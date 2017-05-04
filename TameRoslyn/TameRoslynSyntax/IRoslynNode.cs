// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Zu.TameRoslyn.Syntax
{
    public interface IRoslynNode
    {
        string RoslynTypeName { get; }

        SyntaxNode Node { get; set; }

        SyntaxKind Kind { get; set; }

        TameBaseRoslynNode TaParent { get; set; }

        bool IsChanged { get; set; }

        string Source { get; }
        void SetNotChanged();
        IEnumerable<TameBaseRoslynNode> GetChildren();
        IEnumerable<TameBaseRoslynNode> GetTameFields();
        IEnumerable<TameBaseRoslynNode> Descendants(bool includeSelf = true);
        IEnumerable<TameBaseRoslynNode> DescendantsAll(bool includeSelf = true);
        IEnumerable<TameBaseRoslynNode> Ancestors(bool includeSelf = false);
        StringBuilder ToStringTree(StringBuilder sb, int intend = 0, int maxChars = 50);
    }
}