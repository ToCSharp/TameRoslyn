// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameTypeParameterListSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "TypeParameterListSyntax";
        private SyntaxToken _greaterThanToken;
        private bool _greaterThanTokenIsChanged;
        private string _greaterThanTokenStr;
        private SyntaxToken _lessThanToken;
        private bool _lessThanTokenIsChanged;
        private string _lessThanTokenStr;
        private SeparatedSyntaxList<TypeParameterSyntax> _parameters;
        private int _parametersCount;
        private bool _parametersIsChanged;
        private string _parametersStr;
        private List<TameTypeParameterSyntax> _taParameters;

        public TameTypeParameterListSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTypeParameterList(code);
            AddChildren();
        }

        public TameTypeParameterListSyntax(TypeParameterListSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTypeParameterListSyntax()
        {
            LessThanTokenStr = DefaultValues.TypeParameterListSyntaxLessThanTokenStr;
            ParametersStr = DefaultValues.TypeParameterListSyntaxParametersStr;
            GreaterThanTokenStr = DefaultValues.TypeParameterListSyntaxGreaterThanTokenStr;
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

        public bool TaParametersIsChanged { get; set; }

        public SeparatedSyntaxList<TypeParameterSyntax> Parameters
        {
            get
            {
                if (TaParametersIsChanged || _taParameters != null &&
                    (_taParameters.Count != _parametersCount || _taParameters.Any(v => v.IsChanged)))
                {
                    _parameters =
                        SyntaxFactory.SeparatedList(TaParameters?.Select(v => v.Node).Cast<TypeParameterSyntax>());
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
                    Parameters = new SeparatedSyntaxList<TypeParameterSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameTypeParameterSyntax> TaParameters
        {
            get
            {
                if (_taParameters == null)
                {
                    _taParameters = new List<TameTypeParameterSyntax>();
                    foreach (var item in _parameters)
                        _taParameters.Add(new TameTypeParameterSyntax(item) {TaParent = this});
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
            _taParameters = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _lessThanToken = ((TypeParameterListSyntax) Node).LessThanToken;
            _lessThanTokenIsChanged = false;
            _parameters = ((TypeParameterListSyntax) Node).Parameters;
            _parametersIsChanged = false;
            _parametersCount = _parameters.Count;
            _greaterThanToken = ((TypeParameterListSyntax) Node).GreaterThanToken;
            _greaterThanTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaParameters)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TypeParameterList(LessThanToken, Parameters, GreaterThanToken);
            IsChanged = false;
            return res;
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
            yield return ("LessThanTokenStr", LessThanTokenStr);
            yield return ("ParametersStr", ParametersStr);
            yield return ("GreaterThanTokenStr", GreaterThanTokenStr);
        }

        public TameTypeParameterListSyntax AddParameter(TameTypeParameterSyntax item)
        {
            item.TaParent = this;
            TaParameters.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}