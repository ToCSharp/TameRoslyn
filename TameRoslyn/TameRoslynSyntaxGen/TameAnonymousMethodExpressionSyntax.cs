// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAnonymousMethodExpressionSyntax : TameAnonymousFunctionExpressionSyntax
    {
        public new static string TypeName = "AnonymousMethodExpressionSyntax";
        private BlockSyntax _block;
        private bool _blockIsChanged;
        private string _blockStr;
        private SyntaxToken _delegateKeyword;
        private bool _delegateKeywordIsChanged;
        private string _delegateKeywordStr;
        private ParameterListSyntax _parameterList;
        private bool _parameterListIsChanged;
        private string _parameterListStr;
        private TameBlockSyntax _taBlock;
        private TameParameterListSyntax _taParameterList;

        public TameAnonymousMethodExpressionSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAnonymousMethodExpression(code);
            AddChildren();
        }

        public TameAnonymousMethodExpressionSyntax(AnonymousMethodExpressionSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAnonymousMethodExpressionSyntax()
        {
            BlockStr = DefaultValues.AnonymousMethodExpressionSyntaxBlockStr;
            DelegateKeywordStr = DefaultValues.AnonymousMethodExpressionSyntaxDelegateKeywordStr;
            ParameterListStr = DefaultValues.AnonymousMethodExpressionSyntaxParameterListStr;
            AsyncKeywordStr = DefaultValues.AnonymousMethodExpressionSyntaxAsyncKeywordStr;
            BodyStr = DefaultValues.AnonymousMethodExpressionSyntaxBodyStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public SyntaxToken DelegateKeyword
        {
            get
            {
                if (_delegateKeywordIsChanged)
                {
                    if (_delegateKeywordStr == null) _delegateKeyword = default(SyntaxToken);
                    else
                        _delegateKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_delegateKeywordStr, SyntaxKind.DelegateKeyword);
                    _delegateKeywordIsChanged = false;
                }
                return _delegateKeyword;
            }
            set
            {
                if (_delegateKeyword != value)
                {
                    _delegateKeyword = value;
                    _delegateKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DelegateKeywordStr
        {
            get
            {
                if (_delegateKeywordIsChanged) return _delegateKeywordStr;
                return _delegateKeywordStr = _delegateKeyword.Text;
            }
            set
            {
                if (_delegateKeywordStr != value)
                {
                    _delegateKeywordStr = value;
                    IsChanged = true;
                    _delegateKeywordIsChanged = true;
                }
            }
        }

        public ParameterListSyntax ParameterList
        {
            get
            {
                if (_parameterListIsChanged)
                {
                    _parameterList = SyntaxFactoryStr.ParseParameterListSyntax(ParameterListStr);
                    _parameterListIsChanged = false;
                    _taParameterList = null;
                }
                else if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    _parameterList = (ParameterListSyntax) _taParameterList.Node;
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
                    ParameterList = (ParameterListSyntax) _taParameterList.Node;
                if (_parameterListIsChanged) return _parameterListStr;
                return _parameterListStr = _parameterList?.ToFullString();
            }
            set
            {
                if (_taParameterList != null && _taParameterList.IsChanged)
                {
                    ParameterList = (ParameterListSyntax) _taParameterList.Node;
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

        public TameParameterListSyntax TaParameterList
        {
            get
            {
                if (_taParameterList == null && ParameterList != null)
                {
                    _taParameterList = new TameParameterListSyntax(ParameterList) {TaParent = this};
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

        public override void Clear()
        {
            base.Clear();
            _taBlock = null;
            _taParameterList = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _block = ((AnonymousMethodExpressionSyntax) Node).Block;
            _blockIsChanged = false;
            _delegateKeyword = ((AnonymousMethodExpressionSyntax) Node).DelegateKeyword;
            _delegateKeywordIsChanged = false;
            _parameterList = ((AnonymousMethodExpressionSyntax) Node).ParameterList;
            _parameterListIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AnonymousMethodExpression(AsyncKeyword, DelegateKeyword, ParameterList, Body);
            if (Block != null) res = res.WithBlock(Block);
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
            if (TaParameterList != null) yield return TaParameterList;
            if (TaBody != null) yield return TaBody;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("BlockStr", BlockStr);
            yield return ("DelegateKeywordStr", DelegateKeywordStr);
            yield return ("ParameterListStr", ParameterListStr);
            yield return ("AsyncKeywordStr", AsyncKeywordStr);
            yield return ("BodyStr", BodyStr);
        }
    }
}