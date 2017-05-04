using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.Win32;
using Zu.TameRoslyn.Syntax;

namespace TameRoslynExample
{
    public partial class MainWindow : Window
    {
        private readonly ObservableCollection<TameBaseRoslynNode> _nodeChangeItems =
            new ObservableCollection<TameBaseRoslynNode>();

        private TameCompilationUnitSyntax _currentCU;
        private string _currentSource;
        private TameBaseRoslynNode _selectedNode;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                var fileName = openFileDialog.FileName;
                tbSource.Text = File.ReadAllText(fileName);
                tbFileName.Text = Path.GetFileName(fileName);
            }
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            _currentSource = tbSource.Text;
            _currentCU = TameCompilationUnitSyntax.FromCode(_currentSource);
            //var root = CSharpSyntaxTree.ParseText(code).GetRoot();
            var usings = _currentCU.DescendantsAll().OfType<TameUsingDirectiveSyntax>().Select(v => v.NameStr).ToList();
            lbNodes.ItemsSource = _currentCU.DescendantsAll();
            tbStringTree.Text = _currentCU.ToStringTree(null, 0, 70).ToString();
        }

        private void Button_Click_16(object sender, RoutedEventArgs e)
        {
            var searchStr = tbSearchStr.Text.ToLower();
            var ind = lbNodes.SelectedIndex + 1;
            while (ind < lbNodes.Items.Count &&
                   (lbNodes.Items[ind] as TameBaseRoslynNode)?.ToString().ToLower().Contains(searchStr) != true) ind++;
            if (ind < lbNodes.Items.Count) lbNodes.SelectedIndex = ind;
            if (lbNodes.SelectedItem != null)
                lbNodes.ScrollIntoView(lbNodes.SelectedItem);
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            tbNewSource.Text = _currentCU.FormatedSource;
        }


        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (_selectedNode != null)
                try
                {
                    var code = tbNodeText.Text;
                    //_selectedNode.ReplaceNode(CreateSyntaxNode.CreateFormCode(code, _selectedNode.RoslynTypeName));
                    _selectedNode.ReplaceNode(code);
                    lbNodes.ItemsSource = _currentCU.DescendantsAll();
                    tbStringTree.Text = _currentCU.ToStringTree(null, 0, 70).ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
        }

        private void lbNodes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedNode = lbNodes.SelectedItem as TameBaseRoslynNode;
            tbNodeText.Text = _selectedNode?.FormatedSource;
            var fields = _selectedNode?.GetAllChildren();
            lbTameFields.ItemsSource = fields;
            lbStringProps.ItemsSource = _selectedNode?.GetStringFields().Select(v => $"{v.filedName} = \"{v.value}\"");
        }

        private void lbChanges_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _selectedNode = lbTameFields.SelectedItem as TameBaseRoslynNode;
            if (_selectedNode != null) tbNodeText.Text = _selectedNode.FormatedSource;
        }

        private void ButtonCreateCU_Click(object sender, RoutedEventArgs e)
        {
            // Make class by setting props.
            // Wrapped SyntaxNodes in classes which start with "Tame"
            var newClass = new TameClassDeclarationSyntax
            {
                Name = "MyClass",
                ModifiersStr = "public static"
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
            newClass.TaMembers.Add(new TameMethodDeclarationSyntax("private void Meth2() {}") {TaParent = newClass});
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
            var ns = new TameNamespaceDeclarationSyntax {NameStr = "MyNamespace"};
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
        }
    }
}