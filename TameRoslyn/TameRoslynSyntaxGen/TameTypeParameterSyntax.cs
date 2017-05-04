// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameTypeParameterSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "TypeParameterSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private SyntaxToken _varianceKeyword;
        private bool _varianceKeywordIsChanged;
        private string _varianceKeywordStr;

        public TameTypeParameterSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTypeParameter(code);
            AddChildren();
        }

        public TameTypeParameterSyntax(TypeParameterSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTypeParameterSyntax()
        {
            AttributeListsStr = DefaultValues.TypeParameterSyntaxAttributeListsStr;
            VarianceKeywordStr = DefaultValues.TypeParameterSyntaxVarianceKeywordStr;
            IdentifierStr = DefaultValues.TypeParameterSyntaxIdentifierStr;
        }

        public override string RoslynTypeName => TypeName;
        public bool TaAttributeListsIsChanged { get; set; }

        public SyntaxList<AttributeListSyntax> AttributeLists
        {
            get
            {
                if (TaAttributeListsIsChanged || _taAttributeLists != null &&
                    (_taAttributeLists.Count != _attributeListsCount || _taAttributeLists.Any(v => v.IsChanged)))
                {
                    _attributeLists = SyntaxFactory.List(TaAttributeLists?.Select(v => v.Node)
                        .Cast<AttributeListSyntax>());
                    TaAttributeListsIsChanged = false;
                }
                return _attributeLists;
            }
            set
            {
                if (_attributeLists != value)
                {
                    _attributeLists = value;
                    TaAttributeListsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AttributeListsStr
        {
            get
            {
                if (_attributeListsIsChanged) return _attributeListsStr;
                return _attributeListsStr = string.Join(", ", _attributeLists.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _attributeListsStr = value;
                    AttributeLists = new SyntaxList<AttributeListSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAttributeListSyntax> TaAttributeLists
        {
            get
            {
                if (_taAttributeLists == null)
                {
                    _taAttributeLists = new List<TameAttributeListSyntax>();
                    foreach (var item in _attributeLists)
                        _taAttributeLists.Add(new TameAttributeListSyntax(item) {TaParent = this});
                }
                return _taAttributeLists;
            }
            set
            {
                if (_taAttributeLists != value)
                {
                    _taAttributeLists = value;
                    _taAttributeLists?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAttributeListsIsChanged = true;
                }
            }
        }

        public SyntaxToken VarianceKeyword
        {
            get
            {
                if (_varianceKeywordIsChanged)
                {
                    _varianceKeyword = SyntaxFactoryStr.ParseSyntaxToken(VarianceKeywordStr);
                    _varianceKeywordIsChanged = false;
                }
                return _varianceKeyword;
            }
            set
            {
                if (_varianceKeyword != value)
                {
                    _varianceKeyword = value;
                    _varianceKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string VarianceKeywordStr
        {
            get
            {
                if (_varianceKeywordIsChanged) return _varianceKeywordStr;
                return _varianceKeywordStr = _varianceKeyword.Text;
            }
            set
            {
                if (_varianceKeywordStr != value)
                {
                    _varianceKeywordStr = value;
                    IsChanged = true;
                    _varianceKeywordIsChanged = true;
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
            _taAttributeLists = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _attributeLists = ((TypeParameterSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _varianceKeyword = ((TypeParameterSyntax) Node).VarianceKeyword;
            _varianceKeywordIsChanged = false;
            _identifier = ((TypeParameterSyntax) Node).Identifier;
            _identifierIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TypeParameter(AttributeLists, VarianceKeyword, Identifier);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("VarianceKeywordStr", VarianceKeywordStr);
            yield return ("IdentifierStr", IdentifierStr);
        }

        public TameTypeParameterSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}