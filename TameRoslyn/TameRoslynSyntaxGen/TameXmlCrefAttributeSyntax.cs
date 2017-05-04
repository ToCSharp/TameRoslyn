// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameXmlCrefAttributeSyntax : TameXmlAttributeSyntax
    {
        public new static string TypeName = "XmlCrefAttributeSyntax";
        private CrefSyntax _cref;
        private bool _crefIsChanged;
        private string _crefStr;
        private TameCrefSyntax _taCref;

        public TameXmlCrefAttributeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseXmlCrefAttribute(code);
            AddChildren();
        }

        public TameXmlCrefAttributeSyntax(XmlCrefAttributeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameXmlCrefAttributeSyntax()
        {
            // CrefStr = DefaultValues.XmlCrefAttributeSyntaxCrefStr;
            // NameStr = DefaultValues.XmlCrefAttributeSyntaxNameStr;
            // EqualsTokenStr = DefaultValues.XmlCrefAttributeSyntaxEqualsTokenStr;
            // StartQuoteTokenStr = DefaultValues.XmlCrefAttributeSyntaxStartQuoteTokenStr;
            // EndQuoteTokenStr = DefaultValues.XmlCrefAttributeSyntaxEndQuoteTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public CrefSyntax Cref
        {
            get
            {
                if (_crefIsChanged)
                {
                    _cref = SyntaxFactoryStr.ParseCrefSyntax(CrefStr);
                    _crefIsChanged = false;
                    _taCref = null;
                }
                else if (_taCref != null && _taCref.IsChanged)
                {
                    _cref = (CrefSyntax) _taCref.Node;
                }
                return _cref;
            }
            set
            {
                if (_cref != value)
                {
                    _cref = value;
                    _crefIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CrefStr
        {
            get
            {
                if (_taCref != null && _taCref.IsChanged)
                    Cref = (CrefSyntax) _taCref.Node;
                if (_crefIsChanged) return _crefStr;
                return _crefStr = _cref?.ToFullString();
            }
            set
            {
                if (_taCref != null && _taCref.IsChanged)
                {
                    Cref = (CrefSyntax) _taCref.Node;
                    _crefStr = _cref?.ToFullString();
                }
                if (_crefStr != value)
                {
                    _crefStr = value;
                    IsChanged = true;
                    _crefIsChanged = true;
                    _taCref = null;
                }
            }
        }

        public TameCrefSyntax TaCref
        {
            get
            {
                if (_taCref == null && Cref != null)
                    if (Cref is ConversionOperatorMemberCrefSyntax)
                    {
                        var loc =
                            new TameConversionOperatorMemberCrefSyntax((ConversionOperatorMemberCrefSyntax) Cref)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taCref = loc;
                    }
                    else if (Cref is OperatorMemberCrefSyntax)
                    {
                        var loc = new TameOperatorMemberCrefSyntax((OperatorMemberCrefSyntax) Cref) {TaParent = this};
                        loc.AddChildren();
                        _taCref = loc;
                    }
                    else if (Cref is IndexerMemberCrefSyntax)
                    {
                        var loc = new TameIndexerMemberCrefSyntax((IndexerMemberCrefSyntax) Cref) {TaParent = this};
                        loc.AddChildren();
                        _taCref = loc;
                    }
                    else if (Cref is NameMemberCrefSyntax)
                    {
                        var loc = new TameNameMemberCrefSyntax((NameMemberCrefSyntax) Cref) {TaParent = this};
                        loc.AddChildren();
                        _taCref = loc;
                    }
                    else if (Cref is QualifiedCrefSyntax)
                    {
                        var loc = new TameQualifiedCrefSyntax((QualifiedCrefSyntax) Cref) {TaParent = this};
                        loc.AddChildren();
                        _taCref = loc;
                    }
                    else if (Cref is TypeCrefSyntax)
                    {
                        var loc = new TameTypeCrefSyntax((TypeCrefSyntax) Cref) {TaParent = this};
                        loc.AddChildren();
                        _taCref = loc;
                    }
                return _taCref;
            }
            set
            {
                if (_taCref != value)
                {
                    _taCref = value;
                    if (_taCref != null)
                    {
                        _taCref.TaParent = this;
                        _taCref.IsChanged = true;
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
            _taCref = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _cref = ((XmlCrefAttributeSyntax) Node).Cref;
            _crefIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.XmlCrefAttribute(Name, EqualsToken, StartQuoteToken, Cref, EndQuoteToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaCref != null) yield return TaCref;
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("CrefStr", CrefStr);
            yield return ("NameStr", NameStr);
            yield return ("EqualsTokenStr", EqualsTokenStr);
            yield return ("StartQuoteTokenStr", StartQuoteTokenStr);
            yield return ("EndQuoteTokenStr", EndQuoteTokenStr);
        }
    }
}