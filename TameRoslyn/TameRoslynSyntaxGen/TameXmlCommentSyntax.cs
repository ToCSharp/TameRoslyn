// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlCommentSyntax : TameXmlNodeSyntax
    {
        public new static string TypeName = "XmlCommentSyntax";
        private SyntaxToken _lessThanExclamationMinusMinusToken;
        private bool _lessThanExclamationMinusMinusTokenIsChanged;
        private string _lessThanExclamationMinusMinusTokenStr;
        private SyntaxToken _minusMinusGreaterThanToken;
        private bool _minusMinusGreaterThanTokenIsChanged;
        private string _minusMinusGreaterThanTokenStr;
        private TameSyntaxTokenList _taTextTokens;
        private SyntaxTokenList _textTokens;
        private bool _textTokensIsChanged;
        private string _textTokensStr;

        public TameXmlCommentSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlComment(code);
            AddChildren();
        }

        public TameXmlCommentSyntax(XmlCommentSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlCommentSyntax()
        {
            // LessThanExclamationMinusMinusTokenStr = DefaultValues.XmlCommentSyntaxLessThanExclamationMinusMinusTokenStr;
            // TextTokensStr = DefaultValues.XmlCommentSyntaxTextTokensStr;
            // MinusMinusGreaterThanTokenStr = DefaultValues.XmlCommentSyntaxMinusMinusGreaterThanTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LessThanExclamationMinusMinusToken
        {
            get
            {
                if (_lessThanExclamationMinusMinusTokenIsChanged)
                {
                    _lessThanExclamationMinusMinusToken =
                        SyntaxFactoryStr.ParseSyntaxToken(LessThanExclamationMinusMinusTokenStr);
                    _lessThanExclamationMinusMinusTokenIsChanged = false;
                }
                return _lessThanExclamationMinusMinusToken;
            }
            set
            {
                if (_lessThanExclamationMinusMinusToken != value)
                {
                    _lessThanExclamationMinusMinusToken = value;
                    _lessThanExclamationMinusMinusTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LessThanExclamationMinusMinusTokenStr
        {
            get
            {
                if (_lessThanExclamationMinusMinusTokenIsChanged) return _lessThanExclamationMinusMinusTokenStr;
                return _lessThanExclamationMinusMinusTokenStr = _lessThanExclamationMinusMinusToken.Text;
            }
            set
            {
                if (_lessThanExclamationMinusMinusTokenStr != value)
                {
                    _lessThanExclamationMinusMinusTokenStr = value;
                    IsChanged = true;
                    _lessThanExclamationMinusMinusTokenIsChanged = true;
                }
            }
        }

        public SyntaxTokenList TextTokens
        {
            get
            {
                if (_textTokensIsChanged)
                {
                    _textTokens = SyntaxFactoryStr.ParseSyntaxTokenList(TextTokensStr);
                    _textTokensIsChanged = false;
                    _taTextTokens = null;
                }
                else if (_taTextTokens != null && _taTextTokens.IsChanged)
                {
                    _textTokens = _taTextTokens.Node;
                }
                return _textTokens;
            }
            set
            {
                if (_textTokens != value)
                {
                    _textTokens = value;
                    _textTokensIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TextTokensStr
        {
            get
            {
                if (_taTextTokens != null && _taTextTokens.IsChanged)
                    TextTokens = _taTextTokens.Node;
                if (_textTokensIsChanged) return _textTokensStr;
                return _textTokensStr = _textTokens.ToFullString();
            }
            set
            {
                if (_taTextTokens != null && _taTextTokens.IsChanged)
                {
                    TextTokens = _taTextTokens.Node;
                    _textTokensStr = _textTokens.ToFullString();
                }
                if (_textTokensStr != value)
                {
                    _textTokensStr = value;
                    IsChanged = true;
                    _textTokensIsChanged = true;
                    _taTextTokens = null;
                }
            }
        }

        public TameSyntaxTokenList TaTextTokens
        {
            get
            {
                if (_taTextTokens == null)
                {
                    _taTextTokens = new TameSyntaxTokenList(TextTokens) {TaParent = this};
                    _taTextTokens.AddChildren();
                }
                return _taTextTokens;
            }
            set
            {
                if (_taTextTokens != value)
                {
                    _taTextTokens = value;
                    if (_taTextTokens != null)
                    {
                        _taTextTokens.TaParent = this;
                        _taTextTokens.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken MinusMinusGreaterThanToken
        {
            get
            {
                if (_minusMinusGreaterThanTokenIsChanged)
                {
                    _minusMinusGreaterThanToken = SyntaxFactoryStr.ParseSyntaxToken(MinusMinusGreaterThanTokenStr);
                    _minusMinusGreaterThanTokenIsChanged = false;
                }
                return _minusMinusGreaterThanToken;
            }
            set
            {
                if (_minusMinusGreaterThanToken != value)
                {
                    _minusMinusGreaterThanToken = value;
                    _minusMinusGreaterThanTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string MinusMinusGreaterThanTokenStr
        {
            get
            {
                if (_minusMinusGreaterThanTokenIsChanged) return _minusMinusGreaterThanTokenStr;
                return _minusMinusGreaterThanTokenStr = _minusMinusGreaterThanToken.Text;
            }
            set
            {
                if (_minusMinusGreaterThanTokenStr != value)
                {
                    _minusMinusGreaterThanTokenStr = value;
                    IsChanged = true;
                    _minusMinusGreaterThanTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taTextTokens = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _lessThanExclamationMinusMinusToken = ((XmlCommentSyntax) Node).LessThanExclamationMinusMinusToken;
            _lessThanExclamationMinusMinusTokenIsChanged = false;
            _textTokens = ((XmlCommentSyntax) Node).TextTokens;
            _textTokensIsChanged = false;
            _minusMinusGreaterThanToken = ((XmlCommentSyntax) Node).MinusMinusGreaterThanToken;
            _minusMinusGreaterThanTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlComment(LessThanExclamationMinusMinusToken, TextTokens,
                MinusMinusGreaterThanToken);
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
            yield return ("LessThanExclamationMinusMinusTokenStr", LessThanExclamationMinusMinusTokenStr);
            yield return ("TextTokensStr", TextTokensStr);
            yield return ("MinusMinusGreaterThanTokenStr", MinusMinusGreaterThanTokenStr);
        }
    }
}