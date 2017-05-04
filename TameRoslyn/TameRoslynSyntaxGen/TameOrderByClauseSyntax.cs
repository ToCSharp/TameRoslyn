// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameOrderByClauseSyntax : TameQueryClauseSyntax
    {
        public new static string TypeName = "OrderByClauseSyntax";
        private SyntaxToken _orderByKeyword;
        private bool _orderByKeywordIsChanged;
        private string _orderByKeywordStr;
        private SeparatedSyntaxList<OrderingSyntax> _orderings;
        private int _orderingsCount;
        private bool _orderingsIsChanged;
        private string _orderingsStr;
        private List<TameOrderingSyntax> _taOrderings;

        public TameOrderByClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseOrderByClause(code);
            AddChildren();
        }

        public TameOrderByClauseSyntax(OrderByClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameOrderByClauseSyntax()
        {
            OrderByKeywordStr = DefaultValues.OrderByClauseSyntaxOrderByKeywordStr;
            OrderingsStr = DefaultValues.OrderByClauseSyntaxOrderingsStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OrderByKeyword
        {
            get
            {
                if (_orderByKeywordIsChanged)
                {
                    if (_orderByKeywordStr == null) _orderByKeyword = default(SyntaxToken);
                    else
                        _orderByKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_orderByKeywordStr, SyntaxKind.OrderByKeyword);
                    _orderByKeywordIsChanged = false;
                }
                return _orderByKeyword;
            }
            set
            {
                if (_orderByKeyword != value)
                {
                    _orderByKeyword = value;
                    _orderByKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OrderByKeywordStr
        {
            get
            {
                if (_orderByKeywordIsChanged) return _orderByKeywordStr;
                return _orderByKeywordStr = _orderByKeyword.Text;
            }
            set
            {
                if (_orderByKeywordStr != value)
                {
                    _orderByKeywordStr = value;
                    IsChanged = true;
                    _orderByKeywordIsChanged = true;
                }
            }
        }

        public bool TaOrderingsIsChanged { get; set; }

        public SeparatedSyntaxList<OrderingSyntax> Orderings
        {
            get
            {
                if (TaOrderingsIsChanged || _taOrderings != null &&
                    (_taOrderings.Count != _orderingsCount || _taOrderings.Any(v => v.IsChanged)))
                {
                    _orderings = SyntaxFactory.SeparatedList(TaOrderings?.Select(v => v.Node).Cast<OrderingSyntax>());
                    TaOrderingsIsChanged = false;
                }
                return _orderings;
            }
            set
            {
                if (_orderings != value)
                {
                    _orderings = value;
                    TaOrderingsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OrderingsStr
        {
            get
            {
                if (_orderingsIsChanged) return _orderingsStr;
                return _orderingsStr = string.Join(", ", _orderings.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _orderingsStr = value;
                    Orderings = new SeparatedSyntaxList<OrderingSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameOrderingSyntax> TaOrderings
        {
            get
            {
                if (_taOrderings == null)
                {
                    _taOrderings = new List<TameOrderingSyntax>();
                    foreach (var item in _orderings)
                        _taOrderings.Add(new TameOrderingSyntax(item) {TaParent = this});
                }
                return _taOrderings;
            }
            set
            {
                if (_taOrderings != value)
                {
                    _taOrderings = value;
                    _taOrderings?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaOrderingsIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taOrderings = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _orderByKeyword = ((OrderByClauseSyntax) Node).OrderByKeyword;
            _orderByKeywordIsChanged = false;
            _orderings = ((OrderByClauseSyntax) Node).Orderings;
            _orderingsIsChanged = false;
            _orderingsCount = _orderings.Count;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaOrderings)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.OrderByClause(OrderByKeyword, Orderings);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaOrderings)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OrderByKeywordStr", OrderByKeywordStr);
            yield return ("OrderingsStr", OrderingsStr);
        }

        public TameOrderByClauseSyntax AddOrdering(TameOrderingSyntax item)
        {
            item.TaParent = this;
            TaOrderings.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}