// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCatchFilterClauseSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "CatchFilterClauseSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private ExpressionSyntax _filterExpression;
        private bool _filterExpressionIsChanged;
        private string _filterExpressionStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private TameExpressionSyntax _taFilterExpression;
        private SyntaxToken _whenKeyword;
        private bool _whenKeywordIsChanged;
        private string _whenKeywordStr;

        public TameCatchFilterClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCatchFilterClause(code);
            AddChildren();
        }

        public TameCatchFilterClauseSyntax(CatchFilterClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCatchFilterClauseSyntax()
        {
            WhenKeywordStr = DefaultValues.CatchFilterClauseSyntaxWhenKeywordStr;
            OpenParenTokenStr = DefaultValues.CatchFilterClauseSyntaxOpenParenTokenStr;
            FilterExpressionStr = DefaultValues.CatchFilterClauseSyntaxFilterExpressionStr;
            CloseParenTokenStr = DefaultValues.CatchFilterClauseSyntaxCloseParenTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken WhenKeyword
        {
            get
            {
                if (_whenKeywordIsChanged)
                {
                    if (_whenKeywordStr == null) _whenKeyword = default(SyntaxToken);
                    else _whenKeyword = SyntaxFactoryStr.ParseSyntaxToken(_whenKeywordStr, SyntaxKind.WhenKeyword);
                    _whenKeywordIsChanged = false;
                }
                return _whenKeyword;
            }
            set
            {
                if (_whenKeyword != value)
                {
                    _whenKeyword = value;
                    _whenKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhenKeywordStr
        {
            get
            {
                if (_whenKeywordIsChanged) return _whenKeywordStr;
                return _whenKeywordStr = _whenKeyword.Text;
            }
            set
            {
                if (_whenKeywordStr != value)
                {
                    _whenKeywordStr = value;
                    IsChanged = true;
                    _whenKeywordIsChanged = true;
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

        public ExpressionSyntax FilterExpression
        {
            get
            {
                if (_filterExpressionIsChanged)
                {
                    _filterExpression = SyntaxFactoryStr.ParseExpressionSyntax(FilterExpressionStr);
                    _filterExpressionIsChanged = false;
                    _taFilterExpression = null;
                }
                else if (_taFilterExpression != null && _taFilterExpression.IsChanged)
                {
                    _filterExpression = (ExpressionSyntax) _taFilterExpression.Node;
                }
                return _filterExpression;
            }
            set
            {
                if (_filterExpression != value)
                {
                    _filterExpression = value;
                    _filterExpressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FilterExpressionStr
        {
            get
            {
                if (_taFilterExpression != null && _taFilterExpression.IsChanged)
                    FilterExpression = (ExpressionSyntax) _taFilterExpression.Node;
                if (_filterExpressionIsChanged) return _filterExpressionStr;
                return _filterExpressionStr = _filterExpression?.ToFullString();
            }
            set
            {
                if (_taFilterExpression != null && _taFilterExpression.IsChanged)
                {
                    FilterExpression = (ExpressionSyntax) _taFilterExpression.Node;
                    _filterExpressionStr = _filterExpression?.ToFullString();
                }
                if (_filterExpressionStr != value)
                {
                    _filterExpressionStr = value;
                    IsChanged = true;
                    _filterExpressionIsChanged = true;
                    _taFilterExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaFilterExpression
        {
            get
            {
                if (_taFilterExpression == null && FilterExpression != null)
                    if (FilterExpression is IdentifierNameSyntax)
                    {
                        var loc =
                            new TameIdentifierNameSyntax((IdentifierNameSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax(
                                (AnonymousMethodExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is BaseExpressionSyntax)
                    {
                        var loc =
                            new TameBaseExpressionSyntax((BaseExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is PredefinedTypeSyntax)
                    {
                        var loc =
                            new TamePredefinedTypeSyntax((PredefinedTypeSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ThisExpressionSyntax)
                    {
                        var loc =
                            new TameThisExpressionSyntax((ThisExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax(
                                (ConditionalAccessExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax(
                                (OmittedArraySizeExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) FilterExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is AwaitExpressionSyntax)
                    {
                        var loc =
                            new TameAwaitExpressionSyntax((AwaitExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is QueryExpressionSyntax)
                    {
                        var loc =
                            new TameQueryExpressionSyntax((QueryExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is ThrowExpressionSyntax)
                    {
                        var loc =
                            new TameThrowExpressionSyntax((ThrowExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is TupleExpressionSyntax)
                    {
                        var loc =
                            new TameTupleExpressionSyntax((TupleExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is CastExpressionSyntax)
                    {
                        var loc =
                            new TameCastExpressionSyntax((CastExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                    else if (FilterExpression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) FilterExpression) {TaParent = this};
                        loc.AddChildren();
                        _taFilterExpression = loc;
                    }
                return _taFilterExpression;
            }
            set
            {
                if (_taFilterExpression != value)
                {
                    _taFilterExpression = value;
                    if (_taFilterExpression != null)
                    {
                        _taFilterExpression.TaParent = this;
                        _taFilterExpression.IsChanged = true;
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

        public override void Clear()
        {
            _taFilterExpression = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _whenKeyword = ((CatchFilterClauseSyntax) Node).WhenKeyword;
            _whenKeywordIsChanged = false;
            _openParenToken = ((CatchFilterClauseSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _filterExpression = ((CatchFilterClauseSyntax) Node).FilterExpression;
            _filterExpressionIsChanged = false;
            _closeParenToken = ((CatchFilterClauseSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CatchFilterClause(WhenKeyword, OpenParenToken, FilterExpression, CloseParenToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaFilterExpression != null) yield return TaFilterExpression;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("WhenKeywordStr", WhenKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("FilterExpressionStr", FilterExpressionStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
        }
    }
}