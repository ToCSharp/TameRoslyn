// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TamePrefixUnaryExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "PrefixUnaryExpressionSyntax";
        private ExpressionSyntax _operand;
        private bool _operandIsChanged;
        private string _operandStr;
        private SyntaxToken _operatorToken;
        private bool _operatorTokenIsChanged;
        private string _operatorTokenStr;
        private TameExpressionSyntax _taOperand;

        public TamePrefixUnaryExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParsePrefixUnaryExpression(code);
            AddChildren();
        }

        public TamePrefixUnaryExpressionSyntax(PrefixUnaryExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TamePrefixUnaryExpressionSyntax()
        {
            OperatorTokenStr = DefaultValues.PrefixUnaryExpressionSyntaxOperatorTokenStr;
            OperandStr = DefaultValues.PrefixUnaryExpressionSyntaxOperandStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public ExpressionSyntax Operand
        {
            get
            {
                if (_operandIsChanged)
                {
                    _operand = SyntaxFactoryStr.ParseExpressionSyntax(OperandStr);
                    _operandIsChanged = false;
                    _taOperand = null;
                }
                else if (_taOperand != null && _taOperand.IsChanged)
                {
                    _operand = (ExpressionSyntax) _taOperand.Node;
                }
                return _operand;
            }
            set
            {
                if (_operand != value)
                {
                    _operand = value;
                    _operandIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperandStr
        {
            get
            {
                if (_taOperand != null && _taOperand.IsChanged)
                    Operand = (ExpressionSyntax) _taOperand.Node;
                if (_operandIsChanged) return _operandStr;
                return _operandStr = _operand?.ToFullString();
            }
            set
            {
                if (_taOperand != null && _taOperand.IsChanged)
                {
                    Operand = (ExpressionSyntax) _taOperand.Node;
                    _operandStr = _operand?.ToFullString();
                }
                if (_operandStr != value)
                {
                    _operandStr = value;
                    IsChanged = true;
                    _operandIsChanged = true;
                    _taOperand = null;
                }
            }
        }

        public TameExpressionSyntax TaOperand
        {
            get
            {
                if (_taOperand == null && Operand != null)
                    if (Operand is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax((ParenthesizedLambdaExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Operand)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is CheckedExpressionSyntax)
                    {
                        var loc = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is DefaultExpressionSyntax)
                    {
                        var loc = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is LiteralExpressionSyntax)
                    {
                        var loc = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is MakeRefExpressionSyntax)
                    {
                        var loc = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is RefTypeExpressionSyntax)
                    {
                        var loc = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                    else if (Operand is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Operand) {TaParent = this};
                        loc.AddChildren();
                        _taOperand = loc;
                    }
                return _taOperand;
            }
            set
            {
                if (_taOperand != value)
                {
                    _taOperand = value;
                    if (_taOperand != null)
                    {
                        _taOperand.TaParent = this;
                        _taOperand.IsChanged = true;
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
            _taOperand = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _operatorToken = ((PrefixUnaryExpressionSyntax) Node).OperatorToken;
            _operatorTokenIsChanged = false;
            _operand = ((PrefixUnaryExpressionSyntax) Node).Operand;
            _operandIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            return SyntaxFacts.GetPrefixUnaryExpression(TameSyntaxFacts.SyntaxKindFromStr(OperatorTokenStr));
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.PrefixUnaryExpression(GetKind(), OperatorToken, Operand);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaOperand != null) yield return TaOperand;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OperatorTokenStr", OperatorTokenStr);
            yield return ("OperandStr", OperandStr);
        }
    }
}