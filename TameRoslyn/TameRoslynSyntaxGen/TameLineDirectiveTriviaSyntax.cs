// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameLineDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "LineDirectiveTriviaSyntax";
        private SyntaxToken _file;
        private bool _fileIsChanged;
        private string _fileStr;
        private SyntaxToken _line;
        private bool _lineIsChanged;
        private SyntaxToken _lineKeyword;
        private bool _lineKeywordIsChanged;
        private string _lineKeywordStr;
        private string _lineStr;

        public TameLineDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseLineDirectiveTrivia(code);
            AddChildren();
        }

        public TameLineDirectiveTriviaSyntax(LineDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameLineDirectiveTriviaSyntax()
        {
            // LineKeywordStr = DefaultValues.LineDirectiveTriviaSyntaxLineKeywordStr;
            // LineStr = DefaultValues.LineDirectiveTriviaSyntaxLineStr;
            // FileStr = DefaultValues.LineDirectiveTriviaSyntaxFileStr;
            // DirectiveNameTokenStr = DefaultValues.LineDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.LineDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.LineDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.LineDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LineKeyword
        {
            get
            {
                if (_lineKeywordIsChanged)
                {
                    if (_lineKeywordStr == null) _lineKeyword = default(SyntaxToken);
                    else _lineKeyword = SyntaxFactoryStr.ParseSyntaxToken(_lineKeywordStr, SyntaxKind.LineKeyword);
                    _lineKeywordIsChanged = false;
                }
                return _lineKeyword;
            }
            set
            {
                if (_lineKeyword != value)
                {
                    _lineKeyword = value;
                    _lineKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LineKeywordStr
        {
            get
            {
                if (_lineKeywordIsChanged) return _lineKeywordStr;
                return _lineKeywordStr = _lineKeyword.Text;
            }
            set
            {
                if (_lineKeywordStr != value)
                {
                    _lineKeywordStr = value;
                    IsChanged = true;
                    _lineKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken Line
        {
            get
            {
                if (_lineIsChanged)
                {
                    _line = SyntaxFactoryStr.ParseSyntaxToken(LineStr);
                    _lineIsChanged = false;
                }
                return _line;
            }
            set
            {
                if (_line != value)
                {
                    _line = value;
                    _lineIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LineStr
        {
            get
            {
                if (_lineIsChanged) return _lineStr;
                return _lineStr = _line.Text;
            }
            set
            {
                if (_lineStr != value)
                {
                    _lineStr = value;
                    IsChanged = true;
                    _lineIsChanged = true;
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
            _lineKeyword = ((LineDirectiveTriviaSyntax) Node).LineKeyword;
            _lineKeywordIsChanged = false;
            _line = ((LineDirectiveTriviaSyntax) Node).Line;
            _lineIsChanged = false;
            _file = ((LineDirectiveTriviaSyntax) Node).File;
            _fileIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.LineDirectiveTrivia(HashToken, LineKeyword, Line, File, EndOfDirectiveToken,
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
            yield return ("LineKeywordStr", LineKeywordStr);
            yield return ("LineStr", LineStr);
            yield return ("FileStr", FileStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}