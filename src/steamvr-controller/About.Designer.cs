namespace steamvr_controller
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            button1 = new Button();
            credits_label = new Label();
            info_label = new Label();
            info_label2 = new Label();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(121, 192);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "GitHub";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // credits_label
            // 
            credits_label.AutoSize = true;
            credits_label.Location = new Point(101, 174);
            credits_label.Name = "credits_label";
            credits_label.Size = new Size(121, 15);
            credits_label.TabIndex = 1;
            credits_label.Text = "Written by zachup100";
            // 
            // info_label
            // 
            info_label.Location = new Point(12, 9);
            info_label.Name = "info_label";
            info_label.Size = new Size(296, 64);
            info_label.TabIndex = 2;
            info_label.Text = resources.GetString("info_label.Text");
            info_label.TextAlign = ContentAlignment.TopCenter;
            // 
            // info_label2
            // 
            info_label2.Location = new Point(12, 84);
            info_label2.Name = "info_label2";
            info_label2.Size = new Size(296, 77);
            info_label2.TabIndex = 3;
            info_label2.Text = resources.GetString("info_label2.Text");
            info_label2.TextAlign = ContentAlignment.TopCenter;
            // 
            // About
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(317, 225);
            Controls.Add(info_label2);
            Controls.Add(info_label);
            Controls.Add(credits_label);
            Controls.Add(button1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "About";
            Text = "About";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label credits_label;
        private Label info_label;
        private Label info_label2;
    }
}