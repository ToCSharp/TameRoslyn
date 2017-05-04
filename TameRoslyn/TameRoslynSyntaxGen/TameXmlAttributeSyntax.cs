// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameXmlAttributeSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "XmlAttributeSyntax";
        private SyntaxToken _endQuoteToken;
        private bool _endQuoteTokenIsChanged;
        private string _endQuoteTokenStr;
        private SyntaxToken _equalsToken;
        private bool _equalsTokenIsChanged;
        private string _equalsTokenStr;
        private XmlNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private SyntaxToken _startQuoteToken;
        private bool _startQuoteTokenIsChanged;
        private string _startQuoteTokenStr;
        private TameXmlNameSyntax _taName;

        public TameXmlAttributeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlAttribute(code);
            AddChildren();
        }

        public TameXmlAttributeSyntax(XmlAttributeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlAttributeSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

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

        public SyntaxToken EqualsToken
        {
            get
            {
                if (_equalsTokenIsChanged)
                {
                    if (_equalsTokenStr == null) _equalsToken = default(SyntaxToken);
                    else _equalsToken = SyntaxFactoryStr.ParseSyntaxToken(_equalsTokenStr, SyntaxKind.EqualsToken);
                    _equalsTokenIsChanged = false;
                }
                return _equalsToken;
            }
            set
            {
                if (_equalsToken != value)
                {
                    _equalsToken = value;
                    _equalsTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EqualsTokenStr
        {
            get
            {
                if (_equalsTokenIsChanged) return _equalsTokenStr;
                return _equalsTokenStr = _equalsToken.Text;
            }
            set
            {
                if (_equalsTokenStr != value)
                {
                    _equalsTokenStr = value;
                    IsChanged = true;
                    _equalsTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken StartQuoteToken
        {
            get
            {
                if (_startQuoteTokenIsChanged)
                {
                    _startQuoteToken = SyntaxFactoryStr.ParseSyntaxToken(StartQuoteTokenStr);
                    _startQuoteTokenIsChanged = false;
                }
                return _startQuoteToken;
            }
            set
            {
                if (_startQuoteToken != value)
                {
                    _startQuoteToken = value;
                    _startQuoteTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StartQuoteTokenStr
        {
            get
            {
                if (_startQuoteTokenIsChanged) return _startQuoteTokenStr;
                return _startQuoteTokenStr = _startQuoteToken.Text;
            }
            set
            {
                if (_startQuoteTokenStr != value)
                {
                    _startQuoteTokenStr = value;
                    IsChanged = true;
                    _startQuoteTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken EndQuoteToken
        {
            get
            {
                if (_endQuoteTokenIsChanged)
                {
                    _endQuoteToken = SyntaxFactoryStr.ParseSyntaxToken(EndQuoteTokenStr);
                    _endQuoteTokenIsChanged = false;
                }
                return _endQuoteToken;
            }
            set
            {
                if (_endQuoteToken != value)
                {
                    _endQuoteToken = value;
                    _endQuoteTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndQuoteTokenStr
        {
            get
            {
                if (_endQuoteTokenIsChanged) return _endQuoteTokenStr;
                return _endQuoteTokenStr = _endQuoteToken.Text;
            }
            set
            {
                if (_endQuoteTokenStr != value)
                {
                    _endQuoteTokenStr = value;
                    IsChanged = true;
                    _endQuoteTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taName = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _name = ((XmlAttributeSyntax) Node).Name;
            _nameIsChanged = false;
            _equalsToken = ((XmlAttributeSyntax) Node).EqualsToken;
            _equalsTokenIsChanged = false;
            _startQuoteToken = ((XmlAttributeSyntax) Node).StartQuoteToken;
            _startQuoteTokenIsChanged = false;
            _endQuoteToken = ((XmlAttributeSyntax) Node).EndQuoteToken;
            _endQuoteTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
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
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NameStr", NameStr);
            yield return ("EqualsTokenStr", EqualsTokenStr);
            yield return ("StartQuoteTokenStr", StartQuoteTokenStr);
            yield return ("EndQuoteTokenStr", EndQuoteTokenStr);
        }
    }
}