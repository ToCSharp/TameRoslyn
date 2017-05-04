// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameUnsafeStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "UnsafeStatementSyntax";
        private BlockSyntax _block;
        private bool _blockIsChanged;
        private string _blockStr;
        private TameBlockSyntax _taBlock;
        private SyntaxToken _unsafeKeyword;
        private bool _unsafeKeywordIsChanged;
        private string _unsafeKeywordStr;

        public TameUnsafeStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseUnsafeStatement(code);
            AddChildren();
        }

        public TameUnsafeStatementSyntax(UnsafeStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameUnsafeStatementSyntax()
        {
            UnsafeKeywordStr = DefaultValues.UnsafeStatementSyntaxUnsafeKeywordStr;
            BlockStr = DefaultValues.UnsafeStatementSyntaxBlockStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken UnsafeKeyword
        {
            get
            {
                if (_unsafeKeywordIsChanged)
                {
                    if (_unsafeKeywordStr == null) _unsafeKeyword = default(SyntaxToken);
                    else
                        _unsafeKeyword = SyntaxFactoryStr.ParseSyntaxToken(_unsafeKeywordStr, SyntaxKind.UnsafeKeyword);
                    _unsafeKeywordIsChanged = false;
                }
                return _unsafeKeyword;
            }
            set
            {
                if (_unsafeKeyword != value)
                {
                    _unsafeKeyword = value;
                    _unsafeKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string UnsafeKeywordStr
        {
            get
            {
                if (_unsafeKeywordIsChanged) return _unsafeKeywordStr;
                return _unsafeKeywordStr = _unsafeKeyword.Text;
            }
            set
            {
                if (_unsafeKeywordStr != value)
                {
                    _unsafeKeywordStr = value;
                    IsChanged = true;
                    _unsafeKeywordIsChanged = true;
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
            base.Clear();
            _taBlock = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _unsafeKeyword = ((UnsafeStatementSyntax) Node).UnsafeKeyword;
            _unsafeKeywordIsChanged = false;
            _block = ((UnsafeStatementSyntax) Node).Block;
            _blockIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.UnsafeStatement(UnsafeKeyword, Block);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaBlock != null) yield return TaBlock;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("UnsafeKeywordStr", UnsafeKeywordStr);
            yield return ("BlockStr", BlockStr);
        }
    }
}