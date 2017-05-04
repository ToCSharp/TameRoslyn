// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TamePropertyDeclarationSyntax : TameBasePropertyDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "PropertyDeclarationSyntax";
        private ArrowExpressionClauseSyntax _expressionBody;
        private bool _expressionBodyIsChanged;
        private string _expressionBodyStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private EqualsValueClauseSyntax _initializer;
        private bool _initializerIsChanged;
        private string _initializerStr;
        private SyntaxToken _semicolon;
        private bool _semicolonIsChanged;
        private string _semicolonStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private TameArrowExpressionClauseSyntax _taExpressionBody;
        private TameEqualsValueClauseSyntax _taInitializer;

        public TamePropertyDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParsePropertyDeclaration(code);
            AddChildren();
        }

        public TamePropertyDeclarationSyntax(PropertyDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TamePropertyDeclarationSyntax()
        {
            SemicolonStr = DefaultValues.PropertyDeclarationSyntaxSemicolonStr;
            IdentifierStr = DefaultValues.PropertyDeclarationSyntaxIdentifierStr;
            ExpressionBodyStr = DefaultValues.PropertyDeclarationSyntaxExpressionBodyStr;
            InitializerStr = DefaultValues.PropertyDeclarationSyntaxInitializerStr;
            SemicolonTokenStr = DefaultValues.PropertyDeclarationSyntaxSemicolonTokenStr;
            AttributeListsStr = DefaultValues.PropertyDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.PropertyDeclarationSyntaxModifiersStr;
            TypeStr = DefaultValues.PropertyDeclarationSyntaxTypeStr;
            ExplicitInterfaceSpecifierStr = DefaultValues.PropertyDeclarationSyntaxExplicitInterfaceSpecifierStr;
            AccessorListStr = DefaultValues.PropertyDeclarationSyntaxAccessorListStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken Semicolon
        {
            get
            {
                if (_semicolonIsChanged)
                {
                    _semicolon = SyntaxFactoryStr.ParseSyntaxToken(SemicolonStr);
                    _semicolonIsChanged = false;
                }
                return _semicolon;
            }
            set
            {
                if (_semicolon != value)
                {
                    _semicolon = value;
                    _semicolonIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonStr
        {
            get
            {
                if (_semicolonIsChanged) return _semicolonStr;
                return _semicolonStr = _semicolon.Text;
            }
            set
            {
                if (_semicolonStr != value)
                {
                    _semicolonStr = value;
                    IsChanged = true;
                    _semicolonIsChanged = true;
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

        public EqualsValueClauseSyntax Initializer
        {
            get
            {
                if (_initializerIsChanged)
                {
                    _initializer = SyntaxFactoryStr.ParseEqualsValueClauseSyntax(InitializerStr);
                    _initializerIsChanged = false;
                    _taInitializer = null;
                }
                else if (_taInitializer != null && _taInitializer.IsChanged)
                {
                    _initializer = (EqualsValueClauseSyntax) _taInitializer.Node;
                }
                return _initializer;
            }
            set
            {
                if (_initializer != value)
                {
                    _initializer = value;
                    _initializerIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string InitializerStr
        {
            get
            {
                if (_taInitializer != null && _taInitializer.IsChanged)
                    Initializer = (EqualsValueClauseSyntax) _taInitializer.Node;
                if (_initializerIsChanged) return _initializerStr;
                return _initializerStr = _initializer?.ToFullString();
            }
            set
            {
                if (_taInitializer != null && _taInitializer.IsChanged)
                {
                    Initializer = (EqualsValueClauseSyntax) _taInitializer.Node;
                    _initializerStr = _initializer?.ToFullString();
                }
                if (_initializerStr != value)
                {
                    _initializerStr = value;
                    IsChanged = true;
                    _initializerIsChanged = true;
                    _taInitializer = null;
                }
            }
        }

        public TameEqualsValueClauseSyntax TaInitializer
        {
            get
            {
                if (_taInitializer == null && Initializer != null)
                {
                    _taInitializer = new TameEqualsValueClauseSyntax(Initializer) {TaParent = this};
                    _taInitializer.AddChildren();
                }
                return _taInitializer;
            }
            set
            {
                if (_taInitializer != value)
                {
                    _taInitializer = value;
                    if (_taInitializer != null)
                    {
                        _taInitializer.TaParent = this;
                        _taInitializer.IsChanged = true;
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
            _taExpressionBody = null;
            _taInitializer = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _identifier = ((PropertyDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _expressionBody = ((PropertyDeclarationSyntax) Node).ExpressionBody;
            _expressionBodyIsChanged = false;
            _initializer = ((PropertyDeclarationSyntax) Node).Initializer;
            _initializerIsChanged = false;
            _semicolonToken = ((PropertyDeclarationSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.PropertyDeclaration(AttributeLists, Modifiers, Type, ExplicitInterfaceSpecifier,
                Identifier, AccessorList, ExpressionBody, Initializer, SemicolonToken);
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
            if (TaExpressionBody != null) yield return TaExpressionBody;
            if (TaInitializer != null) yield return TaInitializer;
            if (TaType != null) yield return TaType;
            if (TaExplicitInterfaceSpecifier != null) yield return TaExplicitInterfaceSpecifier;
            if (TaAccessorList != null) yield return TaAccessorList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("SemicolonStr", SemicolonStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("InitializerStr", InitializerStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("TypeStr", TypeStr);
            yield return ("ExplicitInterfaceSpecifierStr", ExplicitInterfaceSpecifierStr);
            yield return ("AccessorListStr", AccessorListStr);
        }

        public TamePropertyDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}