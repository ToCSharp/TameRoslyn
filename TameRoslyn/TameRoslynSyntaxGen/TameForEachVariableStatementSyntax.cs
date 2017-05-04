// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameForEachVariableStatementSyntax : TameCommonForEachStatementSyntax
    {
        public new static string TypeName = "ForEachVariableStatementSyntax";
        private TameExpressionSyntax _taVariable;
        private ExpressionSyntax _variable;
        private bool _variableIsChanged;
        private string _variableStr;

        public TameForEachVariableStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseForEachVariableStatement(code);
            AddChildren();
        }

        public TameForEachVariableStatementSyntax(ForEachVariableStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameForEachVariableStatementSyntax()
        {
            VariableStr = DefaultValues.ForEachVariableStatementSyntaxVariableStr;
            ForEachKeywordStr = DefaultValues.ForEachVariableStatementSyntaxForEachKeywordStr;
            OpenParenTokenStr = DefaultValues.ForEachVariableStatementSyntaxOpenParenTokenStr;
            InKeywordStr = DefaultValues.ForEachVariableStatementSyntaxInKeywordStr;
            ExpressionStr = DefaultValues.ForEachVariableStatementSyntaxExpressionStr;
            CloseParenTokenStr = DefaultValues.ForEachVariableStatementSyntaxCloseParenTokenStr;
            StatementStr = DefaultValues.ForEachVariableStatementSyntaxStatementStr;
        }

        public override string RoslynTypeName => TypeName;

        public ExpressionSyntax Variable
        {
            get
            {
                if (_variableIsChanged)
                {
                    _variable = SyntaxFactoryStr.ParseExpressionSyntax(VariableStr);
                    _variableIsChanged = false;
                    _taVariable = null;
                }
                else if (_taVariable != null && _taVariable.IsChanged)
                {
                    _variable = (ExpressionSyntax) _taVariable.Node;
                }
                return _variable;
            }
            set
            {
                if (_variable != value)
                {
                    _variable = value;
                    _variableIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string VariableStr
        {
            get
            {
                if (_taVariable != null && _taVariable.IsChanged)
                    Variable = (ExpressionSyntax) _taVariable.Node;
                if (_variableIsChanged) return _variableStr;
                return _variableStr = _variable?.ToFullString();
            }
            set
            {
                if (_taVariable != null && _taVariable.IsChanged)
                {
                    Variable = (ExpressionSyntax) _taVariable.Node;
                    _variableStr = _variable?.ToFullString();
                }
                if (_variableStr != value)
                {
                    _variableStr = value;
                    IsChanged = true;
                    _variableIsChanged = true;
                    _taVariable = null;
                }
            }
        }

        public TameExpressionSyntax TaVariable
        {
            get
            {
                if (_taVariable == null && Variable != null)
                    if (Variable is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ParenthesizedLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedLambdaExpressionSyntax(
                                (ParenthesizedLambdaExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is SimpleLambdaExpressionSyntax)
                    {
                        var loc =
                            new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is AnonymousMethodExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is BaseExpressionSyntax)
                    {
                        var loc = new TameBaseExpressionSyntax((BaseExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ThisExpressionSyntax)
                    {
                        var loc = new TameThisExpressionSyntax((ThisExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is AnonymousObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameAnonymousObjectCreationExpressionSyntax(
                                (AnonymousObjectCreationExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is StackAllocArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameStackAllocArrayCreationExpressionSyntax(
                                (StackAllocArrayCreationExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ImplicitArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameImplicitArrayCreationExpressionSyntax(
                                (ImplicitArrayCreationExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is InterpolatedStringExpressionSyntax)
                    {
                        var loc =
                            new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ConditionalAccessExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is OmittedArraySizeExpressionSyntax)
                    {
                        var loc =
                            new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ElementBindingExpressionSyntax)
                    {
                        var loc =
                            new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ObjectCreationExpressionSyntax)
                    {
                        var loc =
                            new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ArrayCreationExpressionSyntax)
                    {
                        var loc =
                            new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ElementAccessExpressionSyntax)
                    {
                        var loc =
                            new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is MemberBindingExpressionSyntax)
                    {
                        var loc =
                            new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ParenthesizedExpressionSyntax)
                    {
                        var loc =
                            new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is MemberAccessExpressionSyntax)
                    {
                        var loc =
                            new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is PostfixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ConditionalExpressionSyntax)
                    {
                        var loc =
                            new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is DeclarationExpressionSyntax)
                    {
                        var loc =
                            new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ImplicitElementAccessSyntax)
                    {
                        var loc =
                            new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is InitializerExpressionSyntax)
                    {
                        var loc =
                            new TameInitializerExpressionSyntax((InitializerExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is PrefixUnaryExpressionSyntax)
                    {
                        var loc =
                            new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) Variable)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is AssignmentExpressionSyntax)
                    {
                        var loc =
                            new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is InvocationExpressionSyntax)
                    {
                        var loc =
                            new TameInvocationExpressionSyntax((InvocationExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is IsPatternExpressionSyntax)
                    {
                        var loc =
                            new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is RefValueExpressionSyntax)
                    {
                        var loc =
                            new TameRefValueExpressionSyntax((RefValueExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is CheckedExpressionSyntax)
                    {
                        var loc = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is DefaultExpressionSyntax)
                    {
                        var loc = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is LiteralExpressionSyntax)
                    {
                        var loc = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is MakeRefExpressionSyntax)
                    {
                        var loc = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is RefTypeExpressionSyntax)
                    {
                        var loc = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is BinaryExpressionSyntax)
                    {
                        var loc = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is SizeOfExpressionSyntax)
                    {
                        var loc = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is TypeOfExpressionSyntax)
                    {
                        var loc = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is AwaitExpressionSyntax)
                    {
                        var loc = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is QueryExpressionSyntax)
                    {
                        var loc = new TameQueryExpressionSyntax((QueryExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is ThrowExpressionSyntax)
                    {
                        var loc = new TameThrowExpressionSyntax((ThrowExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is TupleExpressionSyntax)
                    {
                        var loc = new TameTupleExpressionSyntax((TupleExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is CastExpressionSyntax)
                    {
                        var loc = new TameCastExpressionSyntax((CastExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                    else if (Variable is RefExpressionSyntax)
                    {
                        var loc = new TameRefExpressionSyntax((RefExpressionSyntax) Variable) {TaParent = this};
                        loc.AddChildren();
                        _taVariable = loc;
                    }
                return _taVariable;
            }
            set
            {
                if (_taVariable != value)
                {
                    _taVariable = value;
                    if (_taVariable != null)
                    {
                        _taVariable.TaParent = this;
                        _taVariable.IsChanged = true;
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
            _taVariable = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _variable = ((ForEachVariableStatementSyntax) Node).Variable;
            _variableIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ForEachVariableStatement(ForEachKeyword, OpenParenToken, Variable, InKeyword,
                Expression, CloseParenToken, Statement);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaVariable != null) yield return TaVariable;
            if (TaExpression != null) yield return TaExpression;
            if (TaStatement != null) yield return TaStatement;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("VariableStr", VariableStr);
            yield return ("ForEachKeywordStr", ForEachKeywordStr);
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("InKeywordStr", InKeywordStr);
            yield return ("ExpressionStr", ExpressionStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
            yield return ("StatementStr", StatementStr);
        }
    }
}