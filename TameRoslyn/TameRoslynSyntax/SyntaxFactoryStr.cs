// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public static partial class SyntaxFactoryStr
    {
        public static LoadDirectiveTriviaSyntax ParseLoadDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static LiteralExpressionSyntax ParseLiteralExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<LiteralExpressionSyntax>().FirstOrDefault();
        }

        public static LineDirectiveTriviaSyntax ParseLineDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static IsPatternExpressionSyntax ParseIsPatternExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ if ({code}) {{}} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<IsPatternExpressionSyntax>().FirstOrDefault();
        }

        public static AnonymousObjectMemberDeclaratorSyntax ParseAnonymousObjectMemberDeclarator(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ var v = new {{ {code} }}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AnonymousObjectMemberDeclaratorSyntax>().FirstOrDefault();
        }

        public static ArrayCreationExpressionSyntax ParseArrayCreationExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ var v = {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ArrayCreationExpressionSyntax>().FirstOrDefault();
        }

        public static ArrayTypeSyntax ParseArrayType(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth({code} arr) {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ArrayTypeSyntax>().FirstOrDefault();
        }

        public static ArrowExpressionClauseSyntax ParseArrowExpressionClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ArrowExpressionClauseSyntax>().FirstOrDefault();
        }

        public static ArgumentSyntax ParseArgument(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ a({code}); }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ArgumentSyntax>().FirstOrDefault();
        }

        public static AttributeListSyntax ParseAttributeList(string code)
        {
            if (code == null)
                return null;
            var str = $"{code}\nvoid Meth() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeListSyntax>().FirstOrDefault();
        }

        public static AttributeTargetSpecifierSyntax ParseAttributeTargetSpecifier(string code)
        {
            if (code == null)
                return null;
            var str = $"[{code} Attribute()]\nvoid Meth() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeTargetSpecifierSyntax>().FirstOrDefault();
        }

        public static BadDirectiveTriviaSyntax ParseBadDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static AwaitExpressionSyntax ParseAwaitExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void async Meth() {{ {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AwaitExpressionSyntax>().FirstOrDefault();
        }

        public static BaseExpressionSyntax ParseBaseExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code}.Prop;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<BaseExpressionSyntax>().FirstOrDefault();
        }

        public static AttributeSyntax ParseAttribute(string code)
        {
            if (code == null)
                return null;
            var str = $"[attr: {code}]\nvoid Meth() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeSyntax>().FirstOrDefault();
        }

        public static AttributeArgumentSyntax ParseAttributeArgument(string code)
        {
            if (code == null)
                return null;
            var str = $"[attr: Attribute({code})]\nvoid Meth() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeArgumentSyntax>().FirstOrDefault();
        }

        public static ImplicitArrayCreationExpressionSyntax ParseImplicitArrayCreationExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ImplicitArrayCreationExpressionSyntax>().FirstOrDefault();
        }

        public static BaseExpressionSyntax ParseBaseType(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code}.Prop;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<BaseExpressionSyntax>().FirstOrDefault();
        }

        public static IfDirectiveTriviaSyntax ParseIfDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static ForEachVariableStatementSyntax ParseForEachVariableStatement(string code)
        {
            throw new NotImplementedException();
        }

        public static FinallyClauseSyntax ParseFinallyClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ try {{}} \n{code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<FinallyClauseSyntax>().FirstOrDefault();
        }

        public static CaseSwitchLabelSyntax ParseCaseSwitchLabel(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ switch (obj)  {{ {code} break; }} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<CaseSwitchLabelSyntax>().FirstOrDefault();
        }

        public static ElseDirectiveTriviaSyntax ParseElseDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static CatchFilterClauseSyntax ParseCatchFilterClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ try {{}} \ncatch (Exception e){code}{{}} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<CatchFilterClauseSyntax>().FirstOrDefault();
        }

        public static CaseSwitchLabelSyntax ParseCatchDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static ClassDeclarationSyntax ParseClassDeclaration(string code)
        {
            if (code == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(code);
            return st?.GetRoot()?.DescendantNodes().OfType<ClassDeclarationSyntax>().FirstOrDefault();
        }

        public static ElifDirectiveTriviaSyntax ParseElifDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static DocumentationCommentTriviaSyntax ParseDocumentationCommentTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static DiscardDesignationSyntax ParseDiscardDesignation(string code)
        {
            throw new NotImplementedException();
        }

        public static DirectiveTriviaSyntax ParseDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static DefineDirectiveTriviaSyntax ParseDefineDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static DeclarationPatternSyntax ParseDeclarationPattern(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ if (obj is {code}) {{}} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<DeclarationPatternSyntax>().FirstOrDefault();
        }

        public static DeclarationExpressionSyntax ParseDeclarationExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() {{ return o.TryGetValue(key, out {code} ); }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<DeclarationExpressionSyntax>().FirstOrDefault();
        }

        public static ConstructorDeclarationSyntax ParseConstructorDeclaration(string code)
        {
            if (code == null)
                return null;
            var m = ParseMethodDeclaration(code);
            var str = $"class {m.Identifier} {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ConstructorDeclarationSyntax>().FirstOrDefault();
        }

        public static CrefParameterSyntax ParseCrefParameter(string code)
        {
            throw new NotImplementedException();
        }

        public static ConstantPatternSyntax ParseConstantPattern(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ switch(o1) {{ case obj2 when obj3 == {code}: break; }} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ConstantPatternSyntax>().FirstOrDefault();
        }

        public static DefaultExpressionSyntax ParseDefaultExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<DefaultExpressionSyntax>().FirstOrDefault();
        }

        public static DefaultSwitchLabelSyntax ParseDefaultSwitchLabel(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ switch(o1) {{ case o2: break;{code} break; }} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<DefaultSwitchLabelSyntax>().FirstOrDefault();
        }

        public static ConditionalDirectiveTriviaSyntax ParseConditionalDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static DestructorDeclarationSyntax ParseDestructorDeclaration(string code)
        {
            if (code == null)
                return null;
            var m = ParseMethodDeclaration(code.TrimStart().TrimStart('~'));
            var str = $"class {m.Identifier} {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<DestructorDeclarationSyntax>().FirstOrDefault();
        }

        public static CommonForEachStatementSyntax ParseCommonForEachStatement(string code)
        {
            throw new NotImplementedException();
        }

        public static ElementAccessExpressionSyntax ParseElementAccessExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ElementAccessExpressionSyntax>().FirstOrDefault();
        }

        public static ElementBindingExpressionSyntax ParseElementBindingExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => obj{code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ElementBindingExpressionSyntax>().FirstOrDefault();
        }

        public static ElseClauseSyntax ParseElseClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ if(false) {{}}{code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ElseClauseSyntax>().FirstOrDefault();
        }

        public static EmptyStatementSyntax ParseEmptyStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<EmptyStatementSyntax>().FirstOrDefault();
        }

        public static EndRegionDirectiveTriviaSyntax ParseEndRegionDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static EnumMemberDeclarationSyntax ParseEnumMemberDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"enum E {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<EnumMemberDeclarationSyntax>().FirstOrDefault();
        }

        public static ErrorDirectiveTriviaSyntax ParseErrorDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static EventFieldDeclarationSyntax ParseEventFieldDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"class C {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<EventFieldDeclarationSyntax>().FirstOrDefault();
        }

        public static ExplicitInterfaceSpecifierSyntax ParseExplicitInterfaceSpecifier(string code)
        {
            if (code == null)
                return null;
            var str = $"void {code}.Do() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ExplicitInterfaceSpecifierSyntax>().FirstOrDefault();
        }

        public static ExpressionStatementSyntax ParseExpressionStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ExpressionStatementSyntax>().FirstOrDefault();
        }

        public static FieldDeclarationSyntax ParseFieldDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"class C {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<FieldDeclarationSyntax>().FirstOrDefault();
        }

        public static ExternAliasDirectiveSyntax ParseExternAliasDirective(string code)
        {
            if (code == null)
                return null;
            var str = $"{code}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ExternAliasDirectiveSyntax>().FirstOrDefault();
        }

        public static EqualsValueClauseSyntax ParseEqualsValueClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ var v {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<EqualsValueClauseSyntax>().FirstOrDefault();
        }

        public static ForStatementSyntax ParseForStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ForStatementSyntax>().FirstOrDefault();
        }

        public static GlobalStatementSyntax ParseGlobalStatement(string code)
        {
            throw new NotImplementedException();
        }

        public static GenericNameSyntax ParseGenericName(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth({code} v) {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<GenericNameSyntax>().FirstOrDefault();
        }

        public static IdentifierNameSyntax ParseIdentifierName(string code)
        {
            return IdentifierName(code);
        }

        public static EnumDeclarationSyntax ParseEnumDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"class C {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<EnumDeclarationSyntax>().FirstOrDefault();
        }

        public static ImplicitElementAccessSyntax ParseImplicitElementAccess(string code)
        {
            throw new NotImplementedException();
        }

        public static IndexerDeclarationSyntax ParseIndexerDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"class C {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<IndexerDeclarationSyntax>().FirstOrDefault();
        }

        public static IncompleteMemberSyntax ParseIncompleteMember(string code)
        {
            if (code == null)
                return null;
            var str = $"{code}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<IncompleteMemberSyntax>().FirstOrDefault();
        }

        public static InterfaceDeclarationSyntax ParseInterfaceDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"{code}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InterfaceDeclarationSyntax>().FirstOrDefault();
        }

        public static EndIfDirectiveTriviaSyntax ParseEndIfDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static InterpolatedStringTextSyntax ParseInterpolatedStringText(string code)
        {
            if (code == null)
                return null;
            var str = $"string Meth() => $\"{code}{{obj}}\";";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InterpolatedStringTextSyntax>().FirstOrDefault();
        }

        public static InterpolatedStringExpressionSyntax ParseInterpolatedStringExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"string Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InterpolatedStringExpressionSyntax>().FirstOrDefault();
        }

        public static InterpolationSyntax ParseInterpolation(string code)
        {
            if (code == null)
                return null;
            var str = $"string Meth() => $\"{code}\";";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InterpolationSyntax>().FirstOrDefault();
        }

        public static InvocationExpressionSyntax ParseInvocationExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InvocationExpressionSyntax>().FirstOrDefault();
        }

        public static JoinIntoClauseSyntax ParseJoinIntoClause(string code)
        {
            throw new NotImplementedException();
        }

        public static InterpolationFormatClauseSyntax ParseInterpolationFormatClause(string code)
        {
            if (code == null)
                return null;
            var str = $"string Meth() => $\"{{obj{code}}}\";";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InterpolationFormatClauseSyntax>().FirstOrDefault();
        }

        public static ClassOrStructConstraintSyntax ParseClassOrStructConstraint(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth<T>() where T : {code}{{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ClassOrStructConstraintSyntax>().FirstOrDefault();
        }

        public static CasePatternSwitchLabelSyntax ParseCasePatternSwitchLabel(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ switch (obj)  {{ {code} break; }} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<CasePatternSwitchLabelSyntax>().FirstOrDefault();
        }

        public static LocalFunctionStatementSyntax ParseLocalFunctionStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<LocalFunctionStatementSyntax>().FirstOrDefault();
        }

        public static MakeRefExpressionSyntax ParseMakeRefExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static LocalDeclarationStatementSyntax ParseLocalDeclarationStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<LocalDeclarationStatementSyntax>().FirstOrDefault();
        }

        public static MemberBindingExpressionSyntax ParseMemberBindingExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ var v = o.{code}(); }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<MemberBindingExpressionSyntax>().FirstOrDefault();
        }

        public static BranchingDirectiveTriviaSyntax ParseBranchingDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static NameEqualsSyntax ParseNameEquals(string code)
        {
            if (code == null)
                return null;
            var str = $"using {code} Microsoft.CodeAnalysis; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<NameEqualsSyntax>().FirstOrDefault();
        }

        public static NamespaceDeclarationSyntax ParseNamespaceDeclaration(string code)
        {
            if (code == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(code);
            return st?.GetRoot()?.DescendantNodes().OfType<NamespaceDeclarationSyntax>().FirstOrDefault();
        }

        public static NullableTypeSyntax ParseNullableType(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth({code} o) {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<NullableTypeSyntax>().FirstOrDefault();
        }

        public static ObjectCreationExpressionSyntax ParseObjectCreationExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ObjectCreationExpressionSyntax>().FirstOrDefault();
        }

        public static OmittedTypeArgumentSyntax ParseOmittedTypeArgument(string code)
        {
            throw new NotImplementedException();
        }

        public static OperatorMemberCrefSyntax ParseOperatorMemberCref(string code)
        {
            throw new NotImplementedException();
        }

        public static OmittedArraySizeExpressionSyntax ParseOmittedArraySizeExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"byte[{code}] Meth() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<OmittedArraySizeExpressionSyntax>().FirstOrDefault();
        }

        public static ParenthesizedExpressionSyntax ParseParenthesizedExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ParenthesizedExpressionSyntax>().FirstOrDefault();
        }

        public static ParenthesizedVariableDesignationSyntax ParseParenthesizedVariableDesignation(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ var{code} = m(); }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ParenthesizedVariableDesignationSyntax>().FirstOrDefault();
        }

        public static PatternSyntax ParsePattern(string code)
        {
            throw new NotImplementedException();
        }

        public static PointerTypeSyntax ParsePointerType(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth({code}ptr) {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<PointerTypeSyntax>().FirstOrDefault();
        }

        public static PragmaChecksumDirectiveTriviaSyntax ParsePragmaChecksumDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static PredefinedTypeSyntax ParsePredefinedType(string code)
        {
            if (code == null)
                return null;
            var str = $"{code} Meth() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<PredefinedTypeSyntax>().FirstOrDefault();
        }

        public static PragmaWarningDirectiveTriviaSyntax ParsePragmaWarningDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static PropertyDeclarationSyntax ParsePropertyDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"class C {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<PropertyDeclarationSyntax>().FirstOrDefault();
        }

        public static QueryBodySyntax ParseQueryBody(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<QueryBodySyntax>().FirstOrDefault();
        }

        public static NameMemberCrefSyntax ParseNameMemberCref(string code)
        {
            throw new NotImplementedException();
        }

        public static ReferenceDirectiveTriviaSyntax ParseReferenceDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static RefExpressionSyntax ParseRefExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static RefTypeSyntax ParseRefType(string code)
        {
            throw new NotImplementedException();
        }

        public static RegionDirectiveTriviaSyntax ParseRegionDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static SelectClauseSyntax ParseSelectClause(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => from n in numbers {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<SelectClauseSyntax>().FirstOrDefault();
        }

        public static ReturnStatementSyntax ParseReturnStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ReturnStatementSyntax>().FirstOrDefault();
        }

        public static SimpleBaseTypeSyntax ParseSimpleBaseType(string code)
        {
            if (code == null)
                return null;
            var str = $"class C : {code} {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<SimpleBaseTypeSyntax>().FirstOrDefault();
        }

        public static ShebangDirectiveTriviaSyntax ParseShebangDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static SingleVariableDesignationSyntax ParseSingleVariableDesignation(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth(out var {code}) {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<SingleVariableDesignationSyntax>().FirstOrDefault();
        }

        public static SkippedTokensTriviaSyntax ParseSkippedTokensTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static StackAllocArrayCreationExpressionSyntax ParseStackAllocArrayCreationExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static StructDeclarationSyntax ParseStructDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"{code}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<StructDeclarationSyntax>().FirstOrDefault();
        }

        public static StructuredTriviaSyntax ParseStructuredTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static SwitchStatementSyntax ParseSwitchStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<SwitchStatementSyntax>().FirstOrDefault();
        }

        public static ThrowExpressionSyntax ParseThrowExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ThrowExpressionSyntax>().FirstOrDefault();
        }

        public static ThrowStatementSyntax ParseThrowStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ThrowStatementSyntax>().FirstOrDefault();
        }

        public static TupleElementSyntax ParseTupleElement(string code)
        {
            if (code == null)
                return null;
            var str = $"({code}, int i) Meth() => null;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TupleElementSyntax>().FirstOrDefault();
        }

        public static TupleTypeSyntax ParseTupleType(string code)
        {
            if (code == null)
                return null;
            var str = $"{code} Meth() => null;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TupleTypeSyntax>().FirstOrDefault();
        }

        public static TypeConstraintSyntax ParseTypeConstraint(string code)
        {
            if (code == null)
                return null;
            var str = $"class C<T> where T: class, {code} {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TypeConstraintSyntax>().FirstOrDefault();
        }

        public static TypeCrefSyntax ParseTypeCref(string code)
        {
            throw new NotImplementedException();
        }

        public static TypeOfExpressionSyntax ParseTypeOfExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TypeOfExpressionSyntax>().FirstOrDefault();
        }

        public static TypeParameterConstraintClauseSyntax ParseTypeParameterConstraintClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth<T>(){code} {{ }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TypeParameterConstraintClauseSyntax>().FirstOrDefault();
        }

        public static TupleExpressionSyntax ParseTupleExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TupleExpressionSyntax>().FirstOrDefault();
        }

        public static TypeSyntax ParseType(string code)
        {
            throw new NotImplementedException();
        }

        public static UnsafeStatementSyntax ParseUnsafeStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<UnsafeStatementSyntax>().FirstOrDefault();
        }

        public static UsingStatementSyntax ParseUsingStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<UsingStatementSyntax>().FirstOrDefault();
        }

        public static VariableDeclarationSyntax ParseVariableDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<VariableDeclarationSyntax>().FirstOrDefault();
        }

        public static VariableDesignationSyntax ParseVariableDesignation(string code)
        {
            throw new NotImplementedException();
        }

        public static WhenClauseSyntax ParseWhenClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ switch(o) {{ case o2 {code}: break; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<WhenClauseSyntax>().FirstOrDefault();
        }

        public static WhereClauseSyntax ParseWhereClause(string code)
        {
            if (code == null)
                return null;
            var str = $"object Meth() {{ return from n in numbers {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<WhereClauseSyntax>().FirstOrDefault();
        }

        public static WarningDirectiveTriviaSyntax ParseWarningDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static VariableDeclaratorSyntax ParseVariableDeclarator(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ var {code}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<VariableDeclaratorSyntax>().FirstOrDefault();
        }

        public static UsingDirectiveSyntax ParseUsingDirective(string code)
        {
            if (code == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(code);
            return st?.GetRoot()?.DescendantNodes().OfType<UsingDirectiveSyntax>().FirstOrDefault();
        }

        public static UndefDirectiveTriviaSyntax ParseUndefDirectiveTrivia(string code)
        {
            throw new NotImplementedException();
        }

        public static TypeParameterSyntax ParseTypeParameter(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth<{code}>() {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TypeParameterSyntax>().FirstOrDefault();
        }

        public static ThisExpressionSyntax ParseThisExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code}.Name = name; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ThisExpressionSyntax>().FirstOrDefault();
        }

        public static SizeOfExpressionSyntax ParseSizeOfExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<SizeOfExpressionSyntax>().FirstOrDefault();
        }

        public static RefTypeExpressionSyntax ParseRefTypeExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlTextSyntax ParseXmlText(string code)
        {
            throw new NotImplementedException();
        }

        public static NameColonSyntax ParseNameColon(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ m({code} x); }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<NameColonSyntax>().FirstOrDefault();
        }

        public static BreakStatementSyntax ParseBreakStatement(string code)
        {
            return SyntaxFactory.BreakStatement();
        }

        public static PatternSyntax ParsePatternSyntax(string patternStr)
        {
            throw new NotImplementedException();
        }

        public static SyntaxToken ParseSyntaxToken(string str, SyntaxKind kind = SyntaxKind.None)
        {
            if (kind != SyntaxKind.None)
            {
                if (string.IsNullOrWhiteSpace(str))
                    return SyntaxFactory.Token(default(SyntaxTriviaList), kind, default(SyntaxTriviaList));
                return SyntaxFactory.Token(default(SyntaxTriviaList), kind, str, str, default(SyntaxTriviaList));
            }
            var sk = SyntaxFacts.GetKeywordKind(str); //.Trim()
            if (sk != SyntaxKind.None)
                return SyntaxFactory.Token(sk);
            if (string.IsNullOrWhiteSpace(str)) return default(SyntaxToken);
            sk = SyntaxFacts.GetContextualKeywordKind(str); //.Trim()
            if (sk != SyntaxKind.None)
                return SyntaxFactory.Token(sk);
            if (kind != SyntaxKind.None)
                if (kind == SyntaxKind.CharacterLiteralToken)
                    if (str.Length == 1)
                    {
                        return
                            SyntaxFactory
                                .Literal(
                                    str[
                                        0]); // Token(sk);// SyntaxFactory.LiteralExpression(kind, SyntaxFactory.Token(sk)); // SyntaxFactory.Token(default(SyntaxTriviaList), kind, "'" + str + "'", str, default(SyntaxTriviaList));
                    }
                    else
                    {
                        int i;
                        double d;
                        long l;
                        bool b;
                        if (str.Length > 1 && str.StartsWith("\"") && str.EndsWith("\""))
                            return SyntaxFactory.Literal(str.Substring(1, str.Length - 2));
                        if (str.Length > 1 && str.StartsWith("'") && str.EndsWith("'"))
                            return SyntaxFactory.Literal(str.Substring(1, str.Length - 2)[0]);
                        if (int.TryParse(str, out i))
                            return SyntaxFactory.Literal(i);
                        if (double.TryParse(str, out d))
                            return SyntaxFactory.Literal(d);
                        if (long.TryParse(str, out l))
                            return SyntaxFactory.Literal(l);
                        //else if(bool.TryParse(str, out b)) return SyntaxFactory.Literal(b);
                        return SyntaxFactory.Literal(str);
                    }
                else
                    return SyntaxFactory.Token(default(SyntaxTriviaList), kind, str, str, default(SyntaxTriviaList));

            return SyntaxFactory.ParseToken(str);
        }

        public static SyntaxTokenList ParseSyntaxTokenList(string str)
        {
            return new SyntaxTokenList().AddRange(
                from s in str.Split(',', ' ') select SyntaxFactory.ParseToken(s.Trim()));
        }

        public static FromClauseSyntax ParseFromClauseSyntax(string fromClauseStr)
        {
            if (fromClauseStr == null)
                return null;
            var str = $"void Meth() => {fromClauseStr.Trim()};";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>()?.FirstOrDefault();
        }

        public static BaseArgumentListSyntax ParseBaseArgumentList(string code)
        {
            throw new NotImplementedException();
        }

        public static AssignmentExpressionSyntax ParseAssignmentExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AssignmentExpressionSyntax>()?.FirstOrDefault();
        }

        public static CrefSyntax ParseCref(string code)
        {
            throw new NotImplementedException();
        }

        public static BaseFieldDeclarationSyntax ParseBaseFieldDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static BinaryExpressionSyntax ParseBinaryExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() =>  {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<BinaryExpressionSyntax>()?.FirstOrDefault();
        }

        public static BaseMethodDeclarationSyntax ParseBaseMethodDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static BasePropertyDeclarationSyntax ParseBasePropertyDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static InitializerExpressionSyntax ParseInitializerExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => new vs(){code}; ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<InitializerExpressionSyntax>()?.FirstOrDefault();
        }

        public static CheckedStatementSyntax ParseCheckedStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() 
            {{
                    {code}
                    return;
            }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<CheckedStatementSyntax>()?.FirstOrDefault();
        }

        public static InterpolatedStringContentSyntax ParseInterpolatedStringContent(string code)
        {
            throw new NotImplementedException();
        }

        public static CrefParameterListSyntax ParseCrefParameterList(string code)
        {
            throw new NotImplementedException();
        }

        public static GotoStatementSyntax ParseGotoStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{
            {code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<GotoStatementSyntax>()?.FirstOrDefault();
        }

        public static MemberDeclarationSyntax ParseMemberDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static OrderByClauseSyntax ParseOrderByClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => from v in vs {code} select v; ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<OrderByClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<OrderByClauseSyntax>()?.FirstOrDefault();
        }

        public static MemberAccessExpressionSyntax ParseMemberAccessExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() =>  {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<MemberAccessExpressionSyntax>()?.FirstOrDefault();
        }

        public static QueryClauseSyntax ParseQueryClause(string code)
        {
            throw new NotImplementedException();
        }

        //public static SeparatedWithManyChildrenSyntax ParseSeparatedWithManyChildren(string code)
        //{
        //    throw new NotImplementedException();
        //}
        public static PostfixUnaryExpressionSyntax ParsePostfixUnaryExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() =>             for (int i = 0; i <= 2; {code}) {{}}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<PostfixUnaryExpressionSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<PostfixUnaryExpressionSyntax>()?.FirstOrDefault();
        }

        public static QualifiedCrefSyntax ParseQualifiedCref(string code)
        {
            throw new NotImplementedException();
        }

        public static QueryContinuationSyntax ParseQueryContinuation(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => from v in vs group g by v.Value {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<QueryContinuationSyntax>()?.FirstOrDefault();
        }

        public static TypeParameterListSyntax ParseTypeParameterList(string code)
        {
            if (code == null)
                return null;
            var str = $"class Cl{code} {{ }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<TypeParameterListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<TypeParameterListSyntax>()?.FirstOrDefault();
        }

        public static SwitchLabelSyntax ParseSwitchLabel(string code)
        {
            throw new NotImplementedException();
        }

        public static SimpleNameSyntax ParseSimpleName(string code)
        {
            throw new NotImplementedException();
        }

        public static TryStatementSyntax ParseTryStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{
            {code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<TryStatementSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<TryStatementSyntax>()?.FirstOrDefault();
        }

        //public static WithManyChildrenSyntax ParseWithManyChildren(string code)
        //{
        //    throw new NotImplementedException();
        //}
        //public static WithTwoChildrenSyntax ParseWithTwoChildren(string code)
        //{
        //    throw new NotImplementedException();
        //}
        public static XmlNodeSyntax ParseXmlNode(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlCrefAttributeSyntax ParseXmlCrefAttribute(string code)
        {
            throw new NotImplementedException();
        }

        public static TypeDeclarationSyntax ParseTypeDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlElementSyntax ParseXmlElement(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlCDataSectionSyntax ParseXmlCDataSection(string code)
        {
            throw new NotImplementedException();
        }

        public static InterpolationAlignmentClauseSyntax ParseInterpolationAlignmentClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => $\"{{obj{code}}}\";";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<InterpolationAlignmentClauseSyntax>().FirstOrDefault();
        }

        public static XmlElementStartTagSyntax ParseXmlElementStartTag(string code)
        {
            throw new NotImplementedException();
        }

        public static CatchClauseSyntax ParseCatchClause(string code)
        {
            if (code == null)
                return null;
            var str = $@"       void Meth()
        {{            
            try
            {{
                
            }}
            {code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<CatchClauseSyntax>()?.FirstOrDefault();
        }

        public static XmlNameAttributeSyntax ParseXmlNameAttribute(string code)
        {
            throw new NotImplementedException();
        }

        public static AnonymousMethodExpressionSyntax ParseAnonymousMethodExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => System.Action<int> res = {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<AnonymousMethodExpressionSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AnonymousMethodExpressionSyntax>()?.FirstOrDefault();
        }

        public static XmlTextAttributeSyntax ParseXmlTextAttribute(string code)
        {
            throw new NotImplementedException();
        }

        public static FixedStatementSyntax ParseFixedStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FixedStatementSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<FixedStatementSyntax>()?.FirstOrDefault();
        }

        public static ConditionalExpressionSyntax ParseConditionalExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ConditionalExpressionSyntax>()?.FirstOrDefault();
        }

        public static FromClauseSyntax ParseFromClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code} select v;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>()?.FirstOrDefault();
        }

        public static LabeledStatementSyntax ParseLabeledStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{
{code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<LabeledStatementSyntax>()?.FirstOrDefault();
        }

        public static LetClauseSyntax ParseLetClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => from v in vs {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<LetClauseSyntax>()?.FirstOrDefault();
        }

        public static WhileStatementSyntax ParseWhileStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{
            {code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<WhileStatementSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<WhileStatementSyntax>()?.FirstOrDefault();
        }

        public static ArrayRankSpecifierSyntax ParseArrayRankSpecifier(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => var vs = new int{code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ArrayRankSpecifierSyntax>()?.FirstOrDefault();
        }

        public static RefValueExpressionSyntax ParseRefValueExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static ConstructorConstraintSyntax ParseConstructorConstraint(string code)
        {
            if (code == null)
                return null;
            var str = $"class Cl<T> where T : Obj, {code} {{ }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ConstructorConstraintSyntax>()?.FirstOrDefault();
        }

        public static ConversionOperatorDeclarationSyntax ParseConversionOperatorDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $@"class Cl {{ 
{code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ConversionOperatorDeclarationSyntax>()?.FirstOrDefault();
        }

        public static XmlElementStartTagSyntax ParseXmlElementStartTagSyntax(string startTagStr)
        {
            throw new NotImplementedException();
        }

        public static AnonymousFunctionExpressionSyntax ParseAnonymousFunctionExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static AliasQualifiedNameSyntax ParseAliasQualifiedName(string code)
        {
            if (code == null)
                return null;
            var str = $"using {code}.Runtime;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AliasQualifiedNameSyntax>()?.FirstOrDefault();
        }

        public static XmlNameSyntax ParseXmlNameSyntax(string nameStr)
        {
            throw new NotImplementedException();
        }

        public static DelegateDeclarationSyntax ParseDelegateDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $@"class Cl {{ 
{code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<DelegateDeclarationSyntax>()?.FirstOrDefault();
        }

        public static AccessorDeclarationSyntax ParseAccessorDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $"class Cl {{ public string p {{ {code} }} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AccessorDeclarationSyntax>()?.FirstOrDefault();
        }

        public static SyntaxTokenList ParseTokenList(string tokenStr)
        {
            var token = tokenStr.Split(',', ' ').Select(t => ParseToken(t));
            return SyntaxFactory.TokenList(token);
        }

        public static BracketedArgumentListSyntax ParseBracketedArgumentListSyntax(string argumentListStr)
        {
            if (argumentListStr == null)
                return null;
            var str = $"void Meth() => a{argumentListStr};";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<BracketedArgumentListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<BracketedArgumentListSyntax>()?.FirstOrDefault();
        }

        public static EqualsValueClauseSyntax ParseEqualsValueClauseSyntax(string str)
        {
            if (str == null)
                return null;
            //var str = $"void Meth() => a = {str};";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree($"public int a {str}; }}");
            var ds = st?.GetRoot()?.DescendantNodes().OfType<EqualsValueClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<EqualsValueClauseSyntax>()?.FirstOrDefault();
        }

        public static NameColonSyntax ParseNameColonSyntax(string nameColonStr)
        {
            if (nameColonStr == null)
                return null;
            return SyntaxFactory.NameColon(nameColonStr.TrimEnd()
                .TrimEnd(':')); //  throw new NotImplementedException();
        }

        public static ParameterSyntax ParseParameter(string code)
        {
            return ParseParameterSyntax(code);
        }

        public static ParameterSyntax ParseParameterSyntax(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth({code}) => ;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ParameterSyntax>().FirstOrDefault();
        }

        public static SimpleNameSyntax ParseSimpleNameSyntax(string nameStr)
        {
            return SyntaxFactory.IdentifierName(nameStr);
        }

        public static IdentifierNameSyntax ParseIdentifierNameSyntax(string nameStr)
        {
            return SyntaxFactory.IdentifierName(nameStr);
            // throw new NotImplementedException();
        }

        public static NameEqualsSyntax ParseNameEqualsSyntax(string nameStr)
        {
            return SyntaxFactory.NameEquals(nameStr);
        }

        public static TypeArgumentListSyntax ParseTypeArgumentListSyntax(string typeArgumentListStr)
        {
            if (typeArgumentListStr == null)
                return null;
            var str = $"a{typeArgumentListStr} Meth() => return null;";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<TypeArgumentListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<TypeArgumentListSyntax>()?.FirstOrDefault();
        }

        public static ArgumentListSyntax ParseArgumentListSyntax(string argumentListStr)
        {
            if (argumentListStr == null)
                return null;
            var str = $"void Meth() => a({argumentListStr.Trim().TrimStart('(').TrimEnd(')')});";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<ArgumentListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ArgumentListSyntax>()?.FirstOrDefault();
        }

        public static FinallyClauseSyntax ParseFinallyClauseSyntax(string finallyStr)
        {
            if (finallyStr == null)
                return null;
            var str = $"void Meth() {{ try {{ }} {finallyStr} }}"; //.Trim('\r', '\n', ' ', ';')
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<FinallyClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<FinallyClauseSyntax>()?.FirstOrDefault();
        }

        public static InterpolationFormatClauseSyntax ParseInterpolationFormatClauseSyntax(string formatClauseStr)
        {
            return SyntaxFactory.InterpolationFormatClause(SyntaxFactory.Token(default(SyntaxTriviaList),
                SyntaxKind.InterpolatedStringToken, formatClauseStr, formatClauseStr,
                default(SyntaxTriviaList))); // throw new NotImplementedException();
        }

        public static bool ParseBoolean(string isVarStr)
        {
            return bool.Parse(isVarStr);
        }

        public static CrefParameterListSyntax ParseCrefParameterListSyntax(string parametersStr)
        {
            throw new NotImplementedException();
        }

        public static StatementSyntax ParseStatementSyntax(string statementStr)
        {
            if (statementStr == null)
                return null;
            var str = $"void Meth() {{ {statementStr} }}"; //.Trim('\r', '\n', ' ', ';')
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<StatementSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<StatementSyntax>()?.FirstOrDefault();
        }

        public static InitializerExpressionSyntax ParseInitializerExpressionSyntax(string initializerStr)
        {
            if (initializerStr == null)
                return null;
            var str = $"void Meth() {{ var i = {initializerStr} }}"; //.Trim('\r', '\n', ' ', ';')
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<InitializerExpressionSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<InitializerExpressionSyntax>()?.FirstOrDefault();
        }

        public static SyntaxKind ParseSyntaxKind(string keyword)
        {
            return SyntaxKind.None;
        }

        public static VariableDeclarationSyntax ParseVariableDeclarationSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree($" public {str};");
            return st?.GetRoot()?.DescendantNodes().OfType<VariableDeclarationSyntax>()?.FirstOrDefault();
        }

        public static AttributeTargetSpecifierSyntax ParseAttributeTargetSpecifierSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree($"[{str} null] \n void meth() {{ }}");
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeTargetSpecifierSyntax>()?.FirstOrDefault();
        }

        public static SyntaxNode ParseSyntaxNode(string str)
        {
            return str == null ? null : SyntaxFactory.ParseSyntaxTree(str).GetRoot();
        }

        public static ParameterListSyntax ParseParameterListSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree($"void meth{str} {{ }}");
            return st?.GetRoot()?.DescendantNodes().OfType<ParameterListSyntax>()?.FirstOrDefault();
        }

        public static JoinIntoClauseSyntax ParseJoinIntoClauseSyntax(string intoStr)
        {
            throw new NotImplementedException();
        }

        public static int ParseInt32(string str)
        {
            return int.Parse(str);
        }

        public static ConstructorInitializerSyntax ParseConstructorInitializerSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ConstructorInitializerSyntax>()?.FirstOrDefault();
        }

        public static AttributeListSyntax ParseAttributeListSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeListSyntax>()?.FirstOrDefault();
        }

        public static SyntaxList<AttributeListSyntax> ParseSyntaxList(string str)
        {
            var res = new SyntaxList<AttributeListSyntax>();
            if (str == null)
                return res;
            var s = str.Split(',');
            foreach (var item in s)
            {
                var a = ParseAttributeListSyntax(item.Trim());
                res = res.Add(a);
            }

            return res;
        }

        public static BlockSyntax ParseBlockSyntax(string str)
        {
            if (str == null)
                return null;
            SyntaxTree st;
            if (str.Trim().StartsWith("{"))
                st = SyntaxFactory.ParseSyntaxTree($"void Meth() {str}");
            else
                st = SyntaxFactory.ParseSyntaxTree($"void Meth() {{ {str} }}");
            var root = st?.GetRoot();
            return root?.DescendantNodes().OfType<BlockSyntax>()?.FirstOrDefault();
        }

        public static AccessorListSyntax ParseAccessorListSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree($"class C {{ public int Prop {{ {str} }}");
            var root = st?.GetRoot();
            return root?.DescendantNodes().OfType<AccessorListSyntax>()?.FirstOrDefault();
        }

        public static SyntaxList<T> ParseSyntaxList<T>(string str) where T : SyntaxNode
        {
            var res = new SyntaxList<T>();
            if (str == null)
                return res;
            var s = str.Split(',');
            foreach (var item in s)
            {
                var v = ParseAttributeListSyntax(item.Trim());
                if (v == null)
                    continue;
                res = res.Add(v as T);
            }

            return res;
        }

        public static ExplicitInterfaceSpecifierSyntax ParseExplicitInterfaceSpecifierSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ExplicitInterfaceSpecifierSyntax>()?.FirstOrDefault();
        }

        public static SeparatedSyntaxList<T> ParseSeparatedSyntaxList<T>(string str) where T : SyntaxNode
        {
            var res = new SeparatedSyntaxList<T>();
            if (str == null)
                return res;
            var s = str.Split(',');
            foreach (var item in s)
            {
                var v = ParseAttributeListSyntax(item.Trim());
                if (v == null)
                    continue;
                res = res.Add(v as T);
            }

            return res;
        }

        public static ArrowExpressionClauseSyntax ParseArrowExpressionClauseSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<ArrowExpressionClauseSyntax>()?.FirstOrDefault();
        }

        public static BaseListSyntax ParseBaseListSyntax(string str)
        {
            if (str == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree($"class c {str} {{ }}");
            var ds = st?.GetRoot()?.DescendantNodes().OfType<BaseListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<BaseListSyntax>()?.FirstOrDefault();
        }

        public static NameSyntax ParseNameSyntax(string nameStr)
        {
            return SyntaxFactory.ParseName(nameStr);
            // throw new NotImplementedException();
        }

        public static TypeSyntax ParseTypeSyntax(string returnTypeStr)
        {
            return ParseTypeName(returnTypeStr); // null; // 
        }

        public static TypeParameterListSyntax ParseTypeParameterListSyntax(string code)
        {
            if (code == null)
                return null;
            var str = $"class C{code} {{  }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<TypeParameterListSyntax>().FirstOrDefault();
        }

        public static PropertyDeclarationSyntax PropertyDeclaration(string code)
        {
            if (code == null)
                return null;
            var st = SyntaxFactory.ParseSyntaxTree($"class Cl {{\n   {code}\n}}");
            return st?.GetRoot()?.DescendantNodes().OfType<PropertyDeclarationSyntax>()?.FirstOrDefault();
        }

        public static MethodDeclarationSyntax ParseMethodDeclaration(string code)
        {
            if (code == null)
                return null;
            var s = code.TrimEnd();
            var trimedCodeLast = s[s.Length - 1]; //.Last();
            if (trimedCodeLast != '}' && trimedCodeLast != ';')
            {
                if (trimedCodeLast != ')')
                    code += "()";
                code += " { }";
            }

            var st = SyntaxFactory.ParseSyntaxTree($"class Cl {{\n   {code}\n}}");
            return st?.GetRoot()?.DescendantNodes().OfType<MethodDeclarationSyntax>()?.FirstOrDefault();
        }

        public static XmlPrefixSyntax ParseXmlPrefixSyntax(string prefixStr)
        {
            throw new NotImplementedException();
        }

        public static BaseListSyntax ParseBaseList(string code)
        {
            return ParseBaseListSyntax(code);
        }

        public static IfStatementSyntax ParseIfStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth()
            {{
                    {code}
                }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<IfStatementSyntax>()?.FirstOrDefault();
        }

        public static BaseCrefParameterListSyntax ParseBaseCrefParameterList(string code)
        {
            throw new NotImplementedException();
        }

        public static BaseParameterListSyntax ParseBaseParameterList(string code)
        {
            throw new NotImplementedException();
        }

        public static MemberCrefSyntax ParseMemberCref(string code)
        {
            throw new NotImplementedException();
        }

        public static CheckedExpressionSyntax ParseCheckedExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<CheckedExpressionSyntax>()?.FirstOrDefault();
        }

        public static BaseTypeDeclarationSyntax ParseBaseTypeDeclaration(string code)
        {
            throw new NotImplementedException();
        }

        public static ConstructorInitializerSyntax ParseConstructorInitializer(string code)
        {
            if (code == null)
                return null;
            var str = $@"class Cl {{ 
            public Cl()
            {code}            
            {{
            }}
}}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ConstructorInitializerSyntax>()?.FirstOrDefault();
        }

        public static InstanceExpressionSyntax ParseInstanceExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static CrefBracketedParameterListSyntax ParseCrefBracketedParameterList(string code)
        {
            throw new NotImplementedException();
        }

        public static IndexerMemberCrefSyntax ParseIndexerMemberCref(string code)
        {
            throw new NotImplementedException();
        }

        public static SelectOrGroupClauseSyntax ParseSelectOrGroupClause(string code)
        {
            throw new NotImplementedException();
        }

        public static LambdaExpressionSyntax ParseLambdaExpression(string code)
        {
            throw new NotImplementedException();
        }

        public static OrderingSyntax ParseOrdering(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => from v in vs orderby {code} select v; ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<OrderByClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<OrderingSyntax>()?.FirstOrDefault();
        }

        public static PrefixUnaryExpressionSyntax ParsePrefixUnaryExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() =>             for (int i = 0; i <= 2; {code}) {{}}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<PrefixUnaryExpressionSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<PrefixUnaryExpressionSyntax>()?.FirstOrDefault();
        }

        public static ParenthesizedLambdaExpressionSyntax ParseParenthesizedLambdaExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() =>             m.Ev += {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<ParenthesizedLambdaExpressionSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ParenthesizedLambdaExpressionSyntax>()?.FirstOrDefault();
        }

        public static QualifiedNameSyntax ParseQualifiedName(string code)
        {
            if (code == null)
                return null;
            var str = $"using {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<QualifiedNameSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<QualifiedNameSyntax>()?.FirstOrDefault();
        }

        public static QueryExpressionSyntax ParseQueryExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{  return {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<QueryExpressionSyntax>().FirstOrDefault();
        }

        public static SimpleLambdaExpressionSyntax ParseSimpleLambdaExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => vs.Select({code});";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<SimpleLambdaExpressionSyntax>()?.FirstOrDefault();
        }

        public static TypeArgumentListSyntax ParseTypeArgumentList(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => new List{code}(); ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<TypeArgumentListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<TypeArgumentListSyntax>()?.FirstOrDefault();
        }

        //public static WithThreeChildrenSyntax ParseWithThreeChildren(string code)
        //{
        //    throw new NotImplementedException();
        //}
        public static TypeParameterConstraintSyntax ParseTypeParameterConstraint(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlNameSyntax ParseXmlName(string code)
        {
            throw new NotImplementedException();
        }

        //public static WithManyWeakChildrenSyntax ParseWithManyWeakChildren(string code)
        //{
        //    throw new NotImplementedException();
        //}
        public static SwitchSectionSyntax ParseSwitchSection(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{ 
            switch (v)
            {{
{code}
            default: break;
        }}
}}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<SwitchSectionSyntax>()?.FirstOrDefault();
        }

        public static XmlPrefixSyntax ParseXmlPrefix(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlElementEndTagSyntax ParseXmlElementEndTag(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlAttributeSyntax ParseXmlAttribute(string code)
        {
            throw new NotImplementedException();
        }

        public static XmlCommentSyntax ParseXmlComment(string code)
        {
            throw new NotImplementedException();
        }

        public static ContinueStatementSyntax ParseContinueStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() 
{{
while(true)
{{
{code}
}}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ContinueStatementSyntax>()?.FirstOrDefault();
        }

        public static XmlEmptyElementSyntax ParseXmlEmptyElement(string code)
        {
            throw new NotImplementedException();
        }

        public static YieldStatementSyntax ParseYieldStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<YieldStatementSyntax>()?.FirstOrDefault();
        }

        public static XmlProcessingInstructionSyntax ParseXmlProcessingInstruction(string code)
        {
            throw new NotImplementedException();
        }

        public static CastExpressionSyntax ParseCastExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code}; ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<CastExpressionSyntax>()?.FirstOrDefault();
        }

        public static ConditionalAccessExpressionSyntax ParseConditionalAccessExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => {code}; ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ConditionalAccessExpressionSyntax>()?.FirstOrDefault();
        }

        public static DoStatementSyntax ParseDoStatement(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() {{ {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<DoStatementSyntax>()?.FirstOrDefault();
        }

        public static GroupClauseSyntax ParseGroupClause(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() =>  from v in vs {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<GroupClauseSyntax>()?.FirstOrDefault();
        }

        public static ForEachStatementSyntax ParseForEachStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{
{code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ForEachStatementSyntax>()?.FirstOrDefault();
        }

        public static LockStatementSyntax ParseLockStatement(string code)
        {
            if (code == null)
                return null;
            var str = $@"void Meth() {{
{code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<LockStatementSyntax>()?.FirstOrDefault();
        }

        public static BlockSyntax ParseBlock(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth()  {code} ";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            return st?.GetRoot()?.DescendantNodes().OfType<BlockSyntax>().FirstOrDefault();
        }

        public static AnonymousObjectCreationExpressionSyntax ParseAnonymousObjectCreationExpression(string code)
        {
            if (code == null)
                return null;
            var str = $"void Meth() => from v in vs select {code};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AnonymousObjectCreationExpressionSyntax>()?.FirstOrDefault();
        }

        public static JoinClauseSyntax ParseJoinClause(string code)
        {
            throw new NotImplementedException();
        }

        public static AccessorListSyntax ParseAccessorList(string code)
        {
            if (code == null)
                return null;
            var str = $"class Cl {{         int Pr {code} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AccessorListSyntax>()?.FirstOrDefault();
        }

        public static ConversionOperatorMemberCrefSyntax ParseConversionOperatorMemberCref(string code)
        {
            throw new NotImplementedException();
        }

        public static SelectOrGroupClauseSyntax ParseSelectOrGroupClauseSyntax(string selectOrGroupStr)
        {
            if (selectOrGroupStr == null)
                return null;
            var str = $"void Meth() => from m in ms {selectOrGroupStr.Trim()};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<SelectOrGroupClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<SelectOrGroupClauseSyntax>()?.FirstOrDefault();
        }

        public static EventDeclarationSyntax ParseEventDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $@"class Cl {{ 
            {code}            
}}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<FromClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<EventDeclarationSyntax>()?.FirstOrDefault();
        }

        public static OperatorDeclarationSyntax ParseOperatorDeclaration(string code)
        {
            if (code == null)
                return null;
            var str = $@"class Cl {{ 
{code}
        }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<OperatorDeclarationSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<OperatorDeclarationSyntax>()?.FirstOrDefault();
        }

        public static XmlElementEndTagSyntax ParseXmlElementEndTagSyntax(string endTagStr)
        {
            throw new NotImplementedException();
        }

        public static CrefBracketedParameterListSyntax ParseCrefBracketedParameterListSyntax(string parametersStr)
        {
            throw new NotImplementedException();
        }

        public static AttributeArgumentListSyntax ParseAttributeArgumentListSyntax(string argumentListStr)
        {
            if (argumentListStr == null)
                return null;
            var str = $"[a{argumentListStr}] \nvoid Meth() {{ }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<AttributeArgumentListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<AttributeArgumentListSyntax>()?.FirstOrDefault();
        }

        public static QueryContinuationSyntax ParseQueryContinuationSyntax(string continuationStr)
        {
            if (continuationStr == null)
                return null;
            var str = $"void Meth() => from v in vs {continuationStr};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<QueryContinuationSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<QueryContinuationSyntax>()?.FirstOrDefault();
        }

        public static InterpolationAlignmentClauseSyntax ParseInterpolationAlignmentClauseSyntax(
            string alignmentClauseStr)
        {
            if (alignmentClauseStr == null)
                return null;
            var str = $"void Meth() => {{b{alignmentClauseStr}:X;";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<InterpolationAlignmentClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<InterpolationAlignmentClauseSyntax>()?.FirstOrDefault();
        }

        public static CSharpSyntaxNode ParseCSharpSyntaxNode(string bodyStr)
        {
            if (bodyStr == null)
                return null;
            var str = $"void Meth() => {bodyStr.Trim()};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<CSharpSyntaxNode>();
            return st?.GetRoot()?.DescendantNodes().OfType<CSharpSyntaxNode>()?.ElementAtOrDefault(4);
        }

        public static CatchDeclarationSyntax ParseCatchDeclarationSyntax(string declarationStr)
        {
            if (declarationStr == null)
                return null;
            var str = $"void Meth() {{ try {{ }} catch{declarationStr} {{}} }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<CatchDeclarationSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<CatchDeclarationSyntax>()?.FirstOrDefault();
        }

        public static ExpressionSyntax ParseExpressionSyntax(string expressionStr)
        {
            if (expressionStr == null)
                return null;
            var str = $"void Meth() => {expressionStr.TrimEnd().TrimEnd(';')};";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<ExpressionSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ExpressionSyntax>()?.ElementAtOrDefault(1);
        }

        public static QueryBodySyntax ParseQueryBodySyntax(string bodyStr)
        {
            if (bodyStr == null)
                return null;
            var str = $"void Meth() => from m in ms {bodyStr.Trim()};";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<QueryBodySyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<QueryBodySyntax>()?.FirstOrDefault();
        }

        public static ArrayTypeSyntax ParseArrayTypeSyntax(string typeStr)
        {
            if (typeStr == null)
                return null;
            var str = $"void Meth() {{ a = new {typeStr}; }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<ArrayTypeSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ArrayTypeSyntax>()?.FirstOrDefault();
        }

        public static MemberCrefSyntax ParseMemberCrefSyntax(string memberStr)
        {
            throw new NotImplementedException();
        }

        public static CatchFilterClauseSyntax ParseCatchFilterClauseSyntax(string filterStr)
        {
            return CatchFilterClause(filterStr);
            //if (filterStr == null)
            //    return null;
            //var str = $"void Meth() {{  }}";
            ////var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            //var st = SyntaxFactory.ParseSyntaxTree(str);
            //var ds = st?.GetRoot()?.DescendantNodes().OfType<CatchFilterClauseSyntax>();
            //return st?.GetRoot()?.DescendantNodes().OfType<CatchFilterClauseSyntax>()?.FirstOrDefault();
        }

        public static CrefSyntax ParseCrefSyntax(string crefStr)
        {
            throw new NotImplementedException();
        }

        public static BracketedParameterListSyntax ParseBracketedParameterListSyntax(string parameterListStr)
        {
            if (parameterListStr == null)
                return null;
            var str = $"poublic int this{parameterListStr} {{ }}";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<BracketedParameterListSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<BracketedParameterListSyntax>()?.FirstOrDefault();
        }

        public static ElseClauseSyntax ParseElseClauseSyntax(string elseStr)
        {
            if (elseStr == null)
                return null;
            var str = $"void Meth() {{ if(false) {elseStr.Trim()} }}";
            //var str = $"{expressionStr.TrimEnd().TrimEnd(';')};";
            var st = SyntaxFactory.ParseSyntaxTree(str);
            var ds = st?.GetRoot()?.DescendantNodes().OfType<ElseClauseSyntax>();
            return st?.GetRoot()?.DescendantNodes().OfType<ElseClauseSyntax>()?.FirstOrDefault();
        }
    }
}