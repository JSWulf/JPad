using Avalonia.Controls;
using Avalonia.Interactivity;
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