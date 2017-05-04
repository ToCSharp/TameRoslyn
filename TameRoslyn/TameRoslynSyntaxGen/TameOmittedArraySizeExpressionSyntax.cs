// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameOmittedArraySizeExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "OmittedArraySizeExpressionSyntax";
        private SyntaxToken _omittedArraySizeExpressionToken;
        private bool _omittedArraySizeExpressionTokenIsChanged;
        private string _omittedArraySizeExpressionTokenStr;

        public TameOmittedArraySizeExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseOmittedArraySizeExpression(code);
            AddChildren();
        }

        public TameOmittedArraySizeExpressionSyntax(OmittedArraySizeExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameOmittedArraySizeExpressionSyntax()
        {
            OmittedArraySizeExpressionTokenStr = DefaultValues
                .OmittedArraySizeExpressionSyntaxOmittedArraySizeExpressionTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OmittedArraySizeExpressionToken
        {
            get
            {
                if (_omittedArraySizeExpressionTokenIsChanged)
                {
                    if (_omittedArraySizeExpressionTokenStr == null)
                        _omittedArraySizeExpressionToken = default(SyntaxToken);
                    else
                        _omittedArraySizeExpressionToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_omittedArraySizeExpressionTokenStr,
                                SyntaxKind.OmittedArraySizeExpressionToken);
                    _omittedArraySizeExpressionTokenIsChanged = false;
                }
                return _omittedArraySizeExpressionToken;
            }
            set
            {
                if (_omittedArraySizeExpressionToken != value)
                {
                    _omittedArraySizeExpressionToken = value;
                    _omittedArraySizeExpressionTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OmittedArraySizeExpressionTokenStr
        {
            get
            {
                if (_omittedArraySizeExpressionTokenIsChanged) return _omittedArraySizeExpressionTokenStr;
                return _omittedArraySizeExpressionTokenStr = _omittedArraySizeExpressionToken.Text;
            }
            set
            {
                if (_omittedArraySizeExpressionTokenStr != value)
                {
                    _omittedArraySizeExpressionTokenStr = value;
                    IsChanged = true;
                    _omittedArraySizeExpressionTokenIsChanged = true;
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
            _omittedArraySizeExpressionToken = ((OmittedArraySizeExpressionSyntax) Node)
                .OmittedArraySizeExpressionToken;
            _omittedArraySizeExpressionTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.OmittedArraySizeExpression(OmittedArraySizeExpressionToken);
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
            yield return ("OmittedArraySizeExpressionTokenStr", OmittedArraySizeExpressionTokenStr);
        }
    }
}