// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCatchDeclarationSyntax : TameBaseRoslynNode, IHaveIdentifier
    {
        public static string TypeName = "CatchDeclarationSyntax";
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameCatchDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCatchDeclaration(code);
            AddChildren();
        }

        public TameCatchDeclarationSyntax(CatchDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCatchDeclarationSyntax()
        {
            OpenParenTokenStr = DefaultValues.CatchDeclarationSyntaxOpenParenTokenStr;
            TypeStr = DefaultValues.CatchDeclarationSyntaxTypeStr;
            IdentifierStr = DefaultValues.CatchDeclarationSyntaxIdentifierStr;
            CloseParenTokenStr = DefaultValues.CatchDeclarationSyntaxCloseParenTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenParenToken
        {
            get
            {
                if (_openParenTokenIsChanged)
                {
                    if (_openParenTokenStr == null) _openParenToken = default(SyntaxToken);
                    else
                        _openParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openParenTokenStr, SyntaxKind.OpenParenToken);
                    _openParenTokenIsChanged = false;
                }
                return _openParenToken;
            }
            set
            {
                if (_openParenToken != value)
                {
                    _openParenToken = value;
                    _openParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenParenTokenStr
        {
            get
            {
                if (_openParenTokenIsChanged) return _openParenTokenStr;
                return _openParenTokenStr = _openParenToken.Text;
            }
            set
            {
                if (_openParenTokenStr != value)
                {
                    _openParenTokenStr = value;
                    IsChanged = true;
                    _openParenTokenIsChanged = true;
                }
            }
        }

        public TypeSyntax Type
        {
            get
            {
                if (_typeIsChanged)
                {
                    _type = SyntaxFactoryStr.ParseTypeSyntax(TypeStr);
                    _typeIsChanged = false;
                    _taType = null;
                }
                else if (_taType != null && _taType.IsChanged)
                {
                    _type = (TypeSyntax) _taType.Node;
                }
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    _typeIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeStr
        {
            get
            {
                if (_taType != null && _taType.IsChanged)
                    Type = (TypeSyntax) _taType.Node;
                if (_typeIsChanged) return _typeStr;
                return _typeStr = _type?.ToFullString();
            }
            set
            {
                if (_taType != null && _taType.IsChanged)
                {
                    Type = (TypeSyntax) _taType.Node;
                    _typeStr = _type?.ToFullString();
                }
                if (_typeStr != value)
                {
                    _typeStr = value;
                    IsChanged = true;
                    _typeIsChanged = true;
                    _taType = null;
                }
            }
        }

        public TameTypeSyntax TaType
        {
            get
            {
                if (_taType == null && Type != null)
                    if (Type is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is OmittedTypeArgumentSyntax)
                    {
                        var loc = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                return _taType;
            }
            set
            {
                if (_taType != value)
                {
                    _taType = value;
                    if (_taType != null)
                    {
                        _taType.TaParent = this;
                        _taType.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken CloseParenToken
        {
            get
            {
                if (_closeParenTokenIsChanged)
                {
                    if (_closeParenTokenStr == null) _closeParenToken = default(SyntaxToken);
                    else
                        _closeParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeParenTokenStr, SyntaxKind.CloseParenToken);
                    _closeParenTokenIsChanged = false;
                }
                return _closeParenToken;
            }
            set
            {
                if (_closeParenToken != value)
                {
                    _closeParenToken = value;
                    _closeParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseParenTokenStr
        {
            get
            {
                if (_closeParenTokenIsChanged) return _closeParenTokenStr;
                return _closeParenTokenStr = _closeParenToken.Text;
            }
            set
            {
                if (_closeParenTokenStr != value)
                {
                    _closeParenTokenStr = value;
                    IsChanged = true;
                    _closeParenTokenIsChanged = true;
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
            _taType = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _openParenToken = ((CatchDeclarationSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _type = ((CatchDeclarationSyntax) Node).Type;
            _typeIsChanged = false;
            _identifier = ((CatchDeclarationSyntax) Node).Identifier;
            _identifierIsChanged = false;
            _closeParenToken = ((CatchDeclarationSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CatchDeclaration(OpenParenToken, Type, Identifier, CloseParenToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("TypeStr", TypeStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
        }
    }
}