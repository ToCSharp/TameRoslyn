// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameExplicitInterfaceSpecifierSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "ExplicitInterfaceSpecifierSyntax";
        private SyntaxToken _dotToken;
        private bool _dotTokenIsChanged;
        private string _dotTokenStr;
        private NameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private TameNameSyntax _taName;

        public TameExplicitInterfaceSpecifierSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseExplicitInterfaceSpecifier(code);
            AddChildren();
        }

        public TameExplicitInterfaceSpecifierSyntax(ExplicitInterfaceSpecifierSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameExplicitInterfaceSpecifierSyntax()
        {
            NameStr = DefaultValues.ExplicitInterfaceSpecifierSyntaxNameStr;
            DotTokenStr = DefaultValues.ExplicitInterfaceSpecifierSyntaxDotTokenStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public override void Clear()
        {
            _taName = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _name = ((ExplicitInterfaceSpecifierSyntax) Node).Name;
            _nameIsChanged = false;
            _dotToken = ((ExplicitInterfaceSpecifierSyntax) Node).DotToken;
            _dotTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ExplicitInterfaceSpecifier(Name, DotToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NameStr", NameStr);
            yield return ("DotTokenStr", DotTokenStr);
        }
    }
}