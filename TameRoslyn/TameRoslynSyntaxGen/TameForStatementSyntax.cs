// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameForStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "ForStatementSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private ExpressionSyntax _condition;
        private bool _conditionIsChanged;
        private string _conditionStr;
        private VariableDeclarationSyntax _declaration;
        private bool _declarationIsChanged;
        private string _declarationStr;
        private SyntaxToken _firstSemicolonToken;
        private bool _firstSemicolonTokenIsChanged;
        private string _firstSemicolonTokenStr;
        private SyntaxToken _forKeyword;
        private bool _forKeywordIsChanged;
        private string _forKeywordStr;
        private SeparatedSyntaxList<ExpressionSyntax> _incrementors;
        private int _incrementorsCount;
        private bool _incrementorsIsChanged;
        private string _incrementorsStr;
        private SeparatedSyntaxList<ExpressionSyntax> _initializers;
        private int _initializersCount;
        private bool _initializersIsChanged;
        private string _initializersStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private SyntaxToken _secondSemicolonToken;
        private bool _secondSemicolonTokenIsChanged;
        private string _secondSemicolonTokenStr;
        private StatementSyntax _statement;
        private bool _statementIsChanged;
        private string _statementStr;
        private TameExpressionSyntax _taCondition;
        private TameVariableDeclarationSyntax _taDeclaration;
        private List<TameExpressionSyntax> _taIncrementors;
        private List<TameExpressionSyntax> _taInitializers;
        private TameStatementSyntax _taStatement;

        public TameForStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseForStatement(code);
            AddChildren();
        }

        public TameForStatementSyntax(ForStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameForStatementSyntax()
        {
            ForKeywordStr = DefaultValues.ForStatementSyntaxForKeywordStr;
            OpenParenTokenStr = DefaultValues.ForStatementSyntaxOpenParenTokenStr;
            DeclarationStr = DefaultValues.ForStatementSyntaxDeclarationStr;
            InitializersStr = DefaultValues.ForStatementSyntaxInitializersStr;
            FirstSemicolonTokenStr = DefaultValues.ForStatementSyntaxFirstSemicolonTokenStr;
            ConditionStr = DefaultValues.ForStatementSyntaxConditionStr;
            SecondSemicolonTokenStr = DefaultValues.ForStatementSyntaxSecondSemicolonTokenStr;
            IncrementorsStr = DefaultValues.ForStatementSyntaxIncrementorsStr;
            CloseParenTokenStr = DefaultValues.ForStatementSyntaxCloseParenTokenStr;
            StatementStr = DefaultValues.ForStatementSyntaxStatementStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ForKeyword
        {
            get
            {
                if (_forKeywordIsChanged)
                {
                    if (_forKeywordStr == null) _forKeyword = default(SyntaxToken);
                    else _forKeyword = SyntaxFactoryStr.ParseSyntaxToken(_forKeywordStr, SyntaxKind.ForKeyword);
                    _forKeywordIsChanged = false;
                }
                return _forKeyword;
            }
            set
            {
                if (_forKeyword != value)
                {
                    _forKeyword = value;
                    _forKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ForKeywordStr
        {
            get
            {
                if (_forKeywordIsChanged) return _forKeywordStr;
                return _forKeywordStr = _forKeyword.Text;
            }
            set
            {
                if (_forKeywordStr != value)
                {
                    _forKeywordStr = value;
                    IsChanged = true;
                    _forKeywordIsChanged = true;
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

        public VariableDeclarationSyntax Declaration
        {
            get
            {
                if (_declarationIsChanged)
                {
                    _declaration = SyntaxFactoryStr.ParseVariableDeclarationSyntax(DeclarationStr);
                    _declarationIsChanged = false;
                    _taDeclaration = null;
                }
                else if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    _declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                }
                return _declaration;
            }
            set
            {
                if (_declaration != value)
                {
                    _declaration = value;
                    _declarationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DeclarationStr
        {
            get
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                if (_declarationIsChanged) return _declarationStr;
                return _declarationStr = _declaration?.ToFullString();
            }
            set
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                    _declarationStr = _declaration?.ToFullString();
                }
                if (_declarationStr != value)
                {
                    _declarationStr = value;
                    IsChanged = true;
                    _declarationIsChanged = true;
                    _taDeclaration = null;
                }
            }
        }

        public TameVariableDeclarationSyntax TaDeclaration
        {
            get
            {
                if (_taDeclaration == null && Declaration != null)
                {
                    _taDeclaration = new TameVariableDeclarationSyntax(Declaration) {TaParent = this};
                    _taDeclaration.AddChildren();
                }
                return _taDeclaration;
            }
            set
            {
                if (_taDeclaration != value)
                {
                    _taDeclaration = value;
                    if (_taDeclaration != null)
                    {
                        _taDeclaration.TaParent = this;
                        _taDeclaration.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public bool TaInitializersIsChanged { get; set; }

        public SeparatedSyntaxList<ExpressionSyntax> Initializers
        {
            get
            {
                if (TaInitializersIsChanged || _taInitializers != null &&
                    (_taInitializers.Count != _initializersCount || _taInitializers.Any(v => v.IsChanged)))
                {
                    _initializers =
                        SyntaxFactory.SeparatedList(TaInitializers?.Select(v => v.Node).Cast<ExpressionSyntax>());
                    TaInitializersIsChanged = false;
                }
                return _initializers;
            }
            set
            {
                if (_initializers != value)
                {
                    _initializers = value;
                    TaInitializersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string InitializersStr
        {
            get
            {
                if (_initializersIsChanged) return _initializersStr;
                return _initializersStr = string.Join(", ", _initializers.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _initializersStr = value;
                    Initializers = new SeparatedSyntaxList<ExpressionSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameExpressionSyntax> TaInitializers
        {
            get
            {
                if (_taInitializers == null)
                {
                    _taInitializers = new List<TameExpressionSyntax>();
                    foreach (var item in _initializers)
                        if (item is IdentifierNameSyntax)
                            _taInitializers.Add(
                                new TameIdentifierNameSyntax(item as IdentifierNameSyntax) {TaParent = this});
                        else if (item is GenericNameSyntax)
                            _taInitializers.Add(new TameGenericNameSyntax(item as GenericNameSyntax) {TaParent = this});
                        else if (item is ParenthesizedLambdaExpressionSyntax)
                            _taInitializers.Add(
                                new TameParenthesizedLambdaExpressionSyntax(
                                    item as ParenthesizedLambdaExpressionSyntax) {TaParent = this});
                        else if (item is SimpleLambdaExpressionSyntax)
                            _taInitializers.Add(
                                new TameSimpleLambdaExpressionSyntax(item as SimpleLambdaExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AliasQualifiedNameSyntax)
                            _taInitializers.Add(
                                new TameAliasQualifiedNameSyntax(item as AliasQualifiedNameSyntax) {TaParent = this});
                        else if (item is QualifiedNameSyntax)
                            _taInitializers.Add(
                                new TameQualifiedNameSyntax(item as QualifiedNameSyntax) {TaParent = this});
                        else if (item is AnonymousMethodExpressionSyntax)
                            _taInitializers.Add(
                                new TameAnonymousMethodExpressionSyntax(item as AnonymousMethodExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedTypeArgumentSyntax)
                            _taInitializers.Add(
                                new TameOmittedTypeArgumentSyntax(item as OmittedTypeArgumentSyntax) {TaParent = this});
                        else if (item is BaseExpressionSyntax)
                            _taInitializers.Add(
                                new TameBaseExpressionSyntax(item as BaseExpressionSyntax) {TaParent = this});
                        else if (item is PredefinedTypeSyntax)
                            _taInitializers.Add(
                                new TamePredefinedTypeSyntax(item as PredefinedTypeSyntax) {TaParent = this});
                        else if (item is ThisExpressionSyntax)
                            _taInitializers.Add(
                                new TameThisExpressionSyntax(item as ThisExpressionSyntax) {TaParent = this});
                        else if (item is NullableTypeSyntax)
                            _taInitializers.Add(
                                new TameNullableTypeSyntax(item as NullableTypeSyntax) {TaParent = this});
                        else if (item is PointerTypeSyntax)
                            _taInitializers.Add(new TamePointerTypeSyntax(item as PointerTypeSyntax) {TaParent = this});
                        else if (item is ArrayTypeSyntax)
                            _taInitializers.Add(new TameArrayTypeSyntax(item as ArrayTypeSyntax) {TaParent = this});
                        else if (item is TupleTypeSyntax)
                            _taInitializers.Add(new TameTupleTypeSyntax(item as TupleTypeSyntax) {TaParent = this});
                        else if (item is RefTypeSyntax)
                            _taInitializers.Add(new TameRefTypeSyntax(item as RefTypeSyntax) {TaParent = this});
                        else if (item is AnonymousObjectCreationExpressionSyntax)
                            _taInitializers.Add(
                                new TameAnonymousObjectCreationExpressionSyntax(
                                    item as AnonymousObjectCreationExpressionSyntax) {TaParent = this});
                        else if (item is StackAllocArrayCreationExpressionSyntax)
                            _taInitializers.Add(
                                new TameStackAllocArrayCreationExpressionSyntax(
                                    item as StackAllocArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is ImplicitArrayCreationExpressionSyntax)
                            _taInitializers.Add(
                                new TameImplicitArrayCreationExpressionSyntax(
                                    item as ImplicitArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is InterpolatedStringExpressionSyntax)
                            _taInitializers.Add(
                                new TameInterpolatedStringExpressionSyntax(item as InterpolatedStringExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalAccessExpressionSyntax)
                            _taInitializers.Add(
                                new TameConditionalAccessExpressionSyntax(item as ConditionalAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedArraySizeExpressionSyntax)
                            _taInitializers.Add(
                                new TameOmittedArraySizeExpressionSyntax(item as OmittedArraySizeExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementBindingExpressionSyntax)
                            _taInitializers.Add(
                                new TameElementBindingExpressionSyntax(item as ElementBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ObjectCreationExpressionSyntax)
                            _taInitializers.Add(
                                new TameObjectCreationExpressionSyntax(item as ObjectCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ArrayCreationExpressionSyntax)
                            _taInitializers.Add(
                                new TameArrayCreationExpressionSyntax(item as ArrayCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementAccessExpressionSyntax)
                            _taInitializers.Add(
                                new TameElementAccessExpressionSyntax(item as ElementAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberBindingExpressionSyntax)
                            _taInitializers.Add(
                                new TameMemberBindingExpressionSyntax(item as MemberBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ParenthesizedExpressionSyntax)
                            _taInitializers.Add(
                                new TameParenthesizedExpressionSyntax(item as ParenthesizedExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberAccessExpressionSyntax)
                            _taInitializers.Add(
                                new TameMemberAccessExpressionSyntax(item as MemberAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PostfixUnaryExpressionSyntax)
                            _taInitializers.Add(
                                new TamePostfixUnaryExpressionSyntax(item as PostfixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalExpressionSyntax)
                            _taInitializers.Add(
                                new TameConditionalExpressionSyntax(item as ConditionalExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DeclarationExpressionSyntax)
                            _taInitializers.Add(
                                new TameDeclarationExpressionSyntax(item as DeclarationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ImplicitElementAccessSyntax)
                            _taInitializers.Add(
                                new TameImplicitElementAccessSyntax(item as ImplicitElementAccessSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InitializerExpressionSyntax)
                            _taInitializers.Add(
                                new TameInitializerExpressionSyntax(item as InitializerExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PrefixUnaryExpressionSyntax)
                            _taInitializers.Add(
                                new TamePrefixUnaryExpressionSyntax(item as PrefixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AssignmentExpressionSyntax)
                            _taInitializers.Add(
                                new TameAssignmentExpressionSyntax(item as AssignmentExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InvocationExpressionSyntax)
                            _taInitializers.Add(
                                new TameInvocationExpressionSyntax(item as InvocationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is IsPatternExpressionSyntax)
                            _taInitializers.Add(
                                new TameIsPatternExpressionSyntax(item as IsPatternExpressionSyntax) {TaParent = this});
                        else if (item is RefValueExpressionSyntax)
                            _taInitializers.Add(
                                new TameRefValueExpressionSyntax(item as RefValueExpressionSyntax) {TaParent = this});
                        else if (item is CheckedExpressionSyntax)
                            _taInitializers.Add(
                                new TameCheckedExpressionSyntax(item as CheckedExpressionSyntax) {TaParent = this});
                        else if (item is DefaultExpressionSyntax)
                            _taInitializers.Add(
                                new TameDefaultExpressionSyntax(item as DefaultExpressionSyntax) {TaParent = this});
                        else if (item is LiteralExpressionSyntax)
                            _taInitializers.Add(
                                new TameLiteralExpressionSyntax(item as LiteralExpressionSyntax) {TaParent = this});
                        else if (item is MakeRefExpressionSyntax)
                            _taInitializers.Add(
                                new TameMakeRefExpressionSyntax(item as MakeRefExpressionSyntax) {TaParent = this});
                        else if (item is RefTypeExpressionSyntax)
                            _taInitializers.Add(
                                new TameRefTypeExpressionSyntax(item as RefTypeExpressionSyntax) {TaParent = this});
                        else if (item is BinaryExpressionSyntax)
                            _taInitializers.Add(
                                new TameBinaryExpressionSyntax(item as BinaryExpressionSyntax) {TaParent = this});
                        else if (item is SizeOfExpressionSyntax)
                            _taInitializers.Add(
                                new TameSizeOfExpressionSyntax(item as SizeOfExpressionSyntax) {TaParent = this});
                        else if (item is TypeOfExpressionSyntax)
                            _taInitializers.Add(
                                new TameTypeOfExpressionSyntax(item as TypeOfExpressionSyntax) {TaParent = this});
                        else if (item is AwaitExpressionSyntax)
                            _taInitializers.Add(
                                new TameAwaitExpressionSyntax(item as AwaitExpressionSyntax) {TaParent = this});
                        else if (item is QueryExpressionSyntax)
                            _taInitializers.Add(
                                new TameQueryExpressionSyntax(item as QueryExpressionSyntax) {TaParent = this});
                        else if (item is ThrowExpressionSyntax)
                            _taInitializers.Add(
                                new TameThrowExpressionSyntax(item as ThrowExpressionSyntax) {TaParent = this});
                        else if (item is TupleExpressionSyntax)
                            _taInitializers.Add(
                                new TameTupleExpressionSyntax(item as TupleExpressionSyntax) {TaParent = this});
                        else if (item is CastExpressionSyntax)
                            _taInitializers.Add(
                                new TameCastExpressionSyntax(item as CastExpressionSyntax) {TaParent = this});
                        else if (item is RefExpressionSyntax)
                            _taInitializers.Add(
                                new TameRefExpressionSyntax(item as RefExpressionSyntax) {TaParent = this});
                        else if (item is ExpressionSyntax)
                            _taInitializers.Add(new TameExpressionSyntax(item) {TaParent = this});
                }
                return _taInitializers;
            }
            set
            {
                if (_taInitializers != value)
                {
                    _taInitializers = value;
                    _taInitializers?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaInitializersIsChanged = true;
                }
            }
        }

        public SyntaxToken FirstSemicolonToken
        {
            get
            {
                if (_firstSemicolonTokenIsChanged)
                {
                    _firstSemicolonToken = SyntaxFactoryStr.ParseSyntaxToken(FirstSemicolonTokenStr);
                    _firstSemicolonTokenIsChanged = false;
                }
                return _firstSemicolonToken;
            }
            set
            {
                if (_firstSemicolonToken != value)
                {
                    _firstSemicolonToken = value;
                    _firstSemicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FirstSemicolonTokenStr
        {
            get
            {
                if (_firstSemicolonTokenIsChanged) return _firstSemicolonTokenStr;
                return _firstSemicolonTokenStr = _firstSemicolonToken.Text;
            }
            set
            {
                if (_firstSemicolonTokenStr != value)
                {
                    _firstSemicolonTokenStr = value;
                    IsChanged = true;
                    _firstSemicolonTokenIsChanged = true;
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

        public SyntaxToken SecondSemicolonToken
        {
            get
            {
                if (_secondSemicolonTokenIsChanged)
                {
                    _secondSemicolonToken = SyntaxFactoryStr.ParseSyntaxToken(SecondSemicolonTokenStr);
                    _secondSemicolonTokenIsChanged = false;
                }
                return _secondSemicolonToken;
            }
            set
            {
                if (_secondSemicolonToken != value)
                {
                    _secondSemicolonToken = value;
                    _secondSemicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SecondSemicolonTokenStr
        {
            get
            {
                if (_secondSemicolonTokenIsChanged) return _secondSemicolonTokenStr;
                return _secondSemicolonTokenStr = _secondSemicolonToken.Text;
            }
            set
            {
                if (_secondSemicolonTokenStr != value)
                {
                    _secondSemicolonTokenStr = value;
                    IsChanged = true;
                    _secondSemicolonTokenIsChanged = true;
                }
            }
        }

        public bool TaIncrementorsIsChanged { get; set; }

        public SeparatedSyntaxList<ExpressionSyntax> Incrementors
        {
            get
            {
                if (TaIncrementorsIsChanged || _taIncrementors != null &&
                    (_taIncrementors.Count != _incrementorsCount || _taIncrementors.Any(v => v.IsChanged)))
                {
                    _incrementors =
                        SyntaxFactory.SeparatedList(TaIncrementors?.Select(v => v.Node).Cast<ExpressionSyntax>());
                    TaIncrementorsIsChanged = false;
                }
                return _incrementors;
            }
            set
            {
                if (_incrementors != value)
                {
                    _incrementors = value;
                    TaIncrementorsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IncrementorsStr
        {
            get
            {
                if (_incrementorsIsChanged) return _incrementorsStr;
                return _incrementorsStr = string.Join(", ", _incrementors.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _incrementorsStr = value;
                    Incrementors = new SeparatedSyntaxList<ExpressionSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameExpressionSyntax> TaIncrementors
        {
            get
            {
                if (_taIncrementors == null)
                {
                    _taIncrementors = new List<TameExpressionSyntax>();
                    foreach (var item in _incrementors)
                        if (item is IdentifierNameSyntax)
                            _taIncrementors.Add(
                                new TameIdentifierNameSyntax(item as IdentifierNameSyntax) {TaParent = this});
                        else if (item is GenericNameSyntax)
                            _taIncrementors.Add(new TameGenericNameSyntax(item as GenericNameSyntax) {TaParent = this});
                        else if (item is ParenthesizedLambdaExpressionSyntax)
                            _taIncrementors.Add(
                                new TameParenthesizedLambdaExpressionSyntax(
                                    item as ParenthesizedLambdaExpressionSyntax) {TaParent = this});
                        else if (item is SimpleLambdaExpressionSyntax)
                            _taIncrementors.Add(
                                new TameSimpleLambdaExpressionSyntax(item as SimpleLambdaExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AliasQualifiedNameSyntax)
                            _taIncrementors.Add(
                                new TameAliasQualifiedNameSyntax(item as AliasQualifiedNameSyntax) {TaParent = this});
                        else if (item is QualifiedNameSyntax)
                            _taIncrementors.Add(
                                new TameQualifiedNameSyntax(item as QualifiedNameSyntax) {TaParent = this});
                        else if (item is AnonymousMethodExpressionSyntax)
                            _taIncrementors.Add(
                                new TameAnonymousMethodExpressionSyntax(item as AnonymousMethodExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedTypeArgumentSyntax)
                            _taIncrementors.Add(
                                new TameOmittedTypeArgumentSyntax(item as OmittedTypeArgumentSyntax) {TaParent = this});
                        else if (item is BaseExpressionSyntax)
                            _taIncrementors.Add(
                                new TameBaseExpressionSyntax(item as BaseExpressionSyntax) {TaParent = this});
                        else if (item is PredefinedTypeSyntax)
                            _taIncrementors.Add(
                                new TamePredefinedTypeSyntax(item as PredefinedTypeSyntax) {TaParent = this});
                        else if (item is ThisExpressionSyntax)
                            _taIncrementors.Add(
                                new TameThisExpressionSyntax(item as ThisExpressionSyntax) {TaParent = this});
                        else if (item is NullableTypeSyntax)
                            _taIncrementors.Add(
                                new TameNullableTypeSyntax(item as NullableTypeSyntax) {TaParent = this});
                        else if (item is PointerTypeSyntax)
                            _taIncrementors.Add(new TamePointerTypeSyntax(item as PointerTypeSyntax) {TaParent = this});
                        else if (item is ArrayTypeSyntax)
                            _taIncrementors.Add(new TameArrayTypeSyntax(item as ArrayTypeSyntax) {TaParent = this});
                        else if (item is TupleTypeSyntax)
                            _taIncrementors.Add(new TameTupleTypeSyntax(item as TupleTypeSyntax) {TaParent = this});
                        else if (item is RefTypeSyntax)
                            _taIncrementors.Add(new TameRefTypeSyntax(item as RefTypeSyntax) {TaParent = this});
                        else if (item is AnonymousObjectCreationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameAnonymousObjectCreationExpressionSyntax(
                                    item as AnonymousObjectCreationExpressionSyntax) {TaParent = this});
                        else if (item is StackAllocArrayCreationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameStackAllocArrayCreationExpressionSyntax(
                                    item as StackAllocArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is ImplicitArrayCreationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameImplicitArrayCreationExpressionSyntax(
                                    item as ImplicitArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is InterpolatedStringExpressionSyntax)
                            _taIncrementors.Add(
                                new TameInterpolatedStringExpressionSyntax(item as InterpolatedStringExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalAccessExpressionSyntax)
                            _taIncrementors.Add(
                                new TameConditionalAccessExpressionSyntax(item as ConditionalAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedArraySizeExpressionSyntax)
                            _taIncrementors.Add(
                                new TameOmittedArraySizeExpressionSyntax(item as OmittedArraySizeExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementBindingExpressionSyntax)
                            _taIncrementors.Add(
                                new TameElementBindingExpressionSyntax(item as ElementBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ObjectCreationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameObjectCreationExpressionSyntax(item as ObjectCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ArrayCreationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameArrayCreationExpressionSyntax(item as ArrayCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementAccessExpressionSyntax)
                            _taIncrementors.Add(
                                new TameElementAccessExpressionSyntax(item as ElementAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberBindingExpressionSyntax)
                            _taIncrementors.Add(
                                new TameMemberBindingExpressionSyntax(item as MemberBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ParenthesizedExpressionSyntax)
                            _taIncrementors.Add(
                                new TameParenthesizedExpressionSyntax(item as ParenthesizedExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberAccessExpressionSyntax)
                            _taIncrementors.Add(
                                new TameMemberAccessExpressionSyntax(item as MemberAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PostfixUnaryExpressionSyntax)
                            _taIncrementors.Add(
                                new TamePostfixUnaryExpressionSyntax(item as PostfixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalExpressionSyntax)
                            _taIncrementors.Add(
                                new TameConditionalExpressionSyntax(item as ConditionalExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DeclarationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameDeclarationExpressionSyntax(item as DeclarationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ImplicitElementAccessSyntax)
                            _taIncrementors.Add(
                                new TameImplicitElementAccessSyntax(item as ImplicitElementAccessSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InitializerExpressionSyntax)
                            _taIncrementors.Add(
                                new TameInitializerExpressionSyntax(item as InitializerExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PrefixUnaryExpressionSyntax)
                            _taIncrementors.Add(
                                new TamePrefixUnaryExpressionSyntax(item as PrefixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AssignmentExpressionSyntax)
                            _taIncrementors.Add(
                                new TameAssignmentExpressionSyntax(item as AssignmentExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InvocationExpressionSyntax)
                            _taIncrementors.Add(
                                new TameInvocationExpressionSyntax(item as InvocationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is IsPatternExpressionSyntax)
                            _taIncrementors.Add(
                                new TameIsPatternExpressionSyntax(item as IsPatternExpressionSyntax) {TaParent = this});
                        else if (item is RefValueExpressionSyntax)
                            _taIncrementors.Add(
                                new TameRefValueExpressionSyntax(item as RefValueExpressionSyntax) {TaParent = this});
                        else if (item is CheckedExpressionSyntax)
                            _taIncrementors.Add(
                                new TameCheckedExpressionSyntax(item as CheckedExpressionSyntax) {TaParent = this});
                        else if (item is DefaultExpressionSyntax)
                            _taIncrementors.Add(
                                new TameDefaultExpressionSyntax(item as DefaultExpressionSyntax) {TaParent = this});
                        else if (item is LiteralExpressionSyntax)
                            _taIncrementors.Add(
                                new TameLiteralExpressionSyntax(item as LiteralExpressionSyntax) {TaParent = this});
                        else if (item is MakeRefExpressionSyntax)
                            _taIncrementors.Add(
                                new TameMakeRefExpressionSyntax(item as MakeRefExpressionSyntax) {TaParent = this});
                        else if (item is RefTypeExpressionSyntax)
                            _taIncrementors.Add(
                                new TameRefTypeExpressionSyntax(item as RefTypeExpressionSyntax) {TaParent = this});
                        else if (item is BinaryExpressionSyntax)
                            _taIncrementors.Add(
                                new TameBinaryExpressionSyntax(item as BinaryExpressionSyntax) {TaParent = this});
                        else if (item is SizeOfExpressionSyntax)
                            _taIncrementors.Add(
                                new TameSizeOfExpressionSyntax(item as SizeOfExpressionSyntax) {TaParent = this});
                        else if (item is TypeOfExpressionSyntax)
                            _taIncrementors.Add(
                                new TameTypeOfExpressionSyntax(item as TypeOfExpressionSyntax) {TaParent = this});
                        else if (item is AwaitExpressionSyntax)
                            _taIncrementors.Add(
                                new TameAwaitExpressionSyntax(item as AwaitExpressionSyntax) {TaParent = this});
                        else if (item is QueryExpressionSyntax)
                            _taIncrementors.Add(
                                new TameQueryExpressionSyntax(item as QueryExpressionSyntax) {TaParent = this});
                        else if (item is ThrowExpressionSyntax)
                            _taIncrementors.Add(
                                new TameThrowExpressionSyntax(item as ThrowExpressionSyntax) {TaParent = this});
                        else if (item is TupleExpressionSyntax)
                            _taIncrementors.Add(
                                new TameTupleExpressionSyntax(item as TupleExpressionSyntax) {TaParent = this});
                        else if (item is CastExpressionSyntax)
                            _taIncrementors.Add(
                                new TameCastExpressionSyntax(item as CastExpressionSyntax) {TaParent = this});
                        else if (item is RefExpressionSyntax)
                            _taIncrementors.Add(
                                new TameRefExpressionSyntax(item as RefExpressionSyntax) {TaParent = this});
                        else if (item is ExpressionSyntax)
                            _taIncrementors.Add(new TameExpressionSyntax(item) {TaParent = this});
                }
                return _taIncrementors;
            }
            set
            {
                if (_taIncrementors != value)
                {
                    _taIncrementors = value;
                    _taIncrementors?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaIncrementorsIsChanged = true;
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
            _taDeclaration = null;
            _taInitializers = null;
            _taCondition = null;
            _taIncrementors = null;
            _taStatement = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _forKeyword = ((ForStatementSyntax) Node).ForKeyword;
            _forKeywordIsChanged = false;
            _openParenToken = ((ForStatementSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _declaration = ((ForStatementSyntax) Node).Declaration;
            _declarationIsChanged = false;
            _initializers = ((ForStatementSyntax) Node).Initializers;
            _initializersIsChanged = false;
            _initializersCount = _initializers.Count;
            _firstSemicolonToken = ((ForStatementSyntax) Node).FirstSemicolonToken;
            _firstSemicolonTokenIsChanged = false;
            _condition = ((ForStatementSyntax) Node).Condition;
            _conditionIsChanged = false;
            _secondSemicolonToken = ((ForStatementSyntax) Node).SecondSemicolonToken;
            _secondSemicolonTokenIsChanged = false;
            _incrementors = ((ForStatementSyntax) Node).Incrementors;
            _incrementorsIsChanged = false;
            _incrementorsCount = _incrementors.Count;
            _closeParenToken = ((ForStatementSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
            _statement = ((ForStatementSyntax) Node).Statement;
            _statementIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaInitializers)
                item.SetNotChanged();
            foreach (var item in TaIncrementors)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ForStatement(ForKeyword, OpenParenToken, Declaration, Initializers,
                FirstSemicolonToken, Condition, SecondSemicolonToken, Incrementors, CloseParenToken, Statement);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaInitializers)
                yield return item;
            foreach (var item in TaIncrementors)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaDeclaration != null) yield return TaDeclaration;
            if (TaCondition != null) yield return TaCondition;
            if (TaStatement != null) yield return TaStatement;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ForKeywordStr", ForKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("InitializersStr", InitializersStr);
            yield return ("FirstSemicolonTokenStr", FirstSemicolonTokenStr);
            yield return ("ConditionStr", ConditionStr);
            yield return ("SecondSemicolonTokenStr", SecondSemicolonTokenStr);
            yield return ("IncrementorsStr", IncrementorsStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("StatementStr", StatementStr);
        }

        public TameForStatementSyntax AddInitializer(TameExpressionSyntax item)
        {
            item.TaParent = this;
            TaInitializers.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameForStatementSyntax AddIncrementor(TameExpressionSyntax item)
        {
            item.TaParent = this;
            TaIncrementors.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}