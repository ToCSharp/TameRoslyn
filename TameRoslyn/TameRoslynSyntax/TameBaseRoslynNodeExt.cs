// Copyright (c) Oleg Zudov. All Rights Reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;

//using Microsoft.CodeAnalysis.Formatting;
//using Microsoft.CodeAnalysis.MSBuild;

namespace Zu.TameRoslyn.Syntax
{
    public abstract partial class TameBaseRoslynNode
    {
        public TameClassDeclarationSyntax Class
        {
            get
            {
                var cl = Ancestors(true).OfType<TameClassDeclarationSyntax>().FirstOrDefault() ??
                         DescendantsAll().OfType<TameClassDeclarationSyntax>().FirstOrDefault();
                return cl;
            }
            set
            {
                var cl = Ancestors(true).OfType<TameClassDeclarationSyntax>().FirstOrDefault() ??
                         DescendantsAll().OfType<TameClassDeclarationSyntax>().FirstOrDefault();
                if (cl != null)
                {
                    cl.ReplaceNode(value.Node);
                }
                else
                {
                    if (Namespace != null)
                    {
                        Namespace.TaMembers.Add(value);
                    }
                    else
                    {
                        var cu = Ancestors(true).OfType<TameCompilationUnitSyntax>().FirstOrDefault();
                        cu?.TaMembers.Add(value);
                    }
                }
            }
        }

        public IEnumerable<TameClassDeclarationSyntax> Classes => DescendantsAll().OfType<TameClassDeclarationSyntax>();

        public IEnumerable<TameMethodDeclarationSyntax> Methods => DescendantsAll()
            .OfType<TameMethodDeclarationSyntax>();

        public TameNamespaceDeclarationSyntax Namespace
        {
            get
            {
                var ns = Ancestors(true).OfType<TameNamespaceDeclarationSyntax>().FirstOrDefault() ??
                         DescendantsAll().OfType<TameNamespaceDeclarationSyntax>().FirstOrDefault();
                return ns;
            }
            set
            {
                var ns = Ancestors(true).OfType<TameNamespaceDeclarationSyntax>().FirstOrDefault() ??
                         DescendantsAll().OfType<TameNamespaceDeclarationSyntax>().FirstOrDefault();
                if (ns != null) ns.ReplaceNode(value.Node);
                else
                    Ancestors(true).OfType<TameCompilationUnitSyntax>().FirstOrDefault()?.TaMembers.Add(value);
            }
        }

        public TameMethodDeclarationSyntax Method
        {
            get => Ancestors(true).OfType<TameMethodDeclarationSyntax>().FirstOrDefault() ??
                   DescendantsAll().OfType<TameMethodDeclarationSyntax>().FirstOrDefault();
            set
            {
                var m = Ancestors(true).OfType<TameMethodDeclarationSyntax>().FirstOrDefault() ??
                        DescendantsAll().OfType<TameMethodDeclarationSyntax>().FirstOrDefault();
                if (m != null)
                {
                    m.ReplaceNode(value.Node);
                }
                else
                {
                    if (Class != null) Class.TaMembers.Add(value);
                    else
                        Ancestors(true).OfType<TameCompilationUnitSyntax>().FirstOrDefault()?.TaMembers.Add(value);
                }
            }
        }
    }
}