// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDeclarationPatternSyntax : TamePatternSyntax
    {
        public new static string TypeName = "DeclarationPatternSyntax";
        private VariableDesignationSyntax _designation;
        private bool _designationIsChanged;
        private string _designationStr;
        private TameVariableDesignationSyntax _taDesignation;
        private TameTypeSyntax _taType;
        private TypeSyntax _type;
        private bool _typeIsChanged;
        private string _typeStr;

        public TameDeclarationPatternSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDeclarationPattern(code);
            AddChildren();
        }

        public TameDeclarationPatternSyntax(DeclarationPatternSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDeclarationPatternSyntax()
        {
            TypeStr = DefaultValues.DeclarationPatternSyntaxTypeStr;
            DesignationStr = DefaultValues.DeclarationPatternSyntaxDesignationStr;
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

        public VariableDesignationSyntax Designation
        {
            get
            {
                if (_designationIsChanged)
                {
                    _designation = SyntaxFactoryStr.ParseVariableDesignationSyntax(DesignationStr);
                    _designationIsChanged = false;
                    _taDesignation = null;
                }
                else if (_taDesignation != null && _taDesignation.IsChanged)
                {
                    _designation = (VariableDesignationSyntax) _taDesignation.Node;
                }
                return _designation;
            }
            set
            {
                if (_designation != value)
                {
                    _designation = value;
                    _designationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DesignationStr
        {
            get
            {
                if (_taDesignation != null && _taDesignation.IsChanged)
                    Designation = (VariableDesignationSyntax) _taDesignation.Node;
                if (_designationIsChanged) return _designationStr;
                return _designationStr = _designation?.ToFullString();
            }
            set
            {
                if (_taDesignation != null && _taDesignation.IsChanged)
                {
                    Designation = (VariableDesignationSyntax) _taDesignation.Node;
                    _designationStr = _designation?.ToFullString();
                }
                if (_designationStr != value)
                {
                    _designationStr = value;
                    IsChanged = true;
                    _designationIsChanged = true;
                    _taDesignation = null;
                }
            }
        }

        public TameVariableDesignationSyntax TaDesignation
        {
            get
            {
                if (_taDesignation == null && Designation != null)
                    if (Designation is ParenthesizedVariableDesignationSyntax)
                    {
                        var loc =
                            new TameParenthesizedVariableDesignationSyntax(
                                (ParenthesizedVariableDesignationSyntax) Designation) {TaParent = this};
                        loc.AddChildren();
                        _taDesignation = loc;
                    }
                    else if (Designation is SingleVariableDesignationSyntax)
                    {
                        var loc =
                            new TameSingleVariableDesignationSyntax((SingleVariableDesignationSyntax) Designation)
                            {
                                TaParent = this
                            };
                        loc.AddChildren();
                        _taDesignation = loc;
                    }
                    else if (Designation is DiscardDesignationSyntax)
                    {
                        var loc =
                            new TameDiscardDesignationSyntax((DiscardDesignationSyntax) Designation) {TaParent = this};
                        loc.AddChildren();
                        _taDesignation = loc;
                    }
                return _taDesignation;
            }
            set
            {
                if (_taDesignation != value)
                {
                    _taDesignation = value;
                    if (_taDesignation != null)
                    {
                        _taDesignation.TaParent = this;
                        _taDesignation.IsChanged = true;
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
            _taType = null;
            _taDesignation = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _type = ((DeclarationPatternSyntax) Node).Type;
            _typeIsChanged = false;
            _designation = ((DeclarationPatternSyntax) Node).Designation;
            _designationIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.DeclarationPattern(Type, Designation);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaType != null) yield return TaType;
            if (TaDesignation != null) yield return TaDesignation;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("TypeStr", TypeStr);
            yield return ("DesignationStr", DesignationStr);
        }
    }
}