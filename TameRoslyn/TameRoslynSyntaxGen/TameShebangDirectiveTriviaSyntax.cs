// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameShebangDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "ShebangDirectiveTriviaSyntax";
        private SyntaxToken _exclamationToken;
        private bool _exclamationTokenIsChanged;
        private string _exclamationTokenStr;

        public TameShebangDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseShebangDirectiveTrivia(code);
            AddChildren();
        }

        public TameShebangDirectiveTriviaSyntax(ShebangDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameShebangDirectiveTriviaSyntax()
        {
            // ExclamationTokenStr = DefaultValues.ShebangDirectiveTriviaSyntaxExclamationTokenStr;
            // DirectiveNameTokenStr = DefaultValues.ShebangDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.ShebangDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.ShebangDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.ShebangDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ExclamationToken
        {
            get
            {
                if (_exclamationTokenIsChanged)
                {
                    if (_exclamationTokenStr == null) _exclamationToken = default(SyntaxToken);
                    else
                        _exclamationToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_exclamationTokenStr, SyntaxKind.ExclamationToken);
                    _exclamationTokenIsChanged = false;
                }
                return _exclamationToken;
            }
            set
            {
                if (_exclamationToken != value)
                {
                    _exclamationToken = value;
                    _exclamationTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExclamationTokenStr
        {
            get
            {
                if (_exclamationTokenIsChanged) return _exclamationTokenStr;
                return _exclamationTokenStr = _exclamationToken.Text;
            }
            set
            {
                if (_exclamationTokenStr != value)
                {
                    _exclamationTokenStr = value;
                    IsChanged = true;
                    _exclamationTokenIsChanged = true;
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
            _exclamationToken = ((ShebangDirectiveTriviaSyntax) Node).ExclamationToken;
            _exclamationTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ShebangDirectiveTrivia(HashToken, ExclamationToken, EndOfDirectiveToken, IsActive);
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
            yield return ("ExclamationTokenStr", ExclamationTokenStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}