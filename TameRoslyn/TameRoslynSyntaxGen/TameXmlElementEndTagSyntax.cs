// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlElementEndTagSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "XmlElementEndTagSyntax";
        private SyntaxToken _greaterThanToken;
        private bool _greaterThanTokenIsChanged;
        private string _greaterThanTokenStr;
        private SyntaxToken _lessThanSlashToken;
        private bool _lessThanSlashTokenIsChanged;
        private string _lessThanSlashTokenStr;
        private XmlNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private TameXmlNameSyntax _taName;

        public TameXmlElementEndTagSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlElementEndTag(code);
            AddChildren();
        }

        public TameXmlElementEndTagSyntax(XmlElementEndTagSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlElementEndTagSyntax()
        {
            // LessThanSlashTokenStr = DefaultValues.XmlElementEndTagSyntaxLessThanSlashTokenStr;
            // NameStr = DefaultValues.XmlElementEndTagSyntaxNameStr;
            // GreaterThanTokenStr = DefaultValues.XmlElementEndTagSyntaxGreaterThanTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LessThanSlashToken
        {
            get
            {
                if (_lessThanSlashTokenIsChanged)
                {
                    if (_lessThanSlashTokenStr == null) _lessThanSlashToken = default(SyntaxToken);
                    else
                        _lessThanSlashToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_lessThanSlashTokenStr, SyntaxKind.LessThanSlashToken);
                    _lessThanSlashTokenIsChanged = false;
                }
                return _lessThanSlashToken;
            }
            set
            {
                if (_lessThanSlashToken != value)
                {
                    _lessThanSlashToken = value;
                    _lessThanSlashTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LessThanSlashTokenStr
        {
            get
            {
                if (_lessThanSlashTokenIsChanged) return _lessThanSlashTokenStr;
                return _lessThanSlashTokenStr = _lessThanSlashToken.Text;
            }
            set
            {
                if (_lessThanSlashTokenStr != value)
                {
                    _lessThanSlashTokenStr = value;
                    IsChanged = true;
                    _lessThanSlashTokenIsChanged = true;
                }
            }
        }

        public XmlNameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseXmlNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (XmlNameSyntax) _taName.Node;
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
                    Name = (XmlNameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (XmlNameSyntax) _taName.Node;
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

        public TameXmlNameSyntax TaName
        {
            get
            {
                if (_taName == null && Name != null)
                {
                    _taName = new TameXmlNameSyntax(Name) {TaParent = this};
                    _taName.AddChildren();
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

        public SyntaxToken GreaterThanToken
        {
            get
            {
                if (_greaterThanTokenIsChanged)
                {
                    if (_greaterThanTokenStr == null) _greaterThanToken = default(SyntaxToken);
                    else
                        _greaterThanToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_greaterThanTokenStr, SyntaxKind.GreaterThanToken);
                    _greaterThanTokenIsChanged = false;
                }
                return _greaterThanToken;
            }
            set
            {
                if (_greaterThanToken != value)
                {
                    _greaterThanToken = value;
                    _greaterThanTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string GreaterThanTokenStr
        {
            get
            {
                if (_greaterThanTokenIsChanged) return _greaterThanTokenStr;
                return _greaterThanTokenStr = _greaterThanToken.Text;
            }
            set
            {
                if (_greaterThanTokenStr != value)
                {
                    _greaterThanTokenStr = value;
                    IsChanged = true;
                    _greaterThanTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taName = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _lessThanSlashToken = ((XmlElementEndTagSyntax) Node).LessThanSlashToken;
            _lessThanSlashTokenIsChanged = false;
            _name = ((XmlElementEndTagSyntax) Node).Name;
            _nameIsChanged = false;
            _greaterThanToken = ((XmlElementEndTagSyntax) Node).GreaterThanToken;
            _greaterThanTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlElementEndTag(LessThanSlashToken, Name, GreaterThanToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("LessThanSlashTokenStr", LessThanSlashTokenStr);
            yield return ("NameStr", NameStr);
            yield return ("GreaterThanTokenStr", GreaterThanTokenStr);
        }
    }
}