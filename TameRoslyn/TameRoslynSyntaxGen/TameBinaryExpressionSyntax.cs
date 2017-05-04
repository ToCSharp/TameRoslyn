// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBinaryExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "BinaryExpressionSyntax";
        private ExpressionSyntax _left;
        private bool _leftIsChanged;
        private string _leftStr;
        private SyntaxToken _operatorToken;
        private bool _operatorTokenIsChanged;
        private string _operatorTokenStr;
        private ExpressionSyntax _right;
        private bool _rightIsChanged;
        private string _rightStr;
        private TameExpressionSyntax _taLeft;
        private TameExpressionSyntax _taRight;

        public TameBinaryExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBinaryExpression(code);
            AddChildren();
        }

        public TameBinaryExpressionSyntax(BinaryExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBinaryExpressionSyntax()
        {
            LeftStr = DefaultValues.BinaryExpressionSyntaxLeftStr;
            OperatorTokenStr = DefaultValues.BinaryExpressionSyntaxOperatorTokenStr;
            RightStr = DefaultValues.BinaryExpressionSyntaxRightStr;
        }

        public override string RoslynTypeName => TypeName;

        public ExpressionSyntax Left
        {
            get
            {
                if (_leftIsChanged)
                {
                    _left = SyntaxFactoryStr.ParseExpressionSyntax(LeftStr);
                    _leftIsChanged = false;
                    _taLeft = null;
                }
                else if (_taLeft != null && _taLeft.IsChanged)
                {
                    _left = (ExpressionSyntax) _taLeft.Node;
                }
                return _left;
            }
            set
            {
                if (_left != value)
                {
                    _left = value;
                    _leftIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LeftStr
        {
            get
            {
                if (_taLeft != null && _taLeft.IsChanged)
                    Left = (ExpressionSyntax) _taLeft.Node;
                if (_leftIsChanged) return _leftStr;
                return _leftStr = _left?.ToFullString();
            }
            set
            {
                if (_taLeft != null && _taLeft.IsChanged)
                {
                    Left = (ExpressionSyntax) _taLeft.Node;
                    _leftStr = _left?.ToFullString();
                }
                if (_leftStr != value)
                {
                    _leftStr = value;
                    IsChanged = true;
                    _leftIsChanged = true;
                    _taLeft = null;
                }
            }
        }

        public TameExpressionSyntax TaLeft
        {
            get
            {
                if (_taLeft == null && Left != null)
                    if (Left is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax((ParenthesizedLambdaExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is OmittedTypeArgumentSyntax)
                    {
                        var loc = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Left)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is IsPatternExpressionSyntax)
                    {
                        var loc = new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is RefValueExpressionSyntax)
                    {
                        var loc = new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is CheckedExpressionSyntax)
                    {
                        var loc = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is DefaultExpressionSyntax)
                    {
                        var loc = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is LiteralExpressionSyntax)
                    {
                        var loc = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is MakeRefExpressionSyntax)
                    {
                        var loc = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is RefTypeExpressionSyntax)
                    {
                        var loc = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                return _taLeft;
            }
            set
            {
                if (_taLeft != value)
                {
                    _taLeft = value;
                    if (_taLeft != null)
                    {
                        _taLeft.TaParent = this;
                        _taLeft.IsChanged = true;
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

        public ExpressionSyntax Right
        {
            get
            {
                if (_rightIsChanged)
                {
                    _right = SyntaxFactoryStr.ParseExpressionSyntax(RightStr);
                    _rightIsChanged = false;
                    _taRight = null;
                }
                else if (_taRight != null && _taRight.IsChanged)
                {
                    _right = (ExpressionSyntax) _taRight.Node;
                }
                return _right;
            }
            set
            {
                if (_right != value)
                {
                    _right = value;
                    _rightIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string RightStr
        {
            get
            {
                if (_taRight != null && _taRight.IsChanged)
                    Right = (ExpressionSyntax) _taRight.Node;
                if (_rightIsChanged) return _rightStr;
                return _rightStr = _right?.ToFullString();
            }
            set
            {
                if (_taRight != null && _taRight.IsChanged)
                {
                    Right = (ExpressionSyntax) _taRight.Node;
                    _rightStr = _right?.ToFullString();
                }
                if (_rightStr != value)
                {
                    _rightStr = value;
                    IsChanged = true;
                    _rightIsChanged = true;
                    _taRight = null;
                }
            }
        }

        public TameExpressionSyntax TaRight
        {
            get
            {
                if (_taRight == null && Right != null)
                    if (Right is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax((ParenthesizedLambdaExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Right)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is RefValueExpressionSyntax)
                    {
                        var loc = new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is CheckedExpressionSyntax)
                    {
                        var loc = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is DefaultExpressionSyntax)
                    {
                        var loc = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is LiteralExpressionSyntax)
                    {
                        var loc = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is MakeRefExpressionSyntax)
                    {
                        var loc = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is RefTypeExpressionSyntax)
                    {
                        var loc = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                return _taRight;
            }
            set
            {
                if (_taRight != value)
                {
                    _taRight = value;
                    if (_taRight != null)
                    {
                        _taRight.TaParent = this;
                        _taRight.IsChanged = true;
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
            _taLeft = null;
            _taRight = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _left = ((BinaryExpressionSyntax) Node).Left;
            _leftIsChanged = false;
            _operatorToken = ((BinaryExpressionSyntax) Node).OperatorToken;
            _operatorTokenIsChanged = false;
            _right = ((BinaryExpressionSyntax) Node).Right;
            _rightIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            return SyntaxFacts.GetBinaryExpression(TameSyntaxFacts.SyntaxKindFromStr(OperatorTokenStr));
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.BinaryExpression(GetKind(), Left, OperatorToken, Right);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaLeft != null) yield return TaLeft;
            if (TaRight != null) yield return TaRight;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("LeftStr", LeftStr);
            yield return ("OperatorTokenStr", OperatorTokenStr);
            yield return ("RightStr", RightStr);
        }
    }
}