// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameTypeDeclarationSyntax : TameBaseTypeDeclarationSyntax
    {
        public new static string TypeName = "TypeDeclarationSyntax";
        private int _arity;
        private bool _arityIsChanged;
        private SyntaxList<TypeParameterConstraintClauseSyntax> _constraintClauses;
        private int _constraintClausesCount;
        private bool _constraintClausesIsChanged;
        private string _constraintClausesStr;
        private SyntaxToken _keyword;
        private bool _keywordIsChanged;
        private string _keywordStr;
        private SyntaxList<MemberDeclarationSyntax> _members;
        private int _membersCount;
        private bool _membersIsChanged;
        private string _membersStr;
        private List<TameTypeParameterConstraintClauseSyntax> _taConstraintClauses;
        private List<TameMemberDeclarationSyntax> _taMembers;
        private TameTypeParameterListSyntax _taTypeParameterList;
        private TypeParameterListSyntax _typeParameterList;
        private bool _typeParameterListIsChanged;
        private string _typeParameterListStr;

        public TameTypeDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTypeDeclaration(code);
            AddChildren();
        }

        public TameTypeDeclarationSyntax(TypeDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTypeDeclarationSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;

        public int Arity
        {
            get { return _arity; }
            set
            {
                if (_arity != value)
                {
                    _arity = value;
                    _arityIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public SyntaxToken Keyword
        {
            get
            {
                if (_keywordIsChanged)
                {
                    _keyword = SyntaxFactoryStr.ParseSyntaxToken(KeywordStr);
                    _keywordIsChanged = false;
                }
                return _keyword;
            }
            set
            {
                if (_keyword != value)
                {
                    _keyword = value;
                    _keywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string KeywordStr
        {
            get
            {
                if (_keywordIsChanged) return _keywordStr;
                return _keywordStr = _keyword.Text;
            }
            set
            {
                if (_keywordStr != value)
                {
                    _keywordStr = value;
                    IsChanged = true;
                    _keywordIsChanged = true;
                }
            }
        }

        public TypeParameterListSyntax TypeParameterList
        {
            get
            {
                if (_typeParameterListIsChanged)
                {
                    _typeParameterList = SyntaxFactoryStr.ParseTypeParameterListSyntax(TypeParameterListStr);
                    _typeParameterListIsChanged = false;
                    _taTypeParameterList = null;
                }
                else if (_taTypeParameterList != null && _taTypeParameterList.IsChanged)
                {
                    _typeParameterList = (TypeParameterListSyntax) _taTypeParameterList.Node;
                }
                return _typeParameterList;
            }
            set
            {
                if (_typeParameterList != value)
                {
                    _typeParameterList = value;
                    _typeParameterListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeParameterListStr
        {
            get
            {
                if (_taTypeParameterList != null && _taTypeParameterList.IsChanged)
                    TypeParameterList = (TypeParameterListSyntax) _taTypeParameterList.Node;
                if (_typeParameterListIsChanged) return _typeParameterListStr;
                return _typeParameterListStr = _typeParameterList?.ToFullString();
            }
            set
            {
                if (_taTypeParameterList != null && _taTypeParameterList.IsChanged)
                {
                    TypeParameterList = (TypeParameterListSyntax) _taTypeParameterList.Node;
                    _typeParameterListStr = _typeParameterList?.ToFullString();
                }
                if (_typeParameterListStr != value)
                {
                    _typeParameterListStr = value;
                    IsChanged = true;
                    _typeParameterListIsChanged = true;
                    _taTypeParameterList = null;
                }
            }
        }

        public TameTypeParameterListSyntax TaTypeParameterList
        {
            get
            {
                if (_taTypeParameterList == null && TypeParameterList != null)
                {
                    _taTypeParameterList = new TameTypeParameterListSyntax(TypeParameterList) {TaParent = this};
                    _taTypeParameterList.AddChildren();
                }
                return _taTypeParameterList;
            }
            set
            {
                if (_taTypeParameterList != value)
                {
                    _taTypeParameterList = value;
                    if (_taTypeParameterList != null)
                    {
                        _taTypeParameterList.TaParent = this;
                        _taTypeParameterList.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public bool TaConstraintClausesIsChanged { get; set; }

        public SyntaxList<TypeParameterConstraintClauseSyntax> ConstraintClauses
        {
            get
            {
                if (TaConstraintClausesIsChanged || _taConstraintClauses != null &&
                    (_taConstraintClauses.Count != _constraintClausesCount ||
                     _taConstraintClauses.Any(v => v.IsChanged)))
                {
                    _constraintClauses = SyntaxFactory.List(TaConstraintClauses?.Select(v => v.Node)
                        .Cast<TypeParameterConstraintClauseSyntax>());
                    TaConstraintClausesIsChanged = false;
                }
                return _constraintClauses;
            }
            set
            {
                if (_constraintClauses != value)
                {
                    _constraintClauses = value;
                    TaConstraintClausesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ConstraintClausesStr
        {
            get
            {
                if (_constraintClausesIsChanged) return _constraintClausesStr;
                return _constraintClausesStr = string.Join(", ", _constraintClauses.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _constraintClausesStr = value;
                    ConstraintClauses = new SyntaxList<TypeParameterConstraintClauseSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameTypeParameterConstraintClauseSyntax> TaConstraintClauses
        {
            get
            {
                if (_taConstraintClauses == null)
                {
                    _taConstraintClauses = new List<TameTypeParameterConstraintClauseSyntax>();
                    foreach (var item in _constraintClauses)
                        _taConstraintClauses.Add(new TameTypeParameterConstraintClauseSyntax(item) {TaParent = this});
                }
                return _taConstraintClauses;
            }
            set
            {
                if (_taConstraintClauses != value)
                {
                    _taConstraintClauses = value;
                    _taConstraintClauses?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaConstraintClausesIsChanged = true;
                }
            }
        }

        public bool TaMembersIsChanged { get; set; }

        public SyntaxList<MemberDeclarationSyntax> Members
        {
            get
            {
                if (TaMembersIsChanged || _taMembers != null &&
                    (_taMembers.Count != _membersCount || _taMembers.Any(v => v.IsChanged)))
                {
                    _members = SyntaxFactory.List(TaMembers?.Select(v => v.Node).Cast<MemberDeclarationSyntax>());
                    TaMembersIsChanged = false;
                }
                return _members;
            }
            set
            {
                if (_members != value)
                {
                    _members = value;
                    TaMembersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string MembersStr
        {
            get
            {
                if (_membersIsChanged) return _membersStr;
                return _membersStr = string.Join(", ", _members.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _membersStr = value;
                    Members = new SyntaxList<MemberDeclarationSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameMemberDeclarationSyntax> TaMembers
        {
            get
            {
                if (_taMembers == null)
                {
                    _taMembers = new List<TameMemberDeclarationSyntax>();
                    foreach (var item in _members)
                        if (item is InterfaceDeclarationSyntax)
                            _taMembers.Add(
                                new TameInterfaceDeclarationSyntax(item as InterfaceDeclarationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is StructDeclarationSyntax)
                            _taMembers.Add(
                                new TameStructDeclarationSyntax(item as StructDeclarationSyntax) {TaParent = this});
                        else if (item is ClassDeclarationSyntax)
                            _taMembers.Add(
                                new TameClassDeclarationSyntax(item as ClassDeclarationSyntax) {TaParent = this});
                        else if (item is ConversionOperatorDeclarationSyntax)
                            _taMembers.Add(
                                new TameConversionOperatorDeclarationSyntax(
                                    item as ConversionOperatorDeclarationSyntax) {TaParent = this});
                        else if (item is ConstructorDeclarationSyntax)
                            _taMembers.Add(
                                new TameConstructorDeclarationSyntax(item as ConstructorDeclarationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DestructorDeclarationSyntax)
                            _taMembers.Add(
                                new TameDestructorDeclarationSyntax(item as DestructorDeclarationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is EventFieldDeclarationSyntax)
                            _taMembers.Add(
                                new TameEventFieldDeclarationSyntax(item as EventFieldDeclarationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is OperatorDeclarationSyntax)
                            _taMembers.Add(
                                new TameOperatorDeclarationSyntax(item as OperatorDeclarationSyntax) {TaParent = this});
                        else if (item is PropertyDeclarationSyntax)
                            _taMembers.Add(
                                new TamePropertyDeclarationSyntax(item as PropertyDeclarationSyntax) {TaParent = this});
                        else if (item is IndexerDeclarationSyntax)
                            _taMembers.Add(
                                new TameIndexerDeclarationSyntax(item as IndexerDeclarationSyntax) {TaParent = this});
                        else if (item is MethodDeclarationSyntax)
                            _taMembers.Add(
                                new TameMethodDeclarationSyntax(item as MethodDeclarationSyntax) {TaParent = this});
                        else if (item is EventDeclarationSyntax)
                            _taMembers.Add(
                                new TameEventDeclarationSyntax(item as EventDeclarationSyntax) {TaParent = this});
                        else if (item is FieldDeclarationSyntax)
                            _taMembers.Add(
                                new TameFieldDeclarationSyntax(item as FieldDeclarationSyntax) {TaParent = this});
                        else if (item is EnumDeclarationSyntax)
                            _taMembers.Add(
                                new TameEnumDeclarationSyntax(item as EnumDeclarationSyntax) {TaParent = this});
                        else if (item is EnumMemberDeclarationSyntax)
                            _taMembers.Add(
                                new TameEnumMemberDeclarationSyntax(item as EnumMemberDeclarationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is NamespaceDeclarationSyntax)
                            _taMembers.Add(
                                new TameNamespaceDeclarationSyntax(item as NamespaceDeclarationSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is DelegateDeclarationSyntax)
                            _taMembers.Add(
                                new TameDelegateDeclarationSyntax(item as DelegateDeclarationSyntax) {TaParent = this});
                        else if (item is IncompleteMemberSyntax)
                            _taMembers.Add(
                                new TameIncompleteMemberSyntax(item as IncompleteMemberSyntax) {TaParent = this});
                        else if (item is GlobalStatementSyntax)
                            _taMembers.Add(
                                new TameGlobalStatementSyntax(item as GlobalStatementSyntax) {TaParent = this});
                        else if (item is MemberDeclarationSyntax)
                            _taMembers.Add(new TameMemberDeclarationSyntax(item) {TaParent = this});
                }
                return _taMembers;
            }
            set
            {
                if (_taMembers != value)
                {
                    _taMembers = value;
                    _taMembers?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaMembersIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taTypeParameterList = null;
            _taConstraintClauses = null;
            _taMembers = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _arity = ((TypeDeclarationSyntax) Node).Arity;
            _arityIsChanged = false;
            _keyword = ((TypeDeclarationSyntax) Node).Keyword;
            _keywordIsChanged = false;
            _typeParameterList = ((TypeDeclarationSyntax) Node).TypeParameterList;
            _typeParameterListIsChanged = false;
            _constraintClauses = ((TypeDeclarationSyntax) Node).ConstraintClauses;
            _constraintClausesIsChanged = false;
            _constraintClausesCount = _constraintClauses.Count;
            _members = ((TypeDeclarationSyntax) Node).Members;
            _membersIsChanged = false;
            _membersCount = _members.Count;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaConstraintClauses)
                item.SetNotChanged();
            foreach (var item in TaMembers)
                item.SetNotChanged();
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            return SyntaxFacts.GetTypeDeclarationKind(TameSyntaxFacts.SyntaxKindFromStr(KeywordStr));
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TypeDeclaration(GetKind(), Identifier);
// if (Arity != null) res = res.WithArity(Arity);
// if (Keyword != null) res = res.WithKeyword(Keyword);
// if (TypeParameterList != null) res = res.WithTypeParameterList(TypeParameterList);
// if (Modifiers != null) res = res.WithModifiers(Modifiers);
// if (BaseList != null) res = res.WithBaseList(BaseList);
// if (OpenBraceToken != null) res = res.WithOpenBraceToken(OpenBraceToken);
// if (CloseBraceToken != null) res = res.WithCloseBraceToken(CloseBraceToken);
// if (SemicolonToken != null) res = res.WithSemicolonToken(SemicolonToken);
// if (ConstraintClauses?.Any() == true)
// res = res.WithConstraintClauses(ConstraintClauses.Select(v => v.Node).Cast<SyntaxList<TypeParameterConstraintClauseSyntax>>().ToArray());
// if (Members?.Any() == true)
// res = res.WithMembers(Members.Select(v => v.Node).Cast<SyntaxList<MemberDeclarationSyntax>>().ToArray());
// if (AttributeLists?.Any() == true)
// res = res.WithAttributeLists(AttributeLists.Select(v => v.Node).Cast<SyntaxList<AttributeListSyntax>>().ToArray());
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaConstraintClauses)
                yield return item;
            foreach (var item in TaMembers)
                yield return item;
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaTypeParameterList != null) yield return TaTypeParameterList;
            if (TaBaseList != null) yield return TaBaseList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("Arity", Arity.ToString());
            yield return ("KeywordStr", KeywordStr);
            yield return ("TypeParameterListStr", TypeParameterListStr);
            yield return ("ConstraintClausesStr", ConstraintClausesStr);
            yield return ("MembersStr", MembersStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("BaseListStr", BaseListStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}