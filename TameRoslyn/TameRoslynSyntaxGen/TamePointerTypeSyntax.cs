// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TamePointerTypeSyntax : TameTypeSyntax
    {
        public new static string TypeName = "PointerTypeSyntax";
        private SyntaxToken _asteriskToken;
        private bool _asteriskTokenIsChanged;
        private string _asteriskTokenStr;
        private TypeSyntax _elementType;
        private bool _elementTypeIsChanged;
        private string _elementTypeStr;
        private TameTypeSyntax _taElementType;

        public TamePointerTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParsePointerType(code);
            AddChildren();
        }

        public TamePointerTypeSyntax(PointerTypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TamePointerTypeSyntax()
        {
            ElementTypeStr = DefaultValues.PointerTypeSyntaxElementTypeStr;
            AsteriskTokenStr = DefaultValues.PointerTypeSyntaxAsteriskTokenStr;
            IsVar = DefaultValues.PointerTypeSyntaxIsVar;
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

        public SyntaxToken AsteriskToken
        {
            get
            {
                if (_asteriskTokenIsChanged)
                {
                    if (_asteriskTokenStr == null) _asteriskToken = default(SyntaxToken);
                    else
                        _asteriskToken = SyntaxFactoryStr.ParseSyntaxToken(_asteriskTokenStr, SyntaxKind.AsteriskToken);
                    _asteriskTokenIsChanged = false;
                }
                return _asteriskToken;
            }
            set
            {
                if (_asteriskToken != value)
                {
                    _asteriskToken = value;
                    _asteriskTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AsteriskTokenStr
        {
            get
            {
                if (_asteriskTokenIsChanged) return _asteriskTokenStr;
                return _asteriskTokenStr = _asteriskToken.Text;
            }
            set
            {
                if (_asteriskTokenStr != value)
                {
                    _asteriskTokenStr = value;
                    IsChanged = true;
                    _asteriskTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taElementType = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _elementType = ((PointerTypeSyntax) Node).ElementType;
            _elementTypeIsChanged = false;
            _asteriskToken = ((PointerTypeSyntax) Node).AsteriskToken;
            _asteriskTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.PointerType(ElementType, AsteriskToken);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaElementType != null) yield return TaElementType;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ElementTypeStr", ElementTypeStr);
            yield return ("AsteriskTokenStr", AsteriskTokenStr);
            yield return ("IsVar", IsVar.ToString());
        }
    }
}