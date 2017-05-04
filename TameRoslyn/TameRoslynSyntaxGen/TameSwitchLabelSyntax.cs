// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameSwitchLabelSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "SwitchLabelSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private SyntaxToken _keyword;
        private bool _keywordIsChanged;
        private string _keywordStr;

        public TameSwitchLabelSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSwitchLabel(code);
            AddChildren();
        }

        public TameSwitchLabelSyntax(SwitchLabelSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSwitchLabelSyntax()
        {
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

        public SyntaxToken ColonToken
        {
            get
            {
                if (_colonTokenIsChanged)
                {
                    if (_colonTokenStr == null) _colonToken = default(SyntaxToken);
                    else _colonToken = SyntaxFactoryStr.ParseSyntaxToken(_colonTokenStr, SyntaxKind.ColonToken);
                    _colonTokenIsChanged = false;
                }
                return _colonToken;
            }
            set
            {
                if (_colonToken != value)
                {
                    _colonToken = value;
                    _colonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ColonTokenStr
        {
            get
            {
                if (_colonTokenIsChanged) return _colonTokenStr;
                return _colonTokenStr = _colonToken.Text;
            }
            set
            {
                if (_colonTokenStr != value)
                {
                    _colonTokenStr = value;
                    IsChanged = true;
                    _colonTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _keyword = ((SwitchLabelSyntax) Node).Keyword;
            _keywordIsChanged = false;
            _colonToken = ((SwitchLabelSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("KeywordStr", KeywordStr);
            yield return ("ColonTokenStr", ColonTokenStr);
        }
    }
}