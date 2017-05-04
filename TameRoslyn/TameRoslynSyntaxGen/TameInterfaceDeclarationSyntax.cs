// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameInterfaceDeclarationSyntax : TameTypeDeclarationSyntax
    {
        public new static string TypeName = "InterfaceDeclarationSyntax";

        public TameInterfaceDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseInterfaceDeclaration(code);
            AddChildren();
        }

        public TameInterfaceDeclarationSyntax(InterfaceDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameInterfaceDeclarationSyntax()
        {
            Arity = DefaultValues.InterfaceDeclarationSyntaxArity;
            KeywordStr = DefaultValues.InterfaceDeclarationSyntaxKeywordStr;
            TypeParameterListStr = DefaultValues.InterfaceDeclarationSyntaxTypeParameterListStr;
            ConstraintClausesStr = DefaultValues.InterfaceDeclarationSyntaxConstraintClausesStr;
            MembersStr = DefaultValues.InterfaceDeclarationSyntaxMembersStr;
            AttributeListsStr = DefaultValues.InterfaceDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.InterfaceDeclarationSyntaxModifiersStr;
            IdentifierStr = DefaultValues.InterfaceDeclarationSyntaxIdentifierStr;
            BaseListStr = DefaultValues.InterfaceDeclarationSyntaxBaseListStr;
            OpenBraceTokenStr = DefaultValues.InterfaceDeclarationSyntaxOpenBraceTokenStr;
            CloseBraceTokenStr = DefaultValues.InterfaceDeclarationSyntaxCloseBraceTokenStr;
            SemicolonTokenStr = DefaultValues.InterfaceDeclarationSyntaxSemicolonTokenStr;
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
            var res = SyntaxFactory.InterfaceDeclaration(AttributeLists, Modifiers, Keyword, Identifier,
                TypeParameterList, BaseList, ConstraintClauses, OpenBraceToken, Members, CloseBraceToken,
                SemicolonToken);
// if (Arity != null) res = res.WithArity(Arity);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaConstraintClauses)
                yield return item;
            foreach (var item in TaMembers)
                yield return item;
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaTypeParameterList != null) yield return TaTypeParameterList;
            if (TaBaseList != null) yield return TaBaseList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("Arity", Arity.ToString());
            yield return ("KeywordStr", KeywordStr);
            yield return ("TypeParameterListStr", TypeParameterListStr);
            yield return ("ConstraintClausesStr", ConstraintClausesStr);
            yield return ("MembersStr", MembersStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("BaseListStr", BaseListStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameInterfaceDeclarationSyntax AddConstraintClause(TameTypeParameterConstraintClauseSyntax item)
        {
            item.TaParent = this;
            TaConstraintClauses.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameInterfaceDeclarationSyntax AddMember(TameMemberDeclarationSyntax item)
        {
            item.TaParent = this;
            TaMembers.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameInterfaceDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}