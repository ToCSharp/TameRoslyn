// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameIfStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "IfStatementSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private ExpressionSyntax _condition;
        private bool _conditionIsChanged;
        private string _conditionStr;
        private ElseClauseSyntax _else;
        private bool _elseIsChanged;
        private string _elseStr;
        private SyntaxToken _ifKeyword;
        private bool _ifKeywordIsChanged;
        private string _ifKeywordStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private StatementSyntax _statement;
        private bool _statementIsChanged;
        private string _statementStr;
        private TameExpressionSyntax _taCondition;
        private TameElseClauseSyntax _taElse;
        private TameStatementSyntax _taStatement;

        public TameIfStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseIfStatement(code);
            AddChildren();
        }

        public TameIfStatementSyntax(IfStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameIfStatementSyntax()
        {
            IfKeywordStr = DefaultValues.IfStatementSyntaxIfKeywordStr;
            OpenParenTokenStr = DefaultValues.IfStatementSyntaxOpenParenTokenStr;
            ConditionStr = DefaultValues.IfStatementSyntaxConditionStr;
            CloseParenTokenStr = DefaultValues.IfStatementSyntaxCloseParenTokenStr;
            StatementStr = DefaultValues.IfStatementSyntaxStatementStr;
            ElseStr = DefaultValues.IfStatementSyntaxElseStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken IfKeyword
        {
            get
            {
                if (_ifKeywordIsChanged)
                {
                    if (_ifKeywordStr == null) _ifKeyword = default(SyntaxToken);
                    else _ifKeyword = SyntaxFactoryStr.ParseSyntaxToken(_ifKeywordStr, SyntaxKind.IfKeyword);
                    _ifKeywordIsChanged = false;
                }
                return _ifKeyword;
            }
            set
            {
                if (_ifKeyword != value)
                {
                    _ifKeyword = value;
                    _ifKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IfKeywordStr
        {
            get
            {
                if (_ifKeywordIsChanged) return _ifKeywordStr;
                return _ifKeywordStr = _ifKeyword.Text;
            }
            set
            {
                if (_ifKeywordStr != value)
                {
                    _ifKeywordStr = value;
                    IsChanged = true;
                    _ifKeywordIsChanged = true;
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

        public ElseClauseSyntax Else
        {
            get
            {
                if (_elseIsChanged)
                {
                    _else = SyntaxFactoryStr.ParseElseClauseSyntax(ElseStr);
                    _elseIsChanged = false;
                    _taElse = null;
                }
                else if (_taElse != null && _taElse.IsChanged)
                {
                    _else = (ElseClauseSyntax) _taElse.Node;
                }
                return _else;
            }
            set
            {
                if (_else != value)
                {
                    _else = value;
                    _elseIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ElseStr
        {
            get
            {
                if (_taElse != null && _taElse.IsChanged)
                    Else = (ElseClauseSyntax) _taElse.Node;
                if (_elseIsChanged) return _elseStr;
                return _elseStr = _else?.ToFullString();
            }
            set
            {
                if (_taElse != null && _taElse.IsChanged)
                {
                    Else = (ElseClauseSyntax) _taElse.Node;
                    _elseStr = _else?.ToFullString();
                }
                if (_elseStr != value)
                {
                    _elseStr = value;
                    IsChanged = true;
                    _elseIsChanged = true;
                    _taElse = null;
                }
            }
        }

        public TameElseClauseSyntax TaElse
        {
            get
            {
                if (_taElse == null && Else != null)
                {
                    _taElse = new TameElseClauseSyntax(Else) {TaParent = this};
                    _taElse.AddChildren();
                }
                return _taElse;
            }
            set
            {
                if (_taElse != value)
                {
                    _taElse = value;
                    if (_taElse != null)
                    {
                        _taElse.TaParent = this;
                        _taElse.IsChanged = true;
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
            _taStatement = null;
            _taElse = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _ifKeyword = ((IfStatementSyntax) Node).IfKeyword;
            _ifKeywordIsChanged = false;
            _openParenToken = ((IfStatementSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _condition = ((IfStatementSyntax) Node).Condition;
            _conditionIsChanged = false;
            _closeParenToken = ((IfStatementSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
            _statement = ((IfStatementSyntax) Node).Statement;
            _statementIsChanged = false;
            _else = ((IfStatementSyntax) Node).Else;
            _elseIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.IfStatement(IfKeyword, OpenParenToken, Condition, CloseParenToken, Statement, Else);
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
            if (TaStatement != null) yield return TaStatement;
            if (TaElse != null) yield return TaElse;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IfKeywordStr", IfKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("ConditionStr", ConditionStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("StatementStr", StatementStr);
            yield return ("ElseStr", ElseStr);
        }
    }
}