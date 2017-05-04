// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBlockSyntax : TameStatementSyntax
    {
        public new static string TypeName = "BlockSyntax";
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private SyntaxList<StatementSyntax> _statements;
        private int _statementsCount;
        private bool _statementsIsChanged;
        private string _statementsStr;
        private List<TameStatementSyntax> _taStatements;

        public TameBlockSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBlock(code);
            AddChildren();
        }

        public TameBlockSyntax(BlockSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBlockSyntax()
        {
            OpenBraceTokenStr = DefaultValues.BlockSyntaxOpenBraceTokenStr;
            StatementsStr = DefaultValues.BlockSyntaxStatementsStr;
            CloseBraceTokenStr = DefaultValues.BlockSyntaxCloseBraceTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenBraceToken
        {
            get
            {
                if (_openBraceTokenIsChanged)
                {
                    if (_openBraceTokenStr == null) _openBraceToken = default(SyntaxToken);
                    else
                        _openBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBraceTokenStr, SyntaxKind.OpenBraceToken);
                    _openBraceTokenIsChanged = false;
                }
                return _openBraceToken;
            }
            set
            {
                if (_openBraceToken != value)
                {
                    _openBraceToken = value;
                    _openBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBraceTokenStr
        {
            get
            {
                if (_openBraceTokenIsChanged) return _openBraceTokenStr;
                return _openBraceTokenStr = _openBraceToken.Text;
            }
            set
            {
                if (_openBraceTokenStr != value)
                {
                    _openBraceTokenStr = value;
                    IsChanged = true;
                    _openBraceTokenIsChanged = true;
                }
            }
        }

        public bool TaStatementsIsChanged { get; set; }

        public SyntaxList<StatementSyntax> Statements
        {
            get
            {
                if (TaStatementsIsChanged || _taStatements != null &&
                    (_taStatements.Count != _statementsCount || _taStatements.Any(v => v.IsChanged)))
                {
                    _statements = SyntaxFactory.List(TaStatements?.Select(v => v.Node).Cast<StatementSyntax>());
                    TaStatementsIsChanged = false;
                }
                return _statements;
            }
            set
            {
                if (_statements != value)
                {
                    _statements = value;
                    TaStatementsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StatementsStr
        {
            get
            {
                if (_statementsIsChanged) return _statementsStr;
                return _statementsStr = string.Join(", ", _statements.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _statementsStr = value;
                    Statements = new SyntaxList<StatementSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameStatementSyntax> TaStatements
        {
            get
            {
                if (_taStatements == null)
                {
                    _taStatements = new List<TameStatementSyntax>();
                    foreach (var item in _statements)
                        if (item is ForEachVariableStatementSyntax)
                            _taStatements.Add(
                                new TameForEachVariableStatementSyntax(item as ForEachVariableStatementSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ForEachStatementSyntax)
                            _taStatements.Add(
                                new TameForEachStatementSyntax(item as ForEachStatementSyntax) {TaParent = this});
                        else if (item is LocalDeclarationStatementSyntax)
                            _taStatements.Add(
                                new TameLocalDeclarationStatementSyntax(item as LocalDeclarationStatementSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is LocalFunctionStatementSyntax)
                            _taStatements.Add(
                                new TameLocalFunctionStatementSyntax(item as LocalFunctionStatementSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ExpressionStatementSyntax)
                            _taStatements.Add(
                                new TameExpressionStatementSyntax(item as ExpressionStatementSyntax) {TaParent = this});
                        else if (item is ContinueStatementSyntax)
                            _taStatements.Add(
                                new TameContinueStatementSyntax(item as ContinueStatementSyntax) {TaParent = this});
                        else if (item is CheckedStatementSyntax)
                            _taStatements.Add(
                                new TameCheckedStatementSyntax(item as CheckedStatementSyntax) {TaParent = this});
                        else if (item is LabeledStatementSyntax)
                            _taStatements.Add(
                                new TameLabeledStatementSyntax(item as LabeledStatementSyntax) {TaParent = this});
                        else if (item is ReturnStatementSyntax)
                            _taStatements.Add(
                                new TameReturnStatementSyntax(item as ReturnStatementSyntax) {TaParent = this});
                        else if (item is SwitchStatementSyntax)
                            _taStatements.Add(
                                new TameSwitchStatementSyntax(item as SwitchStatementSyntax) {TaParent = this});
                        else if (item is UnsafeStatementSyntax)
                            _taStatements.Add(
                                new TameUnsafeStatementSyntax(item as UnsafeStatementSyntax) {TaParent = this});
                        else if (item is BreakStatementSyntax)
                            _taStatements.Add(
                                new TameBreakStatementSyntax(item as BreakStatementSyntax) {TaParent = this});
                        else if (item is EmptyStatementSyntax)
                            _taStatements.Add(
                                new TameEmptyStatementSyntax(item as EmptyStatementSyntax) {TaParent = this});
                        else if (item is FixedStatementSyntax)
                            _taStatements.Add(
                                new TameFixedStatementSyntax(item as FixedStatementSyntax) {TaParent = this});
                        else if (item is ThrowStatementSyntax)
                            _taStatements.Add(
                                new TameThrowStatementSyntax(item as ThrowStatementSyntax) {TaParent = this});
                        else if (item is UsingStatementSyntax)
                            _taStatements.Add(
                                new TameUsingStatementSyntax(item as UsingStatementSyntax) {TaParent = this});
                        else if (item is WhileStatementSyntax)
                            _taStatements.Add(
                                new TameWhileStatementSyntax(item as WhileStatementSyntax) {TaParent = this});
                        else if (item is YieldStatementSyntax)
                            _taStatements.Add(
                                new TameYieldStatementSyntax(item as YieldStatementSyntax) {TaParent = this});
                        else if (item is GotoStatementSyntax)
                            _taStatements.Add(
                                new TameGotoStatementSyntax(item as GotoStatementSyntax) {TaParent = this});
                        else if (item is LockStatementSyntax)
                            _taStatements.Add(
                                new TameLockStatementSyntax(item as LockStatementSyntax) {TaParent = this});
                        else if (item is ForStatementSyntax)
                            _taStatements.Add(new TameForStatementSyntax(item as ForStatementSyntax) {TaParent = this});
                        else if (item is TryStatementSyntax)
                            _taStatements.Add(new TameTryStatementSyntax(item as TryStatementSyntax) {TaParent = this});
                        else if (item is DoStatementSyntax)
                            _taStatements.Add(new TameDoStatementSyntax(item as DoStatementSyntax) {TaParent = this});
                        else if (item is IfStatementSyntax)
                            _taStatements.Add(new TameIfStatementSyntax(item as IfStatementSyntax) {TaParent = this});
                        else if (item is BlockSyntax)
                            _taStatements.Add(new TameBlockSyntax(item as BlockSyntax) {TaParent = this});
                        else if (item is StatementSyntax)
                            _taStatements.Add(new TameStatementSyntax(item) {TaParent = this});
                }
                return _taStatements;
            }
            set
            {
                if (_taStatements != value)
                {
                    _taStatements = value;
                    _taStatements?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaStatementsIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                if (_closeBraceTokenIsChanged)
                {
                    if (_closeBraceTokenStr == null) _closeBraceToken = default(SyntaxToken);
                    else
                        _closeBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBraceTokenStr, SyntaxKind.CloseBraceToken);
                    _closeBraceTokenIsChanged = false;
                }
                return _closeBraceToken;
            }
            set
            {
                if (_closeBraceToken != value)
                {
                    _closeBraceToken = value;
                    _closeBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBraceTokenStr
        {
            get
            {
                if (_closeBraceTokenIsChanged) return _closeBraceTokenStr;
                return _closeBraceTokenStr = _closeBraceToken.Text;
            }
            set
            {
                if (_closeBraceTokenStr != value)
                {
                    _closeBraceTokenStr = value;
                    IsChanged = true;
                    _closeBraceTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taStatements = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _openBraceToken = ((BlockSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _statements = ((BlockSyntax) Node).Statements;
            _statementsIsChanged = false;
            _statementsCount = _statements.Count;
            _closeBraceToken = ((BlockSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaStatements)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.Block(OpenBraceToken, Statements, CloseBraceToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaStatements)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("StatementsStr", StatementsStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
        }

        public TameBlockSyntax AddStatement(TameStatementSyntax item)
        {
            item.TaParent = this;
            TaStatements.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}