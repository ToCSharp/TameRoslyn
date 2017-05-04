// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameParenthesizedVariableDesignationSyntax : TameVariableDesignationSyntax
    {
        public new static string TypeName = "ParenthesizedVariableDesignationSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private List<TameVariableDesignationSyntax> _taVariables;
        private SeparatedSyntaxList<VariableDesignationSyntax> _variables;
        private int _variablesCount;
        private bool _variablesIsChanged;
        private string _variablesStr;

        public TameParenthesizedVariableDesignationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseParenthesizedVariableDesignation(code);
            AddChildren();
        }

        public TameParenthesizedVariableDesignationSyntax(ParenthesizedVariableDesignationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameParenthesizedVariableDesignationSyntax()
        {
            OpenParenTokenStr = DefaultValues.ParenthesizedVariableDesignationSyntaxOpenParenTokenStr;
            VariablesStr = DefaultValues.ParenthesizedVariableDesignationSyntaxVariablesStr;
            CloseParenTokenStr = DefaultValues.ParenthesizedVariableDesignationSyntaxCloseParenTokenStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public bool TaVariablesIsChanged { get; set; }

        public SeparatedSyntaxList<VariableDesignationSyntax> Variables
        {
            get
            {
                if (TaVariablesIsChanged || _taVariables != null &&
                    (_taVariables.Count != _variablesCount || _taVariables.Any(v => v.IsChanged)))
                {
                    _variables = SyntaxFactory.SeparatedList(TaVariables?.Select(v => v.Node)
                        .Cast<VariableDesignationSyntax>());
                    TaVariablesIsChanged = false;
                }
                return _variables;
            }
            set
            {
                if (_variables != value)
                {
                    _variables = value;
                    TaVariablesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string VariablesStr
        {
            get
            {
                if (_variablesIsChanged) return _variablesStr;
                return _variablesStr = string.Join(", ", _variables.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _variablesStr = value;
                    Variables = new SeparatedSyntaxList<VariableDesignationSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameVariableDesignationSyntax> TaVariables
        {
            get
            {
                if (_taVariables == null)
                {
                    _taVariables = new List<TameVariableDesignationSyntax>();
                    foreach (var item in _variables)
                        if (item is ParenthesizedVariableDesignationSyntax)
                            _taVariables.Add(
                                new TameParenthesizedVariableDesignationSyntax(
                                    item as ParenthesizedVariableDesignationSyntax) {TaParent = this});
                        else if (item is SingleVariableDesignationSyntax)
                            _taVariables.Add(
                                new TameSingleVariableDesignationSyntax(item as SingleVariableDesignationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DiscardDesignationSyntax)
                            _taVariables.Add(
                                new TameDiscardDesignationSyntax(item as DiscardDesignationSyntax) {TaParent = this});
                        else if (item is VariableDesignationSyntax)
                            _taVariables.Add(new TameVariableDesignationSyntax(item) {TaParent = this});
                }
                return _taVariables;
            }
            set
            {
                if (_taVariables != value)
                {
                    _taVariables = value;
                    _taVariables?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaVariablesIsChanged = true;
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

        public override void Clear()
        {
            base.Clear();
            _taVariables = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _openParenToken = ((ParenthesizedVariableDesignationSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _variables = ((ParenthesizedVariableDesignationSyntax) Node).Variables;
            _variablesIsChanged = false;
            _variablesCount = _variables.Count;
            _closeParenToken = ((ParenthesizedVariableDesignationSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaVariables)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ParenthesizedVariableDesignation(OpenParenToken, Variables, CloseParenToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaVariables)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("VariablesStr", VariablesStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
        }

        public TameParenthesizedVariableDesignationSyntax AddVariable(TameVariableDesignationSyntax item)
        {
            item.TaParent = this;
            TaVariables.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}