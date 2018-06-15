namespace NormalizaNomes
{
    partial class Form1
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.txtPathOrigin = new MetroFramework.Controls.MetroTextBox();
            this.btnPathOrigin = new MetroFramework.Controls.MetroButton();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.btnProcess = new MetroFramework.Controls.MetroButton();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.chkChangeFile = new MetroFramework.Controls.MetroCheckBox();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(13, 164);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(723, 287);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // txtPathOrigin
            // 
            // 
            // 
            // 
            this.txtPathOrigin.CustomButton.Image = null;
            this.txtPathOrigin.CustomButton.Location = new System.Drawing.Point(377, 1);
            this.txtPathOrigin.CustomButton.Name = "";
            this.txtPathOrigin.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.txtPathOrigin.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtPathOrigin.CustomButton.TabIndex = 1;
            this.txtPathOrigin.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtPathOrigin.CustomButton.UseSelectable = true;
            this.txtPathOrigin.CustomButton.Visible = false;
            this.txtPathOrigin.Lines = new string[0];
            this.txtPathOrigin.Location = new System.Drawing.Point(13, 109);
            this.txtPathOrigin.MaxLength = 32767;
            this.txtPathOrigin.Name = "txtPathOrigin";
            this.txtPathOrigin.PasswordChar = '\0';
            this.txtPathOrigin.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.txtPathOrigin.SelectedText = "";
            this.txtPathOrigin.SelectionLength = 0;
            this.txtPathOrigin.SelectionStart = 0;
            this.txtPathOrigin.ShortcutsEnabled = true;
            this.txtPathOrigin.Size = new System.Drawing.Size(399, 23);
            this.txtPathOrigin.TabIndex = 1;
            this.txtPathOrigin.UseSelectable = true;
            this.txtPathOrigin.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtPathOrigin.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // btnPathOrigin
            // 
            this.btnPathOrigin.Location = new System.Drawing.Point(418, 109);
            this.btnPathOrigin.Name = "btnPathOrigin";
            this.btnPathOrigin.Size = new System.Drawing.Size(63, 23);
            this.btnPathOrigin.TabIndex = 4;
            this.btnPathOrigin.Text = "...";
            this.btnPathOrigin.UseSelectable = true;
            this.btnPathOrigin.Click += new System.EventHandler(this.btnPathOrigin_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(13, 87);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(55, 19);
            this.metroLabel1.TabIndex = 7;
            this.metroLabel1.Text = "Origem";
            // 
            // btnProcess
            // 
            this.btnProcess.Location = new System.Drawing.Point(619, 109);
            this.btnProcess.Name = "btnProcess";
            this.btnProcess.Size = new System.Drawing.Size(117, 23);
            this.btnProcess.TabIndex = 9;
            this.btnProcess.Text = "Processar Planilha";
            this.btnProcess.UseSelectable = true;
            this.btnProcess.Click += new System.EventHandler(this.btnProcess_Click);
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(13, 142);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(46, 19);
            this.metroLabel2.TabIndex = 10;
            this.metroLabel2.Text = "Status:";
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Location = new System.Drawing.Point(688, 55);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(48, 48);
            this.metroProgressSpinner1.Speed = 2F;
            this.metroProgressSpinner1.TabIndex = 11;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.Visible = false;
            // 
            // chkChangeFile
            // 
            this.chkChangeFile.AutoSize = true;
            this.chkChangeFile.Location = new System.Drawing.Point(487, 117);
            this.chkChangeFile.Name = "chkChangeFile";
            this.chkChangeFile.Size = new System.Drawing.Size(103, 15);
            this.chkChangeFile.TabIndex = 12;
            this.chkChangeFile.Text = "Alterar Arquivo";
            this.chkChangeFile.UseSelectable = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 499);
            this.Controls.Add(this.chkChangeFile);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.metroLabel2);
            this.Controls.Add(this.btnProcess);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btnPathOrigin);
            this.Controls.Add(this.txtPathOrigin);
            this.Controls.Add(this.richTextBox1);
            this.Name = "Form1";
            this.Text = "CIIA - Normaliza Nomes";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private MetroFramework.Controls.MetroTextBox txtPathOrigin;
        private MetroFramework.Controls.MetroButton btnPathOrigin;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroButton btnProcess;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroCheckBox chkChangeFile;
    }
}

