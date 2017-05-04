// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameElementBindingExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "ElementBindingExpressionSyntax";
        private BracketedArgumentListSyntax _argumentList;
        private bool _argumentListIsChanged;
        private string _argumentListStr;
        private TameBracketedArgumentListSyntax _taArgumentList;

        public TameElementBindingExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseElementBindingExpression(code);
            AddChildren();
        }

        public TameElementBindingExpressionSyntax(ElementBindingExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameElementBindingExpressionSyntax()
        {
            ArgumentListStr = DefaultValues.ElementBindingExpressionSyntaxArgumentListStr;
        }

        public override string RoslynTypeName => TypeName;

        public BracketedArgumentListSyntax ArgumentList
        {
            get
            {
                if (_argumentListIsChanged)
                {
                    _argumentList = SyntaxFactoryStr.ParseBracketedArgumentListSyntax(ArgumentListStr);
                    _argumentListIsChanged = false;
                    _taArgumentList = null;
                }
                else if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    _argumentList = (BracketedArgumentListSyntax) _taArgumentList.Node;
                }
                return _argumentList;
            }
            set
            {
                if (_argumentList != value)
                {
                    _argumentList = value;
                    _argumentListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ArgumentListStr
        {
            get
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                    ArgumentList = (BracketedArgumentListSyntax) _taArgumentList.Node;
                if (_argumentListIsChanged) return _argumentListStr;
                return _argumentListStr = _argumentList?.ToFullString();
            }
            set
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    ArgumentList = (BracketedArgumentListSyntax) _taArgumentList.Node;
                    _argumentListStr = _argumentList?.ToFullString();
                }
                if (_argumentListStr != value)
                {
                    _argumentListStr = value;
                    IsChanged = true;
                    _argumentListIsChanged = true;
                    _taArgumentList = null;
                }
            }
        }

        public TameBracketedArgumentListSyntax TaArgumentList
        {
            get
            {
                if (_taArgumentList == null && ArgumentList != null)
                {
                    _taArgumentList = new TameBracketedArgumentListSyntax(ArgumentList) {TaParent = this};
                    _taArgumentList.AddChildren();
                }
                return _taArgumentList;
            }
            set
            {
                if (_taArgumentList != value)
                {
                    _taArgumentList = value;
                    if (_taArgumentList != null)
                    {
                        _taArgumentList.TaParent = this;
                        _taArgumentList.IsChanged = true;
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
            _taArgumentList = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _argumentList = ((ElementBindingExpressionSyntax) Node).ArgumentList;
            _argumentListIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ElementBindingExpression(ArgumentList);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaArgumentList != null) yield return TaArgumentList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ArgumentListStr", ArgumentListStr);
        }
    }
}