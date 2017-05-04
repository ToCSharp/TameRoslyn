// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameOperatorDeclarationSyntax : TameBaseMethodDeclarationSyntax
    {
        public new static string TypeName = "OperatorDeclarationSyntax";
        private SyntaxToken _operatorKeyword;
        private bool _operatorKeywordIsChanged;
        private string _operatorKeywordStr;
        private SyntaxToken _operatorToken;
        private bool _operatorTokenIsChanged;
        private string _operatorTokenStr;
        private TypeSyntax _returnType;
        private bool _returnTypeIsChanged;
        private string _returnTypeStr;
        private TameTypeSyntax _taReturnType;

        public TameOperatorDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseOperatorDeclaration(code);
            AddChildren();
        }

        public TameOperatorDeclarationSyntax(OperatorDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameOperatorDeclarationSyntax()
        {
            ReturnTypeStr = DefaultValues.OperatorDeclarationSyntaxReturnTypeStr;
            OperatorKeywordStr = DefaultValues.OperatorDeclarationSyntaxOperatorKeywordStr;
            OperatorTokenStr = DefaultValues.OperatorDeclarationSyntaxOperatorTokenStr;
            AttributeListsStr = DefaultValues.OperatorDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.OperatorDeclarationSyntaxModifiersStr;
            ParameterListStr = DefaultValues.OperatorDeclarationSyntaxParameterListStr;
            BodyStr = DefaultValues.OperatorDeclarationSyntaxBodyStr;
            ExpressionBodyStr = DefaultValues.OperatorDeclarationSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.OperatorDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public SyntaxToken OperatorKeyword
        {
            get
            {
                if (_operatorKeywordIsChanged)
                {
                    if (_operatorKeywordStr == null) _operatorKeyword = default(SyntaxToken);
                    else
                        _operatorKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_operatorKeywordStr, SyntaxKind.OperatorKeyword);
                    _operatorKeywordIsChanged = false;
                }
                return _operatorKeyword;
            }
            set
            {
                if (_operatorKeyword != value)
                {
                    _operatorKeyword = value;
                    _operatorKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperatorKeywordStr
        {
            get
            {
                if (_operatorKeywordIsChanged) return _operatorKeywordStr;
                return _operatorKeywordStr = _operatorKeyword.Text;
            }
            set
            {
                if (_operatorKeywordStr != value)
                {
                    _operatorKeywordStr = value;
                    IsChanged = true;
                    _operatorKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken OperatorToken
        {
            get
            {
                if (_operatorTokenIsChanged)
                {
                    _operatorToken = SyntaxFactoryStr.ParseSyntaxToken(OperatorTokenStr);
                    _operatorTokenIsChanged = false;
                }
                return _operatorToken;
            }
            set
            {
                if (_operatorToken != value)
                {
                    _operatorToken = value;
                    _operatorTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperatorTokenStr
        {
            get
            {
                if (_operatorTokenIsChanged) return _operatorTokenStr;
                return _operatorTokenStr = _operatorToken.Text;
            }
            set
            {
                if (_operatorTokenStr != value)
                {
                    _operatorTokenStr = value;
                    IsChanged = true;
                    _operatorTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taReturnType = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _returnType = ((OperatorDeclarationSyntax) Node).ReturnType;
            _returnTypeIsChanged = false;
            _operatorKeyword = ((OperatorDeclarationSyntax) Node).OperatorKeyword;
            _operatorKeywordIsChanged = false;
            _operatorToken = ((OperatorDeclarationSyntax) Node).OperatorToken;
            _operatorTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.OperatorDeclaration(AttributeLists, Modifiers, ReturnType, OperatorKeyword,
                OperatorToken, ParameterList, Body, ExpressionBody, SemicolonToken);
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
            if (TaReturnType != null) yield return TaReturnType;
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
            if (TaExpressionBody != null) yield return TaExpressionBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ReturnTypeStr", ReturnTypeStr);
            yield return ("OperatorKeywordStr", OperatorKeywordStr);
            yield return ("OperatorTokenStr", OperatorTokenStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("BodyStr", BodyStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameOperatorDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}