// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameParenthesizedLambdaExpressionSyntax : TameLambdaExpressionSyntax
    {
        public new static string TypeName = "ParenthesizedLambdaExpressionSyntax";
        private ParameterListSyntax _parameterList;
        private bool _parameterListIsChanged;
        private string _parameterListStr;
        private TameParameterListSyntax _taParameterList;

        public TameParenthesizedLambdaExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseParenthesizedLambdaExpression(code);
            AddChildren();
        }

        public TameParenthesizedLambdaExpressionSyntax(ParenthesizedLambdaExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameParenthesizedLambdaExpressionSyntax()
        {
            ParameterListStr = DefaultValues.ParenthesizedLambdaExpressionSyntaxParameterListStr;
            ArrowTokenStr = DefaultValues.ParenthesizedLambdaExpressionSyntaxArrowTokenStr;
            AsyncKeywordStr = DefaultValues.ParenthesizedLambdaExpressionSyntaxAsyncKeywordStr;
            BodyStr = DefaultValues.ParenthesizedLambdaExpressionSyntaxBodyStr;
        }

        public override string RoslynTypeName => TypeName;

        public ParameterListSyntax ParameterList
        {
            get
            {
                if (_parameterListIsChanged)
                {
                    _parameterList = SyntaxFactoryStr.ParseParameterListSyntax(ParameterListStr);
                    _parameterListIsChanged = false;
                    _taParameterList = null;
                }
                else if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    _parameterList = (ParameterListSyntax) _taParameterList.Node;
                }
                return _parameterList;
            }
            set
            {
                if (_parameterList != value)
                {
                    _parameterList = value;
                    _parameterListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ParameterListStr
        {
            get
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                    ParameterList = (ParameterListSyntax) _taParameterList.Node;
                if (_parameterListIsChanged) return _parameterListStr;
                return _parameterListStr = _parameterList?.ToFullString();
            }
            set
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    ParameterList = (ParameterListSyntax) _taParameterList.Node;
                    _parameterListStr = _parameterList?.ToFullString();
                }
                if (_parameterListStr != value)
                {
                    _parameterListStr = value;
                    IsChanged = true;
                    _parameterListIsChanged = true;
                    _taParameterList = null;
                }
            }
        }

        public TameParameterListSyntax TaParameterList
        {
            get
            {
                if (_taParameterList == null && ParameterList != null)
                {
                    _taParameterList = new TameParameterListSyntax(ParameterList) {TaParent = this};
                    _taParameterList.AddChildren();
                }
                return _taParameterList;
            }
            set
            {
                if (_taParameterList != value)
                {
                    _taParameterList = value;
                    if (_taParameterList != null)
                    {
                        _taParameterList.TaParent = this;
                        _taParameterList.IsChanged = true;
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
            _taParameterList = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _parameterList = ((ParenthesizedLambdaExpressionSyntax) Node).ParameterList;
            _parameterListIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ParenthesizedLambdaExpression(AsyncKeyword, ParameterList, ArrowToken, Body);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("ArrowTokenStr", ArrowTokenStr);
            yield return ("AsyncKeywordStr", AsyncKeywordStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}