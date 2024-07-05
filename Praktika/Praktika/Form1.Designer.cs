namespace Praktika
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            SaveBtn = new Button();
            ConsoleTB = new TextBox();
            RetryBtn = new Button();
            SuspendLayout();
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.SeaGreen;
            SaveBtn.Cursor = Cursors.Hand;
            SaveBtn.Enabled = false;
            SaveBtn.Font = new Font("Segoe UI", 14F);
            SaveBtn.ForeColor = Color.PapayaWhip;
            SaveBtn.Location = new Point(12, 345);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(850, 102);
            SaveBtn.TabIndex = 0;
            SaveBtn.Text = "Сохранить";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // ConsoleTB
            // 
            ConsoleTB.BackColor = Color.PapayaWhip;
            ConsoleTB.ForeColor = Color.SeaGreen;
            ConsoleTB.Location = new Point(12, 12);
            ConsoleTB.Multiline = true;
            ConsoleTB.Name = "ConsoleTB";
            ConsoleTB.ReadOnly = true;
            ConsoleTB.ScrollBars = ScrollBars.Vertical;
            ConsoleTB.Size = new Size(850, 292);
            ConsoleTB.TabIndex = 1;
            ConsoleTB.TextAlign = HorizontalAlignment.Center;
            // 
            // RetryBtn
            // 
            RetryBtn.BackColor = Color.SeaGreen;
            RetryBtn.Cursor = Cursors.Hand;
            RetryBtn.Enabled = false;
            RetryBtn.ForeColor = Color.PapayaWhip;
            RetryBtn.Location = new Point(12, 310);
            RetryBtn.Name = "RetryBtn";
            RetryBtn.Size = new Size(850, 29);
            RetryBtn.TabIndex = 2;
            RetryBtn.Text = "Повторить";
            RetryBtn.UseVisualStyleBackColor = false;
            RetryBtn.Click += RetryBtn_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Linen;
            ClientSize = new Size(874, 452);
            Controls.Add(RetryBtn);
            Controls.Add(ConsoleTB);
            Controls.Add(SaveBtn);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Network Test";
            Load += MainForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button SaveBtn;
        private TextBox ConsoleTB;
        private Button RetryBtn;
    }
}
