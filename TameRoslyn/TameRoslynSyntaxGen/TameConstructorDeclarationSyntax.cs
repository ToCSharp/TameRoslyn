// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameConstructorDeclarationSyntax : TameBaseMethodDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "ConstructorDeclarationSyntax";
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private ConstructorInitializerSyntax _initializer;
        private bool _initializerIsChanged;
        private string _initializerStr;
        private TameConstructorInitializerSyntax _taInitializer;

        public TameConstructorDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseConstructorDeclaration(code);
            AddChildren();
        }

        public TameConstructorDeclarationSyntax(ConstructorDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameConstructorDeclarationSyntax()
        {
            IdentifierStr = DefaultValues.ConstructorDeclarationSyntaxIdentifierStr;
            InitializerStr = DefaultValues.ConstructorDeclarationSyntaxInitializerStr;
            AttributeListsStr = DefaultValues.ConstructorDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.ConstructorDeclarationSyntaxModifiersStr;
            ParameterListStr = DefaultValues.ConstructorDeclarationSyntaxParameterListStr;
            BodyStr = DefaultValues.ConstructorDeclarationSyntaxBodyStr;
            ExpressionBodyStr = DefaultValues.ConstructorDeclarationSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.ConstructorDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public ConstructorInitializerSyntax Initializer
        {
            get
            {
                if (_initializerIsChanged)
                {
                    _initializer = SyntaxFactoryStr.ParseConstructorInitializerSyntax(InitializerStr);
                    _initializerIsChanged = false;
                    _taInitializer = null;
                }
                else if (_taInitializer != null && _taInitializer.IsChanged)
                {
                    _initializer = (ConstructorInitializerSyntax) _taInitializer.Node;
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
                    Initializer = (ConstructorInitializerSyntax) _taInitializer.Node;
                if (_initializerIsChanged) return _initializerStr;
                return _initializerStr = _initializer?.ToFullString();
            }
            set
            {
                if (_taInitializer != null && _taInitializer.IsChanged)
                {
                    Initializer = (ConstructorInitializerSyntax) _taInitializer.Node;
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

        public TameConstructorInitializerSyntax TaInitializer
        {
            get
            {
                if (_taInitializer == null && Initializer != null)
                {
                    _taInitializer = new TameConstructorInitializerSyntax(Initializer) {TaParent = this};
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
            _taInitializer = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _identifier = ((ConstructorDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _initializer = ((ConstructorDeclarationSyntax) Node).Initializer;
            _initializerIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ConstructorDeclaration(AttributeLists, Modifiers, Identifier, ParameterList,
                Initializer, Body, ExpressionBody, SemicolonToken);
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
            if (TaInitializer != null) yield return TaInitializer;
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
            if (TaExpressionBody != null) yield return TaExpressionBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("InitializerStr", InitializerStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("BodyStr", BodyStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameConstructorDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}