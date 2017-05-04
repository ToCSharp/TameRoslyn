// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameWarningDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "WarningDirectiveTriviaSyntax";
        private SyntaxToken _warningKeyword;
        private bool _warningKeywordIsChanged;
        private string _warningKeywordStr;

        public TameWarningDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseWarningDirectiveTrivia(code);
            AddChildren();
        }

        public TameWarningDirectiveTriviaSyntax(WarningDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameWarningDirectiveTriviaSyntax()
        {
            // WarningKeywordStr = DefaultValues.WarningDirectiveTriviaSyntaxWarningKeywordStr;
            // DirectiveNameTokenStr = DefaultValues.WarningDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.WarningDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.WarningDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.WarningDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken WarningKeyword
        {
            get
            {
                if (_warningKeywordIsChanged)
                {
                    if (_warningKeywordStr == null) _warningKeyword = default(SyntaxToken);
                    else
                        _warningKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_warningKeywordStr, SyntaxKind.WarningKeyword);
                    _warningKeywordIsChanged = false;
                }
                return _warningKeyword;
            }
            set
            {
                if (_warningKeyword != value)
                {
                    _warningKeyword = value;
                    _warningKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WarningKeywordStr
        {
            get
            {
                if (_warningKeywordIsChanged) return _warningKeywordStr;
                return _warningKeywordStr = _warningKeyword.Text;
            }
            set
            {
                if (_warningKeywordStr != value)
                {
                    _warningKeywordStr = value;
                    IsChanged = true;
                    _warningKeywordIsChanged = true;
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
            _warningKeyword = ((WarningDirectiveTriviaSyntax) Node).WarningKeyword;
            _warningKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.WarningDirectiveTrivia(HashToken, WarningKeyword, EndOfDirectiveToken, IsActive);
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
            yield return ("WarningKeywordStr", WarningKeywordStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}