// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameSimpleLambdaExpressionSyntax : TameLambdaExpressionSyntax
    {
        public new static string TypeName = "SimpleLambdaExpressionSyntax";
        private ParameterSyntax _parameter;
        private bool _parameterIsChanged;
        private string _parameterStr;
        private TameParameterSyntax _taParameter;

        public TameSimpleLambdaExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSimpleLambdaExpression(code);
            AddChildren();
        }

        public TameSimpleLambdaExpressionSyntax(SimpleLambdaExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSimpleLambdaExpressionSyntax()
        {
            ParameterStr = DefaultValues.SimpleLambdaExpressionSyntaxParameterStr;
            ArrowTokenStr = DefaultValues.SimpleLambdaExpressionSyntaxArrowTokenStr;
            AsyncKeywordStr = DefaultValues.SimpleLambdaExpressionSyntaxAsyncKeywordStr;
            BodyStr = DefaultValues.SimpleLambdaExpressionSyntaxBodyStr;
        }

        public override string RoslynTypeName => TypeName;

        public ParameterSyntax Parameter
        {
            get
            {
                if (_parameterIsChanged)
                {
                    _parameter = SyntaxFactoryStr.ParseParameterSyntax(ParameterStr);
                    _parameterIsChanged = false;
                    _taParameter = null;
                }
                else if (_taParameter != null && _taParameter.IsChanged)
                {
                    _parameter = (ParameterSyntax) _taParameter.Node;
                }
                return _parameter;
            }
            set
            {
                if (_parameter != value)
                {
                    _parameter = value;
                    _parameterIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ParameterStr
        {
            get
            {
                if (_taParameter != null && _taParameter.IsChanged)
                    Parameter = (ParameterSyntax) _taParameter.Node;
                if (_parameterIsChanged) return _parameterStr;
                return _parameterStr = _parameter?.ToFullString();
            }
            set
            {
                if (_taParameter != null && _taParameter.IsChanged)
                {
                    Parameter = (ParameterSyntax) _taParameter.Node;
                    _parameterStr = _parameter?.ToFullString();
                }
                if (_parameterStr != value)
                {
                    _parameterStr = value;
                    IsChanged = true;
                    _parameterIsChanged = true;
                    _taParameter = null;
                }
            }
        }

        public TameParameterSyntax TaParameter
        {
            get
            {
                if (_taParameter == null && Parameter != null)
                {
                    _taParameter = new TameParameterSyntax(Parameter) {TaParent = this};
                    _taParameter.AddChildren();
                }
                return _taParameter;
            }
            set
            {
                if (_taParameter != value)
                {
                    _taParameter = value;
                    if (_taParameter != null)
                    {
                        _taParameter.TaParent = this;
                        _taParameter.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taParameter = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _parameter = ((SimpleLambdaExpressionSyntax) Node).Parameter;
            _parameterIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.SimpleLambdaExpression(AsyncKeyword, Parameter, ArrowToken, Body);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaParameter != null) yield return TaParameter;
            if (TaBody != null) yield return TaBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ParameterStr", ParameterStr);
            yield return ("ArrowTokenStr", ArrowTokenStr);
            yield return ("AsyncKeywordStr", AsyncKeywordStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}