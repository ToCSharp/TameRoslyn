// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameWhereClauseSyntax : TameQueryClauseSyntax
    {
        public new static string TypeName = "WhereClauseSyntax";
        private ExpressionSyntax _condition;
        private bool _conditionIsChanged;
        private string _conditionStr;
        private TameExpressionSyntax _taCondition;
        private SyntaxToken _whereKeyword;
        private bool _whereKeywordIsChanged;
        private string _whereKeywordStr;

        public TameWhereClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseWhereClause(code);
            AddChildren();
        }

        public TameWhereClauseSyntax(WhereClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameWhereClauseSyntax()
        {
            WhereKeywordStr = DefaultValues.WhereClauseSyntaxWhereKeywordStr;
            ConditionStr = DefaultValues.WhereClauseSyntaxConditionStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken WhereKeyword
        {
            get
            {
                if (_whereKeywordIsChanged)
                {
                    if (_whereKeywordStr == null) _whereKeyword = default(SyntaxToken);
                    else _whereKeyword = SyntaxFactoryStr.ParseSyntaxToken(_whereKeywordStr, SyntaxKind.WhereKeyword);
                    _whereKeywordIsChanged = false;
                }
                return _whereKeyword;
            }
            set
            {
                if (_whereKeyword != value)
                {
                    _whereKeyword = value;
                    _whereKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhereKeywordStr
        {
            get
            {
                if (_whereKeywordIsChanged) return _whereKeywordStr;
                return _whereKeywordStr = _whereKeyword.Text;
            }
            set
            {
                if (_whereKeywordStr != value)
                {
                    _whereKeywordStr = value;
                    IsChanged = true;
                    _whereKeywordIsChanged = true;
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

        public override void Clear()
        {
            base.Clear();
            _taCondition = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _whereKeyword = ((WhereClauseSyntax) Node).WhereKeyword;
            _whereKeywordIsChanged = false;
            _condition = ((WhereClauseSyntax) Node).Condition;
            _conditionIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.WhereClause(WhereKeyword, Condition);
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
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("WhereKeywordStr", WhereKeywordStr);
            yield return ("ConditionStr", ConditionStr);
        }
    }
}