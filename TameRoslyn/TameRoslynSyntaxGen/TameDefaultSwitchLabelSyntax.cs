// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDefaultSwitchLabelSyntax : TameSwitchLabelSyntax
    {
        public new static string TypeName = "DefaultSwitchLabelSyntax";

        public TameDefaultSwitchLabelSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDefaultSwitchLabel(code);
            AddChildren();
        }

        public TameDefaultSwitchLabelSyntax(DefaultSwitchLabelSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDefaultSwitchLabelSyntax()
        {
            KeywordStr = DefaultValues.DefaultSwitchLabelSyntaxKeywordStr;
            ColonTokenStr = DefaultValues.DefaultSwitchLabelSyntaxColonTokenStr;
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
            var res = SyntaxFactory.DefaultSwitchLabel(Keyword, ColonToken);
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
            yield return ("KeywordStr", KeywordStr);
            yield return ("ColonTokenStr", ColonTokenStr);
        }
    }
}