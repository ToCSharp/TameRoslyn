// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameClassOrStructConstraintSyntax : TameTypeParameterConstraintSyntax
    {
        public new static string TypeName = "ClassOrStructConstraintSyntax";
        private SyntaxToken _classOrStructKeyword;
        private bool _classOrStructKeywordIsChanged;
        private string _classOrStructKeywordStr;

        public TameClassOrStructConstraintSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseClassOrStructConstraint(code);
            AddChildren();
        }

        public TameClassOrStructConstraintSyntax(ClassOrStructConstraintSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameClassOrStructConstraintSyntax()
        {
            ClassOrStructKeywordStr = DefaultValues.ClassOrStructConstraintSyntaxClassOrStructKeywordStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ClassOrStructKeyword
        {
            get
            {
                if (_classOrStructKeywordIsChanged)
                {
                    _classOrStructKeyword = SyntaxFactoryStr.ParseSyntaxToken(ClassOrStructKeywordStr);
                    _classOrStructKeywordIsChanged = false;
                }
                return _classOrStructKeyword;
            }
            set
            {
                if (_classOrStructKeyword != value)
                {
                    _classOrStructKeyword = value;
                    _classOrStructKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ClassOrStructKeywordStr
        {
            get
            {
                if (_classOrStructKeywordIsChanged) return _classOrStructKeywordStr;
                return _classOrStructKeywordStr = _classOrStructKeyword.Text;
            }
            set
            {
                if (_classOrStructKeywordStr != value)
                {
                    _classOrStructKeywordStr = value;
                    IsChanged = true;
                    _classOrStructKeywordIsChanged = true;
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
            _classOrStructKeyword = ((ClassOrStructConstraintSyntax) Node).ClassOrStructKeyword;
            _classOrStructKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            if (ClassOrStructKeywordStr.Contains("class")) return SyntaxKind.ClassConstraint;
            if (ClassOrStructKeywordStr.Contains("struct")) return SyntaxKind.StructConstraint;
            throw new NotImplementedException();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ClassOrStructConstraint(GetKind(), ClassOrStructKeyword);
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
            yield return ("ClassOrStructKeywordStr", ClassOrStructKeywordStr);
        }
    }
}