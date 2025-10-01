/*======================================================================================================================================================*\
|               .%#@+                                                                       *#%.                     ..    ..                     -*--@: |
|              -##+@.                                      +##.                             @##                    -###*  *#@                   -+:   *+ |
|             -###*                                      .##%*             +##%##+   -##*   =#=                   %#++%  :##%               -%=::.   .=+=|
|            :##:                                       :#@%+          -%#*   %##.  -##%   -##.                 .##.=%  .###.             .@%+@ -+. .. -+|
|       . -=###-                                       :###*         +##.    @##.  *##@.   @#-                 :#% #=   @##.             *@#=####:  ..=* |
|      %#=--##:                        **          :*--###-         .*:     %##. .@###.   %#.                 *#+*#:   +#%            +#@=+=%%@#%:*- *+  |
|         -##*           -@####=    -####*      :###%@##%                  %##. +#%##*   @#.  .%#+   .@#+.   -#@##.  .##%           =@+##@=:=#.  -@+.@.  |
|        +##*         .%###=  ##*.%#=.-##*   . @#=  *###.  :#.            @##.:##-*##. .#%  =####=  @###@. ..###+  .@##@  :@@.        %#@*.*=%#+--=+:@   |
|       =##@%%%%%+:-. --##-   @#-..  *#%  .%#:@#: -#*:#@ +#=             *##@##*  .##%##-    -##:.##.:##.:#%:#=   %#+##-@#*          =% +%++.+@:%@ :.@-  |
|  -+%@###:      .+###*.##  +#@.     @#=##@- -#@*#=   :@@:               %###-      .-       -####-  +###*  .#@*##::###+          .:##=:=%=#@.:@..%+=#+. |
|.%@=@##+            -.  *@=-         :+-     .+:                         ..                   ..     ..      ..   @#+#%          .*###+*%#:.##%*-=@*%:  |
|                   /\                                                                                            %#% :#*      .--=###-  ..#:.#+-%#-%#:  |
|                    \\ _____________________________________________________________________                    +#@ -#%    +#%. :..  *@@.  +=:*##:+@=-  |
|      (O)[\\\\\\\\\\(O)#####################################################################>                  -##..#+    . :@=-     .  :=-.+=+%**%#@   |
|                    //                                                                                         @#:+#.      .  .      ..-*+:.. -.*@.-..  |
|                   \/                                                                                         *##@-                ..      ..::.###:    |
\*======================================================================================================================================================*/
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Drawing.Printing;
using System.Reflection;

namespace JPad
{
    public partial class FormJPad : Form
    {
        public FormJPad(string[] args)
        {

            var assembly = Assembly.GetExecutingAssembly();
            using var stream = assembly.GetManifestResourceStream("JPad.JPad.ico");
            this.Icon = new Icon(stream);


            Setting = new Settings();
            Setting.Reload();

            InitializeComponent();

            txtFont = TxBx_Main.Font;

            DarkMode = Setting.DarkMode;
            WordWrap = Setting.WordWrap;
            TxtFont = Setting.Font;

            if (args.Length > 0 && File.Exists(args[0]))
            {
                Open(args[0]);
            }

            //TxBx_Main.SelectionChanged += UpdateStatusBar; //missing SelectionChanged event.
            TxBx_Main.KeyUp += UpdateStatusBar;
            TxBx_Main.MouseUp += UpdateStatusBar;

            FindRDialog.Btn_Next.Click += Menu_FindNext_Click;
            FindRDialog.Btn_Replace.Click += Menu_FindNext_Click;
            FindRDialog.Btn_RepAll.Click += Menu_FindNext_Click;
        }

        private void FormJPad_Load(object sender, EventArgs e)
        {
            Menu_Status.Checked = Status_Main.Visible;
        }

        #region properties

        private bool darkMode = false;

        public bool DarkMode
        {
            get { return darkMode; }
            set { 
                darkMode = value;
                //bool dark = this.BackColor != Color.FromArgb(30, 30, 30); // toggle based on current color

                this.BackColor = value ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
                TxBx_Main.BackColor = value ? Color.FromArgb(45, 45, 45) : SystemColors.Window;
                TxBx_Main.ForeColor = value ? Color.Gainsboro : SystemColors.WindowText;
                Menu_Main.BackColor = value ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
                Menu_Main.ForeColor = value ? Color.Gainsboro : SystemColors.ControlText;
                Status_Main.BackColor = value ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
                Status_Main.ForeColor = value ? Color.Gainsboro : SystemColors.ControlText;


                Menu_Main.BackColor = value ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
                Menu_Main.ForeColor = value ? Color.Gainsboro : SystemColors.ControlText;


                foreach (ToolStripMenuItem item in Menu_Main.Items)
                {
                    item.BackColor = Menu_Main.BackColor;
                    item.ForeColor = Menu_Main.ForeColor;
                    foreach (ToolStripItem subItem in item.DropDownItems)
                    {
                        subItem.BackColor = Menu_Main.BackColor;
                        subItem.ForeColor = Menu_Main.ForeColor;
                    }
                }


                Menu_Dark.Checked = value;

                Setting.DarkMode = value;
            }
        }

        private bool wordWrap = false;

        public bool WordWrap
        {
            get { return wordWrap; }
            set { 
                wordWrap = value;
                TxBx_Main.WordWrap = value;
                Menu_FWordWrap.Checked = value;
                Menu_VWordWrap.Checked = value;

                TxBx_Main.ScrollBars = value ? ScrollBars.Vertical : ScrollBars.Both;
            }
        }

        private Font txtFont;

        public Font TxtFont
        {
            get { return txtFont; }
            set { 
                txtFont = value;
                TxBx_Main.Font = value;
            }
        }



        public string LoadedHash { get; private set; } = null;

        private string fileName = null;

        public string FileName
        {
            get { return fileName; }
            set
            {
                fileName = value;
                this.Text = $"JPad - {Path.GetFileName(value)}";
            }
        }

        private bool saved = false;

        public bool Saved
        {
            get { return saved; }
            set
            {
                saved = value;
                if (!value && !this.Text.StartsWith('*'))
                {
                    this.Text = '*' + this.Text;
                }
                else if (this.Text.StartsWith('*'))
                {
                    this.Text = this.Text.Remove(0, 1);
                }
            }
        }

        public FindReplace FindRDialog { get; set; } = new FindReplace();
        public Settings Setting { get; set; }
        private PrintDocument printDocument { get; set; } = new PrintDocument();
        private PageSetupDialog pageSetupDialog { get; set; } = new PageSetupDialog();
        private PrintDialog printDialog { get; set; } = new PrintDialog();
        private FontDialog fontDialog { get; set; } = new FontDialog();

        #endregion
        #region methods

        private void Open(string filenm)
        {
            if (filenm == null)
            {
                throw new Exception("Null File Name");
            }

            FileName = filenm;

            var content = File.ReadAllText(FileName);
            LoadedHash = GetHash(content);
            TxBx_Main.Text = content;
            Saved = true;

        }

        private void Save(string filenm = null)
        {
            if (filenm == null && FileName == null)
            {
                throw new Exception("No filename was set");
            }

            var f = filenm == null ? FileName : filenm;

            File.WriteAllText(f, TxBx_Main.Text);
            Saved = true;
        }

        private string GetHash(string input)
        {
            using var md5 = System.Security.Cryptography.MD5.Create();
            var bytes = System.Text.Encoding.UTF8.GetBytes(input);
            var hash = md5.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private void UpdateStatusBar(object sender, EventArgs e)
        {
            int index = TxBx_Main.SelectionStart;
            int line = TxBx_Main.GetLineFromCharIndex(index);
            int col = index - TxBx_Main.GetFirstCharIndexOfCurrentLine();
            Status_Coords.Text = $"Ln {line + 1}, Col {col + 1}";
        }

        private string ReplaceIgnoreCase(string input, string search, string replace)
        {
            return System.Text.RegularExpressions.Regex.Replace(
                input,
                System.Text.RegularExpressions.Regex.Escape(search),
                replace,
                System.Text.RegularExpressions.RegexOptions.IgnoreCase
            );
        }

        private string Unescape(string input)
        {
            return input
                .Replace("\\t", "\t")
                .Replace("\\r", "\r")
                .Replace("\\n", "\n");
        }

        #endregion
        #region events

        private void Menu_New_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start(Application.ExecutablePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to launch new instance:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Menu_Open_Click(object sender, EventArgs e)
        {

            using var dlg = new OpenFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Open(dlg.FileName);
            }

        }

        private void Menu_Save_Click(object sender, EventArgs e)
        {
            if (FileName == null)
            {
                Menu_SaveAs_Click(sender, e);
            }
            else
            {
                Save();
            }
        }

        private void Menu_SaveAs_Click(object sender, EventArgs e)
        {

            using var dlg = new SaveFileDialog();
            dlg.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                Save(dlg.FileName);
                FileName = dlg.FileName;
            }

        }

        private void Menu_PageSetup_Click(object sender, EventArgs e)
        {

            pageSetupDialog.Document = printDocument;
            pageSetupDialog.ShowDialog();

        }

        private void Menu_Print_Click(object sender, EventArgs e)
        {
            currentCharIndex = 0;
            printDocument.PrintPage += PrintDocument_PrintPage;
            printDialog.Document = printDocument;
            if (printDialog.ShowDialog() == DialogResult.OK)
            {
                printDocument.Print();
            }

        }

        private int currentCharIndex = 0;

        private void PrintDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            string text = TxBx_Main.Text;
            Font printFont = TxBx_Main.Font;
            float leftMargin = e.MarginBounds.Left;
            float topMargin = e.MarginBounds.Top;
            float height = e.MarginBounds.Height;

            int charsFitted, linesFilled;

            // Measure how many characters fit on the page
            e.Graphics.MeasureString(
                text.Substring(currentCharIndex),
                printFont,
                new SizeF(e.MarginBounds.Width, height),
                StringFormat.GenericTypographic,
                out charsFitted,
                out linesFilled
            );

            // Draw the portion of text that fits
            e.Graphics.DrawString(
                text.Substring(currentCharIndex, charsFitted),
                printFont,
                Brushes.Black,
                new RectangleF(leftMargin, topMargin, e.MarginBounds.Width, height),
                StringFormat.GenericTypographic
            );

            // Update index and check if more pages are needed
            currentCharIndex += charsFitted;
            e.HasMorePages = currentCharIndex < text.Length;

            // Reset index if printing is done
            if (!e.HasMorePages)
            {
                currentCharIndex = 0;
            }
        }

        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Undo_Click(object sender, EventArgs e)
        {

            if (TxBx_Main.CanUndo)
            {
                TxBx_Main.Undo();
            }
        }

        private void Menu_Cut_Click(object sender, EventArgs e)
        {

            if (TxBx_Main.SelectionLength > 0)
            {
                TxBx_Main.Cut();
            }

        }

        private void Menu_Copy_Click(object sender, EventArgs e)
        {

            if (TxBx_Main.SelectionLength > 0)
            {
                TxBx_Main.Copy();
            }

        }

        private void Menu_Paste_Click(object sender, EventArgs e)
        {

            if (Clipboard.ContainsText())
            {
                TxBx_Main.Paste();
            }

        }

        private void Menu_Find_Click(object sender, EventArgs e)
        {
            FindRDialog.FindOnly = true;
            FindRDialog.Text = "Find...";
            FindRDialog.Show();
        }

        private void Menu_FindNext_Click(object sender, EventArgs e)
        {
            string search = Unescape(FindRDialog.TxBx_Find.Text);
            string replace = Unescape(FindRDialog.TxBx_Replace.Text);
            bool matchCase = FindRDialog.CkBx_Case.Checked;

            StringComparison comparison = matchCase ? StringComparison.Ordinal : StringComparison.OrdinalIgnoreCase;
            int start = TxBx_Main.SelectionStart + TxBx_Main.SelectionLength;

            if (sender == FindRDialog.Btn_Next || sender == Menu_FindNext)
            {
                int index = TxBx_Main.Text.IndexOf(search, start, comparison);
                if (index >= 0)
                {
                    TxBx_Main.Select(index, search.Length);
                    TxBx_Main.ScrollToCaret();
                    TxBx_Main.Focus();
                }
                else
                {
                    MessageBox.Show("Text not found.", "Find", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else if (sender == FindRDialog.Btn_Replace)
            {
                if (TxBx_Main.SelectedText.Equals(search, comparison))
                {
                    TxBx_Main.SelectedText = replace;
                }
                Menu_FindNext_Click(FindRDialog.Btn_Next, EventArgs.Empty); // move to next
            }
            else if (sender == FindRDialog.Btn_RepAll)
            {
                string content = TxBx_Main.Text;
                string updated = matchCase
                    ? content.Replace(search, replace)
                    : ReplaceIgnoreCase(content, search, replace);

                TxBx_Main.Text = updated;
            }
        }

        private void Menu_Replace_Click(object sender, EventArgs e)
        {
            FindRDialog.FindOnly = false;
            FindRDialog.Text = "Replace...";
            FindRDialog.Show();
        }

        private void Menu_WordWrap_Click(object sender, EventArgs e)
        {
            WordWrap = !WordWrap;

            Setting.WordWrap = WordWrap;
            Setting.Save();
        }

        private void Menu_Font_Click(object sender, EventArgs e)
        {
            fontDialog.Font = TxtFont;
            if (fontDialog.ShowDialog() == DialogResult.OK)
            {
                TxtFont = fontDialog.Font;

                Setting.Font = TxtFont;
                Setting.Save();
            }
        }

        private void Menu_Status_Click(object sender, EventArgs e)
        {
            Status_Main.Visible = !Status_Main.Visible;
            Menu_Status.Checked = Status_Main.Visible;
        }

        private void Menu_Dark_Click(object sender, EventArgs e)
        {
            DarkMode = !DarkMode;
            Setting.Save();
        }

        private void Menu_GitHub_Click(object sender, EventArgs e)
        {

            try
            {
                System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
                {
                    FileName = "https://github.com/JSWulf/JPad",
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to open GitHub page:\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Menu_About_Click(object sender, EventArgs e)
        {
            using var about = new AboutJPad();
            about.ShowDialog(this);
        }

        private void TxBx_Main_TextChanged(object sender, EventArgs e)
        {
            Saved = false;
        }

        private void FormJPad_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!Saved && !(fileName == null && string.IsNullOrEmpty(TxBx_Main.Text)))
            {

                if (FileName != null && LoadedHash == GetHash(TxBx_Main.Text))
                {
                    return; // no changes, skip prompt
                }


                var result = MessageBox.Show(
                    "You have unsaved changes. Do you want to save before exiting?",
                    "Unsaved Changes",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Warning);

                if (result == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
                else if (result == DialogResult.Yes)
                {
                    try
                    {
                        Save();
                    }
                    catch
                    {
                        Menu_SaveAs_Click(sender, e);
                    }
                }
            }
        }

        #endregion
    }
}
