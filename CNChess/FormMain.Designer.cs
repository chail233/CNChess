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
            MenuItemGame.DropDownItems.AddRange(new ToolStripItem[] { MenuItemBegin, MenuItemUndo });
            MenuItemGame.Name = "MenuItemGame";
            MenuItemGame.Size = new Size(62, 28);
            MenuItemGame.Text = "游戏";
            // 
            // MenuItemBegin
            // 
            MenuItemBegin.Name = "MenuItemBegin";
            MenuItemBegin.ShortcutKeys = Keys.Control | Keys.B;
            MenuItemBegin.Size = new Size(270, 34);
            MenuItemBegin.Text = "开局";
            MenuItemBegin.Click += MenuItemBegin_Click;
            // 
            // MenuItemUndo
            // 
            MenuItemUndo.Name = "MenuItemUndo";
            MenuItemUndo.ShortcutKeys = Keys.Control | Keys.Z;
            MenuItemUndo.Size = new Size(270, 34);
            MenuItemUndo.Text = "悔棋";
            MenuItemUndo.Click += MenuItemUndo_Click;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1011, 643);
            Controls.Add(menuStrip1);
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
    }
}
