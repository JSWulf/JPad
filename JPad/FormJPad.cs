using System.Windows.Forms;

namespace JPad
{
    public partial class FormJPad : Form
    {
        public FormJPad()
        {
            InitializeComponent();
        }

        private void FormJPad_Load(object sender, EventArgs e)
        {

        }

        private void UpdateStatusBar(object sender, EventArgs e)
        {
            int index = TxBx_Main.SelectionStart;
            int line = TxBx_Main.GetLineFromCharIndex(index);
            int col = index - TxBx_Main.GetFirstCharIndexOfCurrentLine();
            Status_Coords.Text = $"Ln {line + 1}, Col {col + 1}";
        }

    }
}
