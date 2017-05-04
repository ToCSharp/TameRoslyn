// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameElifDirectiveTriviaSyntax : TameConditionalDirectiveTriviaSyntax
    {
        public new static string TypeName = "ElifDirectiveTriviaSyntax";
        private SyntaxToken _elifKeyword;
        private bool _elifKeywordIsChanged;
        private string _elifKeywordStr;

        public TameElifDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseElifDirectiveTrivia(code);
            AddChildren();
        }

        public TameElifDirectiveTriviaSyntax(ElifDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameElifDirectiveTriviaSyntax()
        {
            // ElifKeywordStr = DefaultValues.ElifDirectiveTriviaSyntaxElifKeywordStr;
            // ConditionStr = DefaultValues.ElifDirectiveTriviaSyntaxConditionStr;
            // ConditionValue = DefaultValues.ElifDirectiveTriviaSyntaxConditionValue;
            // BranchTaken = DefaultValues.ElifDirectiveTriviaSyntaxBranchTaken;
            // DirectiveNameTokenStr = DefaultValues.ElifDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.ElifDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.ElifDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.ElifDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ElifKeyword
        {
            get
            {
                if (_elifKeywordIsChanged)
                {
                    if (_elifKeywordStr == null) _elifKeyword = default(SyntaxToken);
                    else _elifKeyword = SyntaxFactoryStr.ParseSyntaxToken(_elifKeywordStr, SyntaxKind.ElifKeyword);
                    _elifKeywordIsChanged = false;
                }
                return _elifKeyword;
            }
            set
            {
                if (_elifKeyword != value)
                {
                    _elifKeyword = value;
                    _elifKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ElifKeywordStr
        {
            get
            {
                if (_elifKeywordIsChanged) return _elifKeywordStr;
                return _elifKeywordStr = _elifKeyword.Text;
            }
            set
            {
                if (_elifKeywordStr != value)
                {
                    _elifKeywordStr = value;
                    IsChanged = true;
                    _elifKeywordIsChanged = true;
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
            _elifKeyword = ((ElifDirectiveTriviaSyntax) Node).ElifKeyword;
            _elifKeywordIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ElifDirectiveTrivia(HashToken, ElifKeyword, Condition, EndOfDirectiveToken,
                IsActive, BranchTaken, ConditionValue);
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
            yield return ("ElifKeywordStr", ElifKeywordStr);
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