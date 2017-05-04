// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameArrayCreationExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "ArrayCreationExpressionSyntax";
        private InitializerExpressionSyntax _initializer;
        private bool _initializerIsChanged;
        private string _initializerStr;
        private SyntaxToken _newKeyword;
        private bool _newKeywordIsChanged;
        private string _newKeywordStr;
        private TameInitializerExpressionSyntax _taInitializer;
        private TameArrayTypeSyntax _taType;
        private ArrayTypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameArrayCreationExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseArrayCreationExpression(code);
            AddChildren();
        }

        public TameArrayCreationExpressionSyntax(ArrayCreationExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameArrayCreationExpressionSyntax()
        {
            NewKeywordStr = DefaultValues.ArrayCreationExpressionSyntaxNewKeywordStr;
            TypeStr = DefaultValues.ArrayCreationExpressionSyntaxTypeStr;
            InitializerStr = DefaultValues.ArrayCreationExpressionSyntaxInitializerStr;
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

        public ArrayTypeSyntax Type
        {
            get
            {
                if (_typeIsChanged)
                {
                    _type = SyntaxFactoryStr.ParseArrayTypeSyntax(TypeStr);
                    _typeIsChanged = false;
                    _taType = null;
                }
                else if (_taType != null && _taType.IsChanged)
                {
                    _type = (ArrayTypeSyntax) _taType.Node;
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
                    Type = (ArrayTypeSyntax) _taType.Node;
                if (_typeIsChanged) return _typeStr;
                return _typeStr = _type?.ToFullString();
            }
            set
            {
                if (_taType != null && _taType.IsChanged)
                {
                    Type = (ArrayTypeSyntax) _taType.Node;
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

        public TameArrayTypeSyntax TaType
        {
            get
            {
                if (_taType == null && Type != null)
                {
                    _taType = new TameArrayTypeSyntax(Type) {TaParent = this};
                    _taType.AddChildren();
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
            _taInitializer = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _newKeyword = ((ArrayCreationExpressionSyntax) Node).NewKeyword;
            _newKeywordIsChanged = false;
            _type = ((ArrayCreationExpressionSyntax) Node).Type;
            _typeIsChanged = false;
            _initializer = ((ArrayCreationExpressionSyntax) Node).Initializer;
            _initializerIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ArrayCreationExpression(NewKeyword, Type, Initializer);
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
            if (TaInitializer != null) yield return TaInitializer;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NewKeywordStr", NewKeywordStr);
            yield return ("TypeStr", TypeStr);
            yield return ("InitializerStr", InitializerStr);
        }
    }
}