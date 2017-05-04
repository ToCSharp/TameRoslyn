// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameUndefDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "UndefDirectiveTriviaSyntax";
        private SyntaxToken _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private SyntaxToken _undefKeyword;
        private bool _undefKeywordIsChanged;
        private string _undefKeywordStr;

        public TameUndefDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseUndefDirectiveTrivia(code);
            AddChildren();
        }

        public TameUndefDirectiveTriviaSyntax(UndefDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameUndefDirectiveTriviaSyntax()
        {
            // UndefKeywordStr = DefaultValues.UndefDirectiveTriviaSyntaxUndefKeywordStr;
            // NameStr = DefaultValues.UndefDirectiveTriviaSyntaxNameStr;
            // DirectiveNameTokenStr = DefaultValues.UndefDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.UndefDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.UndefDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.UndefDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken UndefKeyword
        {
            get
            {
                if (_undefKeywordIsChanged)
                {
                    if (_undefKeywordStr == null) _undefKeyword = default(SyntaxToken);
                    else _undefKeyword = SyntaxFactoryStr.ParseSyntaxToken(_undefKeywordStr, SyntaxKind.UndefKeyword);
                    _undefKeywordIsChanged = false;
                }
                return _undefKeyword;
            }
            set
            {
                if (_undefKeyword != value)
                {
                    _undefKeyword = value;
                    _undefKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string UndefKeywordStr
        {
            get
            {
                if (_undefKeywordIsChanged) return _undefKeywordStr;
                return _undefKeywordStr = _undefKeyword.Text;
            }
            set
            {
                if (_undefKeywordStr != value)
                {
                    _undefKeywordStr = value;
                    IsChanged = true;
                    _undefKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseSyntaxToken(NameStr);
                    _nameIsChanged = false;
                }
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    _nameIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NameStr
        {
            get
            {
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name.Text;
            }
            set
            {
                if (_nameStr != value)
                {
                    _nameStr = value;
                    IsChanged = true;
                    _nameIsChanged = true;
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
            _undefKeyword = ((UndefDirectiveTriviaSyntax) Node).UndefKeyword;
            _undefKeywordIsChanged = false;
            _name = ((UndefDirectiveTriviaSyntax) Node).Name;
            _nameIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.UndefDirectiveTrivia(HashToken, UndefKeyword, Name, EndOfDirectiveToken, IsActive);
// if (DirectiveNameToken != null) res = res.WithDirectiveNameToken(DirectiveNameToken);
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
            yield return ("UndefKeywordStr", UndefKeywordStr);
            yield return ("NameStr", NameStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}