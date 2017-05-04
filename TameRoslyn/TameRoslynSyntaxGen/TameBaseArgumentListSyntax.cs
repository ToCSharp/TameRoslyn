// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameBaseArgumentListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "BaseArgumentListSyntax";
        private SeparatedSyntaxList<ArgumentSyntax> _arguments;
        private int _argumentsCount;
        private bool _argumentsIsChanged;
        private string _argumentsStr;
        private List<TameArgumentSyntax> _taArguments;

        public TameBaseArgumentListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBaseArgumentList(code);
            AddChildren();
        }

        public TameBaseArgumentListSyntax(BaseArgumentListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBaseArgumentListSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;
        public bool TaArgumentsIsChanged { get; set; }

        public SeparatedSyntaxList<ArgumentSyntax> Arguments
        {
            get
            {
                if (TaArgumentsIsChanged || _taArguments != null &&
                    (_taArguments.Count != _argumentsCount || _taArguments.Any(v => v.IsChanged)))
                {
                    _arguments = SyntaxFactory.SeparatedList(TaArguments?.Select(v => v.Node).Cast<ArgumentSyntax>());
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
                    Arguments = new SeparatedSyntaxList<ArgumentSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameArgumentSyntax> TaArguments
        {
            get
            {
                if (_taArguments == null)
                {
                    _taArguments = new List<TameArgumentSyntax>();
                    foreach (var item in _arguments)
                        _taArguments.Add(new TameArgumentSyntax(item) {TaParent = this});
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

        public override void Clear()
        {
            _taArguments = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _arguments = ((BaseArgumentListSyntax) Node).Arguments;
            _argumentsIsChanged = false;
            _argumentsCount = _arguments.Count;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaArguments)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
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
            yield return ("ArgumentsStr", ArgumentsStr);
        }
    }
}