// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;

namespace Zu.TameRoslyn.Syntax
{
    public static class CreateSyntaxNode
    {
        public static SyntaxNode CreateFormCode(string code, string nodeType)
        {
            switch (nodeType)
            {
                case "AccessorDeclarationSyntax": return SyntaxFactoryStr.ParseAccessorDeclaration(code);
                case "AccessorListSyntax": return SyntaxFactoryStr.ParseAccessorList(code);
                case "AliasQualifiedNameSyntax": return SyntaxFactoryStr.ParseAliasQualifiedName(code);
                case "AnonymousFunctionExpressionSyntax":
                    return SyntaxFactoryStr.ParseAnonymousFunctionExpression(code);
                case "AnonymousMethodExpressionSyntax": return SyntaxFactoryStr.ParseAnonymousMethodExpression(code);
                case "AnonymousObjectCreationExpressionSyntax":
                    return SyntaxFactoryStr.ParseAnonymousObjectCreationExpression(code);
                case "AnonymousObjectMemberDeclaratorSyntax":
                    return SyntaxFactoryStr.ParseAnonymousObjectMemberDeclarator(code);
                case "ArgumentListSyntax": return SyntaxFactoryStr.ParseArgumentList(code);
                case "ArgumentSyntax": return SyntaxFactoryStr.ParseArgument(code);
                case "ArrayCreationExpressionSyntax": return SyntaxFactoryStr.ParseArrayCreationExpression(code);
                case "ArrayRankSpecifierSyntax": return SyntaxFactoryStr.ParseArrayRankSpecifier(code);
                case "ArrayTypeSyntax": return SyntaxFactoryStr.ParseArrayType(code);
                case "ArrowExpressionClauseSyntax": return SyntaxFactoryStr.ParseArrowExpressionClause(code);
                case "AssignmentExpressionSyntax": return SyntaxFactoryStr.ParseAssignmentExpression(code);
                case "AttributeArgumentListSyntax": return SyntaxFactoryStr.ParseAttributeArgumentList(code);
                case "AttributeArgumentSyntax": return SyntaxFactoryStr.ParseAttributeArgument(code);
                case "AttributeListSyntax": return SyntaxFactoryStr.ParseAttributeList(code);
                case "AttributeSyntax": return SyntaxFactoryStr.ParseAttribute(code);
                case "AttributeTargetSpecifierSyntax": return SyntaxFactoryStr.ParseAttributeTargetSpecifier(code);
                case "AwaitExpressionSyntax": return SyntaxFactoryStr.ParseAwaitExpression(code);
                case "BadDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseBadDirectiveTrivia(code);
                case "BaseArgumentListSyntax": return SyntaxFactoryStr.ParseBaseArgumentList(code);
                case "BaseCrefParameterListSyntax": return SyntaxFactoryStr.ParseBaseCrefParameterList(code);
                case "BaseExpressionSyntax": return SyntaxFactoryStr.ParseBaseExpression(code);
                case "BaseFieldDeclarationSyntax": return SyntaxFactoryStr.ParseBaseFieldDeclaration(code);
                case "BaseListSyntax": return SyntaxFactoryStr.ParseBaseList(code);
                case "BaseMethodDeclarationSyntax": return SyntaxFactoryStr.ParseBaseMethodDeclaration(code);
                case "BaseParameterListSyntax": return SyntaxFactoryStr.ParseBaseParameterList(code);
                case "BasePropertyDeclarationSyntax": return SyntaxFactoryStr.ParseBasePropertyDeclaration(code);
                case "BaseTypeDeclarationSyntax": return SyntaxFactoryStr.ParseBaseTypeDeclaration(code);
                case "BaseTypeSyntax": return SyntaxFactoryStr.ParseBaseType(code);
                case "BinaryExpressionSyntax": return SyntaxFactoryStr.ParseBinaryExpression(code);
                case "BlockSyntax": return SyntaxFactoryStr.ParseBlock(code);
                case "BracketedArgumentListSyntax": return SyntaxFactoryStr.ParseBracketedArgumentList(code);
                case "BracketedParameterListSyntax": return SyntaxFactoryStr.ParseBracketedParameterList(code);
                case "BranchingDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseBranchingDirectiveTrivia(code);
                case "BreakStatementSyntax": return SyntaxFactoryStr.ParseBreakStatement(code);
                case "CasePatternSwitchLabelSyntax": return SyntaxFactoryStr.ParseCasePatternSwitchLabel(code);
                case "CaseSwitchLabelSyntax": return SyntaxFactoryStr.ParseCaseSwitchLabel(code);
                case "CastExpressionSyntax": return SyntaxFactoryStr.ParseCastExpression(code);
                case "CatchClauseSyntax": return SyntaxFactoryStr.ParseCatchClause(code);
                case "CatchDeclarationSyntax": return SyntaxFactoryStr.ParseCatchDeclaration(code);
                case "CatchFilterClauseSyntax": return SyntaxFactoryStr.ParseCatchFilterClause(code);
                case "CheckedExpressionSyntax": return SyntaxFactoryStr.ParseCheckedExpression(code);
                case "CheckedStatementSyntax": return SyntaxFactoryStr.ParseCheckedStatement(code);
                case "ClassDeclarationSyntax": return SyntaxFactoryStr.ParseClassDeclaration(code);
                case "ClassOrStructConstraintSyntax": return SyntaxFactoryStr.ParseClassOrStructConstraint(code);
                case "CommonForEachStatementSyntax": return SyntaxFactoryStr.ParseCommonForEachStatement(code);
                case "CompilationUnitSyntax": return SyntaxFactoryStr.ParseCompilationUnit(code);
                case "ConditionalAccessExpressionSyntax":
                    return SyntaxFactoryStr.ParseConditionalAccessExpression(code);
                case "ConditionalDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseConditionalDirectiveTrivia(code);
                case "ConditionalExpressionSyntax": return SyntaxFactoryStr.ParseConditionalExpression(code);
                case "ConstantPatternSyntax": return SyntaxFactoryStr.ParseConstantPattern(code);
                case "ConstructorConstraintSyntax": return SyntaxFactoryStr.ParseConstructorConstraint(code);
                case "ConstructorDeclarationSyntax": return SyntaxFactoryStr.ParseConstructorDeclaration(code);
                case "ConstructorInitializerSyntax": return SyntaxFactoryStr.ParseConstructorInitializer(code);
                case "ContinueStatementSyntax": return SyntaxFactoryStr.ParseContinueStatement(code);
                case "ConversionOperatorDeclarationSyntax":
                    return SyntaxFactoryStr.ParseConversionOperatorDeclaration(code);
                case "ConversionOperatorMemberCrefSyntax":
                    return SyntaxFactoryStr.ParseConversionOperatorMemberCref(code);
                case "CrefBracketedParameterListSyntax": return SyntaxFactoryStr.ParseCrefBracketedParameterList(code);
                case "CrefParameterListSyntax": return SyntaxFactoryStr.ParseCrefParameterList(code);
                case "CrefParameterSyntax": return SyntaxFactoryStr.ParseCrefParameter(code);
                case "CrefSyntax": return SyntaxFactoryStr.ParseCref(code);
                case "DeclarationExpressionSyntax": return SyntaxFactoryStr.ParseDeclarationExpression(code);
                case "DeclarationPatternSyntax": return SyntaxFactoryStr.ParseDeclarationPattern(code);
                case "DefaultExpressionSyntax": return SyntaxFactoryStr.ParseDefaultExpression(code);
                case "DefaultSwitchLabelSyntax": return SyntaxFactoryStr.ParseDefaultSwitchLabel(code);
                case "DefineDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseDefineDirectiveTrivia(code);
                case "DelegateDeclarationSyntax": return SyntaxFactoryStr.ParseDelegateDeclaration(code);
                case "DestructorDeclarationSyntax": return SyntaxFactoryStr.ParseDestructorDeclaration(code);
                case "DirectiveTriviaSyntax": return SyntaxFactoryStr.ParseDirectiveTrivia(code);
                case "DiscardDesignationSyntax": return SyntaxFactoryStr.ParseDiscardDesignation(code);
                case "DocumentationCommentTriviaSyntax": return SyntaxFactoryStr.ParseDocumentationCommentTrivia(code);
                case "DoStatementSyntax": return SyntaxFactoryStr.ParseDoStatement(code);
                case "ElementAccessExpressionSyntax": return SyntaxFactoryStr.ParseElementAccessExpression(code);
                case "ElementBindingExpressionSyntax": return SyntaxFactoryStr.ParseElementBindingExpression(code);
                case "ElifDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseElifDirectiveTrivia(code);
                case "ElseClauseSyntax": return SyntaxFactoryStr.ParseElseClause(code);
                case "ElseDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseElseDirectiveTrivia(code);
                case "EmptyStatementSyntax": return SyntaxFactoryStr.ParseEmptyStatement(code);
                case "EndIfDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseEndIfDirectiveTrivia(code);
                case "EndRegionDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseEndRegionDirectiveTrivia(code);
                case "EnumDeclarationSyntax": return SyntaxFactoryStr.ParseEnumDeclaration(code);
                case "EnumMemberDeclarationSyntax": return SyntaxFactoryStr.ParseEnumMemberDeclaration(code);
                case "EqualsValueClauseSyntax": return SyntaxFactoryStr.ParseEqualsValueClause(code);
                case "ErrorDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseErrorDirectiveTrivia(code);
                case "EventDeclarationSyntax": return SyntaxFactoryStr.ParseEventDeclaration(code);
                case "EventFieldDeclarationSyntax": return SyntaxFactoryStr.ParseEventFieldDeclaration(code);
                case "ExplicitInterfaceSpecifierSyntax": return SyntaxFactoryStr.ParseExplicitInterfaceSpecifier(code);
                case "ExpressionStatementSyntax": return SyntaxFactoryStr.ParseExpressionStatement(code);
                case "ExpressionSyntax": return SyntaxFactoryStr.ParseExpression(code);
                case "ExternAliasDirectiveSyntax": return SyntaxFactoryStr.ParseExternAliasDirective(code);
                case "FieldDeclarationSyntax": return SyntaxFactoryStr.ParseFieldDeclaration(code);
                case "FinallyClauseSyntax": return SyntaxFactoryStr.ParseFinallyClause(code);
                case "FixedStatementSyntax": return SyntaxFactoryStr.ParseFixedStatement(code);
                case "ForEachStatementSyntax": return SyntaxFactoryStr.ParseForEachStatement(code);
                case "ForEachVariableStatementSyntax": return SyntaxFactoryStr.ParseForEachVariableStatement(code);
                case "ForStatementSyntax": return SyntaxFactoryStr.ParseForStatement(code);
                case "FromClauseSyntax": return SyntaxFactoryStr.ParseFromClause(code);
                case "GenericNameSyntax": return SyntaxFactoryStr.ParseGenericName(code);
                case "GlobalStatementSyntax": return SyntaxFactoryStr.ParseGlobalStatement(code);
                case "GotoStatementSyntax": return SyntaxFactoryStr.ParseGotoStatement(code);
                case "GroupClauseSyntax": return SyntaxFactoryStr.ParseGroupClause(code);
                case "IdentifierNameSyntax": return SyntaxFactoryStr.ParseIdentifierName(code);
                case "IfDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseIfDirectiveTrivia(code);
                case "IfStatementSyntax": return SyntaxFactoryStr.ParseIfStatement(code);
                case "ImplicitArrayCreationExpressionSyntax":
                    return SyntaxFactoryStr.ParseImplicitArrayCreationExpression(code);
                case "ImplicitElementAccessSyntax": return SyntaxFactoryStr.ParseImplicitElementAccess(code);
                case "IncompleteMemberSyntax": return SyntaxFactoryStr.ParseIncompleteMember(code);
                case "IndexerDeclarationSyntax": return SyntaxFactoryStr.ParseIndexerDeclaration(code);
                case "IndexerMemberCrefSyntax": return SyntaxFactoryStr.ParseIndexerMemberCref(code);
                case "InitializerExpressionSyntax": return SyntaxFactoryStr.ParseInitializerExpression(code);
                case "InstanceExpressionSyntax": return SyntaxFactoryStr.ParseInstanceExpression(code);
                case "InterfaceDeclarationSyntax": return SyntaxFactoryStr.ParseInterfaceDeclaration(code);
                case "InterpolatedStringContentSyntax": return SyntaxFactoryStr.ParseInterpolatedStringContent(code);
                case "InterpolatedStringExpressionSyntax":
                    return SyntaxFactoryStr.ParseInterpolatedStringExpression(code);
                case "InterpolatedStringTextSyntax": return SyntaxFactoryStr.ParseInterpolatedStringText(code);
                case "InterpolationAlignmentClauseSyntax":
                    return SyntaxFactoryStr.ParseInterpolationAlignmentClause(code);
                case "InterpolationFormatClauseSyntax": return SyntaxFactoryStr.ParseInterpolationFormatClause(code);
                case "InterpolationSyntax": return SyntaxFactoryStr.ParseInterpolation(code);
                case "InvocationExpressionSyntax": return SyntaxFactoryStr.ParseInvocationExpression(code);
                case "IsPatternExpressionSyntax": return SyntaxFactoryStr.ParseIsPatternExpression(code);
                case "JoinClauseSyntax": return SyntaxFactoryStr.ParseJoinClause(code);
                case "JoinIntoClauseSyntax": return SyntaxFactoryStr.ParseJoinIntoClause(code);
                case "LabeledStatementSyntax": return SyntaxFactoryStr.ParseLabeledStatement(code);
                case "LambdaExpressionSyntax": return SyntaxFactoryStr.ParseLambdaExpression(code);
                case "LetClauseSyntax": return SyntaxFactoryStr.ParseLetClause(code);
                case "LineDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseLineDirectiveTrivia(code);
                case "LiteralExpressionSyntax": return SyntaxFactoryStr.ParseLiteralExpression(code);
                case "LoadDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseLoadDirectiveTrivia(code);
                case "LocalDeclarationStatementSyntax": return SyntaxFactoryStr.ParseLocalDeclarationStatement(code);
                case "LocalFunctionStatementSyntax": return SyntaxFactoryStr.ParseLocalFunctionStatement(code);
                case "LockStatementSyntax": return SyntaxFactoryStr.ParseLockStatement(code);
                case "MakeRefExpressionSyntax": return SyntaxFactoryStr.ParseMakeRefExpression(code);
                case "MemberAccessExpressionSyntax": return SyntaxFactoryStr.ParseMemberAccessExpression(code);
                case "MemberBindingExpressionSyntax": return SyntaxFactoryStr.ParseMemberBindingExpression(code);
                case "MemberCrefSyntax": return SyntaxFactoryStr.ParseMemberCref(code);
                case "MemberDeclarationSyntax": return SyntaxFactoryStr.ParseMemberDeclaration(code);
                case "MethodDeclarationSyntax": return SyntaxFactoryStr.ParseMethodDeclaration(code);
                case "NameColonSyntax": return SyntaxFactoryStr.ParseNameColon(code);
                case "NameEqualsSyntax": return SyntaxFactoryStr.ParseNameEquals(code);
                case "NameMemberCrefSyntax": return SyntaxFactoryStr.ParseNameMemberCref(code);
                case "NamespaceDeclarationSyntax": return SyntaxFactoryStr.ParseNamespaceDeclaration(code);
                case "NameSyntax": return SyntaxFactoryStr.ParseName(code);
                case "NullableTypeSyntax": return SyntaxFactoryStr.ParseNullableType(code);
                case "ObjectCreationExpressionSyntax": return SyntaxFactoryStr.ParseObjectCreationExpression(code);
                case "OmittedArraySizeExpressionSyntax": return SyntaxFactoryStr.ParseOmittedArraySizeExpression(code);
                case "OmittedTypeArgumentSyntax": return SyntaxFactoryStr.ParseOmittedTypeArgument(code);
                case "OperatorDeclarationSyntax": return SyntaxFactoryStr.ParseOperatorDeclaration(code);
                case "OperatorMemberCrefSyntax": return SyntaxFactoryStr.ParseOperatorMemberCref(code);
                case "OrderByClauseSyntax": return SyntaxFactoryStr.ParseOrderByClause(code);
                case "OrderingSyntax": return SyntaxFactoryStr.ParseOrdering(code);
                case "ParameterListSyntax": return SyntaxFactoryStr.ParseParameterList(code);
                case "ParameterSyntax": return SyntaxFactoryStr.ParseParameter(code);
                case "ParenthesizedExpressionSyntax": return SyntaxFactoryStr.ParseParenthesizedExpression(code);
                case "ParenthesizedLambdaExpressionSyntax":
                    return SyntaxFactoryStr.ParseParenthesizedLambdaExpression(code);
                case "ParenthesizedVariableDesignationSyntax":
                    return SyntaxFactoryStr.ParseParenthesizedVariableDesignation(code);
                case "PatternSyntax": return SyntaxFactoryStr.ParsePattern(code);
                case "PointerTypeSyntax": return SyntaxFactoryStr.ParsePointerType(code);
                case "PostfixUnaryExpressionSyntax": return SyntaxFactoryStr.ParsePostfixUnaryExpression(code);
                case "PragmaChecksumDirectiveTriviaSyntax":
                    return SyntaxFactoryStr.ParsePragmaChecksumDirectiveTrivia(code);
                case "PragmaWarningDirectiveTriviaSyntax":
                    return SyntaxFactoryStr.ParsePragmaWarningDirectiveTrivia(code);
                case "PredefinedTypeSyntax": return SyntaxFactoryStr.ParsePredefinedType(code);
                case "PrefixUnaryExpressionSyntax": return SyntaxFactoryStr.ParsePrefixUnaryExpression(code);
                case "PropertyDeclarationSyntax": return SyntaxFactoryStr.ParsePropertyDeclaration(code);
                case "QualifiedCrefSyntax": return SyntaxFactoryStr.ParseQualifiedCref(code);
                case "QualifiedNameSyntax": return SyntaxFactoryStr.ParseQualifiedName(code);
                case "QueryBodySyntax": return SyntaxFactoryStr.ParseQueryBody(code);
                case "QueryClauseSyntax": return SyntaxFactoryStr.ParseQueryClause(code);
                case "QueryContinuationSyntax": return SyntaxFactoryStr.ParseQueryContinuation(code);
                case "QueryExpressionSyntax": return SyntaxFactoryStr.ParseQueryExpression(code);
                case "ReferenceDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseReferenceDirectiveTrivia(code);
                case "RefExpressionSyntax": return SyntaxFactoryStr.ParseRefExpression(code);
                case "RefTypeExpressionSyntax": return SyntaxFactoryStr.ParseRefTypeExpression(code);
                case "RefTypeSyntax": return SyntaxFactoryStr.ParseRefType(code);
                case "RefValueExpressionSyntax": return SyntaxFactoryStr.ParseRefValueExpression(code);
                case "RegionDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseRegionDirectiveTrivia(code);
                case "ReturnStatementSyntax": return SyntaxFactoryStr.ParseReturnStatement(code);
                case "SelectClauseSyntax": return SyntaxFactoryStr.ParseSelectClause(code);
                case "SelectOrGroupClauseSyntax": return SyntaxFactoryStr.ParseSelectOrGroupClause(code);
                case "ShebangDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseShebangDirectiveTrivia(code);
                case "SimpleBaseTypeSyntax": return SyntaxFactoryStr.ParseSimpleBaseType(code);
                case "SimpleLambdaExpressionSyntax": return SyntaxFactoryStr.ParseSimpleLambdaExpression(code);
                case "SimpleNameSyntax": return SyntaxFactoryStr.ParseSimpleName(code);
                case "SingleVariableDesignationSyntax": return SyntaxFactoryStr.ParseSingleVariableDesignation(code);
                case "SizeOfExpressionSyntax": return SyntaxFactoryStr.ParseSizeOfExpression(code);
                case "SkippedTokensTriviaSyntax": return SyntaxFactoryStr.ParseSkippedTokensTrivia(code);
                case "StackAllocArrayCreationExpressionSyntax":
                    return SyntaxFactoryStr.ParseStackAllocArrayCreationExpression(code);
                case "StatementSyntax": return SyntaxFactoryStr.ParseStatement(code);
                case "StructDeclarationSyntax": return SyntaxFactoryStr.ParseStructDeclaration(code);
                case "StructuredTriviaSyntax": return SyntaxFactoryStr.ParseStructuredTrivia(code);
                case "SwitchLabelSyntax": return SyntaxFactoryStr.ParseSwitchLabel(code);
                case "SwitchSectionSyntax": return SyntaxFactoryStr.ParseSwitchSection(code);
                case "SwitchStatementSyntax": return SyntaxFactoryStr.ParseSwitchStatement(code);
                case "ThisExpressionSyntax": return SyntaxFactoryStr.ParseThisExpression(code);
                case "ThrowExpressionSyntax": return SyntaxFactoryStr.ParseThrowExpression(code);
                case "ThrowStatementSyntax": return SyntaxFactoryStr.ParseThrowStatement(code);
                case "TryStatementSyntax": return SyntaxFactoryStr.ParseTryStatement(code);
                case "TupleElementSyntax": return SyntaxFactoryStr.ParseTupleElement(code);
                case "TupleExpressionSyntax": return SyntaxFactoryStr.ParseTupleExpression(code);
                case "TupleTypeSyntax": return SyntaxFactoryStr.ParseTupleType(code);
                case "TypeArgumentListSyntax": return SyntaxFactoryStr.ParseTypeArgumentList(code);
                case "TypeConstraintSyntax": return SyntaxFactoryStr.ParseTypeConstraint(code);
                case "TypeCrefSyntax": return SyntaxFactoryStr.ParseTypeCref(code);
                case "TypeDeclarationSyntax": return SyntaxFactoryStr.ParseTypeDeclaration(code);
                case "TypeOfExpressionSyntax": return SyntaxFactoryStr.ParseTypeOfExpression(code);
                case "TypeParameterConstraintClauseSyntax":
                    return SyntaxFactoryStr.ParseTypeParameterConstraintClause(code);
                case "TypeParameterConstraintSyntax": return SyntaxFactoryStr.ParseTypeParameterConstraint(code);
                case "TypeParameterListSyntax": return SyntaxFactoryStr.ParseTypeParameterList(code);
                case "TypeParameterSyntax": return SyntaxFactoryStr.ParseTypeParameter(code);
                case "TypeSyntax": return SyntaxFactoryStr.ParseType(code);
                case "UndefDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseUndefDirectiveTrivia(code);
                case "UnsafeStatementSyntax": return SyntaxFactoryStr.ParseUnsafeStatement(code);
                case "UsingDirectiveSyntax": return SyntaxFactoryStr.ParseUsingDirective(code);
                case "UsingStatementSyntax": return SyntaxFactoryStr.ParseUsingStatement(code);
                case "VariableDeclarationSyntax": return SyntaxFactoryStr.ParseVariableDeclaration(code);
                case "VariableDeclaratorSyntax": return SyntaxFactoryStr.ParseVariableDeclarator(code);
                case "VariableDesignationSyntax": return SyntaxFactoryStr.ParseVariableDesignation(code);
                case "WarningDirectiveTriviaSyntax": return SyntaxFactoryStr.ParseWarningDirectiveTrivia(code);
                case "WhenClauseSyntax": return SyntaxFactoryStr.ParseWhenClause(code);
                case "WhereClauseSyntax": return SyntaxFactoryStr.ParseWhereClause(code);
                case "WhileStatementSyntax": return SyntaxFactoryStr.ParseWhileStatement(code);
                case "XmlAttributeSyntax": return SyntaxFactoryStr.ParseXmlAttribute(code);
                case "XmlCDataSectionSyntax": return SyntaxFactoryStr.ParseXmlCDataSection(code);
                case "XmlCommentSyntax": return SyntaxFactoryStr.ParseXmlComment(code);
                case "XmlCrefAttributeSyntax": return SyntaxFactoryStr.ParseXmlCrefAttribute(code);
                case "XmlElementEndTagSyntax": return SyntaxFactoryStr.ParseXmlElementEndTag(code);
                case "XmlElementStartTagSyntax": return SyntaxFactoryStr.ParseXmlElementStartTag(code);
                case "XmlElementSyntax": return SyntaxFactoryStr.ParseXmlElement(code);
                case "XmlEmptyElementSyntax": return SyntaxFactoryStr.ParseXmlEmptyElement(code);
                case "XmlNameAttributeSyntax": return SyntaxFactoryStr.ParseXmlNameAttribute(code);
                case "XmlNameSyntax": return SyntaxFactoryStr.ParseXmlName(code);
                case "XmlNodeSyntax": return SyntaxFactoryStr.ParseXmlNode(code);
                case "XmlPrefixSyntax": return SyntaxFactoryStr.ParseXmlPrefix(code);
                case "XmlProcessingInstructionSyntax": return SyntaxFactoryStr.ParseXmlProcessingInstruction(code);
                case "XmlTextAttributeSyntax": return SyntaxFactoryStr.ParseXmlTextAttribute(code);
                case "XmlTextSyntax": return SyntaxFactoryStr.ParseXmlText(code);
                case "YieldStatementSyntax": return SyntaxFactoryStr.ParseYieldStatement(code);
            }
            return null;
        }
    }
}