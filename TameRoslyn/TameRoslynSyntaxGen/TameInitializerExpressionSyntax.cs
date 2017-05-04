// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameInitializerExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "InitializerExpressionSyntax";
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SeparatedSyntaxList<ExpressionSyntax> _expressions;
        private int _expressionsCount;
        private bool _expressionsIsChanged;
        private string _expressionsStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private List<TameExpressionSyntax> _taExpressions;

        public TameInitializerExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseInitializerExpression(code);
            AddChildren();
        }

        public TameInitializerExpressionSyntax(InitializerExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameInitializerExpressionSyntax()
        {
            OpenBraceTokenStr = DefaultValues.InitializerExpressionSyntaxOpenBraceTokenStr;
            ExpressionsStr = DefaultValues.InitializerExpressionSyntaxExpressionsStr;
            CloseBraceTokenStr = DefaultValues.InitializerExpressionSyntaxCloseBraceTokenStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public bool TaExpressionsIsChanged { get; set; }

        public SeparatedSyntaxList<ExpressionSyntax> Expressions
        {
            get
            {
                if (TaExpressionsIsChanged || _taExpressions != null &&
                    (_taExpressions.Count != _expressionsCount || _taExpressions.Any(v => v.IsChanged)))
                {
                    _expressions =
                        SyntaxFactory.SeparatedList(TaExpressions?.Select(v => v.Node).Cast<ExpressionSyntax>());
                    TaExpressionsIsChanged = false;
                }
                return _expressions;
            }
            set
            {
                if (_expressions != value)
                {
                    _expressions = value;
                    TaExpressionsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExpressionsStr
        {
            get
            {
                if (_expressionsIsChanged) return _expressionsStr;
                return _expressionsStr = string.Join(", ", _expressions.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _expressionsStr = value;
                    Expressions = new SeparatedSyntaxList<ExpressionSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameExpressionSyntax> TaExpressions
        {
            get
            {
                if (_taExpressions == null)
                {
                    _taExpressions = new List<TameExpressionSyntax>();
                    foreach (var item in _expressions)
                        if (item is IdentifierNameSyntax)
                            _taExpressions.Add(
                                new TameIdentifierNameSyntax(item as IdentifierNameSyntax) {TaParent = this});
                        else if (item is GenericNameSyntax)
                            _taExpressions.Add(new TameGenericNameSyntax(item as GenericNameSyntax) {TaParent = this});
                        else if (item is ParenthesizedLambdaExpressionSyntax)
                            _taExpressions.Add(
                                new TameParenthesizedLambdaExpressionSyntax(
                                    item as ParenthesizedLambdaExpressionSyntax) {TaParent = this});
                        else if (item is SimpleLambdaExpressionSyntax)
                            _taExpressions.Add(
                                new TameSimpleLambdaExpressionSyntax(item as SimpleLambdaExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AliasQualifiedNameSyntax)
                            _taExpressions.Add(
                                new TameAliasQualifiedNameSyntax(item as AliasQualifiedNameSyntax) {TaParent = this});
                        else if (item is QualifiedNameSyntax)
                            _taExpressions.Add(
                                new TameQualifiedNameSyntax(item as QualifiedNameSyntax) {TaParent = this});
                        else if (item is AnonymousMethodExpressionSyntax)
                            _taExpressions.Add(
                                new TameAnonymousMethodExpressionSyntax(item as AnonymousMethodExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedTypeArgumentSyntax)
                            _taExpressions.Add(
                                new TameOmittedTypeArgumentSyntax(item as OmittedTypeArgumentSyntax) {TaParent = this});
                        else if (item is BaseExpressionSyntax)
                            _taExpressions.Add(
                                new TameBaseExpressionSyntax(item as BaseExpressionSyntax) {TaParent = this});
                        else if (item is PredefinedTypeSyntax)
                            _taExpressions.Add(
                                new TamePredefinedTypeSyntax(item as PredefinedTypeSyntax) {TaParent = this});
                        else if (item is ThisExpressionSyntax)
                            _taExpressions.Add(
                                new TameThisExpressionSyntax(item as ThisExpressionSyntax) {TaParent = this});
                        else if (item is NullableTypeSyntax)
                            _taExpressions.Add(
                                new TameNullableTypeSyntax(item as NullableTypeSyntax) {TaParent = this});
                        else if (item is PointerTypeSyntax)
                            _taExpressions.Add(new TamePointerTypeSyntax(item as PointerTypeSyntax) {TaParent = this});
                        else if (item is ArrayTypeSyntax)
                            _taExpressions.Add(new TameArrayTypeSyntax(item as ArrayTypeSyntax) {TaParent = this});
                        else if (item is TupleTypeSyntax)
                            _taExpressions.Add(new TameTupleTypeSyntax(item as TupleTypeSyntax) {TaParent = this});
                        else if (item is RefTypeSyntax)
                            _taExpressions.Add(new TameRefTypeSyntax(item as RefTypeSyntax) {TaParent = this});
                        else if (item is AnonymousObjectCreationExpressionSyntax)
                            _taExpressions.Add(
                                new TameAnonymousObjectCreationExpressionSyntax(
                                    item as AnonymousObjectCreationExpressionSyntax) {TaParent = this});
                        else if (item is StackAllocArrayCreationExpressionSyntax)
                            _taExpressions.Add(
                                new TameStackAllocArrayCreationExpressionSyntax(
                                    item as StackAllocArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is ImplicitArrayCreationExpressionSyntax)
                            _taExpressions.Add(
                                new TameImplicitArrayCreationExpressionSyntax(
                                    item as ImplicitArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is InterpolatedStringExpressionSyntax)
                            _taExpressions.Add(
                                new TameInterpolatedStringExpressionSyntax(item as InterpolatedStringExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalAccessExpressionSyntax)
                            _taExpressions.Add(
                                new TameConditionalAccessExpressionSyntax(item as ConditionalAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedArraySizeExpressionSyntax)
                            _taExpressions.Add(
                                new TameOmittedArraySizeExpressionSyntax(item as OmittedArraySizeExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementBindingExpressionSyntax)
                            _taExpressions.Add(
                                new TameElementBindingExpressionSyntax(item as ElementBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ObjectCreationExpressionSyntax)
                            _taExpressions.Add(
                                new TameObjectCreationExpressionSyntax(item as ObjectCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ArrayCreationExpressionSyntax)
                            _taExpressions.Add(
                                new TameArrayCreationExpressionSyntax(item as ArrayCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementAccessExpressionSyntax)
                            _taExpressions.Add(
                                new TameElementAccessExpressionSyntax(item as ElementAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberBindingExpressionSyntax)
                            _taExpressions.Add(
                                new TameMemberBindingExpressionSyntax(item as MemberBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ParenthesizedExpressionSyntax)
                            _taExpressions.Add(
                                new TameParenthesizedExpressionSyntax(item as ParenthesizedExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberAccessExpressionSyntax)
                            _taExpressions.Add(
                                new TameMemberAccessExpressionSyntax(item as MemberAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PostfixUnaryExpressionSyntax)
                            _taExpressions.Add(
                                new TamePostfixUnaryExpressionSyntax(item as PostfixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalExpressionSyntax)
                            _taExpressions.Add(
                                new TameConditionalExpressionSyntax(item as ConditionalExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DeclarationExpressionSyntax)
                            _taExpressions.Add(
                                new TameDeclarationExpressionSyntax(item as DeclarationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ImplicitElementAccessSyntax)
                            _taExpressions.Add(
                                new TameImplicitElementAccessSyntax(item as ImplicitElementAccessSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InitializerExpressionSyntax)
                            _taExpressions.Add(
                                new TameInitializerExpressionSyntax(item as InitializerExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PrefixUnaryExpressionSyntax)
                            _taExpressions.Add(
                                new TamePrefixUnaryExpressionSyntax(item as PrefixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AssignmentExpressionSyntax)
                            _taExpressions.Add(
                                new TameAssignmentExpressionSyntax(item as AssignmentExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InvocationExpressionSyntax)
                            _taExpressions.Add(
                                new TameInvocationExpressionSyntax(item as InvocationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is IsPatternExpressionSyntax)
                            _taExpressions.Add(
                                new TameIsPatternExpressionSyntax(item as IsPatternExpressionSyntax) {TaParent = this});
                        else if (item is RefValueExpressionSyntax)
                            _taExpressions.Add(
                                new TameRefValueExpressionSyntax(item as RefValueExpressionSyntax) {TaParent = this});
                        else if (item is CheckedExpressionSyntax)
                            _taExpressions.Add(
                                new TameCheckedExpressionSyntax(item as CheckedExpressionSyntax) {TaParent = this});
                        else if (item is DefaultExpressionSyntax)
                            _taExpressions.Add(
                                new TameDefaultExpressionSyntax(item as DefaultExpressionSyntax) {TaParent = this});
                        else if (item is LiteralExpressionSyntax)
                            _taExpressions.Add(
                                new TameLiteralExpressionSyntax(item as LiteralExpressionSyntax) {TaParent = this});
                        else if (item is MakeRefExpressionSyntax)
                            _taExpressions.Add(
                                new TameMakeRefExpressionSyntax(item as MakeRefExpressionSyntax) {TaParent = this});
                        else if (item is RefTypeExpressionSyntax)
                            _taExpressions.Add(
                                new TameRefTypeExpressionSyntax(item as RefTypeExpressionSyntax) {TaParent = this});
                        else if (item is BinaryExpressionSyntax)
                            _taExpressions.Add(
                                new TameBinaryExpressionSyntax(item as BinaryExpressionSyntax) {TaParent = this});
                        else if (item is SizeOfExpressionSyntax)
                            _taExpressions.Add(
                                new TameSizeOfExpressionSyntax(item as SizeOfExpressionSyntax) {TaParent = this});
                        else if (item is TypeOfExpressionSyntax)
                            _taExpressions.Add(
                                new TameTypeOfExpressionSyntax(item as TypeOfExpressionSyntax) {TaParent = this});
                        else if (item is AwaitExpressionSyntax)
                            _taExpressions.Add(
                                new TameAwaitExpressionSyntax(item as AwaitExpressionSyntax) {TaParent = this});
                        else if (item is QueryExpressionSyntax)
                            _taExpressions.Add(
                                new TameQueryExpressionSyntax(item as QueryExpressionSyntax) {TaParent = this});
                        else if (item is ThrowExpressionSyntax)
                            _taExpressions.Add(
                                new TameThrowExpressionSyntax(item as ThrowExpressionSyntax) {TaParent = this});
                        else if (item is TupleExpressionSyntax)
                            _taExpressions.Add(
                                new TameTupleExpressionSyntax(item as TupleExpressionSyntax) {TaParent = this});
                        else if (item is CastExpressionSyntax)
                            _taExpressions.Add(
                                new TameCastExpressionSyntax(item as CastExpressionSyntax) {TaParent = this});
                        else if (item is RefExpressionSyntax)
                            _taExpressions.Add(
                                new TameRefExpressionSyntax(item as RefExpressionSyntax) {TaParent = this});
                        else if (item is ExpressionSyntax)
                            _taExpressions.Add(new TameExpressionSyntax(item) {TaParent = this});
                }
                return _taExpressions;
            }
            set
            {
                if (_taExpressions != value)
                {
                    _taExpressions = value;
                    _taExpressions?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaExpressionsIsChanged = true;
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
            _taExpressions = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _openBraceToken = ((InitializerExpressionSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _expressions = ((InitializerExpressionSyntax) Node).Expressions;
            _expressionsIsChanged = false;
            _expressionsCount = _expressions.Count;
            _closeBraceToken = ((InitializerExpressionSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaExpressions)
                item.SetNotChanged();
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            throw new Exception(
                "InitializerExpressionSyntax Kind must be set to SyntaxKind.ObjectInitializerExpression, SyntaxKind.CollectionInitializerExpression, SyntaxKind.ArrayInitializerExpression or SyntaxKind.ComplexElementInitializerExpression");
            //case SyntaxKind.ObjectInitializerExpression:
            //case SyntaxKind.CollectionInitializerExpression:
            //case SyntaxKind.ArrayInitializerExpression:
            //case SyntaxKind.ComplexElementInitializerExpression:
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.InitializerExpression(GetKind(), OpenBraceToken, Expressions, CloseBraceToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaExpressions)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("ExpressionsStr", ExpressionsStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
        }

        public TameInitializerExpressionSyntax AddExpression(TameExpressionSyntax item)
        {
            item.TaParent = this;
            TaExpressions.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}