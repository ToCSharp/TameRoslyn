// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameNameMemberCrefSyntax : TameMemberCrefSyntax
    {
        public new static string TypeName = "NameMemberCrefSyntax";
        private TypeSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private CrefParameterListSyntax _parameters;
        private bool _parametersIsChanged;
        private string _parametersStr;
        private TameTypeSyntax _taName;
        private TameCrefParameterListSyntax _taParameters;

        public TameNameMemberCrefSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseNameMemberCref(code);
            AddChildren();
        }

        public TameNameMemberCrefSyntax(NameMemberCrefSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameNameMemberCrefSyntax()
        {
            // NameStr = DefaultValues.NameMemberCrefSyntaxNameStr;
            // ParametersStr = DefaultValues.NameMemberCrefSyntaxParametersStr;
        }

        public override string RoslynTypeName => TypeName;

        public TypeSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseTypeSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (TypeSyntax) _taName.Node;
                }
                return _name;
            }
            set
            {
                if (_name != value)
                {
                    _name = value;
                    _nameIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string NameStr
        {
            get
            {
                if (_taName != null && _taName.IsChanged)
                    Name = (TypeSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (TypeSyntax) _taName.Node;
                    _nameStr = _name?.ToFullString();
                }
                if (_nameStr != value)
                {
                    _nameStr = value;
                    IsChanged = true;
                    _nameIsChanged = true;
                    _taName = null;
                }
            }
        }

        public TameTypeSyntax TaName
        {
            get
            {
                if (_taName == null && Name != null)
                    if (Name is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is OmittedTypeArgumentSyntax)
                    {
                        var loc = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                    else if (Name is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Name) {TaParent = this};
                        loc.AddChildren();
                        _taName = loc;
                    }
                return _taName;
            }
            set
            {
                if (_taName != value)
                {
                    _taName = value;
                    if (_taName != null)
                    {
                        _taName.TaParent = this;
                        _taName.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
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
            _taName = null;
            _taParameters = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _name = ((NameMemberCrefSyntax) Node).Name;
            _nameIsChanged = false;
            _parameters = ((NameMemberCrefSyntax) Node).Parameters;
            _parametersIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.NameMemberCref(Name, Parameters);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
            if (TaParameters != null) yield return TaParameters;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("NameStr", NameStr);
            yield return ("ParametersStr", ParametersStr);
        }
    }
}