// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameOmittedTypeArgumentSyntax : TameTypeSyntax
    {
        public new static string TypeName = "OmittedTypeArgumentSyntax";
        private SyntaxToken _omittedTypeArgumentToken;
        private bool _omittedTypeArgumentTokenIsChanged;
        private string _omittedTypeArgumentTokenStr;

        public TameOmittedTypeArgumentSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseOmittedTypeArgument(code);
            AddChildren();
        }

        public TameOmittedTypeArgumentSyntax(OmittedTypeArgumentSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameOmittedTypeArgumentSyntax()
        {
            OmittedTypeArgumentTokenStr = DefaultValues.OmittedTypeArgumentSyntaxOmittedTypeArgumentTokenStr;
            IsVar = DefaultValues.OmittedTypeArgumentSyntaxIsVar;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken OmittedTypeArgumentToken
        {
            get
            {
                if (_omittedTypeArgumentTokenIsChanged)
                {
                    if (_omittedTypeArgumentTokenStr == null) _omittedTypeArgumentToken = default(SyntaxToken);
                    else
                        _omittedTypeArgumentToken = SyntaxFactoryStr.ParseSyntaxToken(_omittedTypeArgumentTokenStr,
                            SyntaxKind.OmittedTypeArgumentToken);
                    _omittedTypeArgumentTokenIsChanged = false;
                }
                return _omittedTypeArgumentToken;
            }
            set
            {
                if (_omittedTypeArgumentToken != value)
                {
                    _omittedTypeArgumentToken = value;
                    _omittedTypeArgumentTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string OmittedTypeArgumentTokenStr
        {
            get
            {
                if (_omittedTypeArgumentTokenIsChanged) return _omittedTypeArgumentTokenStr;
                return _omittedTypeArgumentTokenStr = _omittedTypeArgumentToken.Text;
            }
            set
            {
                if (_omittedTypeArgumentTokenStr != value)
                {
                    _omittedTypeArgumentTokenStr = value;
                    IsChanged = true;
                    _omittedTypeArgumentTokenIsChanged = true;
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
            _omittedTypeArgumentToken = ((OmittedTypeArgumentSyntax) Node).OmittedTypeArgumentToken;
            _omittedTypeArgumentTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.OmittedTypeArgument(OmittedTypeArgumentToken);
// if (IsVar != null) res = res.WithIsVar(IsVar);
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
            yield return ("OmittedTypeArgumentTokenStr", OmittedTypeArgumentTokenStr);
            yield return ("IsVar", IsVar.ToString());
        }
    }
}