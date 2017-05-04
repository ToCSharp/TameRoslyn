// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCompilationUnitSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "CompilationUnitSyntax";
        private SyntaxList<AttributeListSyntax> _attributeLists;
        private int _attributeListsCount;
        private bool _attributeListsIsChanged;
        private string _attributeListsStr;
        private SyntaxToken _endOfFileToken;
        private bool _endOfFileTokenIsChanged;
        private string _endOfFileTokenStr;
        private SyntaxList<ExternAliasDirectiveSyntax> _externs;
        private int _externsCount;
        private bool _externsIsChanged;
        private string _externsStr;
        private SyntaxList<MemberDeclarationSyntax> _members;
        private int _membersCount;
        private bool _membersIsChanged;
        private string _membersStr;
        private List<TameAttributeListSyntax> _taAttributeLists;
        private List<TameExternAliasDirectiveSyntax> _taExterns;
        private List<TameMemberDeclarationSyntax> _taMembers;
        private List<TameUsingDirectiveSyntax> _taUsings;
        private SyntaxList<UsingDirectiveSyntax> _usings;
        private int _usingsCount;
        private bool _usingsIsChanged;
        private string _usingsStr;

        public TameCompilationUnitSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCompilationUnit(code);
            AddChildren();
        }

        public TameCompilationUnitSyntax(CompilationUnitSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCompilationUnitSyntax()
        {
            ExternsStr = DefaultValues.CompilationUnitSyntaxExternsStr;
            UsingsStr = DefaultValues.CompilationUnitSyntaxUsingsStr;
            AttributeListsStr = DefaultValues.CompilationUnitSyntaxAttributeListsStr;
            MembersStr = DefaultValues.CompilationUnitSyntaxMembersStr;
            EndOfFileTokenStr = DefaultValues.CompilationUnitSyntaxEndOfFileTokenStr;
        }

        public override string RoslynTypeName => TypeName;
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

        public bool TaAttributeListsIsChanged { get; set; }

        public SyntaxList<AttributeListSyntax> AttributeLists
        {
            get
            {
                if (TaAttributeListsIsChanged || _taAttributeLists != null &&
                    (_taAttributeLists.Count != _attributeListsCount || _taAttributeLists.Any(v => v.IsChanged)))
                {
                    _attributeLists = SyntaxFactory.List(TaAttributeLists?.Select(v => v.Node)
                        .Cast<AttributeListSyntax>());
                    TaAttributeListsIsChanged = false;
                }
                return _attributeLists;
            }
            set
            {
                if (_attributeLists != value)
                {
                    _attributeLists = value;
                    TaAttributeListsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AttributeListsStr
        {
            get
            {
                if (_attributeListsIsChanged) return _attributeListsStr;
                return _attributeListsStr = string.Join(", ", _attributeLists.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _attributeListsStr = value;
                    AttributeLists = new SyntaxList<AttributeListSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAttributeListSyntax> TaAttributeLists
        {
            get
            {
                if (_taAttributeLists == null)
                {
                    _taAttributeLists = new List<TameAttributeListSyntax>();
                    foreach (var item in _attributeLists)
                        _taAttributeLists.Add(new TameAttributeListSyntax(item) {TaParent = this});
                }
                return _taAttributeLists;
            }
            set
            {
                if (_taAttributeLists != value)
                {
                    _taAttributeLists = value;
                    _taAttributeLists?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAttributeListsIsChanged = true;
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

        public SyntaxToken EndOfFileToken
        {
            get
            {
                if (_endOfFileTokenIsChanged)
                {
                    if (_endOfFileTokenStr == null) _endOfFileToken = default(SyntaxToken);
                    else
                        _endOfFileToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_endOfFileTokenStr, SyntaxKind.EndOfFileToken);
                    _endOfFileTokenIsChanged = false;
                }
                return _endOfFileToken;
            }
            set
            {
                if (_endOfFileToken != value)
                {
                    _endOfFileToken = value;
                    _endOfFileTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EndOfFileTokenStr
        {
            get
            {
                if (_endOfFileTokenIsChanged) return _endOfFileTokenStr;
                return _endOfFileTokenStr = _endOfFileToken.Text;
            }
            set
            {
                if (_endOfFileTokenStr != value)
                {
                    _endOfFileTokenStr = value;
                    IsChanged = true;
                    _endOfFileTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taExterns = null;
            _taUsings = null;
            _taAttributeLists = null;
            _taMembers = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _externs = ((CompilationUnitSyntax) Node).Externs;
            _externsIsChanged = false;
            _externsCount = _externs.Count;
            _usings = ((CompilationUnitSyntax) Node).Usings;
            _usingsIsChanged = false;
            _usingsCount = _usings.Count;
            _attributeLists = ((CompilationUnitSyntax) Node).AttributeLists;
            _attributeListsIsChanged = false;
            _attributeListsCount = _attributeLists.Count;
            _members = ((CompilationUnitSyntax) Node).Members;
            _membersIsChanged = false;
            _membersCount = _members.Count;
            _endOfFileToken = ((CompilationUnitSyntax) Node).EndOfFileToken;
            _endOfFileTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaExterns)
                item.SetNotChanged();
            foreach (var item in TaUsings)
                item.SetNotChanged();
            foreach (var item in TaAttributeLists)
                item.SetNotChanged();
            foreach (var item in TaMembers)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CompilationUnit(Externs, Usings, AttributeLists, Members, EndOfFileToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaExterns)
                yield return item;
            foreach (var item in TaUsings)
                yield return item;
            foreach (var item in TaAttributeLists)
                yield return item;
            foreach (var item in TaMembers)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ExternsStr", ExternsStr);
            yield return ("UsingsStr", UsingsStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("MembersStr", MembersStr);
            yield return ("EndOfFileTokenStr", EndOfFileTokenStr);
        }

        public TameCompilationUnitSyntax AddExtern(TameExternAliasDirectiveSyntax item)
        {
            item.TaParent = this;
            TaExterns.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameCompilationUnitSyntax AddUsing(TameUsingDirectiveSyntax item)
        {
            item.TaParent = this;
            TaUsings.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameCompilationUnitSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameCompilationUnitSyntax AddMember(TameMemberDeclarationSyntax item)
        {
            item.TaParent = this;
            TaMembers.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}