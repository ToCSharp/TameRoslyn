// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameEnumDeclarationSyntax : TameBaseTypeDeclarationSyntax
    {
        public new static string TypeName = "EnumDeclarationSyntax";
        private SyntaxToken _enumKeyword;
        private bool _enumKeywordIsChanged;
        private string _enumKeywordStr;
        private SeparatedSyntaxList<EnumMemberDeclarationSyntax> _members;
        private int _membersCount;
        private bool _membersIsChanged;
        private string _membersStr;
        private List<TameEnumMemberDeclarationSyntax> _taMembers;

        public TameEnumDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseEnumDeclaration(code);
            AddChildren();
        }

        public TameEnumDeclarationSyntax(EnumDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameEnumDeclarationSyntax()
        {
            EnumKeywordStr = DefaultValues.EnumDeclarationSyntaxEnumKeywordStr;
            MembersStr = DefaultValues.EnumDeclarationSyntaxMembersStr;
            AttributeListsStr = DefaultValues.EnumDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.EnumDeclarationSyntaxModifiersStr;
            IdentifierStr = DefaultValues.EnumDeclarationSyntaxIdentifierStr;
            BaseListStr = DefaultValues.EnumDeclarationSyntaxBaseListStr;
            OpenBraceTokenStr = DefaultValues.EnumDeclarationSyntaxOpenBraceTokenStr;
            CloseBraceTokenStr = DefaultValues.EnumDeclarationSyntaxCloseBraceTokenStr;
            SemicolonTokenStr = DefaultValues.EnumDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken EnumKeyword
        {
            get
            {
                if (_enumKeywordIsChanged)
                {
                    if (_enumKeywordStr == null) _enumKeyword = default(SyntaxToken);
                    else _enumKeyword = SyntaxFactoryStr.ParseSyntaxToken(_enumKeywordStr, SyntaxKind.EnumKeyword);
                    _enumKeywordIsChanged = false;
                }
                return _enumKeyword;
            }
            set
            {
                if (_enumKeyword != value)
                {
                    _enumKeyword = value;
                    _enumKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EnumKeywordStr
        {
            get
            {
                if (_enumKeywordIsChanged) return _enumKeywordStr;
                return _enumKeywordStr = _enumKeyword.Text;
            }
            set
            {
                if (_enumKeywordStr != value)
                {
                    _enumKeywordStr = value;
                    IsChanged = true;
                    _enumKeywordIsChanged = true;
                }
            }
        }

        public bool TaMembersIsChanged { get; set; }

        public SeparatedSyntaxList<EnumMemberDeclarationSyntax> Members
        {
            get
            {
                if (TaMembersIsChanged || _taMembers != null &&
                    (_taMembers.Count != _membersCount || _taMembers.Any(v => v.IsChanged)))
                {
                    _members = SyntaxFactory.SeparatedList(TaMembers?.Select(v => v.Node)
                        .Cast<EnumMemberDeclarationSyntax>());
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
                    Members = new SeparatedSyntaxList<EnumMemberDeclarationSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameEnumMemberDeclarationSyntax> TaMembers
        {
            get
            {
                if (_taMembers == null)
                {
                    _taMembers = new List<TameEnumMemberDeclarationSyntax>();
                    foreach (var item in _members)
                        _taMembers.Add(new TameEnumMemberDeclarationSyntax(item) {TaParent = this});
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
            _taMembers = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _enumKeyword = ((EnumDeclarationSyntax) Node).EnumKeyword;
            _enumKeywordIsChanged = false;
            _members = ((EnumDeclarationSyntax) Node).Members;
            _membersIsChanged = false;
            _membersCount = _members.Count;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaMembers)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.EnumDeclaration(AttributeLists, Modifiers, EnumKeyword, Identifier, BaseList,
                OpenBraceToken, Members, CloseBraceToken, SemicolonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaMembers)
                yield return item;
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaBaseList != null) yield return TaBaseList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("EnumKeywordStr", EnumKeywordStr);
            yield return ("MembersStr", MembersStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("BaseListStr", BaseListStr);
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameEnumDeclarationSyntax AddMember(TameEnumMemberDeclarationSyntax item)
        {
            item.TaParent = this;
            TaMembers.Add(item);
            item.IsChanged = true;
            return this;
        }

        public TameEnumDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}