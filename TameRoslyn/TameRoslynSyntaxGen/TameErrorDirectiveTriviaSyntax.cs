// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameErrorDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "ErrorDirectiveTriviaSyntax";
        private SyntaxToken _errorKeyword;
        private bool _errorKeywordIsChanged;
        private string _errorKeywordStr;

        public TameErrorDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseErrorDirectiveTrivia(code);
            AddChildren();
        }

        public TameErrorDirectiveTriviaSyntax(ErrorDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameErrorDirectiveTriviaSyntax()
        {
            // ErrorKeywordStr = DefaultValues.ErrorDirectiveTriviaSyntaxErrorKeywordStr;
            // DirectiveNameTokenStr = DefaultValues.ErrorDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.ErrorDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.ErrorDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.ErrorDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ErrorKeyword
        {
            get
            {
                if (_errorKeywordIsChanged)
                {
                    if (_errorKeywordStr == null) _errorKeyword = default(SyntaxToken);
                    else _errorKeyword = SyntaxFactoryStr.ParseSyntaxToken(_errorKeywordStr, SyntaxKind.ErrorKeyword);
                    _errorKeywordIsChanged = false;
                }
                return _errorKeyword;
            }
            set
            {
                if (_errorKeyword != value)
                {
                    _errorKeyword = value;
                    _errorKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ErrorKeywordStr
        {
            get
            {
                if (_errorKeywordIsChanged) return _errorKeywordStr;
                return _errorKeywordStr = _errorKeyword.Text;
            }
            set
            {
                if (_errorKeywordStr != value)
                {
                    _errorKeywordStr = value;
                    IsChanged = true;
                    _errorKeywordIsChanged = true;
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
            _errorKeyword = ((ErrorDirectiveTriviaSyntax) Node).ErrorKeyword;
            _errorKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ErrorDirectiveTrivia(HashToken, ErrorKeyword, EndOfDirectiveToken, IsActive);
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
            yield return ("ErrorKeywordStr", ErrorKeywordStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}