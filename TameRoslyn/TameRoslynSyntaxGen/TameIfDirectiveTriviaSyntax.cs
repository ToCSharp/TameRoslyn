// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameIfDirectiveTriviaSyntax : TameConditionalDirectiveTriviaSyntax
    {
        public new static string TypeName = "IfDirectiveTriviaSyntax";
        private SyntaxToken _ifKeyword;
        private bool _ifKeywordIsChanged;
        private string _ifKeywordStr;

        public TameIfDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseIfDirectiveTrivia(code);
            AddChildren();
        }

        public TameIfDirectiveTriviaSyntax(IfDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameIfDirectiveTriviaSyntax()
        {
            // IfKeywordStr = DefaultValues.IfDirectiveTriviaSyntaxIfKeywordStr;
            // ConditionStr = DefaultValues.IfDirectiveTriviaSyntaxConditionStr;
            // ConditionValue = DefaultValues.IfDirectiveTriviaSyntaxConditionValue;
            // BranchTaken = DefaultValues.IfDirectiveTriviaSyntaxBranchTaken;
            // DirectiveNameTokenStr = DefaultValues.IfDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.IfDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.IfDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.IfDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken IfKeyword
        {
            get
            {
                if (_ifKeywordIsChanged)
                {
                    if (_ifKeywordStr == null) _ifKeyword = default(SyntaxToken);
                    else _ifKeyword = SyntaxFactoryStr.ParseSyntaxToken(_ifKeywordStr, SyntaxKind.IfKeyword);
                    _ifKeywordIsChanged = false;
                }
                return _ifKeyword;
            }
            set
            {
                if (_ifKeyword != value)
                {
                    _ifKeyword = value;
                    _ifKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IfKeywordStr
        {
            get
            {
                if (_ifKeywordIsChanged) return _ifKeywordStr;
                return _ifKeywordStr = _ifKeyword.Text;
            }
            set
            {
                if (_ifKeywordStr != value)
                {
                    _ifKeywordStr = value;
                    IsChanged = true;
                    _ifKeywordIsChanged = true;
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
            _ifKeyword = ((IfDirectiveTriviaSyntax) Node).IfKeyword;
            _ifKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.IfDirectiveTrivia(HashToken, IfKeyword, Condition, EndOfDirectiveToken, IsActive,
                BranchTaken, ConditionValue);
// if (DirectiveNameToken != null) res = res.WithDirectiveNameToken(DirectiveNameToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaCondition != null) yield return TaCondition;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IfKeywordStr", IfKeywordStr);
            yield return ("ConditionStr", ConditionStr);
            yield return ("ConditionValue", ConditionValue.ToString());
            yield return ("BranchTaken", BranchTaken.ToString());
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}