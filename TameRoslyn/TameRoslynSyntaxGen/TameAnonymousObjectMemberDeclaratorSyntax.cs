// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAnonymousObjectMemberDeclaratorSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "AnonymousObjectMemberDeclaratorSyntax";
        private ExpressionSyntax _expression;
        private bool _expressionIsChanged;
        private string _expressionStr;
        private NameEqualsSyntax _nameEquals;
        private bool _nameEqualsIsChanged;
        private string _nameEqualsStr;
        private TameExpressionSyntax _taExpression;
        private TameNameEqualsSyntax _taNameEquals;

        public TameAnonymousObjectMemberDeclaratorSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAnonymousObjectMemberDeclarator(code);
            AddChildren();
        }

        public TameAnonymousObjectMemberDeclaratorSyntax(AnonymousObjectMemberDeclaratorSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAnonymousObjectMemberDeclaratorSyntax()
        {
            NameEqualsStr = DefaultValues.AnonymousObjectMemberDeclaratorSyntaxNameEqualsStr;
            ExpressionStr = DefaultValues.AnonymousObjectMemberDeclaratorSyntaxExpressionStr;
        }

        public override string RoslynTypeName => TypeName;

        public NameEqualsSyntax NameEquals
        {
            get
            {
                if (_nameEqualsIsChanged)
                {
                    _nameEquals = SyntaxFactoryStr.ParseNameEqualsSyntax(NameEqualsStr);
                    _nameEqualsIsChanged = false;
                    _taNameEquals = null;
                }
                else if (_taNameEquals != null && _taNameEquals.IsChanged)
                {
                    _nameEquals = (NameEqualsSyntax) _taNameEquals.Node;
                }
                return _nameEquals;
            }
            set
            {
                if (_nameEquals != value)
                {
                    _nameEquals = value;
                    _nameEqualsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NameEqualsStr
        {
            get
            {
                if (_taNameEquals != null && _taNameEquals.IsChanged)
                    NameEquals = (NameEqualsSyntax) _taNameEquals.Node;
                if (_nameEqualsIsChanged) return _nameEqualsStr;
                return _nameEqualsStr = _nameEquals?.ToFullString();
            }
            set
            {
                if (_taNameEquals != null && _taNameEquals.IsChanged)
                {
                    NameEquals = (NameEqualsSyntax) _taNameEquals.Node;
                    _nameEqualsStr = _nameEquals?.ToFullString();
                }
                if (_nameEqualsStr != value)
                {
                    _nameEqualsStr = value;
                    IsChanged = true;
                    _nameEqualsIsChanged = true;
                    _taNameEquals = null;
                }
            }
        }

        public TameNameEqualsSyntax TaNameEquals
        {
            get
            {
                if (_taNameEquals == null && NameEquals != null)
                {
                    _taNameEquals = new TameNameEqualsSyntax(NameEquals) {TaParent = this};
                    _taNameEquals.AddChildren();
                }
                return _taNameEquals;
            }
            set
            {
                if (_taNameEquals != value)
                {
                    _taNameEquals = value;
                    if (_taNameEquals != null)
                    {
                        _taNameEquals.TaParent = this;
                        _taNameEquals.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
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

        public override void Clear()
        {
            _taNameEquals = null;
            _taExpression = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _nameEquals = ((AnonymousObjectMemberDeclaratorSyntax) Node).NameEquals;
            _nameEqualsIsChanged = false;
            _expression = ((AnonymousObjectMemberDeclaratorSyntax) Node).Expression;
            _expressionIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AnonymousObjectMemberDeclarator(NameEquals, Expression);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaNameEquals != null) yield return TaNameEquals;
            if (TaExpression != null) yield return TaExpression;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NameEqualsStr", NameEqualsStr);
            yield return ("ExpressionStr", ExpressionStr);
        }
    }
}