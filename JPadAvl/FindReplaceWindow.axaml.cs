using Avalonia.Controls;
using Avalonia.Interactivity;
using AvaloniaEdit;
using System;

namespace JPadAvl
{
    public partial class FindReplaceWindow : Window
    {
        private readonly TextEditor editor;
        private int lastIndex = 0;

        public FindReplaceWindow(TextEditor editor)
        {
            InitializeComponent();
            this.editor = editor;
        }

        private void FindNext_Click(object sender, RoutedEventArgs e)
        {
            var text = editor.Text;
            var search = findBox.Text;

            if (string.IsNullOrEmpty(search)) return;

            var index = text.IndexOf(search, lastIndex + 1, StringComparison.OrdinalIgnoreCase);
            if (index >= 0)
            {
                editor.SelectionStart = index;
                editor.SelectionLength = search.Length;
                editor.ScrollToLine(editor.Document.GetLineByOffset(index).LineNumber);
                lastIndex = index;
            }
            else
            {
                lastIndex = 0;
            }
        }

        private void Replace_Click(object sender, RoutedEventArgs e)
        {
            if (editor.SelectionLength > 0 && editor.SelectedText.Equals(findBox.Text, StringComparison.OrdinalIgnoreCase))
            {
                var offset = editor.SelectionStart;
                editor.Document.Replace(offset, editor.SelectionLength, replaceBox.Text);
                lastIndex = offset + replaceBox.Text.Length;
            }

            FindNext_Click(sender, e);
        }

        private void ReplaceAll_Click(object sender, RoutedEventArgs e)
        {
            var text = editor.Text;
            var search = findBox.Text;
            var replace = replaceBox.Text;

            if (string.IsNullOrEmpty(search)) return;

            var newText = text.Replace(search, replace, StringComparison.OrdinalIgnoreCase);
            editor.Text = newText;
            lastIndex = 0;
        }
    }
}