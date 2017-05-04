// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAttributeTargetSpecifierSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "AttributeTargetSpecifierSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;

        public TameAttributeTargetSpecifierSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAttributeTargetSpecifier(code);
            AddChildren();
        }

        public TameAttributeTargetSpecifierSyntax(AttributeTargetSpecifierSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAttributeTargetSpecifierSyntax()
        {
            IdentifierStr = DefaultValues.AttributeTargetSpecifierSyntaxIdentifierStr;
            ColonTokenStr = DefaultValues.AttributeTargetSpecifierSyntaxColonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ColonToken
        {
            get
            {
                if (_colonTokenIsChanged)
                {
                    if (_colonTokenStr == null) _colonToken = default(SyntaxToken);
                    else _colonToken = SyntaxFactoryStr.ParseSyntaxToken(_colonTokenStr, SyntaxKind.ColonToken);
                    _colonTokenIsChanged = false;
                }
                return _colonToken;
            }
            set
            {
                if (_colonToken != value)
                {
                    _colonToken = value;
                    _colonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ColonTokenStr
        {
            get
            {
                if (_colonTokenIsChanged) return _colonTokenStr;
                return _colonTokenStr = _colonToken.Text;
            }
            set
            {
                if (_colonTokenStr != value)
                {
                    _colonTokenStr = value;
                    IsChanged = true;
                    _colonTokenIsChanged = true;
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
            _identifier = ((AttributeTargetSpecifierSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _colonToken = ((AttributeTargetSpecifierSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AttributeTargetSpecifier(Identifier, ColonToken);
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
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("ColonTokenStr", ColonTokenStr);
        }
    }
}