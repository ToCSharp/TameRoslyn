// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameBranchingDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "BranchingDirectiveTriviaSyntax";
        private bool _branchTaken;
        private bool _branchTakenIsChanged;

        public TameBranchingDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBranchingDirectiveTrivia(code);
            AddChildren();
        }

        public TameBranchingDirectiveTriviaSyntax(BranchingDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBranchingDirectiveTriviaSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public bool BranchTaken
        {
            get { return _branchTaken; }
            set
            {
                if (_branchTaken != value)
                {
                    _branchTaken = value;
                    _branchTakenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _branchTaken = ((BranchingDirectiveTriviaSyntax) Node).BranchTaken;
            _branchTakenIsChanged = false;
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
            yield return ("BranchTaken", BranchTaken.ToString());
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}