// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameLockStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "LockStatementSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private ExpressionSyntax _expression;
        private bool _expressionIsChanged;
        private string _expressionStr;
        private SyntaxToken _lockKeyword;
        private bool _lockKeywordIsChanged;
        private string _lockKeywordStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private StatementSyntax _statement;
        private bool _statementIsChanged;
        private string _statementStr;
        private TameExpressionSyntax _taExpression;
        private TameStatementSyntax _taStatement;

        public TameLockStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseLockStatement(code);
            AddChildren();
        }

        public TameLockStatementSyntax(LockStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameLockStatementSyntax()
        {
            LockKeywordStr = DefaultValues.LockStatementSyntaxLockKeywordStr;
            OpenParenTokenStr = DefaultValues.LockStatementSyntaxOpenParenTokenStr;
            ExpressionStr = DefaultValues.LockStatementSyntaxExpressionStr;
            CloseParenTokenStr = DefaultValues.LockStatementSyntaxCloseParenTokenStr;
            StatementStr = DefaultValues.LockStatementSyntaxStatementStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LockKeyword
        {
            get
            {
                if (_lockKeywordIsChanged)
                {
                    if (_lockKeywordStr == null) _lockKeyword = default(SyntaxToken);
                    else _lockKeyword = SyntaxFactoryStr.ParseSyntaxToken(_lockKeywordStr, SyntaxKind.LockKeyword);
                    _lockKeywordIsChanged = false;
                }
                return _lockKeyword;
            }
            set
            {
                if (_lockKeyword != value)
                {
                    _lockKeyword = value;
                    _lockKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LockKeywordStr
        {
            get
            {
                if (_lockKeywordIsChanged) return _lockKeywordStr;
                return _lockKeywordStr = _lockKeyword.Text;
            }
            set
            {
                if (_lockKeywordStr != value)
                {
                    _lockKeywordStr = value;
                    IsChanged = true;
                    _lockKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken OpenParenToken
        {
            get
            {
                if (_openParenTokenIsChanged)
                {
                    if (_openParenTokenStr == null) _openParenToken = default(SyntaxToken);
                    else
                        _openParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openParenTokenStr, SyntaxKind.OpenParenToken);
                    _openParenTokenIsChanged = false;
                }
                return _openParenToken;
            }
            set
            {
                if (_openParenToken != value)
                {
                    _openParenToken = value;
                    _openParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenParenTokenStr
        {
            get
            {
                if (_openParenTokenIsChanged) return _openParenTokenStr;
                return _openParenTokenStr = _openParenToken.Text;
            }
            set
            {
                if (_openParenTokenStr != value)
                {
                    _openParenTokenStr = value;
                    IsChanged = true;
                    _openParenTokenIsChanged = true;
                }
            }
        }

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

        public SyntaxToken CloseParenToken
        {
            get
            {
                if (_closeParenTokenIsChanged)
                {
                    if (_closeParenTokenStr == null) _closeParenToken = default(SyntaxToken);
                    else
                        _closeParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeParenTokenStr, SyntaxKind.CloseParenToken);
                    _closeParenTokenIsChanged = false;
                }
                return _closeParenToken;
            }
            set
            {
                if (_closeParenToken != value)
                {
                    _closeParenToken = value;
                    _closeParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseParenTokenStr
        {
            get
            {
                if (_closeParenTokenIsChanged) return _closeParenTokenStr;
                return _closeParenTokenStr = _closeParenToken.Text;
            }
            set
            {
                if (_closeParenTokenStr != value)
                {
                    _closeParenTokenStr = value;
                    IsChanged = true;
                    _closeParenTokenIsChanged = true;
                }
            }
        }

        public StatementSyntax Statement
        {
            get
            {
                if (_statementIsChanged)
                {
                    _statement = SyntaxFactoryStr.ParseStatementSyntax(StatementStr);
                    _statementIsChanged = false;
                    _taStatement = null;
                }
                else if (_taStatement != null && _taStatement.IsChanged)
                {
                    _statement = (StatementSyntax) _taStatement.Node;
                }
                return _statement;
            }
            set
            {
                if (_statement != value)
                {
                    _statement = value;
                    _statementIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StatementStr
        {
            get
            {
                if (_taStatement != null && _taStatement.IsChanged)
                    Statement = (StatementSyntax) _taStatement.Node;
                if (_statementIsChanged) return _statementStr;
                return _statementStr = _statement?.ToFullString();
            }
            set
            {
                if (_taStatement != null && _taStatement.IsChanged)
                {
                    Statement = (StatementSyntax) _taStatement.Node;
                    _statementStr = _statement?.ToFullString();
                }
                if (_statementStr != value)
                {
                    _statementStr = value;
                    IsChanged = true;
                    _statementIsChanged = true;
                    _taStatement = null;
                }
            }
        }

        public TameStatementSyntax TaStatement
        {
            get
            {
                if (_taStatement == null && Statement != null)
                    if (Statement is ForEachVariableStatementSyntax)
                    {
                        var loc =
                            new TameForEachVariableStatementSyntax((ForEachVariableStatementSyntax) Statement)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ForEachStatementSyntax)
                    {
                        var loc = new TameForEachStatementSyntax((ForEachStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LocalDeclarationStatementSyntax)
                    {
                        var loc =
                            new TameLocalDeclarationStatementSyntax((LocalDeclarationStatementSyntax) Statement)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LocalFunctionStatementSyntax)
                    {
                        var loc =
                            new TameLocalFunctionStatementSyntax((LocalFunctionStatementSyntax) Statement)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ExpressionStatementSyntax)
                    {
                        var loc =
                            new TameExpressionStatementSyntax((ExpressionStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ContinueStatementSyntax)
                    {
                        var loc =
                            new TameContinueStatementSyntax((ContinueStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is CheckedStatementSyntax)
                    {
                        var loc = new TameCheckedStatementSyntax((CheckedStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LabeledStatementSyntax)
                    {
                        var loc = new TameLabeledStatementSyntax((LabeledStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ReturnStatementSyntax)
                    {
                        var loc = new TameReturnStatementSyntax((ReturnStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is SwitchStatementSyntax)
                    {
                        var loc = new TameSwitchStatementSyntax((SwitchStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is UnsafeStatementSyntax)
                    {
                        var loc = new TameUnsafeStatementSyntax((UnsafeStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is BreakStatementSyntax)
                    {
                        var loc = new TameBreakStatementSyntax((BreakStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is EmptyStatementSyntax)
                    {
                        var loc = new TameEmptyStatementSyntax((EmptyStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is FixedStatementSyntax)
                    {
                        var loc = new TameFixedStatementSyntax((FixedStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ThrowStatementSyntax)
                    {
                        var loc = new TameThrowStatementSyntax((ThrowStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is UsingStatementSyntax)
                    {
                        var loc = new TameUsingStatementSyntax((UsingStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is WhileStatementSyntax)
                    {
                        var loc = new TameWhileStatementSyntax((WhileStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is YieldStatementSyntax)
                    {
                        var loc = new TameYieldStatementSyntax((YieldStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is GotoStatementSyntax)
                    {
                        var loc = new TameGotoStatementSyntax((GotoStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is LockStatementSyntax)
                    {
                        var loc = new TameLockStatementSyntax((LockStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is ForStatementSyntax)
                    {
                        var loc = new TameForStatementSyntax((ForStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is TryStatementSyntax)
                    {
                        var loc = new TameTryStatementSyntax((TryStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is DoStatementSyntax)
                    {
                        var loc = new TameDoStatementSyntax((DoStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is IfStatementSyntax)
                    {
                        var loc = new TameIfStatementSyntax((IfStatementSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                    else if (Statement is BlockSyntax)
                    {
                        var loc = new TameBlockSyntax((BlockSyntax) Statement) {TaParent = this};
                        loc.AddChildren();
                        _taStatement = loc;
                    }
                return _taStatement;
            }
            set
            {
                if (_taStatement != value)
                {
                    _taStatement = value;
                    if (_taStatement != null)
                    {
                        _taStatement.TaParent = this;
                        _taStatement.IsChanged = true;
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
            _taStatement = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _lockKeyword = ((LockStatementSyntax) Node).LockKeyword;
            _lockKeywordIsChanged = false;
            _openParenToken = ((LockStatementSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _expression = ((LockStatementSyntax) Node).Expression;
            _expressionIsChanged = false;
            _closeParenToken = ((LockStatementSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
            _statement = ((LockStatementSyntax) Node).Statement;
            _statementIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.LockStatement(LockKeyword, OpenParenToken, Expression, CloseParenToken, Statement);
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
            if (TaStatement != null) yield return TaStatement;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("LockKeywordStr", LockKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("ExpressionStr", ExpressionStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("StatementStr", StatementStr);
        }
    }
}