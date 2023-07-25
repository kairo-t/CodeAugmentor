using System;
using System.Drawing;
using System.Windows.Forms;

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
            cmbTemplates = new ComboBox();
            btnSaveTemplate = new Button();
            btnRemoveTemplate = new Button();
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
            cmbEngine.SelectedIndexChanged += SelectedIndexChanged_cmbEngine;
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
            rtbPrompt.TextChanged += TextChanged_rtbPrompt;
            // 
            // txbAPIKey
            // 
            txbAPIKey.BackColor = Color.White;
            txbAPIKey.Location = new Point(68, 13);
            txbAPIKey.Name = "txbAPIKey";
            txbAPIKey.PasswordChar = '*';
            txbAPIKey.Size = new Size(325, 23);
            txbAPIKey.TabIndex = 10;
            txbAPIKey.TextChanged += TextChanged_txbAPIKey;
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
            btnFiles.Click += Click_btnFiles;
            // 
            // ofdFiles
            // 
            ofdFiles.Multiselect = true;
            // 
            // cmbTemplates
            // 
            cmbTemplates.BackColor = Color.WhiteSmoke;
            cmbTemplates.FormattingEnabled = true;
            cmbTemplates.Location = new Point(12, 173);
            cmbTemplates.Name = "cmbTemplates";
            cmbTemplates.Size = new Size(338, 23);
            cmbTemplates.TabIndex = 15;
            cmbTemplates.SelectedIndexChanged += SelectedIndexChanged_cmbTemplates;
            // 
            // btnSaveTemplate
            // 
            btnSaveTemplate.BackColor = Color.White;
            btnSaveTemplate.Location = new Point(425, 173);
            btnSaveTemplate.Name = "btnSaveTemplate";
            btnSaveTemplate.Size = new Size(54, 23);
            btnSaveTemplate.TabIndex = 16;
            btnSaveTemplate.Text = "Save Template";
            btnSaveTemplate.UseVisualStyleBackColor = false;
            btnSaveTemplate.Click += Click_btnSaveTemplate;
            // 
            // btnRemoveTemplate
            // 
            btnRemoveTemplate.BackColor = Color.White;
            btnRemoveTemplate.Location = new Point(356, 173);
            btnRemoveTemplate.Name = "btnRemoveTemplate";
            btnRemoveTemplate.Size = new Size(63, 23);
            btnRemoveTemplate.TabIndex = 17;
            btnRemoveTemplate.Text = "Remove";
            btnRemoveTemplate.UseVisualStyleBackColor = false;
            btnRemoveTemplate.Click += Click_btnRemoveTemplate;
            // 
            // FrmMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(491, 208);
            Controls.Add(btnRemoveTemplate);
            Controls.Add(btnSaveTemplate);
            Controls.Add(cmbTemplates);
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
        private ComboBox cmbTemplates;
        private Button btnSaveTemplate;
        private Button btnRemoveTemplate;
    }
}