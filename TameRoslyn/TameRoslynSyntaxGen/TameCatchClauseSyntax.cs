// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCatchClauseSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "CatchClauseSyntax";
        private BlockSyntax _block;
        private bool _blockIsChanged;
        private string _blockStr;
        private SyntaxToken _catchKeyword;
        private bool _catchKeywordIsChanged;
        private string _catchKeywordStr;
        private CatchDeclarationSyntax _declaration;
        private bool _declarationIsChanged;
        private string _declarationStr;
        private CatchFilterClauseSyntax _filter;
        private bool _filterIsChanged;
        private string _filterStr;
        private TameBlockSyntax _taBlock;
        private TameCatchDeclarationSyntax _taDeclaration;
        private TameCatchFilterClauseSyntax _taFilter;

        public TameCatchClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCatchClause(code);
            AddChildren();
        }

        public TameCatchClauseSyntax(CatchClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCatchClauseSyntax()
        {
            CatchKeywordStr = DefaultValues.CatchClauseSyntaxCatchKeywordStr;
            DeclarationStr = DefaultValues.CatchClauseSyntaxDeclarationStr;
            FilterStr = DefaultValues.CatchClauseSyntaxFilterStr;
            BlockStr = DefaultValues.CatchClauseSyntaxBlockStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken CatchKeyword
        {
            get
            {
                if (_catchKeywordIsChanged)
                {
                    if (_catchKeywordStr == null) _catchKeyword = default(SyntaxToken);
                    else _catchKeyword = SyntaxFactoryStr.ParseSyntaxToken(_catchKeywordStr, SyntaxKind.CatchKeyword);
                    _catchKeywordIsChanged = false;
                }
                return _catchKeyword;
            }
            set
            {
                if (_catchKeyword != value)
                {
                    _catchKeyword = value;
                    _catchKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CatchKeywordStr
        {
            get
            {
                if (_catchKeywordIsChanged) return _catchKeywordStr;
                return _catchKeywordStr = _catchKeyword.Text;
            }
            set
            {
                if (_catchKeywordStr != value)
                {
                    _catchKeywordStr = value;
                    IsChanged = true;
                    _catchKeywordIsChanged = true;
                }
            }
        }

        public CatchDeclarationSyntax Declaration
        {
            get
            {
                if (_declarationIsChanged)
                {
                    _declaration = SyntaxFactoryStr.ParseCatchDeclarationSyntax(DeclarationStr);
                    _declarationIsChanged = false;
                    _taDeclaration = null;
                }
                else if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    _declaration = (CatchDeclarationSyntax) _taDeclaration.Node;
                }
                return _declaration;
            }
            set
            {
                if (_declaration != value)
                {
                    _declaration = value;
                    _declarationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DeclarationStr
        {
            get
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                    Declaration = (CatchDeclarationSyntax) _taDeclaration.Node;
                if (_declarationIsChanged) return _declarationStr;
                return _declarationStr = _declaration?.ToFullString();
            }
            set
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    Declaration = (CatchDeclarationSyntax) _taDeclaration.Node;
                    _declarationStr = _declaration?.ToFullString();
                }
                if (_declarationStr != value)
                {
                    _declarationStr = value;
                    IsChanged = true;
                    _declarationIsChanged = true;
                    _taDeclaration = null;
                }
            }
        }

        public TameCatchDeclarationSyntax TaDeclaration
        {
            get
            {
                if (_taDeclaration == null && Declaration != null)
                {
                    _taDeclaration = new TameCatchDeclarationSyntax(Declaration) {TaParent = this};
                    _taDeclaration.AddChildren();
                }
                return _taDeclaration;
            }
            set
            {
                if (_taDeclaration != value)
                {
                    _taDeclaration = value;
                    if (_taDeclaration != null)
                    {
                        _taDeclaration.TaParent = this;
                        _taDeclaration.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public CatchFilterClauseSyntax Filter
        {
            get
            {
                if (_filterIsChanged)
                {
                    _filter = SyntaxFactoryStr.ParseCatchFilterClauseSyntax(FilterStr);
                    _filterIsChanged = false;
                    _taFilter = null;
                }
                else if (_taFilter != null && _taFilter.IsChanged)
                {
                    _filter = (CatchFilterClauseSyntax) _taFilter.Node;
                }
                return _filter;
            }
            set
            {
                if (_filter != value)
                {
                    _filter = value;
                    _filterIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FilterStr
        {
            get
            {
                if (_taFilter != null && _taFilter.IsChanged)
                    Filter = (CatchFilterClauseSyntax) _taFilter.Node;
                if (_filterIsChanged) return _filterStr;
                return _filterStr = _filter?.ToFullString();
            }
            set
            {
                if (_taFilter != null && _taFilter.IsChanged)
                {
                    Filter = (CatchFilterClauseSyntax) _taFilter.Node;
                    _filterStr = _filter?.ToFullString();
                }
                if (_filterStr != value)
                {
                    _filterStr = value;
                    IsChanged = true;
                    _filterIsChanged = true;
                    _taFilter = null;
                }
            }
        }

        public TameCatchFilterClauseSyntax TaFilter
        {
            get
            {
                if (_taFilter == null && Filter != null)
                {
                    _taFilter = new TameCatchFilterClauseSyntax(Filter) {TaParent = this};
                    _taFilter.AddChildren();
                }
                return _taFilter;
            }
            set
            {
                if (_taFilter != value)
                {
                    _taFilter = value;
                    if (_taFilter != null)
                    {
                        _taFilter.TaParent = this;
                        _taFilter.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public BlockSyntax Block
        {
            get
            {
                if (_blockIsChanged)
                {
                    _block = SyntaxFactoryStr.ParseBlockSyntax(BlockStr);
                    _blockIsChanged = false;
                    _taBlock = null;
                }
                else if (_taBlock != null && _taBlock.IsChanged)
                {
                    _block = (BlockSyntax) _taBlock.Node;
                }
                return _block;
            }
            set
            {
                if (_block != value)
                {
                    _block = value;
                    _blockIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string BlockStr
        {
            get
            {
                if (_taBlock != null && _taBlock.IsChanged)
                    Block = (BlockSyntax) _taBlock.Node;
                if (_blockIsChanged) return _blockStr;
                return _blockStr = _block?.ToFullString();
            }
            set
            {
                if (_taBlock != null && _taBlock.IsChanged)
                {
                    Block = (BlockSyntax) _taBlock.Node;
                    _blockStr = _block?.ToFullString();
                }
                if (_blockStr != value)
                {
                    _blockStr = value;
                    IsChanged = true;
                    _blockIsChanged = true;
                    _taBlock = null;
                }
            }
        }

        public TameBlockSyntax TaBlock
        {
            get
            {
                if (_taBlock == null && Block != null)
                {
                    _taBlock = new TameBlockSyntax(Block) {TaParent = this};
                    _taBlock.AddChildren();
                }
                return _taBlock;
            }
            set
            {
                if (_taBlock != value)
                {
                    _taBlock = value;
                    if (_taBlock != null)
                    {
                        _taBlock.TaParent = this;
                        _taBlock.IsChanged = true;
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
            _taDeclaration = null;
            _taFilter = null;
            _taBlock = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _catchKeyword = ((CatchClauseSyntax) Node).CatchKeyword;
            _catchKeywordIsChanged = false;
            _declaration = ((CatchClauseSyntax) Node).Declaration;
            _declarationIsChanged = false;
            _filter = ((CatchClauseSyntax) Node).Filter;
            _filterIsChanged = false;
            _block = ((CatchClauseSyntax) Node).Block;
            _blockIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CatchClause(CatchKeyword, Declaration, Filter, Block);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaDeclaration != null) yield return TaDeclaration;
            if (TaFilter != null) yield return TaFilter;
            if (TaBlock != null) yield return TaBlock;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("CatchKeywordStr", CatchKeywordStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("FilterStr", FilterStr);
            yield return ("BlockStr", BlockStr);
        }
    }
}