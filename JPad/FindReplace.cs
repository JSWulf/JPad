using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JPad
{
    public partial class FindReplace : Form
    {
        public FindReplace()
        {

            InitializeComponent();

        }

        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FindOrReplace(bool f)
        {
            Btn_Replace.Visible = !f;
            TxBx_Replace.Visible = !f;
            label2.Visible = !f;
            Btn_RepAll.Visible = !f;
        }

        public bool FindOnly { set
            {
                FindOrReplace(value);
            }
        }

        private void FindReplace_Load(object sender, EventArgs e)
        {

        }
    }
}
