// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameMemberBindingExpressionSyntax : TameExpressionSyntax
    {
        public new static string TypeName = "MemberBindingExpressionSyntax";
        private SimpleNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private SyntaxToken _operatorToken;
        private bool _operatorTokenIsChanged;
        private string _operatorTokenStr;
        private TameSimpleNameSyntax _taName;

        public TameMemberBindingExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseMemberBindingExpression(code);
            AddChildren();
        }

        public TameMemberBindingExpressionSyntax(MemberBindingExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameMemberBindingExpressionSyntax()
        {
            OperatorTokenStr = DefaultValues.MemberBindingExpressionSyntaxOperatorTokenStr;
            NameStr = DefaultValues.MemberBindingExpressionSyntaxNameStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OperatorToken
        {
            get
            {
                if (_operatorTokenIsChanged)
                {
                    _operatorToken = SyntaxFactoryStr.ParseSyntaxToken(OperatorTokenStr);
                    _operatorTokenIsChanged = false;
                }
                return _operatorToken;
            }
            set
            {
                if (_operatorToken != value)
                {
                    _operatorToken = value;
                    _operatorTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperatorTokenStr
        {
            get
            {
                if (_operatorTokenIsChanged) return _operatorTokenStr;
                return _operatorTokenStr = _operatorToken.Text;
            }
            set
            {
                if (_operatorTokenStr != value)
                {
                    _operatorTokenStr = value;
                    IsChanged = true;
                    _operatorTokenIsChanged = true;
                }
            }
        }

        public SimpleNameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseSimpleNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (SimpleNameSyntax) _taName.Node;
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
                    Name = (SimpleNameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (SimpleNameSyntax) _taName.Node;
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

        public TameSimpleNameSyntax TaName
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

        public override void Clear()
        {
            base.Clear();
            _taName = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _operatorToken = ((MemberBindingExpressionSyntax) Node).OperatorToken;
            _operatorTokenIsChanged = false;
            _name = ((MemberBindingExpressionSyntax) Node).Name;
            _nameIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.MemberBindingExpression(OperatorToken, Name);
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
            yield return ("OperatorTokenStr", OperatorTokenStr);
            yield return ("NameStr", NameStr);
        }
    }
}