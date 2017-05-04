// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameUsingDirectiveSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "UsingDirectiveSyntax";
        private NameEqualsSyntax _alias;
        private bool _aliasIsChanged;
        private string _aliasStr;
        private NameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private SyntaxToken _staticKeyword;
        private bool _staticKeywordIsChanged;
        private string _staticKeywordStr;
        private TameNameEqualsSyntax _taAlias;
        private TameNameSyntax _taName;
        private SyntaxToken _usingKeyword;
        private bool _usingKeywordIsChanged;
        private string _usingKeywordStr;

        public TameUsingDirectiveSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseUsingDirective(code);
            AddChildren();
        }

        public TameUsingDirectiveSyntax(UsingDirectiveSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameUsingDirectiveSyntax()
        {
            UsingKeywordStr = DefaultValues.UsingDirectiveSyntaxUsingKeywordStr;
            StaticKeywordStr = DefaultValues.UsingDirectiveSyntaxStaticKeywordStr;
            AliasStr = DefaultValues.UsingDirectiveSyntaxAliasStr;
            NameStr = DefaultValues.UsingDirectiveSyntaxNameStr;
            SemicolonTokenStr = DefaultValues.UsingDirectiveSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken UsingKeyword
        {
            get
            {
                if (_usingKeywordIsChanged)
                {
                    if (_usingKeywordStr == null) _usingKeyword = default(SyntaxToken);
                    else _usingKeyword = SyntaxFactoryStr.ParseSyntaxToken(_usingKeywordStr, SyntaxKind.UsingKeyword);
                    _usingKeywordIsChanged = false;
                }
                return _usingKeyword;
            }
            set
            {
                if (_usingKeyword != value)
                {
                    _usingKeyword = value;
                    _usingKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string UsingKeywordStr
        {
            get
            {
                if (_usingKeywordIsChanged) return _usingKeywordStr;
                return _usingKeywordStr = _usingKeyword.Text;
            }
            set
            {
                if (_usingKeywordStr != value)
                {
                    _usingKeywordStr = value;
                    IsChanged = true;
                    _usingKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken StaticKeyword
        {
            get
            {
                if (_staticKeywordIsChanged)
                {
                    if (_staticKeywordStr == null) _staticKeyword = default(SyntaxToken);
                    else
                        _staticKeyword = SyntaxFactoryStr.ParseSyntaxToken(_staticKeywordStr, SyntaxKind.StaticKeyword);
                    _staticKeywordIsChanged = false;
                }
                return _staticKeyword;
            }
            set
            {
                if (_staticKeyword != value)
                {
                    _staticKeyword = value;
                    _staticKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string StaticKeywordStr
        {
            get
            {
                if (_staticKeywordIsChanged) return _staticKeywordStr;
                return _staticKeywordStr = _staticKeyword.Text;
            }
            set
            {
                if (_staticKeywordStr != value)
                {
                    _staticKeywordStr = value;
                    IsChanged = true;
                    _staticKeywordIsChanged = true;
                }
            }
        }

        public NameEqualsSyntax Alias
        {
            get
            {
                if (_aliasIsChanged)
                {
                    _alias = SyntaxFactoryStr.ParseNameEqualsSyntax(AliasStr);
                    _aliasIsChanged = false;
                    _taAlias = null;
                }
                else if (_taAlias != null && _taAlias.IsChanged)
                {
                    _alias = (NameEqualsSyntax) _taAlias.Node;
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
                    Alias = (NameEqualsSyntax) _taAlias.Node;
                if (_aliasIsChanged) return _aliasStr;
                return _aliasStr = _alias?.ToFullString();
            }
            set
            {
                if (_taAlias != null && _taAlias.IsChanged)
                {
                    Alias = (NameEqualsSyntax) _taAlias.Node;
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

        public TameNameEqualsSyntax TaAlias
        {
            get
            {
                if (_taAlias == null && Alias != null)
                {
                    _taAlias = new TameNameEqualsSyntax(Alias) {TaParent = this};
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
            _taAlias = null;
            _taName = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _usingKeyword = ((UsingDirectiveSyntax) Node).UsingKeyword;
            _usingKeywordIsChanged = false;
            _staticKeyword = ((UsingDirectiveSyntax) Node).StaticKeyword;
            _staticKeywordIsChanged = false;
            _alias = ((UsingDirectiveSyntax) Node).Alias;
            _aliasIsChanged = false;
            _name = ((UsingDirectiveSyntax) Node).Name;
            _nameIsChanged = false;
            _semicolonToken = ((UsingDirectiveSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.UsingDirective(UsingKeyword, StaticKeyword, Alias, Name, SemicolonToken);
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
            yield return ("UsingKeywordStr", UsingKeywordStr);
            yield return ("StaticKeywordStr", StaticKeywordStr);
            yield return ("AliasStr", AliasStr);
            yield return ("NameStr", NameStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}