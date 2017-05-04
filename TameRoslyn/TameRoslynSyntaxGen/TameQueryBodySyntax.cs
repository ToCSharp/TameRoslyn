// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameQueryBodySyntax : TameBaseRoslynNode
    {
        public static string TypeName = "QueryBodySyntax";
        private SyntaxList<QueryClauseSyntax> _clauses;
        private int _clausesCount;
        private bool _clausesIsChanged;
        private string _clausesStr;
        private QueryContinuationSyntax _continuation;
        private bool _continuationIsChanged;
        private string _continuationStr;
        private SelectOrGroupClauseSyntax _selectOrGroup;
        private bool _selectOrGroupIsChanged;
        private string _selectOrGroupStr;
        private List<TameQueryClauseSyntax> _taClauses;
        private TameQueryContinuationSyntax _taContinuation;
        private TameSelectOrGroupClauseSyntax _taSelectOrGroup;

        public TameQueryBodySyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseQueryBody(code);
            AddChildren();
        }

        public TameQueryBodySyntax(QueryBodySyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameQueryBodySyntax()
        {
            ClausesStr = DefaultValues.QueryBodySyntaxClausesStr;
            SelectOrGroupStr = DefaultValues.QueryBodySyntaxSelectOrGroupStr;
            ContinuationStr = DefaultValues.QueryBodySyntaxContinuationStr;
        }

        public override string RoslynTypeName => TypeName;
        public bool TaClausesIsChanged { get; set; }

        public SyntaxList<QueryClauseSyntax> Clauses
        {
            get
            {
                if (TaClausesIsChanged || _taClauses != null &&
                    (_taClauses.Count != _clausesCount || _taClauses.Any(v => v.IsChanged)))
                {
                    _clauses = SyntaxFactory.List(TaClauses?.Select(v => v.Node).Cast<QueryClauseSyntax>());
                    TaClausesIsChanged = false;
                }
                return _clauses;
            }
            set
            {
                if (_clauses != value)
                {
                    _clauses = value;
                    TaClausesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ClausesStr
        {
            get
            {
                if (_clausesIsChanged) return _clausesStr;
                return _clausesStr = string.Join(", ", _clauses.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _clausesStr = value;
                    Clauses = new SyntaxList<QueryClauseSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameQueryClauseSyntax> TaClauses
        {
            get
            {
                if (_taClauses == null)
                {
                    _taClauses = new List<TameQueryClauseSyntax>();
                    foreach (var item in _clauses)
                        if (item is OrderByClauseSyntax)
                            _taClauses.Add(new TameOrderByClauseSyntax(item as OrderByClauseSyntax) {TaParent = this});
                        else if (item is WhereClauseSyntax)
                            _taClauses.Add(new TameWhereClauseSyntax(item as WhereClauseSyntax) {TaParent = this});
                        else if (item is FromClauseSyntax)
                            _taClauses.Add(new TameFromClauseSyntax(item as FromClauseSyntax) {TaParent = this});
                        else if (item is JoinClauseSyntax)
                            _taClauses.Add(new TameJoinClauseSyntax(item as JoinClauseSyntax) {TaParent = this});
                        else if (item is LetClauseSyntax)
                            _taClauses.Add(new TameLetClauseSyntax(item as LetClauseSyntax) {TaParent = this});
                        else if (item is QueryClauseSyntax)
                            _taClauses.Add(new TameQueryClauseSyntax(item) {TaParent = this});
                }
                return _taClauses;
            }
            set
            {
                if (_taClauses != value)
                {
                    _taClauses = value;
                    _taClauses?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaClausesIsChanged = true;
                }
            }
        }

        public SelectOrGroupClauseSyntax SelectOrGroup
        {
            get
            {
                if (_selectOrGroupIsChanged)
                {
                    _selectOrGroup = SyntaxFactoryStr.ParseSelectOrGroupClauseSyntax(SelectOrGroupStr);
                    _selectOrGroupIsChanged = false;
                    _taSelectOrGroup = null;
                }
                else if (_taSelectOrGroup != null && _taSelectOrGroup.IsChanged)
                {
                    _selectOrGroup = (SelectOrGroupClauseSyntax) _taSelectOrGroup.Node;
                }
                return _selectOrGroup;
            }
            set
            {
                if (_selectOrGroup != value)
                {
                    _selectOrGroup = value;
                    _selectOrGroupIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SelectOrGroupStr
        {
            get
            {
                if (_taSelectOrGroup != null && _taSelectOrGroup.IsChanged)
                    SelectOrGroup = (SelectOrGroupClauseSyntax) _taSelectOrGroup.Node;
                if (_selectOrGroupIsChanged) return _selectOrGroupStr;
                return _selectOrGroupStr = _selectOrGroup?.ToFullString();
            }
            set
            {
                if (_taSelectOrGroup != null && _taSelectOrGroup.IsChanged)
                {
                    SelectOrGroup = (SelectOrGroupClauseSyntax) _taSelectOrGroup.Node;
                    _selectOrGroupStr = _selectOrGroup?.ToFullString();
                }
                if (_selectOrGroupStr != value)
                {
                    _selectOrGroupStr = value;
                    IsChanged = true;
                    _selectOrGroupIsChanged = true;
                    _taSelectOrGroup = null;
                }
            }
        }

        public TameSelectOrGroupClauseSyntax TaSelectOrGroup
        {
            get
            {
                if (_taSelectOrGroup == null && SelectOrGroup != null)
                    if (SelectOrGroup is SelectClauseSyntax)
                    {
                        var loc = new TameSelectClauseSyntax((SelectClauseSyntax) SelectOrGroup) {TaParent = this};
                        loc.AddChildren();
                        _taSelectOrGroup = loc;
                    }
                    else if (SelectOrGroup is GroupClauseSyntax)
                    {
                        var loc = new TameGroupClauseSyntax((GroupClauseSyntax) SelectOrGroup) {TaParent = this};
                        loc.AddChildren();
                        _taSelectOrGroup = loc;
                    }
                return _taSelectOrGroup;
            }
            set
            {
                if (_taSelectOrGroup != value)
                {
                    _taSelectOrGroup = value;
                    if (_taSelectOrGroup != null)
                    {
                        _taSelectOrGroup.TaParent = this;
                        _taSelectOrGroup.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public QueryContinuationSyntax Continuation
        {
            get
            {
                if (_continuationIsChanged)
                {
                    _continuation = SyntaxFactoryStr.ParseQueryContinuationSyntax(ContinuationStr);
                    _continuationIsChanged = false;
                    _taContinuation = null;
                }
                else if (_taContinuation != null && _taContinuation.IsChanged)
                {
                    _continuation = (QueryContinuationSyntax) _taContinuation.Node;
                }
                return _continuation;
            }
            set
            {
                if (_continuation != value)
                {
                    _continuation = value;
                    _continuationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ContinuationStr
        {
            get
            {
                if (_taContinuation != null && _taContinuation.IsChanged)
                    Continuation = (QueryContinuationSyntax) _taContinuation.Node;
                if (_continuationIsChanged) return _continuationStr;
                return _continuationStr = _continuation?.ToFullString();
            }
            set
            {
                if (_taContinuation != null && _taContinuation.IsChanged)
                {
                    Continuation = (QueryContinuationSyntax) _taContinuation.Node;
                    _continuationStr = _continuation?.ToFullString();
                }
                if (_continuationStr != value)
                {
                    _continuationStr = value;
                    IsChanged = true;
                    _continuationIsChanged = true;
                    _taContinuation = null;
                }
            }
        }

        public TameQueryContinuationSyntax TaContinuation
        {
            get
            {
                if (_taContinuation == null && Continuation != null)
                {
                    _taContinuation = new TameQueryContinuationSyntax(Continuation) {TaParent = this};
                    _taContinuation.AddChildren();
                }
                return _taContinuation;
            }
            set
            {
                if (_taContinuation != value)
                {
                    _taContinuation = value;
                    if (_taContinuation != null)
                    {
                        _taContinuation.TaParent = this;
                        _taContinuation.IsChanged = true;
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
            _taClauses = null;
            _taSelectOrGroup = null;
            _taContinuation = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _clauses = ((QueryBodySyntax) Node).Clauses;
            _clausesIsChanged = false;
            _clausesCount = _clauses.Count;
            _selectOrGroup = ((QueryBodySyntax) Node).SelectOrGroup;
            _selectOrGroupIsChanged = false;
            _continuation = ((QueryBodySyntax) Node).Continuation;
            _continuationIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaClauses)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.QueryBody(Clauses, SelectOrGroup, Continuation);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaClauses)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaSelectOrGroup != null) yield return TaSelectOrGroup;
            if (TaContinuation != null) yield return TaContinuation;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ClausesStr", ClausesStr);
            yield return ("SelectOrGroupStr", SelectOrGroupStr);
            yield return ("ContinuationStr", ContinuationStr);
        }

        public TameQueryBodySyntax AddClause(TameQueryClauseSyntax item)
        {
            item.TaParent = this;
            TaClauses.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}