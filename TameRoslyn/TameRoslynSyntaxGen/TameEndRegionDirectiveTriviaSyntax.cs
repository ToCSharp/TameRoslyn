// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameEndRegionDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "EndRegionDirectiveTriviaSyntax";
        private SyntaxToken _endRegionKeyword;
        private bool _endRegionKeywordIsChanged;
        private string _endRegionKeywordStr;

        public TameEndRegionDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseEndRegionDirectiveTrivia(code);
            AddChildren();
        }

        public TameEndRegionDirectiveTriviaSyntax(EndRegionDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameEndRegionDirectiveTriviaSyntax()
        {
            // EndRegionKeywordStr = DefaultValues.EndRegionDirectiveTriviaSyntaxEndRegionKeywordStr;
            // DirectiveNameTokenStr = DefaultValues.EndRegionDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.EndRegionDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.EndRegionDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.EndRegionDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken EndRegionKeyword
        {
            get
            {
                if (_endRegionKeywordIsChanged)
                {
                    if (_endRegionKeywordStr == null) _endRegionKeyword = default(SyntaxToken);
                    else
                        _endRegionKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_endRegionKeywordStr, SyntaxKind.EndRegionKeyword);
                    _endRegionKeywordIsChanged = false;
                }
                return _endRegionKeyword;
            }
            set
            {
                if (_endRegionKeyword != value)
                {
                    _endRegionKeyword = value;
                    _endRegionKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndRegionKeywordStr
        {
            get
            {
                if (_endRegionKeywordIsChanged) return _endRegionKeywordStr;
                return _endRegionKeywordStr = _endRegionKeyword.Text;
            }
            set
            {
                if (_endRegionKeywordStr != value)
                {
                    _endRegionKeywordStr = value;
                    IsChanged = true;
                    _endRegionKeywordIsChanged = true;
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
            _endRegionKeyword = ((EndRegionDirectiveTriviaSyntax) Node).EndRegionKeyword;
            _endRegionKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res =
                SyntaxFactory.EndRegionDirectiveTrivia(HashToken, EndRegionKeyword, EndOfDirectiveToken, IsActive);
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
            yield return ("EndRegionKeywordStr", EndRegionKeywordStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}