// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBreakStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "BreakStatementSyntax";
        private SyntaxToken _breakKeyword;
        private bool _breakKeywordIsChanged;
        private string _breakKeywordStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;

        public TameBreakStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBreakStatement(code);
            AddChildren();
        }

        public TameBreakStatementSyntax(BreakStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBreakStatementSyntax()
        {
            BreakKeywordStr = DefaultValues.BreakStatementSyntaxBreakKeywordStr;
            SemicolonTokenStr = DefaultValues.BreakStatementSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken BreakKeyword
        {
            get
            {
                if (_breakKeywordIsChanged)
                {
                    if (_breakKeywordStr == null) _breakKeyword = default(SyntaxToken);
                    else _breakKeyword = SyntaxFactoryStr.ParseSyntaxToken(_breakKeywordStr, SyntaxKind.BreakKeyword);
                    _breakKeywordIsChanged = false;
                }
                return _breakKeyword;
            }
            set
            {
                if (_breakKeyword != value)
                {
                    _breakKeyword = value;
                    _breakKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string BreakKeywordStr
        {
            get
            {
                if (_breakKeywordIsChanged) return _breakKeywordStr;
                return _breakKeywordStr = _breakKeyword.Text;
            }
            set
            {
                if (_breakKeywordStr != value)
                {
                    _breakKeywordStr = value;
                    IsChanged = true;
                    _breakKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken SemicolonToken
        {
            get
            {
                if (_semicolonTokenIsChanged)
                {
                    if (_semicolonTokenStr == null) _semicolonToken = default(SyntaxToken);
                    else
                        _semicolonToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_semicolonTokenStr, SyntaxKind.SemicolonToken);
                    _semicolonTokenIsChanged = false;
                }
                return _semicolonToken;
            }
            set
            {
                if (_semicolonToken != value)
                {
                    _semicolonToken = value;
                    _semicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonTokenStr
        {
            get
            {
                if (_semicolonTokenIsChanged) return _semicolonTokenStr;
                return _semicolonTokenStr = _semicolonToken.Text;
            }
            set
            {
                if (_semicolonTokenStr != value)
                {
                    _semicolonTokenStr = value;
                    IsChanged = true;
                    _semicolonTokenIsChanged = true;
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
            _breakKeyword = ((BreakStatementSyntax) Node).BreakKeyword;
            _breakKeywordIsChanged = false;
            _semicolonToken = ((BreakStatementSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.BreakStatement(BreakKeyword, SemicolonToken);
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
            yield return ("BreakKeywordStr", BreakKeywordStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}