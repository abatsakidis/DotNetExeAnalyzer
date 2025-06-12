using Microsoft.Win32;
using Mono.Cecil;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace DotNetExeAnalyzer
{
    public partial class MainWindow : MahApps.Metro.Controls.MetroWindow
    {
        // Store the types and methods as model objects for filtering
        private List<TypeDefinition> allTypes = new();
        private MethodDefinition currentMethod;
        private bool isPlaceholderActive = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        // Open .NET executable or DLL file and load types, methods, references
        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog
            {
                Filter = "Executable or DLL (*.exe;*.dll)|*.exe;*.dll"
            };

            if (dialog.ShowDialog() != true)
                return;

            txtFileInfo.Text = "";
            txtIL.Clear();
            lstReferences.Items.Clear();
            allTypes.Clear();

            try
            {
                var assembly = AssemblyDefinition.ReadAssembly(dialog.FileName);
                var module = assembly.MainModule;

                txtFileInfo.Text = $"{assembly.Name.Name}, Version={assembly.Name.Version}, Runtime={module.Runtime}";

                foreach (var reference in module.AssemblyReferences)
                {
                    lstReferences.Items.Add($"{reference.Name}, Version={reference.Version}");
                }

                foreach (var type in module.Types)
                {
                    allTypes.Add(type);
                }

                // Reset filter to placeholder state
                isPlaceholderActive = true;
                txtFilter.Text = "Search...";
                txtFilter.Foreground = Brushes.Gray;

                RefreshTreeView(allTypes);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Refresh TreeView items from a list of TypeDefinition objects
        private void RefreshTreeView(List<TypeDefinition> typesToShow)
        {
            var treeItems = new List<TreeViewItem>();

            foreach (var type in typesToShow)
            {
                var typeItem = new TreeViewItem { Header = type.FullName };

                foreach (var method in type.Methods)
                {
                    var methodItem = new TreeViewItem { Header = method.Name, Tag = method };
                    typeItem.Items.Add(methodItem);
                }

                treeItems.Add(typeItem);
            }

            treeView.ItemsSource = treeItems;
        }

        // Display IL code for the selected method in the TreeView
        private void TreeView_SelectedItemChanged(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            txtIL.Clear();
            currentMethod = null;

            if (treeView.SelectedItem is TreeViewItem item && item.Tag is MethodDefinition method && method.HasBody)
            {
                currentMethod = method;
                foreach (var instr in method.Body.Instructions)
                {
                    txtIL.AppendText($"IL_{instr.Offset:X4}: {instr.OpCode} {instr.Operand}\n");
                }
            }
        }

        // Filter methods and types based on search box input
        private void txtFilter_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (isPlaceholderActive) return;

            string filter = txtFilter.Text.ToLower();
            var filteredTypes = new List<TypeDefinition>();

            foreach (var type in allTypes)
            {
                bool typeMatches = type.FullName.ToLower().Contains(filter);

                bool anyMethodMatches = false;
                foreach (var method in type.Methods)
                {
                    if (method.Name.ToLower().Contains(filter))
                    {
                        anyMethodMatches = true;
                        break;
                    }
                }

                if (typeMatches || anyMethodMatches)
                {
                    filteredTypes.Add(type);
                }
            }

            RefreshTreeView(filteredTypes);
        }

        // Copy IL code to clipboard
        private void CopyIL_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtIL.Text))
            {
                Clipboard.SetText(txtIL.Text);
                MessageBox.Show("IL code copied to clipboard.", "Copy", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Export IL code to a text file
        private void ExportIL_Click(object sender, RoutedEventArgs e)
        {
            if (currentMethod == null)
            {
                MessageBox.Show("Please select a method first.", "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var saveDialog = new SaveFileDialog
            {
                Filter = "Text Files (*.txt)|*.txt",
                FileName = $"{currentMethod.Name}_IL.txt"
            };

            if (saveDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveDialog.FileName, txtIL.Text);
                MessageBox.Show("File saved successfully.", "Save", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        // Placeholder behavior: clear on focus
        private void txtFilter_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isPlaceholderActive)
            {
                txtFilter.Text = "";
                txtFilter.Foreground = Brushes.Black;
                isPlaceholderActive = false;
            }
        }

        // Placeholder behavior: restore if empty on lost focus
        private void txtFilter_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFilter.Text))
            {
                isPlaceholderActive = true;
                txtFilter.Text = "Search...";
                txtFilter.Foreground = Brushes.Gray;
            }
        }
    }
}
