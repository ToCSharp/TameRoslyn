// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameBaseListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "BaseListSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private List<TameBaseTypeSyntax> _taTypes;
        private SeparatedSyntaxList<BaseTypeSyntax> _types;
        private int _typesCount;
        private bool _typesIsChanged;
        private string _typesStr;

        public TameBaseListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBaseList(code);
            AddChildren();
        }

        public TameBaseListSyntax(BaseListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBaseListSyntax()
        {
            ColonTokenStr = DefaultValues.BaseListSyntaxColonTokenStr;
            TypesStr = DefaultValues.BaseListSyntaxTypesStr;
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

        public bool TaTypesIsChanged { get; set; }

        public SeparatedSyntaxList<BaseTypeSyntax> Types
        {
            get
            {
                if (TaTypesIsChanged || _taTypes != null &&
                    (_taTypes.Count != _typesCount || _taTypes.Any(v => v.IsChanged)))
                {
                    _types = SyntaxFactory.SeparatedList(TaTypes?.Select(v => v.Node).Cast<BaseTypeSyntax>());
                    TaTypesIsChanged = false;
                }
                return _types;
            }
            set
            {
                if (_types != value)
                {
                    _types = value;
                    TaTypesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypesStr
        {
            get
            {
                if (_typesIsChanged) return _typesStr;
                return _typesStr = string.Join(", ", _types.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _typesStr = value;
                    Types = new SeparatedSyntaxList<BaseTypeSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameBaseTypeSyntax> TaTypes
        {
            get
            {
                if (_taTypes == null)
                {
                    _taTypes = new List<TameBaseTypeSyntax>();
                    foreach (var item in _types)
                        if (item is SimpleBaseTypeSyntax)
                            _taTypes.Add(new TameSimpleBaseTypeSyntax(item as SimpleBaseTypeSyntax) {TaParent = this});
                        else if (item is BaseTypeSyntax)
                            _taTypes.Add(new TameBaseTypeSyntax(item) {TaParent = this});
                }
                return _taTypes;
            }
            set
            {
                if (_taTypes != value)
                {
                    _taTypes = value;
                    _taTypes?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaTypesIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taTypes = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _colonToken = ((BaseListSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
            _types = ((BaseListSyntax) Node).Types;
            _typesIsChanged = false;
            _typesCount = _types.Count;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaTypes)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.BaseList(ColonToken, Types);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaTypes)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ColonTokenStr", ColonTokenStr);
            yield return ("TypesStr", TypesStr);
        }

        public TameBaseListSyntax AddType(TameBaseTypeSyntax item)
        {
            item.TaParent = this;
            TaTypes.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}