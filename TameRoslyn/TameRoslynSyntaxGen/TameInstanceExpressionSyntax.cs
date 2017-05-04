// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameInstanceExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "InstanceExpressionSyntax";

        public TameInstanceExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseInstanceExpression(code);
            AddChildren();
        }

        public TameInstanceExpressionSyntax(InstanceExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameInstanceExpressionSyntax()
        {
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