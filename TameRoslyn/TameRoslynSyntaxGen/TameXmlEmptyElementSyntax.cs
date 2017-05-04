// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlEmptyElementSyntax : TameXmlNodeSyntax
    {
        public new static string TypeName = "XmlEmptyElementSyntax";
        private SyntaxList<XmlAttributeSyntax> _attributes;
        private int _attributesCount;
        private bool _attributesIsChanged;
        private string _attributesStr;
        private SyntaxToken _lessThanToken;
        private bool _lessThanTokenIsChanged;
        private string _lessThanTokenStr;
        private XmlNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private SyntaxToken _slashGreaterThanToken;
        private bool _slashGreaterThanTokenIsChanged;
        private string _slashGreaterThanTokenStr;
        private List<TameXmlAttributeSyntax> _taAttributes;
        private TameXmlNameSyntax _taName;

        public TameXmlEmptyElementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlEmptyElement(code);
            AddChildren();
        }

        public TameXmlEmptyElementSyntax(XmlEmptyElementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlEmptyElementSyntax()
        {
            // LessThanTokenStr = DefaultValues.XmlEmptyElementSyntaxLessThanTokenStr;
            // NameStr = DefaultValues.XmlEmptyElementSyntaxNameStr;
            // AttributesStr = DefaultValues.XmlEmptyElementSyntaxAttributesStr;
            // SlashGreaterThanTokenStr = DefaultValues.XmlEmptyElementSyntaxSlashGreaterThanTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LessThanToken
        {
            get
            {
                if (_lessThanTokenIsChanged)
                {
                    if (_lessThanTokenStr == null) _lessThanToken = default(SyntaxToken);
                    else
                        _lessThanToken = SyntaxFactoryStr.ParseSyntaxToken(_lessThanTokenStr, SyntaxKind.LessThanToken);
                    _lessThanTokenIsChanged = false;
                }
                return _lessThanToken;
            }
            set
            {
                if (_lessThanToken != value)
                {
                    _lessThanToken = value;
                    _lessThanTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LessThanTokenStr
        {
            get
            {
                if (_lessThanTokenIsChanged) return _lessThanTokenStr;
                return _lessThanTokenStr = _lessThanToken.Text;
            }
            set
            {
                if (_lessThanTokenStr != value)
                {
                    _lessThanTokenStr = value;
                    IsChanged = true;
                    _lessThanTokenIsChanged = true;
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

        public bool TaAttributesIsChanged { get; set; }

        public SyntaxList<XmlAttributeSyntax> Attributes
        {
            get
            {
                if (TaAttributesIsChanged || _taAttributes != null &&
                    (_taAttributes.Count != _attributesCount || _taAttributes.Any(v => v.IsChanged)))
                {
                    _attributes = SyntaxFactory.List(TaAttributes?.Select(v => v.Node).Cast<XmlAttributeSyntax>());
                    TaAttributesIsChanged = false;
                }
                return _attributes;
            }
            set
            {
                if (_attributes != value)
                {
                    _attributes = value;
                    TaAttributesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AttributesStr
        {
            get
            {
                if (_attributesIsChanged) return _attributesStr;
                return _attributesStr = string.Join(", ", _attributes.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _attributesStr = value;
                    Attributes = new SyntaxList<XmlAttributeSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameXmlAttributeSyntax> TaAttributes
        {
            get
            {
                if (_taAttributes == null)
                {
                    _taAttributes = new List<TameXmlAttributeSyntax>();
                    foreach (var item in _attributes)
                        if (item is XmlCrefAttributeSyntax)
                            _taAttributes.Add(
                                new TameXmlCrefAttributeSyntax(item as XmlCrefAttributeSyntax) {TaParent = this});
                        else if (item is XmlNameAttributeSyntax)
                            _taAttributes.Add(
                                new TameXmlNameAttributeSyntax(item as XmlNameAttributeSyntax) {TaParent = this});
                        else if (item is XmlTextAttributeSyntax)
                            _taAttributes.Add(
                                new TameXmlTextAttributeSyntax(item as XmlTextAttributeSyntax) {TaParent = this});
                        else if (item is XmlAttributeSyntax)
                            _taAttributes.Add(new TameXmlAttributeSyntax(item) {TaParent = this});
                }
                return _taAttributes;
            }
            set
            {
                if (_taAttributes != value)
                {
                    _taAttributes = value;
                    _taAttributes?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAttributesIsChanged = true;
                }
            }
        }

        public SyntaxToken SlashGreaterThanToken
        {
            get
            {
                if (_slashGreaterThanTokenIsChanged)
                {
                    if (_slashGreaterThanTokenStr == null) _slashGreaterThanToken = default(SyntaxToken);
                    else
                        _slashGreaterThanToken = SyntaxFactoryStr.ParseSyntaxToken(_slashGreaterThanTokenStr,
                            SyntaxKind.SlashGreaterThanToken);
                    _slashGreaterThanTokenIsChanged = false;
                }
                return _slashGreaterThanToken;
            }
            set
            {
                if (_slashGreaterThanToken != value)
                {
                    _slashGreaterThanToken = value;
                    _slashGreaterThanTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SlashGreaterThanTokenStr
        {
            get
            {
                if (_slashGreaterThanTokenIsChanged) return _slashGreaterThanTokenStr;
                return _slashGreaterThanTokenStr = _slashGreaterThanToken.Text;
            }
            set
            {
                if (_slashGreaterThanTokenStr != value)
                {
                    _slashGreaterThanTokenStr = value;
                    IsChanged = true;
                    _slashGreaterThanTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taName = null;
            _taAttributes = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _lessThanToken = ((XmlEmptyElementSyntax) Node).LessThanToken;
            _lessThanTokenIsChanged = false;
            _name = ((XmlEmptyElementSyntax) Node).Name;
            _nameIsChanged = false;
            _attributes = ((XmlEmptyElementSyntax) Node).Attributes;
            _attributesIsChanged = false;
            _attributesCount = _attributes.Count;
            _slashGreaterThanToken = ((XmlEmptyElementSyntax) Node).SlashGreaterThanToken;
            _slashGreaterThanTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaAttributes)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlEmptyElement(LessThanToken, Name, Attributes, SlashGreaterThanToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributes)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("LessThanTokenStr", LessThanTokenStr);
            yield return ("NameStr", NameStr);
            yield return ("AttributesStr", AttributesStr);
            yield return ("SlashGreaterThanTokenStr", SlashGreaterThanTokenStr);
        }

        public TameXmlEmptyElementSyntax AddAttribute(TameXmlAttributeSyntax item)
        {
            item.TaParent = this;
            TaAttributes.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}