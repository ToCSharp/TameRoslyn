// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBaseTypeDeclarationSyntax : TameMemberDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "BaseTypeDeclarationSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private BaseListSyntax _baseList;
        private bool _baseListIsChanged;
        private string _baseListStr;
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private TameBaseListSyntax _taBaseList;
        private TameSyntaxTokenList _taModifiers;

        public TameBaseTypeDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBaseTypeDeclaration(code);
            AddChildren();
        }

        public TameBaseTypeDeclarationSyntax(BaseTypeDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBaseTypeDeclarationSyntax()
        {
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

        public BaseListSyntax BaseList
        {
            get
            {
                if (_baseListIsChanged)
                {
                    _baseList = SyntaxFactoryStr.ParseBaseListSyntax(BaseListStr);
                    _baseListIsChanged = false;
                    _taBaseList = null;
                }
                else if (_taBaseList != null && _taBaseList.IsChanged)
                {
                    _baseList = (BaseListSyntax) _taBaseList.Node;
                }
                return _baseList;
            }
            set
            {
                if (_baseList != value)
                {
                    _baseList = value;
                    _baseListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string BaseListStr
        {
            get
            {
                if (_taBaseList != null && _taBaseList.IsChanged)
                    BaseList = (BaseListSyntax) _taBaseList.Node;
                if (_baseListIsChanged) return _baseListStr;
                return _baseListStr = _baseList?.ToFullString();
            }
            set
            {
                if (_taBaseList != null && _taBaseList.IsChanged)
                {
                    BaseList = (BaseListSyntax) _taBaseList.Node;
                    _baseListStr = _baseList?.ToFullString();
                }
                if (_baseListStr != value)
                {
                    _baseListStr = value;
                    IsChanged = true;
                    _baseListIsChanged = true;
                    _taBaseList = null;
                }
            }
        }

        public TameBaseListSyntax TaBaseList
        {
            get
            {
                if (_taBaseList == null && BaseList != null)
                {
                    _taBaseList = new TameBaseListSyntax(BaseList) {TaParent = this};
                    _taBaseList.AddChildren();
                }
                return _taBaseList;
            }
            set
            {
                if (_taBaseList != value)
                {
                    _taBaseList = value;
                    if (_taBaseList != null)
                    {
                        _taBaseList.TaParent = this;
                        _taBaseList.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
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
            _taAttributeLists = null;
            _taModifiers = null;
            _taBaseList = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _attributeLists = ((BaseTypeDeclarationSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _modifiers = ((BaseTypeDeclarationSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _identifier = ((BaseTypeDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _baseList = ((BaseTypeDeclarationSyntax) Node).BaseList;
            _baseListIsChanged = false;
            _openBraceToken = ((BaseTypeDeclarationSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _closeBraceToken = ((BaseTypeDeclarationSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
            _semicolonToken = ((BaseTypeDeclarationSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaBaseList != null) yield return TaBaseList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("BaseListStr", BaseListStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}