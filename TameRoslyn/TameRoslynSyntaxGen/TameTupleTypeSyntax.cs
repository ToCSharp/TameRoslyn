// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameTupleTypeSyntax : TameTypeSyntax
    {
        public new static string TypeName = "TupleTypeSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private SeparatedSyntaxList<TupleElementSyntax> _elements;
        private int _elementsCount;
        private bool _elementsIsChanged;
        private string _elementsStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private List<TameTupleElementSyntax> _taElements;

        public TameTupleTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTupleType(code);
            AddChildren();
        }

        public TameTupleTypeSyntax(TupleTypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTupleTypeSyntax()
        {
            OpenParenTokenStr = DefaultValues.TupleTypeSyntaxOpenParenTokenStr;
            ElementsStr = DefaultValues.TupleTypeSyntaxElementsStr;
            CloseParenTokenStr = DefaultValues.TupleTypeSyntaxCloseParenTokenStr;
            IsVar = DefaultValues.TupleTypeSyntaxIsVar;
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

        public bool TaElementsIsChanged { get; set; }

        public SeparatedSyntaxList<TupleElementSyntax> Elements
        {
            get
            {
                if (TaElementsIsChanged || _taElements != null &&
                    (_taElements.Count != _elementsCount || _taElements.Any(v => v.IsChanged)))
                {
                    _elements = SyntaxFactory.SeparatedList(TaElements?.Select(v => v.Node).Cast<TupleElementSyntax>());
                    TaElementsIsChanged = false;
                }
                return _elements;
            }
            set
            {
                if (_elements != value)
                {
                    _elements = value;
                    TaElementsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ElementsStr
        {
            get
            {
                if (_elementsIsChanged) return _elementsStr;
                return _elementsStr = string.Join(", ", _elements.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _elementsStr = value;
                    Elements = new SeparatedSyntaxList<TupleElementSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameTupleElementSyntax> TaElements
        {
            get
            {
                if (_taElements == null)
                {
                    _taElements = new List<TameTupleElementSyntax>();
                    foreach (var item in _elements)
                        _taElements.Add(new TameTupleElementSyntax(item) {TaParent = this});
                }
                return _taElements;
            }
            set
            {
                if (_taElements != value)
                {
                    _taElements = value;
                    _taElements?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaElementsIsChanged = true;
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
            _taElements = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _openParenToken = ((TupleTypeSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _elements = ((TupleTypeSyntax) Node).Elements;
            _elementsIsChanged = false;
            _elementsCount = _elements.Count;
            _closeParenToken = ((TupleTypeSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaElements)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TupleType(OpenParenToken, Elements, CloseParenToken);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaElements)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("ElementsStr", ElementsStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("IsVar", IsVar.ToString());
        }

        public TameTupleTypeSyntax AddElement(TameTupleElementSyntax item)
        {
            item.TaParent = this;
            TaElements.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}