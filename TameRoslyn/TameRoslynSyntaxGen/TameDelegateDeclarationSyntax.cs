// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDelegateDeclarationSyntax : TameMemberDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "DelegateDeclarationSyntax";
        private int _arity;
        private bool _arityIsChanged;
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private SyntaxList<TypeParameterConstraintClauseSyntax> _constraintClauses;
        private int _constraintClausesCount;
        private bool _constraintClausesIsChanged;
        private string _constraintClausesStr;
        private SyntaxToken _delegateKeyword;
        private bool _delegateKeywordIsChanged;
        private string _delegateKeywordStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private ParameterListSyntax _parameterList;
        private bool _parameterListIsChanged;
        private string _parameterListStr;
        private TypeSyntax _returnType;
        private bool _returnTypeIsChanged;
        private string _returnTypeStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private List<TameTypeParameterConstraintClauseSyntax> _taConstraintClauses;
        private TameSyntaxTokenList _taModifiers;
        private TameParameterListSyntax _taParameterList;
        private TameTypeSyntax _taReturnType;
        private TameTypeParameterListSyntax _taTypeParameterList;
        private TypeParameterListSyntax _typeParameterList;
        private bool _typeParameterListIsChanged;
        private string _typeParameterListStr;

        public TameDelegateDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDelegateDeclaration(code);
            AddChildren();
        }

        public TameDelegateDeclarationSyntax(DelegateDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDelegateDeclarationSyntax()
        {
            Arity = DefaultValues.DelegateDeclarationSyntaxArity;
            AttributeListsStr = DefaultValues.DelegateDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.DelegateDeclarationSyntaxModifiersStr;
            DelegateKeywordStr = DefaultValues.DelegateDeclarationSyntaxDelegateKeywordStr;
            ReturnTypeStr = DefaultValues.DelegateDeclarationSyntaxReturnTypeStr;
            IdentifierStr = DefaultValues.DelegateDeclarationSyntaxIdentifierStr;
            TypeParameterListStr = DefaultValues.DelegateDeclarationSyntaxTypeParameterListStr;
            ParameterListStr = DefaultValues.DelegateDeclarationSyntaxParameterListStr;
            ConstraintClausesStr = DefaultValues.DelegateDeclarationSyntaxConstraintClausesStr;
            SemicolonTokenStr = DefaultValues.DelegateDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public int Arity
        {
            get { return _arity; }
            set
            {
                if (_arity != value)
                {
                    _arity = value;
                    _arityIsChanged = false;
                    IsChanged = true;
                }
            }
        }

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

        public SyntaxToken DelegateKeyword
        {
            get
            {
                if (_delegateKeywordIsChanged)
                {
                    if (_delegateKeywordStr == null) _delegateKeyword = default(SyntaxToken);
                    else
                        _delegateKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_delegateKeywordStr, SyntaxKind.DelegateKeyword);
                    _delegateKeywordIsChanged = false;
                }
                return _delegateKeyword;
            }
            set
            {
                if (_delegateKeyword != value)
                {
                    _delegateKeyword = value;
                    _delegateKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DelegateKeywordStr
        {
            get
            {
                if (_delegateKeywordIsChanged) return _delegateKeywordStr;
                return _delegateKeywordStr = _delegateKeyword.Text;
            }
            set
            {
                if (_delegateKeywordStr != value)
                {
                    _delegateKeywordStr = value;
                    IsChanged = true;
                    _delegateKeywordIsChanged = true;
                }
            }
        }

        public TypeSyntax ReturnType
        {
            get
            {
                if (_returnTypeIsChanged)
                {
                    _returnType = SyntaxFactoryStr.ParseTypeSyntax(ReturnTypeStr);
                    _returnTypeIsChanged = false;
                    _taReturnType = null;
                }
                else if (_taReturnType != null && _taReturnType.IsChanged)
                {
                    _returnType = (TypeSyntax) _taReturnType.Node;
                }
                return _returnType;
            }
            set
            {
                if (_returnType != value)
                {
                    _returnType = value;
                    _returnTypeIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ReturnTypeStr
        {
            get
            {
                if (_taReturnType != null && _taReturnType.IsChanged)
                    ReturnType = (TypeSyntax) _taReturnType.Node;
                if (_returnTypeIsChanged) return _returnTypeStr;
                return _returnTypeStr = _returnType?.ToFullString();
            }
            set
            {
                if (_taReturnType != null && _taReturnType.IsChanged)
                {
                    ReturnType = (TypeSyntax) _taReturnType.Node;
                    _returnTypeStr = _returnType?.ToFullString();
                }
                if (_returnTypeStr != value)
                {
                    _returnTypeStr = value;
                    IsChanged = true;
                    _returnTypeIsChanged = true;
                    _taReturnType = null;
                }
            }
        }

        public TameTypeSyntax TaReturnType
        {
            get
            {
                if (_taReturnType == null && ReturnType != null)
                    if (ReturnType is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                    else if (ReturnType is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) ReturnType) {TaParent = this};
                        loc.AddChildren();
                        _taReturnType = loc;
                    }
                return _taReturnType;
            }
            set
            {
                if (_taReturnType != value)
                {
                    _taReturnType = value;
                    if (_taReturnType != null)
                    {
                        _taReturnType.TaParent = this;
                        _taReturnType.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public TypeParameterListSyntax TypeParameterList
        {
            get
            {
                if (_typeParameterListIsChanged)
                {
                    _typeParameterList = SyntaxFactoryStr.ParseTypeParameterListSyntax(TypeParameterListStr);
                    _typeParameterListIsChanged = false;
                    _taTypeParameterList = null;
                }
                else if (_taTypeParameterList != null && _taTypeParameterList.IsChanged)
                {
                    _typeParameterList = (TypeParameterListSyntax) _taTypeParameterList.Node;
                }
                return _typeParameterList;
            }
            set
            {
                if (_typeParameterList != value)
                {
                    _typeParameterList = value;
                    _typeParameterListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeParameterListStr
        {
            get
            {
                if (_taTypeParameterList != null && _taTypeParameterList.IsChanged)
                    TypeParameterList = (TypeParameterListSyntax) _taTypeParameterList.Node;
                if (_typeParameterListIsChanged) return _typeParameterListStr;
                return _typeParameterListStr = _typeParameterList?.ToFullString();
            }
            set
            {
                if (_taTypeParameterList != null && _taTypeParameterList.IsChanged)
                {
                    TypeParameterList = (TypeParameterListSyntax) _taTypeParameterList.Node;
                    _typeParameterListStr = _typeParameterList?.ToFullString();
                }
                if (_typeParameterListStr != value)
                {
                    _typeParameterListStr = value;
                    IsChanged = true;
                    _typeParameterListIsChanged = true;
                    _taTypeParameterList = null;
                }
            }
        }

        public TameTypeParameterListSyntax TaTypeParameterList
        {
            get
            {
                if (_taTypeParameterList == null && TypeParameterList != null)
                {
                    _taTypeParameterList = new TameTypeParameterListSyntax(TypeParameterList) {TaParent = this};
                    _taTypeParameterList.AddChildren();
                }
                return _taTypeParameterList;
            }
            set
            {
                if (_taTypeParameterList != value)
                {
                    _taTypeParameterList = value;
                    if (_taTypeParameterList != null)
                    {
                        _taTypeParameterList.TaParent = this;
                        _taTypeParameterList.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public ParameterListSyntax ParameterList
        {
            get
            {
                if (_parameterListIsChanged)
                {
                    _parameterList = SyntaxFactoryStr.ParseParameterListSyntax(ParameterListStr);
                    _parameterListIsChanged = false;
                    _taParameterList = null;
                }
                else if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    _parameterList = (ParameterListSyntax) _taParameterList.Node;
                }
                return _parameterList;
            }
            set
            {
                if (_parameterList != value)
                {
                    _parameterList = value;
                    _parameterListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ParameterListStr
        {
            get
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                    ParameterList = (ParameterListSyntax) _taParameterList.Node;
                if (_parameterListIsChanged) return _parameterListStr;
                return _parameterListStr = _parameterList?.ToFullString();
            }
            set
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    ParameterList = (ParameterListSyntax) _taParameterList.Node;
                    _parameterListStr = _parameterList?.ToFullString();
                }
                if (_parameterListStr != value)
                {
                    _parameterListStr = value;
                    IsChanged = true;
                    _parameterListIsChanged = true;
                    _taParameterList = null;
                }
            }
        }

        public TameParameterListSyntax TaParameterList
        {
            get
            {
                if (_taParameterList == null && ParameterList != null)
                {
                    _taParameterList = new TameParameterListSyntax(ParameterList) {TaParent = this};
                    _taParameterList.AddChildren();
                }
                return _taParameterList;
            }
            set
            {
                if (_taParameterList != value)
                {
                    _taParameterList = value;
                    if (_taParameterList != null)
                    {
                        _taParameterList.TaParent = this;
                        _taParameterList.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public bool TaConstraintClausesIsChanged { get; set; }

        public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses
        {
            get
            {
                if (TaConstraintClausesIsChanged || _taConstraintClauses != null &&
                    (_taConstraintClauses.Count != _constraintClausesCount ||
                     _taConstraintClauses.Any(v => v.IsChanged)))
                {
                    _constraintClauses = SyntaxFactory.List(TaConstraintClauses?.Select(v => v.Node)
                        .Cast<TypeParameterConstraintClauseSyntax>());
                    TaConstraintClausesIsChanged = false;
                }
                return _constraintClauses;
            }
            set
            {
                if (_constraintClauses != value)
                {
                    _constraintClauses = value;
                    TaConstraintClausesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ConstraintClausesStr
        {
            get
            {
                if (_constraintClausesIsChanged) return _constraintClausesStr;
                return _constraintClausesStr = string.Join(", ", _constraintClauses.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _constraintClausesStr = value;
                    ConstraintClauses = new SyntaxList<TypeParameterConstraintClauseSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameTypeParameterConstraintClauseSyntax> TaConstraintClauses
        {
            get
            {
                if (_taConstraintClauses == null)
                {
                    _taConstraintClauses = new List<TameTypeParameterConstraintClauseSyntax>();
                    foreach (var item in _constraintClauses)
                        _taConstraintClauses.Add(new TameTypeParameterConstraintClauseSyntax(item) {TaParent = this});
                }
                return _taConstraintClauses;
            }
            set
            {
                if (_taConstraintClauses != value)
                {
                    _taConstraintClauses = value;
                    _taConstraintClauses?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaConstraintClausesIsChanged = true;
                }
            }
        }

        public SyntaxToken SemicolonToken
        {
            get
            {
                if (_semicolonTokenIsChanged)
                {
                    if (_semicolonTokenStr == null) _semicolonToken = default(SyntaxToken);
                    else
                        _semicolonToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_semicolonTokenStr, SyntaxKind.SemicolonToken);
                    _semicolonTokenIsChanged = false;
                }
                return _semicolonToken;
            }
            set
            {
                if (_semicolonToken != value)
                {
                    _semicolonToken = value;
                    _semicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonTokenStr
        {
            get
            {
                if (_semicolonTokenIsChanged) return _semicolonTokenStr;
                return _semicolonTokenStr = _semicolonToken.Text;
            }
            set
            {
                if (_semicolonTokenStr != value)
                {
                    _semicolonTokenStr = value;
                    IsChanged = true;
                    _semicolonTokenIsChanged = true;
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
            _taModifiers = null;
            _taReturnType = null;
            _taTypeParameterList = null;
            _taParameterList = null;
            _taConstraintClauses = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _arity = ((DelegateDeclarationSyntax) Node).Arity;
            _arityIsChanged = false;
            _attributeLists = ((DelegateDeclarationSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _modifiers = ((DelegateDeclarationSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _delegateKeyword = ((DelegateDeclarationSyntax) Node).DelegateKeyword;
            _delegateKeywordIsChanged = false;
            _returnType = ((DelegateDeclarationSyntax) Node).ReturnType;
            _returnTypeIsChanged = false;
            _identifier = ((DelegateDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _typeParameterList = ((DelegateDeclarationSyntax) Node).TypeParameterList;
            _typeParameterListIsChanged = false;
            _parameterList = ((DelegateDeclarationSyntax) Node).ParameterList;
            _parameterListIsChanged = false;
            _constraintClauses = ((DelegateDeclarationSyntax) Node).ConstraintClauses;
            _constraintClausesIsChanged = false;
            _constraintClausesCount = _constraintClauses.Count;
            _semicolonToken = ((DelegateDeclarationSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
            foreach (var item in TaConstraintClauses)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.DelegateDeclaration(AttributeLists, Modifiers, DelegateKeyword, ReturnType,
                Identifier, TypeParameterList, ParameterList, ConstraintClauses, SemicolonToken);
// if (Arity != null) res = res.WithArity(Arity);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
            foreach (var item in TaConstraintClauses)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaReturnType != null) yield return TaReturnType;
            if (TaTypeParameterList != null) yield return TaTypeParameterList;
            if (TaParameterList != null) yield return TaParameterList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("Arity", Arity.ToString());
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("DelegateKeywordStr", DelegateKeywordStr);
            yield return ("ReturnTypeStr", ReturnTypeStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("TypeParameterListStr", TypeParameterListStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("ConstraintClausesStr", ConstraintClausesStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameDelegateDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameDelegateDeclarationSyntax AddConstraintClause(TameTypeParameterConstraintClauseSyntax item)
        {
            item.TaParent = this;
            TaConstraintClauses.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}