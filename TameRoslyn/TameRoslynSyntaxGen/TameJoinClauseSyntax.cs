// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameJoinClauseSyntax : TameQueryClauseSyntax, IHaveIdentifier
    {
        public new static string TypeName = "JoinClauseSyntax";
        private SyntaxToken _equalsKeyword;
        private bool _equalsKeywordIsChanged;
        private string _equalsKeywordStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private ExpressionSyntax _inExpression;
        private bool _inExpressionIsChanged;
        private string _inExpressionStr;
        private SyntaxToken _inKeyword;
        private bool _inKeywordIsChanged;
        private string _inKeywordStr;
        private JoinIntoClauseSyntax _into;
        private bool _intoIsChanged;
        private string _intoStr;
        private SyntaxToken _joinKeyword;
        private bool _joinKeywordIsChanged;
        private string _joinKeywordStr;
        private ExpressionSyntax _leftExpression;
        private bool _leftExpressionIsChanged;
        private string _leftExpressionStr;
        private SyntaxToken _onKeyword;
        private bool _onKeywordIsChanged;
        private string _onKeywordStr;
        private ExpressionSyntax _rightExpression;
        private bool _rightExpressionIsChanged;
        private string _rightExpressionStr;
        private TameExpressionSyntax _taInExpression;
        private TameJoinIntoClauseSyntax _taInto;
        private TameExpressionSyntax _taLeftExpression;
        private TameExpressionSyntax _taRightExpression;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameJoinClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseJoinClause(code);
            AddChildren();
        }

        public TameJoinClauseSyntax(JoinClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameJoinClauseSyntax()
        {
            // JoinKeywordStr = DefaultValues.JoinClauseSyntaxJoinKeywordStr;
            // TypeStr = DefaultValues.JoinClauseSyntaxTypeStr;
            // IdentifierStr = DefaultValues.JoinClauseSyntaxIdentifierStr;
            // InKeywordStr = DefaultValues.JoinClauseSyntaxInKeywordStr;
            // InExpressionStr = DefaultValues.JoinClauseSyntaxInExpressionStr;
            // OnKeywordStr = DefaultValues.JoinClauseSyntaxOnKeywordStr;
            // LeftExpressionStr = DefaultValues.JoinClauseSyntaxLeftExpressionStr;
            // EqualsKeywordStr = DefaultValues.JoinClauseSyntaxEqualsKeywordStr;
            // RightExpressionStr = DefaultValues.JoinClauseSyntaxRightExpressionStr;
            // IntoStr = DefaultValues.JoinClauseSyntaxIntoStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken JoinKeyword
        {
            get
            {
                if (_joinKeywordIsChanged)
                {
                    if (_joinKeywordStr == null) _joinKeyword = default(SyntaxToken);
                    else _joinKeyword = SyntaxFactoryStr.ParseSyntaxToken(_joinKeywordStr, SyntaxKind.JoinKeyword);
                    _joinKeywordIsChanged = false;
                }
                return _joinKeyword;
            }
            set
            {
                if (_joinKeyword != value)
                {
                    _joinKeyword = value;
                    _joinKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string JoinKeywordStr
        {
            get
            {
                if (_joinKeywordIsChanged) return _joinKeywordStr;
                return _joinKeywordStr = _joinKeyword.Text;
            }
            set
            {
                if (_joinKeywordStr != value)
                {
                    _joinKeywordStr = value;
                    IsChanged = true;
                    _joinKeywordIsChanged = true;
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

        public SyntaxToken InKeyword
        {
            get
            {
                if (_inKeywordIsChanged)
                {
                    if (_inKeywordStr == null) _inKeyword = default(SyntaxToken);
                    else _inKeyword = SyntaxFactoryStr.ParseSyntaxToken(_inKeywordStr, SyntaxKind.InKeyword);
                    _inKeywordIsChanged = false;
                }
                return _inKeyword;
            }
            set
            {
                if (_inKeyword != value)
                {
                    _inKeyword = value;
                    _inKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string InKeywordStr
        {
            get
            {
                if (_inKeywordIsChanged) return _inKeywordStr;
                return _inKeywordStr = _inKeyword.Text;
            }
            set
            {
                if (_inKeywordStr != value)
                {
                    _inKeywordStr = value;
                    IsChanged = true;
                    _inKeywordIsChanged = true;
                }
            }
        }

        public ExpressionSyntax InExpression
        {
            get
            {
                if (_inExpressionIsChanged)
                {
                    _inExpression = SyntaxFactoryStr.ParseExpressionSyntax(InExpressionStr);
                    _inExpressionIsChanged = false;
                    _taInExpression = null;
                }
                else if (_taInExpression != null && _taInExpression.IsChanged)
                {
                    _inExpression = (ExpressionSyntax) _taInExpression.Node;
                }
                return _inExpression;
            }
            set
            {
                if (_inExpression != value)
                {
                    _inExpression = value;
                    _inExpressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string InExpressionStr
        {
            get
            {
                if (_taInExpression != null && _taInExpression.IsChanged)
                    InExpression = (ExpressionSyntax) _taInExpression.Node;
                if (_inExpressionIsChanged) return _inExpressionStr;
                return _inExpressionStr = _inExpression?.ToFullString();
            }
            set
            {
                if (_taInExpression != null && _taInExpression.IsChanged)
                {
                    InExpression = (ExpressionSyntax) _taInExpression.Node;
                    _inExpressionStr = _inExpression?.ToFullString();
                }
                if (_inExpressionStr != value)
                {
                    _inExpressionStr = value;
                    IsChanged = true;
                    _inExpressionIsChanged = true;
                    _taInExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaInExpression
        {
            get
            {
                if (_taInExpression == null && InExpression != null)
                    if (InExpression is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax(
                                (ConditionalAccessExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) InExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                    else if (InExpression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) InExpression) {TaParent = this};
                        loc.AddChildren();
                        _taInExpression = loc;
                    }
                return _taInExpression;
            }
            set
            {
                if (_taInExpression != value)
                {
                    _taInExpression = value;
                    if (_taInExpression != null)
                    {
                        _taInExpression.TaParent = this;
                        _taInExpression.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken OnKeyword
        {
            get
            {
                if (_onKeywordIsChanged)
                {
                    if (_onKeywordStr == null) _onKeyword = default(SyntaxToken);
                    else _onKeyword = SyntaxFactoryStr.ParseSyntaxToken(_onKeywordStr, SyntaxKind.OnKeyword);
                    _onKeywordIsChanged = false;
                }
                return _onKeyword;
            }
            set
            {
                if (_onKeyword != value)
                {
                    _onKeyword = value;
                    _onKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OnKeywordStr
        {
            get
            {
                if (_onKeywordIsChanged) return _onKeywordStr;
                return _onKeywordStr = _onKeyword.Text;
            }
            set
            {
                if (_onKeywordStr != value)
                {
                    _onKeywordStr = value;
                    IsChanged = true;
                    _onKeywordIsChanged = true;
                }
            }
        }

        public ExpressionSyntax LeftExpression
        {
            get
            {
                if (_leftExpressionIsChanged)
                {
                    _leftExpression = SyntaxFactoryStr.ParseExpressionSyntax(LeftExpressionStr);
                    _leftExpressionIsChanged = false;
                    _taLeftExpression = null;
                }
                else if (_taLeftExpression != null && _taLeftExpression.IsChanged)
                {
                    _leftExpression = (ExpressionSyntax) _taLeftExpression.Node;
                }
                return _leftExpression;
            }
            set
            {
                if (_leftExpression != value)
                {
                    _leftExpression = value;
                    _leftExpressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LeftExpressionStr
        {
            get
            {
                if (_taLeftExpression != null && _taLeftExpression.IsChanged)
                    LeftExpression = (ExpressionSyntax) _taLeftExpression.Node;
                if (_leftExpressionIsChanged) return _leftExpressionStr;
                return _leftExpressionStr = _leftExpression?.ToFullString();
            }
            set
            {
                if (_taLeftExpression != null && _taLeftExpression.IsChanged)
                {
                    LeftExpression = (ExpressionSyntax) _taLeftExpression.Node;
                    _leftExpressionStr = _leftExpression?.ToFullString();
                }
                if (_leftExpressionStr != value)
                {
                    _leftExpressionStr = value;
                    IsChanged = true;
                    _leftExpressionIsChanged = true;
                    _taLeftExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaLeftExpression
        {
            get
            {
                if (_taLeftExpression == null && LeftExpression != null)
                    if (LeftExpression is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax(
                                (ConditionalAccessExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax(
                                (OmittedArraySizeExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) LeftExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax((CheckedExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax((DefaultExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax((LiteralExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is AwaitExpressionSyntax)
                    {
                        var loc =
                            new TameAwaitExpressionSyntax((AwaitExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is QueryExpressionSyntax)
                    {
                        var loc =
                            new TameQueryExpressionSyntax((QueryExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is ThrowExpressionSyntax)
                    {
                        var loc =
                            new TameThrowExpressionSyntax((ThrowExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is TupleExpressionSyntax)
                    {
                        var loc =
                            new TameTupleExpressionSyntax((TupleExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                    else if (LeftExpression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) LeftExpression) {TaParent = this};
                        loc.AddChildren();
                        _taLeftExpression = loc;
                    }
                return _taLeftExpression;
            }
            set
            {
                if (_taLeftExpression != value)
                {
                    _taLeftExpression = value;
                    if (_taLeftExpression != null)
                    {
                        _taLeftExpression.TaParent = this;
                        _taLeftExpression.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken EqualsKeyword
        {
            get
            {
                if (_equalsKeywordIsChanged)
                {
                    if (_equalsKeywordStr == null) _equalsKeyword = default(SyntaxToken);
                    else
                        _equalsKeyword = SyntaxFactoryStr.ParseSyntaxToken(_equalsKeywordStr, SyntaxKind.EqualsKeyword);
                    _equalsKeywordIsChanged = false;
                }
                return _equalsKeyword;
            }
            set
            {
                if (_equalsKeyword != value)
                {
                    _equalsKeyword = value;
                    _equalsKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EqualsKeywordStr
        {
            get
            {
                if (_equalsKeywordIsChanged) return _equalsKeywordStr;
                return _equalsKeywordStr = _equalsKeyword.Text;
            }
            set
            {
                if (_equalsKeywordStr != value)
                {
                    _equalsKeywordStr = value;
                    IsChanged = true;
                    _equalsKeywordIsChanged = true;
                }
            }
        }

        public ExpressionSyntax RightExpression
        {
            get
            {
                if (_rightExpressionIsChanged)
                {
                    _rightExpression = SyntaxFactoryStr.ParseExpressionSyntax(RightExpressionStr);
                    _rightExpressionIsChanged = false;
                    _taRightExpression = null;
                }
                else if (_taRightExpression != null && _taRightExpression.IsChanged)
                {
                    _rightExpression = (ExpressionSyntax) _taRightExpression.Node;
                }
                return _rightExpression;
            }
            set
            {
                if (_rightExpression != value)
                {
                    _rightExpression = value;
                    _rightExpressionIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string RightExpressionStr
        {
            get
            {
                if (_taRightExpression != null && _taRightExpression.IsChanged)
                    RightExpression = (ExpressionSyntax) _taRightExpression.Node;
                if (_rightExpressionIsChanged) return _rightExpressionStr;
                return _rightExpressionStr = _rightExpression?.ToFullString();
            }
            set
            {
                if (_taRightExpression != null && _taRightExpression.IsChanged)
                {
                    RightExpression = (ExpressionSyntax) _taRightExpression.Node;
                    _rightExpressionStr = _rightExpression?.ToFullString();
                }
                if (_rightExpressionStr != value)
                {
                    _rightExpressionStr = value;
                    IsChanged = true;
                    _rightExpressionIsChanged = true;
                    _taRightExpression = null;
                }
            }
        }

        public TameExpressionSyntax TaRightExpression
        {
            get
            {
                if (_taRightExpression == null && RightExpression != null)
                    if (RightExpression is IdentifierNameSyntax)
                    {
                        var loc =
                            new TameIdentifierNameSyntax((IdentifierNameSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is BaseExpressionSyntax)
                    {
                        var loc =
                            new TameBaseExpressionSyntax((BaseExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is PredefinedTypeSyntax)
                    {
                        var loc =
                            new TamePredefinedTypeSyntax((PredefinedTypeSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ThisExpressionSyntax)
                    {
                        var loc =
                            new TameThisExpressionSyntax((ThisExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax(
                                (InterpolatedStringExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax(
                                (ConditionalAccessExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax(
                                (OmittedArraySizeExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) RightExpression)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is CheckedExpressionSyntax)
                    {
                        var loc =
                            new TameCheckedExpressionSyntax(
                                (CheckedExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is DefaultExpressionSyntax)
                    {
                        var loc =
                            new TameDefaultExpressionSyntax(
                                (DefaultExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is LiteralExpressionSyntax)
                    {
                        var loc =
                            new TameLiteralExpressionSyntax(
                                (LiteralExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is MakeRefExpressionSyntax)
                    {
                        var loc =
                            new TameMakeRefExpressionSyntax(
                                (MakeRefExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is RefTypeExpressionSyntax)
                    {
                        var loc =
                            new TameRefTypeExpressionSyntax(
                                (RefTypeExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is BinaryExpressionSyntax)
                    {
                        var loc =
                            new TameBinaryExpressionSyntax((BinaryExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is SizeOfExpressionSyntax)
                    {
                        var loc =
                            new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is TypeOfExpressionSyntax)
                    {
                        var loc =
                            new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is AwaitExpressionSyntax)
                    {
                        var loc =
                            new TameAwaitExpressionSyntax((AwaitExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is QueryExpressionSyntax)
                    {
                        var loc =
                            new TameQueryExpressionSyntax((QueryExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is ThrowExpressionSyntax)
                    {
                        var loc =
                            new TameThrowExpressionSyntax((ThrowExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is TupleExpressionSyntax)
                    {
                        var loc =
                            new TameTupleExpressionSyntax((TupleExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is CastExpressionSyntax)
                    {
                        var loc =
                            new TameCastExpressionSyntax((CastExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                    else if (RightExpression is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) RightExpression) {TaParent = this};
                        loc.AddChildren();
                        _taRightExpression = loc;
                    }
                return _taRightExpression;
            }
            set
            {
                if (_taRightExpression != value)
                {
                    _taRightExpression = value;
                    if (_taRightExpression != null)
                    {
                        _taRightExpression.TaParent = this;
                        _taRightExpression.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public JoinIntoClauseSyntax Into
        {
            get
            {
                if (_intoIsChanged)
                {
                    _into = SyntaxFactoryStr.ParseJoinIntoClauseSyntax(IntoStr);
                    _intoIsChanged = false;
                    _taInto = null;
                }
                else if (_taInto != null && _taInto.IsChanged)
                {
                    _into = (JoinIntoClauseSyntax) _taInto.Node;
                }
                return _into;
            }
            set
            {
                if (_into != value)
                {
                    _into = value;
                    _intoIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IntoStr
        {
            get
            {
                if (_taInto != null && _taInto.IsChanged)
                    Into = (JoinIntoClauseSyntax) _taInto.Node;
                if (_intoIsChanged) return _intoStr;
                return _intoStr = _into?.ToFullString();
            }
            set
            {
                if (_taInto != null && _taInto.IsChanged)
                {
                    Into = (JoinIntoClauseSyntax) _taInto.Node;
                    _intoStr = _into?.ToFullString();
                }
                if (_intoStr != value)
                {
                    _intoStr = value;
                    IsChanged = true;
                    _intoIsChanged = true;
                    _taInto = null;
                }
            }
        }

        public TameJoinIntoClauseSyntax TaInto
        {
            get
            {
                if (_taInto == null && Into != null)
                {
                    _taInto = new TameJoinIntoClauseSyntax(Into) {TaParent = this};
                    _taInto.AddChildren();
                }
                return _taInto;
            }
            set
            {
                if (_taInto != value)
                {
                    _taInto = value;
                    if (_taInto != null)
                    {
                        _taInto.TaParent = this;
                        _taInto.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken Identifier
        {
            get
            {
                if (_identifierIsChanged)
                {
                    _identifier = SyntaxFactoryStr.ParseSyntaxToken(IdentifierStr);
                    _identifierIsChanged = false;
                }
                return _identifier;
            }
            set
            {
                if (_identifier != value)
                {
                    _identifier = value;
                    _identifierIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IdentifierStr
        {
            get
            {
                if (_identifierIsChanged) return _identifierStr;
                return _identifierStr = _identifier.Text;
            }
            set
            {
                if (_identifierStr != value)
                {
                    _identifierStr = value;
                    IsChanged = true;
                    _identifierIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taType = null;
            _taInExpression = null;
            _taLeftExpression = null;
            _taRightExpression = null;
            _taInto = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _joinKeyword = ((JoinClauseSyntax) Node).JoinKeyword;
            _joinKeywordIsChanged = false;
            _type = ((JoinClauseSyntax) Node).Type;
            _typeIsChanged = false;
            _identifier = ((JoinClauseSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _inKeyword = ((JoinClauseSyntax) Node).InKeyword;
            _inKeywordIsChanged = false;
            _inExpression = ((JoinClauseSyntax) Node).InExpression;
            _inExpressionIsChanged = false;
            _onKeyword = ((JoinClauseSyntax) Node).OnKeyword;
            _onKeywordIsChanged = false;
            _leftExpression = ((JoinClauseSyntax) Node).LeftExpression;
            _leftExpressionIsChanged = false;
            _equalsKeyword = ((JoinClauseSyntax) Node).EqualsKeyword;
            _equalsKeywordIsChanged = false;
            _rightExpression = ((JoinClauseSyntax) Node).RightExpression;
            _rightExpressionIsChanged = false;
            _into = ((JoinClauseSyntax) Node).Into;
            _intoIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.JoinClause(JoinKeyword, Type, Identifier, InKeyword, InExpression, OnKeyword,
                LeftExpression, EqualsKeyword, RightExpression, Into);
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
            if (TaInExpression != null) yield return TaInExpression;
            if (TaLeftExpression != null) yield return TaLeftExpression;
            if (TaRightExpression != null) yield return TaRightExpression;
            if (TaInto != null) yield return TaInto;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("JoinKeywordStr", JoinKeywordStr);
            yield return ("TypeStr", TypeStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("InKeywordStr", InKeywordStr);
            yield return ("InExpressionStr", InExpressionStr);
            yield return ("OnKeywordStr", OnKeywordStr);
            yield return ("LeftExpressionStr", LeftExpressionStr);
            yield return ("EqualsKeywordStr", EqualsKeywordStr);
            yield return ("RightExpressionStr", RightExpressionStr);
            yield return ("IntoStr", IntoStr);
        }
    }
}