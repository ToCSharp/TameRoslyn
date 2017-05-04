// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAccessorListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "AccessorListSyntax";
        private SyntaxList<AccessorDeclarationSyntax> _accessors;
        private int _accessorsCount;
        private bool _accessorsIsChanged;
        private string _accessorsStr;
        private SyntaxToken _closeBraceToken;
        private bool _closeBraceTokenIsChanged;
        private string _closeBraceTokenStr;
        private SyntaxToken _openBraceToken;
        private bool _openBraceTokenIsChanged;
        private string _openBraceTokenStr;
        private List<TameAccessorDeclarationSyntax> _taAccessors;

        public TameAccessorListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAccessorList(code);
            AddChildren();
        }

        public TameAccessorListSyntax(AccessorListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAccessorListSyntax()
        {
            OpenBraceTokenStr = DefaultValues.AccessorListSyntaxOpenBraceTokenStr;
            AccessorsStr = DefaultValues.AccessorListSyntaxAccessorsStr;
            CloseBraceTokenStr = DefaultValues.AccessorListSyntaxCloseBraceTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenBraceToken
        {
            get
            {
                if (_openBraceTokenIsChanged)
                {
                    if (_openBraceTokenStr == null) _openBraceToken = default(SyntaxToken);
                    else
                        _openBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openBraceTokenStr, SyntaxKind.OpenBraceToken);
                    _openBraceTokenIsChanged = false;
                }
                return _openBraceToken;
            }
            set
            {
                if (_openBraceToken != value)
                {
                    _openBraceToken = value;
                    _openBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenBraceTokenStr
        {
            get
            {
                if (_openBraceTokenIsChanged) return _openBraceTokenStr;
                return _openBraceTokenStr = _openBraceToken.Text;
            }
            set
            {
                if (_openBraceTokenStr != value)
                {
                    _openBraceTokenStr = value;
                    IsChanged = true;
                    _openBraceTokenIsChanged = true;
                }
            }
        }

        public bool TaAccessorsIsChanged { get; set; }

        public SyntaxList<AccessorDeclarationSyntax> Accessors
        {
            get
            {
                if (TaAccessorsIsChanged || _taAccessors != null &&
                    (_taAccessors.Count != _accessorsCount || _taAccessors.Any(v => v.IsChanged)))
                {
                    _accessors = SyntaxFactory.List(TaAccessors?.Select(v => v.Node).Cast<AccessorDeclarationSyntax>());
                    TaAccessorsIsChanged = false;
                }
                return _accessors;
            }
            set
            {
                if (_accessors != value)
                {
                    _accessors = value;
                    TaAccessorsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string AccessorsStr
        {
            get
            {
                if (_accessorsIsChanged) return _accessorsStr;
                return _accessorsStr = string.Join(", ", _accessors.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _accessorsStr = value;
                    Accessors = new SyntaxList<AccessorDeclarationSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAccessorDeclarationSyntax> TaAccessors
        {
            get
            {
                if (_taAccessors == null)
                {
                    _taAccessors = new List<TameAccessorDeclarationSyntax>();
                    foreach (var item in _accessors)
                        _taAccessors.Add(new TameAccessorDeclarationSyntax(item) {TaParent = this});
                }
                return _taAccessors;
            }
            set
            {
                if (_taAccessors != value)
                {
                    _taAccessors = value;
                    _taAccessors?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaAccessorsIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseBraceToken
        {
            get
            {
                if (_closeBraceTokenIsChanged)
                {
                    if (_closeBraceTokenStr == null) _closeBraceToken = default(SyntaxToken);
                    else
                        _closeBraceToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeBraceTokenStr, SyntaxKind.CloseBraceToken);
                    _closeBraceTokenIsChanged = false;
                }
                return _closeBraceToken;
            }
            set
            {
                if (_closeBraceToken != value)
                {
                    _closeBraceToken = value;
                    _closeBraceTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseBraceTokenStr
        {
            get
            {
                if (_closeBraceTokenIsChanged) return _closeBraceTokenStr;
                return _closeBraceTokenStr = _closeBraceToken.Text;
            }
            set
            {
                if (_closeBraceTokenStr != value)
                {
                    _closeBraceTokenStr = value;
                    IsChanged = true;
                    _closeBraceTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taAccessors = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _openBraceToken = ((AccessorListSyntax) Node).OpenBraceToken;
            _openBraceTokenIsChanged = false;
            _accessors = ((AccessorListSyntax) Node).Accessors;
            _accessorsIsChanged = false;
            _accessorsCount = _accessors.Count;
            _closeBraceToken = ((AccessorListSyntax) Node).CloseBraceToken;
            _closeBraceTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaAccessors)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AccessorList(OpenBraceToken, Accessors, CloseBraceToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAccessors)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenBraceTokenStr", OpenBraceTokenStr);
            yield return ("AccessorsStr", AccessorsStr);
            yield return ("CloseBraceTokenStr", CloseBraceTokenStr);
        }

        public TameAccessorListSyntax AddAccessor(TameAccessorDeclarationSyntax item)
        {
            item.TaParent = this;
            TaAccessors.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}