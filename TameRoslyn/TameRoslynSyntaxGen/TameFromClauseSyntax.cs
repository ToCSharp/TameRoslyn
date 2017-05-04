// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameFromClauseSyntax : TameQueryClauseSyntax, IHaveIdentifier
    {
        public new static string TypeName = "FromClauseSyntax";
        private ExpressionSyntax _expression;
        private bool _expressionIsChanged;
        private string _expressionStr;
        private SyntaxToken _fromKeyword;
        private bool _fromKeywordIsChanged;
        private string _fromKeywordStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxToken _inKeyword;
        private bool _inKeywordIsChanged;
        private string _inKeywordStr;
        private TameExpressionSyntax _taExpression;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameFromClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseFromClause(code);
            AddChildren();
        }

        public TameFromClauseSyntax(FromClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameFromClauseSyntax()
        {
            FromKeywordStr = DefaultValues.FromClauseSyntaxFromKeywordStr;
            TypeStr = DefaultValues.FromClauseSyntaxTypeStr;
            IdentifierStr = DefaultValues.FromClauseSyntaxIdentifierStr;
            InKeywordStr = DefaultValues.FromClauseSyntaxInKeywordStr;
            ExpressionStr = DefaultValues.FromClauseSyntaxExpressionStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken FromKeyword
        {
            get
            {
                if (_fromKeywordIsChanged)
                {
                    if (_fromKeywordStr == null) _fromKeyword = default(SyntaxToken);
                    else _fromKeyword = SyntaxFactoryStr.ParseSyntaxToken(_fromKeywordStr, SyntaxKind.FromKeyword);
                    _fromKeywordIsChanged = false;
                }
                return _fromKeyword;
            }
            set
            {
                if (_fromKeyword != value)
                {
                    _fromKeyword = value;
                    _fromKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FromKeywordStr
        {
            get
            {
                if (_fromKeywordIsChanged) return _fromKeywordStr;
                return _fromKeywordStr = _fromKeyword.Text;
            }
            set
            {
                if (_fromKeywordStr != value)
                {
                    _fromKeywordStr = value;
                    IsChanged = true;
                    _fromKeywordIsChanged = true;
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
            _taExpression = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _fromKeyword = ((FromClauseSyntax) Node).FromKeyword;
            _fromKeywordIsChanged = false;
            _type = ((FromClauseSyntax) Node).Type;
            _typeIsChanged = false;
            _identifier = ((FromClauseSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _inKeyword = ((FromClauseSyntax) Node).InKeyword;
            _inKeywordIsChanged = false;
            _expression = ((FromClauseSyntax) Node).Expression;
            _expressionIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.FromClause(FromKeyword, Type, Identifier, InKeyword, Expression);
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
            if (TaExpression != null) yield return TaExpression;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("FromKeywordStr", FromKeywordStr);
            yield return ("TypeStr", TypeStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("InKeywordStr", InKeywordStr);
            yield return ("ExpressionStr", ExpressionStr);
        }
    }
}