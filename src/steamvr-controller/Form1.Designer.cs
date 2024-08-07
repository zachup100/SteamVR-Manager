namespace steamvr_controller
{
    partial class Form1
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
            steamvr_enabled = new CheckBox();
            steamvr_directory = new TextBox();
            steamvr_enabled_label = new Label();
            select_directory = new Button();
            menuStrip1 = new MenuStrip();
            exitToolStripMenuItem = new ToolStripMenuItem();
            exit_menu_item = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            about_menu_item = new ToolStripMenuItem();
            steamvr_toggle = new Button();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // steamvr_enabled
            // 
            steamvr_enabled.AutoCheck = false;
            steamvr_enabled.AutoSize = true;
            steamvr_enabled.Enabled = false;
            steamvr_enabled.Location = new Point(11, 77);
            steamvr_enabled.Name = "steamvr_enabled";
            steamvr_enabled.Size = new Size(15, 14);
            steamvr_enabled.TabIndex = 0;
            steamvr_enabled.UseVisualStyleBackColor = true;
            // 
            // steamvr_directory
            // 
            steamvr_directory.Enabled = false;
            steamvr_directory.Location = new Point(11, 43);
            steamvr_directory.Name = "steamvr_directory";
            steamvr_directory.Size = new Size(382, 23);
            steamvr_directory.TabIndex = 1;
            steamvr_directory.Text = "C:\\Program Files (x86)\\Steam\\Blah\\Blah";
            steamvr_directory.WordWrap = false;
            // 
            // steamvr_enabled_label
            // 
            steamvr_enabled_label.AutoSize = true;
            steamvr_enabled_label.Location = new Point(27, 76);
            steamvr_enabled_label.Name = "steamvr_enabled_label";
            steamvr_enabled_label.Size = new Size(99, 15);
            steamvr_enabled_label.TabIndex = 2;
            steamvr_enabled_label.Text = "SteamVR Enabled";
            // 
            // select_directory
            // 
            select_directory.Location = new Point(264, 72);
            select_directory.Name = "select_directory";
            select_directory.Size = new Size(129, 23);
            select_directory.TabIndex = 3;
            select_directory.Text = "Change Directory";
            select_directory.UseVisualStyleBackColor = true;
            select_directory.Click += select_directory_Click;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { exitToolStripMenuItem, helpToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(405, 24);
            menuStrip1.TabIndex = 4;
            menuStrip1.Text = "menuStrip1";
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { exit_menu_item });
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(37, 20);
            exitToolStripMenuItem.Text = "File";
            // 
            // exit_menu_item
            // 
            exit_menu_item.Name = "exit_menu_item";
            exit_menu_item.Size = new Size(180, 22);
            exit_menu_item.Text = "Exit";
            exit_menu_item.Click += exit_menu_item_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { about_menu_item });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(44, 20);
            helpToolStripMenuItem.Text = "Help";
            // 
            // about_menu_item
            // 
            about_menu_item.Name = "about_menu_item";
            about_menu_item.Size = new Size(180, 22);
            about_menu_item.Text = "About";
            about_menu_item.Click += about_menu_item_Click;
            // 
            // steamvr_toggle
            // 
            steamvr_toggle.Location = new Point(130, 104);
            steamvr_toggle.Name = "steamvr_toggle";
            steamvr_toggle.Size = new Size(132, 23);
            steamvr_toggle.TabIndex = 5;
            steamvr_toggle.Text = "Enable SteamVR";
            steamvr_toggle.UseVisualStyleBackColor = true;
            steamvr_toggle.Click += steamvr_toggle_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Window;
            ClientSize = new Size(405, 139);
            Controls.Add(steamvr_toggle);
            Controls.Add(select_directory);
            Controls.Add(steamvr_enabled_label);
            Controls.Add(steamvr_directory);
            Controls.Add(steamvr_enabled);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "SteamVR Controller";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox steamvr_enabled;
        private TextBox steamvr_directory;
        private Label steamvr_enabled_label;
        private Button select_directory;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem about_menu_item;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem exit_menu_item;
        private Button steamvr_toggle;
    }
}
