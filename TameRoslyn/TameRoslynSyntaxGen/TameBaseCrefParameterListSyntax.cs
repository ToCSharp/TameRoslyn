// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public class TameBaseCrefParameterListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "BaseCrefParameterListSyntax";
        private SeparatedSyntaxList<CrefParameterSyntax> _parameters;
        private int _parametersCount;
        private bool _parametersIsChanged;
        private string _parametersStr;
        private List<TameCrefParameterSyntax> _taParameters;

        public TameBaseCrefParameterListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseBaseCrefParameterList(code);
            AddChildren();
        }

        public TameBaseCrefParameterListSyntax(BaseCrefParameterListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameBaseCrefParameterListSyntax()
        {
        }

        public override string RoslynTypeName => TypeName;
        public bool TaParametersIsChanged { get; set; }

        public SeparatedSyntaxList<CrefParameterSyntax> Parameters
        {
            get
            {
                if (TaParametersIsChanged || _taParameters != null &&
                    (_taParameters.Count != _parametersCount || _taParameters.Any(v => v.IsChanged)))
                {
                    _parameters =
                        SyntaxFactory.SeparatedList(TaParameters?.Select(v => v.Node).Cast<CrefParameterSyntax>());
                    TaParametersIsChanged = false;
                }
                return _parameters;
            }
            set
            {
                if (_parameters != value)
                {
                    _parameters = value;
                    TaParametersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ParametersStr
        {
            get
            {
                if (_parametersIsChanged) return _parametersStr;
                return _parametersStr = string.Join(", ", _parameters.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _parametersStr = value;
                    Parameters = new SeparatedSyntaxList<CrefParameterSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameCrefParameterSyntax> TaParameters
        {
            get
            {
                if (_taParameters == null)
                {
                    _taParameters = new List<TameCrefParameterSyntax>();
                    foreach (var item in _parameters)
                        _taParameters.Add(new TameCrefParameterSyntax(item) {TaParent = this});
                }
                return _taParameters;
            }
            set
            {
                if (_taParameters != value)
                {
                    _taParameters = value;
                    _taParameters?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaParametersIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taParameters = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _parameters = ((BaseCrefParameterListSyntax) Node).Parameters;
            _parametersIsChanged = false;
            _parametersCount = _parameters.Count;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaParameters)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaParameters)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ParametersStr", ParametersStr);
        }
    }
}