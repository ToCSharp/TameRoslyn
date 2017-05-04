// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameDiscardDesignationSyntax : TameVariableDesignationSyntax
    {
        public new static string TypeName = "DiscardDesignationSyntax";
        private SyntaxToken _underscoreToken;
        private bool _underscoreTokenIsChanged;
        private string _underscoreTokenStr;

        public TameDiscardDesignationSyntax(string code)
        {
            Node = SyntaxFactoryStr.ParseDiscardDesignation(code);
            AddChildren();
        }

        public TameDiscardDesignationSyntax(DiscardDesignationSyntax node)
        {
            Node = node;
            AddChildren();
        }

        public TameDiscardDesignationSyntax()
        {
            UnderscoreTokenStr = DefaultValues.DiscardDesignationSyntaxUnderscoreTokenStr;
        }

        public override string RoslynTypeName => TypeName;

        public SyntaxToken UnderscoreToken
        {
            get
            {
                if (_underscoreTokenIsChanged)
                {
                    if (_underscoreTokenStr == null) _underscoreToken = default(SyntaxToken);
                    else
                        _underscoreToken =
                            SyntaxFactoryStr.ParseSyntaxToken(_underscoreTokenStr, SyntaxKind.UnderscoreToken);
                    _underscoreTokenIsChanged = false;
                }
                return _underscoreToken;
            }
            set
            {
                if (_underscoreToken != value)
                {
                    _underscoreToken = value;
                    _underscoreTokenIsChanged = false;
                    IsChanged = true;
                }
            }
        }

        public string UnderscoreTokenStr
        {
            get
            {
                if (_underscoreTokenIsChanged) return _underscoreTokenStr;
                return _underscoreTokenStr = _underscoreToken.Text;
            }
            set
            {
                if (_underscoreTokenStr != value)
                {
                    _underscoreTokenStr = value;
                    IsChanged = true;
                    _underscoreTokenIsChanged = true;
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
            _underscoreToken = ((DiscardDesignationSyntax) Node).UnderscoreToken;
            _underscoreTokenIsChanged = false;
        }

        public override void SetNotChanged()
        {
            base.SetNotChanged();
            IsChanged = false;
        }

        public override SyntaxNode MakeSyntaxNode()
        {
            var res = SyntaxFactory.DiscardDesignation(UnderscoreToken);
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
            yield return ("UnderscoreTokenStr", UnderscoreTokenStr);
        }
    }
}