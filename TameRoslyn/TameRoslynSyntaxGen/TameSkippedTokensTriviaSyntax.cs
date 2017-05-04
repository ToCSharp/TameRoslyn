// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameSkippedTokensTriviaSyntax : TameStructuredTriviaSyntax
    {
        public new static string TypeName = "SkippedTokensTriviaSyntax";
        private TameSyntaxTokenList _taTokens;
        private SyntaxTokenList _tokens;
        private bool _tokensIsChanged;
        private string _tokensStr;

        public TameSkippedTokensTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSkippedTokensTrivia(code);
            AddChildren();
        }

        public TameSkippedTokensTriviaSyntax(SkippedTokensTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSkippedTokensTriviaSyntax()
        {
            // TokensStr = DefaultValues.SkippedTokensTriviaSyntaxTokensStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxTokenList Tokens
        {
            get
            {
                if (_tokensIsChanged)
                {
                    _tokens = SyntaxFactoryStr.ParseSyntaxTokenList(TokensStr);
                    _tokensIsChanged = false;
                    _taTokens = null;
                }
                else if (_taTokens != null && _taTokens.IsChanged)
                {
                    _tokens = _taTokens.Node;
                }
                return _tokens;
            }
            set
            {
                if (_tokens != value)
                {
                    _tokens = value;
                    _tokensIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TokensStr
        {
            get
            {
                if (_taTokens != null && _taTokens.IsChanged)
                    Tokens = _taTokens.Node;
                if (_tokensIsChanged) return _tokensStr;
                return _tokensStr = _tokens.ToFullString();
            }
            set
            {
                if (_taTokens != null && _taTokens.IsChanged)
                {
                    Tokens = _taTokens.Node;
                    _tokensStr = _tokens.ToFullString();
                }
                if (_tokensStr != value)
                {
                    _tokensStr = value;
                    IsChanged = true;
                    _tokensIsChanged = true;
                    _taTokens = null;
                }
            }
        }

        public TameSyntaxTokenList TaTokens
        {
            get
            {
                if (_taTokens == null)
                {
                    _taTokens = new TameSyntaxTokenList(Tokens) {TaParent = this};
                    _taTokens.AddChildren();
                }
                return _taTokens;
            }
            set
            {
                if (_taTokens != value)
                {
                    _taTokens = value;
                    if (_taTokens != null)
                    {
                        _taTokens.TaParent = this;
                        _taTokens.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taTokens = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _tokens = ((SkippedTokensTriviaSyntax) Node).Tokens;
            _tokensIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.SkippedTokensTrivia(Tokens);
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
            yield return ("TokensStr", TokensStr);
        }
    }
}