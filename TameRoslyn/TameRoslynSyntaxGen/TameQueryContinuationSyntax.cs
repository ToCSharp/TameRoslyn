// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameQueryContinuationSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "QueryContinuationSyntax";
        private QueryBodySyntax _body;
        private bool _bodyIsChanged;
        private string _bodyStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxToken _intoKeyword;
        private bool _intoKeywordIsChanged;
        private string _intoKeywordStr;
        private TameQueryBodySyntax _taBody;

        public TameQueryContinuationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseQueryContinuation(code);
            AddChildren();
        }

        public TameQueryContinuationSyntax(QueryContinuationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameQueryContinuationSyntax()
        {
            IntoKeywordStr = DefaultValues.QueryContinuationSyntaxIntoKeywordStr;
            IdentifierStr = DefaultValues.QueryContinuationSyntaxIdentifierStr;
            BodyStr = DefaultValues.QueryContinuationSyntaxBodyStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken IntoKeyword
        {
            get
            {
                if (_intoKeywordIsChanged)
                {
                    if (_intoKeywordStr == null) _intoKeyword = default(SyntaxToken);
                    else _intoKeyword = SyntaxFactoryStr.ParseSyntaxToken(_intoKeywordStr, SyntaxKind.IntoKeyword);
                    _intoKeywordIsChanged = false;
                }
                return _intoKeyword;
            }
            set
            {
                if (_intoKeyword != value)
                {
                    _intoKeyword = value;
                    _intoKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IntoKeywordStr
        {
            get
            {
                if (_intoKeywordIsChanged) return _intoKeywordStr;
                return _intoKeywordStr = _intoKeyword.Text;
            }
            set
            {
                if (_intoKeywordStr != value)
                {
                    _intoKeywordStr = value;
                    IsChanged = true;
                    _intoKeywordIsChanged = true;
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

        public SyntaxToken Identifier
        {
            get
            {
                if (_identifierIsChanged)
                {
                    _identifier = SyntaxFactoryStr.ParseSyntaxToken(IdentifierStr);
                    _identifierIsChanged = false;
                }
                return _identifier;
            }
            set
            {
                if (_identifier != value)
                {
                    _identifier = value;
                    _identifierIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IdentifierStr
        {
            get
            {
                if (_identifierIsChanged) return _identifierStr;
                return _identifierStr = _identifier.Text;
            }
            set
            {
                if (_identifierStr != value)
                {
                    _identifierStr = value;
                    IsChanged = true;
                    _identifierIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taBody = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _intoKeyword = ((QueryContinuationSyntax) Node).IntoKeyword;
            _intoKeywordIsChanged = false;
            _identifier = ((QueryContinuationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _body = ((QueryContinuationSyntax) Node).Body;
            _bodyIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.QueryContinuation(IntoKeyword, Identifier, Body);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaBody != null) yield return TaBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IntoKeywordStr", IntoKeywordStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}