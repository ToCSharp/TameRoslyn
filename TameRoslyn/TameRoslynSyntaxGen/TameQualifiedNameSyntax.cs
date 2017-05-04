// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameQualifiedNameSyntax : TameNameSyntax
    {
        public new static string TypeName = "QualifiedNameSyntax";
        private SyntaxToken _dotToken;
        private bool _dotTokenIsChanged;
        private string _dotTokenStr;
        private NameSyntax _left;
        private bool _leftIsChanged;
        private string _leftStr;
        private SimpleNameSyntax _right;
        private bool _rightIsChanged;
        private string _rightStr;
        private TameNameSyntax _taLeft;
        private TameSimpleNameSyntax _taRight;

        public TameQualifiedNameSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseQualifiedName(code);
            AddChildren();
        }

        public TameQualifiedNameSyntax(QualifiedNameSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameQualifiedNameSyntax()
        {
            LeftStr = DefaultValues.QualifiedNameSyntaxLeftStr;
            DotTokenStr = DefaultValues.QualifiedNameSyntaxDotTokenStr;
            RightStr = DefaultValues.QualifiedNameSyntaxRightStr;
            Arity = DefaultValues.QualifiedNameSyntaxArity;
            IsVar = DefaultValues.QualifiedNameSyntaxIsVar;
        }

        public override string RoslynTypeName => TypeName;

        public NameSyntax Left
        {
            get
            {
                if (_leftIsChanged)
                {
                    _left = SyntaxFactoryStr.ParseNameSyntax(LeftStr);
                    _leftIsChanged = false;
                    _taLeft = null;
                }
                else if (_taLeft != null && _taLeft.IsChanged)
                {
                    _left = (NameSyntax) _taLeft.Node;
                }
                return _left;
            }
            set
            {
                if (_left != value)
                {
                    _left = value;
                    _leftIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LeftStr
        {
            get
            {
                if (_taLeft != null && _taLeft.IsChanged)
                    Left = (NameSyntax) _taLeft.Node;
                if (_leftIsChanged) return _leftStr;
                return _leftStr = _left?.ToFullString();
            }
            set
            {
                if (_taLeft != null && _taLeft.IsChanged)
                {
                    Left = (NameSyntax) _taLeft.Node;
                    _leftStr = _left?.ToFullString();
                }
                if (_leftStr != value)
                {
                    _leftStr = value;
                    IsChanged = true;
                    _leftIsChanged = true;
                    _taLeft = null;
                }
            }
        }

        public TameNameSyntax TaLeft
        {
            get
            {
                if (_taLeft == null && Left != null)
                    if (Left is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                    else if (Left is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Left) {TaParent = this};
                        loc.AddChildren();
                        _taLeft = loc;
                    }
                return _taLeft;
            }
            set
            {
                if (_taLeft != value)
                {
                    _taLeft = value;
                    if (_taLeft != null)
                    {
                        _taLeft.TaParent = this;
                        _taLeft.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken DotToken
        {
            get
            {
                if (_dotTokenIsChanged)
                {
                    if (_dotTokenStr == null) _dotToken = default(SyntaxToken);
                    else _dotToken = SyntaxFactoryStr.ParseSyntaxToken(_dotTokenStr, SyntaxKind.DotToken);
                    _dotTokenIsChanged = false;
                }
                return _dotToken;
            }
            set
            {
                if (_dotToken != value)
                {
                    _dotToken = value;
                    _dotTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DotTokenStr
        {
            get
            {
                if (_dotTokenIsChanged) return _dotTokenStr;
                return _dotTokenStr = _dotToken.Text;
            }
            set
            {
                if (_dotTokenStr != value)
                {
                    _dotTokenStr = value;
                    IsChanged = true;
                    _dotTokenIsChanged = true;
                }
            }
        }

        public SimpleNameSyntax Right
        {
            get
            {
                if (_rightIsChanged)
                {
                    _right = SyntaxFactoryStr.ParseSimpleNameSyntax(RightStr);
                    _rightIsChanged = false;
                    _taRight = null;
                }
                else if (_taRight != null && _taRight.IsChanged)
                {
                    _right = (SimpleNameSyntax) _taRight.Node;
                }
                return _right;
            }
            set
            {
                if (_right != value)
                {
                    _right = value;
                    _rightIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string RightStr
        {
            get
            {
                if (_taRight != null && _taRight.IsChanged)
                    Right = (SimpleNameSyntax) _taRight.Node;
                if (_rightIsChanged) return _rightStr;
                return _rightStr = _right?.ToFullString();
            }
            set
            {
                if (_taRight != null && _taRight.IsChanged)
                {
                    Right = (SimpleNameSyntax) _taRight.Node;
                    _rightStr = _right?.ToFullString();
                }
                if (_rightStr != value)
                {
                    _rightStr = value;
                    IsChanged = true;
                    _rightIsChanged = true;
                    _taRight = null;
                }
            }
        }

        public TameSimpleNameSyntax TaRight
        {
            get
            {
                if (_taRight == null && Right != null)
                    if (Right is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                    else if (Right is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Right) {TaParent = this};
                        loc.AddChildren();
                        _taRight = loc;
                    }
                return _taRight;
            }
            set
            {
                if (_taRight != value)
                {
                    _taRight = value;
                    if (_taRight != null)
                    {
                        _taRight.TaParent = this;
                        _taRight.IsChanged = true;
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
            _taLeft = null;
            _taRight = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _left = ((QualifiedNameSyntax) Node).Left;
            _leftIsChanged = false;
            _dotToken = ((QualifiedNameSyntax) Node).DotToken;
            _dotTokenIsChanged = false;
            _right = ((QualifiedNameSyntax) Node).Right;
            _rightIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.QualifiedName(Left, DotToken, Right);
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
            if (TaLeft != null) yield return TaLeft;
            if (TaRight != null) yield return TaRight;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("LeftStr", LeftStr);
            yield return ("DotTokenStr", DotTokenStr);
            yield return ("RightStr", RightStr);
            yield return ("Arity", Arity.ToString());
            yield return ("IsVar", IsVar.ToString());
        }
    }
}