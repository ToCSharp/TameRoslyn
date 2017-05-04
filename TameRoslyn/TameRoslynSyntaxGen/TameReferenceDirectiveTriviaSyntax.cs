// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameReferenceDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "ReferenceDirectiveTriviaSyntax";
        private SyntaxToken _file;
        private bool _fileIsChanged;
        private string _fileStr;
        private SyntaxToken _referenceKeyword;
        private bool _referenceKeywordIsChanged;
        private string _referenceKeywordStr;

        public TameReferenceDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseReferenceDirectiveTrivia(code);
            AddChildren();
        }

        public TameReferenceDirectiveTriviaSyntax(ReferenceDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameReferenceDirectiveTriviaSyntax()
        {
            // ReferenceKeywordStr = DefaultValues.ReferenceDirectiveTriviaSyntaxReferenceKeywordStr;
            // FileStr = DefaultValues.ReferenceDirectiveTriviaSyntaxFileStr;
            // DirectiveNameTokenStr = DefaultValues.ReferenceDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.ReferenceDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.ReferenceDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.ReferenceDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ReferenceKeyword
        {
            get
            {
                if (_referenceKeywordIsChanged)
                {
                    if (_referenceKeywordStr == null) _referenceKeyword = default(SyntaxToken);
                    else
                        _referenceKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_referenceKeywordStr, SyntaxKind.ReferenceKeyword);
                    _referenceKeywordIsChanged = false;
                }
                return _referenceKeyword;
            }
            set
            {
                if (_referenceKeyword != value)
                {
                    _referenceKeyword = value;
                    _referenceKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ReferenceKeywordStr
        {
            get
            {
                if (_referenceKeywordIsChanged) return _referenceKeywordStr;
                return _referenceKeywordStr = _referenceKeyword.Text;
            }
            set
            {
                if (_referenceKeywordStr != value)
                {
                    _referenceKeywordStr = value;
                    IsChanged = true;
                    _referenceKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken File
        {
            get
            {
                if (_fileIsChanged)
                {
                    _file = SyntaxFactoryStr.ParseSyntaxToken(FileStr);
                    _fileIsChanged = false;
                }
                return _file;
            }
            set
            {
                if (_file != value)
                {
                    _file = value;
                    _fileIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string FileStr
        {
            get
            {
                if (_fileIsChanged) return _fileStr;
                return _fileStr = _file.Text;
            }
            set
            {
                if (_fileStr != value)
                {
                    _fileStr = value;
                    IsChanged = true;
                    _fileIsChanged = true;
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
            _referenceKeyword = ((ReferenceDirectiveTriviaSyntax) Node).ReferenceKeyword;
            _referenceKeywordIsChanged = false;
            _file = ((ReferenceDirectiveTriviaSyntax) Node).File;
            _fileIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ReferenceDirectiveTrivia(HashToken, ReferenceKeyword, File, EndOfDirectiveToken,
                IsActive);
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
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ReferenceKeywordStr", ReferenceKeywordStr);
            yield return ("FileStr", FileStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}