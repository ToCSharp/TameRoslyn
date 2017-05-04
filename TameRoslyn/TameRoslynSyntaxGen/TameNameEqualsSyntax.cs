// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameNameEqualsSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "NameEqualsSyntax";
        private SyntaxToken _equalsToken;
        private bool _equalsTokenIsChanged;
        private string _equalsTokenStr;
        private IdentifierNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private TameIdentifierNameSyntax _taName;

        public TameNameEqualsSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseNameEquals(code);
            AddChildren();
        }

        public TameNameEqualsSyntax(NameEqualsSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameNameEqualsSyntax()
        {
            NameStr = DefaultValues.NameEqualsSyntaxNameStr;
            EqualsTokenStr = DefaultValues.NameEqualsSyntaxEqualsTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public IdentifierNameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseIdentifierNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (IdentifierNameSyntax) _taName.Node;
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
                    Name = (IdentifierNameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (IdentifierNameSyntax) _taName.Node;
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

        public TameIdentifierNameSyntax TaName
        {
            get
            {
                if (_taName == null && Name != null)
                {
                    _taName = new TameIdentifierNameSyntax(Name) {TaParent = this};
                    _taName.AddChildren();
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

        public SyntaxToken EqualsToken
        {
            get
            {
                if (_equalsTokenIsChanged)
                {
                    if (_equalsTokenStr == null) _equalsToken = default(SyntaxToken);
                    else _equalsToken = SyntaxFactoryStr.ParseSyntaxToken(_equalsTokenStr, SyntaxKind.EqualsToken);
                    _equalsTokenIsChanged = false;
                }
                return _equalsToken;
            }
            set
            {
                if (_equalsToken != value)
                {
                    _equalsToken = value;
                    _equalsTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string EqualsTokenStr
        {
            get
            {
                if (_equalsTokenIsChanged) return _equalsTokenStr;
                return _equalsTokenStr = _equalsToken.Text;
            }
            set
            {
                if (_equalsTokenStr != value)
                {
                    _equalsTokenStr = value;
                    IsChanged = true;
                    _equalsTokenIsChanged = true;
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
            _name = ((NameEqualsSyntax) Node).Name;
            _nameIsChanged = false;
            _equalsToken = ((NameEqualsSyntax) Node).EqualsToken;
            _equalsTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.NameEquals(Name, EqualsToken);
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
            yield return ("EqualsTokenStr", EqualsTokenStr);
        }
    }
}