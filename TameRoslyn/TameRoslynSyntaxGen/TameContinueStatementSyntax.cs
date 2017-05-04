// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameContinueStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "ContinueStatementSyntax";
        private SyntaxToken _continueKeyword;
        private bool _continueKeywordIsChanged;
        private string _continueKeywordStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;

        public TameContinueStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseContinueStatement(code);
            AddChildren();
        }

        public TameContinueStatementSyntax(ContinueStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameContinueStatementSyntax()
        {
            ContinueKeywordStr = DefaultValues.ContinueStatementSyntaxContinueKeywordStr;
            SemicolonTokenStr = DefaultValues.ContinueStatementSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ContinueKeyword
        {
            get
            {
                if (_continueKeywordIsChanged)
                {
                    if (_continueKeywordStr == null) _continueKeyword = default(SyntaxToken);
                    else
                        _continueKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_continueKeywordStr, SyntaxKind.ContinueKeyword);
                    _continueKeywordIsChanged = false;
                }
                return _continueKeyword;
            }
            set
            {
                if (_continueKeyword != value)
                {
                    _continueKeyword = value;
                    _continueKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ContinueKeywordStr
        {
            get
            {
                if (_continueKeywordIsChanged) return _continueKeywordStr;
                return _continueKeywordStr = _continueKeyword.Text;
            }
            set
            {
                if (_continueKeywordStr != value)
                {
                    _continueKeywordStr = value;
                    IsChanged = true;
                    _continueKeywordIsChanged = true;
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
            _continueKeyword = ((ContinueStatementSyntax) Node).ContinueKeyword;
            _continueKeywordIsChanged = false;
            _semicolonToken = ((ContinueStatementSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ContinueStatement(ContinueKeyword, SemicolonToken);
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
            yield return ("ContinueKeywordStr", ContinueKeywordStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}