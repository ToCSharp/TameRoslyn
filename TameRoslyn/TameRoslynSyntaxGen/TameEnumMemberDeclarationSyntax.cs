// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameEnumMemberDeclarationSyntax : TameMemberDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "EnumMemberDeclarationSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private EqualsValueClauseSyntax _equalsValue;
        private bool _equalsValueIsChanged;
        private string _equalsValueStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private TameEqualsValueClauseSyntax _taEqualsValue;

        public TameEnumMemberDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseEnumMemberDeclaration(code);
            AddChildren();
        }

        public TameEnumMemberDeclarationSyntax(EnumMemberDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameEnumMemberDeclarationSyntax()
        {
            AttributeListsStr = DefaultValues.EnumMemberDeclarationSyntaxAttributeListsStr;
            IdentifierStr = DefaultValues.EnumMemberDeclarationSyntaxIdentifierStr;
            EqualsValueStr = DefaultValues.EnumMemberDeclarationSyntaxEqualsValueStr;
        }

        public override string RoslynTypeName => TypeName;
        public bool TaAttributeListsIsChanged { get; set; }

        public SyntaxList<AttributeListSyntax> AttributeLists
        {
            get
            {
                if (TaAttributeListsIsChanged || _taAttributeLists != null &&
                    (_taAttributeLists.Count != _attributeListsCount || _taAttributeLists.Any(v => v.IsChanged)))
                {
                    _attributeLists = SyntaxFactory.List(TaAttributeLists?.Select(v => v.Node)
                        .Cast<AttributeListSyntax>());
                    TaAttributeListsIsChanged = false;
                }
                return _attributeLists;
            }
            set
            {
                if (_attributeLists != value)
                {
                    _attributeLists = value;
                    TaAttributeListsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AttributeListsStr
        {
            get
            {
                if (_attributeListsIsChanged) return _attributeListsStr;
                return _attributeListsStr = string.Join(", ", _attributeLists.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _attributeListsStr = value;
                    AttributeLists = new SyntaxList<AttributeListSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAttributeListSyntax> TaAttributeLists
        {
            get
            {
                if (_taAttributeLists == null)
                {
                    _taAttributeLists = new List<TameAttributeListSyntax>();
                    foreach (var item in _attributeLists)
                        _taAttributeLists.Add(new TameAttributeListSyntax(item) {TaParent = this});
                }
                return _taAttributeLists;
            }
            set
            {
                if (_taAttributeLists != value)
                {
                    _taAttributeLists = value;
                    _taAttributeLists?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAttributeListsIsChanged = true;
                }
            }
        }

        public EqualsValueClauseSyntax EqualsValue
        {
            get
            {
                if (_equalsValueIsChanged)
                {
                    _equalsValue = SyntaxFactoryStr.ParseEqualsValueClauseSyntax(EqualsValueStr);
                    _equalsValueIsChanged = false;
                    _taEqualsValue = null;
                }
                else if (_taEqualsValue != null && _taEqualsValue.IsChanged)
                {
                    _equalsValue = (EqualsValueClauseSyntax) _taEqualsValue.Node;
                }
                return _equalsValue;
            }
            set
            {
                if (_equalsValue != value)
                {
                    _equalsValue = value;
                    _equalsValueIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EqualsValueStr
        {
            get
            {
                if (_taEqualsValue != null && _taEqualsValue.IsChanged)
                    EqualsValue = (EqualsValueClauseSyntax) _taEqualsValue.Node;
                if (_equalsValueIsChanged) return _equalsValueStr;
                return _equalsValueStr = _equalsValue?.ToFullString();
            }
            set
            {
                if (_taEqualsValue != null && _taEqualsValue.IsChanged)
                {
                    EqualsValue = (EqualsValueClauseSyntax) _taEqualsValue.Node;
                    _equalsValueStr = _equalsValue?.ToFullString();
                }
                if (_equalsValueStr != value)
                {
                    _equalsValueStr = value;
                    IsChanged = true;
                    _equalsValueIsChanged = true;
                    _taEqualsValue = null;
                }
            }
        }

        public TameEqualsValueClauseSyntax TaEqualsValue
        {
            get
            {
                if (_taEqualsValue == null && EqualsValue != null)
                {
                    _taEqualsValue = new TameEqualsValueClauseSyntax(EqualsValue) {TaParent = this};
                    _taEqualsValue.AddChildren();
                }
                return _taEqualsValue;
            }
            set
            {
                if (_taEqualsValue != value)
                {
                    _taEqualsValue = value;
                    if (_taEqualsValue != null)
                    {
                        _taEqualsValue.TaParent = this;
                        _taEqualsValue.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken Identifier
        {
            get
            {
                if (_identifierIsChanged)
                {
                    _identifier = SyntaxFactoryStr.ParseSyntaxToken(IdentifierStr);
                    _identifierIsChanged = false;
                }
                return _identifier;
            }
            set
            {
                if (_identifier != value)
                {
                    _identifier = value;
                    _identifierIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IdentifierStr
        {
            get
            {
                if (_identifierIsChanged) return _identifierStr;
                return _identifierStr = _identifier.Text;
            }
            set
            {
                if (_identifierStr != value)
                {
                    _identifierStr = value;
                    IsChanged = true;
                    _identifierIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taAttributeLists = null;
            _taEqualsValue = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _attributeLists = ((EnumMemberDeclarationSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _identifier = ((EnumMemberDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _equalsValue = ((EnumMemberDeclarationSyntax) Node).EqualsValue;
            _equalsValueIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.EnumMemberDeclaration(AttributeLists, Identifier, EqualsValue);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaEqualsValue != null) yield return TaEqualsValue;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("EqualsValueStr", EqualsValueStr);
        }

        public TameEnumMemberDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}