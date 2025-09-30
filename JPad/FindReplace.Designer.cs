namespace JPad
{
    partial class FindReplace
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            TxBx_Find = new TextBox();
            TxBx_Replace = new TextBox();
            label1 = new Label();
            label2 = new Label();
            CkBx_Case = new CheckBox();
            Btn_Next = new Button();
            Btn_Replace = new Button();
            Btn_RepAll = new Button();
            Btn_Close = new Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel1.Controls.Add(TxBx_Find, 1, 0);
            tableLayoutPanel1.Controls.Add(TxBx_Replace, 1, 1);
            tableLayoutPanel1.Controls.Add(label1, 0, 0);
            tableLayoutPanel1.Controls.Add(label2, 0, 1);
            tableLayoutPanel1.Controls.Add(CkBx_Case, 0, 3);
            tableLayoutPanel1.Controls.Add(Btn_Next, 2, 0);
            tableLayoutPanel1.Controls.Add(Btn_Replace, 2, 1);
            tableLayoutPanel1.Controls.Add(Btn_RepAll, 2, 2);
            tableLayoutPanel1.Controls.Add(Btn_Close, 2, 3);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle());
            tableLayoutPanel1.Size = new Size(448, 117);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // TxBx_Find
            // 
            TxBx_Find.Dock = DockStyle.Top;
            TxBx_Find.Location = new Point(60, 3);
            TxBx_Find.Name = "TxBx_Find";
            TxBx_Find.Size = new Size(304, 23);
            TxBx_Find.TabIndex = 0;
            // 
            // TxBx_Replace
            // 
            TxBx_Replace.Dock = DockStyle.Top;
            TxBx_Replace.Location = new Point(60, 32);
            TxBx_Replace.Name = "TxBx_Replace";
            TxBx_Replace.Size = new Size(304, 23);
            TxBx_Replace.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(51, 29);
            label1.TabIndex = 2;
            label1.Text = "Find:";
            label1.TextAlign = ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Dock = DockStyle.Fill;
            label2.Location = new Point(3, 29);
            label2.Name = "label2";
            label2.Size = new Size(51, 29);
            label2.TabIndex = 3;
            label2.Text = "Replace:";
            label2.TextAlign = ContentAlignment.MiddleRight;
            // 
            // CkBx_Case
            // 
            CkBx_Case.AutoSize = true;
            tableLayoutPanel1.SetColumnSpan(CkBx_Case, 2);
            CkBx_Case.Location = new Point(3, 91);
            CkBx_Case.Name = "CkBx_Case";
            CkBx_Case.Padding = new Padding(7, 0, 0, 0);
            CkBx_Case.Size = new Size(107, 19);
            CkBx_Case.TabIndex = 4;
            CkBx_Case.Text = "Case Sensitive";
            CkBx_Case.UseVisualStyleBackColor = true;
            // 
            // Btn_Next
            // 
            Btn_Next.Location = new Point(370, 3);
            Btn_Next.Name = "Btn_Next";
            Btn_Next.Size = new Size(75, 23);
            Btn_Next.TabIndex = 5;
            Btn_Next.Text = "Find Next";
            Btn_Next.UseVisualStyleBackColor = true;
            // 
            // Btn_Replace
            // 
            Btn_Replace.Location = new Point(370, 32);
            Btn_Replace.Name = "Btn_Replace";
            Btn_Replace.Size = new Size(75, 23);
            Btn_Replace.TabIndex = 6;
            Btn_Replace.Text = "Replace";
            Btn_Replace.UseVisualStyleBackColor = true;
            // 
            // Btn_RepAll
            // 
            Btn_RepAll.Location = new Point(370, 61);
            Btn_RepAll.Name = "Btn_RepAll";
            Btn_RepAll.Size = new Size(75, 23);
            Btn_RepAll.TabIndex = 7;
            Btn_RepAll.Text = "Replace All";
            Btn_RepAll.UseVisualStyleBackColor = true;
            // 
            // Btn_Close
            // 
            Btn_Close.Location = new Point(370, 91);
            Btn_Close.Name = "Btn_Close";
            Btn_Close.Size = new Size(75, 23);
            Btn_Close.TabIndex = 8;
            Btn_Close.Text = "Close";
            Btn_Close.UseVisualStyleBackColor = true;
            Btn_Close.Click += Btn_Close_Click;
            // 
            // FindReplace
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            ClientSize = new Size(448, 117);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            MaximizeBox = false;
            MinimizeBox = false;
            MinimumSize = new Size(468, 160);
            Name = "FindReplace";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Replace";
            Load += FindReplace_Load;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Label label1;
        private Label label2;
        private Button Btn_Close;
        public TextBox TxBx_Find;
        public TextBox TxBx_Replace;
        public CheckBox CkBx_Case;
        public Button Btn_Next;
        public Button Btn_Replace;
        public Button Btn_RepAll;
    }
}