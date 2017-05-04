// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameIndexerDeclarationSyntax : TameBasePropertyDeclarationSyntax
    {
        public new static string TypeName = "IndexerDeclarationSyntax";
        private ArrowExpressionClauseSyntax _expressionBody;
        private bool _expressionBodyIsChanged;
        private string _expressionBodyStr;
        private BracketedParameterListSyntax _parameterList;
        private bool _parameterListIsChanged;
        private string _parameterListStr;
        private SyntaxToken _semicolon;
        private bool _semicolonIsChanged;
        private string _semicolonStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private TameArrowExpressionClauseSyntax _taExpressionBody;
        private TameBracketedParameterListSyntax _taParameterList;
        private SyntaxToken _thisKeyword;
        private bool _thisKeywordIsChanged;
        private string _thisKeywordStr;

        public TameIndexerDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseIndexerDeclaration(code);
            AddChildren();
        }

        public TameIndexerDeclarationSyntax(IndexerDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameIndexerDeclarationSyntax()
        {
            SemicolonStr = DefaultValues.IndexerDeclarationSyntaxSemicolonStr;
            ThisKeywordStr = DefaultValues.IndexerDeclarationSyntaxThisKeywordStr;
            ParameterListStr = DefaultValues.IndexerDeclarationSyntaxParameterListStr;
            ExpressionBodyStr = DefaultValues.IndexerDeclarationSyntaxExpressionBodyStr;
            SemicolonTokenStr = DefaultValues.IndexerDeclarationSyntaxSemicolonTokenStr;
            AttributeListsStr = DefaultValues.IndexerDeclarationSyntaxAttributeListsStr;
            ModifiersStr = DefaultValues.IndexerDeclarationSyntaxModifiersStr;
            TypeStr = DefaultValues.IndexerDeclarationSyntaxTypeStr;
            ExplicitInterfaceSpecifierStr = DefaultValues.IndexerDeclarationSyntaxExplicitInterfaceSpecifierStr;
            AccessorListStr = DefaultValues.IndexerDeclarationSyntaxAccessorListStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken Semicolon
        {
            get
            {
                if (_semicolonIsChanged)
                {
                    _semicolon = SyntaxFactoryStr.ParseSyntaxToken(SemicolonStr);
                    _semicolonIsChanged = false;
                }
                return _semicolon;
            }
            set
            {
                if (_semicolon != value)
                {
                    _semicolon = value;
                    _semicolonIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonStr
        {
            get
            {
                if (_semicolonIsChanged) return _semicolonStr;
                return _semicolonStr = _semicolon.Text;
            }
            set
            {
                if (_semicolonStr != value)
                {
                    _semicolonStr = value;
                    IsChanged = true;
                    _semicolonIsChanged = true;
                }
            }
        }

        public SyntaxToken ThisKeyword
        {
            get
            {
                if (_thisKeywordIsChanged)
                {
                    if (_thisKeywordStr == null) _thisKeyword = default(SyntaxToken);
                    else _thisKeyword = SyntaxFactoryStr.ParseSyntaxToken(_thisKeywordStr, SyntaxKind.ThisKeyword);
                    _thisKeywordIsChanged = false;
                }
                return _thisKeyword;
            }
            set
            {
                if (_thisKeyword != value)
                {
                    _thisKeyword = value;
                    _thisKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ThisKeywordStr
        {
            get
            {
                if (_thisKeywordIsChanged) return _thisKeywordStr;
                return _thisKeywordStr = _thisKeyword.Text;
            }
            set
            {
                if (_thisKeywordStr != value)
                {
                    _thisKeywordStr = value;
                    IsChanged = true;
                    _thisKeywordIsChanged = true;
                }
            }
        }

        public BracketedParameterListSyntax ParameterList
        {
            get
            {
                if (_parameterListIsChanged)
                {
                    _parameterList = SyntaxFactoryStr.ParseBracketedParameterListSyntax(ParameterListStr);
                    _parameterListIsChanged = false;
                    _taParameterList = null;
                }
                else if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    _parameterList = (BracketedParameterListSyntax) _taParameterList.Node;
                }
                return _parameterList;
            }
            set
            {
                if (_parameterList != value)
                {
                    _parameterList = value;
                    _parameterListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ParameterListStr
        {
            get
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                    ParameterList = (BracketedParameterListSyntax) _taParameterList.Node;
                if (_parameterListIsChanged) return _parameterListStr;
                return _parameterListStr = _parameterList?.ToFullString();
            }
            set
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    ParameterList = (BracketedParameterListSyntax) _taParameterList.Node;
                    _parameterListStr = _parameterList?.ToFullString();
                }
                if (_parameterListStr != value)
                {
                    _parameterListStr = value;
                    IsChanged = true;
                    _parameterListIsChanged = true;
                    _taParameterList = null;
                }
            }
        }

        public TameBracketedParameterListSyntax TaParameterList
        {
            get
            {
                if (_taParameterList == null && ParameterList != null)
                {
                    _taParameterList = new TameBracketedParameterListSyntax(ParameterList) {TaParent = this};
                    _taParameterList.AddChildren();
                }
                return _taParameterList;
            }
            set
            {
                if (_taParameterList != value)
                {
                    _taParameterList = value;
                    if (_taParameterList != null)
                    {
                        _taParameterList.TaParent = this;
                        _taParameterList.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public ArrowExpressionClauseSyntax ExpressionBody
        {
            get
            {
                if (_expressionBodyIsChanged)
                {
                    _expressionBody = SyntaxFactoryStr.ParseArrowExpressionClauseSyntax(ExpressionBodyStr);
                    _expressionBodyIsChanged = false;
                    _taExpressionBody = null;
                }
                else if (_taExpressionBody != null && _taExpressionBody.IsChanged)
                {
                    _expressionBody = (ArrowExpressionClauseSyntax) _taExpressionBody.Node;
                }
                return _expressionBody;
            }
            set
            {
                if (_expressionBody != value)
                {
                    _expressionBody = value;
                    _expressionBodyIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ExpressionBodyStr
        {
            get
            {
                if (_taExpressionBody != null && _taExpressionBody.IsChanged)
                    ExpressionBody = (ArrowExpressionClauseSyntax) _taExpressionBody.Node;
                if (_expressionBodyIsChanged) return _expressionBodyStr;
                return _expressionBodyStr = _expressionBody?.ToFullString();
            }
            set
            {
                if (_taExpressionBody != null && _taExpressionBody.IsChanged)
                {
                    ExpressionBody = (ArrowExpressionClauseSyntax) _taExpressionBody.Node;
                    _expressionBodyStr = _expressionBody?.ToFullString();
                }
                if (_expressionBodyStr != value)
                {
                    _expressionBodyStr = value;
                    IsChanged = true;
                    _expressionBodyIsChanged = true;
                    _taExpressionBody = null;
                }
            }
        }

        public TameArrowExpressionClauseSyntax TaExpressionBody
        {
            get
            {
                if (_taExpressionBody == null && ExpressionBody != null)
                {
                    _taExpressionBody = new TameArrowExpressionClauseSyntax(ExpressionBody) {TaParent = this};
                    _taExpressionBody.AddChildren();
                }
                return _taExpressionBody;
            }
            set
            {
                if (_taExpressionBody != value)
                {
                    _taExpressionBody = value;
                    if (_taExpressionBody != null)
                    {
                        _taExpressionBody.TaParent = this;
                        _taExpressionBody.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken SemicolonToken
        {
            get
            {
                if (_semicolonTokenIsChanged)
                {
                    if (_semicolonTokenStr == null) _semicolonToken = default(SyntaxToken);
                    else
                        _semicolonToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_semicolonTokenStr, SyntaxKind.SemicolonToken);
                    _semicolonTokenIsChanged = false;
                }
                return _semicolonToken;
            }
            set
            {
                if (_semicolonToken != value)
                {
                    _semicolonToken = value;
                    _semicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonTokenStr
        {
            get
            {
                if (_semicolonTokenIsChanged) return _semicolonTokenStr;
                return _semicolonTokenStr = _semicolonToken.Text;
            }
            set
            {
                if (_semicolonTokenStr != value)
                {
                    _semicolonTokenStr = value;
                    IsChanged = true;
                    _semicolonTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taParameterList = null;
            _taExpressionBody = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _thisKeyword = ((IndexerDeclarationSyntax) Node).ThisKeyword;
            _thisKeywordIsChanged = false;
            _parameterList = ((IndexerDeclarationSyntax) Node).ParameterList;
            _parameterListIsChanged = false;
            _expressionBody = ((IndexerDeclarationSyntax) Node).ExpressionBody;
            _expressionBodyIsChanged = false;
            _semicolonToken = ((IndexerDeclarationSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.IndexerDeclaration(AttributeLists, Modifiers, Type, ExplicitInterfaceSpecifier,
                ThisKeyword, ParameterList, AccessorList, ExpressionBody, SemicolonToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaAttributeLists)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaParameterList != null) yield return TaParameterList;
            if (TaExpressionBody != null) yield return TaExpressionBody;
            if (TaType != null) yield return TaType;
            if (TaExplicitInterfaceSpecifier != null) yield return TaExplicitInterfaceSpecifier;
            if (TaAccessorList != null) yield return TaAccessorList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("SemicolonStr", SemicolonStr);
            yield return ("ThisKeywordStr", ThisKeywordStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("ExpressionBodyStr", ExpressionBodyStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
            yield return ("AttributeListsStr", AttributeListsStr);
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("TypeStr", TypeStr);
            yield return ("ExplicitInterfaceSpecifierStr", ExplicitInterfaceSpecifierStr);
            yield return ("AccessorListStr", AccessorListStr);
        }

        public TameIndexerDeclarationSyntax AddAttributeList(TameAttributeListSyntax item)
        {
            item.TaParent = this;
            TaAttributeLists.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}