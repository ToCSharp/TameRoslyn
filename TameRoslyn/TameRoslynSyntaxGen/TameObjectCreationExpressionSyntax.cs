// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameObjectCreationExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "ObjectCreationExpressionSyntax";
        private ArgumentListSyntax _argumentList;
        private bool _argumentListIsChanged;
        private string _argumentListStr;
        private InitializerExpressionSyntax _initializer;
        private bool _initializerIsChanged;
        private string _initializerStr;
        private SyntaxToken _newKeyword;
        private bool _newKeywordIsChanged;
        private string _newKeywordStr;
        private TameArgumentListSyntax _taArgumentList;
        private TameInitializerExpressionSyntax _taInitializer;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameObjectCreationExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseObjectCreationExpression(code);
            AddChildren();
        }

        public TameObjectCreationExpressionSyntax(ObjectCreationExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameObjectCreationExpressionSyntax()
        {
            NewKeywordStr = DefaultValues.ObjectCreationExpressionSyntaxNewKeywordStr;
            TypeStr = DefaultValues.ObjectCreationExpressionSyntaxTypeStr;
            ArgumentListStr = DefaultValues.ObjectCreationExpressionSyntaxArgumentListStr;
            InitializerStr = DefaultValues.ObjectCreationExpressionSyntaxInitializerStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken NewKeyword
        {
            get
            {
                if (_newKeywordIsChanged)
                {
                    if (_newKeywordStr == null) _newKeyword = default(SyntaxToken);
                    else _newKeyword = SyntaxFactoryStr.ParseSyntaxToken(_newKeywordStr, SyntaxKind.NewKeyword);
                    _newKeywordIsChanged = false;
                }
                return _newKeyword;
            }
            set
            {
                if (_newKeyword != value)
                {
                    _newKeyword = value;
                    _newKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NewKeywordStr
        {
            get
            {
                if (_newKeywordIsChanged) return _newKeywordStr;
                return _newKeywordStr = _newKeyword.Text;
            }
            set
            {
                if (_newKeywordStr != value)
                {
                    _newKeywordStr = value;
                    IsChanged = true;
                    _newKeywordIsChanged = true;
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

        public ArgumentListSyntax ArgumentList
        {
            get
            {
                if (_argumentListIsChanged)
                {
                    _argumentList = SyntaxFactoryStr.ParseArgumentListSyntax(ArgumentListStr);
                    _argumentListIsChanged = false;
                    _taArgumentList = null;
                }
                else if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    _argumentList = (ArgumentListSyntax) _taArgumentList.Node;
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
                    ArgumentList = (ArgumentListSyntax) _taArgumentList.Node;
                if (_argumentListIsChanged) return _argumentListStr;
                return _argumentListStr = _argumentList?.ToFullString();
            }
            set
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    ArgumentList = (ArgumentListSyntax) _taArgumentList.Node;
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

        public TameArgumentListSyntax TaArgumentList
        {
            get
            {
                if (_taArgumentList == null && ArgumentList != null)
                {
                    _taArgumentList = new TameArgumentListSyntax(ArgumentList) {TaParent = this};
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

        public InitializerExpressionSyntax Initializer
        {
            get
            {
                if (_initializerIsChanged)
                {
                    _initializer = SyntaxFactoryStr.ParseInitializerExpressionSyntax(InitializerStr);
                    _initializerIsChanged = false;
                    _taInitializer = null;
                }
                else if (_taInitializer != null && _taInitializer.IsChanged)
                {
                    _initializer = (InitializerExpressionSyntax) _taInitializer.Node;
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
                    Initializer = (InitializerExpressionSyntax) _taInitializer.Node;
                if (_initializerIsChanged) return _initializerStr;
                return _initializerStr = _initializer?.ToFullString();
            }
            set
            {
                if (_taInitializer != null && _taInitializer.IsChanged)
                {
                    Initializer = (InitializerExpressionSyntax) _taInitializer.Node;
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

        public TameInitializerExpressionSyntax TaInitializer
        {
            get
            {
                if (_taInitializer == null && Initializer != null)
                {
                    _taInitializer = new TameInitializerExpressionSyntax(Initializer) {TaParent = this};
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

        public override void Clear()
        {
            base.Clear();
            _taType = null;
            _taArgumentList = null;
            _taInitializer = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _newKeyword = ((ObjectCreationExpressionSyntax) Node).NewKeyword;
            _newKeywordIsChanged = false;
            _type = ((ObjectCreationExpressionSyntax) Node).Type;
            _typeIsChanged = false;
            _argumentList = ((ObjectCreationExpressionSyntax) Node).ArgumentList;
            _argumentListIsChanged = false;
            _initializer = ((ObjectCreationExpressionSyntax) Node).Initializer;
            _initializerIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ObjectCreationExpression(NewKeyword, Type, ArgumentList, Initializer);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
            if (TaArgumentList != null) yield return TaArgumentList;
            if (TaInitializer != null) yield return TaInitializer;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NewKeywordStr", NewKeywordStr);
            yield return ("TypeStr", TypeStr);
            yield return ("ArgumentListStr", ArgumentListStr);
            yield return ("InitializerStr", InitializerStr);
        }
    }
}