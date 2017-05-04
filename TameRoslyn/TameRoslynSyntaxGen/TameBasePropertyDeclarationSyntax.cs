// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameBasePropertyDeclarationSyntax : TameMemberDeclarationSyntax
    {
        public new static string TypeName = "BasePropertyDeclarationSyntax";
        private AccessorListSyntax _accessorList;
        private bool _accessorListIsChanged;
        private string _accessorListStr;
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private ExplicitInterfaceSpecifierSyntax _explicitInterfaceSpecifier;
        private bool _explicitInterfaceSpecifierIsChanged;
        private string _explicitInterfaceSpecifierStr;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private TameAccessorListSyntax _taAccessorList;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private TameExplicitInterfaceSpecifierSyntax _taExplicitInterfaceSpecifier;
        private TameSyntaxTokenList _taModifiers;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameBasePropertyDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBasePropertyDeclaration(code);
            AddChildren();
        }

        public TameBasePropertyDeclarationSyntax(BasePropertyDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBasePropertyDeclarationSyntax()
        {
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

        public SyntaxTokenList Modifiers
        {
            get
            {
                if (_modifiersIsChanged)
                {
                    _modifiers = SyntaxFactoryStr.ParseSyntaxTokenList(ModifiersStr);
                    _modifiersIsChanged = false;
                    _taModifiers = null;
                }
                else if (_taModifiers != null && _taModifiers.IsChanged)
                {
                    _modifiers = _taModifiers.Node;
                }
                return _modifiers;
            }
            set
            {
                if (_modifiers != value)
                {
                    _modifiers = value;
                    _modifiersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ModifiersStr
        {
            get
            {
                if (_taModifiers != null && _taModifiers.IsChanged)
                    Modifiers = _taModifiers.Node;
                if (_modifiersIsChanged) return _modifiersStr;
                return _modifiersStr = _modifiers.ToFullString();
            }
            set
            {
                if (_taModifiers != null && _taModifiers.IsChanged)
                {
                    Modifiers = _taModifiers.Node;
                    _modifiersStr = _modifiers.ToFullString();
                }
                if (_modifiersStr != value)
                {
                    _modifiersStr = value;
                    IsChanged = true;
                    _modifiersIsChanged = true;
                    _taModifiers = null;
                }
            }
        }

        public TameSyntaxTokenList TaModifiers
        {
            get
            {
                if (_taModifiers == null)
                {
                    _taModifiers = new TameSyntaxTokenList(Modifiers) {TaParent = this};
                    _taModifiers.AddChildren();
                }
                return _taModifiers;
            }
            set
            {
                if (_taModifiers != value)
                {
                    _taModifiers = value;
                    if (_taModifiers != null)
                    {
                        _taModifiers.TaParent = this;
                        _taModifiers.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public TypeSyntax Type
        {
            get
            {
                if (_typeIsChanged)
                {
                    _type = SyntaxFactoryStr.ParseTypeSyntax(TypeStr);
                    _typeIsChanged = false;
                    _taType = null;
                }
                else if (_taType != null && _taType.IsChanged)
                {
                    _type = (TypeSyntax) _taType.Node;
                }
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    _typeIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeStr
        {
            get
            {
                if (_taType != null && _taType.IsChanged)
                    Type = (TypeSyntax) _taType.Node;
                if (_typeIsChanged) return _typeStr;
                return _typeStr = _type?.ToFullString();
            }
            set
            {
                if (_taType != null && _taType.IsChanged)
                {
                    Type = (TypeSyntax) _taType.Node;
                    _typeStr = _type?.ToFullString();
                }
                if (_typeStr != value)
                {
                    _typeStr = value;
                    IsChanged = true;
                    _typeIsChanged = true;
                    _taType = null;
                }
            }
        }

        public TameTypeSyntax TaType
        {
            get
            {
                if (_taType == null && Type != null)
                    if (Type is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is OmittedTypeArgumentSyntax)
                    {
                        var loc = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                return _taType;
            }
            set
            {
                if (_taType != value)
                {
                    _taType = value;
                    if (_taType != null)
                    {
                        _taType.TaParent = this;
                        _taType.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public ExplicitInterfaceSpecifierSyntax ExplicitInterfaceSpecifier
        {
            get
            {
                if (_explicitInterfaceSpecifierIsChanged)
                {
                    _explicitInterfaceSpecifier =
                        SyntaxFactoryStr.ParseExplicitInterfaceSpecifierSyntax(ExplicitInterfaceSpecifierStr);
                    _explicitInterfaceSpecifierIsChanged = false;
                    _taExplicitInterfaceSpecifier = null;
                }
                else if (_taExplicitInterfaceSpecifier != null && _taExplicitInterfaceSpecifier.IsChanged)
                {
                    _explicitInterfaceSpecifier = (ExplicitInterfaceSpecifierSyntax) _taExplicitInterfaceSpecifier.Node;
                }
                return _explicitInterfaceSpecifier;
            }
            set
            {
                if (_explicitInterfaceSpecifier != value)
                {
                    _explicitInterfaceSpecifier = value;
                    _explicitInterfaceSpecifierIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExplicitInterfaceSpecifierStr
        {
            get
            {
                if (_taExplicitInterfaceSpecifier != null && _taExplicitInterfaceSpecifier.IsChanged)
                    ExplicitInterfaceSpecifier = (ExplicitInterfaceSpecifierSyntax) _taExplicitInterfaceSpecifier.Node;
                if (_explicitInterfaceSpecifierIsChanged) return _explicitInterfaceSpecifierStr;
                return _explicitInterfaceSpecifierStr = _explicitInterfaceSpecifier?.ToFullString();
            }
            set
            {
                if (_taExplicitInterfaceSpecifier != null && _taExplicitInterfaceSpecifier.IsChanged)
                {
                    ExplicitInterfaceSpecifier = (ExplicitInterfaceSpecifierSyntax) _taExplicitInterfaceSpecifier.Node;
                    _explicitInterfaceSpecifierStr = _explicitInterfaceSpecifier?.ToFullString();
                }
                if (_explicitInterfaceSpecifierStr != value)
                {
                    _explicitInterfaceSpecifierStr = value;
                    IsChanged = true;
                    _explicitInterfaceSpecifierIsChanged = true;
                    _taExplicitInterfaceSpecifier = null;
                }
            }
        }

        public TameExplicitInterfaceSpecifierSyntax TaExplicitInterfaceSpecifier
        {
            get
            {
                if (_taExplicitInterfaceSpecifier == null && ExplicitInterfaceSpecifier != null)
                {
                    _taExplicitInterfaceSpecifier =
                        new TameExplicitInterfaceSpecifierSyntax(ExplicitInterfaceSpecifier) {TaParent = this};
                    _taExplicitInterfaceSpecifier.AddChildren();
                }
                return _taExplicitInterfaceSpecifier;
            }
            set
            {
                if (_taExplicitInterfaceSpecifier != value)
                {
                    _taExplicitInterfaceSpecifier = value;
                    if (_taExplicitInterfaceSpecifier != null)
                    {
                        _taExplicitInterfaceSpecifier.TaParent = this;
                        _taExplicitInterfaceSpecifier.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public AccessorListSyntax AccessorList
        {
            get
            {
                if (_accessorListIsChanged)
                {
                    _accessorList = SyntaxFactoryStr.ParseAccessorListSyntax(AccessorListStr);
                    _accessorListIsChanged = false;
                    _taAccessorList = null;
                }
                else if (_taAccessorList != null && _taAccessorList.IsChanged)
                {
                    _accessorList = (AccessorListSyntax) _taAccessorList.Node;
                }
                return _accessorList;
            }
            set
            {
                if (_accessorList != value)
                {
                    _accessorList = value;
                    _accessorListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AccessorListStr
        {
            get
            {
                if (_taAccessorList != null && _taAccessorList.IsChanged)
                    AccessorList = (AccessorListSyntax) _taAccessorList.Node;
                if (_accessorListIsChanged) return _accessorListStr;
                return _accessorListStr = _accessorList?.ToFullString();
            }
            set
            {
                if (_taAccessorList != null && _taAccessorList.IsChanged)
                {
                    AccessorList = (AccessorListSyntax) _taAccessorList.Node;
                    _accessorListStr = _accessorList?.ToFullString();
                }
                if (_accessorListStr != value)
                {
                    _accessorListStr = value;
                    IsChanged = true;
                    _accessorListIsChanged = true;
                    _taAccessorList = null;
                }
            }
        }

        public TameAccessorListSyntax TaAccessorList
        {
            get
            {
                if (_taAccessorList == null && AccessorList != null)
                {
                    _taAccessorList = new TameAccessorListSyntax(AccessorList) {TaParent = this};
                    _taAccessorList.AddChildren();
                }
                return _taAccessorList;
            }
            set
            {
                if (_taAccessorList != value)
                {
                    _taAccessorList = value;
                    if (_taAccessorList != null)
                    {
                        _taAccessorList.TaParent = this;
                        _taAccessorList.IsChanged = true;
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
            _taAttributeLists = null;
            _taModifiers = null;
            _taType = null;
            _taExplicitInterfaceSpecifier = null;
            _taAccessorList = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _attributeLists = ((BasePropertyDeclarationSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _modifiers = ((BasePropertyDeclarationSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _type = ((BasePropertyDeclarationSyntax) Node).Type;
            _typeIsChanged = false;
            _explicitInterfaceSpecifier = ((BasePropertyDeclarationSyntax) Node).ExplicitInterfaceSpecifier;
            _explicitInterfaceSpecifierIsChanged = false;
            _accessorList = ((BasePropertyDeclarationSyntax) Node).AccessorList;
            _accessorListIsChanged = false;
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
            throw new NotImplementedException();
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
            if (TaExplicitInterfaceSpecifier != null) yield return TaExplicitInterfaceSpecifier;
            if (TaAccessorList != null) yield return TaAccessorList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("TypeStr", TypeStr);
            yield return ("ExplicitInterfaceSpecifierStr", ExplicitInterfaceSpecifierStr);
            yield return ("AccessorListStr", AccessorListStr);
        }
    }
}