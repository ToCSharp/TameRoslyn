// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameQualifiedCrefSyntax : TameCrefSyntax
    {
        public new static string TypeName = "QualifiedCrefSyntax";
        private TypeSyntax _container;
        private bool _containerIsChanged;
        private string _containerStr;
        private SyntaxToken _dotToken;
        private bool _dotTokenIsChanged;
        private string _dotTokenStr;
        private MemberCrefSyntax _member;
        private bool _memberIsChanged;
        private string _memberStr;
        private TameTypeSyntax _taContainer;
        private TameMemberCrefSyntax _taMember;

        public TameQualifiedCrefSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseQualifiedCref(code);
            AddChildren();
        }

        public TameQualifiedCrefSyntax(QualifiedCrefSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameQualifiedCrefSyntax()
        {
            // ContainerStr = DefaultValues.QualifiedCrefSyntaxContainerStr;
            // DotTokenStr = DefaultValues.QualifiedCrefSyntaxDotTokenStr;
            // MemberStr = DefaultValues.QualifiedCrefSyntaxMemberStr;
        }

        public override string RoslynTypeName => TypeName;

        public TypeSyntax Container
        {
            get
            {
                if (_containerIsChanged)
                {
                    _container = SyntaxFactoryStr.ParseTypeSyntax(ContainerStr);
                    _containerIsChanged = false;
                    _taContainer = null;
                }
                else if (_taContainer != null && _taContainer.IsChanged)
                {
                    _container = (TypeSyntax) _taContainer.Node;
                }
                return _container;
            }
            set
            {
                if (_container != value)
                {
                    _container = value;
                    _containerIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ContainerStr
        {
            get
            {
                if (_taContainer != null && _taContainer.IsChanged)
                    Container = (TypeSyntax) _taContainer.Node;
                if (_containerIsChanged) return _containerStr;
                return _containerStr = _container?.ToFullString();
            }
            set
            {
                if (_taContainer != null && _taContainer.IsChanged)
                {
                    Container = (TypeSyntax) _taContainer.Node;
                    _containerStr = _container?.ToFullString();
                }
                if (_containerStr != value)
                {
                    _containerStr = value;
                    IsChanged = true;
                    _containerIsChanged = true;
                    _taContainer = null;
                }
            }
        }

        public TameTypeSyntax TaContainer
        {
            get
            {
                if (_taContainer == null && Container != null)
                    if (Container is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is AliasQualifiedNameSyntax)
                    {
                        var loc =
                            new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is OmittedTypeArgumentSyntax)
                    {
                        var loc =
                            new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                    else if (Container is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Container) {TaParent = this};
                        loc.AddChildren();
                        _taContainer = loc;
                    }
                return _taContainer;
            }
            set
            {
                if (_taContainer != value)
                {
                    _taContainer = value;
                    if (_taContainer != null)
                    {
                        _taContainer.TaParent = this;
                        _taContainer.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken DotToken
        {
            get
            {
                if (_dotTokenIsChanged)
                {
                    if (_dotTokenStr == null) _dotToken = default(SyntaxToken);
                    else _dotToken = SyntaxFactoryStr.ParseSyntaxToken(_dotTokenStr, SyntaxKind.DotToken);
                    _dotTokenIsChanged = false;
                }
                return _dotToken;
            }
            set
            {
                if (_dotToken != value)
                {
                    _dotToken = value;
                    _dotTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DotTokenStr
        {
            get
            {
                if (_dotTokenIsChanged) return _dotTokenStr;
                return _dotTokenStr = _dotToken.Text;
            }
            set
            {
                if (_dotTokenStr != value)
                {
                    _dotTokenStr = value;
                    IsChanged = true;
                    _dotTokenIsChanged = true;
                }
            }
        }

        public MemberCrefSyntax Member
        {
            get
            {
                if (_memberIsChanged)
                {
                    _member = SyntaxFactoryStr.ParseMemberCrefSyntax(MemberStr);
                    _memberIsChanged = false;
                    _taMember = null;
                }
                else if (_taMember != null && _taMember.IsChanged)
                {
                    _member = (MemberCrefSyntax) _taMember.Node;
                }
                return _member;
            }
            set
            {
                if (_member != value)
                {
                    _member = value;
                    _memberIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string MemberStr
        {
            get
            {
                if (_taMember != null && _taMember.IsChanged)
                    Member = (MemberCrefSyntax) _taMember.Node;
                if (_memberIsChanged) return _memberStr;
                return _memberStr = _member?.ToFullString();
            }
            set
            {
                if (_taMember != null && _taMember.IsChanged)
                {
                    Member = (MemberCrefSyntax) _taMember.Node;
                    _memberStr = _member?.ToFullString();
                }
                if (_memberStr != value)
                {
                    _memberStr = value;
                    IsChanged = true;
                    _memberIsChanged = true;
                    _taMember = null;
                }
            }
        }

        public TameMemberCrefSyntax TaMember
        {
            get
            {
                if (_taMember == null && Member != null)
                    if (Member is ConversionOperatorMemberCrefSyntax)
                    {
                        var loc =
                            new TameConversionOperatorMemberCrefSyntax((ConversionOperatorMemberCrefSyntax) Member)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taMember = loc;
                    }
                    else if (Member is OperatorMemberCrefSyntax)
                    {
                        var loc = new TameOperatorMemberCrefSyntax((OperatorMemberCrefSyntax) Member) {TaParent = this};
                        loc.AddChildren();
                        _taMember = loc;
                    }
                    else if (Member is IndexerMemberCrefSyntax)
                    {
                        var loc = new TameIndexerMemberCrefSyntax((IndexerMemberCrefSyntax) Member) {TaParent = this};
                        loc.AddChildren();
                        _taMember = loc;
                    }
                    else if (Member is NameMemberCrefSyntax)
                    {
                        var loc = new TameNameMemberCrefSyntax((NameMemberCrefSyntax) Member) {TaParent = this};
                        loc.AddChildren();
                        _taMember = loc;
                    }
                return _taMember;
            }
            set
            {
                if (_taMember != value)
                {
                    _taMember = value;
                    if (_taMember != null)
                    {
                        _taMember.TaParent = this;
                        _taMember.IsChanged = true;
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
            _taContainer = null;
            _taMember = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _container = ((QualifiedCrefSyntax) Node).Container;
            _containerIsChanged = false;
            _dotToken = ((QualifiedCrefSyntax) Node).DotToken;
            _dotTokenIsChanged = false;
            _member = ((QualifiedCrefSyntax) Node).Member;
            _memberIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.QualifiedCref(Container, DotToken, Member);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaContainer != null) yield return TaContainer;
            if (TaMember != null) yield return TaMember;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ContainerStr", ContainerStr);
            yield return ("DotTokenStr", DotTokenStr);
            yield return ("MemberStr", MemberStr);
        }
    }
}