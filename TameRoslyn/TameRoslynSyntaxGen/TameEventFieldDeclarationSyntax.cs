// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameEventFieldDeclarationSyntax : TameBaseFieldDeclarationSyntax
    {
        public new static string TypeName = "EventFieldDeclarationSyntax";
        private SyntaxToken _eventKeyword;
        private bool _eventKeywordIsChanged;
        private string _eventKeywordStr;

        public TameEventFieldDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseEventFieldDeclaration(code);
            AddChildren();
        }

        public TameEventFieldDeclarationSyntax(EventFieldDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameEventFieldDeclarationSyntax()
        {
            EventKeywordStr = DefaultValues.EventFieldDeclarationSyntaxEventKeywordStr;
            AttributeListsStr = DefaultValues.EventFieldDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.EventFieldDeclarationSyntaxModifiersStr;
            DeclarationStr = DefaultValues.EventFieldDeclarationSyntaxDeclarationStr;
            SemicolonTokenStr = DefaultValues.EventFieldDeclarationSyntaxSemicolonTokenStr;
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

        public override void Clear()
        {
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _eventKeyword = ((EventFieldDeclarationSyntax) Node).EventKeyword;
            _eventKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.EventFieldDeclaration(AttributeLists, Modifiers, EventKeyword, Declaration,
                SemicolonToken);
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
            if (TaDeclaration != null) yield return TaDeclaration;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("EventKeywordStr", EventKeywordStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameEventFieldDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}