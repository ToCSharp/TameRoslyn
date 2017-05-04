// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDefineDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "DefineDirectiveTriviaSyntax";
        private SyntaxToken _defineKeyword;
        private bool _defineKeywordIsChanged;
        private string _defineKeywordStr;
        private SyntaxToken _name;
        private bool _nameIsChanged;
        private string _nameStr;

        public TameDefineDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDefineDirectiveTrivia(code);
            AddChildren();
        }

        public TameDefineDirectiveTriviaSyntax(DefineDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDefineDirectiveTriviaSyntax()
        {
            // DefineKeywordStr = DefaultValues.DefineDirectiveTriviaSyntaxDefineKeywordStr;
            // NameStr = DefaultValues.DefineDirectiveTriviaSyntaxNameStr;
            // DirectiveNameTokenStr = DefaultValues.DefineDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.DefineDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.DefineDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.DefineDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken DefineKeyword
        {
            get
            {
                if (_defineKeywordIsChanged)
                {
                    if (_defineKeywordStr == null) _defineKeyword = default(SyntaxToken);
                    else
                        _defineKeyword = SyntaxFactoryStr.ParseSyntaxToken(_defineKeywordStr, SyntaxKind.DefineKeyword);
                    _defineKeywordIsChanged = false;
                }
                return _defineKeyword;
            }
            set
            {
                if (_defineKeyword != value)
                {
                    _defineKeyword = value;
                    _defineKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DefineKeywordStr
        {
            get
            {
                if (_defineKeywordIsChanged) return _defineKeywordStr;
                return _defineKeywordStr = _defineKeyword.Text;
            }
            set
            {
                if (_defineKeywordStr != value)
                {
                    _defineKeywordStr = value;
                    IsChanged = true;
                    _defineKeywordIsChanged = true;
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
            _defineKeyword = ((DefineDirectiveTriviaSyntax) Node).DefineKeyword;
            _defineKeywordIsChanged = false;
            _name = ((DefineDirectiveTriviaSyntax) Node).Name;
            _nameIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.DefineDirectiveTrivia(HashToken, DefineKeyword, Name, EndOfDirectiveToken,
                IsActive);
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
            yield return ("DefineKeywordStr", DefineKeywordStr);
            yield return ("NameStr", NameStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}