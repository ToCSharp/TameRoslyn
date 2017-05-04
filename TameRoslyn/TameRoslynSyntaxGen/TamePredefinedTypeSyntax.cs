// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TamePredefinedTypeSyntax : TameTypeSyntax
    {
        public new static string TypeName = "PredefinedTypeSyntax";
        private SyntaxToken _keyword;
        private bool _keywordIsChanged;
        private string _keywordStr;

        public TamePredefinedTypeSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParsePredefinedType(code);
            AddChildren();
        }

        public TamePredefinedTypeSyntax(PredefinedTypeSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TamePredefinedTypeSyntax()
        {
            KeywordStr = DefaultValues.PredefinedTypeSyntaxKeywordStr;
            IsVar = DefaultValues.PredefinedTypeSyntaxIsVar;
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

        public override void Clear()
        {
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _keyword = ((PredefinedTypeSyntax) Node).Keyword;
            _keywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.PredefinedType(Keyword);
// if (IsVar != null) res = res.WithIsVar(IsVar);
            IsChanged = false;
            return res;
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
            yield return ("IsVar", IsVar.ToString());
        }
    }
}