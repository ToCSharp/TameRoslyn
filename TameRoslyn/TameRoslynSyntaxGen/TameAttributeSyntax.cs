// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAttributeSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "AttributeSyntax";
        private AttributeArgumentListSyntax _argumentList;
        private bool _argumentListIsChanged;
        private string _argumentListStr;
        private NameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private TameAttributeArgumentListSyntax _taArgumentList;
        private TameNameSyntax _taName;

        public TameAttributeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAttribute(code);
            AddChildren();
        }

        public TameAttributeSyntax(AttributeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAttributeSyntax()
        {
            NameStr = DefaultValues.AttributeSyntaxNameStr;
            ArgumentListStr = DefaultValues.AttributeSyntaxArgumentListStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public AttributeArgumentListSyntax ArgumentList
        {
            get
            {
                if (_argumentListIsChanged)
                {
                    _argumentList = SyntaxFactoryStr.ParseAttributeArgumentListSyntax(ArgumentListStr);
                    _argumentListIsChanged = false;
                    _taArgumentList = null;
                }
                else if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    _argumentList = (AttributeArgumentListSyntax) _taArgumentList.Node;
                }
                return _argumentList;
            }
            set
            {
                if (_argumentList != value)
                {
                    _argumentList = value;
                    _argumentListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ArgumentListStr
        {
            get
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                    ArgumentList = (AttributeArgumentListSyntax) _taArgumentList.Node;
                if (_argumentListIsChanged) return _argumentListStr;
                return _argumentListStr = _argumentList?.ToFullString();
            }
            set
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    ArgumentList = (AttributeArgumentListSyntax) _taArgumentList.Node;
                    _argumentListStr = _argumentList?.ToFullString();
                }
                if (_argumentListStr != value)
                {
                    _argumentListStr = value;
                    IsChanged = true;
                    _argumentListIsChanged = true;
                    _taArgumentList = null;
                }
            }
        }

        public TameAttributeArgumentListSyntax TaArgumentList
        {
            get
            {
                if (_taArgumentList == null && ArgumentList != null)
                {
                    _taArgumentList = new TameAttributeArgumentListSyntax(ArgumentList) {TaParent = this};
                    _taArgumentList.AddChildren();
                }
                return _taArgumentList;
            }
            set
            {
                if (_taArgumentList != value)
                {
                    _taArgumentList = value;
                    if (_taArgumentList != null)
                    {
                        _taArgumentList.TaParent = this;
                        _taArgumentList.IsChanged = true;
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
            _taName = null;
            _taArgumentList = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _name = ((AttributeSyntax) Node).Name;
            _nameIsChanged = false;
            _argumentList = ((AttributeSyntax) Node).ArgumentList;
            _argumentListIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.Attribute(Name, ArgumentList);
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
            if (TaArgumentList != null) yield return TaArgumentList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NameStr", NameStr);
            yield return ("ArgumentListStr", ArgumentListStr);
        }
    }
}