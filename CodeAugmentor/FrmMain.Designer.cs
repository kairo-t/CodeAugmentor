namespace CodeAugmentor
{
    partial class FrmMain
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
            label1 = new Label();
            cmbEngine = new ComboBox();
            lblPrompt = new Label();
            rtbPrompt = new RichTextBox();
            txbAPIKey = new TextBox();
            lblAPIKey = new Label();
            btnFiles = new Button();
            ofdFiles = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(222, 45);
            label1.Name = "label1";
            label1.Size = new Size(46, 15);
            label1.TabIndex = 14;
            label1.Text = "Engine:";
            // 
            // cmbEngine
            // 
            cmbEngine.BackColor = Color.WhiteSmoke;
            cmbEngine.FormattingEnabled = true;
            cmbEngine.Items.AddRange(new object[] { "gpt-3.5-turbo", "gpt-3.5-turbo-16k", "gpt-4", "gpt-4-32k" });
            cmbEngine.Location = new Point(274, 42);
            cmbEngine.Name = "cmbEngine";
            cmbEngine.Size = new Size(205, 23);
            cmbEngine.TabIndex = 13;
            cmbEngine.Text = "gpt-3.5-turbo";
            // 
            // lblPrompt
            // 
            lblPrompt.AutoSize = true;
            lblPrompt.Location = new Point(12, 45);
            lblPrompt.Name = "lblPrompt";
            lblPrompt.Size = new Size(50, 15);
            lblPrompt.TabIndex = 12;
            lblPrompt.Text = "Prompt:";
            // 
            // rtbPrompt
            // 
            rtbPrompt.BackColor = Color.White;
            rtbPrompt.BorderStyle = BorderStyle.None;
            rtbPrompt.Location = new Point(12, 71);
            rtbPrompt.Name = "rtbPrompt";
            rtbPrompt.Size = new Size(467, 96);
            rtbPrompt.TabIndex = 11;
            rtbPrompt.Text = "";
            rtbPrompt.TextChanged += rtbPrompt_TextChanged;
            // 
            // txbAPIKey
            // 
            txbAPIKey.BackColor = Color.White;
            txbAPIKey.Location = new Point(68, 13);
            txbAPIKey.Name = "txbAPIKey";
            txbAPIKey.Size = new Size(325, 23);
            txbAPIKey.TabIndex = 10;
            txbAPIKey.TextChanged += txbAPIKey_TextChanged;
            // 
            // lblAPIKey
            // 
            lblAPIKey.AutoSize = true;
            lblAPIKey.Location = new Point(12, 16);
            lblAPIKey.Name = "lblAPIKey";
            lblAPIKey.Size = new Size(50, 15);
            lblAPIKey.TabIndex = 9;
            lblAPIKey.Text = "API Key:";
            // 
            // btnFiles
            // 
            btnFiles.BackColor = Color.White;
            btnFiles.Location = new Point(399, 13);
            btnFiles.Name = "btnFiles";
            btnFiles.Size = new Size(80, 23);
            btnFiles.TabIndex = 8;
            btnFiles.Text = "Files";
            btnFiles.UseVisualStyleBackColor = false;
            btnFiles.Click += btnFiles_Click;
            // 
            // ofdFiles
            // 
            ofdFiles.Multiselect = true;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(491, 174);
            Controls.Add(label1);
            Controls.Add(cmbEngine);
            Controls.Add(lblPrompt);
            Controls.Add(rtbPrompt);
            Controls.Add(txbAPIKey);
            Controls.Add(lblAPIKey);
            Controls.Add(btnFiles);
            Name = "FrmMain";
            Text = "Code Augmentor";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ComboBox cmbEngine;
        private Label lblPrompt;
        private RichTextBox rtbPrompt;
        private TextBox txbAPIKey;
        private Label lblAPIKey;
        private Button btnFiles;
        private OpenFileDialog ofdFiles;
    }
}