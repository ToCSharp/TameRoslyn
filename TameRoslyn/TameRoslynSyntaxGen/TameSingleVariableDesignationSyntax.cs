// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameSingleVariableDesignationSyntax : TameVariableDesignationSyntax, IHaveIdentifier
    {
        public new static string TypeName = "SingleVariableDesignationSyntax";
        private SyntaxToken _identifier;
        private bool _identifierIsChanged;
        private string _identifierStr;

        public TameSingleVariableDesignationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseSingleVariableDesignation(code);
            AddChildren();
        }

        public TameSingleVariableDesignationSyntax(SingleVariableDesignationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameSingleVariableDesignationSyntax()
        {
            IdentifierStr = DefaultValues.SingleVariableDesignationSyntaxIdentifierStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken Identifier
        {
            get
            {
                if (_identifierIsChanged)
                {
                    _identifier = SyntaxFactoryStr.ParseSyntaxToken(IdentifierStr);
                    _identifierIsChanged = false;
                }
                return _identifier;
            }
            set
            {
                if (_identifier != value)
                {
                    _identifier = value;
                    _identifierIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string IdentifierStr
        {
            get
            {
                if (_identifierIsChanged) return _identifierStr;
                return _identifierStr = _identifier.Text;
            }
            set
            {
                if (_identifierStr != value)
                {
                    _identifierStr = value;
                    IsChanged = true;
                    _identifierIsChanged = true;
                }
            }
        }

        public override void Clear()
        {
            base.Clear();
        }

        public new void AddChildren()
        {
            base.AddChildren();
            Kind = Node.Kind();
            _identifier = ((SingleVariableDesignationSyntax) Node).Identifier;
            _identifierIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.SingleVariableDesignation(Identifier);
            IsChanged = false;
            return res;
        }

        public override IEnumerable<TameBaseRoslynNode> GetChildren()
        {
            yield break;
        }

        public override IEnumerable<TameBaseRoslynNode> GetTameFields()
        {
            yield break;
        }

        public override IEnumerable<(string filedName, string value)> GetStringFields()
        {
            yield return ("IdentifierStr", IdentifierStr);
        }
    }
}