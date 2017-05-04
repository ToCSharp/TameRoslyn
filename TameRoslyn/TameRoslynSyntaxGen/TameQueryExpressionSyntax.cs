// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameQueryExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "QueryExpressionSyntax";
        private QueryBodySyntax _body;
        private bool _bodyIsChanged;
        private string _bodyStr;
        private FromClauseSyntax _fromClause;
        private bool _fromClauseIsChanged;
        private string _fromClauseStr;
        private TameQueryBodySyntax _taBody;
        private TameFromClauseSyntax _taFromClause;

        public TameQueryExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseQueryExpression(code);
            AddChildren();
        }

        public TameQueryExpressionSyntax(QueryExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameQueryExpressionSyntax()
        {
            FromClauseStr = DefaultValues.QueryExpressionSyntaxFromClauseStr;
            BodyStr = DefaultValues.QueryExpressionSyntaxBodyStr;
        }

        public override string RoslynTypeName => TypeName;

        public FromClauseSyntax FromClause
        {
            get
            {
                if (_fromClauseIsChanged)
                {
                    _fromClause = SyntaxFactoryStr.ParseFromClauseSyntax(FromClauseStr);
                    _fromClauseIsChanged = false;
                    _taFromClause = null;
                }
                else if (_taFromClause != null && _taFromClause.IsChanged)
                {
                    _fromClause = (FromClauseSyntax) _taFromClause.Node;
                }
                return _fromClause;
            }
            set
            {
                if (_fromClause != value)
                {
                    _fromClause = value;
                    _fromClauseIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FromClauseStr
        {
            get
            {
                if (_taFromClause != null && _taFromClause.IsChanged)
                    FromClause = (FromClauseSyntax) _taFromClause.Node;
                if (_fromClauseIsChanged) return _fromClauseStr;
                return _fromClauseStr = _fromClause?.ToFullString();
            }
            set
            {
                if (_taFromClause != null && _taFromClause.IsChanged)
                {
                    FromClause = (FromClauseSyntax) _taFromClause.Node;
                    _fromClauseStr = _fromClause?.ToFullString();
                }
                if (_fromClauseStr != value)
                {
                    _fromClauseStr = value;
                    IsChanged = true;
                    _fromClauseIsChanged = true;
                    _taFromClause = null;
                }
            }
        }

        public TameFromClauseSyntax TaFromClause
        {
            get
            {
                if (_taFromClause == null && FromClause != null)
                {
                    _taFromClause = new TameFromClauseSyntax(FromClause) {TaParent = this};
                    _taFromClause.AddChildren();
                }
                return _taFromClause;
            }
            set
            {
                if (_taFromClause != value)
                {
                    _taFromClause = value;
                    if (_taFromClause != null)
                    {
                        _taFromClause.TaParent = this;
                        _taFromClause.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public QueryBodySyntax Body
        {
            get
            {
                if (_bodyIsChanged)
                {
                    _body = SyntaxFactoryStr.ParseQueryBodySyntax(BodyStr);
                    _bodyIsChanged = false;
                    _taBody = null;
                }
                else if (_taBody != null && _taBody.IsChanged)
                {
                    _body = (QueryBodySyntax) _taBody.Node;
                }
                return _body;
            }
            set
            {
                if (_body != value)
                {
                    _body = value;
                    _bodyIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string BodyStr
        {
            get
            {
                if (_taBody != null && _taBody.IsChanged)
                    Body = (QueryBodySyntax) _taBody.Node;
                if (_bodyIsChanged) return _bodyStr;
                return _bodyStr = _body?.ToFullString();
            }
            set
            {
                if (_taBody != null && _taBody.IsChanged)
                {
                    Body = (QueryBodySyntax) _taBody.Node;
                    _bodyStr = _body?.ToFullString();
                }
                if (_bodyStr != value)
                {
                    _bodyStr = value;
                    IsChanged = true;
                    _bodyIsChanged = true;
                    _taBody = null;
                }
            }
        }

        public TameQueryBodySyntax TaBody
        {
            get
            {
                if (_taBody == null && Body != null)
                {
                    _taBody = new TameQueryBodySyntax(Body) {TaParent = this};
                    _taBody.AddChildren();
                }
                return _taBody;
            }
            set
            {
                if (_taBody != value)
                {
                    _taBody = value;
                    if (_taBody != null)
                    {
                        _taBody.TaParent = this;
                        _taBody.IsChanged = true;
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
            _taFromClause = null;
            _taBody = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _fromClause = ((QueryExpressionSyntax) Node).FromClause;
            _fromClauseIsChanged = false;
            _body = ((QueryExpressionSyntax) Node).Body;
            _bodyIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.QueryExpression(FromClause, Body);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaFromClause != null) yield return TaFromClause;
            if (TaBody != null) yield return TaBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("FromClauseStr", FromClauseStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}