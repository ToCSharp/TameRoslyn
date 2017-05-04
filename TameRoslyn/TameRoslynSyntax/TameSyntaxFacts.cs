// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis.CSharp;

namespace Zu.TameRoslyn.Syntax
{
    public static class TameSyntaxFacts
    {
        public static SyntaxKind GetKindBinaryExpression(string kind)
        {
            switch (kind)
            {
                case "+":
                    return SyntaxKind.AddExpression;

                case "-":

                    return SyntaxKind.SubtractExpression;


                case "*":

                    return SyntaxKind.MultiplyExpression;


                case "/":

                    return SyntaxKind.DivideExpression;


                case "%":

                    return SyntaxKind.ModuloExpression;


                case "<<":

                    return SyntaxKind.LeftShiftExpression;


                case ">>":

                    return SyntaxKind.RightShiftExpression;


                case "||":

                    return SyntaxKind.LogicalOrExpression;


                case "&&":

                    return SyntaxKind.LogicalAndExpression;


                case "|":

                    return SyntaxKind.BitwiseOrExpression;


                case "&":

                    return SyntaxKind.BitwiseAndExpression;


                case "^":

                    return SyntaxKind.ExclusiveOrExpression;


                case "==":

                    return SyntaxKind.EqualsExpression;


                case "!=":

                    return SyntaxKind.NotEqualsExpression;


                case "<":

                    return SyntaxKind.LessThanExpression;


                case "<=":

                    return SyntaxKind.LessThanOrEqualExpression;


                case ">":

                    return SyntaxKind.GreaterThanExpression;


                case ">=":

                    return SyntaxKind.GreaterThanOrEqualExpression;


                case "as":

                    return SyntaxKind.AsExpression;


                case "is":

                    return SyntaxKind.IsExpression;


                case "??":

                    return SyntaxKind.CoalesceExpression;


                case ".":

                    return SyntaxKind.SimpleMemberAccessExpression;


                case "->":

                    return SyntaxKind.PointerMemberAccessExpression;
            }
            return SyntaxKind.None;
        }

        internal static SyntaxKind GetKindAssignmentExpression(string kind)
        {
            switch (kind)
            {
                case "=":
                {
                    return SyntaxKind.SimpleAssignmentExpression;
                }

                case "+=":
                {
                    return SyntaxKind.AddAssignmentExpression;
                }

                case "-=":
                {
                    return SyntaxKind.SubtractAssignmentExpression;
                }

                case "*=":
                {
                    return SyntaxKind.MultiplyAssignmentExpression;
                }

                case "/=":
                {
                    return SyntaxKind.DivideAssignmentExpression;
                }

                case "%=":
                {
                    return SyntaxKind.ModuloAssignmentExpression;
                }

                case "&=":
                {
                    return SyntaxKind.AndAssignmentExpression;
                }

                case "^=":
                {
                    return SyntaxKind.ExclusiveOrAssignmentExpression;
                }

                case "|=":
                {
                    return SyntaxKind.OrAssignmentExpression;
                }

                case "<<=":
                {
                    return SyntaxKind.LeftShiftAssignmentExpression;
                }

                case ">>=":
                {
                    return SyntaxKind.RightShiftAssignmentExpression;
                }
                //case "==":
                //    {
                //        return SyntaxKind.EqualsEqualsToken;
                //    }
            }
            return SyntaxKind.None;
        }

        //public static SyntaxKind GetLiteralExpression(SyntaxKind token)
        //{
        //    switch (token)
        //    {
        //        case SyntaxKind.StringLiteralToken:
        //            return SyntaxKind.StringLiteralExpression;
        //        case SyntaxKind.CharacterLiteralToken:
        //            return SyntaxKind.CharacterLiteralExpression;
        //        case SyntaxKind.NumericLiteralToken:
        //            return SyntaxKind.NumericLiteralExpression;
        //        case SyntaxKind.NullKeyword:
        //            return SyntaxKind.NullLiteralExpression;
        //        case SyntaxKind.TrueKeyword:
        //            return SyntaxKind.TrueLiteralExpression;
        //        case SyntaxKind.FalseKeyword:
        //            return SyntaxKind.FalseLiteralExpression;
        //        case SyntaxKind.ArgListKeyword:
        //            return SyntaxKind.ArgListExpression;
        //        default:
        //            return SyntaxKind.None;
        //    }
        //}

        public static SyntaxKind SyntaxKindFromStr(string kind)
        {
            switch (kind)
            {
                case "~":
                {
                    return SyntaxKind.TildeToken;
                }

                case "!":
                {
                    return SyntaxKind.ExclamationToken;
                }

                case "$":
                {
                    return SyntaxKind.DollarToken;
                }

                case "%":
                {
                    return SyntaxKind.PercentToken;
                }

                case "^":
                {
                    return SyntaxKind.CaretToken;
                }

                case "&":
                {
                    return SyntaxKind.AmpersandToken;
                }

                case "*":
                {
                    return SyntaxKind.AsteriskToken;
                }

                case "(":
                {
                    return SyntaxKind.OpenParenToken;
                }

                case ")":
                {
                    return SyntaxKind.CloseParenToken;
                }

                case "-":
                {
                    return SyntaxKind.MinusToken;
                }

                case "+":
                {
                    return SyntaxKind.PlusToken;
                }

                case "=":
                {
                    return SyntaxKind.EqualsToken;
                }

                case "{":
                {
                    return SyntaxKind.OpenBraceToken;
                }

                case "}":
                {
                    return SyntaxKind.CloseBraceToken;
                }

                case "[":
                {
                    return SyntaxKind.OpenBracketToken;
                }

                case "]":
                {
                    return SyntaxKind.CloseBracketToken;
                }

                case "|":
                {
                    return SyntaxKind.BarToken;
                }

                case "\\":
                {
                    return SyntaxKind.BackslashToken;
                }

                case ":":
                {
                    return SyntaxKind.ColonToken;
                }

                case ";":
                {
                    return SyntaxKind.SemicolonToken;
                }

                case "\"":
                {
                    return SyntaxKind.DoubleQuoteToken;
                    //return SyntaxKind.InterpolatedStringEndToken; todo ??
                }

                case "'":
                {
                    return SyntaxKind.SingleQuoteToken;
                }

                case "<":
                {
                    return SyntaxKind.LessThanToken;
                }

                case ",":
                {
                    return SyntaxKind.CommaToken;
                }

                case ">":
                {
                    return SyntaxKind.GreaterThanToken;
                }

                case ".":
                {
                    return SyntaxKind.DotToken;
                }

                case "?":
                {
                    return SyntaxKind.QuestionToken;
                }

                case "#":
                {
                    return SyntaxKind.HashToken;
                }

                case "/":
                {
                    return SyntaxKind.SlashToken;
                }

                case "/>":
                {
                    return SyntaxKind.SlashGreaterThanToken;
                }

                case "</":
                {
                    return SyntaxKind.LessThanSlashToken;
                }

                case "<!--":
                {
                    return SyntaxKind.XmlCommentStartToken;
                }

                case "-->":
                {
                    return SyntaxKind.XmlCommentEndToken;
                }

                case "<![CDATA[":
                {
                    return SyntaxKind.XmlCDataStartToken;
                }

                case "]]>":
                {
                    return SyntaxKind.XmlCDataEndToken;
                }

                case "<?":
                {
                    return SyntaxKind.XmlProcessingInstructionStartToken;
                }

                case "?>":
                {
                    return SyntaxKind.XmlProcessingInstructionEndToken;
                }

                case "||":
                {
                    return SyntaxKind.BarBarToken;
                }

                case "&&":
                {
                    return SyntaxKind.AmpersandAmpersandToken;
                }

                case "--":
                {
                    return SyntaxKind.MinusMinusToken;
                }

                case "++":
                {
                    return SyntaxKind.PlusPlusToken;
                }

                case "::":
                {
                    return SyntaxKind.ColonColonToken;
                }

                case "??":
                {
                    return SyntaxKind.QuestionQuestionToken;
                }

                case "->":
                {
                    return SyntaxKind.MinusGreaterThanToken;
                }

                case "!=":
                {
                    return SyntaxKind.ExclamationEqualsToken;
                }

                case "==":
                {
                    return SyntaxKind.EqualsEqualsToken;
                }

                case "=>":
                {
                    return SyntaxKind.EqualsGreaterThanToken;
                }

                case "<=":
                {
                    return SyntaxKind.LessThanEqualsToken;
                }

                case "<<":
                {
                    return SyntaxKind.LessThanLessThanToken;
                }

                case "<<=":
                {
                    return SyntaxKind.LessThanLessThanEqualsToken;
                }

                case ">=":
                {
                    return SyntaxKind.GreaterThanEqualsToken;
                }

                case ">>":
                {
                    return SyntaxKind.GreaterThanGreaterThanToken;
                }

                case ">>=":
                {
                    return SyntaxKind.GreaterThanGreaterThanEqualsToken;
                }

                case "/=":
                {
                    return SyntaxKind.SlashEqualsToken;
                }

                case "*=":
                {
                    return SyntaxKind.AsteriskEqualsToken;
                }

                case "|=":
                {
                    return SyntaxKind.BarEqualsToken;
                }

                case "&=":
                {
                    return SyntaxKind.AmpersandEqualsToken;
                }

                case "+=":
                {
                    return SyntaxKind.PlusEqualsToken;
                }

                case "-=":
                {
                    return SyntaxKind.MinusEqualsToken;
                }

                case "^=":
                {
                    return SyntaxKind.CaretEqualsToken;
                }

                case "%=":
                {
                    return SyntaxKind.PercentEqualsToken;
                }

                case "bool":
                {
                    return SyntaxKind.BoolKeyword;
                }

                case "byte":
                {
                    return SyntaxKind.ByteKeyword;
                }

                case "sbyte":
                {
                    return SyntaxKind.SByteKeyword;
                }

                case "short":
                {
                    return SyntaxKind.ShortKeyword;
                }

                case "ushort":
                {
                    return SyntaxKind.UShortKeyword;
                }

                case "int":
                {
                    return SyntaxKind.IntKeyword;
                }

                case "uint":
                {
                    return SyntaxKind.UIntKeyword;
                }

                case "long":
                {
                    return SyntaxKind.LongKeyword;
                }

                case "ulong":
                {
                    return SyntaxKind.ULongKeyword;
                }

                case "double":
                {
                    return SyntaxKind.DoubleKeyword;
                }

                case "float":
                {
                    return SyntaxKind.FloatKeyword;
                }

                case "decimal":
                {
                    return SyntaxKind.DecimalKeyword;
                }

                case "string":
                {
                    return SyntaxKind.StringKeyword;
                }

                case "char":
                {
                    return SyntaxKind.CharKeyword;
                }

                case "void":
                {
                    return SyntaxKind.VoidKeyword;
                }

                case "object":
                {
                    return SyntaxKind.ObjectKeyword;
                }

                case "typeof":
                {
                    return SyntaxKind.TypeOfKeyword;
                }

                case "sizeof":
                {
                    return SyntaxKind.SizeOfKeyword;
                }

                case "null":
                {
                    return SyntaxKind.NullKeyword;
                }

                case "true":
                {
                    return SyntaxKind.TrueKeyword;
                }

                case "false":
                {
                    return SyntaxKind.FalseKeyword;
                }

                case "if":
                {
                    return SyntaxKind.IfKeyword;
                }

                case "else":
                {
                    return SyntaxKind.ElseKeyword;
                }

                case "while":
                {
                    return SyntaxKind.WhileKeyword;
                }

                case "for":
                {
                    return SyntaxKind.ForKeyword;
                }

                case "foreach":
                {
                    return SyntaxKind.ForEachKeyword;
                }

                case "do":
                {
                    return SyntaxKind.DoKeyword;
                }

                case "switch":
                {
                    return SyntaxKind.SwitchKeyword;
                }

                case "case":
                {
                    return SyntaxKind.CaseKeyword;
                }

                case "default":
                {
                    return SyntaxKind.DefaultKeyword;
                }

                case "try":
                {
                    return SyntaxKind.TryKeyword;
                }

                case "catch":
                {
                    return SyntaxKind.CatchKeyword;
                }

                case "finally":
                {
                    return SyntaxKind.FinallyKeyword;
                }

                case "lock":
                {
                    return SyntaxKind.LockKeyword;
                }

                case "goto":
                {
                    return SyntaxKind.GotoKeyword;
                }

                case "break":
                {
                    return SyntaxKind.BreakKeyword;
                }

                case "continue":
                {
                    return SyntaxKind.ContinueKeyword;
                }

                case "return":
                {
                    return SyntaxKind.ReturnKeyword;
                }

                case "throw":
                {
                    return SyntaxKind.ThrowKeyword;
                }

                case "public":
                {
                    return SyntaxKind.PublicKeyword;
                }

                case "private":
                {
                    return SyntaxKind.PrivateKeyword;
                }

                case "internal":
                {
                    return SyntaxKind.InternalKeyword;
                }

                case "protected":
                {
                    return SyntaxKind.ProtectedKeyword;
                }

                case "static":
                {
                    return SyntaxKind.StaticKeyword;
                }

                case "readonly":
                {
                    return SyntaxKind.ReadOnlyKeyword;
                }

                case "sealed":
                {
                    return SyntaxKind.SealedKeyword;
                }

                case "const":
                {
                    return SyntaxKind.ConstKeyword;
                }

                case "fixed":
                {
                    return SyntaxKind.FixedKeyword;
                }

                case "stackalloc":
                {
                    return SyntaxKind.StackAllocKeyword;
                }

                case "volatile":
                {
                    return SyntaxKind.VolatileKeyword;
                }

                case "new":
                {
                    return SyntaxKind.NewKeyword;
                }

                case "override":
                {
                    return SyntaxKind.OverrideKeyword;
                }

                case "abstract":
                {
                    return SyntaxKind.AbstractKeyword;
                }

                case "virtual":
                {
                    return SyntaxKind.VirtualKeyword;
                }

                case "event":
                {
                    return SyntaxKind.EventKeyword;
                }

                case "extern":
                {
                    return SyntaxKind.ExternKeyword;
                }

                case "ref":
                {
                    return SyntaxKind.RefKeyword;
                }

                case "out":
                {
                    return SyntaxKind.OutKeyword;
                }

                case "in":
                {
                    return SyntaxKind.InKeyword;
                }

                case "is":
                {
                    return SyntaxKind.IsKeyword;
                }

                case "as":
                {
                    return SyntaxKind.AsKeyword;
                }

                case "params":
                {
                    return SyntaxKind.ParamsKeyword;
                }

                case "__arglist":
                {
                    return SyntaxKind.ArgListKeyword;
                }

                case "__makeref":
                {
                    return SyntaxKind.MakeRefKeyword;
                }

                case "__reftype":
                {
                    return SyntaxKind.RefTypeKeyword;
                }

                case "__refvalue":
                {
                    return SyntaxKind.RefValueKeyword;
                }

                case "this":
                {
                    return SyntaxKind.ThisKeyword;
                }

                case "base":
                {
                    return SyntaxKind.BaseKeyword;
                }

                case "namespace":
                {
                    return SyntaxKind.NamespaceKeyword;
                }

                case "using":
                {
                    return SyntaxKind.UsingKeyword;
                }

                case "class":
                {
                    return SyntaxKind.ClassKeyword;
                }

                case "struct":
                {
                    return SyntaxKind.StructKeyword;
                }

                case "interface":
                {
                    return SyntaxKind.InterfaceKeyword;
                }

                case "enum":
                {
                    return SyntaxKind.EnumKeyword;
                }

                case "delegate":
                {
                    return SyntaxKind.DelegateKeyword;
                }

                case "checked":
                {
                    return SyntaxKind.CheckedKeyword;
                }

                case "unchecked":
                {
                    return SyntaxKind.UncheckedKeyword;
                }

                case "unsafe":
                {
                    return SyntaxKind.UnsafeKeyword;
                }

                case "operator":
                {
                    return SyntaxKind.OperatorKeyword;
                }

                case "implicit":
                {
                    return SyntaxKind.ImplicitKeyword;
                }

                case "explicit":
                {
                    return SyntaxKind.ExplicitKeyword;
                }

                case "elif":
                {
                    return SyntaxKind.ElifKeyword;
                }

                case "endif":
                {
                    return SyntaxKind.EndIfKeyword;
                }

                case "region":
                {
                    return SyntaxKind.RegionKeyword;
                }

                case "endregion":
                {
                    return SyntaxKind.EndRegionKeyword;
                }

                case "define":
                {
                    return SyntaxKind.DefineKeyword;
                }

                case "undef":
                {
                    return SyntaxKind.UndefKeyword;
                }

                case "warning":
                {
                    return SyntaxKind.WarningKeyword;
                }

                case "error":
                {
                    return SyntaxKind.ErrorKeyword;
                }

                case "line":
                {
                    return SyntaxKind.LineKeyword;
                }

                case "pragma":
                {
                    return SyntaxKind.PragmaKeyword;
                }

                case "hidden":
                {
                    return SyntaxKind.HiddenKeyword;
                }

                case "checksum":
                {
                    return SyntaxKind.ChecksumKeyword;
                }

                case "disable":
                {
                    return SyntaxKind.DisableKeyword;
                }

                case "restore":
                {
                    return SyntaxKind.RestoreKeyword;
                }

                case "r":
                {
                    return SyntaxKind.ReferenceKeyword;
                }

                case "load":
                {
                    return SyntaxKind.LoadKeyword;
                }

                case "yield":
                {
                    return SyntaxKind.YieldKeyword;
                }

                case "partial":
                {
                    return SyntaxKind.PartialKeyword;
                }

                case "from":
                {
                    return SyntaxKind.FromKeyword;
                }

                case "group":
                {
                    return SyntaxKind.GroupKeyword;
                }

                case "join":
                {
                    return SyntaxKind.JoinKeyword;
                }

                case "into":
                {
                    return SyntaxKind.IntoKeyword;
                }

                case "let":
                {
                    return SyntaxKind.LetKeyword;
                }

                case "by":
                {
                    return SyntaxKind.ByKeyword;
                }

                case "where":
                {
                    return SyntaxKind.WhereKeyword;
                }

                case "select":
                {
                    return SyntaxKind.SelectKeyword;
                }

                case "get":
                {
                    return SyntaxKind.GetKeyword;
                }

                case "set":
                {
                    return SyntaxKind.SetKeyword;
                }

                case "add":
                {
                    return SyntaxKind.AddKeyword;
                }

                case "remove":
                {
                    return SyntaxKind.RemoveKeyword;
                }

                case "orderby":
                {
                    return SyntaxKind.OrderByKeyword;
                }

                case "alias":
                {
                    return SyntaxKind.AliasKeyword;
                }

                case "on":
                {
                    return SyntaxKind.OnKeyword;
                }

                case "equals":
                {
                    return SyntaxKind.EqualsKeyword;
                }

                case "ascending":
                {
                    return SyntaxKind.AscendingKeyword;
                }

                case "descending":
                {
                    return SyntaxKind.DescendingKeyword;
                }

                case "assembly":
                {
                    return SyntaxKind.AssemblyKeyword;
                }

                case "module":
                {
                    return SyntaxKind.ModuleKeyword;
                }

                case "type":
                {
                    return SyntaxKind.TypeKeyword;
                }

                case "field":
                {
                    return SyntaxKind.FieldKeyword;
                }

                case "method":
                {
                    return SyntaxKind.MethodKeyword;
                }

                case "param":
                {
                    return SyntaxKind.ParamKeyword;
                }

                case "property":
                {
                    return SyntaxKind.PropertyKeyword;
                }

                case "typevar":
                {
                    return SyntaxKind.TypeVarKeyword;
                }

                case "global":
                {
                    return SyntaxKind.GlobalKeyword;
                }

                case "async":
                {
                    return SyntaxKind.AsyncKeyword;
                }

                case "await":
                {
                    return SyntaxKind.AwaitKeyword;
                }

                case "when":
                {
                    return SyntaxKind.WhenKeyword;
                }

                case "nameof":
                {
                    return SyntaxKind.NameOfKeyword;
                }

                case "$@\"":
                {
                    return SyntaxKind.InterpolatedVerbatimStringStartToken;
                }

                case "$\"":
                {
                    return SyntaxKind.InterpolatedStringStartToken;
                }
            }

            return SyntaxKind.None;
        }
    }
}