// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlNameSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "XmlNameSyntax";
        private SyntaxToken _localName;
        private bool _localNameIsChanged;
        private string _localNameStr;
        private XmlPrefixSyntax _prefix;
        private bool _prefixIsChanged;
        private string _prefixStr;
        private TameXmlPrefixSyntax _taPrefix;

        public TameXmlNameSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlName(code);
            AddChildren();
        }

        public TameXmlNameSyntax(XmlNameSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlNameSyntax()
        {
            // PrefixStr = DefaultValues.XmlNameSyntaxPrefixStr;
            // LocalNameStr = DefaultValues.XmlNameSyntaxLocalNameStr;
        }

        public override string RoslynTypeName => TypeName;

        public XmlPrefixSyntax Prefix
        {
            get
            {
                if (_prefixIsChanged)
                {
                    _prefix = SyntaxFactoryStr.ParseXmlPrefixSyntax(PrefixStr);
                    _prefixIsChanged = false;
                    _taPrefix = null;
                }
                else if (_taPrefix != null && _taPrefix.IsChanged)
                {
                    _prefix = (XmlPrefixSyntax) _taPrefix.Node;
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
                if (_taPrefix != null && _taPrefix.IsChanged)
                    Prefix = (XmlPrefixSyntax) _taPrefix.Node;
                if (_prefixIsChanged) return _prefixStr;
                return _prefixStr = _prefix?.ToFullString();
            }
            set
            {
                if (_taPrefix != null && _taPrefix.IsChanged)
                {
                    Prefix = (XmlPrefixSyntax) _taPrefix.Node;
                    _prefixStr = _prefix?.ToFullString();
                }
                if (_prefixStr != value)
                {
                    _prefixStr = value;
                    IsChanged = true;
                    _prefixIsChanged = true;
                    _taPrefix = null;
                }
            }
        }

        public TameXmlPrefixSyntax TaPrefix
        {
            get
            {
                if (_taPrefix == null && Prefix != null)
                {
                    _taPrefix = new TameXmlPrefixSyntax(Prefix) {TaParent = this};
                    _taPrefix.AddChildren();
                }
                return _taPrefix;
            }
            set
            {
                if (_taPrefix != value)
                {
                    _taPrefix = value;
                    if (_taPrefix != null)
                    {
                        _taPrefix.TaParent = this;
                        _taPrefix.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken LocalName
        {
            get
            {
                if (_localNameIsChanged)
                {
                    _localName = SyntaxFactoryStr.ParseSyntaxToken(LocalNameStr);
                    _localNameIsChanged = false;
                }
                return _localName;
            }
            set
            {
                if (_localName != value)
                {
                    _localName = value;
                    _localNameIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LocalNameStr
        {
            get
            {
                if (_localNameIsChanged) return _localNameStr;
                return _localNameStr = _localName.Text;
            }
            set
            {
                if (_localNameStr != value)
                {
                    _localNameStr = value;
                    IsChanged = true;
                    _localNameIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taPrefix = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _prefix = ((XmlNameSyntax) Node).Prefix;
            _prefixIsChanged = false;
            _localName = ((XmlNameSyntax) Node).LocalName;
            _localNameIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlName(Prefix, LocalName);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaPrefix != null) yield return TaPrefix;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("PrefixStr", PrefixStr);
            yield return ("LocalNameStr", LocalNameStr);
        }
    }
}