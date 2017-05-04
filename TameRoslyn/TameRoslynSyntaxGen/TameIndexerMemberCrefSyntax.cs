// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameIndexerMemberCrefSyntax : TameMemberCrefSyntax
    {
        public new static string TypeName = "IndexerMemberCrefSyntax";
        private CrefBracketedParameterListSyntax _parameters;
        private bool _parametersIsChanged;
        private string _parametersStr;
        private TameCrefBracketedParameterListSyntax _taParameters;
        private SyntaxToken _thisKeyword;
        private bool _thisKeywordIsChanged;
        private string _thisKeywordStr;

        public TameIndexerMemberCrefSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseIndexerMemberCref(code);
            AddChildren();
        }

        public TameIndexerMemberCrefSyntax(IndexerMemberCrefSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameIndexerMemberCrefSyntax()
        {
            // ThisKeywordStr = DefaultValues.IndexerMemberCrefSyntaxThisKeywordStr;
            // ParametersStr = DefaultValues.IndexerMemberCrefSyntaxParametersStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken ThisKeyword
        {
            get
            {
                if (_thisKeywordIsChanged)
                {
                    if (_thisKeywordStr == null) _thisKeyword = default(SyntaxToken);
                    else _thisKeyword = SyntaxFactoryStr.ParseSyntaxToken(_thisKeywordStr, SyntaxKind.ThisKeyword);
                    _thisKeywordIsChanged = false;
                }
                return _thisKeyword;
            }
            set
            {
                if (_thisKeyword != value)
                {
                    _thisKeyword = value;
                    _thisKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ThisKeywordStr
        {
            get
            {
                if (_thisKeywordIsChanged) return _thisKeywordStr;
                return _thisKeywordStr = _thisKeyword.Text;
            }
            set
            {
                if (_thisKeywordStr != value)
                {
                    _thisKeywordStr = value;
                    IsChanged = true;
                    _thisKeywordIsChanged = true;
                }
            }
        }

        public CrefBracketedParameterListSyntax Parameters
        {
            get
            {
                if (_parametersIsChanged)
                {
                    _parameters = SyntaxFactoryStr.ParseCrefBracketedParameterListSyntax(ParametersStr);
                    _parametersIsChanged = false;
                    _taParameters = null;
                }
                else if (_taParameters != null && _taParameters.IsChanged)
                {
                    _parameters = (CrefBracketedParameterListSyntax) _taParameters.Node;
                }
                return _parameters;
            }
            set
            {
                if (_parameters != value)
                {
                    _parameters = value;
                    _parametersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ParametersStr
        {
            get
            {
                if (_taParameters != null && _taParameters.IsChanged)
                    Parameters = (CrefBracketedParameterListSyntax) _taParameters.Node;
                if (_parametersIsChanged) return _parametersStr;
                return _parametersStr = _parameters?.ToFullString();
            }
            set
            {
                if (_taParameters != null && _taParameters.IsChanged)
                {
                    Parameters = (CrefBracketedParameterListSyntax) _taParameters.Node;
                    _parametersStr = _parameters?.ToFullString();
                }
                if (_parametersStr != value)
                {
                    _parametersStr = value;
                    IsChanged = true;
                    _parametersIsChanged = true;
                    _taParameters = null;
                }
            }
        }

        public TameCrefBracketedParameterListSyntax TaParameters
        {
            get
            {
                if (_taParameters == null && Parameters != null)
                {
                    _taParameters = new TameCrefBracketedParameterListSyntax(Parameters) {TaParent = this};
                    _taParameters.AddChildren();
                }
                return _taParameters;
            }
            set
            {
                if (_taParameters != value)
                {
                    _taParameters = value;
                    if (_taParameters != null)
                    {
                        _taParameters.TaParent = this;
                        _taParameters.IsChanged = true;
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
            base.Clear();
            _taParameters = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _thisKeyword = ((IndexerMemberCrefSyntax) Node).ThisKeyword;
            _thisKeywordIsChanged = false;
            _parameters = ((IndexerMemberCrefSyntax) Node).Parameters;
            _parametersIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.IndexerMemberCref(ThisKeyword, Parameters);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaParameters != null) yield return TaParameters;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("ThisKeywordStr", ThisKeywordStr);
            yield return ("ParametersStr", ParametersStr);
        }
    }
}