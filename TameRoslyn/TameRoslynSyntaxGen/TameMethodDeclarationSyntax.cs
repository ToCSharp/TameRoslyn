// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameMethodDeclarationSyntax : TameBaseMethodDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "MethodDeclarationSyntax";
        private int _arity;
        private bool _arityIsChanged;
        private SyntaxList<TypeParameterConstraintClauseSyntax> _constraintClauses;
        private int _constraintClausesCount;
        private bool _constraintClausesIsChanged;
        private string _constraintClausesStr;
        private ExplicitInterfaceSpecifierSyntax _explicitInterfaceSpecifier;
        private bool _explicitInterfaceSpecifierIsChanged;
        private string _explicitInterfaceSpecifierStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private TypeSyntax _returnType;
        private bool _returnTypeIsChanged;
        private string _returnTypeStr;
        private List<TameTypeParameterConstraintClauseSyntax> _taConstraintClauses;
        private TameExplicitInterfaceSpecifierSyntax _taExplicitInterfaceSpecifier;
        private TameTypeSyntax _taReturnType;
        private TameTypeParameterListSyntax _taTypeParameterList;
        private TypeParameterListSyntax _typeParameterList;
        private bool _typeParameterListIsChanged;
        private string _typeParameterListStr;

        public TameMethodDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseMethodDeclaration(code);
            AddChildren();
        }

        public TameMethodDeclarationSyntax(MethodDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameMethodDeclarationSyntax()
        {
            Arity = DefaultValues.MethodDeclarationSyntaxArity;
            ReturnTypeStr = DefaultValues.MethodDeclarationSyntaxReturnTypeStr;
            ExplicitInterfaceSpecifierStr = DefaultValues.MethodDeclarationSyntaxExplicitInterfaceSpecifierStr;
            IdentifierStr = DefaultValues.MethodDeclarationSyntaxIdentifierStr;
            TypeParameterListStr = DefaultValues.MethodDeclarationSyntaxTypeParameterListStr;
            ConstraintClausesStr = DefaultValues.MethodDeclarationSyntaxConstraintClausesStr;
            AttributeListsStr = DefaultValues.MethodDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.MethodDeclarationSyntaxModifiersStr;
            ParameterListStr = DefaultValues.MethodDeclarationSyntaxParameterListStr;
            BodyStr = DefaultValues.MethodDeclarationSyntaxBodyStr;
            ExpressionBodyStr = DefaultValues.MethodDeclarationSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.MethodDeclarationSyntaxSemicolonTokenStr;
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
            _taReturnType = null;
            _taExplicitInterfaceSpecifier = null;
            _taTypeParameterList = null;
            _taConstraintClauses = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _arity = ((MethodDeclarationSyntax) Node).Arity;
            _arityIsChanged = false;
            _returnType = ((MethodDeclarationSyntax) Node).ReturnType;
            _returnTypeIsChanged = false;
            _explicitInterfaceSpecifier = ((MethodDeclarationSyntax) Node).ExplicitInterfaceSpecifier;
            _explicitInterfaceSpecifierIsChanged = false;
            _identifier = ((MethodDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _typeParameterList = ((MethodDeclarationSyntax) Node).TypeParameterList;
            _typeParameterListIsChanged = false;
            _constraintClauses = ((MethodDeclarationSyntax) Node).ConstraintClauses;
            _constraintClausesIsChanged = false;
            _constraintClausesCount = _constraintClauses.Count;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaConstraintClauses)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.MethodDeclaration(AttributeLists, Modifiers, ReturnType, ExplicitInterfaceSpecifier,
                Identifier, TypeParameterList, ParameterList, ConstraintClauses, Body, ExpressionBody, SemicolonToken);
// if (Arity != null) res = res.WithArity(Arity);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaConstraintClauses)
                yield return item;
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaReturnType != null) yield return TaReturnType;
            if (TaExplicitInterfaceSpecifier != null) yield return TaExplicitInterfaceSpecifier;
            if (TaTypeParameterList != null) yield return TaTypeParameterList;
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
            if (TaExpressionBody != null) yield return TaExpressionBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("Arity", Arity.ToString());
            yield return ("ReturnTypeStr", ReturnTypeStr);
            yield return ("ExplicitInterfaceSpecifierStr", ExplicitInterfaceSpecifierStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("TypeParameterListStr", TypeParameterListStr);
            yield return ("ConstraintClausesStr", ConstraintClausesStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("BodyStr", BodyStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameMethodDeclarationSyntax AddConstraintClause(TameTypeParameterConstraintClauseSyntax item)
        {
            item.TaParent = this;
            TaConstraintClauses.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameMethodDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}