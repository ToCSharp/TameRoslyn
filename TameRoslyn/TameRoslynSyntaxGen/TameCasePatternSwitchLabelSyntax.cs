// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCasePatternSwitchLabelSyntax : TameSwitchLabelSyntax
    {
        public new static string TypeName = "CasePatternSwitchLabelSyntax";
        private PatternSyntax _pattern;
        private bool _patternIsChanged;
        private string _patternStr;
        private TamePatternSyntax _taPattern;
        private TameWhenClauseSyntax _taWhenClause;
        private WhenClauseSyntax _whenClause;
        private bool _whenClauseIsChanged;
        private string _whenClauseStr;

        public TameCasePatternSwitchLabelSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCasePatternSwitchLabel(code);
            AddChildren();
        }

        public TameCasePatternSwitchLabelSyntax(CasePatternSwitchLabelSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCasePatternSwitchLabelSyntax()
        {
            PatternStr = DefaultValues.CasePatternSwitchLabelSyntaxPatternStr;
            WhenClauseStr = DefaultValues.CasePatternSwitchLabelSyntaxWhenClauseStr;
            KeywordStr = DefaultValues.CasePatternSwitchLabelSyntaxKeywordStr;
            ColonTokenStr = DefaultValues.CasePatternSwitchLabelSyntaxColonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public PatternSyntax Pattern
        {
            get
            {
                if (_patternIsChanged)
                {
                    _pattern = SyntaxFactoryStr.ParsePatternSyntax(PatternStr);
                    _patternIsChanged = false;
                    _taPattern = null;
                }
                else if (_taPattern != null && _taPattern.IsChanged)
                {
                    _pattern = (PatternSyntax) _taPattern.Node;
                }
                return _pattern;
            }
            set
            {
                if (_pattern != value)
                {
                    _pattern = value;
                    _patternIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string PatternStr
        {
            get
            {
                if (_taPattern != null && _taPattern.IsChanged)
                    Pattern = (PatternSyntax) _taPattern.Node;
                if (_patternIsChanged) return _patternStr;
                return _patternStr = _pattern?.ToFullString();
            }
            set
            {
                if (_taPattern != null && _taPattern.IsChanged)
                {
                    Pattern = (PatternSyntax) _taPattern.Node;
                    _patternStr = _pattern?.ToFullString();
                }
                if (_patternStr != value)
                {
                    _patternStr = value;
                    IsChanged = true;
                    _patternIsChanged = true;
                    _taPattern = null;
                }
            }
        }

        public TamePatternSyntax TaPattern
        {
            get
            {
                if (_taPattern == null && Pattern != null)
                    if (Pattern is DeclarationPatternSyntax)
                    {
                        var loc =
                            new TameDeclarationPatternSyntax((DeclarationPatternSyntax) Pattern) {TaParent = this};
                        loc.AddChildren();
                        _taPattern = loc;
                    }
                    else if (Pattern is ConstantPatternSyntax)
                    {
                        var loc = new TameConstantPatternSyntax((ConstantPatternSyntax) Pattern) {TaParent = this};
                        loc.AddChildren();
                        _taPattern = loc;
                    }
                return _taPattern;
            }
            set
            {
                if (_taPattern != value)
                {
                    _taPattern = value;
                    if (_taPattern != null)
                    {
                        _taPattern.TaParent = this;
                        _taPattern.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public WhenClauseSyntax WhenClause
        {
            get
            {
                if (_whenClauseIsChanged)
                {
                    _whenClause = SyntaxFactoryStr.ParseWhenClauseSyntax(WhenClauseStr);
                    _whenClauseIsChanged = false;
                    _taWhenClause = null;
                }
                else if (_taWhenClause != null && _taWhenClause.IsChanged)
                {
                    _whenClause = (WhenClauseSyntax) _taWhenClause.Node;
                }
                return _whenClause;
            }
            set
            {
                if (_whenClause != value)
                {
                    _whenClause = value;
                    _whenClauseIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhenClauseStr
        {
            get
            {
                if (_taWhenClause != null && _taWhenClause.IsChanged)
                    WhenClause = (WhenClauseSyntax) _taWhenClause.Node;
                if (_whenClauseIsChanged) return _whenClauseStr;
                return _whenClauseStr = _whenClause?.ToFullString();
            }
            set
            {
                if (_taWhenClause != null && _taWhenClause.IsChanged)
                {
                    WhenClause = (WhenClauseSyntax) _taWhenClause.Node;
                    _whenClauseStr = _whenClause?.ToFullString();
                }
                if (_whenClauseStr != value)
                {
                    _whenClauseStr = value;
                    IsChanged = true;
                    _whenClauseIsChanged = true;
                    _taWhenClause = null;
                }
            }
        }

        public TameWhenClauseSyntax TaWhenClause
        {
            get
            {
                if (_taWhenClause == null && WhenClause != null)
                {
                    _taWhenClause = new TameWhenClauseSyntax(WhenClause) {TaParent = this};
                    _taWhenClause.AddChildren();
                }
                return _taWhenClause;
            }
            set
            {
                if (_taWhenClause != value)
                {
                    _taWhenClause = value;
                    if (_taWhenClause != null)
                    {
                        _taWhenClause.TaParent = this;
                        _taWhenClause.IsChanged = true;
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
            _taPattern = null;
            _taWhenClause = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _pattern = ((CasePatternSwitchLabelSyntax) Node).Pattern;
            _patternIsChanged = false;
            _whenClause = ((CasePatternSwitchLabelSyntax) Node).WhenClause;
            _whenClauseIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CasePatternSwitchLabel(Keyword, Pattern, WhenClause, ColonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaPattern != null) yield return TaPattern;
            if (TaWhenClause != null) yield return TaWhenClause;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("PatternStr", PatternStr);
            yield return ("WhenClauseStr", WhenClauseStr);
            yield return ("KeywordStr", KeywordStr);
            yield return ("ColonTokenStr", ColonTokenStr);
        }
    }
}