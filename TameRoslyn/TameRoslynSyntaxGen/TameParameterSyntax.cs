// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameParameterSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "ParameterSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private EqualsValueClauseSyntax _default;
        private bool _defaultIsChanged;
        private string _defaultStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private TameEqualsValueClauseSyntax _taDefault;
        private TameSyntaxTokenList _taModifiers;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameParameterSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseParameter(code);
            AddChildren();
        }

        public TameParameterSyntax(ParameterSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameParameterSyntax()
        {
            AttributeListsStr = DefaultValues.ParameterSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.ParameterSyntaxModifiersStr;
            TypeStr = DefaultValues.ParameterSyntaxTypeStr;
            IdentifierStr = DefaultValues.ParameterSyntaxIdentifierStr;
            DefaultStr = DefaultValues.ParameterSyntaxDefaultStr;
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

        public EqualsValueClauseSyntax Default
        {
            get
            {
                if (_defaultIsChanged)
                {
                    _default = SyntaxFactoryStr.ParseEqualsValueClauseSyntax(DefaultStr);
                    _defaultIsChanged = false;
                    _taDefault = null;
                }
                else if (_taDefault != null && _taDefault.IsChanged)
                {
                    _default = (EqualsValueClauseSyntax) _taDefault.Node;
                }
                return _default;
            }
            set
            {
                if (_default != value)
                {
                    _default = value;
                    _defaultIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DefaultStr
        {
            get
            {
                if (_taDefault != null && _taDefault.IsChanged)
                    Default = (EqualsValueClauseSyntax) _taDefault.Node;
                if (_defaultIsChanged) return _defaultStr;
                return _defaultStr = _default?.ToFullString();
            }
            set
            {
                if (_taDefault != null && _taDefault.IsChanged)
                {
                    Default = (EqualsValueClauseSyntax) _taDefault.Node;
                    _defaultStr = _default?.ToFullString();
                }
                if (_defaultStr != value)
                {
                    _defaultStr = value;
                    IsChanged = true;
                    _defaultIsChanged = true;
                    _taDefault = null;
                }
            }
        }

        public TameEqualsValueClauseSyntax TaDefault
        {
            get
            {
                if (_taDefault == null && Default != null)
                {
                    _taDefault = new TameEqualsValueClauseSyntax(Default) {TaParent = this};
                    _taDefault.AddChildren();
                }
                return _taDefault;
            }
            set
            {
                if (_taDefault != value)
                {
                    _taDefault = value;
                    if (_taDefault != null)
                    {
                        _taDefault.TaParent = this;
                        _taDefault.IsChanged = true;
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
            _taAttributeLists = null;
            _taModifiers = null;
            _taType = null;
            _taDefault = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _attributeLists = ((ParameterSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _modifiers = ((ParameterSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _type = ((ParameterSyntax) Node).Type;
            _typeIsChanged = false;
            _identifier = ((ParameterSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _default = ((ParameterSyntax) Node).Default;
            _defaultIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.Parameter(AttributeLists, Modifiers, Type, Identifier, Default);
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
            if (TaType != null) yield return TaType;
            if (TaDefault != null) yield return TaDefault;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("TypeStr", TypeStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("DefaultStr", DefaultStr);
        }

        public TameParameterSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}