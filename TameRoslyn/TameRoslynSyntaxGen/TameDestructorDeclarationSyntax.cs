// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDestructorDeclarationSyntax : TameBaseMethodDeclarationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "DestructorDeclarationSyntax";
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxToken _tildeToken;
        private bool _tildeTokenIsChanged;
        private string _tildeTokenStr;

        public TameDestructorDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDestructorDeclaration(code);
            AddChildren();
        }

        public TameDestructorDeclarationSyntax(DestructorDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDestructorDeclarationSyntax()
        {
            TildeTokenStr = DefaultValues.DestructorDeclarationSyntaxTildeTokenStr;
            IdentifierStr = DefaultValues.DestructorDeclarationSyntaxIdentifierStr;
            AttributeListsStr = DefaultValues.DestructorDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.DestructorDeclarationSyntaxModifiersStr;
            ParameterListStr = DefaultValues.DestructorDeclarationSyntaxParameterListStr;
            BodyStr = DefaultValues.DestructorDeclarationSyntaxBodyStr;
            ExpressionBodyStr = DefaultValues.DestructorDeclarationSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.DestructorDeclarationSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken TildeToken
        {
            get
            {
                if (_tildeTokenIsChanged)
                {
                    if (_tildeTokenStr == null) _tildeToken = default(SyntaxToken);
                    else _tildeToken = SyntaxFactoryStr.ParseSyntaxToken(_tildeTokenStr, SyntaxKind.TildeToken);
                    _tildeTokenIsChanged = false;
                }
                return _tildeToken;
            }
            set
            {
                if (_tildeToken != value)
                {
                    _tildeToken = value;
                    _tildeTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TildeTokenStr
        {
            get
            {
                if (_tildeTokenIsChanged) return _tildeTokenStr;
                return _tildeTokenStr = _tildeToken.Text;
            }
            set
            {
                if (_tildeTokenStr != value)
                {
                    _tildeTokenStr = value;
                    IsChanged = true;
                    _tildeTokenIsChanged = true;
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
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _tildeToken = ((DestructorDeclarationSyntax) Node).TildeToken;
            _tildeTokenIsChanged = false;
            _identifier = ((DestructorDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.DestructorDeclaration(AttributeLists, Modifiers, TildeToken, Identifier,
                ParameterList, Body, ExpressionBody, SemicolonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
            if (TaExpressionBody != null) yield return TaExpressionBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("TildeTokenStr", TildeTokenStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("BodyStr", BodyStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }

        public TameDestructorDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}