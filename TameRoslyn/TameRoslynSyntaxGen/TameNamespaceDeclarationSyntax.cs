// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameNamespaceDeclarationSyntax : TameMemberDeclarationSyntax
    {
        public new static string TypeName = "NamespaceDeclarationSyntax";
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SyntaxList<ExternAliasDirectiveSyntax> _externs;
        private int _externsCount;
        private bool _externsIsChanged;
        private string _externsStr;
        private SyntaxList<MemberDeclarationSyntax> _members;
        private int _membersCount;
        private bool _membersIsChanged;
        private string _membersStr;
        private NameSyntax _name;
        private bool _nameIsChanged;
        private SyntaxToken _namespaceKeyword;
        private bool _namespaceKeywordIsChanged;
        private string _namespaceKeywordStr;
        private string _nameStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private List<TameExternAliasDirectiveSyntax> _taExterns;
        private List<TameMemberDeclarationSyntax> _taMembers;
        private TameNameSyntax _taName;
        private List<TameUsingDirectiveSyntax> _taUsings;
        private SyntaxList<UsingDirectiveSyntax> _usings;
        private int _usingsCount;
        private bool _usingsIsChanged;
        private string _usingsStr;

        public TameNamespaceDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseNamespaceDeclaration(code);
            AddChildren();
        }

        public TameNamespaceDeclarationSyntax(NamespaceDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameNamespaceDeclarationSyntax()
        {
            NamespaceKeywordStr = DefaultValues.NamespaceDeclarationSyntaxNamespaceKeywordStr;
            NameStr = DefaultValues.NamespaceDeclarationSyntaxNameStr;
            OpenBraceTokenStr = DefaultValues.NamespaceDeclarationSyntaxOpenBraceTokenStr;
            ExternsStr = DefaultValues.NamespaceDeclarationSyntaxExternsStr;
            UsingsStr = DefaultValues.NamespaceDeclarationSyntaxUsingsStr;
            MembersStr = DefaultValues.NamespaceDeclarationSyntaxMembersStr;
            CloseBraceTokenStr = DefaultValues.NamespaceDeclarationSyntaxCloseBraceTokenStr;
            SemicolonTokenStr = DefaultValues.NamespaceDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken NamespaceKeyword
        {
            get
            {
                if (_namespaceKeywordIsChanged)
                {
                    if (_namespaceKeywordStr == null) _namespaceKeyword = default(SyntaxToken);
                    else
                        _namespaceKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_namespaceKeywordStr, SyntaxKind.NamespaceKeyword);
                    _namespaceKeywordIsChanged = false;
                }
                return _namespaceKeyword;
            }
            set
            {
                if (_namespaceKeyword != value)
                {
                    _namespaceKeyword = value;
                    _namespaceKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NamespaceKeywordStr
        {
            get
            {
                if (_namespaceKeywordIsChanged) return _namespaceKeywordStr;
                return _namespaceKeywordStr = _namespaceKeyword.Text;
            }
            set
            {
                if (_namespaceKeywordStr != value)
                {
                    _namespaceKeywordStr = value;
                    IsChanged = true;
                    _namespaceKeywordIsChanged = true;
                }
            }
        }

        public NameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (NameSyntax) _taName.Node;
                }
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    _nameIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NameStr
        {
            get
            {
                if (_taName != null && _taName.IsChanged)
                    Name = (NameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (NameSyntax) _taName.Node;
                    _nameStr = _name?.ToFullString();
                }
                if (_nameStr != value)
                {
                    _nameStr = value;
                    IsChanged = true;
                    _nameIsChanged = true;
                    _taName = null;
                }
            }
        }

        public TameNameSyntax TaName
        {
            get
            {
                if (_taName == null && Name != null)
                    if (Name is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                return _taName;
            }
            set
            {
                if (_taName != value)
                {
                    _taName = value;
                    if (_taName != null)
                    {
                        _taName.TaParent = this;
                        _taName.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

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

        public bool TaExternsIsChanged { get; set; }

        public SyntaxList<ExternAliasDirectiveSyntax> Externs
        {
            get
            {
                if (TaExternsIsChanged || _taExterns != null &&
                    (_taExterns.Count != _externsCount || _taExterns.Any(v => v.IsChanged)))
                {
                    _externs = SyntaxFactory.List(TaExterns?.Select(v => v.Node).Cast<ExternAliasDirectiveSyntax>());
                    TaExternsIsChanged = false;
                }
                return _externs;
            }
            set
            {
                if (_externs != value)
                {
                    _externs = value;
                    TaExternsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExternsStr
        {
            get
            {
                if (_externsIsChanged) return _externsStr;
                return _externsStr = string.Join(", ", _externs.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _externsStr = value;
                    Externs = new SyntaxList<ExternAliasDirectiveSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameExternAliasDirectiveSyntax> TaExterns
        {
            get
            {
                if (_taExterns == null)
                {
                    _taExterns = new List<TameExternAliasDirectiveSyntax>();
                    foreach (var item in _externs)
                        _taExterns.Add(new TameExternAliasDirectiveSyntax(item) {TaParent = this});
                }
                return _taExterns;
            }
            set
            {
                if (_taExterns != value)
                {
                    _taExterns = value;
                    _taExterns?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaExternsIsChanged = true;
                }
            }
        }

        public bool TaUsingsIsChanged { get; set; }

        public SyntaxList<UsingDirectiveSyntax> Usings
        {
            get
            {
                if (TaUsingsIsChanged || _taUsings != null &&
                    (_taUsings.Count != _usingsCount || _taUsings.Any(v => v.IsChanged)))
                {
                    _usings = SyntaxFactory.List(TaUsings?.Select(v => v.Node).Cast<UsingDirectiveSyntax>());
                    TaUsingsIsChanged = false;
                }
                return _usings;
            }
            set
            {
                if (_usings != value)
                {
                    _usings = value;
                    TaUsingsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string UsingsStr
        {
            get
            {
                if (_usingsIsChanged) return _usingsStr;
                return _usingsStr = string.Join(", ", _usings.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _usingsStr = value;
                    Usings = new SyntaxList<UsingDirectiveSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameUsingDirectiveSyntax> TaUsings
        {
            get
            {
                if (_taUsings == null)
                {
                    _taUsings = new List<TameUsingDirectiveSyntax>();
                    foreach (var item in _usings)
                        _taUsings.Add(new TameUsingDirectiveSyntax(item) {TaParent = this});
                }
                return _taUsings;
            }
            set
            {
                if (_taUsings != value)
                {
                    _taUsings = value;
                    _taUsings?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaUsingsIsChanged = true;
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

        public SyntaxToken SemicolonToken
        {
            get
            {
                if (_semicolonTokenIsChanged)
                {
                    if (_semicolonTokenStr == null) _semicolonToken = default(SyntaxToken);
                    else
                        _semicolonToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_semicolonTokenStr, SyntaxKind.SemicolonToken);
                    _semicolonTokenIsChanged = false;
                }
                return _semicolonToken;
            }
            set
            {
                if (_semicolonToken != value)
                {
                    _semicolonToken = value;
                    _semicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonTokenStr
        {
            get
            {
                if (_semicolonTokenIsChanged) return _semicolonTokenStr;
                return _semicolonTokenStr = _semicolonToken.Text;
            }
            set
            {
                if (_semicolonTokenStr != value)
                {
                    _semicolonTokenStr = value;
                    IsChanged = true;
                    _semicolonTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taName = null;
            _taExterns = null;
            _taUsings = null;
            _taMembers = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _namespaceKeyword = ((NamespaceDeclarationSyntax) Node).NamespaceKeyword;
            _namespaceKeywordIsChanged = false;
            _name = ((NamespaceDeclarationSyntax) Node).Name;
            _nameIsChanged = false;
            _openBraceToken = ((NamespaceDeclarationSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _externs = ((NamespaceDeclarationSyntax) Node).Externs;
            _externsIsChanged = false;
            _externsCount = _externs.Count;
            _usings = ((NamespaceDeclarationSyntax) Node).Usings;
            _usingsIsChanged = false;
            _usingsCount = _usings.Count;
            _members = ((NamespaceDeclarationSyntax) Node).Members;
            _membersIsChanged = false;
            _membersCount = _members.Count;
            _closeBraceToken = ((NamespaceDeclarationSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
            _semicolonToken = ((NamespaceDeclarationSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaExterns)
                item.SetNotChanged();
            foreach (var item in TaUsings)
                item.SetNotChanged();
            foreach (var item in TaMembers)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.NamespaceDeclaration(NamespaceKeyword, Name, OpenBraceToken, Externs, Usings,
                Members, CloseBraceToken, SemicolonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaExterns)
                yield return item;
            foreach (var item in TaUsings)
                yield return item;
            foreach (var item in TaMembers)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NamespaceKeywordStr", NamespaceKeywordStr);
            yield return ("NameStr", NameStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("ExternsStr", ExternsStr);
            yield return ("UsingsStr", UsingsStr);
            yield return ("MembersStr", MembersStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameNamespaceDeclarationSyntax AddExtern(TameExternAliasDirectiveSyntax item)
        {
            item.TaParent = this;
            TaExterns.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameNamespaceDeclarationSyntax AddUsing(TameUsingDirectiveSyntax item)
        {
            item.TaParent = this;
            TaUsings.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameNamespaceDeclarationSyntax AddMember(TameMemberDeclarationSyntax item)
        {
            item.TaParent = this;
            TaMembers.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}