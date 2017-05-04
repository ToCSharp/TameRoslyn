// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameFieldDeclarationSyntax : TameBaseFieldDeclarationSyntax
    {
        public new static string TypeName = "FieldDeclarationSyntax";

        public TameFieldDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseFieldDeclaration(code);
            AddChildren();
        }

        public TameFieldDeclarationSyntax(FieldDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameFieldDeclarationSyntax()
        {
            AttributeListsStr = DefaultValues.FieldDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.FieldDeclarationSyntaxModifiersStr;
            DeclarationStr = DefaultValues.FieldDeclarationSyntaxDeclarationStr;
            SemicolonTokenStr = DefaultValues.FieldDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public override void Clear()
        {
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.FieldDeclaration(AttributeLists, Modifiers, Declaration, SemicolonToken);
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
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameFieldDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}