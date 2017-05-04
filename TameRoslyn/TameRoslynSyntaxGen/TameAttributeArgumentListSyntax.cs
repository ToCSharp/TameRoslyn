// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameAttributeArgumentListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "AttributeArgumentListSyntax";
        private SeparatedSyntaxList<AttributeArgumentSyntax> _arguments;
        private int _argumentsCount;
        private bool _argumentsIsChanged;
        private string _argumentsStr;
        private SyntaxToken _closeParenToken;
        private bool _closeParenTokenIsChanged;
        private string _closeParenTokenStr;
        private SyntaxToken _openParenToken;
        private bool _openParenTokenIsChanged;
        private string _openParenTokenStr;
        private List<TameAttributeArgumentSyntax> _taArguments;

        public TameAttributeArgumentListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseAttributeArgumentList(code);
            AddChildren();
        }

        public TameAttributeArgumentListSyntax(AttributeArgumentListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameAttributeArgumentListSyntax()
        {
            OpenParenTokenStr = DefaultValues.AttributeArgumentListSyntaxOpenParenTokenStr;
            ArgumentsStr = DefaultValues.AttributeArgumentListSyntaxArgumentsStr;
            CloseParenTokenStr = DefaultValues.AttributeArgumentListSyntaxCloseParenTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OpenParenToken
        {
            get
            {
                if (_openParenTokenIsChanged)
                {
                    if (_openParenTokenStr == null) _openParenToken = default(SyntaxToken);
                    else
                        _openParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_openParenTokenStr, SyntaxKind.OpenParenToken);
                    _openParenTokenIsChanged = false;
                }
                return _openParenToken;
            }
            set
            {
                if (_openParenToken != value)
                {
                    _openParenToken = value;
                    _openParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OpenParenTokenStr
        {
            get
            {
                if (_openParenTokenIsChanged) return _openParenTokenStr;
                return _openParenTokenStr = _openParenToken.Text;
            }
            set
            {
                if (_openParenTokenStr != value)
                {
                    _openParenTokenStr = value;
                    IsChanged = true;
                    _openParenTokenIsChanged = true;
                }
            }
        }

        public bool TaArgumentsIsChanged { get; set; }

        public SeparatedSyntaxList<AttributeArgumentSyntax> Arguments
        {
            get
            {
                if (TaArgumentsIsChanged || _taArguments != null &&
                    (_taArguments.Count != _argumentsCount || _taArguments.Any(v => v.IsChanged)))
                {
                    _arguments =
                        SyntaxFactory.SeparatedList(TaArguments?.Select(v => v.Node).Cast<AttributeArgumentSyntax>());
                    TaArgumentsIsChanged = false;
                }
                return _arguments;
            }
            set
            {
                if (_arguments != value)
                {
                    _arguments = value;
                    TaArgumentsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ArgumentsStr
        {
            get
            {
                if (_argumentsIsChanged) return _argumentsStr;
                return _argumentsStr = string.Join(", ", _arguments.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _argumentsStr = value;
                    Arguments = new SeparatedSyntaxList<AttributeArgumentSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameAttributeArgumentSyntax> TaArguments
        {
            get
            {
                if (_taArguments == null)
                {
                    _taArguments = new List<TameAttributeArgumentSyntax>();
                    foreach (var item in _arguments)
                        _taArguments.Add(new TameAttributeArgumentSyntax(item) {TaParent = this});
                }
                return _taArguments;
            }
            set
            {
                if (_taArguments != value)
                {
                    _taArguments = value;
                    _taArguments?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaArgumentsIsChanged = true;
                }
            }
        }

        public SyntaxToken CloseParenToken
        {
            get
            {
                if (_closeParenTokenIsChanged)
                {
                    if (_closeParenTokenStr == null) _closeParenToken = default(SyntaxToken);
                    else
                        _closeParenToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_closeParenTokenStr, SyntaxKind.CloseParenToken);
                    _closeParenTokenIsChanged = false;
                }
                return _closeParenToken;
            }
            set
            {
                if (_closeParenToken != value)
                {
                    _closeParenToken = value;
                    _closeParenTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string CloseParenTokenStr
        {
            get
            {
                if (_closeParenTokenIsChanged) return _closeParenTokenStr;
                return _closeParenTokenStr = _closeParenToken.Text;
            }
            set
            {
                if (_closeParenTokenStr != value)
                {
                    _closeParenTokenStr = value;
                    IsChanged = true;
                    _closeParenTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taArguments = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _openParenToken = ((AttributeArgumentListSyntax) Node).OpenParenToken;
            _openParenTokenIsChanged = false;
            _arguments = ((AttributeArgumentListSyntax) Node).Arguments;
            _argumentsIsChanged = false;
            _argumentsCount = _arguments.Count;
            _closeParenToken = ((AttributeArgumentListSyntax) Node).CloseParenToken;
            _closeParenTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaArguments)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.AttributeArgumentList(OpenParenToken, Arguments, CloseParenToken);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaArguments)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("OpenParenTokenStr", OpenParenTokenStr);
            yield return ("ArgumentsStr", ArgumentsStr);
            yield return ("CloseParenTokenStr", CloseParenTokenStr);
        }

        public TameAttributeArgumentListSyntax AddArgument(TameAttributeArgumentSyntax item)
        {
            item.TaParent = this;
            TaArguments.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}