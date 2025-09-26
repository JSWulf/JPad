namespace JPad
{
    partial class FormJPad
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Menu_Main = new MenuStrip();
            Menu_File = new ToolStripMenuItem();
            Menu_New = new ToolStripMenuItem();
            Menu_Open = new ToolStripMenuItem();
            Menu_Save = new ToolStripMenuItem();
            Menu_SaveAs = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            Menu_PageSetup = new ToolStripMenuItem();
            Menu_Print = new ToolStripMenuItem();
            toolStripMenuItem2 = new ToolStripSeparator();
            Menu_Exit = new ToolStripMenuItem();
            Menu_Edit = new ToolStripMenuItem();
            Menu_Undo = new ToolStripMenuItem();
            toolStripMenuItem3 = new ToolStripSeparator();
            Menu_Cut = new ToolStripMenuItem();
            Menu_Copy = new ToolStripMenuItem();
            Menu_Paste = new ToolStripMenuItem();
            toolStripMenuItem4 = new ToolStripSeparator();
            Menu_Find = new ToolStripMenuItem();
            Menu_FindNext = new ToolStripMenuItem();
            Menu_Replace = new ToolStripMenuItem();
            Menu_Format = new ToolStripMenuItem();
            Menu_FWordWrap = new ToolStripMenuItem();
            Menu_Font = new ToolStripMenuItem();
            Menu_View = new ToolStripMenuItem();
            Menu_VWordWrap = new ToolStripMenuItem();
            Menu_Status = new ToolStripMenuItem();
            Menu_Help = new ToolStripMenuItem();
            Menu_GitHub = new ToolStripMenuItem();
            Menu_About = new ToolStripMenuItem();
            Status_Main = new StatusStrip();
            Status_Coords = new ToolStripStatusLabel();
            TxBx_Main = new TextBox();
            Menu_Dark = new ToolStripMenuItem();
            Menu_Main.SuspendLayout();
            Status_Main.SuspendLayout();
            SuspendLayout();
            // 
            // Menu_Main
            // 
            Menu_Main.Items.AddRange(new ToolStripItem[] { Menu_File, Menu_Edit, Menu_Format, Menu_View, Menu_Help });
            Menu_Main.Location = new Point(0, 0);
            Menu_Main.Name = "Menu_Main";
            Menu_Main.Size = new Size(800, 24);
            Menu_Main.TabIndex = 0;
            Menu_Main.Text = "menuStrip1";
            // 
            // Menu_File
            // 
            Menu_File.DropDownItems.AddRange(new ToolStripItem[] { Menu_New, Menu_Open, Menu_Save, Menu_SaveAs, toolStripMenuItem1, Menu_PageSetup, Menu_Print, toolStripMenuItem2, Menu_Exit });
            Menu_File.Name = "Menu_File";
            Menu_File.Size = new Size(37, 20);
            Menu_File.Text = "File";
            // 
            // Menu_New
            // 
            Menu_New.Name = "Menu_New";
            Menu_New.ShortcutKeys = Keys.Control | Keys.N;
            Menu_New.Size = new Size(155, 22);
            Menu_New.Text = "New";
            // 
            // Menu_Open
            // 
            Menu_Open.Name = "Menu_Open";
            Menu_Open.ShortcutKeys = Keys.Control | Keys.O;
            Menu_Open.Size = new Size(155, 22);
            Menu_Open.Text = "Open...";
            // 
            // Menu_Save
            // 
            Menu_Save.Name = "Menu_Save";
            Menu_Save.ShortcutKeys = Keys.Control | Keys.S;
            Menu_Save.Size = new Size(155, 22);
            Menu_Save.Text = "Save";
            // 
            // Menu_SaveAs
            // 
            Menu_SaveAs.Name = "Menu_SaveAs";
            Menu_SaveAs.Size = new Size(155, 22);
            Menu_SaveAs.Text = "Save As...";
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(152, 6);
            // 
            // Menu_PageSetup
            // 
            Menu_PageSetup.Name = "Menu_PageSetup";
            Menu_PageSetup.Size = new Size(155, 22);
            Menu_PageSetup.Text = "Page Setup";
            // 
            // Menu_Print
            // 
            Menu_Print.Name = "Menu_Print";
            Menu_Print.ShortcutKeys = Keys.Control | Keys.P;
            Menu_Print.Size = new Size(155, 22);
            Menu_Print.Text = "Print";
            // 
            // toolStripMenuItem2
            // 
            toolStripMenuItem2.Name = "toolStripMenuItem2";
            toolStripMenuItem2.Size = new Size(152, 6);
            // 
            // Menu_Exit
            // 
            Menu_Exit.Name = "Menu_Exit";
            Menu_Exit.Size = new Size(155, 22);
            Menu_Exit.Text = "Exit";
            // 
            // Menu_Edit
            // 
            Menu_Edit.DropDownItems.AddRange(new ToolStripItem[] { Menu_Undo, toolStripMenuItem3, Menu_Cut, Menu_Copy, Menu_Paste, toolStripMenuItem4, Menu_Find, Menu_FindNext, Menu_Replace });
            Menu_Edit.Name = "Menu_Edit";
            Menu_Edit.Size = new Size(39, 20);
            Menu_Edit.Text = "Edit";
            // 
            // Menu_Undo
            // 
            Menu_Undo.Name = "Menu_Undo";
            Menu_Undo.ShortcutKeys = Keys.Control | Keys.Z;
            Menu_Undo.Size = new Size(167, 22);
            Menu_Undo.Text = "Undo";
            // 
            // toolStripMenuItem3
            // 
            toolStripMenuItem3.Name = "toolStripMenuItem3";
            toolStripMenuItem3.Size = new Size(164, 6);
            // 
            // Menu_Cut
            // 
            Menu_Cut.Name = "Menu_Cut";
            Menu_Cut.ShortcutKeys = Keys.Control | Keys.X;
            Menu_Cut.Size = new Size(167, 22);
            Menu_Cut.Text = "Cut";
            // 
            // Menu_Copy
            // 
            Menu_Copy.Name = "Menu_Copy";
            Menu_Copy.ShortcutKeys = Keys.Control | Keys.C;
            Menu_Copy.Size = new Size(167, 22);
            Menu_Copy.Text = "Copy";
            // 
            // Menu_Paste
            // 
            Menu_Paste.Name = "Menu_Paste";
            Menu_Paste.ShortcutKeys = Keys.Control | Keys.V;
            Menu_Paste.Size = new Size(167, 22);
            Menu_Paste.Text = "Paste";
            // 
            // toolStripMenuItem4
            // 
            toolStripMenuItem4.Name = "toolStripMenuItem4";
            toolStripMenuItem4.Size = new Size(164, 6);
            // 
            // Menu_Find
            // 
            Menu_Find.Name = "Menu_Find";
            Menu_Find.ShortcutKeys = Keys.Control | Keys.F;
            Menu_Find.Size = new Size(167, 22);
            Menu_Find.Text = "Find...";
            // 
            // Menu_FindNext
            // 
            Menu_FindNext.Name = "Menu_FindNext";
            Menu_FindNext.ShortcutKeys = Keys.F3;
            Menu_FindNext.Size = new Size(167, 22);
            Menu_FindNext.Text = "Find Next";
            // 
            // Menu_Replace
            // 
            Menu_Replace.Name = "Menu_Replace";
            Menu_Replace.ShortcutKeys = Keys.Control | Keys.H;
            Menu_Replace.Size = new Size(167, 22);
            Menu_Replace.Text = "Replace...";
            // 
            // Menu_Format
            // 
            Menu_Format.DropDownItems.AddRange(new ToolStripItem[] { Menu_FWordWrap, Menu_Font });
            Menu_Format.Name = "Menu_Format";
            Menu_Format.Size = new Size(57, 20);
            Menu_Format.Text = "Format";
            // 
            // Menu_FWordWrap
            // 
            Menu_FWordWrap.Name = "Menu_FWordWrap";
            Menu_FWordWrap.Size = new Size(180, 22);
            Menu_FWordWrap.Text = "Word Wrap";
            // 
            // Menu_Font
            // 
            Menu_Font.Name = "Menu_Font";
            Menu_Font.Size = new Size(180, 22);
            Menu_Font.Text = "Font...";
            // 
            // Menu_View
            // 
            Menu_View.DropDownItems.AddRange(new ToolStripItem[] { Menu_VWordWrap, Menu_Status, Menu_Dark });
            Menu_View.Name = "Menu_View";
            Menu_View.Size = new Size(44, 20);
            Menu_View.Text = "View";
            // 
            // Menu_VWordWrap
            // 
            Menu_VWordWrap.Name = "Menu_VWordWrap";
            Menu_VWordWrap.Size = new Size(180, 22);
            Menu_VWordWrap.Text = "Word Wrap";
            // 
            // Menu_Status
            // 
            Menu_Status.Name = "Menu_Status";
            Menu_Status.Size = new Size(180, 22);
            Menu_Status.Text = "Status Bar";
            // 
            // Menu_Help
            // 
            Menu_Help.DropDownItems.AddRange(new ToolStripItem[] { Menu_GitHub, Menu_About });
            Menu_Help.Name = "Menu_Help";
            Menu_Help.Size = new Size(44, 20);
            Menu_Help.Text = "Help";
            // 
            // Menu_GitHub
            // 
            Menu_GitHub.Name = "Menu_GitHub";
            Menu_GitHub.Size = new Size(180, 22);
            Menu_GitHub.Text = "Visit Page";
            // 
            // Menu_About
            // 
            Menu_About.Name = "Menu_About";
            Menu_About.Size = new Size(180, 22);
            Menu_About.Text = "About JPad";
            // 
            // Status_Main
            // 
            Status_Main.Items.AddRange(new ToolStripItem[] { Status_Coords });
            Status_Main.Location = new Point(0, 428);
            Status_Main.Name = "Status_Main";
            Status_Main.Size = new Size(800, 22);
            Status_Main.TabIndex = 1;
            Status_Main.Text = "Status_Main";
            // 
            // Status_Coords
            // 
            Status_Coords.Name = "Status_Coords";
            Status_Coords.Size = new Size(62, 17);
            Status_Coords.Text = "Ln 1, Col 1";
            // 
            // TxBx_Main
            // 
            TxBx_Main.Dock = DockStyle.Fill;
            TxBx_Main.Font = new Font("Lucida Console", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            TxBx_Main.Location = new Point(0, 24);
            TxBx_Main.Multiline = true;
            TxBx_Main.Name = "TxBx_Main";
            TxBx_Main.ScrollBars = ScrollBars.Both;
            TxBx_Main.Size = new Size(800, 404);
            TxBx_Main.TabIndex = 2;
            TxBx_Main.WordWrap = false;
            // 
            // Menu_Dark
            // 
            Menu_Dark.Name = "Menu_Dark";
            Menu_Dark.Size = new Size(180, 22);
            Menu_Dark.Text = "Dark Mode";
            // 
            // FormJPad
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(TxBx_Main);
            Controls.Add(Status_Main);
            Controls.Add(Menu_Main);
            MainMenuStrip = Menu_Main;
            Name = "FormJPad";
            Text = "JPad";
            Load += FormJPad_Load;
            Menu_Main.ResumeLayout(false);
            Menu_Main.PerformLayout();
            Status_Main.ResumeLayout(false);
            Status_Main.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip Menu_Main;
        private ToolStripMenuItem Menu_File;
        private ToolStripMenuItem Menu_Edit;
        private ToolStripMenuItem Menu_Format;
        private ToolStripMenuItem Menu_View;
        private ToolStripMenuItem Menu_Help;
        private StatusStrip Status_Main;
        private TextBox TxBx_Main;
        private ToolStripMenuItem Menu_New;
        private ToolStripMenuItem Menu_Open;
        private ToolStripMenuItem Menu_Save;
        private ToolStripMenuItem Menu_SaveAs;
        private ToolStripSeparator toolStripMenuItem2;
        private ToolStripMenuItem Menu_Exit;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem Menu_PageSetup;
        private ToolStripMenuItem Menu_Print;
        private ToolStripMenuItem Menu_Undo;
        private ToolStripSeparator toolStripMenuItem3;
        private ToolStripMenuItem Menu_Cut;
        private ToolStripMenuItem Menu_Copy;
        private ToolStripMenuItem Menu_Paste;
        private ToolStripSeparator toolStripMenuItem4;
        private ToolStripMenuItem Menu_Find;
        private ToolStripMenuItem Menu_FindNext;
        private ToolStripMenuItem Menu_Replace;
        private ToolStripMenuItem Menu_FWordWrap;
        private ToolStripMenuItem Menu_Font;
        private ToolStripMenuItem Menu_VWordWrap;
        private ToolStripMenuItem Menu_Status;
        private ToolStripMenuItem Menu_GitHub;
        private ToolStripMenuItem Menu_About;
        private ToolStripStatusLabel Status_Coords;
        private ToolStripMenuItem Menu_Dark;
    }
}
