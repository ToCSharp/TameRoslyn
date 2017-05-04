// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAnonymousObjectCreationExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "AnonymousObjectCreationExpressionSyntax";
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax> _initializers;
        private int _initializersCount;
        private bool _initializersIsChanged;
        private string _initializersStr;
        private SyntaxToken _newKeyword;
        private bool _newKeywordIsChanged;
        private string _newKeywordStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private List<TameAnonymousObjectMemberDeclaratorSyntax> _taInitializers;

        public TameAnonymousObjectCreationExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAnonymousObjectCreationExpression(code);
            AddChildren();
        }

        public TameAnonymousObjectCreationExpressionSyntax(AnonymousObjectCreationExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAnonymousObjectCreationExpressionSyntax()
        {
            NewKeywordStr = DefaultValues.AnonymousObjectCreationExpressionSyntaxNewKeywordStr;
            OpenBraceTokenStr = DefaultValues.AnonymousObjectCreationExpressionSyntaxOpenBraceTokenStr;
            InitializersStr = DefaultValues.AnonymousObjectCreationExpressionSyntaxInitializersStr;
            CloseBraceTokenStr = DefaultValues.AnonymousObjectCreationExpressionSyntaxCloseBraceTokenStr;
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

        public SyntaxToken OpenBraceToken
        {
            get
            {
                if (_openBraceTokenIsChanged)
                {
                    if (_openBraceTokenStr == null) _openBraceToken = default(SyntaxToken);
                    else
                        _openBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBraceTokenStr, SyntaxKind.OpenBraceToken);
                    _openBraceTokenIsChanged = false;
                }
                return _openBraceToken;
            }
            set
            {
                if (_openBraceToken != value)
                {
                    _openBraceToken = value;
                    _openBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBraceTokenStr
        {
            get
            {
                if (_openBraceTokenIsChanged) return _openBraceTokenStr;
                return _openBraceTokenStr = _openBraceToken.Text;
            }
            set
            {
                if (_openBraceTokenStr != value)
                {
                    _openBraceTokenStr = value;
                    IsChanged = true;
                    _openBraceTokenIsChanged = true;
                }
            }
        }

        public bool TaInitializersIsChanged { get; set; }

        public SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax> Initializers
        {
            get
            {
                if (TaInitializersIsChanged || _taInitializers != null &&
                    (_taInitializers.Count != _initializersCount || _taInitializers.Any(v => v.IsChanged)))
                {
                    _initializers = SyntaxFactory.SeparatedList(TaInitializers?.Select(v => v.Node)
                        .Cast<AnonymousObjectMemberDeclaratorSyntax>());
                    TaInitializersIsChanged = false;
                }
                return _initializers;
            }
            set
            {
                if (_initializers != value)
                {
                    _initializers = value;
                    TaInitializersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string InitializersStr
        {
            get
            {
                if (_initializersIsChanged) return _initializersStr;
                return _initializersStr = string.Join(", ", _initializers.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _initializersStr = value;
                    Initializers = new SeparatedSyntaxList<AnonymousObjectMemberDeclaratorSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAnonymousObjectMemberDeclaratorSyntax> TaInitializers
        {
            get
            {
                if (_taInitializers == null)
                {
                    _taInitializers = new List<TameAnonymousObjectMemberDeclaratorSyntax>();
                    foreach (var item in _initializers)
                        _taInitializers.Add(new TameAnonymousObjectMemberDeclaratorSyntax(item) {TaParent = this});
                }
                return _taInitializers;
            }
            set
            {
                if (_taInitializers != value)
                {
                    _taInitializers = value;
                    _taInitializers?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaInitializersIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                if (_closeBraceTokenIsChanged)
                {
                    if (_closeBraceTokenStr == null) _closeBraceToken = default(SyntaxToken);
                    else
                        _closeBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBraceTokenStr, SyntaxKind.CloseBraceToken);
                    _closeBraceTokenIsChanged = false;
                }
                return _closeBraceToken;
            }
            set
            {
                if (_closeBraceToken != value)
                {
                    _closeBraceToken = value;
                    _closeBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBraceTokenStr
        {
            get
            {
                if (_closeBraceTokenIsChanged) return _closeBraceTokenStr;
                return _closeBraceTokenStr = _closeBraceToken.Text;
            }
            set
            {
                if (_closeBraceTokenStr != value)
                {
                    _closeBraceTokenStr = value;
                    IsChanged = true;
                    _closeBraceTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taInitializers = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _newKeyword = ((AnonymousObjectCreationExpressionSyntax) Node).NewKeyword;
            _newKeywordIsChanged = false;
            _openBraceToken = ((AnonymousObjectCreationExpressionSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _initializers = ((AnonymousObjectCreationExpressionSyntax) Node).Initializers;
            _initializersIsChanged = false;
            _initializersCount = _initializers.Count;
            _closeBraceToken = ((AnonymousObjectCreationExpressionSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaInitializers)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res =
                SyntaxFactory.AnonymousObjectCreationExpression(NewKeyword, OpenBraceToken, Initializers,
                    CloseBraceToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaInitializers)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NewKeywordStr", NewKeywordStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("InitializersStr", InitializersStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
        }

        public TameAnonymousObjectCreationExpressionSyntax AddInitializer(
            TameAnonymousObjectMemberDeclaratorSyntax item)
        {
            item.TaParent = this;
            TaInitializers.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}