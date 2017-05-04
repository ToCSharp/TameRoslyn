// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameExternAliasDirectiveSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "ExternAliasDirectiveSyntax";
        private SyntaxToken _aliasKeyword;
        private bool _aliasKeywordIsChanged;
        private string _aliasKeywordStr;
        private SyntaxToken _externKeyword;
        private bool _externKeywordIsChanged;
        private string _externKeywordStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;

        public TameExternAliasDirectiveSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseExternAliasDirective(code);
            AddChildren();
        }

        public TameExternAliasDirectiveSyntax(ExternAliasDirectiveSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameExternAliasDirectiveSyntax()
        {
            ExternKeywordStr = DefaultValues.ExternAliasDirectiveSyntaxExternKeywordStr;
            AliasKeywordStr = DefaultValues.ExternAliasDirectiveSyntaxAliasKeywordStr;
            IdentifierStr = DefaultValues.ExternAliasDirectiveSyntaxIdentifierStr;
            SemicolonTokenStr = DefaultValues.ExternAliasDirectiveSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ExternKeyword
        {
            get
            {
                if (_externKeywordIsChanged)
                {
                    if (_externKeywordStr == null) _externKeyword = default(SyntaxToken);
                    else
                        _externKeyword = SyntaxFactoryStr.ParseSyntaxToken(_externKeywordStr, SyntaxKind.ExternKeyword);
                    _externKeywordIsChanged = false;
                }
                return _externKeyword;
            }
            set
            {
                if (_externKeyword != value)
                {
                    _externKeyword = value;
                    _externKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExternKeywordStr
        {
            get
            {
                if (_externKeywordIsChanged) return _externKeywordStr;
                return _externKeywordStr = _externKeyword.Text;
            }
            set
            {
                if (_externKeywordStr != value)
                {
                    _externKeywordStr = value;
                    IsChanged = true;
                    _externKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken AliasKeyword
        {
            get
            {
                if (_aliasKeywordIsChanged)
                {
                    if (_aliasKeywordStr == null) _aliasKeyword = default(SyntaxToken);
                    else _aliasKeyword = SyntaxFactoryStr.ParseSyntaxToken(_aliasKeywordStr, SyntaxKind.AliasKeyword);
                    _aliasKeywordIsChanged = false;
                }
                return _aliasKeyword;
            }
            set
            {
                if (_aliasKeyword != value)
                {
                    _aliasKeyword = value;
                    _aliasKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AliasKeywordStr
        {
            get
            {
                if (_aliasKeywordIsChanged) return _aliasKeywordStr;
                return _aliasKeywordStr = _aliasKeyword.Text;
            }
            set
            {
                if (_aliasKeywordStr != value)
                {
                    _aliasKeywordStr = value;
                    IsChanged = true;
                    _aliasKeywordIsChanged = true;
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

        public SyntaxToken Identifier
        {
            get
            {
                if (_identifierIsChanged)
                {
                    _identifier = SyntaxFactoryStr.ParseSyntaxToken(IdentifierStr);
                    _identifierIsChanged = false;
                }
                return _identifier;
            }
            set
            {
                if (_identifier != value)
                {
                    _identifier = value;
                    _identifierIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IdentifierStr
        {
            get
            {
                if (_identifierIsChanged) return _identifierStr;
                return _identifierStr = _identifier.Text;
            }
            set
            {
                if (_identifierStr != value)
                {
                    _identifierStr = value;
                    IsChanged = true;
                    _identifierIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _externKeyword = ((ExternAliasDirectiveSyntax) Node).ExternKeyword;
            _externKeywordIsChanged = false;
            _aliasKeyword = ((ExternAliasDirectiveSyntax) Node).AliasKeyword;
            _aliasKeywordIsChanged = false;
            _identifier = ((ExternAliasDirectiveSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _semicolonToken = ((ExternAliasDirectiveSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ExternAliasDirective(ExternKeyword, AliasKeyword, Identifier, SemicolonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ExternKeywordStr", ExternKeywordStr);
            yield return ("AliasKeywordStr", AliasKeywordStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}