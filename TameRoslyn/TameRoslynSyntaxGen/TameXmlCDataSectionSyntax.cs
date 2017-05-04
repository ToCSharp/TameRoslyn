// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlCDataSectionSyntax : TameXmlNodeSyntax
    {
        public new static string TypeName = "XmlCDataSectionSyntax";
        private SyntaxToken _endCDataToken;
        private bool _endCDataTokenIsChanged;
        private string _endCDataTokenStr;
        private SyntaxToken _startCDataToken;
        private bool _startCDataTokenIsChanged;
        private string _startCDataTokenStr;
        private TameSyntaxTokenList _taTextTokens;
        private SyntaxTokenList _textTokens;
        private bool _textTokensIsChanged;
        private string _textTokensStr;

        public TameXmlCDataSectionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlCDataSection(code);
            AddChildren();
        }

        public TameXmlCDataSectionSyntax(XmlCDataSectionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlCDataSectionSyntax()
        {
            // StartCDataTokenStr = DefaultValues.XmlCDataSectionSyntaxStartCDataTokenStr;
            // TextTokensStr = DefaultValues.XmlCDataSectionSyntaxTextTokensStr;
            // EndCDataTokenStr = DefaultValues.XmlCDataSectionSyntaxEndCDataTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken StartCDataToken
        {
            get
            {
                if (_startCDataTokenIsChanged)
                {
                    _startCDataToken = SyntaxFactoryStr.ParseSyntaxToken(StartCDataTokenStr);
                    _startCDataTokenIsChanged = false;
                }
                return _startCDataToken;
            }
            set
            {
                if (_startCDataToken != value)
                {
                    _startCDataToken = value;
                    _startCDataTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StartCDataTokenStr
        {
            get
            {
                if (_startCDataTokenIsChanged) return _startCDataTokenStr;
                return _startCDataTokenStr = _startCDataToken.Text;
            }
            set
            {
                if (_startCDataTokenStr != value)
                {
                    _startCDataTokenStr = value;
                    IsChanged = true;
                    _startCDataTokenIsChanged = true;
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

        public SyntaxToken EndCDataToken
        {
            get
            {
                if (_endCDataTokenIsChanged)
                {
                    _endCDataToken = SyntaxFactoryStr.ParseSyntaxToken(EndCDataTokenStr);
                    _endCDataTokenIsChanged = false;
                }
                return _endCDataToken;
            }
            set
            {
                if (_endCDataToken != value)
                {
                    _endCDataToken = value;
                    _endCDataTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndCDataTokenStr
        {
            get
            {
                if (_endCDataTokenIsChanged) return _endCDataTokenStr;
                return _endCDataTokenStr = _endCDataToken.Text;
            }
            set
            {
                if (_endCDataTokenStr != value)
                {
                    _endCDataTokenStr = value;
                    IsChanged = true;
                    _endCDataTokenIsChanged = true;
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
            _startCDataToken = ((XmlCDataSectionSyntax) Node).StartCDataToken;
            _startCDataTokenIsChanged = false;
            _textTokens = ((XmlCDataSectionSyntax) Node).TextTokens;
            _textTokensIsChanged = false;
            _endCDataToken = ((XmlCDataSectionSyntax) Node).EndCDataToken;
            _endCDataTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlCDataSection(StartCDataToken, TextTokens, EndCDataToken);
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
            yield return ("StartCDataTokenStr", StartCDataTokenStr);
            yield return ("TextTokensStr", TextTokensStr);
            yield return ("EndCDataTokenStr", EndCDataTokenStr);
        }
    }
}