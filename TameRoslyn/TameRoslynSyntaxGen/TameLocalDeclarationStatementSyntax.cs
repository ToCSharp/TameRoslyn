// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameLocalDeclarationStatementSyntax : TameStatementSyntax
    {
        public new static string TypeName = "LocalDeclarationStatementSyntax";
        private VariableDeclarationSyntax _declaration;
        private bool _declarationIsChanged;
        private string _declarationStr;
        private bool _isConst;
        private bool _isConstIsChanged;
        private SyntaxTokenList _modifiers;
        private bool _modifiersIsChanged;
        private string _modifiersStr;
        private SyntaxToken _semicolonToken;
        private bool _semicolonTokenIsChanged;
        private string _semicolonTokenStr;
        private TameVariableDeclarationSyntax _taDeclaration;
        private TameSyntaxTokenList _taModifiers;

        public TameLocalDeclarationStatementSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseLocalDeclarationStatement(code);
            AddChildren();
        }

        public TameLocalDeclarationStatementSyntax(LocalDeclarationStatementSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameLocalDeclarationStatementSyntax()
        {
            IsConst = DefaultValues.LocalDeclarationStatementSyntaxIsConst;
            ModifiersStr = DefaultValues.LocalDeclarationStatementSyntaxModifiersStr;
            DeclarationStr = DefaultValues.LocalDeclarationStatementSyntaxDeclarationStr;
            SemicolonTokenStr = DefaultValues.LocalDeclarationStatementSyntaxSemicolonTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public bool IsConst
        {
            get { return _isConst; }
            set
            {
                if (_isConst != value)
                {
                    _isConst = value;
                    _isConstIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public SyntaxTokenList Modifiers
        {
            get
            {
                if (_modifiersIsChanged)
                {
                    _modifiers = SyntaxFactoryStr.ParseSyntaxTokenList(ModifiersStr);
                    _modifiersIsChanged = false;
                    _taModifiers = null;
                }
                else if (_taModifiers != null && _taModifiers.IsChanged)
                {
                    _modifiers = _taModifiers.Node;
                }
                return _modifiers;
            }
            set
            {
                if (_modifiers != value)
                {
                    _modifiers = value;
                    _modifiersIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string ModifiersStr
        {
            get
            {
                if (_taModifiers != null && _taModifiers.IsChanged)
                    Modifiers = _taModifiers.Node;
                if (_modifiersIsChanged) return _modifiersStr;
                return _modifiersStr = _modifiers.ToFullString();
            }
            set
            {
                if (_taModifiers != null && _taModifiers.IsChanged)
                {
                    Modifiers = _taModifiers.Node;
                    _modifiersStr = _modifiers.ToFullString();
                }
                if (_modifiersStr != value)
                {
                    _modifiersStr = value;
                    IsChanged = true;
                    _modifiersIsChanged = true;
                    _taModifiers = null;
                }
            }
        }

        public TameSyntaxTokenList TaModifiers
        {
            get
            {
                if (_taModifiers == null)
                {
                    _taModifiers = new TameSyntaxTokenList(Modifiers) {TaParent = this};
                    _taModifiers.AddChildren();
                }
                return _taModifiers;
            }
            set
            {
                if (_taModifiers != value)
                {
                    _taModifiers = value;
                    if (_taModifiers != null)
                    {
                        _taModifiers.TaParent = this;
                        _taModifiers.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public VariableDeclarationSyntax Declaration
        {
            get
            {
                if (_declarationIsChanged)
                {
                    _declaration = SyntaxFactoryStr.ParseVariableDeclarationSyntax(DeclarationStr);
                    _declarationIsChanged = false;
                    _taDeclaration = null;
                }
                else if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    _declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                }
                return _declaration;
            }
            set
            {
                if (_declaration != value)
                {
                    _declaration = value;
                    _declarationIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string DeclarationStr
        {
            get
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                if (_declarationIsChanged) return _declarationStr;
                return _declarationStr = _declaration?.ToFullString();
            }
            set
            {
                if (_taDeclaration != null && _taDeclaration.IsChanged)
                {
                    Declaration = (VariableDeclarationSyntax) _taDeclaration.Node;
                    _declarationStr = _declaration?.ToFullString();
                }
                if (_declarationStr != value)
                {
                    _declarationStr = value;
                    IsChanged = true;
                    _declarationIsChanged = true;
                    _taDeclaration = null;
                }
            }
        }

        public TameVariableDeclarationSyntax TaDeclaration
        {
            get
            {
                if (_taDeclaration == null && Declaration != null)
                {
                    _taDeclaration = new TameVariableDeclarationSyntax(Declaration) {TaParent = this};
                    _taDeclaration.AddChildren();
                }
                return _taDeclaration;
            }
            set
            {
                if (_taDeclaration != value)
                {
                    _taDeclaration = value;
                    if (_taDeclaration != null)
                    {
                        _taDeclaration.TaParent = this;
                        _taDeclaration.IsChanged = true;
                    }
                    else
                    {
                        IsChanged = true;
                    }
                }
            }
        }

        public SyntaxToken SemicolonToken
        {
            get
            {
                if (_semicolonTokenIsChanged)
                {
                    if (_semicolonTokenStr == null) _semicolonToken = default(SyntaxToken);
                    else
                        _semicolonToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_semicolonTokenStr, SyntaxKind.SemicolonToken);
                    _semicolonTokenIsChanged = false;
                }
                return _semicolonToken;
            }
            set
            {
                if (_semicolonToken != value)
                {
                    _semicolonToken = value;
                    _semicolonTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string SemicolonTokenStr
        {
            get
            {
                if (_semicolonTokenIsChanged) return _semicolonTokenStr;
                return _semicolonTokenStr = _semicolonToken.Text;
            }
            set
            {
                if (_semicolonTokenStr != value)
                {
                    _semicolonTokenStr = value;
                    IsChanged = true;
                    _semicolonTokenIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
            _taModifiers = null;
            _taDeclaration = null;
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _isConst = ((LocalDeclarationStatementSyntax) Node).IsConst;
            _isConstIsChanged = false;
            _modifiers = ((LocalDeclarationStatementSyntax) Node).Modifiers;
            _modifiersIsChanged = false;
            _declaration = ((LocalDeclarationStatementSyntax) Node).Declaration;
            _declarationIsChanged = false;
            _semicolonToken = ((LocalDeclarationStatementSyntax) Node).SemicolonToken;
            _semicolonTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.LocalDeclarationStatement(Modifiers, Declaration, SemicolonToken);
// if (IsConst != null) res = res.WithIsConst(IsConst);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            if (TaDeclaration != null) yield return TaDeclaration;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IsConst", IsConst.ToString());
            yield return ("ModifiersStr", ModifiersStr);
            yield return ("DeclarationStr", DeclarationStr);
            yield return ("SemicolonTokenStr", SemicolonTokenStr);
        }
    }
}