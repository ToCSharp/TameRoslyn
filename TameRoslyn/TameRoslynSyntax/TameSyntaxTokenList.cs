// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace Zu.TameRoslyn.Syntax
{
    public class TameSyntaxTokenList
    {
        public TameSyntaxTokenList(SyntaxTokenList list)
        {
            Node = list;
        }

        public SyntaxTokenList Node { get; set; }
        public TameBaseRoslynNode TaParent { get; set; }
        public bool IsChanged { get; set; }

        internal void AddChildren()
        {
            //throw new NotImplementedException();
        }
    }
}