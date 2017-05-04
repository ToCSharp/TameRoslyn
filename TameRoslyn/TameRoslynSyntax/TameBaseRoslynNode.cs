// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

//using Microsoft.CodeAnalysis.Formatting;
//using Microsoft.CodeAnalysis.MSBuild;

namespace Zu.TameRoslyn.Syntax
{
    public abstract partial class TameBaseRoslynNode : IRoslynNode
    {
        private bool _isChanged;

        private SyntaxNode _node;

        public string FormatedSource => GetFormatedSource();


        public Dictionary<string, object> Metadata { get; set; }

        public abstract string RoslynTypeName { get; }

        public bool IsChanged
        {
            get => _isChanged;
            set
            {
                _isChanged = value;
                if (_isChanged && TaParent != null)
                    TaParent.IsChanged = true;
            }
        }

        public SyntaxNode Node
        {
            get
            {
                if (!IsChanged && _node != null)
                    return _node;
                _node =
                    MakeSyntaxNode(); 
                return _node;
            }
            set => _node = value;
        }

        public SyntaxKind Kind { get; set; }

        public TameBaseRoslynNode TaParent { get; set; }

        public string Source => GetNodeSource();
        public abstract IEnumerable<TameBaseRoslynNode> GetChildren();
        public abstract IEnumerable<TameBaseRoslynNode> GetTameFields();

        public IEnumerable<TameBaseRoslynNode> Descendants(bool includeSelf = true)
        {
            if (includeSelf) yield return this;
            foreach (var descendant in GetChildren())
            foreach (var ch in descendant.Descendants())
                yield return ch;
        }

        public IEnumerable<TameBaseRoslynNode> DescendantsAll(bool includeSelf = true)
        {
            if (includeSelf) yield return this;
            foreach (var descendant in GetAllChildren())
            foreach (var ch in descendant.DescendantsAll())
                yield return ch;
        }

        public IEnumerable<TameBaseRoslynNode> Ancestors(bool includeSelf = false)
        {
            if (includeSelf) yield return this;
            var parent = TaParent;

            while (parent != null)
            {
                yield return parent;
                parent = parent.TaParent;
            }
        }

        public StringBuilder ToStringTree(StringBuilder sb = null, int intend = 0, int maxChars = 50)
        {
            if (sb == null) sb = new StringBuilder();
            sb.AppendLine();
            sb.Append(' ', intend * 2);
            sb.Append(Node.GetType().Name);
            sb.Append("   ");
            var s = Source.Trim().Replace("\r\n", " ").Replace("\n", " ");
            while (s.Contains("  ")) s = s.Replace("  ", " ");
            sb.Append(s.Length > maxChars ? s.Substring(0, maxChars - 2) + ".." : s);

            foreach (var item in GetAllChildren())
                sb.Append(item.ToStringTree(new StringBuilder(), intend + 1));
            return sb;
        }

        public abstract void SetNotChanged();

        public abstract void AddChildren();

        public abstract IEnumerable<(string filedName, string value)> GetStringFields();

        public void ReplaceNode(SyntaxNode newNode)
        {
            _node = newNode;
            IsChanged = false;
            GetType().GetMethod("Clear").Invoke(this, null);
            GetType().GetMethod("AddChildren").Invoke(this, null);
            //AddChildren();
            IsChanged = true;
        }

        public void ReplaceNode(string code)
        {
            ReplaceNode(CreateSyntaxNode.CreateFormCode(code, RoslynTypeName));
        }

        public abstract void Clear();

        public abstract SyntaxNode MakeSyntaxNode();

        public string GetNodeSource()
        {
            if (Node == null) Node = MakeSyntaxNode();
            return Node.GetText().ToString();
        }

        public string GetFormatedSource()
        {
            return
                Node?.NormalizeWhitespace()
                    .GetText()
                    .ToString(); 
        }

        //public IEnumerable<TameBaseRoslynNode> GetAllChildren() => GetChildren().Concat(GetTameFields());
        public IEnumerable<TameBaseRoslynNode> GetAllChildren()
        {
            return GetTameFields().Concat(GetChildren());
        }

        public SyntaxNode GetNodeWithoutComments()
        {
            CSharpSyntaxRewriter rewriter = new RegionRemover1();
            var newRoot = rewriter.Visit(Node);
            return newRoot;
        }

        public string GetSourceWithoutComments()
        {
            CSharpSyntaxRewriter rewriter = new RegionRemover1();
            var newRoot = rewriter.Visit(Node);
            return newRoot?.ToFullString();
        }

        public object GetMetadata(string key)
        {
            if (Metadata == null) return null;
            if (!Metadata.ContainsKey(key)) return null;
            return Metadata[key];
        }

        public void SetMetadata(string key, object obj)
        {
            if (Metadata == null) Metadata = new Dictionary<string, object>();
            Metadata[key] = obj;
        }

        public override string ToString()
        {
            return GetType().Name + (this as IHaveIdentifier)?.IdentifierStr?.AddSpace();
        }

        public class RegionRemover1 : CSharpSyntaxRewriter
        {
            public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
            {
                var updatedTrivia = base.VisitTrivia(trivia);
                if (trivia.Kind() == SyntaxKind.SingleLineCommentTrivia ||
                    trivia.Kind() == SyntaxKind.MultiLineCommentTrivia ||
                    trivia.Kind() == SyntaxKind.MultiLineDocumentationCommentTrivia ||
                    trivia.Kind() == SyntaxKind.SingleLineDocumentationCommentTrivia)
                    updatedTrivia = default(SyntaxTrivia);

                return updatedTrivia;
            }
        }
    }

    public static class StringExt
    {
        public static string AddSpace(this string str)
        {
            return " " + str;
        }
    }
}