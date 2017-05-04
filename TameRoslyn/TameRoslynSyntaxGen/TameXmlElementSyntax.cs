// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlElementSyntax : TameXmlNodeSyntax
    {
        public new static string TypeName = "XmlElementSyntax";
        private SyntaxList<XmlNodeSyntax> _content;
        private int _contentCount;
        private bool _contentIsChanged;
        private string _contentStr;
        private XmlElementEndTagSyntax _endTag;
        private bool _endTagIsChanged;
        private string _endTagStr;
        private XmlElementStartTagSyntax _startTag;
        private bool _startTagIsChanged;
        private string _startTagStr;
        private List<TameXmlNodeSyntax> _taContent;
        private TameXmlElementEndTagSyntax _taEndTag;
        private TameXmlElementStartTagSyntax _taStartTag;

        public TameXmlElementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlElement(code);
            AddChildren();
        }

        public TameXmlElementSyntax(XmlElementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlElementSyntax()
        {
            // StartTagStr = DefaultValues.XmlElementSyntaxStartTagStr;
            // ContentStr = DefaultValues.XmlElementSyntaxContentStr;
            // EndTagStr = DefaultValues.XmlElementSyntaxEndTagStr;
        }

        public override string RoslynTypeName => TypeName;

        public XmlElementStartTagSyntax StartTag
        {
            get
            {
                if (_startTagIsChanged)
                {
                    _startTag = SyntaxFactoryStr.ParseXmlElementStartTagSyntax(StartTagStr);
                    _startTagIsChanged = false;
                    _taStartTag = null;
                }
                else if (_taStartTag != null && _taStartTag.IsChanged)
                {
                    _startTag = (XmlElementStartTagSyntax) _taStartTag.Node;
                }
                return _startTag;
            }
            set
            {
                if (_startTag != value)
                {
                    _startTag = value;
                    _startTagIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StartTagStr
        {
            get
            {
                if (_taStartTag != null && _taStartTag.IsChanged)
                    StartTag = (XmlElementStartTagSyntax) _taStartTag.Node;
                if (_startTagIsChanged) return _startTagStr;
                return _startTagStr = _startTag?.ToFullString();
            }
            set
            {
                if (_taStartTag != null && _taStartTag.IsChanged)
                {
                    StartTag = (XmlElementStartTagSyntax) _taStartTag.Node;
                    _startTagStr = _startTag?.ToFullString();
                }
                if (_startTagStr != value)
                {
                    _startTagStr = value;
                    IsChanged = true;
                    _startTagIsChanged = true;
                    _taStartTag = null;
                }
            }
        }

        public TameXmlElementStartTagSyntax TaStartTag
        {
            get
            {
                if (_taStartTag == null && StartTag != null)
                {
                    _taStartTag = new TameXmlElementStartTagSyntax(StartTag) {TaParent = this};
                    _taStartTag.AddChildren();
                }
                return _taStartTag;
            }
            set
            {
                if (_taStartTag != value)
                {
                    _taStartTag = value;
                    if (_taStartTag != null)
                    {
                        _taStartTag.TaParent = this;
                        _taStartTag.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

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

        public XmlElementEndTagSyntax EndTag
        {
            get
            {
                if (_endTagIsChanged)
                {
                    _endTag = SyntaxFactoryStr.ParseXmlElementEndTagSyntax(EndTagStr);
                    _endTagIsChanged = false;
                    _taEndTag = null;
                }
                else if (_taEndTag != null && _taEndTag.IsChanged)
                {
                    _endTag = (XmlElementEndTagSyntax) _taEndTag.Node;
                }
                return _endTag;
            }
            set
            {
                if (_endTag != value)
                {
                    _endTag = value;
                    _endTagIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndTagStr
        {
            get
            {
                if (_taEndTag != null && _taEndTag.IsChanged)
                    EndTag = (XmlElementEndTagSyntax) _taEndTag.Node;
                if (_endTagIsChanged) return _endTagStr;
                return _endTagStr = _endTag?.ToFullString();
            }
            set
            {
                if (_taEndTag != null && _taEndTag.IsChanged)
                {
                    EndTag = (XmlElementEndTagSyntax) _taEndTag.Node;
                    _endTagStr = _endTag?.ToFullString();
                }
                if (_endTagStr != value)
                {
                    _endTagStr = value;
                    IsChanged = true;
                    _endTagIsChanged = true;
                    _taEndTag = null;
                }
            }
        }

        public TameXmlElementEndTagSyntax TaEndTag
        {
            get
            {
                if (_taEndTag == null && EndTag != null)
                {
                    _taEndTag = new TameXmlElementEndTagSyntax(EndTag) {TaParent = this};
                    _taEndTag.AddChildren();
                }
                return _taEndTag;
            }
            set
            {
                if (_taEndTag != value)
                {
                    _taEndTag = value;
                    if (_taEndTag != null)
                    {
                        _taEndTag.TaParent = this;
                        _taEndTag.IsChanged = true;
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
            _taStartTag = null;
            _taContent = null;
            _taEndTag = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _startTag = ((XmlElementSyntax) Node).StartTag;
            _startTagIsChanged = false;
            _content = ((XmlElementSyntax) Node).Content;
            _contentIsChanged = false;
            _contentCount = _content.Count;
            _endTag = ((XmlElementSyntax) Node).EndTag;
            _endTagIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaContent)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlElement(StartTag, Content, EndTag);
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
            if (TaStartTag != null) yield return TaStartTag;
            if (TaEndTag != null) yield return TaEndTag;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("StartTagStr", StartTagStr);
            yield return ("ContentStr", ContentStr);
            yield return ("EndTagStr", EndTagStr);
        }

        public TameXmlElementSyntax AddContent(TameXmlNodeSyntax item)
        {
            item.TaParent = this;
            TaContent.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}