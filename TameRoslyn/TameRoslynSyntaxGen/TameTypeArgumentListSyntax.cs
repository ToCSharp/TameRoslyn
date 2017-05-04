// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameTypeArgumentListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "TypeArgumentListSyntax";
        private SeparatedSyntaxList<TypeSyntax> _arguments;
        private int _argumentsCount;
        private bool _argumentsIsChanged;
        private string _argumentsStr;
        private SyntaxToken _greaterThanToken;
        private bool _greaterThanTokenIsChanged;
        private string _greaterThanTokenStr;
        private SyntaxToken _lessThanToken;
        private bool _lessThanTokenIsChanged;
        private string _lessThanTokenStr;
        private List<TameTypeSyntax> _taArguments;

        public TameTypeArgumentListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTypeArgumentList(code);
            AddChildren();
        }

        public TameTypeArgumentListSyntax(TypeArgumentListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTypeArgumentListSyntax()
        {
            LessThanTokenStr = DefaultValues.TypeArgumentListSyntaxLessThanTokenStr;
            ArgumentsStr = DefaultValues.TypeArgumentListSyntaxArgumentsStr;
            GreaterThanTokenStr = DefaultValues.TypeArgumentListSyntaxGreaterThanTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken LessThanToken
        {
            get
            {
                if (_lessThanTokenIsChanged)
                {
                    if (_lessThanTokenStr == null) _lessThanToken = default(SyntaxToken);
                    else
                        _lessThanToken = SyntaxFactoryStr.ParseSyntaxToken(_lessThanTokenStr, SyntaxKind.LessThanToken);
                    _lessThanTokenIsChanged = false;
                }
                return _lessThanToken;
            }
            set
            {
                if (_lessThanToken != value)
                {
                    _lessThanToken = value;
                    _lessThanTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string LessThanTokenStr
        {
            get
            {
                if (_lessThanTokenIsChanged) return _lessThanTokenStr;
                return _lessThanTokenStr = _lessThanToken.Text;
            }
            set
            {
                if (_lessThanTokenStr != value)
                {
                    _lessThanTokenStr = value;
                    IsChanged = true;
                    _lessThanTokenIsChanged = true;
                }
            }
        }

        public bool TaArgumentsIsChanged { get; set; }

        public SeparatedSyntaxList<TypeSyntax> Arguments
        {
            get
            {
                if (TaArgumentsIsChanged || _taArguments != null &&
                    (_taArguments.Count != _argumentsCount || _taArguments.Any(v => v.IsChanged)))
                {
                    _arguments = SyntaxFactory.SeparatedList(TaArguments?.Select(v => v.Node).Cast<TypeSyntax>());
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
                    Arguments = new SeparatedSyntaxList<TypeSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameTypeSyntax> TaArguments
        {
            get
            {
                if (_taArguments == null)
                {
                    _taArguments = new List<TameTypeSyntax>();
                    foreach (var item in _arguments)
                        if (item is IdentifierNameSyntax)
                            _taArguments.Add(
                                new TameIdentifierNameSyntax(item as IdentifierNameSyntax) {TaParent = this});
                        else if (item is GenericNameSyntax)
                            _taArguments.Add(new TameGenericNameSyntax(item as GenericNameSyntax) {TaParent = this});
                        else if (item is AliasQualifiedNameSyntax)
                            _taArguments.Add(
                                new TameAliasQualifiedNameSyntax(item as AliasQualifiedNameSyntax) {TaParent = this});
                        else if (item is QualifiedNameSyntax)
                            _taArguments.Add(
                                new TameQualifiedNameSyntax(item as QualifiedNameSyntax) {TaParent = this});
                        else if (item is OmittedTypeArgumentSyntax)
                            _taArguments.Add(
                                new TameOmittedTypeArgumentSyntax(item as OmittedTypeArgumentSyntax) {TaParent = this});
                        else if (item is PredefinedTypeSyntax)
                            _taArguments.Add(
                                new TamePredefinedTypeSyntax(item as PredefinedTypeSyntax) {TaParent = this});
                        else if (item is NullableTypeSyntax)
                            _taArguments.Add(new TameNullableTypeSyntax(item as NullableTypeSyntax) {TaParent = this});
                        else if (item is PointerTypeSyntax)
                            _taArguments.Add(new TamePointerTypeSyntax(item as PointerTypeSyntax) {TaParent = this});
                        else if (item is ArrayTypeSyntax)
                            _taArguments.Add(new TameArrayTypeSyntax(item as ArrayTypeSyntax) {TaParent = this});
                        else if (item is TupleTypeSyntax)
                            _taArguments.Add(new TameTupleTypeSyntax(item as TupleTypeSyntax) {TaParent = this});
                        else if (item is RefTypeSyntax)
                            _taArguments.Add(new TameRefTypeSyntax(item as RefTypeSyntax) {TaParent = this});
                        else if (item is TypeSyntax)
                            _taArguments.Add(new TameTypeSyntax(item) {TaParent = this});
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

        public SyntaxToken GreaterThanToken
        {
            get
            {
                if (_greaterThanTokenIsChanged)
                {
                    if (_greaterThanTokenStr == null) _greaterThanToken = default(SyntaxToken);
                    else
                        _greaterThanToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_greaterThanTokenStr, SyntaxKind.GreaterThanToken);
                    _greaterThanTokenIsChanged = false;
                }
                return _greaterThanToken;
            }
            set
            {
                if (_greaterThanToken != value)
                {
                    _greaterThanToken = value;
                    _greaterThanTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string GreaterThanTokenStr
        {
            get
            {
                if (_greaterThanTokenIsChanged) return _greaterThanTokenStr;
                return _greaterThanTokenStr = _greaterThanToken.Text;
            }
            set
            {
                if (_greaterThanTokenStr != value)
                {
                    _greaterThanTokenStr = value;
                    IsChanged = true;
                    _greaterThanTokenIsChanged = true;
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
            _lessThanToken = ((TypeArgumentListSyntax) Node).LessThanToken;
            _lessThanTokenIsChanged = false;
            _arguments = ((TypeArgumentListSyntax) Node).Arguments;
            _argumentsIsChanged = false;
            _argumentsCount = _arguments.Count;
            _greaterThanToken = ((TypeArgumentListSyntax) Node).GreaterThanToken;
            _greaterThanTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaArguments)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TypeArgumentList(LessThanToken, Arguments, GreaterThanToken);
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
            yield return ("LessThanTokenStr", LessThanTokenStr);
            yield return ("ArgumentsStr", ArgumentsStr);
            yield return ("GreaterThanTokenStr", GreaterThanTokenStr);
        }

        public TameTypeArgumentListSyntax AddArgument(TameTypeSyntax item)
        {
            item.TaParent = this;
            TaArguments.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}