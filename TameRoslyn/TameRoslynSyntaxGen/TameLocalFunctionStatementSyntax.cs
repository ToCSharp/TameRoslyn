// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameLocalFunctionStatementSyntax : TameStatementSyntax, IHaveIdentifier
    {
        public new static string TypeName = "LocalFunctionStatementSyntax";
        private BlockSyntax _body;
        private bool _bodyIsChanged;
        private string _bodyStr;
        private SyntaxList<TypeParameterConstraintClauseSyntax> _constraintClauses;
        private int _constraintClausesCount;
        private bool _constraintClausesIsChanged;
        private string _constraintClausesStr;
        private ArrowExpressionClauseSyntax _expressionBody;
        private bool _expressionBodyIsChanged;
        private string _expressionBodyStr;
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
        private TameBlockSyntax _taBody;
        private List<TameTypeParameterConstraintClauseSyntax> _taConstraintClauses;
        private TameArrowExpressionClauseSyntax _taExpressionBody;
        private TameSyntaxTokenList _taModifiers;
        private TameParameterListSyntax _taParameterList;
        private TameTypeSyntax _taReturnType;
        private TameTypeParameterListSyntax _taTypeParameterList;
        private TypeParameterListSyntax _typeParameterList;
        private bool _typeParameterListIsChanged;
        private string _typeParameterListStr;

        public TameLocalFunctionStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseLocalFunctionStatement(code);
            AddChildren();
        }

        public TameLocalFunctionStatementSyntax(LocalFunctionStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameLocalFunctionStatementSyntax()
        {
            ModifiersStr = DefaultValues.LocalFunctionStatementSyntaxModifiersStr;
            ReturnTypeStr = DefaultValues.LocalFunctionStatementSyntaxReturnTypeStr;
            IdentifierStr = DefaultValues.LocalFunctionStatementSyntaxIdentifierStr;
            TypeParameterListStr = DefaultValues.LocalFunctionStatementSyntaxTypeParameterListStr;
            ParameterListStr = DefaultValues.LocalFunctionStatementSyntaxParameterListStr;
            ConstraintClausesStr = DefaultValues.LocalFunctionStatementSyntaxConstraintClausesStr;
            BodyStr = DefaultValues.LocalFunctionStatementSyntaxBodyStr;
            ExpressionBodyStr = DefaultValues.LocalFunctionStatementSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.LocalFunctionStatementSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public BlockSyntax Body
        {
            get
            {
                if (_bodyIsChanged)
                {
                    _body = SyntaxFactoryStr.ParseBlockSyntax(BodyStr);
                    _bodyIsChanged = false;
                    _taBody = null;
                }
                else if (_taBody != null && _taBody.IsChanged)
                {
                    _body = (BlockSyntax) _taBody.Node;
                }
                return _body;
            }
            set
            {
                if (_body != value)
                {
                    _body = value;
                    _bodyIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string BodyStr
        {
            get
            {
                if (_taBody != null && _taBody.IsChanged)
                    Body = (BlockSyntax) _taBody.Node;
                if (_bodyIsChanged) return _bodyStr;
                return _bodyStr = _body?.ToFullString();
            }
            set
            {
                if (_taBody != null && _taBody.IsChanged)
                {
                    Body = (BlockSyntax) _taBody.Node;
                    _bodyStr = _body?.ToFullString();
                }
                if (_bodyStr != value)
                {
                    _bodyStr = value;
                    IsChanged = true;
                    _bodyIsChanged = true;
                    _taBody = null;
                }
            }
        }

        public TameBlockSyntax TaBody
        {
            get
            {
                if (_taBody == null && Body != null)
                {
                    _taBody = new TameBlockSyntax(Body) {TaParent = this};
                    _taBody.AddChildren();
                }
                return _taBody;
            }
            set
            {
                if (_taBody != value)
                {
                    _taBody = value;
                    if (_taBody != null)
                    {
                        _taBody.TaParent = this;
                        _taBody.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public ArrowExpressionClauseSyntax ExpressionBody
        {
            get
            {
                if (_expressionBodyIsChanged)
                {
                    _expressionBody = SyntaxFactoryStr.ParseArrowExpressionClauseSyntax(ExpressionBodyStr);
                    _expressionBodyIsChanged = false;
                    _taExpressionBody = null;
                }
                else if (_taExpressionBody != null && _taExpressionBody.IsChanged)
                {
                    _expressionBody = (ArrowExpressionClauseSyntax) _taExpressionBody.Node;
                }
                return _expressionBody;
            }
            set
            {
                if (_expressionBody != value)
                {
                    _expressionBody = value;
                    _expressionBodyIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExpressionBodyStr
        {
            get
            {
                if (_taExpressionBody != null && _taExpressionBody.IsChanged)
                    ExpressionBody = (ArrowExpressionClauseSyntax) _taExpressionBody.Node;
                if (_expressionBodyIsChanged) return _expressionBodyStr;
                return _expressionBodyStr = _expressionBody?.ToFullString();
            }
            set
            {
                if (_taExpressionBody != null && _taExpressionBody.IsChanged)
                {
                    ExpressionBody = (ArrowExpressionClauseSyntax) _taExpressionBody.Node;
                    _expressionBodyStr = _expressionBody?.ToFullString();
                }
                if (_expressionBodyStr != value)
                {
                    _expressionBodyStr = value;
                    IsChanged = true;
                    _expressionBodyIsChanged = true;
                    _taExpressionBody = null;
                }
            }
        }

        public TameArrowExpressionClauseSyntax TaExpressionBody
        {
            get
            {
                if (_taExpressionBody == null && ExpressionBody != null)
                {
                    _taExpressionBody = new TameArrowExpressionClauseSyntax(ExpressionBody) {TaParent = this};
                    _taExpressionBody.AddChildren();
                }
                return _taExpressionBody;
            }
            set
            {
                if (_taExpressionBody != value)
                {
                    _taExpressionBody = value;
                    if (_taExpressionBody != null)
                    {
                        _taExpressionBody.TaParent = this;
                        _taExpressionBody.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
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
            _taModifiers = null;
            _taReturnType = null;
            _taTypeParameterList = null;
            _taParameterList = null;
            _taConstraintClauses = null;
            _taBody = null;
            _taExpressionBody = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _modifiers = ((LocalFunctionStatementSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _returnType = ((LocalFunctionStatementSyntax) Node).ReturnType;
            _returnTypeIsChanged = false;
            _identifier = ((LocalFunctionStatementSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _typeParameterList = ((LocalFunctionStatementSyntax) Node).TypeParameterList;
            _typeParameterListIsChanged = false;
            _parameterList = ((LocalFunctionStatementSyntax) Node).ParameterList;
            _parameterListIsChanged = false;
            _constraintClauses = ((LocalFunctionStatementSyntax) Node).ConstraintClauses;
            _constraintClausesIsChanged = false;
            _constraintClausesCount = _constraintClauses.Count;
            _body = ((LocalFunctionStatementSyntax) Node).Body;
            _bodyIsChanged = false;
            _expressionBody = ((LocalFunctionStatementSyntax) Node).ExpressionBody;
            _expressionBodyIsChanged = false;
            _semicolonToken = ((LocalFunctionStatementSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
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
            var res = SyntaxFactory.LocalFunctionStatement(Modifiers, ReturnType, Identifier, TypeParameterList,
                ParameterList, ConstraintClauses, Body, ExpressionBody, SemicolonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaConstraintClauses)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaReturnType != null) yield return TaReturnType;
            if (TaTypeParameterList != null) yield return TaTypeParameterList;
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
            if (TaExpressionBody != null) yield return TaExpressionBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("ReturnTypeStr", ReturnTypeStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("TypeParameterListStr", TypeParameterListStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("ConstraintClausesStr", ConstraintClausesStr);
            yield return ("BodyStr", BodyStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameLocalFunctionStatementSyntax AddConstraintClause(TameTypeParameterConstraintClauseSyntax item)
        {
            item.TaParent = this;
            TaConstraintClauses.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}