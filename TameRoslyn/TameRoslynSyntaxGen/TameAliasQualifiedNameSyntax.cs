// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAliasQualifiedNameSyntax : TameNameSyntax
    {
        public new static string TypeName = "AliasQualifiedNameSyntax";
        private IdentifierNameSyntax _alias;
        private bool _aliasIsChanged;
        private string _aliasStr;
        private SyntaxToken _colonColonToken;
        private bool _colonColonTokenIsChanged;
        private string _colonColonTokenStr;
        private SimpleNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private TameIdentifierNameSyntax _taAlias;
        private TameSimpleNameSyntax _taName;

        public TameAliasQualifiedNameSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAliasQualifiedName(code);
            AddChildren();
        }

        public TameAliasQualifiedNameSyntax(AliasQualifiedNameSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAliasQualifiedNameSyntax()
        {
            AliasStr = DefaultValues.AliasQualifiedNameSyntaxAliasStr;
            ColonColonTokenStr = DefaultValues.AliasQualifiedNameSyntaxColonColonTokenStr;
            NameStr = DefaultValues.AliasQualifiedNameSyntaxNameStr;
            Arity = DefaultValues.AliasQualifiedNameSyntaxArity;
            IsVar = DefaultValues.AliasQualifiedNameSyntaxIsVar;
        }

        public override string RoslynTypeName => TypeName;

        public IdentifierNameSyntax Alias
        {
            get
            {
                if (_aliasIsChanged)
                {
                    _alias = SyntaxFactoryStr.ParseIdentifierNameSyntax(AliasStr);
                    _aliasIsChanged = false;
                    _taAlias = null;
                }
                else if (_taAlias != null && _taAlias.IsChanged)
                {
                    _alias = (IdentifierNameSyntax) _taAlias.Node;
                }
                return _alias;
            }
            set
            {
                if (_alias != value)
                {
                    _alias = value;
                    _aliasIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AliasStr
        {
            get
            {
                if (_taAlias != null && _taAlias.IsChanged)
                    Alias = (IdentifierNameSyntax) _taAlias.Node;
                if (_aliasIsChanged) return _aliasStr;
                return _aliasStr = _alias?.ToFullString();
            }
            set
            {
                if (_taAlias != null && _taAlias.IsChanged)
                {
                    Alias = (IdentifierNameSyntax) _taAlias.Node;
                    _aliasStr = _alias?.ToFullString();
                }
                if (_aliasStr != value)
                {
                    _aliasStr = value;
                    IsChanged = true;
                    _aliasIsChanged = true;
                    _taAlias = null;
                }
            }
        }

        public TameIdentifierNameSyntax TaAlias
        {
            get
            {
                if (_taAlias == null && Alias != null)
                {
                    _taAlias = new TameIdentifierNameSyntax(Alias) {TaParent = this};
                    _taAlias.AddChildren();
                }
                return _taAlias;
            }
            set
            {
                if (_taAlias != value)
                {
                    _taAlias = value;
                    if (_taAlias != null)
                    {
                        _taAlias.TaParent = this;
                        _taAlias.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken ColonColonToken
        {
            get
            {
                if (_colonColonTokenIsChanged)
                {
                    if (_colonColonTokenStr == null) _colonColonToken = default(SyntaxToken);
                    else
                        _colonColonToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_colonColonTokenStr, SyntaxKind.ColonColonToken);
                    _colonColonTokenIsChanged = false;
                }
                return _colonColonToken;
            }
            set
            {
                if (_colonColonToken != value)
                {
                    _colonColonToken = value;
                    _colonColonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ColonColonTokenStr
        {
            get
            {
                if (_colonColonTokenIsChanged) return _colonColonTokenStr;
                return _colonColonTokenStr = _colonColonToken.Text;
            }
            set
            {
                if (_colonColonTokenStr != value)
                {
                    _colonColonTokenStr = value;
                    IsChanged = true;
                    _colonColonTokenIsChanged = true;
                }
            }
        }

        public SimpleNameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseSimpleNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (SimpleNameSyntax) _taName.Node;
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
                    Name = (SimpleNameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (SimpleNameSyntax) _taName.Node;
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

        public TameSimpleNameSyntax TaName
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

        public override void Clear()
        {
            base.Clear();
            _taAlias = null;
            _taName = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _alias = ((AliasQualifiedNameSyntax) Node).Alias;
            _aliasIsChanged = false;
            _colonColonToken = ((AliasQualifiedNameSyntax) Node).ColonColonToken;
            _colonColonTokenIsChanged = false;
            _name = ((AliasQualifiedNameSyntax) Node).Name;
            _nameIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AliasQualifiedName(Alias, ColonColonToken, Name);
// if (Arity != null) res = res.WithArity(Arity);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaAlias != null) yield return TaAlias;
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("AliasStr", AliasStr);
            yield return ("ColonColonTokenStr", ColonColonTokenStr);
            yield return ("NameStr", NameStr);
            yield return ("Arity", Arity.ToString());
            yield return ("IsVar", IsVar.ToString());
        }
    }
}