// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameSwitchStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "SwitchStatementSyntax";
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private ExpressionSyntax _expression;
        private bool _expressionIsChanged;
        private string _expressionStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private SyntaxList<SwitchSectionSyntax> _sections;
        private int _sectionsCount;
        private bool _sectionsIsChanged;
        private string _sectionsStr;
        private SyntaxToken _switchKeyword;
        private bool _switchKeywordIsChanged;
        private string _switchKeywordStr;
        private TameExpressionSyntax _taExpression;
        private List<TameSwitchSectionSyntax> _taSections;

        public TameSwitchStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSwitchStatement(code);
            AddChildren();
        }

        public TameSwitchStatementSyntax(SwitchStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSwitchStatementSyntax()
        {
            SwitchKeywordStr = DefaultValues.SwitchStatementSyntaxSwitchKeywordStr;
            OpenParenTokenStr = DefaultValues.SwitchStatementSyntaxOpenParenTokenStr;
            ExpressionStr = DefaultValues.SwitchStatementSyntaxExpressionStr;
            CloseParenTokenStr = DefaultValues.SwitchStatementSyntaxCloseParenTokenStr;
            OpenBraceTokenStr = DefaultValues.SwitchStatementSyntaxOpenBraceTokenStr;
            SectionsStr = DefaultValues.SwitchStatementSyntaxSectionsStr;
            CloseBraceTokenStr = DefaultValues.SwitchStatementSyntaxCloseBraceTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken SwitchKeyword
        {
            get
            {
                if (_switchKeywordIsChanged)
                {
                    if (_switchKeywordStr == null) _switchKeyword = default(SyntaxToken);
                    else
                        _switchKeyword = SyntaxFactoryStr.ParseSyntaxToken(_switchKeywordStr, SyntaxKind.SwitchKeyword);
                    _switchKeywordIsChanged = false;
                }
                return _switchKeyword;
            }
            set
            {
                if (_switchKeyword != value)
                {
                    _switchKeyword = value;
                    _switchKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SwitchKeywordStr
        {
            get
            {
                if (_switchKeywordIsChanged) return _switchKeywordStr;
                return _switchKeywordStr = _switchKeyword.Text;
            }
            set
            {
                if (_switchKeywordStr != value)
                {
                    _switchKeywordStr = value;
                    IsChanged = true;
                    _switchKeywordIsChanged = true;
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

        public SyntaxToken OpenBraceToken
        {
            get
            {
                if (_openBraceTokenIsChanged)
                {
                    if (_openBraceTokenStr == null) _openBraceToken = default(SyntaxToken);
                    else
                        _openBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBraceTokenStr, SyntaxKind.OpenBraceToken);
                    _openBraceTokenIsChanged = false;
                }
                return _openBraceToken;
            }
            set
            {
                if (_openBraceToken != value)
                {
                    _openBraceToken = value;
                    _openBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBraceTokenStr
        {
            get
            {
                if (_openBraceTokenIsChanged) return _openBraceTokenStr;
                return _openBraceTokenStr = _openBraceToken.Text;
            }
            set
            {
                if (_openBraceTokenStr != value)
                {
                    _openBraceTokenStr = value;
                    IsChanged = true;
                    _openBraceTokenIsChanged = true;
                }
            }
        }

        public bool TaSectionsIsChanged { get; set; }

        public SyntaxList<SwitchSectionSyntax> Sections
        {
            get
            {
                if (TaSectionsIsChanged || _taSections != null &&
                    (_taSections.Count != _sectionsCount || _taSections.Any(v => v.IsChanged)))
                {
                    _sections = SyntaxFactory.List(TaSections?.Select(v => v.Node).Cast<SwitchSectionSyntax>());
                    TaSectionsIsChanged = false;
                }
                return _sections;
            }
            set
            {
                if (_sections != value)
                {
                    _sections = value;
                    TaSectionsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SectionsStr
        {
            get
            {
                if (_sectionsIsChanged) return _sectionsStr;
                return _sectionsStr = string.Join(", ", _sections.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _sectionsStr = value;
                    Sections = new SyntaxList<SwitchSectionSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameSwitchSectionSyntax> TaSections
        {
            get
            {
                if (_taSections == null)
                {
                    _taSections = new List<TameSwitchSectionSyntax>();
                    foreach (var item in _sections)
                        _taSections.Add(new TameSwitchSectionSyntax(item) {TaParent = this});
                }
                return _taSections;
            }
            set
            {
                if (_taSections != value)
                {
                    _taSections = value;
                    _taSections?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaSectionsIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                if (_closeBraceTokenIsChanged)
                {
                    if (_closeBraceTokenStr == null) _closeBraceToken = default(SyntaxToken);
                    else
                        _closeBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBraceTokenStr, SyntaxKind.CloseBraceToken);
                    _closeBraceTokenIsChanged = false;
                }
                return _closeBraceToken;
            }
            set
            {
                if (_closeBraceToken != value)
                {
                    _closeBraceToken = value;
                    _closeBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBraceTokenStr
        {
            get
            {
                if (_closeBraceTokenIsChanged) return _closeBraceTokenStr;
                return _closeBraceTokenStr = _closeBraceToken.Text;
            }
            set
            {
                if (_closeBraceTokenStr != value)
                {
                    _closeBraceTokenStr = value;
                    IsChanged = true;
                    _closeBraceTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taExpression = null;
            _taSections = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _switchKeyword = ((SwitchStatementSyntax) Node).SwitchKeyword;
            _switchKeywordIsChanged = false;
            _openParenToken = ((SwitchStatementSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _expression = ((SwitchStatementSyntax) Node).Expression;
            _expressionIsChanged = false;
            _closeParenToken = ((SwitchStatementSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
            _openBraceToken = ((SwitchStatementSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _sections = ((SwitchStatementSyntax) Node).Sections;
            _sectionsIsChanged = false;
            _sectionsCount = _sections.Count;
            _closeBraceToken = ((SwitchStatementSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaSections)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.SwitchStatement(SwitchKeyword, OpenParenToken, Expression, CloseParenToken,
                OpenBraceToken, Sections, CloseBraceToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaSections)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaExpression != null) yield return TaExpression;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("SwitchKeywordStr", SwitchKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("ExpressionStr", ExpressionStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("SectionsStr", SectionsStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
        }

        public TameSwitchStatementSyntax AddSection(TameSwitchSectionSyntax item)
        {
            item.TaParent = this;
            TaSections.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}