// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameThisExpressionSyntax : TameInstanceExpressionSyntax
    {
        public new static string TypeName = "ThisExpressionSyntax";
        private SyntaxToken _token;
        private bool _tokenIsChanged;
        private string _tokenStr;

        public TameThisExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseThisExpression(code);
            AddChildren();
        }

        public TameThisExpressionSyntax(ThisExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameThisExpressionSyntax()
        {
            TokenStr = DefaultValues.ThisExpressionSyntaxTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken Token
        {
            get
            {
                if (_tokenIsChanged)
                {
                    _token = SyntaxFactoryStr.ParseSyntaxToken(TokenStr);
                    _tokenIsChanged = false;
                }
                return _token;
            }
            set
            {
                if (_token != value)
                {
                    _token = value;
                    _tokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TokenStr
        {
            get
            {
                if (_tokenIsChanged) return _tokenStr;
                return _tokenStr = _token.Text;
            }
            set
            {
                if (_tokenStr != value)
                {
                    _tokenStr = value;
                    IsChanged = true;
                    _tokenIsChanged = true;
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
            _token = ((ThisExpressionSyntax) Node).Token;
            _tokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ThisExpression(Token);
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
            yield return ("TokenStr", TokenStr);
        }
    }
}