// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Zu.TameRoslyn.Syntax
{
    public static class TameBaseRoslynNodeCreate
    {
        public static TameBaseRoslynNode CreateTameNode(CSharpSyntaxNode node)
        {
            switch (node.GetType().Name)
            {
                case "ElifDirectiveTriviaSyntax":
                    var n1 = new TameElifDirectiveTriviaSyntax((ElifDirectiveTriviaSyntax) node);
                    n1.AddChildren();
                    return n1;
                case "IfDirectiveTriviaSyntax":
                    var n2 = new TameIfDirectiveTriviaSyntax((IfDirectiveTriviaSyntax) node);
                    n2.AddChildren();
                    return n2;
                case "IdentifierNameSyntax":
                    var n3 = new TameIdentifierNameSyntax((IdentifierNameSyntax) node);
                    n3.AddChildren();
                    return n3;
                case "GenericNameSyntax":
                    var n4 = new TameGenericNameSyntax((GenericNameSyntax) node);
                    n4.AddChildren();
                    return n4;
                case "ParenthesizedLambdaExpressionSyntax":
                    var n5 = new TameParenthesizedLambdaExpressionSyntax((ParenthesizedLambdaExpressionSyntax) node);
                    n5.AddChildren();
                    return n5;
                case "SimpleLambdaExpressionSyntax":
                    var n6 = new TameSimpleLambdaExpressionSyntax((SimpleLambdaExpressionSyntax) node);
                    n6.AddChildren();
                    return n6;
                case "InterfaceDeclarationSyntax":
                    var n7 = new TameInterfaceDeclarationSyntax((InterfaceDeclarationSyntax) node);
                    n7.AddChildren();
                    return n7;
                case "ElseDirectiveTriviaSyntax":
                    var n8 = new TameElseDirectiveTriviaSyntax((ElseDirectiveTriviaSyntax) node);
                    n8.AddChildren();
                    return n8;
                case "AliasQualifiedNameSyntax":
                    var n9 = new TameAliasQualifiedNameSyntax((AliasQualifiedNameSyntax) node);
                    n9.AddChildren();
                    return n9;
                case "StructDeclarationSyntax":
                    var n10 = new TameStructDeclarationSyntax((StructDeclarationSyntax) node);
                    n10.AddChildren();
                    return n10;
                case "ClassDeclarationSyntax":
                    var n11 = new TameClassDeclarationSyntax((ClassDeclarationSyntax) node);
                    n11.AddChildren();
                    return n11;
                case "QualifiedNameSyntax":
                    var n12 = new TameQualifiedNameSyntax((QualifiedNameSyntax) node);
                    n12.AddChildren();
                    return n12;
                case "ConversionOperatorDeclarationSyntax":
                    var n13 = new TameConversionOperatorDeclarationSyntax((ConversionOperatorDeclarationSyntax) node);
                    n13.AddChildren();
                    return n13;
                case "PragmaChecksumDirectiveTriviaSyntax":
                    var n14 = new TamePragmaChecksumDirectiveTriviaSyntax((PragmaChecksumDirectiveTriviaSyntax) node);
                    n14.AddChildren();
                    return n14;
                case "ConversionOperatorMemberCrefSyntax":
                    var n15 = new TameConversionOperatorMemberCrefSyntax((ConversionOperatorMemberCrefSyntax) node);
                    n15.AddChildren();
                    return n15;
                case "PragmaWarningDirectiveTriviaSyntax":
                    var n16 = new TamePragmaWarningDirectiveTriviaSyntax((PragmaWarningDirectiveTriviaSyntax) node);
                    n16.AddChildren();
                    return n16;
                case "AnonymousMethodExpressionSyntax":
                    var n17 = new TameAnonymousMethodExpressionSyntax((AnonymousMethodExpressionSyntax) node);
                    n17.AddChildren();
                    return n17;
                case "EndRegionDirectiveTriviaSyntax":
                    var n18 = new TameEndRegionDirectiveTriviaSyntax((EndRegionDirectiveTriviaSyntax) node);
                    n18.AddChildren();
                    return n18;
                case "ForEachVariableStatementSyntax":
                    var n19 = new TameForEachVariableStatementSyntax((ForEachVariableStatementSyntax) node);
                    n19.AddChildren();
                    return n19;
                case "ReferenceDirectiveTriviaSyntax":
                    var n20 = new TameReferenceDirectiveTriviaSyntax((ReferenceDirectiveTriviaSyntax) node);
                    n20.AddChildren();
                    return n20;
                case "ConstructorDeclarationSyntax":
                    var n21 = new TameConstructorDeclarationSyntax((ConstructorDeclarationSyntax) node);
                    n21.AddChildren();
                    return n21;
                case "ShebangDirectiveTriviaSyntax":
                    var n22 = new TameShebangDirectiveTriviaSyntax((ShebangDirectiveTriviaSyntax) node);
                    n22.AddChildren();
                    return n22;
                case "WarningDirectiveTriviaSyntax":
                    var n23 = new TameWarningDirectiveTriviaSyntax((WarningDirectiveTriviaSyntax) node);
                    n23.AddChildren();
                    return n23;
                case "DefineDirectiveTriviaSyntax":
                    var n24 = new TameDefineDirectiveTriviaSyntax((DefineDirectiveTriviaSyntax) node);
                    n24.AddChildren();
                    return n24;
                case "DestructorDeclarationSyntax":
                    var n25 = new TameDestructorDeclarationSyntax((DestructorDeclarationSyntax) node);
                    n25.AddChildren();
                    return n25;
                case "EventFieldDeclarationSyntax":
                    var n26 = new TameEventFieldDeclarationSyntax((EventFieldDeclarationSyntax) node);
                    n26.AddChildren();
                    return n26;
                case "RegionDirectiveTriviaSyntax":
                    var n27 = new TameRegionDirectiveTriviaSyntax((RegionDirectiveTriviaSyntax) node);
                    n27.AddChildren();
                    return n27;
                case "EndIfDirectiveTriviaSyntax":
                    var n28 = new TameEndIfDirectiveTriviaSyntax((EndIfDirectiveTriviaSyntax) node);
                    n28.AddChildren();
                    return n28;
                case "ErrorDirectiveTriviaSyntax":
                    var n29 = new TameErrorDirectiveTriviaSyntax((ErrorDirectiveTriviaSyntax) node);
                    n29.AddChildren();
                    return n29;
                case "UndefDirectiveTriviaSyntax":
                    var n30 = new TameUndefDirectiveTriviaSyntax((UndefDirectiveTriviaSyntax) node);
                    n30.AddChildren();
                    return n30;
                case "LineDirectiveTriviaSyntax":
                    var n31 = new TameLineDirectiveTriviaSyntax((LineDirectiveTriviaSyntax) node);
                    n31.AddChildren();
                    return n31;
                case "LoadDirectiveTriviaSyntax":
                    var n32 = new TameLoadDirectiveTriviaSyntax((LoadDirectiveTriviaSyntax) node);
                    n32.AddChildren();
                    return n32;
                case "OmittedTypeArgumentSyntax":
                    var n33 = new TameOmittedTypeArgumentSyntax((OmittedTypeArgumentSyntax) node);
                    n33.AddChildren();
                    return n33;
                case "OperatorDeclarationSyntax":
                    var n34 = new TameOperatorDeclarationSyntax((OperatorDeclarationSyntax) node);
                    n34.AddChildren();
                    return n34;
                case "PropertyDeclarationSyntax":
                    var n35 = new TamePropertyDeclarationSyntax((PropertyDeclarationSyntax) node);
                    n35.AddChildren();
                    return n35;
                case "BadDirectiveTriviaSyntax":
                    var n36 = new TameBadDirectiveTriviaSyntax((BadDirectiveTriviaSyntax) node);
                    n36.AddChildren();
                    return n36;
                case "IndexerDeclarationSyntax":
                    var n37 = new TameIndexerDeclarationSyntax((IndexerDeclarationSyntax) node);
                    n37.AddChildren();
                    return n37;
                case "OperatorMemberCrefSyntax":
                    var n38 = new TameOperatorMemberCrefSyntax((OperatorMemberCrefSyntax) node);
                    n38.AddChildren();
                    return n38;
                case "IndexerMemberCrefSyntax":
                    var n39 = new TameIndexerMemberCrefSyntax((IndexerMemberCrefSyntax) node);
                    n39.AddChildren();
                    return n39;
                case "MethodDeclarationSyntax":
                    var n40 = new TameMethodDeclarationSyntax((MethodDeclarationSyntax) node);
                    n40.AddChildren();
                    return n40;
                case "EventDeclarationSyntax":
                    var n41 = new TameEventDeclarationSyntax((EventDeclarationSyntax) node);
                    n41.AddChildren();
                    return n41;
                case "FieldDeclarationSyntax":
                    var n42 = new TameFieldDeclarationSyntax((FieldDeclarationSyntax) node);
                    n42.AddChildren();
                    return n42;
                case "ForEachStatementSyntax":
                    var n43 = new TameForEachStatementSyntax((ForEachStatementSyntax) node);
                    n43.AddChildren();
                    return n43;
                case "EnumDeclarationSyntax":
                    var n44 = new TameEnumDeclarationSyntax((EnumDeclarationSyntax) node);
                    n44.AddChildren();
                    return n44;
                case "BaseExpressionSyntax":
                    var n45 = new TameBaseExpressionSyntax((BaseExpressionSyntax) node);
                    n45.AddChildren();
                    return n45;
                case "NameMemberCrefSyntax":
                    var n46 = new TameNameMemberCrefSyntax((NameMemberCrefSyntax) node);
                    n46.AddChildren();
                    return n46;
                case "PredefinedTypeSyntax":
                    var n47 = new TamePredefinedTypeSyntax((PredefinedTypeSyntax) node);
                    n47.AddChildren();
                    return n47;
                case "ThisExpressionSyntax":
                    var n48 = new TameThisExpressionSyntax((ThisExpressionSyntax) node);
                    n48.AddChildren();
                    return n48;
                case "NullableTypeSyntax":
                    var n49 = new TameNullableTypeSyntax((NullableTypeSyntax) node);
                    n49.AddChildren();
                    return n49;
                case "PointerTypeSyntax":
                    var n50 = new TamePointerTypeSyntax((PointerTypeSyntax) node);
                    n50.AddChildren();
                    return n50;
                case "ArrayTypeSyntax":
                    var n51 = new TameArrayTypeSyntax((ArrayTypeSyntax) node);
                    n51.AddChildren();
                    return n51;
                case "TupleTypeSyntax":
                    var n52 = new TameTupleTypeSyntax((TupleTypeSyntax) node);
                    n52.AddChildren();
                    return n52;
                case "RefTypeSyntax":
                    var n53 = new TameRefTypeSyntax((RefTypeSyntax) node);
                    n53.AddChildren();
                    return n53;
                case "AnonymousObjectCreationExpressionSyntax":
                    var n54 =
                        new TameAnonymousObjectCreationExpressionSyntax((AnonymousObjectCreationExpressionSyntax) node);
                    n54.AddChildren();
                    return n54;
                case "StackAllocArrayCreationExpressionSyntax":
                    var n55 =
                        new TameStackAllocArrayCreationExpressionSyntax((StackAllocArrayCreationExpressionSyntax) node);
                    n55.AddChildren();
                    return n55;
                case "ParenthesizedVariableDesignationSyntax":
                    var n56 =
                        new TameParenthesizedVariableDesignationSyntax((ParenthesizedVariableDesignationSyntax) node);
                    n56.AddChildren();
                    return n56;
                case "ImplicitArrayCreationExpressionSyntax":
                    var n57 =
                        new TameImplicitArrayCreationExpressionSyntax((ImplicitArrayCreationExpressionSyntax) node);
                    n57.AddChildren();
                    return n57;
                case "InterpolatedStringExpressionSyntax":
                    var n58 = new TameInterpolatedStringExpressionSyntax((InterpolatedStringExpressionSyntax) node);
                    n58.AddChildren();
                    return n58;
                case "ConditionalAccessExpressionSyntax":
                    var n59 = new TameConditionalAccessExpressionSyntax((ConditionalAccessExpressionSyntax) node);
                    n59.AddChildren();
                    return n59;
                case "CrefBracketedParameterListSyntax":
                    var n60 = new TameCrefBracketedParameterListSyntax((CrefBracketedParameterListSyntax) node);
                    n60.AddChildren();
                    return n60;
                case "DocumentationCommentTriviaSyntax":
                    var n61 = new TameDocumentationCommentTriviaSyntax((DocumentationCommentTriviaSyntax) node);
                    n61.AddChildren();
                    return n61;
                case "OmittedArraySizeExpressionSyntax":
                    var n62 = new TameOmittedArraySizeExpressionSyntax((OmittedArraySizeExpressionSyntax) node);
                    n62.AddChildren();
                    return n62;
                case "LocalDeclarationStatementSyntax":
                    var n63 = new TameLocalDeclarationStatementSyntax((LocalDeclarationStatementSyntax) node);
                    n63.AddChildren();
                    return n63;
                case "SingleVariableDesignationSyntax":
                    var n64 = new TameSingleVariableDesignationSyntax((SingleVariableDesignationSyntax) node);
                    n64.AddChildren();
                    return n64;
                case "ElementBindingExpressionSyntax":
                    var n65 = new TameElementBindingExpressionSyntax((ElementBindingExpressionSyntax) node);
                    n65.AddChildren();
                    return n65;
                case "ObjectCreationExpressionSyntax":
                    var n66 = new TameObjectCreationExpressionSyntax((ObjectCreationExpressionSyntax) node);
                    n66.AddChildren();
                    return n66;
                case "XmlProcessingInstructionSyntax":
                    var n67 = new TameXmlProcessingInstructionSyntax((XmlProcessingInstructionSyntax) node);
                    n67.AddChildren();
                    return n67;
                case "ArrayCreationExpressionSyntax":
                    var n68 = new TameArrayCreationExpressionSyntax((ArrayCreationExpressionSyntax) node);
                    n68.AddChildren();
                    return n68;
                case "ClassOrStructConstraintSyntax":
                    var n69 = new TameClassOrStructConstraintSyntax((ClassOrStructConstraintSyntax) node);
                    n69.AddChildren();
                    return n69;
                case "ElementAccessExpressionSyntax":
                    var n70 = new TameElementAccessExpressionSyntax((ElementAccessExpressionSyntax) node);
                    n70.AddChildren();
                    return n70;
                case "MemberBindingExpressionSyntax":
                    var n71 = new TameMemberBindingExpressionSyntax((MemberBindingExpressionSyntax) node);
                    n71.AddChildren();
                    return n71;
                case "ParenthesizedExpressionSyntax":
                    var n72 = new TameParenthesizedExpressionSyntax((ParenthesizedExpressionSyntax) node);
                    n72.AddChildren();
                    return n72;
                case "BracketedParameterListSyntax":
                    var n73 = new TameBracketedParameterListSyntax((BracketedParameterListSyntax) node);
                    n73.AddChildren();
                    return n73;
                case "CasePatternSwitchLabelSyntax":
                    var n74 = new TameCasePatternSwitchLabelSyntax((CasePatternSwitchLabelSyntax) node);
                    n74.AddChildren();
                    return n74;
                case "InterpolatedStringTextSyntax":
                    var n75 = new TameInterpolatedStringTextSyntax((InterpolatedStringTextSyntax) node);
                    n75.AddChildren();
                    return n75;
                case "LocalFunctionStatementSyntax":
                    var n76 = new TameLocalFunctionStatementSyntax((LocalFunctionStatementSyntax) node);
                    n76.AddChildren();
                    return n76;
                case "MemberAccessExpressionSyntax":
                    var n77 = new TameMemberAccessExpressionSyntax((MemberAccessExpressionSyntax) node);
                    n77.AddChildren();
                    return n77;
                case "PostfixUnaryExpressionSyntax":
                    var n78 = new TamePostfixUnaryExpressionSyntax((PostfixUnaryExpressionSyntax) node);
                    n78.AddChildren();
                    return n78;
                case "BracketedArgumentListSyntax":
                    var n79 = new TameBracketedArgumentListSyntax((BracketedArgumentListSyntax) node);
                    n79.AddChildren();
                    return n79;
                case "ConditionalExpressionSyntax":
                    var n80 = new TameConditionalExpressionSyntax((ConditionalExpressionSyntax) node);
                    n80.AddChildren();
                    return n80;
                case "ConstructorConstraintSyntax":
                    var n81 = new TameConstructorConstraintSyntax((ConstructorConstraintSyntax) node);
                    n81.AddChildren();
                    return n81;
                case "DeclarationExpressionSyntax":
                    var n82 = new TameDeclarationExpressionSyntax((DeclarationExpressionSyntax) node);
                    n82.AddChildren();
                    return n82;
                case "EnumMemberDeclarationSyntax":
                    var n83 = new TameEnumMemberDeclarationSyntax((EnumMemberDeclarationSyntax) node);
                    n83.AddChildren();
                    return n83;
                case "ImplicitElementAccessSyntax":
                    var n84 = new TameImplicitElementAccessSyntax((ImplicitElementAccessSyntax) node);
                    n84.AddChildren();
                    return n84;
                case "InitializerExpressionSyntax":
                    var n85 = new TameInitializerExpressionSyntax((InitializerExpressionSyntax) node);
                    n85.AddChildren();
                    return n85;
                case "PrefixUnaryExpressionSyntax":
                    var n86 = new TamePrefixUnaryExpressionSyntax((PrefixUnaryExpressionSyntax) node);
                    n86.AddChildren();
                    return n86;
                case "AssignmentExpressionSyntax":
                    var n87 = new TameAssignmentExpressionSyntax((AssignmentExpressionSyntax) node);
                    n87.AddChildren();
                    return n87;
                case "InvocationExpressionSyntax":
                    var n88 = new TameInvocationExpressionSyntax((InvocationExpressionSyntax) node);
                    n88.AddChildren();
                    return n88;
                case "NamespaceDeclarationSyntax":
                    var n89 = new TameNamespaceDeclarationSyntax((NamespaceDeclarationSyntax) node);
                    n89.AddChildren();
                    return n89;
                case "DelegateDeclarationSyntax":
                    var n90 = new TameDelegateDeclarationSyntax((DelegateDeclarationSyntax) node);
                    n90.AddChildren();
                    return n90;
                case "ExpressionStatementSyntax":
                    var n91 = new TameExpressionStatementSyntax((ExpressionStatementSyntax) node);
                    n91.AddChildren();
                    return n91;
                case "IsPatternExpressionSyntax":
                    var n92 = new TameIsPatternExpressionSyntax((IsPatternExpressionSyntax) node);
                    n92.AddChildren();
                    return n92;
                case "SkippedTokensTriviaSyntax":
                    var n93 = new TameSkippedTokensTriviaSyntax((SkippedTokensTriviaSyntax) node);
                    n93.AddChildren();
                    return n93;
                case "DeclarationPatternSyntax":
                    var n94 = new TameDeclarationPatternSyntax((DeclarationPatternSyntax) node);
                    n94.AddChildren();
                    return n94;
                case "DefaultSwitchLabelSyntax":
                    var n95 = new TameDefaultSwitchLabelSyntax((DefaultSwitchLabelSyntax) node);
                    n95.AddChildren();
                    return n95;
                case "DiscardDesignationSyntax":
                    var n96 = new TameDiscardDesignationSyntax((DiscardDesignationSyntax) node);
                    n96.AddChildren();
                    return n96;
                case "RefValueExpressionSyntax":
                    var n97 = new TameRefValueExpressionSyntax((RefValueExpressionSyntax) node);
                    n97.AddChildren();
                    return n97;
                case "CheckedExpressionSyntax":
                    var n98 = new TameCheckedExpressionSyntax((CheckedExpressionSyntax) node);
                    n98.AddChildren();
                    return n98;
                case "ContinueStatementSyntax":
                    var n99 = new TameContinueStatementSyntax((ContinueStatementSyntax) node);
                    n99.AddChildren();
                    return n99;
                case "CrefParameterListSyntax":
                    var n100 = new TameCrefParameterListSyntax((CrefParameterListSyntax) node);
                    n100.AddChildren();
                    return n100;
                case "DefaultExpressionSyntax":
                    var n101 = new TameDefaultExpressionSyntax((DefaultExpressionSyntax) node);
                    n101.AddChildren();
                    return n101;
                case "LiteralExpressionSyntax":
                    var n102 = new TameLiteralExpressionSyntax((LiteralExpressionSyntax) node);
                    n102.AddChildren();
                    return n102;
                case "MakeRefExpressionSyntax":
                    var n103 = new TameMakeRefExpressionSyntax((MakeRefExpressionSyntax) node);
                    n103.AddChildren();
                    return n103;
                case "RefTypeExpressionSyntax":
                    var n104 = new TameRefTypeExpressionSyntax((RefTypeExpressionSyntax) node);
                    n104.AddChildren();
                    return n104;
                case "BinaryExpressionSyntax":
                    var n105 = new TameBinaryExpressionSyntax((BinaryExpressionSyntax) node);
                    n105.AddChildren();
                    return n105;
                case "CheckedStatementSyntax":
                    var n106 = new TameCheckedStatementSyntax((CheckedStatementSyntax) node);
                    n106.AddChildren();
                    return n106;
                case "IncompleteMemberSyntax":
                    var n107 = new TameIncompleteMemberSyntax((IncompleteMemberSyntax) node);
                    n107.AddChildren();
                    return n107;
                case "LabeledStatementSyntax":
                    var n108 = new TameLabeledStatementSyntax((LabeledStatementSyntax) node);
                    n108.AddChildren();
                    return n108;
                case "SizeOfExpressionSyntax":
                    var n109 = new TameSizeOfExpressionSyntax((SizeOfExpressionSyntax) node);
                    n109.AddChildren();
                    return n109;
                case "TypeOfExpressionSyntax":
                    var n110 = new TameTypeOfExpressionSyntax((TypeOfExpressionSyntax) node);
                    n110.AddChildren();
                    return n110;
                case "XmlCrefAttributeSyntax":
                    var n111 = new TameXmlCrefAttributeSyntax((XmlCrefAttributeSyntax) node);
                    n111.AddChildren();
                    return n111;
                case "XmlNameAttributeSyntax":
                    var n112 = new TameXmlNameAttributeSyntax((XmlNameAttributeSyntax) node);
                    n112.AddChildren();
                    return n112;
                case "XmlTextAttributeSyntax":
                    var n113 = new TameXmlTextAttributeSyntax((XmlTextAttributeSyntax) node);
                    n113.AddChildren();
                    return n113;
                case "AwaitExpressionSyntax":
                    var n114 = new TameAwaitExpressionSyntax((AwaitExpressionSyntax) node);
                    n114.AddChildren();
                    return n114;
                case "CaseSwitchLabelSyntax":
                    var n115 = new TameCaseSwitchLabelSyntax((CaseSwitchLabelSyntax) node);
                    n115.AddChildren();
                    return n115;
                case "ConstantPatternSyntax":
                    var n116 = new TameConstantPatternSyntax((ConstantPatternSyntax) node);
                    n116.AddChildren();
                    return n116;
                case "GlobalStatementSyntax":
                    var n117 = new TameGlobalStatementSyntax((GlobalStatementSyntax) node);
                    n117.AddChildren();
                    return n117;
                case "QueryExpressionSyntax":
                    var n118 = new TameQueryExpressionSyntax((QueryExpressionSyntax) node);
                    n118.AddChildren();
                    return n118;
                case "ReturnStatementSyntax":
                    var n119 = new TameReturnStatementSyntax((ReturnStatementSyntax) node);
                    n119.AddChildren();
                    return n119;
                case "SwitchStatementSyntax":
                    var n120 = new TameSwitchStatementSyntax((SwitchStatementSyntax) node);
                    n120.AddChildren();
                    return n120;
                case "ThrowExpressionSyntax":
                    var n121 = new TameThrowExpressionSyntax((ThrowExpressionSyntax) node);
                    n121.AddChildren();
                    return n121;
                case "TupleExpressionSyntax":
                    var n122 = new TameTupleExpressionSyntax((TupleExpressionSyntax) node);
                    n122.AddChildren();
                    return n122;
                case "UnsafeStatementSyntax":
                    var n123 = new TameUnsafeStatementSyntax((UnsafeStatementSyntax) node);
                    n123.AddChildren();
                    return n123;
                case "XmlCDataSectionSyntax":
                    var n124 = new TameXmlCDataSectionSyntax((XmlCDataSectionSyntax) node);
                    n124.AddChildren();
                    return n124;
                case "XmlEmptyElementSyntax":
                    var n125 = new TameXmlEmptyElementSyntax((XmlEmptyElementSyntax) node);
                    n125.AddChildren();
                    return n125;
                case "BreakStatementSyntax":
                    var n126 = new TameBreakStatementSyntax((BreakStatementSyntax) node);
                    n126.AddChildren();
                    return n126;
                case "CastExpressionSyntax":
                    var n127 = new TameCastExpressionSyntax((CastExpressionSyntax) node);
                    n127.AddChildren();
                    return n127;
                case "EmptyStatementSyntax":
                    var n128 = new TameEmptyStatementSyntax((EmptyStatementSyntax) node);
                    n128.AddChildren();
                    return n128;
                case "FixedStatementSyntax":
                    var n129 = new TameFixedStatementSyntax((FixedStatementSyntax) node);
                    n129.AddChildren();
                    return n129;
                case "SimpleBaseTypeSyntax":
                    var n130 = new TameSimpleBaseTypeSyntax((SimpleBaseTypeSyntax) node);
                    n130.AddChildren();
                    return n130;
                case "ThrowStatementSyntax":
                    var n131 = new TameThrowStatementSyntax((ThrowStatementSyntax) node);
                    n131.AddChildren();
                    return n131;
                case "TypeConstraintSyntax":
                    var n132 = new TameTypeConstraintSyntax((TypeConstraintSyntax) node);
                    n132.AddChildren();
                    return n132;
                case "UsingStatementSyntax":
                    var n133 = new TameUsingStatementSyntax((UsingStatementSyntax) node);
                    n133.AddChildren();
                    return n133;
                case "WhileStatementSyntax":
                    var n134 = new TameWhileStatementSyntax((WhileStatementSyntax) node);
                    n134.AddChildren();
                    return n134;
                case "YieldStatementSyntax":
                    var n135 = new TameYieldStatementSyntax((YieldStatementSyntax) node);
                    n135.AddChildren();
                    return n135;
                case "GotoStatementSyntax":
                    var n136 = new TameGotoStatementSyntax((GotoStatementSyntax) node);
                    n136.AddChildren();
                    return n136;
                case "InterpolationSyntax":
                    var n137 = new TameInterpolationSyntax((InterpolationSyntax) node);
                    n137.AddChildren();
                    return n137;
                case "LockStatementSyntax":
                    var n138 = new TameLockStatementSyntax((LockStatementSyntax) node);
                    n138.AddChildren();
                    return n138;
                case "OrderByClauseSyntax":
                    var n139 = new TameOrderByClauseSyntax((OrderByClauseSyntax) node);
                    n139.AddChildren();
                    return n139;
                case "ParameterListSyntax":
                    var n140 = new TameParameterListSyntax((ParameterListSyntax) node);
                    n140.AddChildren();
                    return n140;
                case "QualifiedCrefSyntax":
                    var n141 = new TameQualifiedCrefSyntax((QualifiedCrefSyntax) node);
                    n141.AddChildren();
                    return n141;
                case "RefExpressionSyntax":
                    var n142 = new TameRefExpressionSyntax((RefExpressionSyntax) node);
                    n142.AddChildren();
                    return n142;
                case "ArgumentListSyntax":
                    var n143 = new TameArgumentListSyntax((ArgumentListSyntax) node);
                    n143.AddChildren();
                    return n143;
                case "ForStatementSyntax":
                    var n144 = new TameForStatementSyntax((ForStatementSyntax) node);
                    n144.AddChildren();
                    return n144;
                case "SelectClauseSyntax":
                    var n145 = new TameSelectClauseSyntax((SelectClauseSyntax) node);
                    n145.AddChildren();
                    return n145;
                case "TryStatementSyntax":
                    var n146 = new TameTryStatementSyntax((TryStatementSyntax) node);
                    n146.AddChildren();
                    return n146;
                case "DoStatementSyntax":
                    var n147 = new TameDoStatementSyntax((DoStatementSyntax) node);
                    n147.AddChildren();
                    return n147;
                case "GroupClauseSyntax":
                    var n148 = new TameGroupClauseSyntax((GroupClauseSyntax) node);
                    n148.AddChildren();
                    return n148;
                case "IfStatementSyntax":
                    var n149 = new TameIfStatementSyntax((IfStatementSyntax) node);
                    n149.AddChildren();
                    return n149;
                case "WhereClauseSyntax":
                    var n150 = new TameWhereClauseSyntax((WhereClauseSyntax) node);
                    n150.AddChildren();
                    return n150;
                case "FromClauseSyntax":
                    var n151 = new TameFromClauseSyntax((FromClauseSyntax) node);
                    n151.AddChildren();
                    return n151;
                case "JoinClauseSyntax":
                    var n152 = new TameJoinClauseSyntax((JoinClauseSyntax) node);
                    n152.AddChildren();
                    return n152;
                case "XmlCommentSyntax":
                    var n153 = new TameXmlCommentSyntax((XmlCommentSyntax) node);
                    n153.AddChildren();
                    return n153;
                case "XmlElementSyntax":
                    var n154 = new TameXmlElementSyntax((XmlElementSyntax) node);
                    n154.AddChildren();
                    return n154;
                case "LetClauseSyntax":
                    var n155 = new TameLetClauseSyntax((LetClauseSyntax) node);
                    n155.AddChildren();
                    return n155;
                case "TypeCrefSyntax":
                    var n156 = new TameTypeCrefSyntax((TypeCrefSyntax) node);
                    n156.AddChildren();
                    return n156;
                case "XmlTextSyntax":
                    var n157 = new TameXmlTextSyntax((XmlTextSyntax) node);
                    n157.AddChildren();
                    return n157;
                case "BlockSyntax":
                    var n158 = new TameBlockSyntax((BlockSyntax) node);
                    n158.AddChildren();
                    return n158;
                case "AnonymousObjectMemberDeclaratorSyntax":
                    var n159 =
                        new TameAnonymousObjectMemberDeclaratorSyntax((AnonymousObjectMemberDeclaratorSyntax) node);
                    n159.AddChildren();
                    return n159;
                case "TypeParameterConstraintClauseSyntax":
                    var n160 = new TameTypeParameterConstraintClauseSyntax((TypeParameterConstraintClauseSyntax) node);
                    n160.AddChildren();
                    return n160;
                case "InterpolationAlignmentClauseSyntax":
                    var n161 = new TameInterpolationAlignmentClauseSyntax((InterpolationAlignmentClauseSyntax) node);
                    n161.AddChildren();
                    return n161;
                case "ExplicitInterfaceSpecifierSyntax":
                    var n162 = new TameExplicitInterfaceSpecifierSyntax((ExplicitInterfaceSpecifierSyntax) node);
                    n162.AddChildren();
                    return n162;
                case "InterpolationFormatClauseSyntax":
                    var n163 = new TameInterpolationFormatClauseSyntax((InterpolationFormatClauseSyntax) node);
                    n163.AddChildren();
                    return n163;
                case "AttributeTargetSpecifierSyntax":
                    var n164 = new TameAttributeTargetSpecifierSyntax((AttributeTargetSpecifierSyntax) node);
                    n164.AddChildren();
                    return n164;
                case "ConstructorInitializerSyntax":
                    var n165 = new TameConstructorInitializerSyntax((ConstructorInitializerSyntax) node);
                    n165.AddChildren();
                    return n165;
                case "ArrowExpressionClauseSyntax":
                    var n166 = new TameArrowExpressionClauseSyntax((ArrowExpressionClauseSyntax) node);
                    n166.AddChildren();
                    return n166;
                case "AttributeArgumentListSyntax":
                    var n167 = new TameAttributeArgumentListSyntax((AttributeArgumentListSyntax) node);
                    n167.AddChildren();
                    return n167;
                case "ExternAliasDirectiveSyntax":
                    var n168 = new TameExternAliasDirectiveSyntax((ExternAliasDirectiveSyntax) node);
                    n168.AddChildren();
                    return n168;
                case "AccessorDeclarationSyntax":
                    var n169 = new TameAccessorDeclarationSyntax((AccessorDeclarationSyntax) node);
                    n169.AddChildren();
                    return n169;
                case "VariableDeclarationSyntax":
                    var n170 = new TameVariableDeclarationSyntax((VariableDeclarationSyntax) node);
                    n170.AddChildren();
                    return n170;
                case "ArrayRankSpecifierSyntax":
                    var n171 = new TameArrayRankSpecifierSyntax((ArrayRankSpecifierSyntax) node);
                    n171.AddChildren();
                    return n171;
                case "VariableDeclaratorSyntax":
                    var n172 = new TameVariableDeclaratorSyntax((VariableDeclaratorSyntax) node);
                    n172.AddChildren();
                    return n172;
                case "XmlElementStartTagSyntax":
                    var n173 = new TameXmlElementStartTagSyntax((XmlElementStartTagSyntax) node);
                    n173.AddChildren();
                    return n173;
                case "AttributeArgumentSyntax":
                    var n174 = new TameAttributeArgumentSyntax((AttributeArgumentSyntax) node);
                    n174.AddChildren();
                    return n174;
                case "CatchFilterClauseSyntax":
                    var n175 = new TameCatchFilterClauseSyntax((CatchFilterClauseSyntax) node);
                    n175.AddChildren();
                    return n175;
                case "EqualsValueClauseSyntax":
                    var n176 = new TameEqualsValueClauseSyntax((EqualsValueClauseSyntax) node);
                    n176.AddChildren();
                    return n176;
                case "QueryContinuationSyntax":
                    var n177 = new TameQueryContinuationSyntax((QueryContinuationSyntax) node);
                    n177.AddChildren();
                    return n177;
                case "TypeParameterListSyntax":
                    var n178 = new TameTypeParameterListSyntax((TypeParameterListSyntax) node);
                    n178.AddChildren();
                    return n178;
                case "CatchDeclarationSyntax":
                    var n179 = new TameCatchDeclarationSyntax((CatchDeclarationSyntax) node);
                    n179.AddChildren();
                    return n179;
                case "TypeArgumentListSyntax":
                    var n180 = new TameTypeArgumentListSyntax((TypeArgumentListSyntax) node);
                    n180.AddChildren();
                    return n180;
                case "XmlElementEndTagSyntax":
                    var n181 = new TameXmlElementEndTagSyntax((XmlElementEndTagSyntax) node);
                    n181.AddChildren();
                    return n181;
                case "CompilationUnitSyntax":
                    var n182 = new TameCompilationUnitSyntax((CompilationUnitSyntax) node);
                    n182.AddChildren();
                    return n182;
                case "JoinIntoClauseSyntax":
                    var n183 = new TameJoinIntoClauseSyntax((JoinIntoClauseSyntax) node);
                    n183.AddChildren();
                    return n183;
                case "UsingDirectiveSyntax":
                    var n184 = new TameUsingDirectiveSyntax((UsingDirectiveSyntax) node);
                    n184.AddChildren();
                    return n184;
                case "AttributeListSyntax":
                    var n185 = new TameAttributeListSyntax((AttributeListSyntax) node);
                    n185.AddChildren();
                    return n185;
                case "CrefParameterSyntax":
                    var n186 = new TameCrefParameterSyntax((CrefParameterSyntax) node);
                    n186.AddChildren();
                    return n186;
                case "FinallyClauseSyntax":
                    var n187 = new TameFinallyClauseSyntax((FinallyClauseSyntax) node);
                    n187.AddChildren();
                    return n187;
                case "SwitchSectionSyntax":
                    var n188 = new TameSwitchSectionSyntax((SwitchSectionSyntax) node);
                    n188.AddChildren();
                    return n188;
                case "TypeParameterSyntax":
                    var n189 = new TameTypeParameterSyntax((TypeParameterSyntax) node);
                    n189.AddChildren();
                    return n189;
                case "AccessorListSyntax":
                    var n190 = new TameAccessorListSyntax((AccessorListSyntax) node);
                    n190.AddChildren();
                    return n190;
                case "TupleElementSyntax":
                    var n191 = new TameTupleElementSyntax((TupleElementSyntax) node);
                    n191.AddChildren();
                    return n191;
                case "CatchClauseSyntax":
                    var n192 = new TameCatchClauseSyntax((CatchClauseSyntax) node);
                    n192.AddChildren();
                    return n192;
                case "ElseClauseSyntax":
                    var n193 = new TameElseClauseSyntax((ElseClauseSyntax) node);
                    n193.AddChildren();
                    return n193;
                case "NameEqualsSyntax":
                    var n194 = new TameNameEqualsSyntax((NameEqualsSyntax) node);
                    n194.AddChildren();
                    return n194;
                case "WhenClauseSyntax":
                    var n195 = new TameWhenClauseSyntax((WhenClauseSyntax) node);
                    n195.AddChildren();
                    return n195;
                case "AttributeSyntax":
                    var n196 = new TameAttributeSyntax((AttributeSyntax) node);
                    n196.AddChildren();
                    return n196;
                case "NameColonSyntax":
                    var n197 = new TameNameColonSyntax((NameColonSyntax) node);
                    n197.AddChildren();
                    return n197;
                case "ParameterSyntax":
                    var n198 = new TameParameterSyntax((ParameterSyntax) node);
                    n198.AddChildren();
                    return n198;
                case "QueryBodySyntax":
                    var n199 = new TameQueryBodySyntax((QueryBodySyntax) node);
                    n199.AddChildren();
                    return n199;
                case "XmlPrefixSyntax":
                    var n200 = new TameXmlPrefixSyntax((XmlPrefixSyntax) node);
                    n200.AddChildren();
                    return n200;
                case "ArgumentSyntax":
                    var n201 = new TameArgumentSyntax((ArgumentSyntax) node);
                    n201.AddChildren();
                    return n201;
                case "BaseListSyntax":
                    var n202 = new TameBaseListSyntax((BaseListSyntax) node);
                    n202.AddChildren();
                    return n202;
                case "OrderingSyntax":
                    var n203 = new TameOrderingSyntax((OrderingSyntax) node);
                    n203.AddChildren();
                    return n203;
                case "XmlNameSyntax":
                    var n204 = new TameXmlNameSyntax((XmlNameSyntax) node);
                    n204.AddChildren();
                    return n204;
            }
            return null;
        }
    }
}