// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameConditionalAccessExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "ConditionalAccessExpressionSyntax";
        private ExpressionSyntax _expression;
        private bool _expressionIsChanged;
        private string _expressionStr;
        private SyntaxToken _operatorToken;
        private bool _operatorTokenIsChanged;
        private string _operatorTokenStr;
        private TameExpressionSyntax _taExpression;
        private TameExpressionSyntax _taWhenNotNull;
        private ExpressionSyntax _whenNotNull;
        private bool _whenNotNullIsChanged;
        private string _whenNotNullStr;

        public TameConditionalAccessExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseConditionalAccessExpression(code);
            AddChildren();
        }

        public TameConditionalAccessExpressionSyntax(ConditionalAccessExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameConditionalAccessExpressionSyntax()
        {
            ExpressionStr = DefaultValues.ConditionalAccessExpressionSyntaxExpressionStr;
            OperatorTokenStr = DefaultValues.ConditionalAccessExpressionSyntaxOperatorTokenStr;
            WhenNotNullStr = DefaultValues.ConditionalAccessExpressionSyntaxWhenNotNullStr;
        }

        public override string RoslynTypeName => TypeName;

        public ExpressionSyntax Expression
        {
            get
            {
                if (_expressionIsChanged)
                {
                    _expression = SyntaxFactoryStr.ParseExpressionSyntax(ExpressionStr);
                    _expressionIsChanged = false;
                    _taExpression = null;
                }
                else if (_taExpression != null && _taExpression.IsChanged)
                {
                    _expression = (ExpressionSyntax) _taExpression.Node;
                }
                return _expression;
            }
            set
            {
                if (_expression != value)
                {
                    _expression = value;
                    _expressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExpressionStr
        {
            get
            {
                if (_taExpression != null && _taExpression.IsChanged)
                    Expression = (ExpressionSyntax) _taExpression.Node;
                if (_expressionIsChanged) return _expressionStr;
                return _expressionStr = _expression?.ToFullString();
            }
            set
            {
                if (_taExpression != null && _taExpression.IsChanged)
                {
                    Expression = (ExpressionSyntax) _taExpression.Node;
                    _expressionStr = _expression?.ToFullString();
                }
                if (_expressionStr != value)
                {
                    _expressionStr = value;
                    IsChanged = true;
                    _expressionIsChanged = true;
                    _taExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaExpression
        {
            get
            {
                if (_taExpression == null && Expression != null)
                    if (Expression is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Expression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                    else if (Expression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Expression) {TaParent = this};
                        loc.AddChildren();
                        _taExpression = loc;
                    }
                return _taExpression;
            }
            set
            {
                if (_taExpression != value)
                {
                    _taExpression = value;
                    if (_taExpression != null)
                    {
                        _taExpression.TaParent = this;
                        _taExpression.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken OperatorToken
        {
            get
            {
                if (_operatorTokenIsChanged)
                {
                    _operatorToken = SyntaxFactoryStr.ParseSyntaxToken(OperatorTokenStr);
                    _operatorTokenIsChanged = false;
                }
                return _operatorToken;
            }
            set
            {
                if (_operatorToken != value)
                {
                    _operatorToken = value;
                    _operatorTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperatorTokenStr
        {
            get
            {
                if (_operatorTokenIsChanged) return _operatorTokenStr;
                return _operatorTokenStr = _operatorToken.Text;
            }
            set
            {
                if (_operatorTokenStr != value)
                {
                    _operatorTokenStr = value;
                    IsChanged = true;
                    _operatorTokenIsChanged = true;
                }
            }
        }

        public ExpressionSyntax WhenNotNull
        {
            get
            {
                if (_whenNotNullIsChanged)
                {
                    _whenNotNull = SyntaxFactoryStr.ParseExpressionSyntax(WhenNotNullStr);
                    _whenNotNullIsChanged = false;
                    _taWhenNotNull = null;
                }
                else if (_taWhenNotNull != null && _taWhenNotNull.IsChanged)
                {
                    _whenNotNull = (ExpressionSyntax) _taWhenNotNull.Node;
                }
                return _whenNotNull;
            }
            set
            {
                if (_whenNotNull != value)
                {
                    _whenNotNull = value;
                    _whenNotNullIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhenNotNullStr
        {
            get
            {
                if (_taWhenNotNull != null && _taWhenNotNull.IsChanged)
                    WhenNotNull = (ExpressionSyntax) _taWhenNotNull.Node;
                if (_whenNotNullIsChanged) return _whenNotNullStr;
                return _whenNotNullStr = _whenNotNull?.ToFullString();
            }
            set
            {
                if (_taWhenNotNull != null && _taWhenNotNull.IsChanged)
                {
                    WhenNotNull = (ExpressionSyntax) _taWhenNotNull.Node;
                    _whenNotNullStr = _whenNotNull?.ToFullString();
                }
                if (_whenNotNullStr != value)
                {
                    _whenNotNullStr = value;
                    IsChanged = true;
                    _whenNotNullIsChanged = true;
                    _taWhenNotNull = null;
                }
            }
        }

        public TameExpressionSyntax TaWhenNotNull
        {
            get
            {
                if (_taWhenNotNull == null && WhenNotNull != null)
                    if (WhenNotNull is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) WhenNotNull)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                    else if (WhenNotNull is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) WhenNotNull) {TaParent = this};
                        loc.AddChildren();
                        _taWhenNotNull = loc;
                    }
                return _taWhenNotNull;
            }
            set
            {
                if (_taWhenNotNull != value)
                {
                    _taWhenNotNull = value;
                    if (_taWhenNotNull != null)
                    {
                        _taWhenNotNull.TaParent = this;
                        _taWhenNotNull.IsChanged = true;
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
            _taExpression = null;
            _taWhenNotNull = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _expression = ((ConditionalAccessExpressionSyntax) Node).Expression;
            _expressionIsChanged = false;
            _operatorToken = ((ConditionalAccessExpressionSyntax) Node).OperatorToken;
            _operatorTokenIsChanged = false;
            _whenNotNull = ((ConditionalAccessExpressionSyntax) Node).WhenNotNull;
            _whenNotNullIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ConditionalAccessExpression(Expression, OperatorToken, WhenNotNull);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaExpression != null) yield return TaExpression;
            if (TaWhenNotNull != null) yield return TaWhenNotNull;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ExpressionStr", ExpressionStr);
            yield return ("OperatorTokenStr", OperatorTokenStr);
            yield return ("WhenNotNullStr", WhenNotNullStr);
        }
    }
}