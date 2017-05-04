// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlNameAttributeSyntax : TameXmlAttributeSyntax
    {
        public new static string TypeName = "XmlNameAttributeSyntax";
        private IdentifierNameSyntax _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;
        private TameIdentifierNameSyntax _taIdentifier;

        public TameXmlNameAttributeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlNameAttribute(code);
            AddChildren();
        }

        public TameXmlNameAttributeSyntax(XmlNameAttributeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlNameAttributeSyntax()
        {
            // IdentifierStr = DefaultValues.XmlNameAttributeSyntaxIdentifierStr;
            // NameStr = DefaultValues.XmlNameAttributeSyntaxNameStr;
            // EqualsTokenStr = DefaultValues.XmlNameAttributeSyntaxEqualsTokenStr;
            // StartQuoteTokenStr = DefaultValues.XmlNameAttributeSyntaxStartQuoteTokenStr;
            // EndQuoteTokenStr = DefaultValues.XmlNameAttributeSyntaxEndQuoteTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public IdentifierNameSyntax Identifier
        {
            get
            {
                if (_identifierIsChanged)
                {
                    _identifier = SyntaxFactoryStr.ParseIdentifierNameSyntax(IdentifierStr);
                    _identifierIsChanged = false;
                    _taIdentifier = null;
                }
                else if (_taIdentifier != null && _taIdentifier.IsChanged)
                {
                    _identifier = (IdentifierNameSyntax) _taIdentifier.Node;
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
                if (_taIdentifier != null && _taIdentifier.IsChanged)
                    Identifier = (IdentifierNameSyntax) _taIdentifier.Node;
                if (_identifierIsChanged) return _identifierStr;
                return _identifierStr = _identifier?.ToFullString();
            }
            set
            {
                if (_taIdentifier != null && _taIdentifier.IsChanged)
                {
                    Identifier = (IdentifierNameSyntax) _taIdentifier.Node;
                    _identifierStr = _identifier?.ToFullString();
                }
                if (_identifierStr != value)
                {
                    _identifierStr = value;
                    IsChanged = true;
                    _identifierIsChanged = true;
                    _taIdentifier = null;
                }
            }
        }

        public TameIdentifierNameSyntax TaIdentifier
        {
            get
            {
                if (_taIdentifier == null && Identifier != null)
                {
                    _taIdentifier = new TameIdentifierNameSyntax(Identifier) {TaParent = this};
                    _taIdentifier.AddChildren();
                }
                return _taIdentifier;
            }
            set
            {
                if (_taIdentifier != value)
                {
                    _taIdentifier = value;
                    if (_taIdentifier != null)
                    {
                        _taIdentifier.TaParent = this;
                        _taIdentifier.IsChanged = true;
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
            _taIdentifier = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _identifier = ((XmlNameAttributeSyntax) Node).Identifier;
            _identifierIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlNameAttribute(Name, EqualsToken, StartQuoteToken, Identifier, EndQuoteToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaIdentifier != null) yield return TaIdentifier;
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("NameStr", NameStr);
            yield return ("EqualsTokenStr", EqualsTokenStr);
            yield return ("StartQuoteTokenStr", StartQuoteTokenStr);
            yield return ("EndQuoteTokenStr", EndQuoteTokenStr);
        }
    }
}