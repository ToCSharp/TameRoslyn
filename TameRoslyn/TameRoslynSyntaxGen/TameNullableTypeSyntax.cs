// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameNullableTypeSyntax : TameTypeSyntax
    {
        public new static string TypeName = "NullableTypeSyntax";
        private TypeSyntax _elementType;
        private bool _elementTypeIsChanged;
        private string _elementTypeStr;
        private SyntaxToken _questionToken;
        private bool _questionTokenIsChanged;
        private string _questionTokenStr;
        private TameTypeSyntax _taElementType;

        public TameNullableTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseNullableType(code);
            AddChildren();
        }

        public TameNullableTypeSyntax(NullableTypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameNullableTypeSyntax()
        {
            ElementTypeStr = DefaultValues.NullableTypeSyntaxElementTypeStr;
            QuestionTokenStr = DefaultValues.NullableTypeSyntaxQuestionTokenStr;
            IsVar = DefaultValues.NullableTypeSyntaxIsVar;
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

        public SyntaxToken QuestionToken
        {
            get
            {
                if (_questionTokenIsChanged)
                {
                    if (_questionTokenStr == null) _questionToken = default(SyntaxToken);
                    else
                        _questionToken = SyntaxFactoryStr.ParseSyntaxToken(_questionTokenStr, SyntaxKind.QuestionToken);
                    _questionTokenIsChanged = false;
                }
                return _questionToken;
            }
            set
            {
                if (_questionToken != value)
                {
                    _questionToken = value;
                    _questionTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string QuestionTokenStr
        {
            get
            {
                if (_questionTokenIsChanged) return _questionTokenStr;
                return _questionTokenStr = _questionToken.Text;
            }
            set
            {
                if (_questionTokenStr != value)
                {
                    _questionTokenStr = value;
                    IsChanged = true;
                    _questionTokenIsChanged = true;
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
            _elementType = ((NullableTypeSyntax) Node).ElementType;
            _elementTypeIsChanged = false;
            _questionToken = ((NullableTypeSyntax) Node).QuestionToken;
            _questionTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.NullableType(ElementType, QuestionToken);
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
            yield return ("QuestionTokenStr", QuestionTokenStr);
            yield return ("IsVar", IsVar.ToString());
        }
    }
}