// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameDirectiveTriviaSyntax : TameStructuredTriviaSyntax
    {
        public new static string TypeName = "DirectiveTriviaSyntax";
        private SyntaxToken _directiveNameToken;
        private bool _directiveNameTokenIsChanged;
        private string _directiveNameTokenStr;
        private SyntaxToken _endOfDirectiveToken;
        private bool _endOfDirectiveTokenIsChanged;
        private string _endOfDirectiveTokenStr;
        private SyntaxToken _hashToken;
        private bool _hashTokenIsChanged;
        private string _hashTokenStr;
        private bool _isActive;
        private bool _isActiveIsChanged;

        public TameDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDirectiveTrivia(code);
            AddChildren();
        }

        public TameDirectiveTriviaSyntax(DirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDirectiveTriviaSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken DirectiveNameToken
        {
            get
            {
                if (_directiveNameTokenIsChanged)
                {
                    _directiveNameToken = SyntaxFactoryStr.ParseSyntaxToken(DirectiveNameTokenStr);
                    _directiveNameTokenIsChanged = false;
                }
                return _directiveNameToken;
            }
            set
            {
                if (_directiveNameToken != value)
                {
                    _directiveNameToken = value;
                    _directiveNameTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DirectiveNameTokenStr
        {
            get
            {
                if (_directiveNameTokenIsChanged) return _directiveNameTokenStr;
                return _directiveNameTokenStr = _directiveNameToken.Text;
            }
            set
            {
                if (_directiveNameTokenStr != value)
                {
                    _directiveNameTokenStr = value;
                    IsChanged = true;
                    _directiveNameTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken HashToken
        {
            get
            {
                if (_hashTokenIsChanged)
                {
                    if (_hashTokenStr == null) _hashToken = default(SyntaxToken);
                    else _hashToken = SyntaxFactoryStr.ParseSyntaxToken(_hashTokenStr, SyntaxKind.HashToken);
                    _hashTokenIsChanged = false;
                }
                return _hashToken;
            }
            set
            {
                if (_hashToken != value)
                {
                    _hashToken = value;
                    _hashTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string HashTokenStr
        {
            get
            {
                if (_hashTokenIsChanged) return _hashTokenStr;
                return _hashTokenStr = _hashToken.Text;
            }
            set
            {
                if (_hashTokenStr != value)
                {
                    _hashTokenStr = value;
                    IsChanged = true;
                    _hashTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken EndOfDirectiveToken
        {
            get
            {
                if (_endOfDirectiveTokenIsChanged)
                {
                    if (_endOfDirectiveTokenStr == null) _endOfDirectiveToken = default(SyntaxToken);
                    else
                        _endOfDirectiveToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_endOfDirectiveTokenStr, SyntaxKind.EndOfDirectiveToken);
                    _endOfDirectiveTokenIsChanged = false;
                }
                return _endOfDirectiveToken;
            }
            set
            {
                if (_endOfDirectiveToken != value)
                {
                    _endOfDirectiveToken = value;
                    _endOfDirectiveTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndOfDirectiveTokenStr
        {
            get
            {
                if (_endOfDirectiveTokenIsChanged) return _endOfDirectiveTokenStr;
                return _endOfDirectiveTokenStr = _endOfDirectiveToken.Text;
            }
            set
            {
                if (_endOfDirectiveTokenStr != value)
                {
                    _endOfDirectiveTokenStr = value;
                    IsChanged = true;
                    _endOfDirectiveTokenIsChanged = true;
                }
            }
        }

        public bool IsActive
        {
            get { return _isActive; }
            set
            {
                if (_isActive != value)
                {
                    _isActive = value;
                    _isActiveIsChanged = false;
                    IsChanged = true;
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
            _directiveNameToken = ((DirectiveTriviaSyntax) Node).DirectiveNameToken;
            _directiveNameTokenIsChanged = false;
            _hashToken = ((DirectiveTriviaSyntax) Node).HashToken;
            _hashTokenIsChanged = false;
            _endOfDirectiveToken = ((DirectiveTriviaSyntax) Node).EndOfDirectiveToken;
            _endOfDirectiveTokenIsChanged = false;
            _isActive = ((DirectiveTriviaSyntax) Node).IsActive;
            _isActiveIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
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
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}