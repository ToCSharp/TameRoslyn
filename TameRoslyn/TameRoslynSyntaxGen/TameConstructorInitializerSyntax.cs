// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameConstructorInitializerSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "ConstructorInitializerSyntax";
        private ArgumentListSyntax _argumentList;
        private bool _argumentListIsChanged;
        private string _argumentListStr;
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private TameArgumentListSyntax _taArgumentList;
        private SyntaxToken _thisOrBaseKeyword;
        private bool _thisOrBaseKeywordIsChanged;
        private string _thisOrBaseKeywordStr;

        public TameConstructorInitializerSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseConstructorInitializer(code);
            AddChildren();
        }

        public TameConstructorInitializerSyntax(ConstructorInitializerSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameConstructorInitializerSyntax()
        {
            ColonTokenStr = DefaultValues.ConstructorInitializerSyntaxColonTokenStr;
            ThisOrBaseKeywordStr = DefaultValues.ConstructorInitializerSyntaxThisOrBaseKeywordStr;
            ArgumentListStr = DefaultValues.ConstructorInitializerSyntaxArgumentListStr;
        }

        public override string RoslynTypeName => TypeName;

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

        public SyntaxToken ThisOrBaseKeyword
        {
            get
            {
                if (_thisOrBaseKeywordIsChanged)
                {
                    _thisOrBaseKeyword = SyntaxFactoryStr.ParseSyntaxToken(ThisOrBaseKeywordStr);
                    _thisOrBaseKeywordIsChanged = false;
                }
                return _thisOrBaseKeyword;
            }
            set
            {
                if (_thisOrBaseKeyword != value)
                {
                    _thisOrBaseKeyword = value;
                    _thisOrBaseKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ThisOrBaseKeywordStr
        {
            get
            {
                if (_thisOrBaseKeywordIsChanged) return _thisOrBaseKeywordStr;
                return _thisOrBaseKeywordStr = _thisOrBaseKeyword.Text;
            }
            set
            {
                if (_thisOrBaseKeywordStr != value)
                {
                    _thisOrBaseKeywordStr = value;
                    IsChanged = true;
                    _thisOrBaseKeywordIsChanged = true;
                }
            }
        }

        public ArgumentListSyntax ArgumentList
        {
            get
            {
                if (_argumentListIsChanged)
                {
                    _argumentList = SyntaxFactoryStr.ParseArgumentListSyntax(ArgumentListStr);
                    _argumentListIsChanged = false;
                    _taArgumentList = null;
                }
                else if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    _argumentList = (ArgumentListSyntax) _taArgumentList.Node;
                }
                return _argumentList;
            }
            set
            {
                if (_argumentList != value)
                {
                    _argumentList = value;
                    _argumentListIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ArgumentListStr
        {
            get
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                    ArgumentList = (ArgumentListSyntax) _taArgumentList.Node;
                if (_argumentListIsChanged) return _argumentListStr;
                return _argumentListStr = _argumentList?.ToFullString();
            }
            set
            {
                if (_taArgumentList != null && _taArgumentList.IsChanged)
                {
                    ArgumentList = (ArgumentListSyntax) _taArgumentList.Node;
                    _argumentListStr = _argumentList?.ToFullString();
                }
                if (_argumentListStr != value)
                {
                    _argumentListStr = value;
                    IsChanged = true;
                    _argumentListIsChanged = true;
                    _taArgumentList = null;
                }
            }
        }

        public TameArgumentListSyntax TaArgumentList
        {
            get
            {
                if (_taArgumentList == null && ArgumentList != null)
                {
                    _taArgumentList = new TameArgumentListSyntax(ArgumentList) {TaParent = this};
                    _taArgumentList.AddChildren();
                }
                return _taArgumentList;
            }
            set
            {
                if (_taArgumentList != value)
                {
                    _taArgumentList = value;
                    if (_taArgumentList != null)
                    {
                        _taArgumentList.TaParent = this;
                        _taArgumentList.IsChanged = true;
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
            _taArgumentList = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _colonToken = ((ConstructorInitializerSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
            _thisOrBaseKeyword = ((ConstructorInitializerSyntax) Node).ThisOrBaseKeyword;
            _thisOrBaseKeywordIsChanged = false;
            _argumentList = ((ConstructorInitializerSyntax) Node).ArgumentList;
            _argumentListIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
        }

        public SyntaxKind GetKind()
        {
            if (Kind != SyntaxKind.None) return Kind;
            if (ThisOrBaseKeywordStr.Contains("this")) return SyntaxKind.ThisConstructorInitializer;
            if (ThisOrBaseKeywordStr.Contains("base")) return SyntaxKind.BaseConstructorInitializer;
            throw new NotImplementedException();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.ConstructorInitializer(GetKind(), ColonToken, ThisOrBaseKeyword, ArgumentList);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaArgumentList != null) yield return TaArgumentList;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ColonTokenStr", ColonTokenStr);
            yield return ("ThisOrBaseKeywordStr", ThisOrBaseKeywordStr);
            yield return ("ArgumentListStr", ArgumentListStr);
        }
    }
}