// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBracketedParameterListSyntax : TameBaseParameterListSyntax
    {
        public new static string TypeName = "BracketedParameterListSyntax";
        private SyntaxToken _closeBracketToken;
        private bool _closeBracketTokenIsChanged;
        private string _closeBracketTokenStr;
        private SyntaxToken _openBracketToken;
        private bool _openBracketTokenIsChanged;
        private string _openBracketTokenStr;

        public TameBracketedParameterListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBracketedParameterList(code);
            AddChildren();
        }

        public TameBracketedParameterListSyntax(BracketedParameterListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBracketedParameterListSyntax()
        {
            OpenBracketTokenStr = DefaultValues.BracketedParameterListSyntaxOpenBracketTokenStr;
            CloseBracketTokenStr = DefaultValues.BracketedParameterListSyntaxCloseBracketTokenStr;
            ParametersStr = DefaultValues.BracketedParameterListSyntaxParametersStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenBracketToken
        {
            get
            {
                if (_openBracketTokenIsChanged)
                {
                    if (_openBracketTokenStr == null) _openBracketToken = default(SyntaxToken);
                    else
                        _openBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBracketTokenStr, SyntaxKind.OpenBracketToken);
                    _openBracketTokenIsChanged = false;
                }
                return _openBracketToken;
            }
            set
            {
                if (_openBracketToken != value)
                {
                    _openBracketToken = value;
                    _openBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBracketTokenStr
        {
            get
            {
                if (_openBracketTokenIsChanged) return _openBracketTokenStr;
                return _openBracketTokenStr = _openBracketToken.Text;
            }
            set
            {
                if (_openBracketTokenStr != value)
                {
                    _openBracketTokenStr = value;
                    IsChanged = true;
                    _openBracketTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBracketToken
        {
            get
            {
                if (_closeBracketTokenIsChanged)
                {
                    if (_closeBracketTokenStr == null) _closeBracketToken = default(SyntaxToken);
                    else
                        _closeBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBracketTokenStr, SyntaxKind.CloseBracketToken);
                    _closeBracketTokenIsChanged = false;
                }
                return _closeBracketToken;
            }
            set
            {
                if (_closeBracketToken != value)
                {
                    _closeBracketToken = value;
                    _closeBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBracketTokenStr
        {
            get
            {
                if (_closeBracketTokenIsChanged) return _closeBracketTokenStr;
                return _closeBracketTokenStr = _closeBracketToken.Text;
            }
            set
            {
                if (_closeBracketTokenStr != value)
                {
                    _closeBracketTokenStr = value;
                    IsChanged = true;
                    _closeBracketTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _openBracketToken = ((BracketedParameterListSyntax) Node).OpenBracketToken;
            _openBracketTokenIsChanged = false;
            _closeBracketToken = ((BracketedParameterListSyntax) Node).CloseBracketToken;
            _closeBracketTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.BracketedParameterList(OpenBracketToken, Parameters, CloseBracketToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaParameters)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenBracketTokenStr", OpenBracketTokenStr);
            yield return ("CloseBracketTokenStr", CloseBracketTokenStr);
            yield return ("ParametersStr", ParametersStr);
        }

        public TameBracketedParameterListSyntax AddParameter(TameParameterSyntax item)
        {
            item.TaParent = this;
            TaParameters.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}