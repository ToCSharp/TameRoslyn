// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameVariableDeclarationSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "VariableDeclarationSyntax";
        private TameTypeSyntax _taType;
        private List<TameVariableDeclaratorSyntax> _taVariables;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;
        private SeparatedSyntaxList<VariableDeclaratorSyntax> _variables;
        private int _variablesCount;
        private bool _variablesIsChanged;
        private string _variablesStr;

        public TameVariableDeclarationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseVariableDeclaration(code);
            AddChildren();
        }

        public TameVariableDeclarationSyntax(VariableDeclarationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameVariableDeclarationSyntax()
        {
            TypeStr = DefaultValues.VariableDeclarationSyntaxTypeStr;
            VariablesStr = DefaultValues.VariableDeclarationSyntaxVariablesStr;
        }

        public override string RoslynTypeName => TypeName;

        public TypeSyntax Type
        {
            get
            {
                if (_typeIsChanged)
                {
                    _type = SyntaxFactoryStr.ParseTypeSyntax(TypeStr);
                    _typeIsChanged = false;
                    _taType = null;
                }
                else if (_taType != null && _taType.IsChanged)
                {
                    _type = (TypeSyntax) _taType.Node;
                }
                return _type;
            }
            set
            {
                if (_type != value)
                {
                    _type = value;
                    _typeIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string TypeStr
        {
            get
            {
                if (_taType != null && _taType.IsChanged)
                    Type = (TypeSyntax) _taType.Node;
                if (_typeIsChanged) return _typeStr;
                return _typeStr = _type?.ToFullString();
            }
            set
            {
                if (_taType != null && _taType.IsChanged)
                {
                    Type = (TypeSyntax) _taType.Node;
                    _typeStr = _type?.ToFullString();
                }
                if (_typeStr != value)
                {
                    _typeStr = value;
                    IsChanged = true;
                    _typeIsChanged = true;
                    _taType = null;
                }
            }
        }

        public TameTypeSyntax TaType
        {
            get
            {
                if (_taType == null && Type != null)
                    if (Type is IdentifierNameSyntax)
                    {
                        var loc = new TameIdentifierNameSyntax((IdentifierNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is GenericNameSyntax)
                    {
                        var loc = new TameGenericNameSyntax((GenericNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is AliasQualifiedNameSyntax)
                    {
                        var loc = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is QualifiedNameSyntax)
                    {
                        var loc = new TameQualifiedNameSyntax((QualifiedNameSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is OmittedTypeArgumentSyntax)
                    {
                        var loc = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PredefinedTypeSyntax)
                    {
                        var loc = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is NullableTypeSyntax)
                    {
                        var loc = new TameNullableTypeSyntax((NullableTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is PointerTypeSyntax)
                    {
                        var loc = new TamePointerTypeSyntax((PointerTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is ArrayTypeSyntax)
                    {
                        var loc = new TameArrayTypeSyntax((ArrayTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is TupleTypeSyntax)
                    {
                        var loc = new TameTupleTypeSyntax((TupleTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                    else if (Type is RefTypeSyntax)
                    {
                        var loc = new TameRefTypeSyntax((RefTypeSyntax) Type) {TaParent = this};
                        loc.AddChildren();
                        _taType = loc;
                    }
                return _taType;
            }
            set
            {
                if (_taType != value)
                {
                    _taType = value;
                    if (_taType != null)
                    {
                        _taType.TaParent = this;
                        _taType.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public bool TaVariablesIsChanged { get; set; }

        public SeparatedSyntaxList<VariableDeclaratorSyntax> Variables
        {
            get
            {
                if (TaVariablesIsChanged || _taVariables != null &&
                    (_taVariables.Count != _variablesCount || _taVariables.Any(v => v.IsChanged)))
                {
                    _variables = SyntaxFactory.SeparatedList(TaVariables?.Select(v => v.Node)
                        .Cast<VariableDeclaratorSyntax>());
                    TaVariablesIsChanged = false;
                }
                return _variables;
            }
            set
            {
                if (_variables != value)
                {
                    _variables = value;
                    TaVariablesIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string VariablesStr
        {
            get
            {
                if (_variablesIsChanged) return _variablesStr;
                return _variablesStr = string.Join(", ", _variables.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _variablesStr = value;
                    Variables = new SeparatedSyntaxList<VariableDeclaratorSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameVariableDeclaratorSyntax> TaVariables
        {
            get
            {
                if (_taVariables == null)
                {
                    _taVariables = new List<TameVariableDeclaratorSyntax>();
                    foreach (var item in _variables)
                        _taVariables.Add(new TameVariableDeclaratorSyntax(item) {TaParent = this});
                }
                return _taVariables;
            }
            set
            {
                if (_taVariables != value)
                {
                    _taVariables = value;
                    _taVariables?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaVariablesIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taType = null;
            _taVariables = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _type = ((VariableDeclarationSyntax) Node).Type;
            _typeIsChanged = false;
            _variables = ((VariableDeclarationSyntax) Node).Variables;
            _variablesIsChanged = false;
            _variablesCount = _variables.Count;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaVariables)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.VariableDeclaration(Type, Variables);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaVariables)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("TypeStr", TypeStr);
            yield return ("VariablesStr", VariablesStr);
        }

        public TameVariableDeclarationSyntax AddVariable(TameVariableDeclaratorSyntax item)
        {
            item.TaParent = this;
            TaVariables.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}