// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCaseSwitchLabelSyntax : TameSwitchLabelSyntax
    {
        public new static string TypeName = "CaseSwitchLabelSyntax";
        private TameExpressionSyntax _taValue;
        private ExpressionSyntax _value;
        private bool _valueIsChanged;
        private string _valueStr;

        public TameCaseSwitchLabelSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCaseSwitchLabel(code);
            AddChildren();
        }

        public TameCaseSwitchLabelSyntax(CaseSwitchLabelSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCaseSwitchLabelSyntax()
        {
            ValueStr = DefaultValues.CaseSwitchLabelSyntaxValueStr;
            KeywordStr = DefaultValues.CaseSwitchLabelSyntaxKeywordStr;
            ColonTokenStr = DefaultValues.CaseSwitchLabelSyntaxColonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public ExpressionSyntax Value
        {
            get
            {
                if (_valueIsChanged)
                {
                    _value = SyntaxFactoryStr.ParseExpressionSyntax(ValueStr);
                    _valueIsChanged = false;
                    _taValue = null;
                }
                else if (_taValue != null && _taValue.IsChanged)
                {
                    _value = (ExpressionSyntax) _taValue.Node;
                }
                return _value;
            }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    _valueIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ValueStr
        {
            get
            {
                if (_taValue != null && _taValue.IsChanged)
                    Value = (ExpressionSyntax) _taValue.Node;
                if (_valueIsChanged) return _valueStr;
                return _valueStr = _value?.ToFullString();
            }
            set
            {
                if (_taValue != null && _taValue.IsChanged)
                {
                    Value = (ExpressionSyntax) _taValue.Node;
                    _valueStr = _value?.ToFullString();
                }
                if (_valueStr != value)
                {
                    _valueStr = value;
                    IsChanged = true;
                    _valueIsChanged = true;
                    _taValue = null;
                }
            }
        }

        public TameExpressionSyntax TaValue
        {
            get
            {
                if (_taValue == null && Value != null)
                    if (Value is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax((ParenthesizedLambdaExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Value)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is RefValueExpressionSyntax)
                    {
                        var loc = new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is CheckedExpressionSyntax)
                    {
                        var loc = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is DefaultExpressionSyntax)
                    {
                        var loc = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is LiteralExpressionSyntax)
                    {
                        var loc = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is MakeRefExpressionSyntax)
                    {
                        var loc = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is RefTypeExpressionSyntax)
                    {
                        var loc = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                    else if (Value is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Value) {TaParent = this};
                        loc.AddChildren();
                        _taValue = loc;
                    }
                return _taValue;
            }
            set
            {
                if (_taValue != value)
                {
                    _taValue = value;
                    if (_taValue != null)
                    {
                        _taValue.TaParent = this;
                        _taValue.IsChanged = true;
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
            _taValue = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _value = ((CaseSwitchLabelSyntax) Node).Value;
            _valueIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CaseSwitchLabel(Keyword, Value, ColonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaValue != null) yield return TaValue;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ValueStr", ValueStr);
            yield return ("KeywordStr", KeywordStr);
            yield return ("ColonTokenStr", ColonTokenStr);
        }
    }
}