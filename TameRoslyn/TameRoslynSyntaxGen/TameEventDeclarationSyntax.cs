// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameEventDeclarationSyntax : TameBasePropertyDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "EventDeclarationSyntax";
        private SyntaxToken _eventKeyword;
        private bool _eventKeywordIsChanged;
        private string _eventKeywordStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;

        public TameEventDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseEventDeclaration(code);
            AddChildren();
        }

        public TameEventDeclarationSyntax(EventDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameEventDeclarationSyntax()
        {
            EventKeywordStr = DefaultValues.EventDeclarationSyntaxEventKeywordStr;
            IdentifierStr = DefaultValues.EventDeclarationSyntaxIdentifierStr;
            AttributeListsStr = DefaultValues.EventDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.EventDeclarationSyntaxModifiersStr;
            TypeStr = DefaultValues.EventDeclarationSyntaxTypeStr;
            ExplicitInterfaceSpecifierStr = DefaultValues.EventDeclarationSyntaxExplicitInterfaceSpecifierStr;
            AccessorListStr = DefaultValues.EventDeclarationSyntaxAccessorListStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken EventKeyword
        {
            get
            {
                if (_eventKeywordIsChanged)
                {
                    if (_eventKeywordStr == null) _eventKeyword = default(SyntaxToken);
                    else _eventKeyword = SyntaxFactoryStr.ParseSyntaxToken(_eventKeywordStr, SyntaxKind.EventKeyword);
                    _eventKeywordIsChanged = false;
                }
                return _eventKeyword;
            }
            set
            {
                if (_eventKeyword != value)
                {
                    _eventKeyword = value;
                    _eventKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EventKeywordStr
        {
            get
            {
                if (_eventKeywordIsChanged) return _eventKeywordStr;
                return _eventKeywordStr = _eventKeyword.Text;
            }
            set
            {
                if (_eventKeywordStr != value)
                {
                    _eventKeywordStr = value;
                    IsChanged = true;
                    _eventKeywordIsChanged = true;
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
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _eventKeyword = ((EventDeclarationSyntax) Node).EventKeyword;
            _eventKeywordIsChanged = false;
            _identifier = ((EventDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.EventDeclaration(AttributeLists, Modifiers, EventKeyword, Type,
                ExplicitInterfaceSpecifier, Identifier, AccessorList);
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
            if (TaType != null) yield return TaType;
            if (TaExplicitInterfaceSpecifier != null) yield return TaExplicitInterfaceSpecifier;
            if (TaAccessorList != null) yield return TaAccessorList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("EventKeywordStr", EventKeywordStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("TypeStr", TypeStr);
            yield return ("ExplicitInterfaceSpecifierStr", ExplicitInterfaceSpecifierStr);
            yield return ("AccessorListStr", AccessorListStr);
        }

        public TameEventDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}