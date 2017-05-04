// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameLoadDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "LoadDirectiveTriviaSyntax";
        private SyntaxToken _file;
        private bool _fileIsChanged;
        private string _fileStr;
        private SyntaxToken _loadKeyword;
        private bool _loadKeywordIsChanged;
        private string _loadKeywordStr;

        public TameLoadDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseLoadDirectiveTrivia(code);
            AddChildren();
        }

        public TameLoadDirectiveTriviaSyntax(LoadDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameLoadDirectiveTriviaSyntax()
        {
            // LoadKeywordStr = DefaultValues.LoadDirectiveTriviaSyntaxLoadKeywordStr;
            // FileStr = DefaultValues.LoadDirectiveTriviaSyntaxFileStr;
            // DirectiveNameTokenStr = DefaultValues.LoadDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.LoadDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.LoadDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.LoadDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LoadKeyword
        {
            get
            {
                if (_loadKeywordIsChanged)
                {
                    if (_loadKeywordStr == null) _loadKeyword = default(SyntaxToken);
                    else _loadKeyword = SyntaxFactoryStr.ParseSyntaxToken(_loadKeywordStr, SyntaxKind.LoadKeyword);
                    _loadKeywordIsChanged = false;
                }
                return _loadKeyword;
            }
            set
            {
                if (_loadKeyword != value)
                {
                    _loadKeyword = value;
                    _loadKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LoadKeywordStr
        {
            get
            {
                if (_loadKeywordIsChanged) return _loadKeywordStr;
                return _loadKeywordStr = _loadKeyword.Text;
            }
            set
            {
                if (_loadKeywordStr != value)
                {
                    _loadKeywordStr = value;
                    IsChanged = true;
                    _loadKeywordIsChanged = true;
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
            _loadKeyword = ((LoadDirectiveTriviaSyntax) Node).LoadKeyword;
            _loadKeywordIsChanged = false;
            _file = ((LoadDirectiveTriviaSyntax) Node).File;
            _fileIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.LoadDirectiveTrivia(HashToken, LoadKeyword, File, EndOfDirectiveToken, IsActive);
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
            yield return ("LoadKeywordStr", LoadKeywordStr);
            yield return ("FileStr", FileStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}