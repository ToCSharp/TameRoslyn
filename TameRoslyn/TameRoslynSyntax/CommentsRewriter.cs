// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Zu.TameRoslyn.Syntax
{
    public static class CommentsRewriter
    {
        public static SyntaxNode RemoveComments(SyntaxNode node)
        {
            var rewriter = new Rewriter5();
            var newNode = rewriter.Visit(node);
            return newNode;
        }
    }

    internal class Rewriter1 : CSharpSyntaxRewriter
    {
        public override SyntaxToken VisitToken(SyntaxToken token)
        {
            return token
                .WithLeadingTrivia(RemoveCommentsAndRedundantTrailingWhitespace(token.LeadingTrivia))
                .WithTrailingTrivia(RemoveCommentsAndRedundantTrailingWhitespace(token.TrailingTrivia));
        }

        private SyntaxTriviaList RemoveCommentsAndRedundantTrailingWhitespace(SyntaxTriviaList oldTriviaList)
        {
            var newTriviaList = new List<SyntaxTrivia>();
            for (var i = 0; i < oldTriviaList.Count; ++i)
            {
                var isComment =
                    oldTriviaList[i].Kind() == SyntaxKind.SingleLineCommentTrivia ||
                    oldTriviaList[i].Kind() == SyntaxKind.MultiLineCommentTrivia;

                var isRedundantWhitespace =
                    i + 1 < oldTriviaList.Count &&
                    oldTriviaList[i].Kind() == SyntaxKind.WhitespaceTrivia &&
                    oldTriviaList[i + 1].Kind() == SyntaxKind.EndOfLineTrivia;

                if (!isComment && !isRedundantWhitespace)
                    newTriviaList.Add(oldTriviaList[i]);
            }
            return SyntaxFactory.TriviaList(newTriviaList);
        }
    }

    public class Rewriter5 : CSharpSyntaxRewriter
    {
        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            var updatedTrivia = base.VisitTrivia(trivia);
            if (trivia.Kind() == SyntaxKind.SingleLineCommentTrivia ||
                trivia.Kind() == SyntaxKind.MultiLineCommentTrivia)
                updatedTrivia = default(SyntaxTrivia);

            return updatedTrivia;
        }
    }

    public class RegionRemover1 : CSharpSyntaxRewriter
    {
        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            var updatedTrivia = base.VisitTrivia(trivia);
            if (trivia.Kind() == SyntaxKind.RegionDirectiveTrivia ||
                trivia.Kind() == SyntaxKind.EndRegionDirectiveTrivia)
                updatedTrivia = default(SyntaxTrivia);

            return updatedTrivia;
        }
    }

    internal class Rewriter2 : CSharpSyntaxRewriter
    {
        public override SyntaxTrivia VisitTrivia(SyntaxTrivia trivia)
        {
            var newTrivia = trivia;
            if (trivia.Kind() == SyntaxKind.SingleLineCommentTrivia ||
                trivia.Kind() == SyntaxKind.MultiLineCommentTrivia)
                newTrivia = default(SyntaxTrivia);
            return newTrivia;
        }
    }
}