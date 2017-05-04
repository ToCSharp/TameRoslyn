// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameOperatorMemberCrefSyntax : TameMemberCrefSyntax
    {
        public new static string TypeName = "OperatorMemberCrefSyntax";
        private SyntaxToken _operatorKeyword;
        private bool _operatorKeywordIsChanged;
        private string _operatorKeywordStr;
        private SyntaxToken _operatorToken;
        private bool _operatorTokenIsChanged;
        private string _operatorTokenStr;
        private CrefParameterListSyntax _parameters;
        private bool _parametersIsChanged;
        private string _parametersStr;
        private TameCrefParameterListSyntax _taParameters;

        public TameOperatorMemberCrefSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseOperatorMemberCref(code);
            AddChildren();
        }

        public TameOperatorMemberCrefSyntax(OperatorMemberCrefSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameOperatorMemberCrefSyntax()
        {
            // OperatorKeywordStr = DefaultValues.OperatorMemberCrefSyntaxOperatorKeywordStr;
            // OperatorTokenStr = DefaultValues.OperatorMemberCrefSyntaxOperatorTokenStr;
            // ParametersStr = DefaultValues.OperatorMemberCrefSyntaxParametersStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OperatorKeyword
        {
            get
            {
                if (_operatorKeywordIsChanged)
                {
                    if (_operatorKeywordStr == null) _operatorKeyword = default(SyntaxToken);
                    else
                        _operatorKeyword =
                            SyntaxFactoryStr.ParseSyntaxToken(_operatorKeywordStr, SyntaxKind.OperatorKeyword);
                    _operatorKeywordIsChanged = false;
                }
                return _operatorKeyword;
            }
            set
            {
                if (_operatorKeyword != value)
                {
                    _operatorKeyword = value;
                    _operatorKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperatorKeywordStr
        {
            get
            {
                if (_operatorKeywordIsChanged) return _operatorKeywordStr;
                return _operatorKeywordStr = _operatorKeyword.Text;
            }
            set
            {
                if (_operatorKeywordStr != value)
                {
                    _operatorKeywordStr = value;
                    IsChanged = true;
                    _operatorKeywordIsChanged = true;
                }
            }
        }

        public SyntaxToken OperatorToken
        {
            get
            {
                if (_operatorTokenIsChanged)
                {
                    _operatorToken = SyntaxFactoryStr.ParseSyntaxToken(OperatorTokenStr);
                    _operatorTokenIsChanged = false;
                }
                return _operatorToken;
            }
            set
            {
                if (_operatorToken != value)
                {
                    _operatorToken = value;
                    _operatorTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OperatorTokenStr
        {
            get
            {
                if (_operatorTokenIsChanged) return _operatorTokenStr;
                return _operatorTokenStr = _operatorToken.Text;
            }
            set
            {
                if (_operatorTokenStr != value)
                {
                    _operatorTokenStr = value;
                    IsChanged = true;
                    _operatorTokenIsChanged = true;
                }
            }
        }

        public CrefParameterListSyntax Parameters
        {
            get
            {
                if (_parametersIsChanged)
                {
                    _parameters = SyntaxFactoryStr.ParseCrefParameterListSyntax(ParametersStr);
                    _parametersIsChanged = false;
                    _taParameters = null;
                }
                else if (_taParameters != null && _taParameters.IsChanged)
                {
                    _parameters = (CrefParameterListSyntax) _taParameters.Node;
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
                    Parameters = (CrefParameterListSyntax) _taParameters.Node;
                if (_parametersIsChanged) return _parametersStr;
                return _parametersStr = _parameters?.ToFullString();
            }
            set
            {
                if (_taParameters != null && _taParameters.IsChanged)
                {
                    Parameters = (CrefParameterListSyntax) _taParameters.Node;
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

        public TameCrefParameterListSyntax TaParameters
        {
            get
            {
                if (_taParameters == null && Parameters != null)
                {
                    _taParameters = new TameCrefParameterListSyntax(Parameters) {TaParent = this};
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
            _operatorKeyword = ((OperatorMemberCrefSyntax) Node).OperatorKeyword;
            _operatorKeywordIsChanged = false;
            _operatorToken = ((OperatorMemberCrefSyntax) Node).OperatorToken;
            _operatorTokenIsChanged = false;
            _parameters = ((OperatorMemberCrefSyntax) Node).Parameters;
            _parametersIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.OperatorMemberCref(OperatorKeyword, OperatorToken, Parameters);
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
            yield return ("OperatorKeywordStr", OperatorKeywordStr);
            yield return ("OperatorTokenStr", OperatorTokenStr);
            yield return ("ParametersStr", ParametersStr);
        }
    }
}