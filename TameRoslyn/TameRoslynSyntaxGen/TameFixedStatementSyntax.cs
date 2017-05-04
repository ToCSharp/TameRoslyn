// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameFixedStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "FixedStatementSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private VariableDeclarationSyntax _declaration;
        private bool _declarationIsChanged;
        private string _declarationStr;
        private SyntaxToken _fixedKeyword;
        private bool _fixedKeywordIsChanged;
        private string _fixedKeywordStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private StatementSyntax _statement;
        private bool _statementIsChanged;
        private string _statementStr;
        private TameVariableDeclarationSyntax _taDeclaration;
        private TameStatementSyntax _taStatement;

        public TameFixedStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseFixedStatement(code);
            AddChildren();
        }

        public TameFixedStatementSyntax(FixedStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameFixedStatementSyntax()
        {
            FixedKeywordStr = DefaultValues.FixedStatementSyntaxFixedKeywordStr;
            OpenParenTokenStr = DefaultValues.FixedStatementSyntaxOpenParenTokenStr;
            DeclarationStr = DefaultValues.FixedStatementSyntaxDeclarationStr;
            CloseParenTokenStr = DefaultValues.FixedStatementSyntaxCloseParenTokenStr;
            StatementStr = DefaultValues.FixedStatementSyntaxStatementStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken FixedKeyword
        {
            get
            {
                if (_fixedKeywordIsChanged)
                {
                    if (_fixedKeywordStr == null) _fixedKeyword = default(SyntaxToken);
                    else _fixedKeyword = SyntaxFactoryStr.ParseSyntaxToken(_fixedKeywordStr, SyntaxKind.FixedKeyword);
                    _fixedKeywordIsChanged = false;
                }
                return _fixedKeyword;
            }
            set
            {
                if (_fixedKeyword != value)
                {
                    _fixedKeyword = value;
                    _fixedKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FixedKeywordStr
        {
            get
            {
                if (_fixedKeywordIsChanged) return _fixedKeywordStr;
                return _fixedKeywordStr = _fixedKeyword.Text;
            }
            set
            {
                if (_fixedKeywordStr != value)
                {
                    _fixedKeywordStr = value;
                    IsChanged = true;
                    _fixedKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken OpenParenToken
        {
            get
            {
                if (_openParenTokenIsChanged)
                {
                    if (_openParenTokenStr == null) _openParenToken = default(SyntaxToken);
                    else
                        _openParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openParenTokenStr, SyntaxKind.OpenParenToken);
                    _openParenTokenIsChanged = false;
                }
                return _openParenToken;
            }
            set
            {
                if (_openParenToken != value)
                {
                    _openParenToken = value;
                    _openParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenParenTokenStr
        {
            get
            {
                if (_openParenTokenIsChanged) return _openParenTokenStr;
                return _openParenTokenStr = _openParenToken.Text;
            }
            set
            {
                if (_openParenTokenStr != value)
                {
                    _openParenTokenStr = value;
                    IsChanged = true;
                    _openParenTokenIsChanged = true;
                }
            }
        }

        public VariableDeclarationSyntax Declaration
        {
            get
            {
                if (_declarationIsChanged)
                {
                    _declaration = SyntaxFactoryStr.ParseVariableDeclarationSyntax(DeclarationStr);
                    _declarationIsChanged = false;
                    _taDeclaration = null;
                }
                else if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    _declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                }
                return _declaration;
            }
            set
            {
                if (_declaration != value)
                {
                    _declaration = value;
                    _declarationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DeclarationStr
        {
            get
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                if (_declarationIsChanged) return _declarationStr;
                return _declarationStr = _declaration?.ToFullString();
            }
            set
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                    _declarationStr = _declaration?.ToFullString();
                }
                if (_declarationStr != value)
                {
                    _declarationStr = value;
                    IsChanged = true;
                    _declarationIsChanged = true;
                    _taDeclaration = null;
                }
            }
        }

        public TameVariableDeclarationSyntax TaDeclaration
        {
            get
            {
                if (_taDeclaration == null && Declaration != null)
                {
                    _taDeclaration = new TameVariableDeclarationSyntax(Declaration) {TaParent = this};
                    _taDeclaration.AddChildren();
                }
                return _taDeclaration;
            }
            set
            {
                if (_taDeclaration != value)
                {
                    _taDeclaration = value;
                    if (_taDeclaration != null)
                    {
                        _taDeclaration.TaParent = this;
                        _taDeclaration.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken CloseParenToken
        {
            get
            {
                if (_closeParenTokenIsChanged)
                {
                    if (_closeParenTokenStr == null) _closeParenToken = default(SyntaxToken);
                    else
                        _closeParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeParenTokenStr, SyntaxKind.CloseParenToken);
                    _closeParenTokenIsChanged = false;
                }
                return _closeParenToken;
            }
            set
            {
                if (_closeParenToken != value)
                {
                    _closeParenToken = value;
                    _closeParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseParenTokenStr
        {
            get
            {
                if (_closeParenTokenIsChanged) return _closeParenTokenStr;
                return _closeParenTokenStr = _closeParenToken.Text;
            }
            set
            {
                if (_closeParenTokenStr != value)
                {
                    _closeParenTokenStr = value;
                    IsChanged = true;
                    _closeParenTokenIsChanged = true;
                }
            }
        }

        public StatementSyntax Statement
        {
            get
            {
                if (_statementIsChanged)
                {
                    _statement = SyntaxFactoryStr.ParseStatementSyntax(StatementStr);
                    _statementIsChanged = false;
                    _taStatement = null;
                }
                else if (_taStatement != null && _taStatement.IsChanged)
                {
                    _statement = (StatementSyntax) _taStatement.Node;
                }
                return _statement;
            }
            set
            {
                if (_statement != value)
                {
                    _statement = value;
                    _statementIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StatementStr
        {
            get
            {
                if (_taStatement != null && _taStatement.IsChanged)
                    Statement = (StatementSyntax) _taStatement.Node;
                if (_statementIsChanged) return _statementStr;
                return _statementStr = _statement?.ToFullString();
            }
            set
            {
                if (_taStatement != null && _taStatement.IsChanged)
                {
                    Statement = (StatementSyntax) _taStatement.Node;
                    _statementStr = _statement?.ToFullString();
                }
                if (_statementStr != value)
                {
                    _statementStr = value;
                    IsChanged = true;
                    _statementIsChanged = true;
                    _taStatement = null;
                }
            }
        }

        public TameStatementSyntax TaStatement
        {
            get
            {
                if (_taStatement == null && Statement != null)
                    if (Statement is ForEachVariableStatementSyntax)
                    {
                        var loc =
                            new TameForEachVariableStatementSyntax((ForEachVariableStatementSyntax) Statement)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ForEachStatementSyntax)
                    {
                        var loc = new TameForEachStatementSyntax((ForEachStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LocalDeclarationStatementSyntax)
                    {
                        var loc =
                            new TameLocalDeclarationStatementSyntax((LocalDeclarationStatementSyntax) Statement)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LocalFunctionStatementSyntax)
                    {
                        var loc =
                            new TameLocalFunctionStatementSyntax((LocalFunctionStatementSyntax) Statement)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ExpressionStatementSyntax)
                    {
                        var loc =
                            new TameExpressionStatementSyntax((ExpressionStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ContinueStatementSyntax)
                    {
                        var loc =
                            new TameContinueStatementSyntax((ContinueStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is CheckedStatementSyntax)
                    {
                        var loc = new TameCheckedStatementSyntax((CheckedStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LabeledStatementSyntax)
                    {
                        var loc = new TameLabeledStatementSyntax((LabeledStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ReturnStatementSyntax)
                    {
                        var loc = new TameReturnStatementSyntax((ReturnStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is SwitchStatementSyntax)
                    {
                        var loc = new TameSwitchStatementSyntax((SwitchStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is UnsafeStatementSyntax)
                    {
                        var loc = new TameUnsafeStatementSyntax((UnsafeStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is BreakStatementSyntax)
                    {
                        var loc = new TameBreakStatementSyntax((BreakStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is EmptyStatementSyntax)
                    {
                        var loc = new TameEmptyStatementSyntax((EmptyStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is FixedStatementSyntax)
                    {
                        var loc = new TameFixedStatementSyntax((FixedStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ThrowStatementSyntax)
                    {
                        var loc = new TameThrowStatementSyntax((ThrowStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is UsingStatementSyntax)
                    {
                        var loc = new TameUsingStatementSyntax((UsingStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is WhileStatementSyntax)
                    {
                        var loc = new TameWhileStatementSyntax((WhileStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is YieldStatementSyntax)
                    {
                        var loc = new TameYieldStatementSyntax((YieldStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is GotoStatementSyntax)
                    {
                        var loc = new TameGotoStatementSyntax((GotoStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LockStatementSyntax)
                    {
                        var loc = new TameLockStatementSyntax((LockStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ForStatementSyntax)
                    {
                        var loc = new TameForStatementSyntax((ForStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is TryStatementSyntax)
                    {
                        var loc = new TameTryStatementSyntax((TryStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is DoStatementSyntax)
                    {
                        var loc = new TameDoStatementSyntax((DoStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is IfStatementSyntax)
                    {
                        var loc = new TameIfStatementSyntax((IfStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is BlockSyntax)
                    {
                        var loc = new TameBlockSyntax((BlockSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                return _taStatement;
            }
            set
            {
                if (_taStatement != value)
                {
                    _taStatement = value;
                    if (_taStatement != null)
                    {
                        _taStatement.TaParent = this;
                        _taStatement.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taDeclaration = null;
            _taStatement = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _fixedKeyword = ((FixedStatementSyntax) Node).FixedKeyword;
            _fixedKeywordIsChanged = false;
            _openParenToken = ((FixedStatementSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _declaration = ((FixedStatementSyntax) Node).Declaration;
            _declarationIsChanged = false;
            _closeParenToken = ((FixedStatementSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
            _statement = ((FixedStatementSyntax) Node).Statement;
            _statementIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.FixedStatement(FixedKeyword, OpenParenToken, Declaration, CloseParenToken,
                Statement);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaDeclaration != null) yield return TaDeclaration;
            if (TaStatement != null) yield return TaStatement;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("FixedKeywordStr", FixedKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("StatementStr", StatementStr);
        }
    }
}