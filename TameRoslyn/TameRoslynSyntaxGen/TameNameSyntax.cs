// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameNameSyntax : TameTypeSyntax
    {
        public new static string TypeName = "NameSyntax";
        private int _arity;
        private bool _arityIsChanged;

        public TameNameSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseName(code);
            AddChildren();
        }

        public TameNameSyntax(NameSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameNameSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public int Arity
        {
            get { return _arity; }
            set
            {
                if (_arity != value)
                {
                    _arity = value;
                    _arityIsChanged = false;
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
            _arity = ((NameSyntax) Node).Arity;
            _arityIsChanged = false;
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
            yield return ("Arity", Arity.ToString());
            yield return ("IsVar", IsVar.ToString());
        }
    }
}