// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameEndIfDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "EndIfDirectiveTriviaSyntax";
        private SyntaxToken _endIfKeyword;
        private bool _endIfKeywordIsChanged;
        private string _endIfKeywordStr;

        public TameEndIfDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseEndIfDirectiveTrivia(code);
            AddChildren();
        }

        public TameEndIfDirectiveTriviaSyntax(EndIfDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameEndIfDirectiveTriviaSyntax()
        {
            // EndIfKeywordStr = DefaultValues.EndIfDirectiveTriviaSyntaxEndIfKeywordStr;
            // DirectiveNameTokenStr = DefaultValues.EndIfDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.EndIfDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.EndIfDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.EndIfDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken EndIfKeyword
        {
            get
            {
                if (_endIfKeywordIsChanged)
                {
                    if (_endIfKeywordStr == null) _endIfKeyword = default(SyntaxToken);
                    else _endIfKeyword = SyntaxFactoryStr.ParseSyntaxToken(_endIfKeywordStr, SyntaxKind.EndIfKeyword);
                    _endIfKeywordIsChanged = false;
                }
                return _endIfKeyword;
            }
            set
            {
                if (_endIfKeyword != value)
                {
                    _endIfKeyword = value;
                    _endIfKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndIfKeywordStr
        {
            get
            {
                if (_endIfKeywordIsChanged) return _endIfKeywordStr;
                return _endIfKeywordStr = _endIfKeyword.Text;
            }
            set
            {
                if (_endIfKeywordStr != value)
                {
                    _endIfKeywordStr = value;
                    IsChanged = true;
                    _endIfKeywordIsChanged = true;
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
            _endIfKeyword = ((EndIfDirectiveTriviaSyntax) Node).EndIfKeyword;
            _endIfKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.EndIfDirectiveTrivia(HashToken, EndIfKeyword, EndOfDirectiveToken, IsActive);
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
            yield return ("EndIfKeywordStr", EndIfKeywordStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}