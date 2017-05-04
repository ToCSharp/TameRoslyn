// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameInterpolatedStringTextSyntax : TameInterpolatedStringContentSyntax
    {
        public new static string TypeName = "InterpolatedStringTextSyntax";
        private SyntaxToken _textToken;
        private bool _textTokenIsChanged;
        private string _textTokenStr;

        public TameInterpolatedStringTextSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseInterpolatedStringText(code);
            AddChildren();
        }

        public TameInterpolatedStringTextSyntax(InterpolatedStringTextSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameInterpolatedStringTextSyntax()
        {
            TextTokenStr = DefaultValues.InterpolatedStringTextSyntaxTextTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken TextToken
        {
            get
            {
                if (_textTokenIsChanged)
                {
                    _textToken = SyntaxFactoryStr.ParseSyntaxToken(TextTokenStr);
                    _textTokenIsChanged = false;
                }
                return _textToken;
            }
            set
            {
                if (_textToken != value)
                {
                    _textToken = value;
                    _textTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TextTokenStr
        {
            get
            {
                if (_textTokenIsChanged) return _textTokenStr;
                return _textTokenStr = _textToken.Text;
            }
            set
            {
                if (_textTokenStr != value)
                {
                    _textTokenStr = value;
                    IsChanged = true;
                    _textTokenIsChanged = true;
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
            _textToken = ((InterpolatedStringTextSyntax) Node).TextToken;
            _textTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.InterpolatedStringText(TextToken);
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
            yield return ("TextTokenStr", TextTokenStr);
        }
    }
}