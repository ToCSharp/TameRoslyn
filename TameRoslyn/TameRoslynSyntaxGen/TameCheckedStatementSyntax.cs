// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCheckedStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "CheckedStatementSyntax";
        private BlockSyntax _block;
        private bool _blockIsChanged;
        private string _blockStr;
        private SyntaxToken _keyword;
        private bool _keywordIsChanged;
        private string _keywordStr;
        private TameBlockSyntax _taBlock;

        public TameCheckedStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseCheckedStatement(code);
            AddChildren();
        }

        public TameCheckedStatementSyntax(CheckedStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameCheckedStatementSyntax()
        {
            KeywordStr = DefaultValues.CheckedStatementSyntaxKeywordStr;
            BlockStr = DefaultValues.CheckedStatementSyntaxBlockStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken Keyword
        {
            get
            {
                if (_keywordIsChanged)
                {
                    _keyword = SyntaxFactoryStr.ParseSyntaxToken(KeywordStr);
                    _keywordIsChanged = false;
                }
                return _keyword;
            }
            set
            {
                if (_keyword != value)
                {
                    _keyword = value;
                    _keywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string KeywordStr
        {
            get
            {
                if (_keywordIsChanged) return _keywordStr;
                return _keywordStr = _keyword.Text;
            }
            set
            {
                if (_keywordStr != value)
                {
                    _keywordStr = value;
                    IsChanged = true;
                    _keywordIsChanged = true;
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
            _keyword = ((CheckedStatementSyntax) Node).Keyword;
            _keywordIsChanged = false;
            _block = ((CheckedStatementSyntax) Node).Block;
            _blockIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            return SyntaxFacts.GetCheckStatement(TameSyntaxFacts.SyntaxKindFromStr(KeywordStr));
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.CheckedStatement(GetKind(), Keyword, Block);
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
            yield return ("KeywordStr", KeywordStr);
            yield return ("BlockStr", BlockStr);
        }
    }
}