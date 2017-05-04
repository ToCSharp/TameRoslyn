// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAttributeListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "AttributeListSyntax";
        private SeparatedSyntaxList<AttributeSyntax> _attributes;
        private int _attributesCount;
        private bool _attributesIsChanged;
        private string _attributesStr;
        private SyntaxToken _closeBracketToken;
        private bool _closeBracketTokenIsChanged;
        private string _closeBracketTokenStr;
        private SyntaxToken _openBracketToken;
        private bool _openBracketTokenIsChanged;
        private string _openBracketTokenStr;
        private List<TameAttributeSyntax> _taAttributes;
        private AttributeTargetSpecifierSyntax _target;
        private bool _targetIsChanged;
        private string _targetStr;
        private TameAttributeTargetSpecifierSyntax _taTarget;

        public TameAttributeListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAttributeList(code);
            AddChildren();
        }

        public TameAttributeListSyntax(AttributeListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAttributeListSyntax()
        {
            OpenBracketTokenStr = DefaultValues.AttributeListSyntaxOpenBracketTokenStr;
            TargetStr = DefaultValues.AttributeListSyntaxTargetStr;
            AttributesStr = DefaultValues.AttributeListSyntaxAttributesStr;
            CloseBracketTokenStr = DefaultValues.AttributeListSyntaxCloseBracketTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenBracketToken
        {
            get
            {
                if (_openBracketTokenIsChanged)
                {
                    if (_openBracketTokenStr == null) _openBracketToken = default(SyntaxToken);
                    else
                        _openBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBracketTokenStr, SyntaxKind.OpenBracketToken);
                    _openBracketTokenIsChanged = false;
                }
                return _openBracketToken;
            }
            set
            {
                if (_openBracketToken != value)
                {
                    _openBracketToken = value;
                    _openBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBracketTokenStr
        {
            get
            {
                if (_openBracketTokenIsChanged) return _openBracketTokenStr;
                return _openBracketTokenStr = _openBracketToken.Text;
            }
            set
            {
                if (_openBracketTokenStr != value)
                {
                    _openBracketTokenStr = value;
                    IsChanged = true;
                    _openBracketTokenIsChanged = true;
                }
            }
        }

        public AttributeTargetSpecifierSyntax Target
        {
            get
            {
                if (_targetIsChanged)
                {
                    _target = SyntaxFactoryStr.ParseAttributeTargetSpecifierSyntax(TargetStr);
                    _targetIsChanged = false;
                    _taTarget = null;
                }
                else if (_taTarget != null && _taTarget.IsChanged)
                {
                    _target = (AttributeTargetSpecifierSyntax) _taTarget.Node;
                }
                return _target;
            }
            set
            {
                if (_target != value)
                {
                    _target = value;
                    _targetIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TargetStr
        {
            get
            {
                if (_taTarget != null && _taTarget.IsChanged)
                    Target = (AttributeTargetSpecifierSyntax) _taTarget.Node;
                if (_targetIsChanged) return _targetStr;
                return _targetStr = _target?.ToFullString();
            }
            set
            {
                if (_taTarget != null && _taTarget.IsChanged)
                {
                    Target = (AttributeTargetSpecifierSyntax) _taTarget.Node;
                    _targetStr = _target?.ToFullString();
                }
                if (_targetStr != value)
                {
                    _targetStr = value;
                    IsChanged = true;
                    _targetIsChanged = true;
                    _taTarget = null;
                }
            }
        }

        public TameAttributeTargetSpecifierSyntax TaTarget
        {
            get
            {
                if (_taTarget == null && Target != null)
                {
                    _taTarget = new TameAttributeTargetSpecifierSyntax(Target) {TaParent = this};
                    _taTarget.AddChildren();
                }
                return _taTarget;
            }
            set
            {
                if (_taTarget != value)
                {
                    _taTarget = value;
                    if (_taTarget != null)
                    {
                        _taTarget.TaParent = this;
                        _taTarget.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public bool TaAttributesIsChanged { get; set; }

        public SeparatedSyntaxList<AttributeSyntax> Attributes
        {
            get
            {
                if (TaAttributesIsChanged || _taAttributes != null &&
                    (_taAttributes.Count != _attributesCount || _taAttributes.Any(v => v.IsChanged)))
                {
                    _attributes =
                        SyntaxFactory.SeparatedList(TaAttributes?.Select(v => v.Node).Cast<AttributeSyntax>());
                    TaAttributesIsChanged = false;
                }
                return _attributes;
            }
            set
            {
                if (_attributes != value)
                {
                    _attributes = value;
                    TaAttributesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AttributesStr
        {
            get
            {
                if (_attributesIsChanged) return _attributesStr;
                return _attributesStr = string.Join(", ", _attributes.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _attributesStr = value;
                    Attributes = new SeparatedSyntaxList<AttributeSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAttributeSyntax> TaAttributes
        {
            get
            {
                if (_taAttributes == null)
                {
                    _taAttributes = new List<TameAttributeSyntax>();
                    foreach (var item in _attributes)
                        _taAttributes.Add(new TameAttributeSyntax(item) {TaParent = this});
                }
                return _taAttributes;
            }
            set
            {
                if (_taAttributes != value)
                {
                    _taAttributes = value;
                    _taAttributes?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAttributesIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBracketToken
        {
            get
            {
                if (_closeBracketTokenIsChanged)
                {
                    if (_closeBracketTokenStr == null) _closeBracketToken = default(SyntaxToken);
                    else
                        _closeBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBracketTokenStr, SyntaxKind.CloseBracketToken);
                    _closeBracketTokenIsChanged = false;
                }
                return _closeBracketToken;
            }
            set
            {
                if (_closeBracketToken != value)
                {
                    _closeBracketToken = value;
                    _closeBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBracketTokenStr
        {
            get
            {
                if (_closeBracketTokenIsChanged) return _closeBracketTokenStr;
                return _closeBracketTokenStr = _closeBracketToken.Text;
            }
            set
            {
                if (_closeBracketTokenStr != value)
                {
                    _closeBracketTokenStr = value;
                    IsChanged = true;
                    _closeBracketTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taTarget = null;
            _taAttributes = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _openBracketToken = ((AttributeListSyntax) Node).OpenBracketToken;
            _openBracketTokenIsChanged = false;
            _target = ((AttributeListSyntax) Node).Target;
            _targetIsChanged = false;
            _attributes = ((AttributeListSyntax) Node).Attributes;
            _attributesIsChanged = false;
            _attributesCount = _attributes.Count;
            _closeBracketToken = ((AttributeListSyntax) Node).CloseBracketToken;
            _closeBracketTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaAttributes)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AttributeList(OpenBracketToken, Target, Attributes, CloseBracketToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributes)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaTarget != null) yield return TaTarget;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenBracketTokenStr", OpenBracketTokenStr);
            yield return ("TargetStr", TargetStr);
            yield return ("AttributesStr", AttributesStr);
            yield return ("CloseBracketTokenStr", CloseBracketTokenStr);
        }

        public TameAttributeListSyntax AddAttribute(TameAttributeSyntax item)
        {
            item.TaParent = this;
            TaAttributes.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}