// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameTryStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "TryStatementSyntax";
        private BlockSyntax _block;
        private bool _blockIsChanged;
        private string _blockStr;
        private SyntaxList<CatchClauseSyntax> _catches;
        private int _catchesCount;
        private bool _catchesIsChanged;
        private string _catchesStr;
        private FinallyClauseSyntax _finally;
        private bool _finallyIsChanged;
        private string _finallyStr;
        private TameBlockSyntax _taBlock;
        private List<TameCatchClauseSyntax> _taCatches;
        private TameFinallyClauseSyntax _taFinally;
        private SyntaxToken _tryKeyword;
        private bool _tryKeywordIsChanged;
        private string _tryKeywordStr;

        public TameTryStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTryStatement(code);
            AddChildren();
        }

        public TameTryStatementSyntax(TryStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTryStatementSyntax()
        {
            TryKeywordStr = DefaultValues.TryStatementSyntaxTryKeywordStr;
            BlockStr = DefaultValues.TryStatementSyntaxBlockStr;
            CatchesStr = DefaultValues.TryStatementSyntaxCatchesStr;
            FinallyStr = DefaultValues.TryStatementSyntaxFinallyStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken TryKeyword
        {
            get
            {
                if (_tryKeywordIsChanged)
                {
                    if (_tryKeywordStr == null) _tryKeyword = default(SyntaxToken);
                    else _tryKeyword = SyntaxFactoryStr.ParseSyntaxToken(_tryKeywordStr, SyntaxKind.TryKeyword);
                    _tryKeywordIsChanged = false;
                }
                return _tryKeyword;
            }
            set
            {
                if (_tryKeyword != value)
                {
                    _tryKeyword = value;
                    _tryKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TryKeywordStr
        {
            get
            {
                if (_tryKeywordIsChanged) return _tryKeywordStr;
                return _tryKeywordStr = _tryKeyword.Text;
            }
            set
            {
                if (_tryKeywordStr != value)
                {
                    _tryKeywordStr = value;
                    IsChanged = true;
                    _tryKeywordIsChanged = true;
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

        public bool TaCatchesIsChanged { get; set; }

        public SyntaxList<CatchClauseSyntax> Catches
        {
            get
            {
                if (TaCatchesIsChanged || _taCatches != null &&
                    (_taCatches.Count != _catchesCount || _taCatches.Any(v => v.IsChanged)))
                {
                    _catches = SyntaxFactory.List(TaCatches?.Select(v => v.Node).Cast<CatchClauseSyntax>());
                    TaCatchesIsChanged = false;
                }
                return _catches;
            }
            set
            {
                if (_catches != value)
                {
                    _catches = value;
                    TaCatchesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CatchesStr
        {
            get
            {
                if (_catchesIsChanged) return _catchesStr;
                return _catchesStr = string.Join(", ", _catches.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _catchesStr = value;
                    Catches = new SyntaxList<CatchClauseSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameCatchClauseSyntax> TaCatches
        {
            get
            {
                if (_taCatches == null)
                {
                    _taCatches = new List<TameCatchClauseSyntax>();
                    foreach (var item in _catches)
                        _taCatches.Add(new TameCatchClauseSyntax(item) {TaParent = this});
                }
                return _taCatches;
            }
            set
            {
                if (_taCatches != value)
                {
                    _taCatches = value;
                    _taCatches?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaCatchesIsChanged = true;
                }
            }
        }

        public FinallyClauseSyntax Finally
        {
            get
            {
                if (_finallyIsChanged)
                {
                    _finally = SyntaxFactoryStr.ParseFinallyClauseSyntax(FinallyStr);
                    _finallyIsChanged = false;
                    _taFinally = null;
                }
                else if (_taFinally != null && _taFinally.IsChanged)
                {
                    _finally = (FinallyClauseSyntax) _taFinally.Node;
                }
                return _finally;
            }
            set
            {
                if (_finally != value)
                {
                    _finally = value;
                    _finallyIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FinallyStr
        {
            get
            {
                if (_taFinally != null && _taFinally.IsChanged)
                    Finally = (FinallyClauseSyntax) _taFinally.Node;
                if (_finallyIsChanged) return _finallyStr;
                return _finallyStr = _finally?.ToFullString();
            }
            set
            {
                if (_taFinally != null && _taFinally.IsChanged)
                {
                    Finally = (FinallyClauseSyntax) _taFinally.Node;
                    _finallyStr = _finally?.ToFullString();
                }
                if (_finallyStr != value)
                {
                    _finallyStr = value;
                    IsChanged = true;
                    _finallyIsChanged = true;
                    _taFinally = null;
                }
            }
        }

        public TameFinallyClauseSyntax TaFinally
        {
            get
            {
                if (_taFinally == null && Finally != null)
                {
                    _taFinally = new TameFinallyClauseSyntax(Finally) {TaParent = this};
                    _taFinally.AddChildren();
                }
                return _taFinally;
            }
            set
            {
                if (_taFinally != value)
                {
                    _taFinally = value;
                    if (_taFinally != null)
                    {
                        _taFinally.TaParent = this;
                        _taFinally.IsChanged = true;
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
            _taBlock = null;
            _taCatches = null;
            _taFinally = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _tryKeyword = ((TryStatementSyntax) Node).TryKeyword;
            _tryKeywordIsChanged = false;
            _block = ((TryStatementSyntax) Node).Block;
            _blockIsChanged = false;
            _catches = ((TryStatementSyntax) Node).Catches;
            _catchesIsChanged = false;
            _catchesCount = _catches.Count;
            _finally = ((TryStatementSyntax) Node).Finally;
            _finallyIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
            foreach (var item in TaCatches)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TryStatement(TryKeyword, Block, Catches, Finally);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaCatches)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaBlock != null) yield return TaBlock;
            if (TaFinally != null) yield return TaFinally;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("TryKeywordStr", TryKeywordStr);
            yield return ("BlockStr", BlockStr);
            yield return ("CatchesStr", CatchesStr);
            yield return ("FinallyStr", FinallyStr);
        }

        public TameTryStatementSyntax AddCatche(TameCatchClauseSyntax item)
        {
            item.TaParent = this;
            TaCatches.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}