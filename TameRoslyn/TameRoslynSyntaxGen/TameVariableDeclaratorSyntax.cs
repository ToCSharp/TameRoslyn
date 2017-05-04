// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameVariableDeclaratorSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "VariableDeclaratorSyntax";
        private BracketedArgumentListSyntax _argumentList;
        private bool _argumentListIsChanged;
        private string _argumentListStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private EqualsValueClauseSyntax _initializer;
        private bool _initializerIsChanged;
        private string _initializerStr;
        private TameBracketedArgumentListSyntax _taArgumentList;
        private TameEqualsValueClauseSyntax _taInitializer;

        public TameVariableDeclaratorSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseVariableDeclarator(code);
            AddChildren();
        }

        public TameVariableDeclaratorSyntax(VariableDeclaratorSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameVariableDeclaratorSyntax()
        {
            IdentifierStr = DefaultValues.VariableDeclaratorSyntaxIdentifierStr;
            ArgumentListStr = DefaultValues.VariableDeclaratorSyntaxArgumentListStr;
            InitializerStr = DefaultValues.VariableDeclaratorSyntaxInitializerStr;
        }

        public override string RoslynTypeName => TypeName;

        public BracketedArgumentListSyntax ArgumentList
        {
            get
            {
                if (_argumentListIsChanged)
                {
                    _argumentList = SyntaxFactoryStr.ParseBracketedArgumentListSyntax(ArgumentListStr);
                    _argumentListIsChanged = false;
                    _taArgumentList = null;
                }
                else if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    _argumentList = (BracketedArgumentListSyntax) _taArgumentList.Node;
                }
                return _argumentList;
            }
            set
            {
                if (_argumentList != value)
                {
                    _argumentList = value;
                    _argumentListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ArgumentListStr
        {
            get
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                    ArgumentList = (BracketedArgumentListSyntax) _taArgumentList.Node;
                if (_argumentListIsChanged) return _argumentListStr;
                return _argumentListStr = _argumentList?.ToFullString();
            }
            set
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    ArgumentList = (BracketedArgumentListSyntax) _taArgumentList.Node;
                    _argumentListStr = _argumentList?.ToFullString();
                }
                if (_argumentListStr != value)
                {
                    _argumentListStr = value;
                    IsChanged = true;
                    _argumentListIsChanged = true;
                    _taArgumentList = null;
                }
            }
        }

        public TameBracketedArgumentListSyntax TaArgumentList
        {
            get
            {
                if (_taArgumentList == null && ArgumentList != null)
                {
                    _taArgumentList = new TameBracketedArgumentListSyntax(ArgumentList) {TaParent = this};
                    _taArgumentList.AddChildren();
                }
                return _taArgumentList;
            }
            set
            {
                if (_taArgumentList != value)
                {
                    _taArgumentList = value;
                    if (_taArgumentList != null)
                    {
                        _taArgumentList.TaParent = this;
                        _taArgumentList.IsChanged = true;
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
            _taArgumentList = null;
            _taInitializer = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _identifier = ((VariableDeclaratorSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _argumentList = ((VariableDeclaratorSyntax) Node).ArgumentList;
            _argumentListIsChanged = false;
            _initializer = ((VariableDeclaratorSyntax) Node).Initializer;
            _initializerIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.VariableDeclarator(Identifier, ArgumentList, Initializer);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaArgumentList != null) yield return TaArgumentList;
            if (TaInitializer != null) yield return TaInitializer;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("ArgumentListStr", ArgumentListStr);
            yield return ("InitializerStr", InitializerStr);
        }
    }
}