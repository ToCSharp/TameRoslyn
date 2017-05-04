// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameRegionDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "RegionDirectiveTriviaSyntax";
        private SyntaxToken _regionKeyword;
        private bool _regionKeywordIsChanged;
        private string _regionKeywordStr;

        public TameRegionDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseRegionDirectiveTrivia(code);
            AddChildren();
        }

        public TameRegionDirectiveTriviaSyntax(RegionDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameRegionDirectiveTriviaSyntax()
        {
            // RegionKeywordStr = DefaultValues.RegionDirectiveTriviaSyntaxRegionKeywordStr;
            // DirectiveNameTokenStr = DefaultValues.RegionDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.RegionDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.RegionDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.RegionDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken RegionKeyword
        {
            get
            {
                if (_regionKeywordIsChanged)
                {
                    if (_regionKeywordStr == null) _regionKeyword = default(SyntaxToken);
                    else
                        _regionKeyword = SyntaxFactoryStr.ParseSyntaxToken(_regionKeywordStr, SyntaxKind.RegionKeyword);
                    _regionKeywordIsChanged = false;
                }
                return _regionKeyword;
            }
            set
            {
                if (_regionKeyword != value)
                {
                    _regionKeyword = value;
                    _regionKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string RegionKeywordStr
        {
            get
            {
                if (_regionKeywordIsChanged) return _regionKeywordStr;
                return _regionKeywordStr = _regionKeyword.Text;
            }
            set
            {
                if (_regionKeywordStr != value)
                {
                    _regionKeywordStr = value;
                    IsChanged = true;
                    _regionKeywordIsChanged = true;
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
            _regionKeyword = ((RegionDirectiveTriviaSyntax) Node).RegionKeyword;
            _regionKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.RegionDirectiveTrivia(HashToken, RegionKeyword, EndOfDirectiveToken, IsActive);
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
            yield return ("RegionKeywordStr", RegionKeywordStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}