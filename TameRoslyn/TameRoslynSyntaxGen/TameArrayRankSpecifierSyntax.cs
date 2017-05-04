// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameArrayRankSpecifierSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "ArrayRankSpecifierSyntax";
        private SyntaxToken _closeBracketToken;
        private bool _closeBracketTokenIsChanged;
        private string _closeBracketTokenStr;
        private SyntaxToken _openBracketToken;
        private bool _openBracketTokenIsChanged;
        private string _openBracketTokenStr;
        private int _rank;
        private bool _rankIsChanged;
        private SeparatedSyntaxList<ExpressionSyntax> _sizes;
        private int _sizesCount;
        private bool _sizesIsChanged;
        private string _sizesStr;
        private List<TameExpressionSyntax> _taSizes;

        public TameArrayRankSpecifierSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseArrayRankSpecifier(code);
            AddChildren();
        }

        public TameArrayRankSpecifierSyntax(ArrayRankSpecifierSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameArrayRankSpecifierSyntax()
        {
            Rank = DefaultValues.ArrayRankSpecifierSyntaxRank;
            OpenBracketTokenStr = DefaultValues.ArrayRankSpecifierSyntaxOpenBracketTokenStr;
            SizesStr = DefaultValues.ArrayRankSpecifierSyntaxSizesStr;
            CloseBracketTokenStr = DefaultValues.ArrayRankSpecifierSyntaxCloseBracketTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public int Rank
        {
            get { return _rank; }
            set
            {
                if (_rank != value)
                {
                    _rank = value;
                    _rankIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public SyntaxToken OpenBracketToken
        {
            get
            {
                if (_openBracketTokenIsChanged)
                {
                    if (_openBracketTokenStr == null) _openBracketToken = default(SyntaxToken);
                    else
                        _openBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBracketTokenStr, SyntaxKind.OpenBracketToken);
                    _openBracketTokenIsChanged = false;
                }
                return _openBracketToken;
            }
            set
            {
                if (_openBracketToken != value)
                {
                    _openBracketToken = value;
                    _openBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBracketTokenStr
        {
            get
            {
                if (_openBracketTokenIsChanged) return _openBracketTokenStr;
                return _openBracketTokenStr = _openBracketToken.Text;
            }
            set
            {
                if (_openBracketTokenStr != value)
                {
                    _openBracketTokenStr = value;
                    IsChanged = true;
                    _openBracketTokenIsChanged = true;
                }
            }
        }

        public bool TaSizesIsChanged { get; set; }

        public SeparatedSyntaxList<ExpressionSyntax> Sizes
        {
            get
            {
                if (TaSizesIsChanged || _taSizes != null &&
                    (_taSizes.Count != _sizesCount || _taSizes.Any(v => v.IsChanged)))
                {
                    _sizes = SyntaxFactory.SeparatedList(TaSizes?.Select(v => v.Node).Cast<ExpressionSyntax>());
                    TaSizesIsChanged = false;
                }
                return _sizes;
            }
            set
            {
                if (_sizes != value)
                {
                    _sizes = value;
                    TaSizesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SizesStr
        {
            get
            {
                if (_sizesIsChanged) return _sizesStr;
                return _sizesStr = string.Join(", ", _sizes.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _sizesStr = value;
                    Sizes = new SeparatedSyntaxList<ExpressionSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameExpressionSyntax> TaSizes
        {
            get
            {
                if (_taSizes == null)
                {
                    _taSizes = new List<TameExpressionSyntax>();
                    foreach (var item in _sizes)
                        if (item is IdentifierNameSyntax)
                            _taSizes.Add(new TameIdentifierNameSyntax(item as IdentifierNameSyntax) {TaParent = this});
                        else if (item is GenericNameSyntax)
                            _taSizes.Add(new TameGenericNameSyntax(item as GenericNameSyntax) {TaParent = this});
                        else if (item is ParenthesizedLambdaExpressionSyntax)
                            _taSizes.Add(
                                new TameParenthesizedLambdaExpressionSyntax(
                                    item as ParenthesizedLambdaExpressionSyntax) {TaParent = this});
                        else if (item is SimpleLambdaExpressionSyntax)
                            _taSizes.Add(
                                new TameSimpleLambdaExpressionSyntax(item as SimpleLambdaExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AliasQualifiedNameSyntax)
                            _taSizes.Add(
                                new TameAliasQualifiedNameSyntax(item as AliasQualifiedNameSyntax) {TaParent = this});
                        else if (item is QualifiedNameSyntax)
                            _taSizes.Add(new TameQualifiedNameSyntax(item as QualifiedNameSyntax) {TaParent = this});
                        else if (item is AnonymousMethodExpressionSyntax)
                            _taSizes.Add(
                                new TameAnonymousMethodExpressionSyntax(item as AnonymousMethodExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedTypeArgumentSyntax)
                            _taSizes.Add(
                                new TameOmittedTypeArgumentSyntax(item as OmittedTypeArgumentSyntax) {TaParent = this});
                        else if (item is BaseExpressionSyntax)
                            _taSizes.Add(new TameBaseExpressionSyntax(item as BaseExpressionSyntax) {TaParent = this});
                        else if (item is PredefinedTypeSyntax)
                            _taSizes.Add(new TamePredefinedTypeSyntax(item as PredefinedTypeSyntax) {TaParent = this});
                        else if (item is ThisExpressionSyntax)
                            _taSizes.Add(new TameThisExpressionSyntax(item as ThisExpressionSyntax) {TaParent = this});
                        else if (item is NullableTypeSyntax)
                            _taSizes.Add(new TameNullableTypeSyntax(item as NullableTypeSyntax) {TaParent = this});
                        else if (item is PointerTypeSyntax)
                            _taSizes.Add(new TamePointerTypeSyntax(item as PointerTypeSyntax) {TaParent = this});
                        else if (item is ArrayTypeSyntax)
                            _taSizes.Add(new TameArrayTypeSyntax(item as ArrayTypeSyntax) {TaParent = this});
                        else if (item is TupleTypeSyntax)
                            _taSizes.Add(new TameTupleTypeSyntax(item as TupleTypeSyntax) {TaParent = this});
                        else if (item is RefTypeSyntax)
                            _taSizes.Add(new TameRefTypeSyntax(item as RefTypeSyntax) {TaParent = this});
                        else if (item is AnonymousObjectCreationExpressionSyntax)
                            _taSizes.Add(
                                new TameAnonymousObjectCreationExpressionSyntax(
                                    item as AnonymousObjectCreationExpressionSyntax) {TaParent = this});
                        else if (item is StackAllocArrayCreationExpressionSyntax)
                            _taSizes.Add(
                                new TameStackAllocArrayCreationExpressionSyntax(
                                    item as StackAllocArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is ImplicitArrayCreationExpressionSyntax)
                            _taSizes.Add(
                                new TameImplicitArrayCreationExpressionSyntax(
                                    item as ImplicitArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is InterpolatedStringExpressionSyntax)
                            _taSizes.Add(
                                new TameInterpolatedStringExpressionSyntax(item as InterpolatedStringExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalAccessExpressionSyntax)
                            _taSizes.Add(
                                new TameConditionalAccessExpressionSyntax(item as ConditionalAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedArraySizeExpressionSyntax)
                            _taSizes.Add(
                                new TameOmittedArraySizeExpressionSyntax(item as OmittedArraySizeExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementBindingExpressionSyntax)
                            _taSizes.Add(
                                new TameElementBindingExpressionSyntax(item as ElementBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ObjectCreationExpressionSyntax)
                            _taSizes.Add(
                                new TameObjectCreationExpressionSyntax(item as ObjectCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ArrayCreationExpressionSyntax)
                            _taSizes.Add(
                                new TameArrayCreationExpressionSyntax(item as ArrayCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementAccessExpressionSyntax)
                            _taSizes.Add(
                                new TameElementAccessExpressionSyntax(item as ElementAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberBindingExpressionSyntax)
                            _taSizes.Add(
                                new TameMemberBindingExpressionSyntax(item as MemberBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ParenthesizedExpressionSyntax)
                            _taSizes.Add(
                                new TameParenthesizedExpressionSyntax(item as ParenthesizedExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberAccessExpressionSyntax)
                            _taSizes.Add(
                                new TameMemberAccessExpressionSyntax(item as MemberAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PostfixUnaryExpressionSyntax)
                            _taSizes.Add(
                                new TamePostfixUnaryExpressionSyntax(item as PostfixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalExpressionSyntax)
                            _taSizes.Add(
                                new TameConditionalExpressionSyntax(item as ConditionalExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DeclarationExpressionSyntax)
                            _taSizes.Add(
                                new TameDeclarationExpressionSyntax(item as DeclarationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ImplicitElementAccessSyntax)
                            _taSizes.Add(
                                new TameImplicitElementAccessSyntax(item as ImplicitElementAccessSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InitializerExpressionSyntax)
                            _taSizes.Add(
                                new TameInitializerExpressionSyntax(item as InitializerExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PrefixUnaryExpressionSyntax)
                            _taSizes.Add(
                                new TamePrefixUnaryExpressionSyntax(item as PrefixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AssignmentExpressionSyntax)
                            _taSizes.Add(
                                new TameAssignmentExpressionSyntax(item as AssignmentExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InvocationExpressionSyntax)
                            _taSizes.Add(
                                new TameInvocationExpressionSyntax(item as InvocationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is IsPatternExpressionSyntax)
                            _taSizes.Add(
                                new TameIsPatternExpressionSyntax(item as IsPatternExpressionSyntax) {TaParent = this});
                        else if (item is RefValueExpressionSyntax)
                            _taSizes.Add(
                                new TameRefValueExpressionSyntax(item as RefValueExpressionSyntax) {TaParent = this});
                        else if (item is CheckedExpressionSyntax)
                            _taSizes.Add(
                                new TameCheckedExpressionSyntax(item as CheckedExpressionSyntax) {TaParent = this});
                        else if (item is DefaultExpressionSyntax)
                            _taSizes.Add(
                                new TameDefaultExpressionSyntax(item as DefaultExpressionSyntax) {TaParent = this});
                        else if (item is LiteralExpressionSyntax)
                            _taSizes.Add(
                                new TameLiteralExpressionSyntax(item as LiteralExpressionSyntax) {TaParent = this});
                        else if (item is MakeRefExpressionSyntax)
                            _taSizes.Add(
                                new TameMakeRefExpressionSyntax(item as MakeRefExpressionSyntax) {TaParent = this});
                        else if (item is RefTypeExpressionSyntax)
                            _taSizes.Add(
                                new TameRefTypeExpressionSyntax(item as RefTypeExpressionSyntax) {TaParent = this});
                        else if (item is BinaryExpressionSyntax)
                            _taSizes.Add(
                                new TameBinaryExpressionSyntax(item as BinaryExpressionSyntax) {TaParent = this});
                        else if (item is SizeOfExpressionSyntax)
                            _taSizes.Add(
                                new TameSizeOfExpressionSyntax(item as SizeOfExpressionSyntax) {TaParent = this});
                        else if (item is TypeOfExpressionSyntax)
                            _taSizes.Add(
                                new TameTypeOfExpressionSyntax(item as TypeOfExpressionSyntax) {TaParent = this});
                        else if (item is AwaitExpressionSyntax)
                            _taSizes.Add(
                                new TameAwaitExpressionSyntax(item as AwaitExpressionSyntax) {TaParent = this});
                        else if (item is QueryExpressionSyntax)
                            _taSizes.Add(
                                new TameQueryExpressionSyntax(item as QueryExpressionSyntax) {TaParent = this});
                        else if (item is ThrowExpressionSyntax)
                            _taSizes.Add(
                                new TameThrowExpressionSyntax(item as ThrowExpressionSyntax) {TaParent = this});
                        else if (item is TupleExpressionSyntax)
                            _taSizes.Add(
                                new TameTupleExpressionSyntax(item as TupleExpressionSyntax) {TaParent = this});
                        else if (item is CastExpressionSyntax)
                            _taSizes.Add(new TameCastExpressionSyntax(item as CastExpressionSyntax) {TaParent = this});
                        else if (item is RefExpressionSyntax)
                            _taSizes.Add(new TameRefExpressionSyntax(item as RefExpressionSyntax) {TaParent = this});
                        else if (item is ExpressionSyntax)
                            _taSizes.Add(new TameExpressionSyntax(item) {TaParent = this});
                }
                return _taSizes;
            }
            set
            {
                if (_taSizes != value)
                {
                    _taSizes = value;
                    _taSizes?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaSizesIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBracketToken
        {
            get
            {
                if (_closeBracketTokenIsChanged)
                {
                    if (_closeBracketTokenStr == null) _closeBracketToken = default(SyntaxToken);
                    else
                        _closeBracketToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBracketTokenStr, SyntaxKind.CloseBracketToken);
                    _closeBracketTokenIsChanged = false;
                }
                return _closeBracketToken;
            }
            set
            {
                if (_closeBracketToken != value)
                {
                    _closeBracketToken = value;
                    _closeBracketTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBracketTokenStr
        {
            get
            {
                if (_closeBracketTokenIsChanged) return _closeBracketTokenStr;
                return _closeBracketTokenStr = _closeBracketToken.Text;
            }
            set
            {
                if (_closeBracketTokenStr != value)
                {
                    _closeBracketTokenStr = value;
                    IsChanged = true;
                    _closeBracketTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taSizes = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _rank = ((ArrayRankSpecifierSyntax) Node).Rank;
            _rankIsChanged = false;
            _openBracketToken = ((ArrayRankSpecifierSyntax) Node).OpenBracketToken;
            _openBracketTokenIsChanged = false;
            _sizes = ((ArrayRankSpecifierSyntax) Node).Sizes;
            _sizesIsChanged = false;
            _sizesCount = _sizes.Count;
            _closeBracketToken = ((ArrayRankSpecifierSyntax) Node).CloseBracketToken;
            _closeBracketTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaSizes)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ArrayRankSpecifier(OpenBracketToken, Sizes, CloseBracketToken);
// if (Rank != null) res = res.WithRank(Rank);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaSizes)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("Rank", Rank.ToString());
            yield return ("OpenBracketTokenStr", OpenBracketTokenStr);
            yield return ("SizesStr", SizesStr);
            yield return ("CloseBracketTokenStr", CloseBracketTokenStr);
        }

        public TameArrayRankSpecifierSyntax AddSize(TameExpressionSyntax item)
        {
            item.TaParent = this;
            TaSizes.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}