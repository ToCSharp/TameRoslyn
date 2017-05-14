# TameRoslyn
The mutable wrapper of Microsoft's [.NET Compiler Platform ("Roslyn")](https://github.com/dotnet/roslyn) syntax tree.
For simple manipulation of C# files.

## Install TameRoslyn via NuGet

.Net Framework >= 4.6.2 require.
If you want to include TameRoslyn in your project, you can [install it directly from NuGet](https://www.nuget.org/packages/TameRoslyn/)

```
PM> Install-Package TameRoslyn
```

## Example
Look at TameRoslynExample.
```csharp
            // Make class by setting props.
            // Wrapped SyntaxNodes in classes which starts with "Tame"
            var newClass = new TameClassDeclarationSyntax
            {
                Name = "MyClass",
                ModifiersStr = "public static",
            };
            // SyntaxNode of newClass
            var newClassNode = newClass.Node;

            // Add method to class. Wrapped properties starts with "Ta"
            newClass.TaMembers.Add(new TameMethodDeclarationSyntax
            {
                // setting props by SyntaxNodes
                Identifier = SyntaxFactory.Identifier("MyMethod"),
                // or by strings
                //IdentifierStr = "MyMethod",
                ModifiersStr = "public static",
                ParameterListStr = "(string s, int i)",
                // or by tame classes
                TaTypeParameterList = new TameTypeParameterListSyntax("<T>"),
                // TaParent must be set when add directly to lists
                TaParent = newClass
            });

            // add method to class by code
            newClass.TaMembers.Add(new TameMethodDeclarationSyntax("private void Meth2() {}") { TaParent = newClass });
            // adding directly to lists IsChanged must be set to true
            newClass.IsChanged = true;

            // or add member by AddMember method 
            // It sets TaParent and IsChanged
            newClass.AddMember(new TameMethodDeclarationSyntax("public void Meth3() {}"));

            // change Modifiers of first Method
            newClass.TaMembers.OfType<TameMethodDeclarationSyntax>().FirstOrDefault()?.SetModifiersStr("private");

            // source of newClass
            tbSource.Text = newClass.FormatedSource;
            // SyntaxNode of newClass with all we made
            newClassNode = newClass.Node;

            // make CompilationUnit with namespace
            var cu = new TameCompilationUnitSyntax();
            var ns = new TameNamespaceDeclarationSyntax { NameStr = "MyNamespace" };
            ns.TaMembers.Add(newClass);
            cu.TaMembers.Add(ns);

            // example of changing lists
            var ps = cu.Methods.FirstOrDefault()?.TaParameterList;
            if (ps?.TaParameters?.Any() == true)
            {
                // (string s, int i) => (int i)
                ps.TaParameters.RemoveAt(0);
                // when change List, IsChanged must be set to true
                ps.IsChanged = true;
            }

            // source of CompilationUnit
            tbSource.Text = cu.FormatedSource;
            // SyntaxNode of CompilationUnit
            var newCuNode = cu.Node;

            // The same CompilationUnit
            var cu2 = TameCompilationUnitSyntax.FromCode(@"
namespace MyNamespace
{
    public static class MyClass
    {
        private void MyMethod<T>(int i)
        {
        }

        private void Meth2()
        {
        }

        public void Meth3()
        {
        }
    }
}");
            tbNewSource.Text = cu2.FormatedSource;

```
