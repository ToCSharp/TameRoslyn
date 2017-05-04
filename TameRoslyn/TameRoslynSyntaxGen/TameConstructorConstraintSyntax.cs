// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameConstructorConstraintSyntax : TameTypeParameterConstraintSyntax
    {
        public new static string TypeName = "ConstructorConstraintSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private SyntaxToken _newKeyword;
        private bool _newKeywordIsChanged;
        private string _newKeywordStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;

        public TameConstructorConstraintSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseConstructorConstraint(code);
            AddChildren();
        }

        public TameConstructorConstraintSyntax(ConstructorConstraintSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameConstructorConstraintSyntax()
        {
            NewKeywordStr = DefaultValues.ConstructorConstraintSyntaxNewKeywordStr;
            OpenParenTokenStr = DefaultValues.ConstructorConstraintSyntaxOpenParenTokenStr;
            CloseParenTokenStr = DefaultValues.ConstructorConstraintSyntaxCloseParenTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken NewKeyword
        {
            get
            {
                if (_newKeywordIsChanged)
                {
                    if (_newKeywordStr == null) _newKeyword = default(SyntaxToken);
                    else _newKeyword = SyntaxFactoryStr.ParseSyntaxToken(_newKeywordStr, SyntaxKind.NewKeyword);
                    _newKeywordIsChanged = false;
                }
                return _newKeyword;
            }
            set
            {
                if (_newKeyword != value)
                {
                    _newKeyword = value;
                    _newKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NewKeywordStr
        {
            get
            {
                if (_newKeywordIsChanged) return _newKeywordStr;
                return _newKeywordStr = _newKeyword.Text;
            }
            set
            {
                if (_newKeywordStr != value)
                {
                    _newKeywordStr = value;
                    IsChanged = true;
                    _newKeywordIsChanged = true;
                }
            }
        }

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
            _newKeyword = ((ConstructorConstraintSyntax) Node).NewKeyword;
            _newKeywordIsChanged = false;
            _openParenToken = ((ConstructorConstraintSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _closeParenToken = ((ConstructorConstraintSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ConstructorConstraint(NewKeyword, OpenParenToken, CloseParenToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NewKeywordStr", NewKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
        }
    }
}