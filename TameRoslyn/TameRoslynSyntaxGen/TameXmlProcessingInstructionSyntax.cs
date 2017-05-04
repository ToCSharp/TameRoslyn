// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlProcessingInstructionSyntax : TameXmlNodeSyntax
    {
        public new static string TypeName = "XmlProcessingInstructionSyntax";
        private SyntaxToken _endProcessingInstructionToken;
        private bool _endProcessingInstructionTokenIsChanged;
        private string _endProcessingInstructionTokenStr;
        private XmlNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private SyntaxToken _startProcessingInstructionToken;
        private bool _startProcessingInstructionTokenIsChanged;
        private string _startProcessingInstructionTokenStr;
        private TameXmlNameSyntax _taName;
        private TameSyntaxTokenList _taTextTokens;
        private SyntaxTokenList _textTokens;
        private bool _textTokensIsChanged;
        private string _textTokensStr;

        public TameXmlProcessingInstructionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlProcessingInstruction(code);
            AddChildren();
        }

        public TameXmlProcessingInstructionSyntax(XmlProcessingInstructionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlProcessingInstructionSyntax()
        {
            // StartProcessingInstructionTokenStr = DefaultValues.XmlProcessingInstructionSyntaxStartProcessingInstructionTokenStr;
            // NameStr = DefaultValues.XmlProcessingInstructionSyntaxNameStr;
            // TextTokensStr = DefaultValues.XmlProcessingInstructionSyntaxTextTokensStr;
            // EndProcessingInstructionTokenStr = DefaultValues.XmlProcessingInstructionSyntaxEndProcessingInstructionTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken StartProcessingInstructionToken
        {
            get
            {
                if (_startProcessingInstructionTokenIsChanged)
                {
                    _startProcessingInstructionToken =
                        SyntaxFactoryStr.ParseSyntaxToken(StartProcessingInstructionTokenStr);
                    _startProcessingInstructionTokenIsChanged = false;
                }
                return _startProcessingInstructionToken;
            }
            set
            {
                if (_startProcessingInstructionToken != value)
                {
                    _startProcessingInstructionToken = value;
                    _startProcessingInstructionTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StartProcessingInstructionTokenStr
        {
            get
            {
                if (_startProcessingInstructionTokenIsChanged) return _startProcessingInstructionTokenStr;
                return _startProcessingInstructionTokenStr = _startProcessingInstructionToken.Text;
            }
            set
            {
                if (_startProcessingInstructionTokenStr != value)
                {
                    _startProcessingInstructionTokenStr = value;
                    IsChanged = true;
                    _startProcessingInstructionTokenIsChanged = true;
                }
            }
        }

        public XmlNameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseXmlNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (XmlNameSyntax) _taName.Node;
                }
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    _nameIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NameStr
        {
            get
            {
                if (_taName != null && _taName.IsChanged)
                    Name = (XmlNameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (XmlNameSyntax) _taName.Node;
                    _nameStr = _name?.ToFullString();
                }
                if (_nameStr != value)
                {
                    _nameStr = value;
                    IsChanged = true;
                    _nameIsChanged = true;
                    _taName = null;
                }
            }
        }

        public TameXmlNameSyntax TaName
        {
            get
            {
                if (_taName == null && Name != null)
                {
                    _taName = new TameXmlNameSyntax(Name) {TaParent = this};
                    _taName.AddChildren();
                }
                return _taName;
            }
            set
            {
                if (_taName != value)
                {
                    _taName = value;
                    if (_taName != null)
                    {
                        _taName.TaParent = this;
                        _taName.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
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

        public SyntaxToken EndProcessingInstructionToken
        {
            get
            {
                if (_endProcessingInstructionTokenIsChanged)
                {
                    _endProcessingInstructionToken =
                        SyntaxFactoryStr.ParseSyntaxToken(EndProcessingInstructionTokenStr);
                    _endProcessingInstructionTokenIsChanged = false;
                }
                return _endProcessingInstructionToken;
            }
            set
            {
                if (_endProcessingInstructionToken != value)
                {
                    _endProcessingInstructionToken = value;
                    _endProcessingInstructionTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndProcessingInstructionTokenStr
        {
            get
            {
                if (_endProcessingInstructionTokenIsChanged) return _endProcessingInstructionTokenStr;
                return _endProcessingInstructionTokenStr = _endProcessingInstructionToken.Text;
            }
            set
            {
                if (_endProcessingInstructionTokenStr != value)
                {
                    _endProcessingInstructionTokenStr = value;
                    IsChanged = true;
                    _endProcessingInstructionTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taName = null;
            _taTextTokens = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _startProcessingInstructionToken = ((XmlProcessingInstructionSyntax) Node).StartProcessingInstructionToken;
            _startProcessingInstructionTokenIsChanged = false;
            _name = ((XmlProcessingInstructionSyntax) Node).Name;
            _nameIsChanged = false;
            _textTokens = ((XmlProcessingInstructionSyntax) Node).TextTokens;
            _textTokensIsChanged = false;
            _endProcessingInstructionToken = ((XmlProcessingInstructionSyntax) Node).EndProcessingInstructionToken;
            _endProcessingInstructionTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlProcessingInstruction(StartProcessingInstructionToken, Name, TextTokens,
                EndProcessingInstructionToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("StartProcessingInstructionTokenStr", StartProcessingInstructionTokenStr);
            yield return ("NameStr", NameStr);
            yield return ("TextTokensStr", TextTokensStr);
            yield return ("EndProcessingInstructionTokenStr", EndProcessingInstructionTokenStr);
        }
    }
}