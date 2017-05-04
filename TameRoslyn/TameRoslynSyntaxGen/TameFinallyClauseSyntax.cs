// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameFinallyClauseSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "FinallyClauseSyntax";
        private BlockSyntax _block;
        private bool _blockIsChanged;
        private string _blockStr;
        private SyntaxToken _finallyKeyword;
        private bool _finallyKeywordIsChanged;
        private string _finallyKeywordStr;
        private TameBlockSyntax _taBlock;

        public TameFinallyClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseFinallyClause(code);
            AddChildren();
        }

        public TameFinallyClauseSyntax(FinallyClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameFinallyClauseSyntax()
        {
            FinallyKeywordStr = DefaultValues.FinallyClauseSyntaxFinallyKeywordStr;
            BlockStr = DefaultValues.FinallyClauseSyntaxBlockStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken FinallyKeyword
        {
            get
            {
                if (_finallyKeywordIsChanged)
                {
                    if (_finallyKeywordStr == null) _finallyKeyword = default(SyntaxToken);
                    else
                        _finallyKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_finallyKeywordStr, SyntaxKind.FinallyKeyword);
                    _finallyKeywordIsChanged = false;
                }
                return _finallyKeyword;
            }
            set
            {
                if (_finallyKeyword != value)
                {
                    _finallyKeyword = value;
                    _finallyKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FinallyKeywordStr
        {
            get
            {
                if (_finallyKeywordIsChanged) return _finallyKeywordStr;
                return _finallyKeywordStr = _finallyKeyword.Text;
            }
            set
            {
                if (_finallyKeywordStr != value)
                {
                    _finallyKeywordStr = value;
                    IsChanged = true;
                    _finallyKeywordIsChanged = true;
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
            _taBlock = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _finallyKeyword = ((FinallyClauseSyntax) Node).FinallyKeyword;
            _finallyKeywordIsChanged = false;
            _block = ((FinallyClauseSyntax) Node).Block;
            _blockIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.FinallyClause(FinallyKeyword, Block);
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
            yield return ("FinallyKeywordStr", FinallyKeywordStr);
            yield return ("BlockStr", BlockStr);
        }
    }
}