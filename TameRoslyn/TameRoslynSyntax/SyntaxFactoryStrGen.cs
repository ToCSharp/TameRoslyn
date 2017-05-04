// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public static partial class SyntaxFactoryStr
    {
        public static StructDeclarationSyntax StructDeclaration(string str)
        {
            return str == null ? null : SyntaxFactory.StructDeclaration(str);
        }

        public static InterfaceDeclarationSyntax InterfaceDeclaration(string str)
        {
            return str == null ? null : SyntaxFactory.InterfaceDeclaration(str);
        }

        internal static XmlTextSyntax XmlText(string code)
        {
            throw new NotImplementedException();
        }

        internal static WhenClauseSyntax WhenClause(string code)
        {
            throw new NotImplementedException();
        }

        internal static VariableDesignationSyntax VariableDesignation(string code)
        {
            throw new NotImplementedException();
        }

        internal static UnsafeStatementSyntax UnsafeStatement(string code)
        {
            throw new NotImplementedException();
        }

        internal static UndefDirectiveTriviaSyntax UndefDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        internal static TypeSyntax Type(string code)
        {
            throw new NotImplementedException();
        }

        internal static TupleTypeSyntax TupleType(string code)
        {
            throw new NotImplementedException();
        }

        internal static TupleExpressionSyntax TupleExpression(string code)
        {
            throw new NotImplementedException();
        }

        internal static TupleElementSyntax TupleElement(string code)
        {
            throw new NotImplementedException();
        }

        internal static ThrowExpressionSyntax ThrowExpression(string code)
        {
            throw new NotImplementedException();
        }

        internal static StructuredTriviaSyntax StructuredTrivia(string code)
        {
            throw new NotImplementedException();
        }

        internal static SingleVariableDesignationSyntax SingleVariableDesignation(string code)
        {
            throw new NotImplementedException();
        }

        internal static RefTypeSyntax RefType(string code)
        {
            throw new NotImplementedException();
        }

        internal static RefExpressionSyntax RefExpression(string code)
        {
            throw new NotImplementedException();
        }

        internal static ReferenceDirectiveTriviaSyntax ReferenceDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        internal static QueryBodySyntax QueryBody(string code)
        {
            throw new NotImplementedException();
        }

        internal static PragmaWarningDirectiveTriviaSyntax PragmaWarningDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        internal static PragmaChecksumDirectiveTriviaSyntax PragmaChecksumDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        internal static PatternSyntax Pattern(string code)
        {
            throw new NotImplementedException();
        }

        internal static ParenthesizedVariableDesignationSyntax ParenthesizedVariableDesignation(string code)
        {
            throw new NotImplementedException();
        }

        internal static MemberBindingExpressionSyntax MemberBindingExpression(string code)
        {
            throw new NotImplementedException();
        }

        internal static LocalFunctionStatementSyntax LocalFunctionStatement(string code)
        {
            throw new NotImplementedException();
        }

        internal static BaseTypeSyntax BaseType(string code)
        {
            throw new NotImplementedException();
        }

        internal static BadDirectiveTriviaSyntax BadDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        internal static AttributeListSyntax AttributeList(string code)
        {
            throw new NotImplementedException();
        }

        public static EnumDeclarationSyntax EnumDeclaration(string str)
        {
            return str == null ? null : SyntaxFactory.EnumDeclaration(str);
        }

        public static EnumMemberDeclarationSyntax EnumMemberDeclaration(string str)
        {
            return str == null ? null : SyntaxFactory.EnumMemberDeclaration(str);
        }

        internal static VariableDesignationSyntax ParseVariableDesignationSyntax(string designationStr)
        {
            throw new NotImplementedException();
        }

        public static TypeParameterConstraintClauseSyntax TypeParameterConstraintClause(string str)
        {
            return str == null ? null : SyntaxFactory.TypeParameterConstraintClause(str);
        }

        public static ConstructorDeclarationSyntax
            ConstructorDeclaration(string code,
                string className) // => str == null ? null : SyntaxFactory.ConstructorDeclaration(str);
        {
            if (code == null) return null;
            var str = $"class {className} {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ConstructorDeclarationSyntax>()?.FirstOrDefault();
        }

        public static DestructorDeclarationSyntax DestructorDeclaration(string str)
        {
            return str == null ? null : SyntaxFactory.DestructorDeclaration(str);
        }

        public static ExternAliasDirectiveSyntax ExternAliasDirective(string str)
        {
            return str == null ? null : SyntaxFactory.ExternAliasDirective(str);
        }

        internal static WhenClauseSyntax ParseWhenClauseSyntax(string whenClauseStr)
        {
            throw new NotImplementedException();
        }

        public static NameEqualsSyntax NameEquals(string str)
        {
            return str == null ? null : SyntaxFactory.NameEquals(str);
        }

        public static TypeParameterSyntax TypeParameter(string str)
        {
            return str == null ? null : SyntaxFactory.TypeParameter(str);
        }

        public static ClassDeclarationSyntax ClassDeclaration(string str)
        {
            return str == null ? null : SyntaxFactory.ClassDeclaration(str);
        }

        public static JoinIntoClauseSyntax JoinIntoClause(string str)
        {
            return str == null ? null : SyntaxFactory.JoinIntoClause(str);
        }

        public static VariableDeclaratorSyntax VariableDeclarator(string str)
        {
            return str == null ? null : SyntaxFactory.VariableDeclarator(str);
        }

        public static NameColonSyntax NameColon(string str)
        {
            return str == null ? null : SyntaxFactory.NameColon(str);
        }

        public static IdentifierNameSyntax IdentifierName(string str)
        {
            return str == null ? null : SyntaxFactory.IdentifierName(str);
        }

        public static SyntaxTree ParseSyntaxTree(string str)
        {
            return str == null ? null : SyntaxFactory.ParseSyntaxTree(str);
        }

        public static SyntaxTriviaList ParseLeadingTrivia(string str)
        {
            return SyntaxFactory.ParseLeadingTrivia(str);
        }

        public static SyntaxTriviaList ParseTrailingTrivia(string str)
        {
            return SyntaxFactory.ParseTrailingTrivia(str);
        }

        public static SyntaxToken ParseToken(string str)
        {
            return SyntaxFactory.ParseToken(str);
        }

        public static IEnumerable<SyntaxToken> ParseTokens(string str)
        {
            return SyntaxFactory.ParseTokens(str);
        }

        public static NameSyntax ParseName(string str)
        {
            return str == null ? null : SyntaxFactory.ParseName(str);
        }

        public static TypeSyntax ParseTypeName(string str)
        {
            return str == null ? null : SyntaxFactory.ParseTypeName(str);
        }

        public static ExpressionSyntax ParseExpression(string str)
        {
            return str == null ? null : SyntaxFactory.ParseExpression(str);
        }

        public static StatementSyntax ParseStatement(string str)
        {
            return str == null ? null : SyntaxFactory.ParseStatement(str);
        }

        public static CompilationUnitSyntax ParseCompilationUnit(string str)
        {
            return str == null ? null : SyntaxFactory.ParseCompilationUnit(str);
        }

        public static ParameterListSyntax ParseParameterList(string str)
        {
            return str == null ? null : SyntaxFactory.ParseParameterList(str);
        }

        public static BracketedParameterListSyntax ParseBracketedParameterList(string str)
        {
            return str == null ? null : SyntaxFactory.ParseBracketedParameterList(str);
        }

        public static ArgumentListSyntax ParseArgumentList(string str)
        {
            return str == null ? null : SyntaxFactory.ParseArgumentList(str);
        }

        public static BracketedArgumentListSyntax ParseBracketedArgumentList(string str)
        {
            return str == null ? null : SyntaxFactory.ParseBracketedArgumentList(str);
        }

        public static AttributeArgumentListSyntax ParseAttributeArgumentList(string str)
        {
            return str == null ? null : SyntaxFactory.ParseAttributeArgumentList(str);
        }

        public static GenericNameSyntax GenericName(string str)
        {
            return str == null ? null : SyntaxFactory.GenericName(str);
        }

        public static SyntaxTrivia EndOfLine(string str)
        {
            return SyntaxFactory.EndOfLine(str);
        }

        public static SyntaxTrivia ElasticEndOfLine(string str)
        {
            return SyntaxFactory.ElasticEndOfLine(str);
        }

        public static SyntaxTrivia Whitespace(string str)
        {
            return SyntaxFactory.Whitespace(str);
        }

        public static SyntaxTrivia ElasticWhitespace(string str)
        {
            return SyntaxFactory.ElasticWhitespace(str);
        }

        public static SyntaxTrivia Comment(string str)
        {
            return SyntaxFactory.Comment(str);
        }

        public static SyntaxTrivia DisabledText(string str)
        {
            return SyntaxFactory.DisabledText(str);
        }

        public static SyntaxTrivia PreprocessingMessage(string str)
        {
            return SyntaxFactory.PreprocessingMessage(str);
        }

        public static SyntaxToken Identifier(string str)
        {
            return SyntaxFactory.Identifier(str);
        }

        public static SyntaxToken Literal(string str)
        {
            if (str.Length == 1) SyntaxFactory.Literal(str[0]);
            return SyntaxFactory.Literal(str);
        }

        public static SyntaxTrivia DocumentationCommentExterior(string str)
        {
            return SyntaxFactory.DocumentationCommentExterior(str);
        }

        public static IncompleteMemberSyntax IncompleteMember(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.IncompleteMember(type);
        }

        public static SkippedTokensTriviaSyntax SkippedTokensTrivia()
        {
            return SyntaxFactory.SkippedTokensTrivia();
        }

        public static TypeCrefSyntax TypeCref(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.TypeCref(type);
        }

        public static NameMemberCrefSyntax NameMemberCref(string nameStr)
        {
            var name = ParseTypeName(nameStr);
            return SyntaxFactory.NameMemberCref(name);
        }

        public static OperatorMemberCrefSyntax OperatorMemberCref(string operatorTokenStr)
        {
            var operatorToken = ParseToken(operatorTokenStr);
            return SyntaxFactory.OperatorMemberCref(operatorToken);
        }

        public static ConversionOperatorMemberCrefSyntax ConversionOperatorMemberCref(
            string implicitOrExplicitKeywordStr, string typeStr)
        {
            var implicitOrExplicitKeyword = ParseToken(implicitOrExplicitKeywordStr);
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.ConversionOperatorMemberCref(implicitOrExplicitKeyword, type);
        }

        public static CrefParameterSyntax CrefParameter(string refOrOutKeywordStr, string typeStr)
        {
            var refOrOutKeyword = ParseToken(refOrOutKeywordStr);
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.CrefParameter(refOrOutKeyword, type);
        }

        public static CrefParameterSyntax CrefParameter(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.CrefParameter(type);
        }

        public static DelegateDeclarationSyntax DelegateDeclaration(string returnTypeStr, string identifierStr)
        {
            var returnType = ParseTypeName(returnTypeStr);
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.DelegateDeclaration(returnType, identifier);
        }

        public static SimpleBaseTypeSyntax SimpleBaseType(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.SimpleBaseType(type);
        }

        public static ConstructorConstraintSyntax ConstructorConstraint(string newKeywordStr, string openParenTokenStr,
            string closeParenTokenStr)
        {
            var newKeyword = ParseToken(newKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.ConstructorConstraint(newKeyword, openParenToken, closeParenToken);
        }

        public static ConstructorConstraintSyntax ConstructorConstraint()
        {
            return SyntaxFactory.ConstructorConstraint();
        }

        public static TypeConstraintSyntax TypeConstraint(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.TypeConstraint(type);
        }

        public static ExplicitInterfaceSpecifierSyntax ExplicitInterfaceSpecifier(string nameStr, string dotTokenStr)
        {
            var name = ParseName(nameStr);
            var dotToken = ParseToken(dotTokenStr);
            return SyntaxFactory.ExplicitInterfaceSpecifier(name, dotToken);
        }

        public static ExplicitInterfaceSpecifierSyntax ExplicitInterfaceSpecifier(string nameStr)
        {
            var name = ParseName(nameStr);
            return SyntaxFactory.ExplicitInterfaceSpecifier(name);
        }

        public static MethodDeclarationSyntax MethodDeclaration(string returnTypeStr, string identifierStr)
        {
            var returnType = ParseTypeName(returnTypeStr);
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.MethodDeclaration(returnType, identifier).WithBody(ParseBlockSyntax(""));
        }

        public static OperatorDeclarationSyntax OperatorDeclaration(string returnTypeStr, string operatorTokenStr)
        {
            var returnType = ParseTypeName(returnTypeStr);
            var operatorToken = ParseToken(operatorTokenStr);
            return SyntaxFactory.OperatorDeclaration(returnType, operatorToken);
        }

        public static ConversionOperatorDeclarationSyntax ConversionOperatorDeclaration(
            string implicitOrExplicitKeywordStr, string typeStr)
        {
            var implicitOrExplicitKeyword = ParseToken(implicitOrExplicitKeywordStr);
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.ConversionOperatorDeclaration(implicitOrExplicitKeyword, type);
        }

        public static PropertyDeclarationSyntax PropertyDeclaration(string typeStr, string identifierStr)
        {
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.PropertyDeclaration(type, identifier);
        }

        public static ArrowExpressionClauseSyntax ArrowExpressionClause(string arrowTokenStr, string expressionStr)
        {
            var arrowToken = ParseToken(arrowTokenStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ArrowExpressionClause(arrowToken, expression);
        }

        public static ArrowExpressionClauseSyntax ArrowExpressionClause(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ArrowExpressionClause(expression);
        }

        public static EventDeclarationSyntax EventDeclaration(string typeStr, string identifierStr)
        {
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.EventDeclaration(type, identifier);
        }

        public static IndexerDeclarationSyntax IndexerDeclaration(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.IndexerDeclaration(type);
        }

        public static ParameterSyntax Parameter(string identifierStr)
        {
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.Parameter(identifier);
        }

        public static WhileStatementSyntax WhileStatement(string whileKeywordStr, string openParenTokenStr,
            string conditionStr, string closeParenTokenStr, string statementStr)
        {
            var whileKeyword = ParseToken(whileKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var condition = ParseExpression(conditionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.WhileStatement(whileKeyword, openParenToken, condition, closeParenToken, statement);
        }

        public static WhileStatementSyntax WhileStatement(string conditionStr, string statementStr)
        {
            var condition = ParseExpression(conditionStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.WhileStatement(condition, statement);
        }

        public static DoStatementSyntax DoStatement(string doKeywordStr, string statementStr, string whileKeywordStr,
            string openParenTokenStr, string conditionStr, string closeParenTokenStr, string semicolonTokenStr)
        {
            var doKeyword = ParseToken(doKeywordStr);
            var statement = ParseStatement(statementStr);
            var whileKeyword = ParseToken(whileKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var condition = ParseExpression(conditionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.DoStatement(doKeyword, statement, whileKeyword, openParenToken, condition,
                closeParenToken, semicolonToken);
        }

        public static DoStatementSyntax DoStatement(string statementStr, string conditionStr)
        {
            var statement = ParseStatement(statementStr);
            var condition = ParseExpression(conditionStr);
            return SyntaxFactory.DoStatement(statement, condition);
        }

        public static ForStatementSyntax ForStatement(string statementStr)
        {
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.ForStatement(statement);
        }

        public static ForEachStatementSyntax ForEachStatement(string forEachKeywordStr, string openParenTokenStr,
            string typeStr, string identifierStr, string inKeywordStr, string expressionStr, string closeParenTokenStr,
            string statementStr)
        {
            var forEachKeyword = ParseToken(forEachKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var inKeyword = ParseToken(inKeywordStr);
            var expression = ParseExpression(expressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.ForEachStatement(forEachKeyword, openParenToken, type, identifier, inKeyword,
                expression, closeParenToken, statement);
        }

        public static ForEachStatementSyntax ForEachStatement(string typeStr, string identifierStr,
            string expressionStr, string statementStr)
        {
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var expression = ParseExpression(expressionStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.ForEachStatement(type, identifier, expression, statement);
        }

        public static UsingStatementSyntax UsingStatement(string statementStr)
        {
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.UsingStatement(statement);
        }

        public static LockStatementSyntax LockStatement(string lockKeywordStr, string openParenTokenStr,
            string expressionStr, string closeParenTokenStr, string statementStr)
        {
            var lockKeyword = ParseToken(lockKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var expression = ParseExpression(expressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.LockStatement(lockKeyword, openParenToken, expression, closeParenToken, statement);
        }

        public static LockStatementSyntax LockStatement(string expressionStr, string statementStr)
        {
            var expression = ParseExpression(expressionStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.LockStatement(expression, statement);
        }

        public static IfStatementSyntax IfStatement(string conditionStr, string statementStr)
        {
            var condition = ParseExpression(conditionStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.IfStatement(condition, statement);
        }

        public static ElseClauseSyntax ElseClause(string elseKeywordStr, string statementStr)
        {
            var elseKeyword = ParseToken(elseKeywordStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.ElseClause(elseKeyword, statement);
        }

        public static ElseClauseSyntax ElseClause(string statementStr)
        {
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.ElseClause(statement);
        }

        public static SwitchStatementSyntax SwitchStatement(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.SwitchStatement(expression);
        }

        public static SwitchSectionSyntax SwitchSection()
        {
            return SyntaxFactory.SwitchSection();
        }

        public static CaseSwitchLabelSyntax CaseSwitchLabel(string keywordStr, string valueStr, string colonTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var value = ParseExpression(valueStr);
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.CaseSwitchLabel(keyword, value, colonToken);
        }

        public static CaseSwitchLabelSyntax CaseSwitchLabel(string valueStr, string colonTokenStr)
        {
            var value = ParseExpression(valueStr);
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.CaseSwitchLabel(value, colonToken);
        }

        public static DefaultSwitchLabelSyntax DefaultSwitchLabel(string keywordStr, string colonTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.DefaultSwitchLabel(keyword, colonToken);
        }

        public static DefaultSwitchLabelSyntax DefaultSwitchLabel(string colonTokenStr)
        {
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.DefaultSwitchLabel(colonToken);
        }

        public static CatchClauseSyntax CatchClause()
        {
            return SyntaxFactory.CatchClause();
        }

        public static CatchDeclarationSyntax CatchDeclaration(string openParenTokenStr, string typeStr,
            string identifierStr, string closeParenTokenStr)
        {
            var openParenToken = ParseToken(openParenTokenStr);
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.CatchDeclaration(openParenToken, type, identifier, closeParenToken);
        }

        public static CatchDeclarationSyntax CatchDeclaration(string typeStr, string identifierStr)
        {
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.CatchDeclaration(type, identifier);
        }

        public static CatchDeclarationSyntax CatchDeclaration(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.CatchDeclaration(type);
        }

        public static CatchFilterClauseSyntax CatchFilterClause(string whenKeywordStr, string openParenTokenStr,
            string filterExpressionStr, string closeParenTokenStr)
        {
            var whenKeyword = ParseToken(whenKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var filterExpression = ParseExpression(filterExpressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.CatchFilterClause(whenKeyword, openParenToken, filterExpression, closeParenToken);
        }

        public static CatchFilterClauseSyntax CatchFilterClause(string filterExpressionStr)
        {
            filterExpressionStr = filterExpressionStr.Trim();
            if (filterExpressionStr.StartsWith("when ") && filterExpressionStr.EndsWith(")"))
            {
                filterExpressionStr = filterExpressionStr.Substring("when ".Length).TrimStart();
                filterExpressionStr = filterExpressionStr.Substring(1, filterExpressionStr.Length - 2);
            }
            var filterExpression = ParseExpression(filterExpressionStr);
            return SyntaxFactory.CatchFilterClause(filterExpression);
        }

        public static CompilationUnitSyntax CompilationUnit(string code = null)
        {
            return SyntaxFactory.CompilationUnit();
        }

        public static ExternAliasDirectiveSyntax ExternAliasDirective(string externKeywordStr, string aliasKeywordStr,
            string identifierStr, string semicolonTokenStr)
        {
            var externKeyword = ParseToken(externKeywordStr);
            var aliasKeyword = ParseToken(aliasKeywordStr);
            var identifier = ParseToken(identifierStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.ExternAliasDirective(externKeyword, aliasKeyword, identifier, semicolonToken);
        }

        public static UsingDirectiveSyntax UsingDirective(string usingKeywordStr, string staticKeywordStr,
            string aliasStr, string nameStr, string semicolonTokenStr)
        {
            var usingKeyword = ParseToken(usingKeywordStr);
            var staticKeyword = ParseToken(staticKeywordStr);
            var alias = NameEquals(aliasStr);
            var name = ParseName(nameStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.UsingDirective(usingKeyword, staticKeyword, alias, name, semicolonToken);
        }

        public static UsingDirectiveSyntax UsingDirective(string staticKeywordStr, string aliasStr, string nameStr)
        {
            var staticKeyword = ParseToken(staticKeywordStr);
            var alias = NameEquals(aliasStr);
            var name = ParseName(nameStr);
            return SyntaxFactory.UsingDirective(staticKeyword, alias, name);
        }

        public static UsingDirectiveSyntax UsingDirective(string nameStr)
        {
            var name = ParseName(nameStr);
            return SyntaxFactory.UsingDirective(name);
        }

        public static NamespaceDeclarationSyntax NamespaceDeclaration(string nameStr)
        {
            var name = ParseName(nameStr);
            return SyntaxFactory.NamespaceDeclaration(name);
        }

        public static AttributeTargetSpecifierSyntax AttributeTargetSpecifier(string identifierStr,
            string colonTokenStr)
        {
            var identifier = ParseToken(identifierStr);
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.AttributeTargetSpecifier(identifier, colonToken);
        }

        public static AttributeTargetSpecifierSyntax AttributeTargetSpecifier(string identifierStr)
        {
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.AttributeTargetSpecifier(identifier);
        }

        public static AttributeSyntax Attribute(string nameStr, string argumentListStr)
        {
            var name = ParseName(nameStr);
            var argumentList = ParseAttributeArgumentList(argumentListStr);
            return SyntaxFactory.Attribute(name, argumentList);
        }

        public static AttributeSyntax Attribute(string nameStr)
        {
            var name = ParseName(nameStr);
            return SyntaxFactory.Attribute(name);
        }

        public static AttributeArgumentSyntax AttributeArgument(string nameEqualsStr, string nameColonStr,
            string expressionStr)
        {
            var nameEquals = NameEquals(nameEqualsStr);
            var nameColon = NameColon(nameColonStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.AttributeArgument(nameEquals, nameColon, expression);
        }

        public static AttributeArgumentSyntax AttributeArgument(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.AttributeArgument(expression);
        }

        public static NameEqualsSyntax NameEquals(string nameStr, string equalsTokenStr)
        {
            var name = IdentifierName(nameStr);
            var equalsToken = ParseToken(equalsTokenStr);
            return SyntaxFactory.NameEquals(name, equalsToken);
        }

        public static StackAllocArrayCreationExpressionSyntax StackAllocArrayCreationExpression(
            string stackAllocKeywordStr, string typeStr)
        {
            var stackAllocKeyword = ParseToken(stackAllocKeywordStr);
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.StackAllocArrayCreationExpression(stackAllocKeyword, type);
        }

        public static StackAllocArrayCreationExpressionSyntax StackAllocArrayCreationExpression(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.StackAllocArrayCreationExpression(type);
        }

        public static FromClauseSyntax FromClause(string fromKeywordStr, string typeStr, string identifierStr,
            string inKeywordStr, string expressionStr)
        {
            var fromKeyword = ParseToken(fromKeywordStr);
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var inKeyword = ParseToken(inKeywordStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.FromClause(fromKeyword, type, identifier, inKeyword, expression);
        }

        public static FromClauseSyntax FromClause(string typeStr, string identifierStr, string expressionStr)
        {
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.FromClause(type, identifier, expression);
        }

        public static FromClauseSyntax FromClause(string identifierStr, string expressionStr)
        {
            var identifier = ParseToken(identifierStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.FromClause(identifier, expression);
        }

        public static LetClauseSyntax LetClause(string letKeywordStr, string identifierStr, string equalsTokenStr,
            string expressionStr)
        {
            var letKeyword = ParseToken(letKeywordStr);
            var identifier = ParseToken(identifierStr);
            var equalsToken = ParseToken(equalsTokenStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.LetClause(letKeyword, identifier, equalsToken, expression);
        }

        public static LetClauseSyntax LetClause(string identifierStr, string expressionStr)
        {
            var identifier = ParseToken(identifierStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.LetClause(identifier, expression);
        }

        public static JoinClauseSyntax JoinClause(string joinKeywordStr, string typeStr, string identifierStr,
            string inKeywordStr, string inExpressionStr, string onKeywordStr, string leftExpressionStr,
            string equalsKeywordStr, string rightExpressionStr, string intoStr)
        {
            var joinKeyword = ParseToken(joinKeywordStr);
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var inKeyword = ParseToken(inKeywordStr);
            var inExpression = ParseExpression(inExpressionStr);
            var onKeyword = ParseToken(onKeywordStr);
            var leftExpression = ParseExpression(leftExpressionStr);
            var equalsKeyword = ParseToken(equalsKeywordStr);
            var rightExpression = ParseExpression(rightExpressionStr);
            var into = JoinIntoClause(intoStr);
            return SyntaxFactory.JoinClause(joinKeyword, type, identifier, inKeyword, inExpression, onKeyword,
                leftExpression, equalsKeyword, rightExpression, into);
        }

        public static JoinClauseSyntax JoinClause(string typeStr, string identifierStr, string inExpressionStr,
            string leftExpressionStr, string rightExpressionStr, string intoStr)
        {
            var type = ParseTypeName(typeStr);
            var identifier = ParseToken(identifierStr);
            var inExpression = ParseExpression(inExpressionStr);
            var leftExpression = ParseExpression(leftExpressionStr);
            var rightExpression = ParseExpression(rightExpressionStr);
            var into = JoinIntoClause(intoStr);
            return SyntaxFactory.JoinClause(type, identifier, inExpression, leftExpression, rightExpression, into);
        }

        public static JoinClauseSyntax JoinClause(string identifierStr, string inExpressionStr,
            string leftExpressionStr, string rightExpressionStr)
        {
            var identifier = ParseToken(identifierStr);
            var inExpression = ParseExpression(inExpressionStr);
            var leftExpression = ParseExpression(leftExpressionStr);
            var rightExpression = ParseExpression(rightExpressionStr);
            return SyntaxFactory.JoinClause(identifier, inExpression, leftExpression, rightExpression);
        }

        public static JoinIntoClauseSyntax JoinIntoClause(string intoKeywordStr, string identifierStr)
        {
            var intoKeyword = ParseToken(intoKeywordStr);
            var identifier = ParseToken(identifierStr);
            return SyntaxFactory.JoinIntoClause(intoKeyword, identifier);
        }

        public static WhereClauseSyntax WhereClause(string whereKeywordStr, string conditionStr)
        {
            var whereKeyword = ParseToken(whereKeywordStr);
            var condition = ParseExpression(conditionStr);
            return SyntaxFactory.WhereClause(whereKeyword, condition);
        }

        public static WhereClauseSyntax WhereClause(string conditionStr)
        {
            var condition = ParseExpression(conditionStr);
            return SyntaxFactory.WhereClause(condition);
        }

        public static SelectClauseSyntax SelectClause(string selectKeywordStr, string expressionStr)
        {
            var selectKeyword = ParseToken(selectKeywordStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.SelectClause(selectKeyword, expression);
        }

        public static SelectClauseSyntax SelectClause(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.SelectClause(expression);
        }

        public static GroupClauseSyntax GroupClause(string groupKeywordStr, string groupExpressionStr,
            string byKeywordStr, string byExpressionStr)
        {
            var groupKeyword = ParseToken(groupKeywordStr);
            var groupExpression = ParseExpression(groupExpressionStr);
            var byKeyword = ParseToken(byKeywordStr);
            var byExpression = ParseExpression(byExpressionStr);
            return SyntaxFactory.GroupClause(groupKeyword, groupExpression, byKeyword, byExpression);
        }

        public static GroupClauseSyntax GroupClause(string groupExpressionStr, string byExpressionStr)
        {
            var groupExpression = ParseExpression(groupExpressionStr);
            var byExpression = ParseExpression(byExpressionStr);
            return SyntaxFactory.GroupClause(groupExpression, byExpression);
        }

        public static OmittedArraySizeExpressionSyntax OmittedArraySizeExpression(
            string omittedArraySizeExpressionTokenStr)
        {
            var omittedArraySizeExpressionToken = ParseToken(omittedArraySizeExpressionTokenStr);
            return SyntaxFactory.OmittedArraySizeExpression(omittedArraySizeExpressionToken);
        }

        public static OmittedArraySizeExpressionSyntax OmittedArraySizeExpression()
        {
            return SyntaxFactory.OmittedArraySizeExpression();
        }

        public static InterpolatedStringExpressionSyntax InterpolatedStringExpression(string stringStartTokenStr)
        {
            var stringStartToken = ParseToken(stringStartTokenStr);
            return SyntaxFactory.InterpolatedStringExpression(stringStartToken);
        }

        public static InterpolatedStringTextSyntax InterpolatedStringText(string textTokenStr)
        {
            var textToken = ParseToken(textTokenStr);
            return SyntaxFactory.InterpolatedStringText(textToken);
        }

        public static InterpolatedStringTextSyntax InterpolatedStringText()
        {
            return SyntaxFactory.InterpolatedStringText();
        }

        public static InterpolationSyntax Interpolation(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.Interpolation(expression);
        }

        public static InterpolationAlignmentClauseSyntax InterpolationAlignmentClause(string commaTokenStr,
            string valueStr)
        {
            var commaToken = ParseToken(commaTokenStr);
            var value = ParseExpression(valueStr);
            return SyntaxFactory.InterpolationAlignmentClause(commaToken, value);
        }

        public static InterpolationFormatClauseSyntax InterpolationFormatClause(string colonTokenStr,
            string formatStringTokenStr)
        {
            var colonToken = ParseToken(colonTokenStr);
            var formatStringToken = ParseToken(formatStringTokenStr);
            return SyntaxFactory.InterpolationFormatClause(colonToken, formatStringToken);
        }

        public static InterpolationFormatClauseSyntax InterpolationFormatClause(string colonTokenStr)
        {
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.InterpolationFormatClause(colonToken);
        }

        public static GlobalStatementSyntax GlobalStatement(string statementStr)
        {
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.GlobalStatement(statement);
        }

        public static VariableDeclarationSyntax VariableDeclaration(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.VariableDeclaration(type);
        }

        public static EqualsValueClauseSyntax EqualsValueClause(string equalsTokenStr, string valueStr)
        {
            var equalsToken = ParseToken(equalsTokenStr);
            var value = ParseExpression(valueStr);
            return SyntaxFactory.EqualsValueClause(equalsToken, value);
        }

        public static EqualsValueClauseSyntax EqualsValueClause(string valueStr)
        {
            var value = ParseExpression(valueStr);
            return SyntaxFactory.EqualsValueClause(value);
        }

        public static ExpressionStatementSyntax ExpressionStatement(string expressionStr, string semicolonTokenStr)
        {
            var expression = ParseExpression(expressionStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.ExpressionStatement(expression, semicolonToken);
        }

        public static ExpressionStatementSyntax ExpressionStatement(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ExpressionStatement(expression);
        }

        public static EmptyStatementSyntax EmptyStatement(string semicolonTokenStr)
        {
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.EmptyStatement(semicolonToken);
        }

        public static EmptyStatementSyntax EmptyStatement()
        {
            return SyntaxFactory.EmptyStatement();
        }

        public static LabeledStatementSyntax LabeledStatement(string identifierStr, string colonTokenStr,
            string statementStr)
        {
            var identifier = ParseToken(identifierStr);
            var colonToken = ParseToken(colonTokenStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.LabeledStatement(identifier, colonToken, statement);
        }

        public static LabeledStatementSyntax LabeledStatement(string identifierStr, string statementStr)
        {
            var identifier = ParseToken(identifierStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.LabeledStatement(identifier, statement);
        }

        public static BreakStatementSyntax BreakStatement(string breakKeywordStr, string semicolonTokenStr)
        {
            var breakKeyword = ParseToken(breakKeywordStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.BreakStatement(breakKeyword, semicolonToken);
        }

        public static BreakStatementSyntax BreakStatement()
        {
            return SyntaxFactory.BreakStatement();
        }

        public static ContinueStatementSyntax ContinueStatement(string continueKeywordStr, string semicolonTokenStr)
        {
            var continueKeyword = ParseToken(continueKeywordStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.ContinueStatement(continueKeyword, semicolonToken);
        }

        public static ContinueStatementSyntax ContinueStatement()
        {
            return SyntaxFactory.ContinueStatement();
        }

        public static ReturnStatementSyntax ReturnStatement(string returnKeywordStr, string expressionStr,
            string semicolonTokenStr)
        {
            var returnKeyword = ParseToken(returnKeywordStr);
            var expression = ParseExpression(expressionStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.ReturnStatement(returnKeyword, expression, semicolonToken);
        }

        public static ReturnStatementSyntax ReturnStatement(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ReturnStatement(expression);
        }

        public static ThrowStatementSyntax ThrowStatement(string throwKeywordStr, string expressionStr,
            string semicolonTokenStr)
        {
            var throwKeyword = ParseToken(throwKeywordStr);
            var expression = ParseExpression(expressionStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.ThrowStatement(throwKeyword, expression, semicolonToken);
        }

        public static ThrowStatementSyntax ThrowStatement(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ThrowStatement(expression);
        }

        public static OmittedTypeArgumentSyntax OmittedTypeArgument()
        {
            return SyntaxFactory.OmittedTypeArgument();
        }

        public static ParenthesizedExpressionSyntax ParenthesizedExpression(string openParenTokenStr,
            string expressionStr, string closeParenTokenStr)
        {
            var openParenToken = ParseToken(openParenTokenStr);
            var expression = ParseExpression(expressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.ParenthesizedExpression(openParenToken, expression, closeParenToken);
        }

        public static ParenthesizedExpressionSyntax ParenthesizedExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ParenthesizedExpression(expression);
        }

        public static AwaitExpressionSyntax AwaitExpression(string awaitKeywordStr, string expressionStr)
        {
            var awaitKeyword = ParseToken(awaitKeywordStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.AwaitExpression(awaitKeyword, expression);
        }

        public static AwaitExpressionSyntax AwaitExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.AwaitExpression(expression);
        }

        public static ConditionalAccessExpressionSyntax ConditionalAccessExpression(string expressionStr,
            string operatorTokenStr, string whenNotNullStr)
        {
            var expression = ParseExpression(expressionStr);
            var operatorToken = ParseToken(operatorTokenStr);
            var whenNotNull = ParseExpression(whenNotNullStr);
            return SyntaxFactory.ConditionalAccessExpression(expression, operatorToken, whenNotNull);
        }

        public static ConditionalAccessExpressionSyntax ConditionalAccessExpression(string expressionStr,
            string whenNotNullStr)
        {
            var expression = ParseExpression(expressionStr);
            var whenNotNull = ParseExpression(whenNotNullStr);
            return SyntaxFactory.ConditionalAccessExpression(expression, whenNotNull);
        }

        public static ElementBindingExpressionSyntax ElementBindingExpression(string argumentListStr)
        {
            var argumentList = ParseBracketedArgumentList(argumentListStr);
            return SyntaxFactory.ElementBindingExpression(argumentList);
        }

        public static ElementBindingExpressionSyntax ElementBindingExpression()
        {
            return SyntaxFactory.ElementBindingExpression();
        }

        public static ImplicitElementAccessSyntax ImplicitElementAccess(string argumentListStr)
        {
            var argumentList = ParseBracketedArgumentList(argumentListStr);
            return SyntaxFactory.ImplicitElementAccess(argumentList);
        }

        public static ImplicitElementAccessSyntax ImplicitElementAccess()
        {
            return SyntaxFactory.ImplicitElementAccess();
        }

        public static ConditionalExpressionSyntax ConditionalExpression(string conditionStr, string questionTokenStr,
            string whenTrueStr, string colonTokenStr, string whenFalseStr)
        {
            var condition = ParseExpression(conditionStr);
            var questionToken = ParseToken(questionTokenStr);
            var whenTrue = ParseExpression(whenTrueStr);
            var colonToken = ParseToken(colonTokenStr);
            var whenFalse = ParseExpression(whenFalseStr);
            return SyntaxFactory.ConditionalExpression(condition, questionToken, whenTrue, colonToken, whenFalse);
        }

        public static ConditionalExpressionSyntax ConditionalExpression(string conditionStr, string whenTrueStr,
            string whenFalseStr)
        {
            var condition = ParseExpression(conditionStr);
            var whenTrue = ParseExpression(whenTrueStr);
            var whenFalse = ParseExpression(whenFalseStr);
            return SyntaxFactory.ConditionalExpression(condition, whenTrue, whenFalse);
        }

        public static ThisExpressionSyntax ThisExpression(string tokenStr)
        {
            var token = ParseToken(tokenStr);
            return SyntaxFactory.ThisExpression(token);
        }

        public static ThisExpressionSyntax ThisExpression()
        {
            return SyntaxFactory.ThisExpression();
        }

        public static BaseExpressionSyntax BaseExpression(string tokenStr)
        {
            var token = ParseToken(tokenStr);
            return SyntaxFactory.BaseExpression(token);
        }

        public static BaseExpressionSyntax BaseExpression()
        {
            return SyntaxFactory.BaseExpression();
        }

        public static MakeRefExpressionSyntax MakeRefExpression(string keywordStr, string openParenTokenStr,
            string expressionStr, string closeParenTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var expression = ParseExpression(expressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.MakeRefExpression(keyword, openParenToken, expression, closeParenToken);
        }

        public static MakeRefExpressionSyntax MakeRefExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.MakeRefExpression(expression);
        }

        public static RefTypeExpressionSyntax RefTypeExpression(string keywordStr, string openParenTokenStr,
            string expressionStr, string closeParenTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var expression = ParseExpression(expressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.RefTypeExpression(keyword, openParenToken, expression, closeParenToken);
        }

        public static RefTypeExpressionSyntax RefTypeExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.RefTypeExpression(expression);
        }

        public static RefValueExpressionSyntax RefValueExpression(string keywordStr, string openParenTokenStr,
            string expressionStr, string commaStr, string typeStr, string closeParenTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var expression = ParseExpression(expressionStr);
            var comma = ParseToken(commaStr);
            var type = ParseTypeName(typeStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.RefValueExpression(keyword, openParenToken, expression, comma, type, closeParenToken);
        }

        public static RefValueExpressionSyntax RefValueExpression(string expressionStr, string typeStr)
        {
            var expression = ParseExpression(expressionStr);
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.RefValueExpression(expression, type);
        }

        public static DefaultExpressionSyntax DefaultExpression(string keywordStr, string openParenTokenStr,
            string typeStr, string closeParenTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var type = ParseTypeName(typeStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.DefaultExpression(keyword, openParenToken, type, closeParenToken);
        }

        public static DefaultExpressionSyntax DefaultExpression(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.DefaultExpression(type);
        }

        public static TypeOfExpressionSyntax TypeOfExpression(string keywordStr, string openParenTokenStr,
            string typeStr, string closeParenTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var type = ParseTypeName(typeStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.TypeOfExpression(keyword, openParenToken, type, closeParenToken);
        }

        public static TypeOfExpressionSyntax TypeOfExpression(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.TypeOfExpression(type);
        }

        public static SizeOfExpressionSyntax SizeOfExpression(string keywordStr, string openParenTokenStr,
            string typeStr, string closeParenTokenStr)
        {
            var keyword = ParseToken(keywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var type = ParseTypeName(typeStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            return SyntaxFactory.SizeOfExpression(keyword, openParenToken, type, closeParenToken);
        }

        public static SizeOfExpressionSyntax SizeOfExpression(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.SizeOfExpression(type);
        }

        public static InvocationExpressionSyntax InvocationExpression(string expressionStr, string argumentListStr)
        {
            var expression = ParseExpression(expressionStr);
            var argumentList = ParseArgumentList(argumentListStr);
            return SyntaxFactory.InvocationExpression(expression, argumentList);
        }

        public static InvocationExpressionSyntax InvocationExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.InvocationExpression(expression);
        }

        public static ElementAccessExpressionSyntax ElementAccessExpression(string expressionStr,
            string argumentListStr)
        {
            var expression = ParseExpression(expressionStr);
            var argumentList = ParseBracketedArgumentList(argumentListStr);
            return SyntaxFactory.ElementAccessExpression(expression, argumentList);
        }

        public static ElementAccessExpressionSyntax ElementAccessExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.ElementAccessExpression(expression);
        }

        public static ArgumentSyntax Argument(string nameColonStr, string refOrOutKeywordStr, string expressionStr)
        {
            var nameColon = NameColon(nameColonStr);
            var refOrOutKeyword = ParseToken(refOrOutKeywordStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.Argument(nameColon, refOrOutKeyword, expression);
        }

        public static ArgumentSyntax Argument(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.Argument(expression);
        }

        public static NameColonSyntax NameColon(string nameStr, string colonTokenStr)
        {
            var name = IdentifierName(nameStr);
            var colonToken = ParseToken(colonTokenStr);
            return SyntaxFactory.NameColon(name, colonToken);
        }

        public static CastExpressionSyntax CastExpression(string openParenTokenStr, string typeStr,
            string closeParenTokenStr, string expressionStr)
        {
            var openParenToken = ParseToken(openParenTokenStr);
            var type = ParseTypeName(typeStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.CastExpression(openParenToken, type, closeParenToken, expression);
        }

        public static CastExpressionSyntax CastExpression(string typeStr, string expressionStr)
        {
            var type = ParseTypeName(typeStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.CastExpression(type, expression);
        }

        public static ObjectCreationExpressionSyntax ObjectCreationExpression(string typeStr)
        {
            var type = ParseTypeName(typeStr);
            return SyntaxFactory.ObjectCreationExpression(type);
        }

        public static AnonymousObjectMemberDeclaratorSyntax AnonymousObjectMemberDeclarator(string nameEqualsStr,
            string expressionStr)
        {
            var nameEquals = NameEquals(nameEqualsStr);
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.AnonymousObjectMemberDeclarator(nameEquals, expression);
        }

        public static AnonymousObjectMemberDeclaratorSyntax AnonymousObjectMemberDeclarator(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.AnonymousObjectMemberDeclarator(expression);
        }

        public static SyntaxNodeOrTokenList NodeOrTokenList()
        {
            return SyntaxFactory.NodeOrTokenList();
        }

        public static bool AreEquivalent(string oldTokenStr, string newTokenStr)
        {
            var oldToken = ParseToken(oldTokenStr);
            var newToken = ParseToken(newTokenStr);
            return SyntaxFactory.AreEquivalent(oldToken, newToken);
        }

        public static ExpressionSyntax GetStandaloneExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.GetStandaloneExpression(expression);
        }

        public static ExpressionSyntax GetNonGenericExpression(string expressionStr)
        {
            var expression = ParseExpression(expressionStr);
            return SyntaxFactory.GetNonGenericExpression(expression);
        }

        public static bool IsCompleteSubmission(string treeStr)
        {
            var tree = ParseSyntaxTree(treeStr);
            return SyntaxFactory.IsCompleteSubmission(tree);
        }

        public static CaseSwitchLabelSyntax CaseSwitchLabel(string valueStr)
        {
            var value = ParseExpression(valueStr);
            return SyntaxFactory.CaseSwitchLabel(value);
        }

        public static DefaultSwitchLabelSyntax DefaultSwitchLabel()
        {
            return SyntaxFactory.DefaultSwitchLabel();
        }

        public static UsingDirectiveSyntax UsingDirective(string aliasStr, string nameStr)
        {
            var alias = NameEquals(aliasStr);
            var name = ParseName(nameStr);
            return SyntaxFactory.UsingDirective(alias, name);
        }

        public static PredefinedTypeSyntax PredefinedType(string keywordStr)
        {
            var keyword = ParseToken(keywordStr);
            return SyntaxFactory.PredefinedType(keyword);
        }

        public static ArrayTypeSyntax ArrayType(string elementTypeStr)
        {
            var elementType = ParseTypeName(elementTypeStr);
            return SyntaxFactory.ArrayType(elementType);
        }

        public static PointerTypeSyntax PointerType(string elementTypeStr, string asteriskTokenStr)
        {
            var elementType = ParseTypeName(elementTypeStr);
            var asteriskToken = ParseToken(asteriskTokenStr);
            return SyntaxFactory.PointerType(elementType, asteriskToken);
        }

        public static PointerTypeSyntax PointerType(string elementTypeStr)
        {
            var elementType = ParseTypeName(elementTypeStr);
            return SyntaxFactory.PointerType(elementType);
        }

        public static NullableTypeSyntax NullableType(string elementTypeStr, string questionTokenStr)
        {
            var elementType = ParseTypeName(elementTypeStr);
            var questionToken = ParseToken(questionTokenStr);
            return SyntaxFactory.NullableType(elementType, questionToken);
        }

        public static NullableTypeSyntax NullableType(string elementTypeStr)
        {
            var elementType = ParseTypeName(elementTypeStr);
            return SyntaxFactory.NullableType(elementType);
        }

        public static OmittedTypeArgumentSyntax OmittedTypeArgument(string omittedTypeArgumentTokenStr)
        {
            var omittedTypeArgumentToken = ParseToken(omittedTypeArgumentTokenStr);
            return SyntaxFactory.OmittedTypeArgument(omittedTypeArgumentToken);
        }

        public static AnonymousMethodExpressionSyntax AnonymousMethodExpression()
        {
            return SyntaxFactory.AnonymousMethodExpression();
        }

        //public static SyntaxList<TNode>  List()
        //{
        //    return SyntaxFactory.List();               
        //}
        public static SyntaxTokenList TokenList()
        {
            return SyntaxFactory.TokenList();
        }

        //public static SyntaxTokenList TokenList(string tokensStr)
        //{
        //    var tokens = ParseTokens(tokensStr); 
        //    return SyntaxFactory.TokenList(tokens);               
        //}
        public static SyntaxTriviaList TriviaList()
        {
            return SyntaxFactory.TriviaList();
        }

        public static SyntaxTriviaList TriviaList(string triviaStr)
        {
            var trivia = EndOfLine(triviaStr);
            return SyntaxFactory.TriviaList(trivia);
        }

        //public static SeparatedSyntaxList<TNode>  SeparatedList()
        //{
        //    return SyntaxFactory.SeparatedList();               
        //}
        //public static String ToString()
        //{
        //    return SyntaxFactory.ToString();               
        //}
        //public static Int32 GetHashCode()
        //{
        //    return SyntaxFactory.GetHashCode();               
        //}
        //public static Type GetType()
        //{
        //    return SyntaxFactory.GetType();               
        //}
        public static PragmaWarningDirectiveTriviaSyntax PragmaWarningDirectiveTrivia(string disableOrRestoreKeywordStr,
            string isActiveStr)
        {
            var disableOrRestoreKeyword = ParseToken(disableOrRestoreKeywordStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.PragmaWarningDirectiveTrivia(disableOrRestoreKeyword, isActive);
        }

        public static PragmaChecksumDirectiveTriviaSyntax PragmaChecksumDirectiveTrivia(string hashTokenStr,
            string pragmaKeywordStr, string checksumKeywordStr, string fileStr, string guidStr, string bytesStr,
            string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var pragmaKeyword = ParseToken(pragmaKeywordStr);
            var checksumKeyword = ParseToken(checksumKeywordStr);
            var file = ParseToken(fileStr);
            var guid = ParseToken(guidStr);
            var bytes = ParseToken(bytesStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.PragmaChecksumDirectiveTrivia(hashToken, pragmaKeyword, checksumKeyword, file, guid,
                bytes, endOfDirectiveToken, isActive);
        }

        public static PragmaChecksumDirectiveTriviaSyntax PragmaChecksumDirectiveTrivia(string fileStr, string guidStr,
            string bytesStr, string isActiveStr)
        {
            var file = ParseToken(fileStr);
            var guid = ParseToken(guidStr);
            var bytes = ParseToken(bytesStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.PragmaChecksumDirectiveTrivia(file, guid, bytes, isActive);
        }

        public static ReferenceDirectiveTriviaSyntax ReferenceDirectiveTrivia(string hashTokenStr,
            string referenceKeywordStr, string fileStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var referenceKeyword = ParseToken(referenceKeywordStr);
            var file = ParseToken(fileStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.ReferenceDirectiveTrivia(hashToken, referenceKeyword, file, endOfDirectiveToken,
                isActive);
        }

        public static ReferenceDirectiveTriviaSyntax ReferenceDirectiveTrivia(string fileStr, string isActiveStr)
        {
            var file = ParseToken(fileStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.ReferenceDirectiveTrivia(file, isActive);
        }

        public static LoadDirectiveTriviaSyntax LoadDirectiveTrivia(string hashTokenStr, string loadKeywordStr,
            string fileStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var loadKeyword = ParseToken(loadKeywordStr);
            var file = ParseToken(fileStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.LoadDirectiveTrivia(hashToken, loadKeyword, file, endOfDirectiveToken, isActive);
        }

        public static LoadDirectiveTriviaSyntax LoadDirectiveTrivia(string fileStr, string isActiveStr)
        {
            var file = ParseToken(fileStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.LoadDirectiveTrivia(file, isActive);
        }

        public static ShebangDirectiveTriviaSyntax ShebangDirectiveTrivia(string hashTokenStr,
            string exclamationTokenStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var exclamationToken = ParseToken(exclamationTokenStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.ShebangDirectiveTrivia(hashToken, exclamationToken, endOfDirectiveToken, isActive);
        }

        public static ShebangDirectiveTriviaSyntax ShebangDirectiveTrivia(string isActiveStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.ShebangDirectiveTrivia(isActive);
        }

        public static SkippedTokensTriviaSyntax SkippedTokensTrivia(string tokensStr)
        {
            var tokens = ParseTokenList(tokensStr);
            return SyntaxFactory.SkippedTokensTrivia(tokens);
        }

        public static IfDirectiveTriviaSyntax IfDirectiveTrivia(string hashTokenStr, string ifKeywordStr,
            string conditionStr, string endOfDirectiveTokenStr, string isActiveStr, string branchTakenStr,
            string conditionValueStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var ifKeyword = ParseToken(ifKeywordStr);
            var condition = ParseExpression(conditionStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            var branchTaken = IsCompleteSubmission(branchTakenStr);
            var conditionValue = IsCompleteSubmission(conditionValueStr);
            return SyntaxFactory.IfDirectiveTrivia(hashToken, ifKeyword, condition, endOfDirectiveToken, isActive,
                branchTaken, conditionValue);
        }

        public static IfDirectiveTriviaSyntax IfDirectiveTrivia(string conditionStr, string isActiveStr,
            string branchTakenStr, string conditionValueStr)
        {
            var condition = ParseExpression(conditionStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            var branchTaken = IsCompleteSubmission(branchTakenStr);
            var conditionValue = IsCompleteSubmission(conditionValueStr);
            return SyntaxFactory.IfDirectiveTrivia(condition, isActive, branchTaken, conditionValue);
        }

        public static ElifDirectiveTriviaSyntax ElifDirectiveTrivia(string hashTokenStr, string elifKeywordStr,
            string conditionStr, string endOfDirectiveTokenStr, string isActiveStr, string branchTakenStr,
            string conditionValueStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var elifKeyword = ParseToken(elifKeywordStr);
            var condition = ParseExpression(conditionStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            var branchTaken = IsCompleteSubmission(branchTakenStr);
            var conditionValue = IsCompleteSubmission(conditionValueStr);
            return SyntaxFactory.ElifDirectiveTrivia(hashToken, elifKeyword, condition, endOfDirectiveToken, isActive,
                branchTaken, conditionValue);
        }

        public static ElifDirectiveTriviaSyntax ElifDirectiveTrivia(string conditionStr, string isActiveStr,
            string branchTakenStr, string conditionValueStr)
        {
            var condition = ParseExpression(conditionStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            var branchTaken = IsCompleteSubmission(branchTakenStr);
            var conditionValue = IsCompleteSubmission(conditionValueStr);
            return SyntaxFactory.ElifDirectiveTrivia(condition, isActive, branchTaken, conditionValue);
        }

        public static ElseDirectiveTriviaSyntax ElseDirectiveTrivia(string hashTokenStr, string elseKeywordStr,
            string endOfDirectiveTokenStr, string isActiveStr, string branchTakenStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var elseKeyword = ParseToken(elseKeywordStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            var branchTaken = IsCompleteSubmission(branchTakenStr);
            return SyntaxFactory.ElseDirectiveTrivia(hashToken, elseKeyword, endOfDirectiveToken, isActive,
                branchTaken);
        }

        public static ElseDirectiveTriviaSyntax ElseDirectiveTrivia(string isActiveStr, string branchTakenStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            var branchTaken = IsCompleteSubmission(branchTakenStr);
            return SyntaxFactory.ElseDirectiveTrivia(isActive, branchTaken);
        }

        public static EndIfDirectiveTriviaSyntax EndIfDirectiveTrivia(string hashTokenStr, string endIfKeywordStr,
            string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var endIfKeyword = ParseToken(endIfKeywordStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.EndIfDirectiveTrivia(hashToken, endIfKeyword, endOfDirectiveToken, isActive);
        }

        public static EndIfDirectiveTriviaSyntax EndIfDirectiveTrivia(string isActiveStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.EndIfDirectiveTrivia(isActive);
        }

        public static RegionDirectiveTriviaSyntax RegionDirectiveTrivia(string hashTokenStr, string regionKeywordStr,
            string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var regionKeyword = ParseToken(regionKeywordStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.RegionDirectiveTrivia(hashToken, regionKeyword, endOfDirectiveToken, isActive);
        }

        public static RegionDirectiveTriviaSyntax RegionDirectiveTrivia(string isActiveStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.RegionDirectiveTrivia(isActive);
        }

        public static EndRegionDirectiveTriviaSyntax EndRegionDirectiveTrivia(string hashTokenStr,
            string endRegionKeywordStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var endRegionKeyword = ParseToken(endRegionKeywordStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.EndRegionDirectiveTrivia(hashToken, endRegionKeyword, endOfDirectiveToken, isActive);
        }

        public static EndRegionDirectiveTriviaSyntax EndRegionDirectiveTrivia(string isActiveStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.EndRegionDirectiveTrivia(isActive);
        }

        public static ErrorDirectiveTriviaSyntax ErrorDirectiveTrivia(string hashTokenStr, string errorKeywordStr,
            string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var errorKeyword = ParseToken(errorKeywordStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.ErrorDirectiveTrivia(hashToken, errorKeyword, endOfDirectiveToken, isActive);
        }

        public static ErrorDirectiveTriviaSyntax ErrorDirectiveTrivia(string isActiveStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.ErrorDirectiveTrivia(isActive);
        }

        public static WarningDirectiveTriviaSyntax WarningDirectiveTrivia(string hashTokenStr, string warningKeywordStr,
            string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var warningKeyword = ParseToken(warningKeywordStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.WarningDirectiveTrivia(hashToken, warningKeyword, endOfDirectiveToken, isActive);
        }

        public static WarningDirectiveTriviaSyntax WarningDirectiveTrivia(string isActiveStr)
        {
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.WarningDirectiveTrivia(isActive);
        }

        public static BadDirectiveTriviaSyntax BadDirectiveTrivia(string hashTokenStr, string identifierStr,
            string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var identifier = ParseToken(identifierStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.BadDirectiveTrivia(hashToken, identifier, endOfDirectiveToken, isActive);
        }

        public static BadDirectiveTriviaSyntax BadDirectiveTrivia(string identifierStr, string isActiveStr)
        {
            var identifier = ParseToken(identifierStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.BadDirectiveTrivia(identifier, isActive);
        }

        public static DefineDirectiveTriviaSyntax DefineDirectiveTrivia(string hashTokenStr, string defineKeywordStr,
            string nameStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var defineKeyword = ParseToken(defineKeywordStr);
            var name = ParseToken(nameStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.DefineDirectiveTrivia(hashToken, defineKeyword, name, endOfDirectiveToken, isActive);
        }

        public static DefineDirectiveTriviaSyntax DefineDirectiveTrivia(string nameStr, string isActiveStr)
        {
            var name = ParseToken(nameStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.DefineDirectiveTrivia(name, isActive);
        }

        public static UndefDirectiveTriviaSyntax UndefDirectiveTrivia(string hashTokenStr, string undefKeywordStr,
            string nameStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var undefKeyword = ParseToken(undefKeywordStr);
            var name = ParseToken(nameStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.UndefDirectiveTrivia(hashToken, undefKeyword, name, endOfDirectiveToken, isActive);
        }

        public static UndefDirectiveTriviaSyntax UndefDirectiveTrivia(string nameStr, string isActiveStr)
        {
            var name = ParseToken(nameStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.UndefDirectiveTrivia(name, isActive);
        }

        public static LineDirectiveTriviaSyntax LineDirectiveTrivia(string hashTokenStr, string lineKeywordStr,
            string lineStr, string fileStr, string endOfDirectiveTokenStr, string isActiveStr)
        {
            var hashToken = ParseToken(hashTokenStr);
            var lineKeyword = ParseToken(lineKeywordStr);
            var line = ParseToken(lineStr);
            var file = ParseToken(fileStr);
            var endOfDirectiveToken = ParseToken(endOfDirectiveTokenStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.LineDirectiveTrivia(hashToken, lineKeyword, line, file, endOfDirectiveToken, isActive);
        }

        public static LineDirectiveTriviaSyntax LineDirectiveTrivia(string lineStr, string fileStr, string isActiveStr)
        {
            var line = ParseToken(lineStr);
            var file = ParseToken(fileStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.LineDirectiveTrivia(line, file, isActive);
        }

        public static LineDirectiveTriviaSyntax LineDirectiveTrivia(string lineStr, string isActiveStr)
        {
            var line = ParseToken(lineStr);
            var isActive = IsCompleteSubmission(isActiveStr);
            return SyntaxFactory.LineDirectiveTrivia(line, isActive);
        }

        public static FieldDeclarationSyntax FieldDeclaration(string declarationStr)
        {
            var declaration = VariableDeclaration(declarationStr);
            return SyntaxFactory.FieldDeclaration(declaration);
        }

        public static EventFieldDeclarationSyntax EventFieldDeclaration(string declarationStr)
        {
            var declaration = VariableDeclaration(declarationStr);
            return SyntaxFactory.EventFieldDeclaration(declaration);
        }

        public static UsingStatementSyntax UsingStatement(string usingKeywordStr, string openParenTokenStr,
            string declarationStr, string expressionStr, string closeParenTokenStr, string statementStr)
        {
            var usingKeyword = ParseToken(usingKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var declaration = VariableDeclaration(declarationStr);
            var expression = ParseExpression(expressionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.UsingStatement(usingKeyword, openParenToken, declaration, expression, closeParenToken,
                statement);
        }

        public static UsingStatementSyntax UsingStatement(string declarationStr, string expressionStr,
            string statementStr)
        {
            var declaration = VariableDeclaration(declarationStr);
            var expression = ParseExpression(expressionStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.UsingStatement(declaration, expression, statement);
        }

        public static FixedStatementSyntax FixedStatement(string fixedKeywordStr, string openParenTokenStr,
            string declarationStr, string closeParenTokenStr, string statementStr)
        {
            var fixedKeyword = ParseToken(fixedKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var declaration = VariableDeclaration(declarationStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.FixedStatement(fixedKeyword, openParenToken, declaration, closeParenToken, statement);
        }

        public static FixedStatementSyntax FixedStatement(string declarationStr, string statementStr)
        {
            var declaration = VariableDeclaration(declarationStr);
            var statement = ParseStatement(statementStr);
            return SyntaxFactory.FixedStatement(declaration, statement);
        }

        public static IfStatementSyntax IfStatement(string ifKeywordStr, string openParenTokenStr, string conditionStr,
            string closeParenTokenStr, string statementStr, string elseStr)
        {
            var ifKeyword = ParseToken(ifKeywordStr);
            var openParenToken = ParseToken(openParenTokenStr);
            var condition = ParseExpression(conditionStr);
            var closeParenToken = ParseToken(closeParenTokenStr);
            var statement = ParseStatement(statementStr);
            var @else = ElseClause(elseStr);
            return SyntaxFactory.IfStatement(ifKeyword, openParenToken, condition, closeParenToken, statement, @else);
        }

        public static IfStatementSyntax IfStatement(string conditionStr, string statementStr, string elseStr)
        {
            var condition = ParseExpression(conditionStr);
            var statement = ParseStatement(statementStr);
            var @else = ElseClause(elseStr);
            return SyntaxFactory.IfStatement(condition, statement, @else);
        }

        public static ArrayCreationExpressionSyntax ArrayCreationExpression(string typeStr)
        {
            var type = ArrayType(typeStr);
            return SyntaxFactory.ArrayCreationExpression(type);
        }

        public static LocalDeclarationStatementSyntax LocalDeclarationStatement(string modifiersStr,
            string declarationStr, string semicolonTokenStr)
        {
            var modifiers = ParseTokenList(modifiersStr);
            var declaration = VariableDeclaration(declarationStr);
            var semicolonToken = ParseToken(semicolonTokenStr);
            return SyntaxFactory.LocalDeclarationStatement(modifiers, declaration, semicolonToken);
        }

        public static LocalDeclarationStatementSyntax LocalDeclarationStatement(string modifiersStr,
            string declarationStr)
        {
            var modifiers = ParseTokenList(modifiersStr);
            var declaration = VariableDeclaration(declarationStr);
            return SyntaxFactory.LocalDeclarationStatement(modifiers, declaration);
        }

        public static LocalDeclarationStatementSyntax LocalDeclarationStatement(string declarationStr)
        {
            var declaration = VariableDeclaration(declarationStr);
            return SyntaxFactory.LocalDeclarationStatement(declaration);
        }

        public static VariableDeclaratorSyntax VariableDeclarator(string identifierStr, string argumentListStr,
            string initializerStr)
        {
            var identifier = ParseToken(identifierStr);
            var argumentList = ParseBracketedArgumentList(argumentListStr);
            var initializer = EqualsValueClause(initializerStr);
            return SyntaxFactory.VariableDeclarator(identifier, argumentList, initializer);
        }

        public static bool AreEquivalent(string oldTreeStr, string newTreeStr, string topLevelStr)
        {
            var oldTree = ParseSyntaxTree(oldTreeStr);
            var newTree = ParseSyntaxTree(newTreeStr);
            var topLevel = IsCompleteSubmission(topLevelStr);
            return SyntaxFactory.AreEquivalent(oldTree, newTree, topLevel);
        }
    }
}