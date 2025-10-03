using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using AvaloniaEdit;
using AvaloniaEdit.Document;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;

namespace JPadAvl
{
    public partial class MainWindow : Window
    {
        private Settings settings;
        private string currentFilePath;

        public MainWindow()
        {
            InitializeComponent();

            textEditor.Document = new AvaloniaEdit.Document.TextDocument("Hello Avalonia!");

            textEditor.Background = Avalonia.Media.Brushes.White;
            textEditor.Foreground = Avalonia.Media.Brushes.Black;


            var configPath = Path.Combine(AppContext.BaseDirectory, "JPad.conf");
            if (File.Exists(configPath))
            {
                var json = File.ReadAllText(configPath);
                settings = JsonSerializer.Deserialize<Settings>(json);
            }
            else
            {
                settings = new Settings();
            }

            ApplySettings();
        }

        #region Properties

        private bool darkMode = false;
        public bool DarkMode
        {
            get => darkMode;
            set
            {
                darkMode = value;

                var bgColor = value ? Color.FromRgb(30, 30, 30) : Colors.White;
                var editorBg = value ? Color.FromRgb(45, 45, 45) : Colors.White;
                var editorFg = value ? Colors.Gainsboro : Colors.Black;

                Background = new SolidColorBrush(bgColor);
                textEditor.Background = new SolidColorBrush(editorBg);
                textEditor.Foreground = new SolidColorBrush(editorFg);

                Setting.DarkMode = value;
            }
        }

        private bool wordWrap = false;
        public bool WordWrap
        {
            get => wordWrap;
            set
            {
                wordWrap = value;
                textEditor.WordWrap = value;

                //wordWrapMenuItem.IsChecked = value;
                //verticalWrapMenuItem.IsChecked = value;
            }
        }

        private FontFamily txtFont;
        public FontFamily TxtFont
        {
            get => txtFont;
            set
            {
                txtFont = value;
                textEditor.FontFamily = value;
            }
        }

        private float fontSize;

        public float TxtFontSize
        {
            get { return fontSize; }
            set { fontSize = value; }
        }

        public string TxtFontSizeStr
        {
            get { return fontSize.ToString(); }
            set { fontSize = float.Parse(value); }
        }

        private FontStyle fontStyle;

        public FontStyle TxtFontStyle
        {
            get { return fontStyle; }
            set { fontStyle = value; }
        }

        public string TxtFontStyleStr
        {
            get { return fontStyle.ToString(); }
            //set { fontStyle = Convert<FontStyle>(value); }
        }

        private FontWeight fontWeight;

        public FontWeight TxtFontWeight
        {
            get { return fontWeight; }
            set { fontWeight = value; }
        }

        public string TxtFontWeightStr
        {
            get { return fontWeight.ToString(); }
            //set { fontWeight = value; }
        }


        public string LoadedHash { get; private set; } = null;

        private string fileName = null;
        public string FileName
        {
            get => fileName;
            set
            {
                fileName = value;
                Title = $"JPad - {Path.GetFileName(value)}";
            }
        }

        private bool saved = false;
        public bool Saved
        {
            get => saved;
            set
            {
                saved = value;
                if (!value && !Title.StartsWith("*"))
                {
                    Title = "*" + Title;
                }
                else if (Title.StartsWith("*"))
                {
                    Title = Title.Substring(1);
                }
            }
        }

        //public bool ShowStatusBar
        //{
        //    get => StatusBar_Main.IsVisible;
        //    set
        //    {
        //        StatusBar_Main.IsVisible = value;
        //        Menu_Status.IsChecked = value;
        //    }
        //}

        public FindReplaceWindow FindRDialog { get; set; }
        public Settings Setting { get; set; }

        #endregion

        private void ApplySettings()
        {
            textEditor.FontFamily = settings.Font;
            textEditor.FontSize = settings.FontSize;
            textEditor.FontWeight = settings.Fontweight;
            textEditor.FontStyle = settings.FontStyle;
            textEditor.WordWrap = settings.WordWrap;
        }

        private void OpenFile_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });
            dialog.AllowMultiple = false;

            dialog.ShowAsync(this).ContinueWith(t =>
            {
                var result = t.Result;
                if (result != null && result.Length > 0)
                {
                    currentFilePath = result[0];
                    var text = File.ReadAllText(currentFilePath);
                    textEditor.Text = text;
                }
            });
        }

        private void SaveFile_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(currentFilePath))
            {
                var dialog = new SaveFileDialog();
                dialog.Filters.Add(new FileDialogFilter() { Name = "Text Files", Extensions = { "txt" } });

                dialog.ShowAsync(this).ContinueWith(t =>
                {
                    var result = t.Result;
                    if (!string.IsNullOrEmpty(result))
                    {
                        currentFilePath = result;
                        File.WriteAllText(currentFilePath, textEditor.Text);
                    }
                });
            }
            else
            {
                File.WriteAllText(currentFilePath, textEditor.Text);
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ToggleWordWrap_Click(object sender, RoutedEventArgs e)
        {
            settings.WordWrap = !settings.WordWrap;
            textEditor.WordWrap = settings.WordWrap;
            SaveSettings();
        }

        private void ChangeFont_Click(object sender, RoutedEventArgs e)
        {
            // You can implement a font picker dialog here
        }

        private void FindReplace_Click(object sender, RoutedEventArgs e)
        {
            //var findWindow = new FindReplaceWindow(textEditor);
            //findWindow.Show();
        }

        private void SaveSettings()
        {
            var configPath = Path.Combine(AppContext.BaseDirectory, "JPad.conf");
            var json = JsonSerializer.Serialize(settings, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(configPath, json);
        }

        private async void Copy_Click(object sender, RoutedEventArgs e)
        {
            var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
            if (clipboard != null)
                await clipboard.SetTextAsync(textEditor.SelectedText);
        }

        private async void Paste_Click(object sender, RoutedEventArgs e)
        {
            var clipboard = TopLevel.GetTopLevel(this)?.Clipboard;
            if (clipboard != null)
            {
                var text = await clipboard.GetTextAsync();
                if (!string.IsNullOrEmpty(text))
                    textEditor.Document.Insert(textEditor.CaretOffset, text);
            }
        }

        private void Cut_Click(object sender, RoutedEventArgs e)
        {
            Copy_Click(sender, e);
            textEditor.Document.Remove(textEditor.SelectionStart, textEditor.SelectionLength);
        }

        private void Undo_Click(object sender, RoutedEventArgs e)
        {
            if (textEditor.CanUndo)
                textEditor.Undo();
        }

        private void Redo_Click(object sender, RoutedEventArgs e)
        {
            if (textEditor.CanRedo)
                textEditor.Redo();
        }

        private void VisitGitHub_Click(object sender, RoutedEventArgs e)
        {
            var url = "https://github.com/JSWulf/JPad";
            Process.Start(new ProcessStartInfo(url) { UseShellExecute = true });
        }

        private void About_Click(object sender, RoutedEventArgs e)
        {
            //var aboutWindow = new AboutWindow();
            //aboutWindow.ShowDialog(this);
        }
    }
}