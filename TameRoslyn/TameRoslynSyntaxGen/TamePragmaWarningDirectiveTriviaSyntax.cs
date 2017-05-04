// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TamePragmaWarningDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "PragmaWarningDirectiveTriviaSyntax";
        private SyntaxToken _disableOrRestoreKeyword;
        private bool _disableOrRestoreKeywordIsChanged;
        private string _disableOrRestoreKeywordStr;
        private SeparatedSyntaxList<ExpressionSyntax> _errorCodes;
        private int _errorCodesCount;
        private bool _errorCodesIsChanged;
        private string _errorCodesStr;
        private SyntaxToken _pragmaKeyword;
        private bool _pragmaKeywordIsChanged;
        private string _pragmaKeywordStr;
        private List<TameExpressionSyntax> _taErrorCodes;
        private SyntaxToken _warningKeyword;
        private bool _warningKeywordIsChanged;
        private string _warningKeywordStr;

        public TamePragmaWarningDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParsePragmaWarningDirectiveTrivia(code);
            AddChildren();
        }

        public TamePragmaWarningDirectiveTriviaSyntax(PragmaWarningDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TamePragmaWarningDirectiveTriviaSyntax()
        {
            // PragmaKeywordStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxPragmaKeywordStr;
            // WarningKeywordStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxWarningKeywordStr;
            // DisableOrRestoreKeywordStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxDisableOrRestoreKeywordStr;
            // ErrorCodesStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxErrorCodesStr;
            // DirectiveNameTokenStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.PragmaWarningDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.PragmaWarningDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken PragmaKeyword
        {
            get
            {
                if (_pragmaKeywordIsChanged)
                {
                    if (_pragmaKeywordStr == null) _pragmaKeyword = default(SyntaxToken);
                    else
                        _pragmaKeyword = SyntaxFactoryStr.ParseSyntaxToken(_pragmaKeywordStr, SyntaxKind.PragmaKeyword);
                    _pragmaKeywordIsChanged = false;
                }
                return _pragmaKeyword;
            }
            set
            {
                if (_pragmaKeyword != value)
                {
                    _pragmaKeyword = value;
                    _pragmaKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string PragmaKeywordStr
        {
            get
            {
                if (_pragmaKeywordIsChanged) return _pragmaKeywordStr;
                return _pragmaKeywordStr = _pragmaKeyword.Text;
            }
            set
            {
                if (_pragmaKeywordStr != value)
                {
                    _pragmaKeywordStr = value;
                    IsChanged = true;
                    _pragmaKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken WarningKeyword
        {
            get
            {
                if (_warningKeywordIsChanged)
                {
                    if (_warningKeywordStr == null) _warningKeyword = default(SyntaxToken);
                    else
                        _warningKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_warningKeywordStr, SyntaxKind.WarningKeyword);
                    _warningKeywordIsChanged = false;
                }
                return _warningKeyword;
            }
            set
            {
                if (_warningKeyword != value)
                {
                    _warningKeyword = value;
                    _warningKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WarningKeywordStr
        {
            get
            {
                if (_warningKeywordIsChanged) return _warningKeywordStr;
                return _warningKeywordStr = _warningKeyword.Text;
            }
            set
            {
                if (_warningKeywordStr != value)
                {
                    _warningKeywordStr = value;
                    IsChanged = true;
                    _warningKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken DisableOrRestoreKeyword
        {
            get
            {
                if (_disableOrRestoreKeywordIsChanged)
                {
                    _disableOrRestoreKeyword = SyntaxFactoryStr.ParseSyntaxToken(DisableOrRestoreKeywordStr);
                    _disableOrRestoreKeywordIsChanged = false;
                }
                return _disableOrRestoreKeyword;
            }
            set
            {
                if (_disableOrRestoreKeyword != value)
                {
                    _disableOrRestoreKeyword = value;
                    _disableOrRestoreKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DisableOrRestoreKeywordStr
        {
            get
            {
                if (_disableOrRestoreKeywordIsChanged) return _disableOrRestoreKeywordStr;
                return _disableOrRestoreKeywordStr = _disableOrRestoreKeyword.Text;
            }
            set
            {
                if (_disableOrRestoreKeywordStr != value)
                {
                    _disableOrRestoreKeywordStr = value;
                    IsChanged = true;
                    _disableOrRestoreKeywordIsChanged = true;
                }
            }
        }

        public bool TaErrorCodesIsChanged { get; set; }

        public SeparatedSyntaxList<ExpressionSyntax> ErrorCodes
        {
            get
            {
                if (TaErrorCodesIsChanged || _taErrorCodes != null &&
                    (_taErrorCodes.Count != _errorCodesCount || _taErrorCodes.Any(v => v.IsChanged)))
                {
                    _errorCodes =
                        SyntaxFactory.SeparatedList(TaErrorCodes?.Select(v => v.Node).Cast<ExpressionSyntax>());
                    TaErrorCodesIsChanged = false;
                }
                return _errorCodes;
            }
            set
            {
                if (_errorCodes != value)
                {
                    _errorCodes = value;
                    TaErrorCodesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ErrorCodesStr
        {
            get
            {
                if (_errorCodesIsChanged) return _errorCodesStr;
                return _errorCodesStr = string.Join(", ", _errorCodes.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _errorCodesStr = value;
                    ErrorCodes = new SeparatedSyntaxList<ExpressionSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameExpressionSyntax> TaErrorCodes
        {
            get
            {
                if (_taErrorCodes == null)
                {
                    _taErrorCodes = new List<TameExpressionSyntax>();
                    foreach (var item in _errorCodes)
                        if (item is IdentifierNameSyntax)
                            _taErrorCodes.Add(
                                new TameIdentifierNameSyntax(item as IdentifierNameSyntax) {TaParent = this});
                        else if (item is GenericNameSyntax)
                            _taErrorCodes.Add(new TameGenericNameSyntax(item as GenericNameSyntax) {TaParent = this});
                        else if (item is ParenthesizedLambdaExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameParenthesizedLambdaExpressionSyntax(
                                    item as ParenthesizedLambdaExpressionSyntax) {TaParent = this});
                        else if (item is SimpleLambdaExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameSimpleLambdaExpressionSyntax(item as SimpleLambdaExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AliasQualifiedNameSyntax)
                            _taErrorCodes.Add(
                                new TameAliasQualifiedNameSyntax(item as AliasQualifiedNameSyntax) {TaParent = this});
                        else if (item is QualifiedNameSyntax)
                            _taErrorCodes.Add(
                                new TameQualifiedNameSyntax(item as QualifiedNameSyntax) {TaParent = this});
                        else if (item is AnonymousMethodExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameAnonymousMethodExpressionSyntax(item as AnonymousMethodExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedTypeArgumentSyntax)
                            _taErrorCodes.Add(
                                new TameOmittedTypeArgumentSyntax(item as OmittedTypeArgumentSyntax) {TaParent = this});
                        else if (item is BaseExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameBaseExpressionSyntax(item as BaseExpressionSyntax) {TaParent = this});
                        else if (item is PredefinedTypeSyntax)
                            _taErrorCodes.Add(
                                new TamePredefinedTypeSyntax(item as PredefinedTypeSyntax) {TaParent = this});
                        else if (item is ThisExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameThisExpressionSyntax(item as ThisExpressionSyntax) {TaParent = this});
                        else if (item is NullableTypeSyntax)
                            _taErrorCodes.Add(new TameNullableTypeSyntax(item as NullableTypeSyntax) {TaParent = this});
                        else if (item is PointerTypeSyntax)
                            _taErrorCodes.Add(new TamePointerTypeSyntax(item as PointerTypeSyntax) {TaParent = this});
                        else if (item is ArrayTypeSyntax)
                            _taErrorCodes.Add(new TameArrayTypeSyntax(item as ArrayTypeSyntax) {TaParent = this});
                        else if (item is TupleTypeSyntax)
                            _taErrorCodes.Add(new TameTupleTypeSyntax(item as TupleTypeSyntax) {TaParent = this});
                        else if (item is RefTypeSyntax)
                            _taErrorCodes.Add(new TameRefTypeSyntax(item as RefTypeSyntax) {TaParent = this});
                        else if (item is AnonymousObjectCreationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameAnonymousObjectCreationExpressionSyntax(
                                    item as AnonymousObjectCreationExpressionSyntax) {TaParent = this});
                        else if (item is StackAllocArrayCreationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameStackAllocArrayCreationExpressionSyntax(
                                    item as StackAllocArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is ImplicitArrayCreationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameImplicitArrayCreationExpressionSyntax(
                                    item as ImplicitArrayCreationExpressionSyntax) {TaParent = this});
                        else if (item is InterpolatedStringExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameInterpolatedStringExpressionSyntax(item as InterpolatedStringExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalAccessExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameConditionalAccessExpressionSyntax(item as ConditionalAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OmittedArraySizeExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameOmittedArraySizeExpressionSyntax(item as OmittedArraySizeExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementBindingExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameElementBindingExpressionSyntax(item as ElementBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ObjectCreationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameObjectCreationExpressionSyntax(item as ObjectCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ArrayCreationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameArrayCreationExpressionSyntax(item as ArrayCreationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ElementAccessExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameElementAccessExpressionSyntax(item as ElementAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberBindingExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameMemberBindingExpressionSyntax(item as MemberBindingExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ParenthesizedExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameParenthesizedExpressionSyntax(item as ParenthesizedExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is MemberAccessExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameMemberAccessExpressionSyntax(item as MemberAccessExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PostfixUnaryExpressionSyntax)
                            _taErrorCodes.Add(
                                new TamePostfixUnaryExpressionSyntax(item as PostfixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConditionalExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameConditionalExpressionSyntax(item as ConditionalExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DeclarationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameDeclarationExpressionSyntax(item as DeclarationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ImplicitElementAccessSyntax)
                            _taErrorCodes.Add(
                                new TameImplicitElementAccessSyntax(item as ImplicitElementAccessSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InitializerExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameInitializerExpressionSyntax(item as InitializerExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is PrefixUnaryExpressionSyntax)
                            _taErrorCodes.Add(
                                new TamePrefixUnaryExpressionSyntax(item as PrefixUnaryExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is AssignmentExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameAssignmentExpressionSyntax(item as AssignmentExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is InvocationExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameInvocationExpressionSyntax(item as InvocationExpressionSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is IsPatternExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameIsPatternExpressionSyntax(item as IsPatternExpressionSyntax) {TaParent = this});
                        else if (item is RefValueExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameRefValueExpressionSyntax(item as RefValueExpressionSyntax) {TaParent = this});
                        else if (item is CheckedExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameCheckedExpressionSyntax(item as CheckedExpressionSyntax) {TaParent = this});
                        else if (item is DefaultExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameDefaultExpressionSyntax(item as DefaultExpressionSyntax) {TaParent = this});
                        else if (item is LiteralExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameLiteralExpressionSyntax(item as LiteralExpressionSyntax) {TaParent = this});
                        else if (item is MakeRefExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameMakeRefExpressionSyntax(item as MakeRefExpressionSyntax) {TaParent = this});
                        else if (item is RefTypeExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameRefTypeExpressionSyntax(item as RefTypeExpressionSyntax) {TaParent = this});
                        else if (item is BinaryExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameBinaryExpressionSyntax(item as BinaryExpressionSyntax) {TaParent = this});
                        else if (item is SizeOfExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameSizeOfExpressionSyntax(item as SizeOfExpressionSyntax) {TaParent = this});
                        else if (item is TypeOfExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameTypeOfExpressionSyntax(item as TypeOfExpressionSyntax) {TaParent = this});
                        else if (item is AwaitExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameAwaitExpressionSyntax(item as AwaitExpressionSyntax) {TaParent = this});
                        else if (item is QueryExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameQueryExpressionSyntax(item as QueryExpressionSyntax) {TaParent = this});
                        else if (item is ThrowExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameThrowExpressionSyntax(item as ThrowExpressionSyntax) {TaParent = this});
                        else if (item is TupleExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameTupleExpressionSyntax(item as TupleExpressionSyntax) {TaParent = this});
                        else if (item is CastExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameCastExpressionSyntax(item as CastExpressionSyntax) {TaParent = this});
                        else if (item is RefExpressionSyntax)
                            _taErrorCodes.Add(
                                new TameRefExpressionSyntax(item as RefExpressionSyntax) {TaParent = this});
                        else if (item is ExpressionSyntax)
                            _taErrorCodes.Add(new TameExpressionSyntax(item) {TaParent = this});
                }
                return _taErrorCodes;
            }
            set
            {
                if (_taErrorCodes != value)
                {
                    _taErrorCodes = value;
                    _taErrorCodes?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaErrorCodesIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taErrorCodes = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _pragmaKeyword = ((PragmaWarningDirectiveTriviaSyntax) Node).PragmaKeyword;
            _pragmaKeywordIsChanged = false;
            _warningKeyword = ((PragmaWarningDirectiveTriviaSyntax) Node).WarningKeyword;
            _warningKeywordIsChanged = false;
            _disableOrRestoreKeyword = ((PragmaWarningDirectiveTriviaSyntax) Node).DisableOrRestoreKeyword;
            _disableOrRestoreKeywordIsChanged = false;
            _errorCodes = ((PragmaWarningDirectiveTriviaSyntax) Node).ErrorCodes;
            _errorCodesIsChanged = false;
            _errorCodesCount = _errorCodes.Count;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaErrorCodes)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.PragmaWarningDirectiveTrivia(HashToken, PragmaKeyword, WarningKeyword,
                DisableOrRestoreKeyword, ErrorCodes, EndOfDirectiveToken, IsActive);
// if (DirectiveNameToken != null) res = res.WithDirectiveNameToken(DirectiveNameToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaErrorCodes)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("PragmaKeywordStr", PragmaKeywordStr);
            yield return ("WarningKeywordStr", WarningKeywordStr);
            yield return ("DisableOrRestoreKeywordStr", DisableOrRestoreKeywordStr);
            yield return ("ErrorCodesStr", ErrorCodesStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }

        public TamePragmaWarningDirectiveTriviaSyntax AddErrorCode(TameExpressionSyntax item)
        {
            item.TaParent = this;
            TaErrorCodes.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}