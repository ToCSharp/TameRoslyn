// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameStackAllocArrayCreationExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "StackAllocArrayCreationExpressionSyntax";
        private SyntaxToken _stackAllocKeyword;
        private bool _stackAllocKeywordIsChanged;
        private string _stackAllocKeywordStr;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameStackAllocArrayCreationExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseStackAllocArrayCreationExpression(code);
            AddChildren();
        }

        public TameStackAllocArrayCreationExpressionSyntax(StackAllocArrayCreationExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameStackAllocArrayCreationExpressionSyntax()
        {
            // StackAllocKeywordStr = DefaultValues.StackAllocArrayCreationExpressionSyntaxStackAllocKeywordStr;
            // TypeStr = DefaultValues.StackAllocArrayCreationExpressionSyntaxTypeStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken StackAllocKeyword
        {
            get
            {
                if (_stackAllocKeywordIsChanged)
                {
                    if (_stackAllocKeywordStr == null) _stackAllocKeyword = default(SyntaxToken);
                    else
                        _stackAllocKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_stackAllocKeywordStr, SyntaxKind.StackAllocKeyword);
                    _stackAllocKeywordIsChanged = false;
                }
                return _stackAllocKeyword;
            }
            set
            {
                if (_stackAllocKeyword != value)
                {
                    _stackAllocKeyword = value;
                    _stackAllocKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StackAllocKeywordStr
        {
            get
            {
                if (_stackAllocKeywordIsChanged) return _stackAllocKeywordStr;
                return _stackAllocKeywordStr = _stackAllocKeyword.Text;
            }
            set
            {
                if (_stackAllocKeywordStr != value)
                {
                    _stackAllocKeywordStr = value;
                    IsChanged = true;
                    _stackAllocKeywordIsChanged = true;
                }
            }
        }

        public TypeSyntax Type
        {
            get
            {
                if (_typeIsChanged)
                {
                    _type = SyntaxFactoryStr.ParseTypeSyntax(TypeStr);
                    _typeIsChanged = false;
                    _taType = null;
                }
                else if (_taType != null && _taType.IsChanged)
                {
                    _type = (TypeSyntax) _taType.Node;
                }
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    _typeIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeStr
        {
            get
            {
                if (_taType != null && _taType.IsChanged)
                    Type = (TypeSyntax) _taType.Node;
                if (_typeIsChanged) return _typeStr;
                return _typeStr = _type?.ToFullString();
            }
            set
            {
                if (_taType != null && _taType.IsChanged)
                {
                    Type = (TypeSyntax) _taType.Node;
                    _typeStr = _type?.ToFullString();
                }
                if (_typeStr != value)
                {
                    _typeStr = value;
                    IsChanged = true;
                    _typeIsChanged = true;
                    _taType = null;
                }
            }
        }

        public TameTypeSyntax TaType
        {
            get
            {
                if (_taType == null && Type != null)
                    if (Type is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is OmittedTypeArgumentSyntax)
                    {
                        var loc = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                return _taType;
            }
            set
            {
                if (_taType != value)
                {
                    _taType = value;
                    if (_taType != null)
                    {
                        _taType.TaParent = this;
                        _taType.IsChanged = true;
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
            _taType = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _stackAllocKeyword = ((StackAllocArrayCreationExpressionSyntax) Node).StackAllocKeyword;
            _stackAllocKeywordIsChanged = false;
            _type = ((StackAllocArrayCreationExpressionSyntax) Node).Type;
            _typeIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.StackAllocArrayCreationExpression(StackAllocKeyword, Type);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("StackAllocKeywordStr", StackAllocKeywordStr);
            yield return ("TypeStr", TypeStr);
        }
    }
}