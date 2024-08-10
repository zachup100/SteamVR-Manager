namespace steamvr_manager
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            steamvr_enabled = new CheckBox();
            steamvr_directory = new TextBox();
            steamvr_enabled_label = new Label();
            select_directory = new Button();
            topbar = new MenuStrip();
            topbar_file_dropdown = new ToolStripMenuItem();
            settings = new ToolStripMenuItem();
            exit_menu_item = new ToolStripMenuItem();
            topbar_help_dropdown = new ToolStripMenuItem();
            check_for_updates = new ToolStripMenuItem();
            about_menu_item = new ToolStripMenuItem();
            steamvr_toggle = new Button();
            topbar.SuspendLayout();
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
            steamvr_directory.Text = "If you're seeing this, something went wrong";
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
            select_directory.Location = new Point(278, 72);
            select_directory.Name = "select_directory";
            select_directory.Size = new Size(115, 23);
            select_directory.TabIndex = 3;
            select_directory.Text = "Change Directory";
            select_directory.UseVisualStyleBackColor = true;
            select_directory.Click += select_directory_Click;
            // 
            // topbar
            // 
            topbar.BackColor = Color.FromArgb(238, 238, 238);
            topbar.Items.AddRange(new ToolStripItem[] { topbar_file_dropdown, topbar_help_dropdown });
            topbar.Location = new Point(0, 0);
            topbar.Name = "topbar";
            topbar.Size = new Size(405, 24);
            topbar.TabIndex = 4;
            topbar.Text = "menuStrip1";
            // 
            // topbar_file_dropdown
            // 
            topbar_file_dropdown.DropDownItems.AddRange(new ToolStripItem[] { settings, exit_menu_item });
            topbar_file_dropdown.Name = "topbar_file_dropdown";
            topbar_file_dropdown.Size = new Size(37, 20);
            topbar_file_dropdown.Text = "File";
            // 
            // settings
            // 
            settings.Name = "settings";
            settings.Size = new Size(180, 22);
            settings.Text = "Settings";
            settings.Click += settings_Click;
            // 
            // exit_menu_item
            // 
            exit_menu_item.Name = "exit_menu_item";
            exit_menu_item.Size = new Size(180, 22);
            exit_menu_item.Text = "Exit";
            exit_menu_item.Click += exit_menu_item_Click;
            // 
            // topbar_help_dropdown
            // 
            topbar_help_dropdown.DropDownItems.AddRange(new ToolStripItem[] { check_for_updates, about_menu_item });
            topbar_help_dropdown.Name = "topbar_help_dropdown";
            topbar_help_dropdown.Size = new Size(44, 20);
            topbar_help_dropdown.Text = "Help";
            // 
            // check_for_updates
            // 
            check_for_updates.Name = "check_for_updates";
            check_for_updates.Size = new Size(180, 22);
            check_for_updates.Text = "Check for updates";
            check_for_updates.Click += check_for_updates_Click;
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
            steamvr_toggle.Location = new Point(136, 104);
            steamvr_toggle.Name = "steamvr_toggle";
            steamvr_toggle.Size = new Size(132, 23);
            steamvr_toggle.TabIndex = 5;
            steamvr_toggle.Text = "Enable SteamVR";
            steamvr_toggle.UseVisualStyleBackColor = true;
            steamvr_toggle.Click += steamvr_toggle_Click;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(405, 139);
            Controls.Add(steamvr_toggle);
            Controls.Add(select_directory);
            Controls.Add(steamvr_enabled_label);
            Controls.Add(steamvr_directory);
            Controls.Add(steamvr_enabled);
            Controls.Add(topbar);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = topbar;
            MaximizeBox = false;
            MaximumSize = new Size(421, 178);
            MinimumSize = new Size(421, 178);
            Name = "Main";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SteamVR Manager";
            topbar.ResumeLayout(false);
            topbar.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox steamvr_enabled;
        private TextBox steamvr_directory;
        private Label steamvr_enabled_label;
        private Button select_directory;
        private MenuStrip topbar;
        private ToolStripMenuItem topbar_help_dropdown;
        private ToolStripMenuItem about_menu_item;
        private ToolStripMenuItem topbar_file_dropdown;
        private ToolStripMenuItem exit_menu_item;
        private Button steamvr_toggle;
        private ToolStripMenuItem check_for_updates;
        private ToolStripMenuItem settings;
    }
}
