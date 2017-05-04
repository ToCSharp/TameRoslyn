// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameGroupClauseSyntax : TameSelectOrGroupClauseSyntax
    {
        public new static string TypeName = "GroupClauseSyntax";
        private ExpressionSyntax _byExpression;
        private bool _byExpressionIsChanged;
        private string _byExpressionStr;
        private SyntaxToken _byKeyword;
        private bool _byKeywordIsChanged;
        private string _byKeywordStr;
        private ExpressionSyntax _groupExpression;
        private bool _groupExpressionIsChanged;
        private string _groupExpressionStr;
        private SyntaxToken _groupKeyword;
        private bool _groupKeywordIsChanged;
        private string _groupKeywordStr;
        private TameExpressionSyntax _taByExpression;
        private TameExpressionSyntax _taGroupExpression;

        public TameGroupClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseGroupClause(code);
            AddChildren();
        }

        public TameGroupClauseSyntax(GroupClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameGroupClauseSyntax()
        {
            GroupKeywordStr = DefaultValues.GroupClauseSyntaxGroupKeywordStr;
            GroupExpressionStr = DefaultValues.GroupClauseSyntaxGroupExpressionStr;
            ByKeywordStr = DefaultValues.GroupClauseSyntaxByKeywordStr;
            ByExpressionStr = DefaultValues.GroupClauseSyntaxByExpressionStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken GroupKeyword
        {
            get
            {
                if (_groupKeywordIsChanged)
                {
                    if (_groupKeywordStr == null) _groupKeyword = default(SyntaxToken);
                    else _groupKeyword = SyntaxFactoryStr.ParseSyntaxToken(_groupKeywordStr, SyntaxKind.GroupKeyword);
                    _groupKeywordIsChanged = false;
                }
                return _groupKeyword;
            }
            set
            {
                if (_groupKeyword != value)
                {
                    _groupKeyword = value;
                    _groupKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string GroupKeywordStr
        {
            get
            {
                if (_groupKeywordIsChanged) return _groupKeywordStr;
                return _groupKeywordStr = _groupKeyword.Text;
            }
            set
            {
                if (_groupKeywordStr != value)
                {
                    _groupKeywordStr = value;
                    IsChanged = true;
                    _groupKeywordIsChanged = true;
                }
            }
        }

        public ExpressionSyntax GroupExpression
        {
            get
            {
                if (_groupExpressionIsChanged)
                {
                    _groupExpression = SyntaxFactoryStr.ParseExpressionSyntax(GroupExpressionStr);
                    _groupExpressionIsChanged = false;
                    _taGroupExpression = null;
                }
                else if (_taGroupExpression != null && _taGroupExpression.IsChanged)
                {
                    _groupExpression = (ExpressionSyntax) _taGroupExpression.Node;
                }
                return _groupExpression;
            }
            set
            {
                if (_groupExpression != value)
                {
                    _groupExpression = value;
                    _groupExpressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string GroupExpressionStr
        {
            get
            {
                if (_taGroupExpression != null && _taGroupExpression.IsChanged)
                    GroupExpression = (ExpressionSyntax) _taGroupExpression.Node;
                if (_groupExpressionIsChanged) return _groupExpressionStr;
                return _groupExpressionStr = _groupExpression?.ToFullString();
            }
            set
            {
                if (_taGroupExpression != null && _taGroupExpression.IsChanged)
                {
                    GroupExpression = (ExpressionSyntax) _taGroupExpression.Node;
                    _groupExpressionStr = _groupExpression?.ToFullString();
                }
                if (_groupExpressionStr != value)
                {
                    _groupExpressionStr = value;
                    IsChanged = true;
                    _groupExpressionIsChanged = true;
                    _taGroupExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaGroupExpression
        {
            get
            {
                if (_taGroupExpression == null && GroupExpression != null)
                    if (GroupExpression is IdentifierNameSyntax)
                    {
                        var loc =
                            new TameIdentifierNameSyntax((IdentifierNameSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is BaseExpressionSyntax)
                    {
                        var loc =
                            new TameBaseExpressionSyntax((BaseExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is PredefinedTypeSyntax)
                    {
                        var loc =
                            new TamePredefinedTypeSyntax((PredefinedTypeSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ThisExpressionSyntax)
                    {
                        var loc =
                            new TameThisExpressionSyntax((ThisExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax(
                                (ConditionalAccessExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax(
                                (OmittedArraySizeExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) GroupExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax(
                                (CheckedExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax(
                                (DefaultExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax(
                                (LiteralExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax(
                                (MakeRefExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax(
                                (RefTypeExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is AwaitExpressionSyntax)
                    {
                        var loc =
                            new TameAwaitExpressionSyntax((AwaitExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is QueryExpressionSyntax)
                    {
                        var loc =
                            new TameQueryExpressionSyntax((QueryExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is ThrowExpressionSyntax)
                    {
                        var loc =
                            new TameThrowExpressionSyntax((ThrowExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is TupleExpressionSyntax)
                    {
                        var loc =
                            new TameTupleExpressionSyntax((TupleExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is CastExpressionSyntax)
                    {
                        var loc =
                            new TameCastExpressionSyntax((CastExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                    else if (GroupExpression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) GroupExpression) {TaParent = this};
                        loc.AddChildren();
                        _taGroupExpression = loc;
                    }
                return _taGroupExpression;
            }
            set
            {
                if (_taGroupExpression != value)
                {
                    _taGroupExpression = value;
                    if (_taGroupExpression != null)
                    {
                        _taGroupExpression.TaParent = this;
                        _taGroupExpression.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken ByKeyword
        {
            get
            {
                if (_byKeywordIsChanged)
                {
                    if (_byKeywordStr == null) _byKeyword = default(SyntaxToken);
                    else _byKeyword = SyntaxFactoryStr.ParseSyntaxToken(_byKeywordStr, SyntaxKind.ByKeyword);
                    _byKeywordIsChanged = false;
                }
                return _byKeyword;
            }
            set
            {
                if (_byKeyword != value)
                {
                    _byKeyword = value;
                    _byKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ByKeywordStr
        {
            get
            {
                if (_byKeywordIsChanged) return _byKeywordStr;
                return _byKeywordStr = _byKeyword.Text;
            }
            set
            {
                if (_byKeywordStr != value)
                {
                    _byKeywordStr = value;
                    IsChanged = true;
                    _byKeywordIsChanged = true;
                }
            }
        }

        public ExpressionSyntax ByExpression
        {
            get
            {
                if (_byExpressionIsChanged)
                {
                    _byExpression = SyntaxFactoryStr.ParseExpressionSyntax(ByExpressionStr);
                    _byExpressionIsChanged = false;
                    _taByExpression = null;
                }
                else if (_taByExpression != null && _taByExpression.IsChanged)
                {
                    _byExpression = (ExpressionSyntax) _taByExpression.Node;
                }
                return _byExpression;
            }
            set
            {
                if (_byExpression != value)
                {
                    _byExpression = value;
                    _byExpressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ByExpressionStr
        {
            get
            {
                if (_taByExpression != null && _taByExpression.IsChanged)
                    ByExpression = (ExpressionSyntax) _taByExpression.Node;
                if (_byExpressionIsChanged) return _byExpressionStr;
                return _byExpressionStr = _byExpression?.ToFullString();
            }
            set
            {
                if (_taByExpression != null && _taByExpression.IsChanged)
                {
                    ByExpression = (ExpressionSyntax) _taByExpression.Node;
                    _byExpressionStr = _byExpression?.ToFullString();
                }
                if (_byExpressionStr != value)
                {
                    _byExpressionStr = value;
                    IsChanged = true;
                    _byExpressionIsChanged = true;
                    _taByExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaByExpression
        {
            get
            {
                if (_taByExpression == null && ByExpression != null)
                    if (ByExpression is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax(
                                (ConditionalAccessExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) ByExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                    else if (ByExpression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) ByExpression) {TaParent = this};
                        loc.AddChildren();
                        _taByExpression = loc;
                    }
                return _taByExpression;
            }
            set
            {
                if (_taByExpression != value)
                {
                    _taByExpression = value;
                    if (_taByExpression != null)
                    {
                        _taByExpression.TaParent = this;
                        _taByExpression.IsChanged = true;
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
            _taGroupExpression = null;
            _taByExpression = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _groupKeyword = ((GroupClauseSyntax) Node).GroupKeyword;
            _groupKeywordIsChanged = false;
            _groupExpression = ((GroupClauseSyntax) Node).GroupExpression;
            _groupExpressionIsChanged = false;
            _byKeyword = ((GroupClauseSyntax) Node).ByKeyword;
            _byKeywordIsChanged = false;
            _byExpression = ((GroupClauseSyntax) Node).ByExpression;
            _byExpressionIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.GroupClause(GroupKeyword, GroupExpression, ByKeyword, ByExpression);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaGroupExpression != null) yield return TaGroupExpression;
            if (TaByExpression != null) yield return TaByExpression;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("GroupKeywordStr", GroupKeywordStr);
            yield return ("GroupExpressionStr", GroupExpressionStr);
            yield return ("ByKeywordStr", ByKeywordStr);
            yield return ("ByExpressionStr", ByExpressionStr);
        }
    }
}