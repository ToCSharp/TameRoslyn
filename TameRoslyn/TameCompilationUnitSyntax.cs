// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace Zu.TameRoslyn.Syntax
{
    public partial class TameCompilationUnitSyntax : TameBaseRoslynNode
    {
        public TameCompilationUnitSyntax(SyntaxNode root)
        {
            Node = root;
            AddChildren();
        }
        public static TameCompilationUnitSyntax FromFile(string fileName)
        {
            var root = CSharpSyntaxTree.ParseText(File.ReadAllText(fileName)).GetRoot();
            return new TameCompilationUnitSyntax(root);
        }

        public static TameCompilationUnitSyntax FromCode(string code)
        {
            var root = CSharpSyntaxTree.ParseText(code).GetRoot();
            return new TameCompilationUnitSyntax(root);
        }

        public IEnumerable<TameClassDeclarationSyntax> GetAllClasses()
        {
            return Descendants().OfType<TameClassDeclarationSyntax>();
        }

        public IEnumerable<TameInterfaceDeclarationSyntax> GetAllInterfaces()
        {
            return Descendants().OfType<TameInterfaceDeclarationSyntax>();
        }

        public IEnumerable<TameMethodDeclarationSyntax> GetAllMethods()
        {
            return Descendants().OfType<TameMethodDeclarationSyntax>();
        }


        public TameInterfaceDeclarationSyntax GetFirstInterface()
        {
            return Descendants().OfType<TameInterfaceDeclarationSyntax>().FirstOrDefault();
        }
    }
}