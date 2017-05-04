// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameJoinIntoClauseSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "JoinIntoClauseSyntax";
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxToken _intoKeyword;
        private bool _intoKeywordIsChanged;
        private string _intoKeywordStr;

        public TameJoinIntoClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseJoinIntoClause(code);
            AddChildren();
        }

        public TameJoinIntoClauseSyntax(JoinIntoClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameJoinIntoClauseSyntax()
        {
            // IntoKeywordStr = DefaultValues.JoinIntoClauseSyntaxIntoKeywordStr;
            // IdentifierStr = DefaultValues.JoinIntoClauseSyntaxIdentifierStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken IntoKeyword
        {
            get
            {
                if (_intoKeywordIsChanged)
                {
                    if (_intoKeywordStr == null) _intoKeyword = default(SyntaxToken);
                    else _intoKeyword = SyntaxFactoryStr.ParseSyntaxToken(_intoKeywordStr, SyntaxKind.IntoKeyword);
                    _intoKeywordIsChanged = false;
                }
                return _intoKeyword;
            }
            set
            {
                if (_intoKeyword != value)
                {
                    _intoKeyword = value;
                    _intoKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IntoKeywordStr
        {
            get
            {
                if (_intoKeywordIsChanged) return _intoKeywordStr;
                return _intoKeywordStr = _intoKeyword.Text;
            }
            set
            {
                if (_intoKeywordStr != value)
                {
                    _intoKeywordStr = value;
                    IsChanged = true;
                    _intoKeywordIsChanged = true;
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
            _intoKeyword = ((JoinIntoClauseSyntax) Node).IntoKeyword;
            _intoKeywordIsChanged = false;
            _identifier = ((JoinIntoClauseSyntax) Node).Identifier;
            _identifierIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.JoinIntoClause(IntoKeyword, Identifier);
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
            yield return ("IntoKeywordStr", IntoKeywordStr);
            yield return ("IdentifierStr", IdentifierStr);
        }
    }
}