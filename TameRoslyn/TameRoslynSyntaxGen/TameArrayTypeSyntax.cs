// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameArrayTypeSyntax : TameTypeSyntax
    {
        public new static string TypeName = "ArrayTypeSyntax";
        private TypeSyntax _elementType;
        private bool _elementTypeIsChanged;
        private string _elementTypeStr;
        private SyntaxList<ArrayRankSpecifierSyntax> _rankSpecifiers;
        private int _rankSpecifiersCount;
        private bool _rankSpecifiersIsChanged;
        private string _rankSpecifiersStr;
        private TameTypeSyntax _taElementType;
        private List<TameArrayRankSpecifierSyntax> _taRankSpecifiers;

        public TameArrayTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseArrayType(code);
            AddChildren();
        }

        public TameArrayTypeSyntax(ArrayTypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameArrayTypeSyntax()
        {
            ElementTypeStr = DefaultValues.ArrayTypeSyntaxElementTypeStr;
            RankSpecifiersStr = DefaultValues.ArrayTypeSyntaxRankSpecifiersStr;
            IsVar = DefaultValues.ArrayTypeSyntaxIsVar;
        }

        public override string RoslynTypeName => TypeName;

        public TypeSyntax ElementType
        {
            get
            {
                if (_elementTypeIsChanged)
                {
                    _elementType = SyntaxFactoryStr.ParseTypeSyntax(ElementTypeStr);
                    _elementTypeIsChanged = false;
                    _taElementType = null;
                }
                else if (_taElementType != null && _taElementType.IsChanged)
                {
                    _elementType = (TypeSyntax) _taElementType.Node;
                }
                return _elementType;
            }
            set
            {
                if (_elementType != value)
                {
                    _elementType = value;
                    _elementTypeIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ElementTypeStr
        {
            get
            {
                if (_taElementType != null && _taElementType.IsChanged)
                    ElementType = (TypeSyntax) _taElementType.Node;
                if (_elementTypeIsChanged) return _elementTypeStr;
                return _elementTypeStr = _elementType?.ToFullString();
            }
            set
            {
                if (_taElementType != null && _taElementType.IsChanged)
                {
                    ElementType = (TypeSyntax) _taElementType.Node;
                    _elementTypeStr = _elementType?.ToFullString();
                }
                if (_elementTypeStr != value)
                {
                    _elementTypeStr = value;
                    IsChanged = true;
                    _elementTypeIsChanged = true;
                    _taElementType = null;
                }
            }
        }

        public TameTypeSyntax TaElementType
        {
            get
            {
                if (_taElementType == null && ElementType != null)
                    if (ElementType is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) ElementType)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                    else if (ElementType is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) ElementType) {TaParent = this};
                        loc.AddChildren();
                        _taElementType = loc;
                    }
                return _taElementType;
            }
            set
            {
                if (_taElementType != value)
                {
                    _taElementType = value;
                    if (_taElementType != null)
                    {
                        _taElementType.TaParent = this;
                        _taElementType.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public bool TaRankSpecifiersIsChanged { get; set; }

        public SyntaxList<ArrayRankSpecifierSyntax> RankSpecifiers
        {
            get
            {
                if (TaRankSpecifiersIsChanged || _taRankSpecifiers != null &&
                    (_taRankSpecifiers.Count != _rankSpecifiersCount || _taRankSpecifiers.Any(v => v.IsChanged)))
                {
                    _rankSpecifiers = SyntaxFactory.List(TaRankSpecifiers?.Select(v => v.Node)
                        .Cast<ArrayRankSpecifierSyntax>());
                    TaRankSpecifiersIsChanged = false;
                }
                return _rankSpecifiers;
            }
            set
            {
                if (_rankSpecifiers != value)
                {
                    _rankSpecifiers = value;
                    TaRankSpecifiersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string RankSpecifiersStr
        {
            get
            {
                if (_rankSpecifiersIsChanged) return _rankSpecifiersStr;
                return _rankSpecifiersStr = string.Join(", ", _rankSpecifiers.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _rankSpecifiersStr = value;
                    RankSpecifiers = new SyntaxList<ArrayRankSpecifierSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameArrayRankSpecifierSyntax> TaRankSpecifiers
        {
            get
            {
                if (_taRankSpecifiers == null)
                {
                    _taRankSpecifiers = new List<TameArrayRankSpecifierSyntax>();
                    foreach (var item in _rankSpecifiers)
                        _taRankSpecifiers.Add(new TameArrayRankSpecifierSyntax(item) {TaParent = this});
                }
                return _taRankSpecifiers;
            }
            set
            {
                if (_taRankSpecifiers != value)
                {
                    _taRankSpecifiers = value;
                    _taRankSpecifiers?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaRankSpecifiersIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taElementType = null;
            _taRankSpecifiers = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _elementType = ((ArrayTypeSyntax) Node).ElementType;
            _elementTypeIsChanged = false;
            _rankSpecifiers = ((ArrayTypeSyntax) Node).RankSpecifiers;
            _rankSpecifiersIsChanged = false;
            _rankSpecifiersCount = _rankSpecifiers.Count;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaRankSpecifiers)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ArrayType(ElementType, RankSpecifiers);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaRankSpecifiers)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaElementType != null) yield return TaElementType;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ElementTypeStr", ElementTypeStr);
            yield return ("RankSpecifiersStr", RankSpecifiersStr);
            yield return ("IsVar", IsVar.ToString());
        }

        public TameArrayTypeSyntax AddRankSpecifier(TameArrayRankSpecifierSyntax item)
        {
            item.TaParent = this;
            TaRankSpecifiers.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}