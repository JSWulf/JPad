using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Media;
using AvaloniaEdit;
using System;
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
    }
}