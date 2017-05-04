// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameTypeParameterConstraintClauseSyntax : TameBaseRoslynNode
    {
        public static string TypeName = "TypeParameterConstraintClauseSyntax";
        private SyntaxToken _colonToken;
        private bool _colonTokenIsChanged;
        private string _colonTokenStr;
        private SeparatedSyntaxList<TypeParameterConstraintSyntax> _constraints;
        private int _constraintsCount;
        private bool _constraintsIsChanged;
        private string _constraintsStr;
        private IdentifierNameSyntax _name;
        private bool _nameIsChanged;
        private string _nameStr;
        private List<TameTypeParameterConstraintSyntax> _taConstraints;
        private TameIdentifierNameSyntax _taName;
        private SyntaxToken _whereKeyword;
        private bool _whereKeywordIsChanged;
        private string _whereKeywordStr;

        public TameTypeParameterConstraintClauseSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseTypeParameterConstraintClause(code);
            AddChildren();
        }

        public TameTypeParameterConstraintClauseSyntax(TypeParameterConstraintClauseSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameTypeParameterConstraintClauseSyntax()
        {
            WhereKeywordStr = DefaultValues.TypeParameterConstraintClauseSyntaxWhereKeywordStr;
            NameStr = DefaultValues.TypeParameterConstraintClauseSyntaxNameStr;
            ColonTokenStr = DefaultValues.TypeParameterConstraintClauseSyntaxColonTokenStr;
            ConstraintsStr = DefaultValues.TypeParameterConstraintClauseSyntaxConstraintsStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken WhereKeyword
        {
            get
            {
                if (_whereKeywordIsChanged)
                {
                    if (_whereKeywordStr == null) _whereKeyword = default(SyntaxToken);
                    else _whereKeyword = SyntaxFactoryStr.ParseSyntaxToken(_whereKeywordStr, SyntaxKind.WhereKeyword);
                    _whereKeywordIsChanged = false;
                }
                return _whereKeyword;
            }
            set
            {
                if (_whereKeyword != value)
                {
                    _whereKeyword = value;
                    _whereKeywordIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string WhereKeywordStr
        {
            get
            {
                if (_whereKeywordIsChanged) return _whereKeywordStr;
                return _whereKeywordStr = _whereKeyword.Text;
            }
            set
            {
                if (_whereKeywordStr != value)
                {
                    _whereKeywordStr = value;
                    IsChanged = true;
                    _whereKeywordIsChanged = true;
                }
            }
        }

        public IdentifierNameSyntax Name
        {
            get
            {
                if (_nameIsChanged)
                {
                    _name = SyntaxFactoryStr.ParseIdentifierNameSyntax(NameStr);
                    _nameIsChanged = false;
                    _taName = null;
                }
                else if (_taName != null && _taName.IsChanged)
                {
                    _name = (IdentifierNameSyntax) _taName.Node;
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
                    Name = (IdentifierNameSyntax) _taName.Node;
                if (_nameIsChanged) return _nameStr;
                return _nameStr = _name?.ToFullString();
            }
            set
            {
                if (_taName != null && _taName.IsChanged)
                {
                    Name = (IdentifierNameSyntax) _taName.Node;
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

        public TameIdentifierNameSyntax TaName
        {
            get
            {
                if (_taName == null && Name != null)
                {
                    _taName = new TameIdentifierNameSyntax(Name) {TaParent = this};
                    _taName.AddChildren();
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

        public SyntaxToken ColonToken
        {
            get
            {
                if (_colonTokenIsChanged)
                {
                    if (_colonTokenStr == null) _colonToken = default(SyntaxToken);
                    else _colonToken = SyntaxFactoryStr.ParseSyntaxToken(_colonTokenStr, SyntaxKind.ColonToken);
                    _colonTokenIsChanged = false;
                }
                return _colonToken;
            }
            set
            {
                if (_colonToken != value)
                {
                    _colonToken = value;
                    _colonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ColonTokenStr
        {
            get
            {
                if (_colonTokenIsChanged) return _colonTokenStr;
                return _colonTokenStr = _colonToken.Text;
            }
            set
            {
                if (_colonTokenStr != value)
                {
                    _colonTokenStr = value;
                    IsChanged = true;
                    _colonTokenIsChanged = true;
                }
            }
        }

        public bool TaConstraintsIsChanged { get; set; }

        public SeparatedSyntaxList<TypeParameterConstraintSyntax> Constraints
        {
            get
            {
                if (TaConstraintsIsChanged || _taConstraints != null &&
                    (_taConstraints.Count != _constraintsCount || _taConstraints.Any(v => v.IsChanged)))
                {
                    _constraints = SyntaxFactory.SeparatedList(TaConstraints?.Select(v => v.Node)
                        .Cast<TypeParameterConstraintSyntax>());
                    TaConstraintsIsChanged = false;
                }
                return _constraints;
            }
            set
            {
                if (_constraints != value)
                {
                    _constraints = value;
                    TaConstraintsIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ConstraintsStr
        {
            get
            {
                if (_constraintsIsChanged) return _constraintsStr;
                return _constraintsStr = string.Join(", ", _constraints.Select(v => v?.ToFullString()));
            }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    _constraintsStr = value;
                    Constraints = new SeparatedSyntaxList<TypeParameterConstraintSyntax>();
                }
                else
                {
                    throw new NotImplementedException();
                }
            }
        }

        public List<TameTypeParameterConstraintSyntax> TaConstraints
        {
            get
            {
                if (_taConstraints == null)
                {
                    _taConstraints = new List<TameTypeParameterConstraintSyntax>();
                    foreach (var item in _constraints)
                        if (item is ClassOrStructConstraintSyntax)
                            _taConstraints.Add(
                                new TameClassOrStructConstraintSyntax(item as ClassOrStructConstraintSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is ConstructorConstraintSyntax)
                            _taConstraints.Add(
                                new TameConstructorConstraintSyntax(item as ConstructorConstraintSyntax)
                                {
                                    TaParent = this
                                });
                        else if (item is TypeConstraintSyntax)
                            _taConstraints.Add(
                                new TameTypeConstraintSyntax(item as TypeConstraintSyntax) {TaParent = this});
                        else if (item is TypeParameterConstraintSyntax)
                            _taConstraints.Add(new TameTypeParameterConstraintSyntax(item) {TaParent = this});
                }
                return _taConstraints;
            }
            set
            {
                if (_taConstraints != value)
                {
                    _taConstraints = value;
                    _taConstraints?.ForEach(v => v.TaParent = this);
                    IsChanged = true;
                    TaConstraintsIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            _taName = null;
            _taConstraints = null;
        }

        public override void AddChildren()
        {
            Kind = Node.Kind();
            _whereKeyword = ((TypeParameterConstraintClauseSyntax) Node).WhereKeyword;
            _whereKeywordIsChanged = false;
            _name = ((TypeParameterConstraintClauseSyntax) Node).Name;
            _nameIsChanged = false;
            _colonToken = ((TypeParameterConstraintClauseSyntax) Node).ColonToken;
            _colonTokenIsChanged = false;
            _constraints = ((TypeParameterConstraintClauseSyntax) Node).Constraints;
            _constraintsIsChanged = false;
            _constraintsCount = _constraints.Count;
        }

        public override void SetNotChanged()
        {
            IsChanged = false;
            foreach (var item in TaConstraints)
                item.SetNotChanged();
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.TypeParameterConstraintClause(WhereKeyword, Name, ColonToken, Constraints);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            foreach (var item in TaConstraints)
                yield return item;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaName != null) yield return TaName;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("WhereKeywordStr", WhereKeywordStr);
            yield return ("NameStr", NameStr);
            yield return ("ColonTokenStr", ColonTokenStr);
            yield return ("ConstraintsStr", ConstraintsStr);
        }

        public TameTypeParameterConstraintClauseSyntax AddConstraint(TameTypeParameterConstraintSyntax item)
        {
            item.TaParent = this;
            TaConstraints.Add(item);
            item.IsChanged = true;
            return this;
        }
    }
}