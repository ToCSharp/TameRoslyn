// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlPrefixSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "XmlPrefixSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private SyntaxToken _prefix;
        private bool _prefixIsChanged;
        private string _prefixStr;

        public TameXmlPrefixSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlPrefix(code);
            AddChildren();
        }

        public TameXmlPrefixSyntax(XmlPrefixSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlPrefixSyntax()
        {
            // PrefixStr = DefaultValues.XmlPrefixSyntaxPrefixStr;
            // ColonTokenStr = DefaultValues.XmlPrefixSyntaxColonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken Prefix
        {
            get
            {
                if (_prefixIsChanged)
                {
                    _prefix = SyntaxFactoryStr.ParseSyntaxToken(PrefixStr);
                    _prefixIsChanged = false;
                }
                return _prefix;
            }
            set
            {
                if (_prefix != value)
                {
                    _prefix = value;
                    _prefixIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string PrefixStr
        {
            get
            {
                if (_prefixIsChanged) return _prefixStr;
                return _prefixStr = _prefix.Text;
            }
            set
            {
                if (_prefixStr != value)
                {
                    _prefixStr = value;
                    IsChanged = true;
                    _prefixIsChanged = true;
                }
            }
        }

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

        public override void Clear()
        {
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _prefix = ((XmlPrefixSyntax) Node).Prefix;
            _prefixIsChanged = false;
            _colonToken = ((XmlPrefixSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlPrefix(Prefix, ColonToken);
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
            yield return ("PrefixStr", PrefixStr);
            yield return ("ColonTokenStr", ColonTokenStr);
        }
    }
}