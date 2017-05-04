// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameSimpleBaseTypeSyntax : TameBaseTypeSyntax
    {
        public new static string TypeName = "SimpleBaseTypeSyntax";

        public TameSimpleBaseTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSimpleBaseType(code);
            AddChildren();
        }

        public TameSimpleBaseTypeSyntax(SimpleBaseTypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSimpleBaseTypeSyntax()
        {
            TypeStr = DefaultValues.SimpleBaseTypeSyntaxTypeStr;
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
            var res = SyntaxFactory.SimpleBaseType(Type);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("TypeStr", TypeStr);
        }
    }
}