// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TamePragmaChecksumDirectiveTriviaSyntax : TameDirectiveTriviaSyntax
    {
        public new static string TypeName = "PragmaChecksumDirectiveTriviaSyntax";
        private SyntaxToken _bytes;
        private bool _bytesIsChanged;
        private string _bytesStr;
        private SyntaxToken _checksumKeyword;
        private bool _checksumKeywordIsChanged;
        private string _checksumKeywordStr;
        private SyntaxToken _file;
        private bool _fileIsChanged;
        private string _fileStr;
        private SyntaxToken _guid;
        private bool _guidIsChanged;
        private string _guidStr;
        private SyntaxToken _pragmaKeyword;
        private bool _pragmaKeywordIsChanged;
        private string _pragmaKeywordStr;

        public TamePragmaChecksumDirectiveTriviaSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParsePragmaChecksumDirectiveTrivia(code);
            AddChildren();
        }

        public TamePragmaChecksumDirectiveTriviaSyntax(PragmaChecksumDirectiveTriviaSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TamePragmaChecksumDirectiveTriviaSyntax()
        {
            // PragmaKeywordStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxPragmaKeywordStr;
            // ChecksumKeywordStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxChecksumKeywordStr;
            // FileStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxFileStr;
            // GuidStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxGuidStr;
            // BytesStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxBytesStr;
            // DirectiveNameTokenStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxDirectiveNameTokenStr;
            // HashTokenStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxHashTokenStr;
            // EndOfDirectiveTokenStr = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxEndOfDirectiveTokenStr;
            // IsActive = DefaultValues.PragmaChecksumDirectiveTriviaSyntaxIsActive;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken PragmaKeyword
        {
            get
            {
                if (_pragmaKeywordIsChanged)
                {
                    if (_pragmaKeywordStr == null) _pragmaKeyword = default(SyntaxToken);
                    else
                        _pragmaKeyword = SyntaxFactoryStr.ParseSyntaxToken(_pragmaKeywordStr, SyntaxKind.PragmaKeyword);
                    _pragmaKeywordIsChanged = false;
                }
                return _pragmaKeyword;
            }
            set
            {
                if (_pragmaKeyword != value)
                {
                    _pragmaKeyword = value;
                    _pragmaKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string PragmaKeywordStr
        {
            get
            {
                if (_pragmaKeywordIsChanged) return _pragmaKeywordStr;
                return _pragmaKeywordStr = _pragmaKeyword.Text;
            }
            set
            {
                if (_pragmaKeywordStr != value)
                {
                    _pragmaKeywordStr = value;
                    IsChanged = true;
                    _pragmaKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken ChecksumKeyword
        {
            get
            {
                if (_checksumKeywordIsChanged)
                {
                    if (_checksumKeywordStr == null) _checksumKeyword = default(SyntaxToken);
                    else
                        _checksumKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_checksumKeywordStr, SyntaxKind.ChecksumKeyword);
                    _checksumKeywordIsChanged = false;
                }
                return _checksumKeyword;
            }
            set
            {
                if (_checksumKeyword != value)
                {
                    _checksumKeyword = value;
                    _checksumKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ChecksumKeywordStr
        {
            get
            {
                if (_checksumKeywordIsChanged) return _checksumKeywordStr;
                return _checksumKeywordStr = _checksumKeyword.Text;
            }
            set
            {
                if (_checksumKeywordStr != value)
                {
                    _checksumKeywordStr = value;
                    IsChanged = true;
                    _checksumKeywordIsChanged = true;
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

        public SyntaxToken Guid
        {
            get
            {
                if (_guidIsChanged)
                {
                    _guid = SyntaxFactoryStr.ParseSyntaxToken(GuidStr);
                    _guidIsChanged = false;
                }
                return _guid;
            }
            set
            {
                if (_guid != value)
                {
                    _guid = value;
                    _guidIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string GuidStr
        {
            get
            {
                if (_guidIsChanged) return _guidStr;
                return _guidStr = _guid.Text;
            }
            set
            {
                if (_guidStr != value)
                {
                    _guidStr = value;
                    IsChanged = true;
                    _guidIsChanged = true;
                }
            }
        }

        public SyntaxToken Bytes
        {
            get
            {
                if (_bytesIsChanged)
                {
                    _bytes = SyntaxFactoryStr.ParseSyntaxToken(BytesStr);
                    _bytesIsChanged = false;
                }
                return _bytes;
            }
            set
            {
                if (_bytes != value)
                {
                    _bytes = value;
                    _bytesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string BytesStr
        {
            get
            {
                if (_bytesIsChanged) return _bytesStr;
                return _bytesStr = _bytes.Text;
            }
            set
            {
                if (_bytesStr != value)
                {
                    _bytesStr = value;
                    IsChanged = true;
                    _bytesIsChanged = true;
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
            _pragmaKeyword = ((PragmaChecksumDirectiveTriviaSyntax) Node).PragmaKeyword;
            _pragmaKeywordIsChanged = false;
            _checksumKeyword = ((PragmaChecksumDirectiveTriviaSyntax) Node).ChecksumKeyword;
            _checksumKeywordIsChanged = false;
            _file = ((PragmaChecksumDirectiveTriviaSyntax) Node).File;
            _fileIsChanged = false;
            _guid = ((PragmaChecksumDirectiveTriviaSyntax) Node).Guid;
            _guidIsChanged = false;
            _bytes = ((PragmaChecksumDirectiveTriviaSyntax) Node).Bytes;
            _bytesIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.PragmaChecksumDirectiveTrivia(HashToken, PragmaKeyword, ChecksumKeyword, File, Guid,
                Bytes, EndOfDirectiveToken, IsActive);
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
            yield return ("PragmaKeywordStr", PragmaKeywordStr);
            yield return ("ChecksumKeywordStr", ChecksumKeywordStr);
            yield return ("FileStr", FileStr);
            yield return ("GuidStr", GuidStr);
            yield return ("BytesStr", BytesStr);
            yield return ("DirectiveNameTokenStr", DirectiveNameTokenStr);
            yield return ("HashTokenStr", HashTokenStr);
            yield return ("EndOfDirectiveTokenStr", EndOfDirectiveTokenStr);
            yield return ("IsActive", IsActive.ToString());
        }
    }
}