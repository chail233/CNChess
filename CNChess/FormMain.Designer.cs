namespace CNChess
{
    partial class FormMain
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
            menuStrip1 = new MenuStrip();
            MenuItemGame = new ToolStripMenuItem();
            MenuItemBegin = new ToolStripMenuItem();
            MenuItemUndo = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            MenuItemSave = new ToolStripMenuItem();
            MenuItemOpen = new ToolStripMenuItem();
            saveFileDialog1 = new SaveFileDialog();
            openFileDialog1 = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { MenuItemGame });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1011, 32);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // MenuItemGame
            // 
            MenuItemGame.DropDownItems.AddRange(new ToolStripItem[] { MenuItemBegin, MenuItemUndo, toolStripMenuItem1, MenuItemSave, MenuItemOpen });
            MenuItemGame.Name = "MenuItemGame";
            MenuItemGame.Size = new Size(62, 28);
            MenuItemGame.Text = "游戏";
            // 
            // MenuItemBegin
            // 
            MenuItemBegin.Name = "MenuItemBegin";
            MenuItemBegin.ShortcutKeys = Keys.Control | Keys.B;
            MenuItemBegin.Size = new Size(251, 34);
            MenuItemBegin.Text = "开局";
            MenuItemBegin.Click += MenuItemBegin_Click;
            // 
            // MenuItemUndo
            // 
            MenuItemUndo.Name = "MenuItemUndo";
            MenuItemUndo.ShortcutKeys = Keys.Control | Keys.Z;
            MenuItemUndo.Size = new Size(251, 34);
            MenuItemUndo.Text = "悔棋";
            MenuItemUndo.Click += MenuItemUndo_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(248, 6);
            // 
            // MenuItemSave
            // 
            MenuItemSave.Name = "MenuItemSave";
            MenuItemSave.ShortcutKeys = Keys.Control | Keys.S;
            MenuItemSave.Size = new Size(251, 34);
            MenuItemSave.Text = "保存残局";
            MenuItemSave.Click += MenuItemSave_Click;
            // 
            // MenuItemOpen
            // 
            MenuItemOpen.Name = "MenuItemOpen";
            MenuItemOpen.ShortcutKeys = Keys.Control | Keys.O;
            MenuItemOpen.Size = new Size(251, 34);
            MenuItemOpen.Text = "打开残局";
            MenuItemOpen.Click += MenuItemOpen_Click;
            // 
            // saveFileDialog1
            // 
            saveFileDialog1.FileName = "*.chs";
            saveFileDialog1.Filter = "所有文件|*.*|残局文件|*.chs";
            saveFileDialog1.InitialDirectory = "saves";
            saveFileDialog1.Title = "保存残局";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "*.chs";
            openFileDialog1.Filter = "所有文件|*.*|残局文件|*.chs";
            openFileDialog1.Title = "打开残局";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 643);
            Controls.Add(menuStrip1);
            Cursor = Cursors.Hand;
            DoubleBuffered = true;
            MainMenuStrip = menuStrip1;
            Name = "FormMain";
            ShowIcon = false;
            Text = "象棋";
            WindowState = FormWindowState.Maximized;
            Paint += FormMain_Paint;
            MouseDown += FormMain_MouseDown;
            MouseMove += FormMain_MouseMove;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem MenuItemGame;
        private ToolStripMenuItem MenuItemBegin;
        private ToolStripMenuItem MenuItemUndo;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem MenuItemSave;
        private ToolStripMenuItem MenuItemOpen;
        private SaveFileDialog saveFileDialog1;
        private OpenFileDialog openFileDialog1;
    }
}
