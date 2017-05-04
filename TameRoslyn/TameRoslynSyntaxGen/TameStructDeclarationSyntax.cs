// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameStructDeclarationSyntax : TameTypeDeclarationSyntax
    {
        public new static string TypeName = "StructDeclarationSyntax";

        public TameStructDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseStructDeclaration(code);
            AddChildren();
        }

        public TameStructDeclarationSyntax(StructDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameStructDeclarationSyntax()
        {
            Arity = DefaultValues.StructDeclarationSyntaxArity;
            KeywordStr = DefaultValues.StructDeclarationSyntaxKeywordStr;
            TypeParameterListStr = DefaultValues.StructDeclarationSyntaxTypeParameterListStr;
            ConstraintClausesStr = DefaultValues.StructDeclarationSyntaxConstraintClausesStr;
            MembersStr = DefaultValues.StructDeclarationSyntaxMembersStr;
            AttributeListsStr = DefaultValues.StructDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.StructDeclarationSyntaxModifiersStr;
            IdentifierStr = DefaultValues.StructDeclarationSyntaxIdentifierStr;
            BaseListStr = DefaultValues.StructDeclarationSyntaxBaseListStr;
            OpenBraceTokenStr = DefaultValues.StructDeclarationSyntaxOpenBraceTokenStr;
            CloseBraceTokenStr = DefaultValues.StructDeclarationSyntaxCloseBraceTokenStr;
            SemicolonTokenStr = DefaultValues.StructDeclarationSyntaxSemicolonTokenStr;
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
            var res = SyntaxFactory.StructDeclaration(AttributeLists, Modifiers, Keyword, Identifier, TypeParameterList,
                BaseList, ConstraintClauses, OpenBraceToken, Members, CloseBraceToken, SemicolonToken);
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

        public TameStructDeclarationSyntax AddConstraintClause(TameTypeParameterConstraintClauseSyntax item)
        {
            item.TaParent = this;
            TaConstraintClauses.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameStructDeclarationSyntax AddMember(TameMemberDeclarationSyntax item)
        {
            item.TaParent = this;
            TaMembers.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameStructDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}