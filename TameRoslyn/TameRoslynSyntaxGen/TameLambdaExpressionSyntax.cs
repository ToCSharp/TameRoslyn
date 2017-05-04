// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameLambdaExpressionSyntax : TameAnonymousFunctionExpressionSyntax
    {
        public new static string TypeName = "LambdaExpressionSyntax";
        private SyntaxToken _arrowToken;
        private bool _arrowTokenIsChanged;
        private string _arrowTokenStr;

        public TameLambdaExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseLambdaExpression(code);
            AddChildren();
        }

        public TameLambdaExpressionSyntax(LambdaExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameLambdaExpressionSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ArrowToken
        {
            get
            {
                if (_arrowTokenIsChanged)
                {
                    _arrowToken = SyntaxFactoryStr.ParseSyntaxToken(ArrowTokenStr);
                    _arrowTokenIsChanged = false;
                }
                return _arrowToken;
            }
            set
            {
                if (_arrowToken != value)
                {
                    _arrowToken = value;
                    _arrowTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ArrowTokenStr
        {
            get
            {
                if (_arrowTokenIsChanged) return _arrowTokenStr;
                return _arrowTokenStr = _arrowToken.Text;
            }
            set
            {
                if (_arrowTokenStr != value)
                {
                    _arrowTokenStr = value;
                    IsChanged = true;
                    _arrowTokenIsChanged = true;
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
            _arrowToken = ((LambdaExpressionSyntax) Node).ArrowToken;
            _arrowTokenIsChanged = false;
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
            if (TaBody != null) yield return TaBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ArrowTokenStr", ArrowTokenStr);
            yield return ("AsyncKeywordStr", AsyncKeywordStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}