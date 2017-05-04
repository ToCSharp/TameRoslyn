// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameInterpolationFormatClauseSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "InterpolationFormatClauseSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private SyntaxToken _formatStringToken;
        private bool _formatStringTokenIsChanged;
        private string _formatStringTokenStr;

        public TameInterpolationFormatClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseInterpolationFormatClause(code);
            AddChildren();
        }

        public TameInterpolationFormatClauseSyntax(InterpolationFormatClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameInterpolationFormatClauseSyntax()
        {
            ColonTokenStr = DefaultValues.InterpolationFormatClauseSyntaxColonTokenStr;
            FormatStringTokenStr = DefaultValues.InterpolationFormatClauseSyntaxFormatStringTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ColonToken
        {
            get
            {
                if (_colonTokenIsChanged)
                {
                    if (_colonTokenStr == null) _colonToken = default(SyntaxToken);
                    else _colonToken = SyntaxFactoryStr.ParseSyntaxToken(_colonTokenStr, SyntaxKind.ColonToken);
                    _colonTokenIsChanged = false;
                }
                return _colonToken;
            }
            set
            {
                if (_colonToken != value)
                {
                    _colonToken = value;
                    _colonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ColonTokenStr
        {
            get
            {
                if (_colonTokenIsChanged) return _colonTokenStr;
                return _colonTokenStr = _colonToken.Text;
            }
            set
            {
                if (_colonTokenStr != value)
                {
                    _colonTokenStr = value;
                    IsChanged = true;
                    _colonTokenIsChanged = true;
                }
            }
        }

        public SyntaxToken FormatStringToken
        {
            get
            {
                if (_formatStringTokenIsChanged)
                {
                    _formatStringToken = SyntaxFactoryStr.ParseSyntaxToken(FormatStringTokenStr);
                    _formatStringTokenIsChanged = false;
                }
                return _formatStringToken;
            }
            set
            {
                if (_formatStringToken != value)
                {
                    _formatStringToken = value;
                    _formatStringTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FormatStringTokenStr
        {
            get
            {
                if (_formatStringTokenIsChanged) return _formatStringTokenStr;
                return _formatStringTokenStr = _formatStringToken.Text;
            }
            set
            {
                if (_formatStringTokenStr != value)
                {
                    _formatStringTokenStr = value;
                    IsChanged = true;
                    _formatStringTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _colonToken = ((InterpolationFormatClauseSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
            _formatStringToken = ((InterpolationFormatClauseSyntax) Node).FormatStringToken;
            _formatStringTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.InterpolationFormatClause(ColonToken, FormatStringToken);
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
            yield return ("ColonTokenStr", ColonTokenStr);
            yield return ("FormatStringTokenStr", FormatStringTokenStr);
        }
    }
}