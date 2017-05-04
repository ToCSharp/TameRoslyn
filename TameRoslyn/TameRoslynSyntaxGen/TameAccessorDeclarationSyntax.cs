// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAccessorDeclarationSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "AccessorDeclarationSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private BlockSyntax _body;
        private bool _bodyIsChanged;
        private string _bodyStr;
        private ArrowExpressionClauseSyntax _expressionBody;
        private bool _expressionBodyIsChanged;
        private string _expressionBodyStr;
        private SyntaxToken _keyword;
        private bool _keywordIsChanged;
        private string _keywordStr;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private TameBlockSyntax _taBody;
        private TameArrowExpressionClauseSyntax _taExpressionBody;
        private TameSyntaxTokenList _taModifiers;

        public TameAccessorDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAccessorDeclaration(code);
            AddChildren();
        }

        public TameAccessorDeclarationSyntax(AccessorDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAccessorDeclarationSyntax()
        {
            AttributeListsStr = DefaultValues.AccessorDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.AccessorDeclarationSyntaxModifiersStr;
            KeywordStr = DefaultValues.AccessorDeclarationSyntaxKeywordStr;
            BodyStr = DefaultValues.AccessorDeclarationSyntaxBodyStr;
            ExpressionBodyStr = DefaultValues.AccessorDeclarationSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.AccessorDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;
        public bool TaAttributeListsIsChanged { get; set; }

        public SyntaxList<AttributeListSyntax> AttributeLists
        {
            get
            {
                if (TaAttributeListsIsChanged || _taAttributeLists != null &&
                    (_taAttributeLists.Count != _attributeListsCount || _taAttributeLists.Any(v => v.IsChanged)))
                {
                    _attributeLists = SyntaxFactory.List(TaAttributeLists?.Select(v => v.Node)
                        .Cast<AttributeListSyntax>());
                    TaAttributeListsIsChanged = false;
                }
                return _attributeLists;
            }
            set
            {
                if (_attributeLists != value)
                {
                    _attributeLists = value;
                    TaAttributeListsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AttributeListsStr
        {
            get
            {
                if (_attributeListsIsChanged) return _attributeListsStr;
                return _attributeListsStr = string.Join(", ", _attributeLists.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _attributeListsStr = value;
                    AttributeLists = new SyntaxList<AttributeListSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAttributeListSyntax> TaAttributeLists
        {
            get
            {
                if (_taAttributeLists == null)
                {
                    _taAttributeLists = new List<TameAttributeListSyntax>();
                    foreach (var item in _attributeLists)
                        _taAttributeLists.Add(new TameAttributeListSyntax(item) {TaParent = this});
                }
                return _taAttributeLists;
            }
            set
            {
                if (_taAttributeLists != value)
                {
                    _taAttributeLists = value;
                    _taAttributeLists?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAttributeListsIsChanged = true;
                }
            }
        }

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

        public SyntaxToken Keyword
        {
            get
            {
                if (_keywordIsChanged)
                {
                    _keyword = SyntaxFactoryStr.ParseSyntaxToken(KeywordStr);
                    _keywordIsChanged = false;
                }
                return _keyword;
            }
            set
            {
                if (_keyword != value)
                {
                    _keyword = value;
                    _keywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string KeywordStr
        {
            get
            {
                if (_keywordIsChanged) return _keywordStr;
                return _keywordStr = _keyword.Text;
            }
            set
            {
                if (_keywordStr != value)
                {
                    _keywordStr = value;
                    IsChanged = true;
                    _keywordIsChanged = true;
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

        public override void Clear()
        {
            _taAttributeLists = null;
            _taModifiers = null;
            _taBody = null;
            _taExpressionBody = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _attributeLists = ((AccessorDeclarationSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _modifiers = ((AccessorDeclarationSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _keyword = ((AccessorDeclarationSyntax) Node).Keyword;
            _keywordIsChanged = false;
            _body = ((AccessorDeclarationSyntax) Node).Body;
            _bodyIsChanged = false;
            _expressionBody = ((AccessorDeclarationSyntax) Node).ExpressionBody;
            _expressionBodyIsChanged = false;
            _semicolonToken = ((AccessorDeclarationSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            return SyntaxFacts.GetAccessorDeclarationKind(SyntaxFacts.GetContextualKeywordKind(KeywordStr));
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AccessorDeclaration(GetKind(), AttributeLists, Modifiers, Keyword, Body,
                ExpressionBody, SemicolonToken);
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
            if (TaBody != null) yield return TaBody;
            if (TaExpressionBody != null) yield return TaExpressionBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("KeywordStr", KeywordStr);
            yield return ("BodyStr", BodyStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameAccessorDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}