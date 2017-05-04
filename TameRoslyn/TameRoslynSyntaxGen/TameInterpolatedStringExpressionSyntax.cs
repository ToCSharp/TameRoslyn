// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameInterpolatedStringExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "InterpolatedStringExpressionSyntax";
        private SyntaxList<InterpolatedStringContentSyntax> _contents;
        private int _contentsCount;
        private bool _contentsIsChanged;
        private string _contentsStr;
        private SyntaxToken _stringEndToken;
        private bool _stringEndTokenIsChanged;
        private string _stringEndTokenStr;
        private SyntaxToken _stringStartToken;
        private bool _stringStartTokenIsChanged;
        private string _stringStartTokenStr;
        private List<TameInterpolatedStringContentSyntax> _taContents;

        public TameInterpolatedStringExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseInterpolatedStringExpression(code);
            AddChildren();
        }

        public TameInterpolatedStringExpressionSyntax(InterpolatedStringExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameInterpolatedStringExpressionSyntax()
        {
            StringStartTokenStr = DefaultValues.InterpolatedStringExpressionSyntaxStringStartTokenStr;
            ContentsStr = DefaultValues.InterpolatedStringExpressionSyntaxContentsStr;
            StringEndTokenStr = DefaultValues.InterpolatedStringExpressionSyntaxStringEndTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken StringStartToken
        {
            get
            {
                if (_stringStartTokenIsChanged)
                {
                    _stringStartToken = SyntaxFactoryStr.ParseSyntaxToken(StringStartTokenStr);
                    _stringStartTokenIsChanged = false;
                }
                return _stringStartToken;
            }
            set
            {
                if (_stringStartToken != value)
                {
                    _stringStartToken = value;
                    _stringStartTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StringStartTokenStr
        {
            get
            {
                if (_stringStartTokenIsChanged) return _stringStartTokenStr;
                return _stringStartTokenStr = _stringStartToken.Text;
            }
            set
            {
                if (_stringStartTokenStr != value)
                {
                    _stringStartTokenStr = value;
                    IsChanged = true;
                    _stringStartTokenIsChanged = true;
                }
            }
        }

        public bool TaContentsIsChanged { get; set; }

        public SyntaxList<InterpolatedStringContentSyntax> Contents
        {
            get
            {
                if (TaContentsIsChanged || _taContents != null &&
                    (_taContents.Count != _contentsCount || _taContents.Any(v => v.IsChanged)))
                {
                    _contents = SyntaxFactory.List(TaContents?.Select(v => v.Node)
                        .Cast<InterpolatedStringContentSyntax>());
                    TaContentsIsChanged = false;
                }
                return _contents;
            }
            set
            {
                if (_contents != value)
                {
                    _contents = value;
                    TaContentsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ContentsStr
        {
            get
            {
                if (_contentsIsChanged) return _contentsStr;
                return _contentsStr = string.Join(", ", _contents.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _contentsStr = value;
                    Contents = new SyntaxList<InterpolatedStringContentSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameInterpolatedStringContentSyntax> TaContents
        {
            get
            {
                if (_taContents == null)
                {
                    _taContents = new List<TameInterpolatedStringContentSyntax>();
                    foreach (var item in _contents)
                        if (item is InterpolatedStringTextSyntax)
                            _taContents.Add(
                                new TameInterpolatedStringTextSyntax(item as InterpolatedStringTextSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InterpolationSyntax)
                            _taContents.Add(new TameInterpolationSyntax(item as InterpolationSyntax) {TaParent = this});
                        else if (item is InterpolatedStringContentSyntax)
                            _taContents.Add(new TameInterpolatedStringContentSyntax(item) {TaParent = this});
                }
                return _taContents;
            }
            set
            {
                if (_taContents != value)
                {
                    _taContents = value;
                    _taContents?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaContentsIsChanged = true;
                }
            }
        }

        public SyntaxToken StringEndToken
        {
            get
            {
                if (_stringEndTokenIsChanged)
                {
                    _stringEndToken = SyntaxFactoryStr.ParseSyntaxToken(StringEndTokenStr);
                    _stringEndTokenIsChanged = false;
                }
                return _stringEndToken;
            }
            set
            {
                if (_stringEndToken != value)
                {
                    _stringEndToken = value;
                    _stringEndTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StringEndTokenStr
        {
            get
            {
                if (_stringEndTokenIsChanged) return _stringEndTokenStr;
                return _stringEndTokenStr = _stringEndToken.Text;
            }
            set
            {
                if (_stringEndTokenStr != value)
                {
                    _stringEndTokenStr = value;
                    IsChanged = true;
                    _stringEndTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taContents = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _stringStartToken = ((InterpolatedStringExpressionSyntax) Node).StringStartToken;
            _stringStartTokenIsChanged = false;
            _contents = ((InterpolatedStringExpressionSyntax) Node).Contents;
            _contentsIsChanged = false;
            _contentsCount = _contents.Count;
            _stringEndToken = ((InterpolatedStringExpressionSyntax) Node).StringEndToken;
            _stringEndTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaContents)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.InterpolatedStringExpression(StringStartToken, Contents, StringEndToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaContents)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("StringStartTokenStr", StringStartTokenStr);
            yield return ("ContentsStr", ContentsStr);
            yield return ("StringEndTokenStr", StringEndTokenStr);
        }

        public TameInterpolatedStringExpressionSyntax AddContent(TameInterpolatedStringContentSyntax item)
        {
            item.TaParent = this;
            TaContents.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}