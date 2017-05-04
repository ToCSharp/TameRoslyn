// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameSwitchSectionSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "SwitchSectionSyntax";
        private SyntaxList<SwitchLabelSyntax> _labels;
        private int _labelsCount;
        private bool _labelsIsChanged;
        private string _labelsStr;
        private SyntaxList<StatementSyntax> _statements;
        private int _statementsCount;
        private bool _statementsIsChanged;
        private string _statementsStr;
        private List<TameSwitchLabelSyntax> _taLabels;
        private List<TameStatementSyntax> _taStatements;

        public TameSwitchSectionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSwitchSection(code);
            AddChildren();
        }

        public TameSwitchSectionSyntax(SwitchSectionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSwitchSectionSyntax()
        {
            LabelsStr = DefaultValues.SwitchSectionSyntaxLabelsStr;
            StatementsStr = DefaultValues.SwitchSectionSyntaxStatementsStr;
        }

        public override string RoslynTypeName => TypeName;
        public bool TaLabelsIsChanged { get; set; }

        public SyntaxList<SwitchLabelSyntax> Labels
        {
            get
            {
                if (TaLabelsIsChanged || _taLabels != null &&
                    (_taLabels.Count != _labelsCount || _taLabels.Any(v => v.IsChanged)))
                {
                    _labels = SyntaxFactory.List(TaLabels?.Select(v => v.Node).Cast<SwitchLabelSyntax>());
                    TaLabelsIsChanged = false;
                }
                return _labels;
            }
            set
            {
                if (_labels != value)
                {
                    _labels = value;
                    TaLabelsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LabelsStr
        {
            get
            {
                if (_labelsIsChanged) return _labelsStr;
                return _labelsStr = string.Join(", ", _labels.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _labelsStr = value;
                    Labels = new SyntaxList<SwitchLabelSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameSwitchLabelSyntax> TaLabels
        {
            get
            {
                if (_taLabels == null)
                {
                    _taLabels = new List<TameSwitchLabelSyntax>();
                    foreach (var item in _labels)
                        if (item is CasePatternSwitchLabelSyntax)
                            _taLabels.Add(
                                new TameCasePatternSwitchLabelSyntax(item as CasePatternSwitchLabelSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DefaultSwitchLabelSyntax)
                            _taLabels.Add(
                                new TameDefaultSwitchLabelSyntax(item as DefaultSwitchLabelSyntax) {TaParent = this});
                        else if (item is CaseSwitchLabelSyntax)
                            _taLabels.Add(
                                new TameCaseSwitchLabelSyntax(item as CaseSwitchLabelSyntax) {TaParent = this});
                        else if (item is SwitchLabelSyntax)
                            _taLabels.Add(new TameSwitchLabelSyntax(item) {TaParent = this});
                }
                return _taLabels;
            }
            set
            {
                if (_taLabels != value)
                {
                    _taLabels = value;
                    _taLabels?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaLabelsIsChanged = true;
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

        public override void Clear()
        {
            _taLabels = null;
            _taStatements = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _labels = ((SwitchSectionSyntax) Node).Labels;
            _labelsIsChanged = false;
            _labelsCount = _labels.Count;
            _statements = ((SwitchSectionSyntax) Node).Statements;
            _statementsIsChanged = false;
            _statementsCount = _statements.Count;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaLabels)
                item.SetNotChanged();
            foreach (var item in TaStatements)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.SwitchSection(Labels, Statements);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaLabels)
                yield return item;
            foreach (var item in TaStatements)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("LabelsStr", LabelsStr);
            yield return ("StatementsStr", StatementsStr);
        }

        public TameSwitchSectionSyntax AddLabel(TameSwitchLabelSyntax item)
        {
            item.TaParent = this;
            TaLabels.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameSwitchSectionSyntax AddStatement(TameStatementSyntax item)
        {
            item.TaParent = this;
            TaStatements.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}