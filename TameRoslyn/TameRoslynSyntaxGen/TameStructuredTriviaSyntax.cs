// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameStructuredTriviaSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "StructuredTriviaSyntax";

        public TameStructuredTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseStructuredTrivia(code);
            AddChildren();
        }

        public TameStructuredTriviaSyntax(StructuredTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameStructuredTriviaSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public override void Clear()
        {
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
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
            yield break;
        }
    }
}