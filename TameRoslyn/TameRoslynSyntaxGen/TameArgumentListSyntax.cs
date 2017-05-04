// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameArgumentListSyntax : TameBaseArgumentListSyntax
    {
        public new static string TypeName = "ArgumentListSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;

        public TameArgumentListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseArgumentList(code);
            AddChildren();
        }

        public TameArgumentListSyntax(ArgumentListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameArgumentListSyntax()
        {
            OpenParenTokenStr = DefaultValues.ArgumentListSyntaxOpenParenTokenStr;
            CloseParenTokenStr = DefaultValues.ArgumentListSyntaxCloseParenTokenStr;
            ArgumentsStr = DefaultValues.ArgumentListSyntaxArgumentsStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenParenToken
        {
            get
            {
                if (_openParenTokenIsChanged)
                {
                    if (_openParenTokenStr == null) _openParenToken = default(SyntaxToken);
                    else
                        _openParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openParenTokenStr, SyntaxKind.OpenParenToken);
                    _openParenTokenIsChanged = false;
                }
                return _openParenToken;
            }
            set
            {
                if (_openParenToken != value)
                {
                    _openParenToken = value;
                    _openParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenParenTokenStr
        {
            get
            {
                if (_openParenTokenIsChanged) return _openParenTokenStr;
                return _openParenTokenStr = _openParenToken.Text;
            }
            set
            {
                if (_openParenTokenStr != value)
                {
                    _openParenTokenStr = value;
                    IsChanged = true;
                    _openParenTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseParenToken
        {
            get
            {
                if (_closeParenTokenIsChanged)
                {
                    if (_closeParenTokenStr == null) _closeParenToken = default(SyntaxToken);
                    else
                        _closeParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeParenTokenStr, SyntaxKind.CloseParenToken);
                    _closeParenTokenIsChanged = false;
                }
                return _closeParenToken;
            }
            set
            {
                if (_closeParenToken != value)
                {
                    _closeParenToken = value;
                    _closeParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseParenTokenStr
        {
            get
            {
                if (_closeParenTokenIsChanged) return _closeParenTokenStr;
                return _closeParenTokenStr = _closeParenToken.Text;
            }
            set
            {
                if (_closeParenTokenStr != value)
                {
                    _closeParenTokenStr = value;
                    IsChanged = true;
                    _closeParenTokenIsChanged = true;
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
            _openParenToken = ((ArgumentListSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _closeParenToken = ((ArgumentListSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ArgumentList(OpenParenToken, Arguments, CloseParenToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaArguments)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("ArgumentsStr", ArgumentsStr);
        }

        public TameArgumentListSyntax AddArgument(TameArgumentSyntax item)
        {
            item.TaParent = this;
            TaArguments.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}