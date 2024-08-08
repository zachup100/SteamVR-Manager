namespace steamvr_manager
{
    partial class Changelog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Changelog));
            check_for_updates = new Button();
            panel1 = new Panel();
            changelog_info = new Label();
            current_version = new Label();
            current_build = new Label();
            get_build_selection = new ComboBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // check_for_updates
            // 
            check_for_updates.Location = new Point(192, 244);
            check_for_updates.Name = "check_for_updates";
            check_for_updates.Size = new Size(140, 23);
            check_for_updates.TabIndex = 1;
            check_for_updates.Text = "Check for Updates";
            check_for_updates.UseVisualStyleBackColor = true;
            check_for_updates.Click += check_for_updates_Click;
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(changelog_info);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(354, 226);
            panel1.TabIndex = 2;
            // 
            // changelog_info
            // 
            changelog_info.AutoSize = true;
            changelog_info.Location = new Point(3, 3);
            changelog_info.MaximumSize = new Size(346, 0);
            changelog_info.MinimumSize = new Size(346, 0);
            changelog_info.Name = "changelog_info";
            changelog_info.Size = new Size(346, 15);
            changelog_info.TabIndex = 0;
            changelog_info.Text = "Select a build candidate and click 'Check for Updates'";
            // 
            // current_version
            // 
            current_version.Location = new Point(12, 270);
            current_version.Name = "current_version";
            current_version.Size = new Size(354, 16);
            current_version.TabIndex = 3;
            current_version.Text = "Current Version: N/A";
            current_version.TextAlign = ContentAlignment.TopCenter;
            // 
            // current_build
            // 
            current_build.Location = new Point(12, 286);
            current_build.Name = "current_build";
            current_build.Size = new Size(354, 17);
            current_build.TabIndex = 4;
            current_build.Text = "Current Build: N/A";
            current_build.TextAlign = ContentAlignment.TopCenter;
            // 
            // get_build_selection
            // 
            get_build_selection.DropDownStyle = ComboBoxStyle.DropDownList;
            get_build_selection.FlatStyle = FlatStyle.System;
            get_build_selection.FormattingEnabled = true;
            get_build_selection.Items.AddRange(new object[] { "Latest", "Release", "Nightly" });
            get_build_selection.Location = new Point(49, 244);
            get_build_selection.Name = "get_build_selection";
            get_build_selection.Size = new Size(121, 23);
            get_build_selection.TabIndex = 5;
            // 
            // Changelog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(378, 307);
            Controls.Add(get_build_selection);
            Controls.Add(current_build);
            Controls.Add(current_version);
            Controls.Add(panel1);
            Controls.Add(check_for_updates);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Changelog";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Check for Updates";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Button check_for_updates;
        private Panel panel1;
        private Label current_version;
        private Label current_build;
        private ComboBox get_build_selection;
        private Label changelog_info;
    }
}