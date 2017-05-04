// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameElseDirectiveTriviaSyntax : TameBranchingDirectiveTriviaSyntax
    {
        public new static string TypeName = "ElseDirectiveTriviaSyntax";
        private SyntaxToken _elseKeyword;
        private bool _elseKeywordIsChanged;
        private string _elseKeywordStr;

        public TameElseDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseElseDirectiveTrivia(code);
            AddChildren();
        }

        public TameElseDirectiveTriviaSyntax(ElseDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameElseDirectiveTriviaSyntax()
        {
            // ElseKeywordStr = DefaultValues.ElseDirectiveTriviaSyntaxElseKeywordStr;
            // BranchTaken = DefaultValues.ElseDirectiveTriviaSyntaxBranchTaken;
            // DirectiveNameTokenStr = DefaultValues.ElseDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.ElseDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.ElseDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.ElseDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ElseKeyword
        {
            get
            {
                if (_elseKeywordIsChanged)
                {
                    if (_elseKeywordStr == null) _elseKeyword = default(SyntaxToken);
                    else _elseKeyword = SyntaxFactoryStr.ParseSyntaxToken(_elseKeywordStr, SyntaxKind.ElseKeyword);
                    _elseKeywordIsChanged = false;
                }
                return _elseKeyword;
            }
            set
            {
                if (_elseKeyword != value)
                {
                    _elseKeyword = value;
                    _elseKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ElseKeywordStr
        {
            get
            {
                if (_elseKeywordIsChanged) return _elseKeywordStr;
                return _elseKeywordStr = _elseKeyword.Text;
            }
            set
            {
                if (_elseKeywordStr != value)
                {
                    _elseKeywordStr = value;
                    IsChanged = true;
                    _elseKeywordIsChanged = true;
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
            _elseKeyword = ((ElseDirectiveTriviaSyntax) Node).ElseKeyword;
            _elseKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ElseDirectiveTrivia(HashToken, ElseKeyword, EndOfDirectiveToken, IsActive,
                BranchTaken);
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
            yield return ("ElseKeywordStr", ElseKeywordStr);
            yield return ("BranchTaken", BranchTaken.ToString());
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}