// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameImplicitArrayCreationExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "ImplicitArrayCreationExpressionSyntax";
        private SyntaxToken _closeBracketToken;
        private bool _closeBracketTokenIsChanged;
        private string _closeBracketTokenStr;
        private SyntaxTokenList _commas;
        private bool _commasIsChanged;
        private string _commasStr;
        private InitializerExpressionSyntax _initializer;
        private bool _initializerIsChanged;
        private string _initializerStr;
        private SyntaxToken _newKeyword;
        private bool _newKeywordIsChanged;
        private string _newKeywordStr;
        private SyntaxToken _openBracketToken;
        private bool _openBracketTokenIsChanged;
        private string _openBracketTokenStr;
        private TameSyntaxTokenList _taCommas;
        private TameInitializerExpressionSyntax _taInitializer;

        public TameImplicitArrayCreationExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseImplicitArrayCreationExpression(code);
            AddChildren();
        }

        public TameImplicitArrayCreationExpressionSyntax(ImplicitArrayCreationExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameImplicitArrayCreationExpressionSyntax()
        {
            NewKeywordStr = DefaultValues.ImplicitArrayCreationExpressionSyntaxNewKeywordStr;
            OpenBracketTokenStr = DefaultValues.ImplicitArrayCreationExpressionSyntaxOpenBracketTokenStr;
            CommasStr = DefaultValues.ImplicitArrayCreationExpressionSyntaxCommasStr;
            CloseBracketTokenStr = DefaultValues.ImplicitArrayCreationExpressionSyntaxCloseBracketTokenStr;
            InitializerStr = DefaultValues.ImplicitArrayCreationExpressionSyntaxInitializerStr;
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

        public SyntaxToken OpenBracketToken
        {
            get
            {
                if (_openBracketTokenIsChanged)
                {
                    if (_openBracketTokenStr == null) _openBracketToken = default(SyntaxToken);
                    else
                        _openBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBracketTokenStr, SyntaxKind.OpenBracketToken);
                    _openBracketTokenIsChanged = false;
                }
                return _openBracketToken;
            }
            set
            {
                if (_openBracketToken != value)
                {
                    _openBracketToken = value;
                    _openBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBracketTokenStr
        {
            get
            {
                if (_openBracketTokenIsChanged) return _openBracketTokenStr;
                return _openBracketTokenStr = _openBracketToken.Text;
            }
            set
            {
                if (_openBracketTokenStr != value)
                {
                    _openBracketTokenStr = value;
                    IsChanged = true;
                    _openBracketTokenIsChanged = true;
                }
            }
        }

        public SyntaxTokenList Commas
        {
            get
            {
                if (_commasIsChanged)
                {
                    _commas = SyntaxFactoryStr.ParseSyntaxTokenList(CommasStr);
                    _commasIsChanged = false;
                    _taCommas = null;
                }
                else if (_taCommas != null && _taCommas.IsChanged)
                {
                    _commas = _taCommas.Node;
                }
                return _commas;
            }
            set
            {
                if (_commas != value)
                {
                    _commas = value;
                    _commasIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CommasStr
        {
            get
            {
                if (_taCommas != null && _taCommas.IsChanged)
                    Commas = _taCommas.Node;
                if (_commasIsChanged) return _commasStr;
                return _commasStr = _commas.ToFullString();
            }
            set
            {
                if (_taCommas != null && _taCommas.IsChanged)
                {
                    Commas = _taCommas.Node;
                    _commasStr = _commas.ToFullString();
                }
                if (_commasStr != value)
                {
                    _commasStr = value;
                    IsChanged = true;
                    _commasIsChanged = true;
                    _taCommas = null;
                }
            }
        }

        public TameSyntaxTokenList TaCommas
        {
            get
            {
                if (_taCommas == null)
                {
                    _taCommas = new TameSyntaxTokenList(Commas) {TaParent = this};
                    _taCommas.AddChildren();
                }
                return _taCommas;
            }
            set
            {
                if (_taCommas != value)
                {
                    _taCommas = value;
                    if (_taCommas != null)
                    {
                        _taCommas.TaParent = this;
                        _taCommas.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken CloseBracketToken
        {
            get
            {
                if (_closeBracketTokenIsChanged)
                {
                    if (_closeBracketTokenStr == null) _closeBracketToken = default(SyntaxToken);
                    else
                        _closeBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBracketTokenStr, SyntaxKind.CloseBracketToken);
                    _closeBracketTokenIsChanged = false;
                }
                return _closeBracketToken;
            }
            set
            {
                if (_closeBracketToken != value)
                {
                    _closeBracketToken = value;
                    _closeBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBracketTokenStr
        {
            get
            {
                if (_closeBracketTokenIsChanged) return _closeBracketTokenStr;
                return _closeBracketTokenStr = _closeBracketToken.Text;
            }
            set
            {
                if (_closeBracketTokenStr != value)
                {
                    _closeBracketTokenStr = value;
                    IsChanged = true;
                    _closeBracketTokenIsChanged = true;
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
            _taCommas = null;
            _taInitializer = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _newKeyword = ((ImplicitArrayCreationExpressionSyntax) Node).NewKeyword;
            _newKeywordIsChanged = false;
            _openBracketToken = ((ImplicitArrayCreationExpressionSyntax) Node).OpenBracketToken;
            _openBracketTokenIsChanged = false;
            _commas = ((ImplicitArrayCreationExpressionSyntax) Node).Commas;
            _commasIsChanged = false;
            _closeBracketToken = ((ImplicitArrayCreationExpressionSyntax) Node).CloseBracketToken;
            _closeBracketTokenIsChanged = false;
            _initializer = ((ImplicitArrayCreationExpressionSyntax) Node).Initializer;
            _initializerIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ImplicitArrayCreationExpression(NewKeyword, OpenBracketToken, Commas,
                CloseBracketToken, Initializer);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaInitializer != null) yield return TaInitializer;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NewKeywordStr", NewKeywordStr);
            yield return ("OpenBracketTokenStr", OpenBracketTokenStr);
            yield return ("CommasStr", CommasStr);
            yield return ("CloseBracketTokenStr", CloseBracketTokenStr);
            yield return ("InitializerStr", InitializerStr);
        }
    }
}