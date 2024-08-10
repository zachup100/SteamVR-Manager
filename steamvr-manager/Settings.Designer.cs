namespace steamvr_manager
{
    partial class Settings
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Settings));
            theme_list = new ComboBox();
            use_theme_label = new Label();
            current_theme_label = new Label();
            SuspendLayout();
            // 
            // theme_list
            // 
            theme_list.DropDownStyle = ComboBoxStyle.DropDownList;
            theme_list.FormattingEnabled = true;
            theme_list.Location = new Point(173, 45);
            theme_list.Name = "theme_list";
            theme_list.Size = new Size(166, 23);
            theme_list.TabIndex = 0;
            theme_list.SelectedIndexChanged += theme_list_SelectedIndexChanged;
            // 
            // use_theme_label
            // 
            use_theme_label.AutoSize = true;
            use_theme_label.Location = new Point(102, 48);
            use_theme_label.Name = "use_theme_label";
            use_theme_label.Size = new Size(65, 15);
            use_theme_label.TabIndex = 1;
            use_theme_label.Text = "Use Theme";
            // 
            // current_theme_label
            // 
            current_theme_label.AutoSize = true;
            current_theme_label.Location = new Point(125, 71);
            current_theme_label.Name = "current_theme_label";
            current_theme_label.Size = new Size(89, 15);
            current_theme_label.TabIndex = 2;
            current_theme_label.Text = "Current Theme:";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(442, 365);
            Controls.Add(current_theme_label);
            Controls.Add(use_theme_label);
            Controls.Add(theme_list);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            TopMost = true;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox theme_list;
        private Label use_theme_label;
        private Label current_theme_label;
    }
}