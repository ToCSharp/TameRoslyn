// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameConditionalExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "ConditionalExpressionSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private ExpressionSyntax _condition;
        private bool _conditionIsChanged;
        private string _conditionStr;
        private SyntaxToken _questionToken;
        private bool _questionTokenIsChanged;
        private string _questionTokenStr;
        private TameExpressionSyntax _taCondition;
        private TameExpressionSyntax _taWhenFalse;
        private TameExpressionSyntax _taWhenTrue;
        private ExpressionSyntax _whenFalse;
        private bool _whenFalseIsChanged;
        private string _whenFalseStr;
        private ExpressionSyntax _whenTrue;
        private bool _whenTrueIsChanged;
        private string _whenTrueStr;

        public TameConditionalExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseConditionalExpression(code);
            AddChildren();
        }

        public TameConditionalExpressionSyntax(ConditionalExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameConditionalExpressionSyntax()
        {
            ConditionStr = DefaultValues.ConditionalExpressionSyntaxConditionStr;
            QuestionTokenStr = DefaultValues.ConditionalExpressionSyntaxQuestionTokenStr;
            WhenTrueStr = DefaultValues.ConditionalExpressionSyntaxWhenTrueStr;
            ColonTokenStr = DefaultValues.ConditionalExpressionSyntaxColonTokenStr;
            WhenFalseStr = DefaultValues.ConditionalExpressionSyntaxWhenFalseStr;
        }

        public override string RoslynTypeName => TypeName;

        public ExpressionSyntax Condition
        {
            get
            {
                if (_conditionIsChanged)
                {
                    _condition = SyntaxFactoryStr.ParseExpressionSyntax(ConditionStr);
                    _conditionIsChanged = false;
                    _taCondition = null;
                }
                else if (_taCondition != null && _taCondition.IsChanged)
                {
                    _condition = (ExpressionSyntax) _taCondition.Node;
                }
                return _condition;
            }
            set
            {
                if (_condition != value)
                {
                    _condition = value;
                    _conditionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ConditionStr
        {
            get
            {
                if (_taCondition != null && _taCondition.IsChanged)
                    Condition = (ExpressionSyntax) _taCondition.Node;
                if (_conditionIsChanged) return _conditionStr;
                return _conditionStr = _condition?.ToFullString();
            }
            set
            {
                if (_taCondition != null && _taCondition.IsChanged)
                {
                    Condition = (ExpressionSyntax) _taCondition.Node;
                    _conditionStr = _condition?.ToFullString();
                }
                if (_conditionStr != value)
                {
                    _conditionStr = value;
                    IsChanged = true;
                    _conditionIsChanged = true;
                    _taCondition = null;
                }
            }
        }

        public TameExpressionSyntax TaCondition
        {
            get
            {
                if (_taCondition == null && Condition != null)
                    if (Condition is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Condition)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                    else if (Condition is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Condition) {TaParent = this};
                        loc.AddChildren();
                        _taCondition = loc;
                    }
                return _taCondition;
            }
            set
            {
                if (_taCondition != value)
                {
                    _taCondition = value;
                    if (_taCondition != null)
                    {
                        _taCondition.TaParent = this;
                        _taCondition.IsChanged = true;
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

        public ExpressionSyntax WhenTrue
        {
            get
            {
                if (_whenTrueIsChanged)
                {
                    _whenTrue = SyntaxFactoryStr.ParseExpressionSyntax(WhenTrueStr);
                    _whenTrueIsChanged = false;
                    _taWhenTrue = null;
                }
                else if (_taWhenTrue != null && _taWhenTrue.IsChanged)
                {
                    _whenTrue = (ExpressionSyntax) _taWhenTrue.Node;
                }
                return _whenTrue;
            }
            set
            {
                if (_whenTrue != value)
                {
                    _whenTrue = value;
                    _whenTrueIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhenTrueStr
        {
            get
            {
                if (_taWhenTrue != null && _taWhenTrue.IsChanged)
                    WhenTrue = (ExpressionSyntax) _taWhenTrue.Node;
                if (_whenTrueIsChanged) return _whenTrueStr;
                return _whenTrueStr = _whenTrue?.ToFullString();
            }
            set
            {
                if (_taWhenTrue != null && _taWhenTrue.IsChanged)
                {
                    WhenTrue = (ExpressionSyntax) _taWhenTrue.Node;
                    _whenTrueStr = _whenTrue?.ToFullString();
                }
                if (_whenTrueStr != value)
                {
                    _whenTrueStr = value;
                    IsChanged = true;
                    _whenTrueIsChanged = true;
                    _taWhenTrue = null;
                }
            }
        }

        public TameExpressionSyntax TaWhenTrue
        {
            get
            {
                if (_taWhenTrue == null && WhenTrue != null)
                    if (WhenTrue is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) WhenTrue)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is CheckedExpressionSyntax)
                    {
                        var loc = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is DefaultExpressionSyntax)
                    {
                        var loc = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is LiteralExpressionSyntax)
                    {
                        var loc = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is MakeRefExpressionSyntax)
                    {
                        var loc = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is RefTypeExpressionSyntax)
                    {
                        var loc = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                    else if (WhenTrue is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) WhenTrue) {TaParent = this};
                        loc.AddChildren();
                        _taWhenTrue = loc;
                    }
                return _taWhenTrue;
            }
            set
            {
                if (_taWhenTrue != value)
                {
                    _taWhenTrue = value;
                    if (_taWhenTrue != null)
                    {
                        _taWhenTrue.TaParent = this;
                        _taWhenTrue.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken ColonToken
        {
            get
            {
                if (_colonTokenIsChanged)
                {
                    if (_colonTokenStr == null) _colonToken = default(SyntaxToken);
                    else _colonToken = SyntaxFactoryStr.ParseSyntaxToken(_colonTokenStr, SyntaxKind.ColonToken);
                    _colonTokenIsChanged = false;
                }
                return _colonToken;
            }
            set
            {
                if (_colonToken != value)
                {
                    _colonToken = value;
                    _colonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ColonTokenStr
        {
            get
            {
                if (_colonTokenIsChanged) return _colonTokenStr;
                return _colonTokenStr = _colonToken.Text;
            }
            set
            {
                if (_colonTokenStr != value)
                {
                    _colonTokenStr = value;
                    IsChanged = true;
                    _colonTokenIsChanged = true;
                }
            }
        }

        public ExpressionSyntax WhenFalse
        {
            get
            {
                if (_whenFalseIsChanged)
                {
                    _whenFalse = SyntaxFactoryStr.ParseExpressionSyntax(WhenFalseStr);
                    _whenFalseIsChanged = false;
                    _taWhenFalse = null;
                }
                else if (_taWhenFalse != null && _taWhenFalse.IsChanged)
                {
                    _whenFalse = (ExpressionSyntax) _taWhenFalse.Node;
                }
                return _whenFalse;
            }
            set
            {
                if (_whenFalse != value)
                {
                    _whenFalse = value;
                    _whenFalseIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhenFalseStr
        {
            get
            {
                if (_taWhenFalse != null && _taWhenFalse.IsChanged)
                    WhenFalse = (ExpressionSyntax) _taWhenFalse.Node;
                if (_whenFalseIsChanged) return _whenFalseStr;
                return _whenFalseStr = _whenFalse?.ToFullString();
            }
            set
            {
                if (_taWhenFalse != null && _taWhenFalse.IsChanged)
                {
                    WhenFalse = (ExpressionSyntax) _taWhenFalse.Node;
                    _whenFalseStr = _whenFalse?.ToFullString();
                }
                if (_whenFalseStr != value)
                {
                    _whenFalseStr = value;
                    IsChanged = true;
                    _whenFalseIsChanged = true;
                    _taWhenFalse = null;
                }
            }
        }

        public TameExpressionSyntax TaWhenFalse
        {
            get
            {
                if (_taWhenFalse == null && WhenFalse != null)
                    if (WhenFalse is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) WhenFalse)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                    else if (WhenFalse is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) WhenFalse) {TaParent = this};
                        loc.AddChildren();
                        _taWhenFalse = loc;
                    }
                return _taWhenFalse;
            }
            set
            {
                if (_taWhenFalse != value)
                {
                    _taWhenFalse = value;
                    if (_taWhenFalse != null)
                    {
                        _taWhenFalse.TaParent = this;
                        _taWhenFalse.IsChanged = true;
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
            _taCondition = null;
            _taWhenTrue = null;
            _taWhenFalse = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _condition = ((ConditionalExpressionSyntax) Node).Condition;
            _conditionIsChanged = false;
            _questionToken = ((ConditionalExpressionSyntax) Node).QuestionToken;
            _questionTokenIsChanged = false;
            _whenTrue = ((ConditionalExpressionSyntax) Node).WhenTrue;
            _whenTrueIsChanged = false;
            _colonToken = ((ConditionalExpressionSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
            _whenFalse = ((ConditionalExpressionSyntax) Node).WhenFalse;
            _whenFalseIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ConditionalExpression(Condition, QuestionToken, WhenTrue, ColonToken, WhenFalse);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaCondition != null) yield return TaCondition;
            if (TaWhenTrue != null) yield return TaWhenTrue;
            if (TaWhenFalse != null) yield return TaWhenFalse;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ConditionStr", ConditionStr);
            yield return ("QuestionTokenStr", QuestionTokenStr);
            yield return ("WhenTrueStr", WhenTrueStr);
            yield return ("ColonTokenStr", ColonTokenStr);
            yield return ("WhenFalseStr", WhenFalseStr);
        }
    }
}