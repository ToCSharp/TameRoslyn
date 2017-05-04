// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameIdentifierNameSyntax : TameSimpleNameSyntax
    {
        public new static string TypeName = "IdentifierNameSyntax";

        public TameIdentifierNameSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseIdentifierName(code);
            AddChildren();
        }

        public TameIdentifierNameSyntax(IdentifierNameSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameIdentifierNameSyntax()
        {
            IdentifierStr = DefaultValues.IdentifierNameSyntaxIdentifierStr;
            Arity = DefaultValues.IdentifierNameSyntaxArity;
            IsVar = DefaultValues.IdentifierNameSyntaxIsVar;
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
            var res = SyntaxFactory.IdentifierName(Identifier);
// if (Arity != null) res = res.WithArity(Arity);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("Arity", Arity.ToString());
            yield return ("IsVar", IsVar.ToString());
        }
    }
}