// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameGenericNameSyntax : TameSimpleNameSyntax
    {
        public new static string TypeName = "GenericNameSyntax";
        private bool _isUnboundGenericName;
        private bool _isUnboundGenericNameIsChanged;
        private TameTypeArgumentListSyntax _taTypeArgumentList;
        private TypeArgumentListSyntax _typeArgumentList;
        private bool _typeArgumentListIsChanged;
        private string _typeArgumentListStr;

        public TameGenericNameSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseGenericName(code);
            AddChildren();
        }

        public TameGenericNameSyntax(GenericNameSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameGenericNameSyntax()
        {
            IsUnboundGenericName = DefaultValues.GenericNameSyntaxIsUnboundGenericName;
            TypeArgumentListStr = DefaultValues.GenericNameSyntaxTypeArgumentListStr;
            IdentifierStr = DefaultValues.GenericNameSyntaxIdentifierStr;
            Arity = DefaultValues.GenericNameSyntaxArity;
            IsVar = DefaultValues.GenericNameSyntaxIsVar;
        }

        public override string RoslynTypeName => TypeName;

        public bool IsUnboundGenericName
        {
            get { return _isUnboundGenericName; }
            set
            {
                if (_isUnboundGenericName != value)
                {
                    _isUnboundGenericName = value;
                    _isUnboundGenericNameIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public TypeArgumentListSyntax TypeArgumentList
        {
            get
            {
                if (_typeArgumentListIsChanged)
                {
                    _typeArgumentList = SyntaxFactoryStr.ParseTypeArgumentListSyntax(TypeArgumentListStr);
                    _typeArgumentListIsChanged = false;
                    _taTypeArgumentList = null;
                }
                else if (_taTypeArgumentList != null && _taTypeArgumentList.IsChanged)
                {
                    _typeArgumentList = (TypeArgumentListSyntax) _taTypeArgumentList.Node;
                }
                return _typeArgumentList;
            }
            set
            {
                if (_typeArgumentList != value)
                {
                    _typeArgumentList = value;
                    _typeArgumentListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeArgumentListStr
        {
            get
            {
                if (_taTypeArgumentList != null && _taTypeArgumentList.IsChanged)
                    TypeArgumentList = (TypeArgumentListSyntax) _taTypeArgumentList.Node;
                if (_typeArgumentListIsChanged) return _typeArgumentListStr;
                return _typeArgumentListStr = _typeArgumentList?.ToFullString();
            }
            set
            {
                if (_taTypeArgumentList != null && _taTypeArgumentList.IsChanged)
                {
                    TypeArgumentList = (TypeArgumentListSyntax) _taTypeArgumentList.Node;
                    _typeArgumentListStr = _typeArgumentList?.ToFullString();
                }
                if (_typeArgumentListStr != value)
                {
                    _typeArgumentListStr = value;
                    IsChanged = true;
                    _typeArgumentListIsChanged = true;
                    _taTypeArgumentList = null;
                }
            }
        }

        public TameTypeArgumentListSyntax TaTypeArgumentList
        {
            get
            {
                if (_taTypeArgumentList == null && TypeArgumentList != null)
                {
                    _taTypeArgumentList = new TameTypeArgumentListSyntax(TypeArgumentList) {TaParent = this};
                    _taTypeArgumentList.AddChildren();
                }
                return _taTypeArgumentList;
            }
            set
            {
                if (_taTypeArgumentList != value)
                {
                    _taTypeArgumentList = value;
                    if (_taTypeArgumentList != null)
                    {
                        _taTypeArgumentList.TaParent = this;
                        _taTypeArgumentList.IsChanged = true;
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
            _taTypeArgumentList = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _isUnboundGenericName = ((GenericNameSyntax) Node).IsUnboundGenericName;
            _isUnboundGenericNameIsChanged = false;
            _typeArgumentList = ((GenericNameSyntax) Node).TypeArgumentList;
            _typeArgumentListIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.GenericName(Identifier, TypeArgumentList);
// if (IsUnboundGenericName != null) res = res.WithIsUnboundGenericName(IsUnboundGenericName);
// if (Arity != null) res = res.WithArity(Arity);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaTypeArgumentList != null) yield return TaTypeArgumentList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IsUnboundGenericName", IsUnboundGenericName.ToString());
            yield return ("TypeArgumentListStr", TypeArgumentListStr);
            yield return ("IdentifierStr", IdentifierStr);
            yield return ("Arity", Arity.ToString());
            yield return ("IsVar", IsVar.ToString());
        }
    }
}