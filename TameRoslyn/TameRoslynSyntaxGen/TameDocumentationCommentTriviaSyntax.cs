// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDocumentationCommentTriviaSyntax : TameStructuredTriviaSyntax
    {
        public new static string TypeName = "DocumentationCommentTriviaSyntax";
        private SyntaxList<XmlNodeSyntax> _content;
        private int _contentCount;
        private bool _contentIsChanged;
        private string _contentStr;
        private SyntaxToken _endOfComment;
        private bool _endOfCommentIsChanged;
        private string _endOfCommentStr;
        private List<TameXmlNodeSyntax> _taContent;

        public TameDocumentationCommentTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDocumentationCommentTrivia(code);
            AddChildren();
        }

        public TameDocumentationCommentTriviaSyntax(DocumentationCommentTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDocumentationCommentTriviaSyntax()
        {
            // ContentStr = DefaultValues.DocumentationCommentTriviaSyntaxContentStr;
            // EndOfCommentStr = DefaultValues.DocumentationCommentTriviaSyntaxEndOfCommentStr;
        }

        public override string RoslynTypeName => TypeName;
        public bool TaContentIsChanged { get; set; }

        public SyntaxList<XmlNodeSyntax> Content
        {
            get
            {
                if (TaContentIsChanged || _taContent != null &&
                    (_taContent.Count != _contentCount || _taContent.Any(v => v.IsChanged)))
                {
                    _content = SyntaxFactory.List(TaContent?.Select(v => v.Node).Cast<XmlNodeSyntax>());
                    TaContentIsChanged = false;
                }
                return _content;
            }
            set
            {
                if (_content != value)
                {
                    _content = value;
                    TaContentIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ContentStr
        {
            get
            {
                if (_contentIsChanged) return _contentStr;
                return _contentStr = string.Join(", ", _content.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _contentStr = value;
                    Content = new SyntaxList<XmlNodeSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameXmlNodeSyntax> TaContent
        {
            get
            {
                if (_taContent == null)
                {
                    _taContent = new List<TameXmlNodeSyntax>();
                    foreach (var item in _content)
                        if (item is XmlProcessingInstructionSyntax)
                            _taContent.Add(
                                new TameXmlProcessingInstructionSyntax(item as XmlProcessingInstructionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is XmlCDataSectionSyntax)
                            _taContent.Add(
                                new TameXmlCDataSectionSyntax(item as XmlCDataSectionSyntax) {TaParent = this});
                        else if (item is XmlEmptyElementSyntax)
                            _taContent.Add(
                                new TameXmlEmptyElementSyntax(item as XmlEmptyElementSyntax) {TaParent = this});
                        else if (item is XmlCommentSyntax)
                            _taContent.Add(new TameXmlCommentSyntax(item as XmlCommentSyntax) {TaParent = this});
                        else if (item is XmlElementSyntax)
                            _taContent.Add(new TameXmlElementSyntax(item as XmlElementSyntax) {TaParent = this});
                        else if (item is XmlTextSyntax)
                            _taContent.Add(new TameXmlTextSyntax(item as XmlTextSyntax) {TaParent = this});
                        else if (item is XmlNodeSyntax)
                            _taContent.Add(new TameXmlNodeSyntax(item) {TaParent = this});
                }
                return _taContent;
            }
            set
            {
                if (_taContent != value)
                {
                    _taContent = value;
                    _taContent?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaContentIsChanged = true;
                }
            }
        }

        public SyntaxToken EndOfComment
        {
            get
            {
                if (_endOfCommentIsChanged)
                {
                    _endOfComment = SyntaxFactoryStr.ParseSyntaxToken(EndOfCommentStr);
                    _endOfCommentIsChanged = false;
                }
                return _endOfComment;
            }
            set
            {
                if (_endOfComment != value)
                {
                    _endOfComment = value;
                    _endOfCommentIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndOfCommentStr
        {
            get
            {
                if (_endOfCommentIsChanged) return _endOfCommentStr;
                return _endOfCommentStr = _endOfComment.Text;
            }
            set
            {
                if (_endOfCommentStr != value)
                {
                    _endOfCommentStr = value;
                    IsChanged = true;
                    _endOfCommentIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taContent = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _content = ((DocumentationCommentTriviaSyntax) Node).Content;
            _contentIsChanged = false;
            _contentCount = _content.Count;
            _endOfComment = ((DocumentationCommentTriviaSyntax) Node).EndOfComment;
            _endOfCommentIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaContent)
                item.SetNotChanged();
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            throw new Exception(
                "InitializerExpressionSyntax Kind must be set to SyntaxKind.SingleLineDocumentationCommentTrivia or SyntaxKind.MultiLineDocumentationCommentTrivia");
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.DocumentationCommentTrivia(GetKind(), Content, EndOfComment);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaContent)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ContentStr", ContentStr);
            yield return ("EndOfCommentStr", EndOfCommentStr);
        }

        public TameDocumentationCommentTriviaSyntax AddContent(TameXmlNodeSyntax item)
        {
            item.TaParent = this;
            TaContent.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}