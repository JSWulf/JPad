using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace JPad
{
    public partial class FormJPad : Form
    {
        public FormJPad(string[] args)
        {
            InitializeComponent();


            if (args.Length > 0 && File.Exists(args[0]))
            {
                Open(args[0]);
            }


            //TxBx_Main.SelectionChanged += UpdateStatusBar; //missing SelectionChanged event.
            TxBx_Main.KeyUp += UpdateStatusBar;
            TxBx_Main.MouseUp += UpdateStatusBar;


        }

        private void FormJPad_Load(object sender, EventArgs e)
        {

        }

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

        private void Open(string filenm)
        {
            if (filenm == null)
            {
                throw new Exception("Null File Name");
            }

            Saved = true;
            FileName = filenm;
            TxBx_Main.Text = File.ReadAllText(FileName);

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

        }

        private void Menu_Print_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Menu_Undo_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Cut_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Copy_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Paste_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Find_Click(object sender, EventArgs e)
        {

        }

        private void Menu_FindNext_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Replace_Click(object sender, EventArgs e)
        {

        }

        private void Menu_WordWrap_Click(object sender, EventArgs e)
        {
            TxBx_Main.WordWrap = !TxBx_Main.WordWrap;

            Menu_FWordWrap.Checked = TxBx_Main.WordWrap;
            Menu_VWordWrap.Checked = TxBx_Main.WordWrap;

            TxBx_Main.ScrollBars = TxBx_Main.WordWrap ? ScrollBars.Vertical : ScrollBars.Both;
        }

        private void Menu_Font_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Status_Click(object sender, EventArgs e)
        {
            Status_Main.Visible = !Status_Main.Visible;
            Menu_Status.Checked = Status_Main.Visible;
        }

        private void Menu_Dark_Click(object sender, EventArgs e)
        {
            bool dark = this.BackColor != Color.FromArgb(30, 30, 30); // toggle based on current color

            this.BackColor = dark ? Color.FromArgb(30, 30, 30) : SystemColors.Control;
            TxBx_Main.BackColor = dark ? Color.FromArgb(45, 45, 45) : SystemColors.Window;
            TxBx_Main.ForeColor = dark ? Color.Gainsboro : SystemColors.WindowText;
            Menu_Main.BackColor = dark ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
            Menu_Main.ForeColor = dark ? Color.Gainsboro : SystemColors.ControlText;
            Status_Main.BackColor = dark ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
            Status_Main.ForeColor = dark ? Color.Gainsboro : SystemColors.ControlText;


            Menu_Main.BackColor = dark ? Color.FromArgb(45, 45, 45) : SystemColors.Control;
            Menu_Main.ForeColor = dark ? Color.Gainsboro : SystemColors.ControlText;


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


            Menu_Dark.Checked = dark;
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
    }
}
