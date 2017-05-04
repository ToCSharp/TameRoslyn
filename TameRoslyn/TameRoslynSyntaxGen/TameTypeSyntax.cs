// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameTypeSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "TypeSyntax";
        private bool _isVar;
        private bool _isVarIsChanged;

        public TameTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseType(code);
            AddChildren();
        }

        public TameTypeSyntax(TypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTypeSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public bool IsVar
        {
            get { return _isVar; }
            set
            {
                if (_isVar != value)
                {
                    _isVar = value;
                    _isVarIsChanged = false;
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
            _isVar = ((TypeSyntax) Node).IsVar;
            _isVarIsChanged = false;
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
            yield return ("IsVar", IsVar.ToString());
        }
    }
}