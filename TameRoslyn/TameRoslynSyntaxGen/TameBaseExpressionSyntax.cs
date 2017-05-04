// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBaseExpressionSyntax : TameInstanceExpressionSyntax
    {
        public new static string TypeName = "BaseExpressionSyntax";
        private SyntaxToken _token;
        private bool _tokenIsChanged;
        private string _tokenStr;

        public TameBaseExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBaseExpression(code);
            AddChildren();
        }

        public TameBaseExpressionSyntax(BaseExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBaseExpressionSyntax()
        {
            TokenStr = DefaultValues.BaseExpressionSyntaxTokenStr;
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
            _token = ((BaseExpressionSyntax) Node).Token;
            _tokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.BaseExpression(Token);
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