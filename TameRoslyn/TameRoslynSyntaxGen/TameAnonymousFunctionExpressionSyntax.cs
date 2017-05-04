// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameAnonymousFunctionExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "AnonymousFunctionExpressionSyntax";
        private SyntaxToken _asyncKeyword;
        private bool _asyncKeywordIsChanged;
        private string _asyncKeywordStr;
        private CSharpSyntaxNode _body;
        private bool _bodyIsChanged;
        private string _bodyStr;
        private TameBaseRoslynNode _taBody;

        public TameAnonymousFunctionExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAnonymousFunctionExpression(code);
            AddChildren();
        }

        public TameAnonymousFunctionExpressionSyntax(AnonymousFunctionExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAnonymousFunctionExpressionSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken AsyncKeyword
        {
            get
            {
                if (_asyncKeywordIsChanged)
                {
                    if (_asyncKeywordStr == null) _asyncKeyword = default(SyntaxToken);
                    else _asyncKeyword = SyntaxFactoryStr.ParseSyntaxToken(_asyncKeywordStr, SyntaxKind.AsyncKeyword);
                    _asyncKeywordIsChanged = false;
                }
                return _asyncKeyword;
            }
            set
            {
                if (_asyncKeyword != value)
                {
                    _asyncKeyword = value;
                    _asyncKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AsyncKeywordStr
        {
            get
            {
                if (_asyncKeywordIsChanged) return _asyncKeywordStr;
                return _asyncKeywordStr = _asyncKeyword.Text;
            }
            set
            {
                if (_asyncKeywordStr != value)
                {
                    _asyncKeywordStr = value;
                    IsChanged = true;
                    _asyncKeywordIsChanged = true;
                }
            }
        }

        public CSharpSyntaxNode Body
        {
            get
            {
                if (_bodyIsChanged)
                {
                    _body = SyntaxFactoryStr.ParseCSharpSyntaxNode(BodyStr);
                    _bodyIsChanged = false;
                    _taBody = null;
                }
                else if (_taBody != null && _taBody.IsChanged)
                {
                    _body = (CSharpSyntaxNode) _taBody.Node;
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
                    Body = (CSharpSyntaxNode) _taBody.Node;
                if (_bodyIsChanged) return _bodyStr;
                return _bodyStr = _body?.ToFullString();
            }
            set
            {
                if (_taBody != null && _taBody.IsChanged)
                {
                    Body = (CSharpSyntaxNode) _taBody.Node;
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

        public TameBaseRoslynNode TaBody
        {
            get
            {
                if (_taBody == null && Body != null)
                {
                    _taBody = TameBaseRoslynNodeCreate.CreateTameNode(Body);
                    _taBody.TaParent = this;
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
            _taBody = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _asyncKeyword = ((AnonymousFunctionExpressionSyntax) Node).AsyncKeyword;
            _asyncKeywordIsChanged = false;
            _body = ((AnonymousFunctionExpressionSyntax) Node).Body;
            _bodyIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
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
            yield return ("AsyncKeywordStr", AsyncKeywordStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}