// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameBaseFieldDeclarationSyntax : TameMemberDeclarationSyntax
    {
        public new static string TypeName = "BaseFieldDeclarationSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private VariableDeclarationSyntax _declaration;
        private bool _declarationIsChanged;
        private string _declarationStr;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private TameVariableDeclarationSyntax _taDeclaration;
        private TameSyntaxTokenList _taModifiers;

        public TameBaseFieldDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBaseFieldDeclaration(code);
            AddChildren();
        }

        public TameBaseFieldDeclarationSyntax(BaseFieldDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBaseFieldDeclarationSyntax()
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

        public VariableDeclarationSyntax Declaration
        {
            get
            {
                if (_declarationIsChanged)
                {
                    _declaration = SyntaxFactoryStr.ParseVariableDeclarationSyntax(DeclarationStr);
                    _declarationIsChanged = false;
                    _taDeclaration = null;
                }
                else if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    _declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                }
                return _declaration;
            }
            set
            {
                if (_declaration != value)
                {
                    _declaration = value;
                    _declarationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DeclarationStr
        {
            get
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                if (_declarationIsChanged) return _declarationStr;
                return _declarationStr = _declaration?.ToFullString();
            }
            set
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                    _declarationStr = _declaration?.ToFullString();
                }
                if (_declarationStr != value)
                {
                    _declarationStr = value;
                    IsChanged = true;
                    _declarationIsChanged = true;
                    _taDeclaration = null;
                }
            }
        }

        public TameVariableDeclarationSyntax TaDeclaration
        {
            get
            {
                if (_taDeclaration == null && Declaration != null)
                {
                    _taDeclaration = new TameVariableDeclarationSyntax(Declaration) {TaParent = this};
                    _taDeclaration.AddChildren();
                }
                return _taDeclaration;
            }
            set
            {
                if (_taDeclaration != value)
                {
                    _taDeclaration = value;
                    if (_taDeclaration != null)
                    {
                        _taDeclaration.TaParent = this;
                        _taDeclaration.IsChanged = true;
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
            base.Clear();
            _taAttributeLists = null;
            _taModifiers = null;
            _taDeclaration = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _attributeLists = ((BaseFieldDeclarationSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _modifiers = ((BaseFieldDeclarationSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _declaration = ((BaseFieldDeclarationSyntax) Node).Declaration;
            _declarationIsChanged = false;
            _semicolonToken = ((BaseFieldDeclarationSyntax) Node).SemicolonToken;
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
            if (TaDeclaration != null) yield return TaDeclaration;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}