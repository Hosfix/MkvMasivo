namespace MkvMasivo
{
    partial class Form
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form));
            this.btnForlder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.richCommand = new System.Windows.Forms.RichTextBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelControl1 = new System.Windows.Forms.Label();
            this.chkExtensions = new System.Windows.Forms.CheckedListBox();
            this.lblExtensions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnForlder
            // 
            this.btnForlder.Location = new System.Drawing.Point(1080, 19);
            this.btnForlder.Margin = new System.Windows.Forms.Padding(6);
            this.btnForlder.Name = "btnForlder";
            this.btnForlder.Size = new System.Drawing.Size(150, 44);
            this.btnForlder.TabIndex = 0;
            this.btnForlder.Text = "Select...";
            this.btnForlder.Click += new System.EventHandler(this.btnForlder_Click);
            // 
            // txtFolder
            // 
            this.txtFolder.Enabled = false;
            this.txtFolder.Location = new System.Drawing.Point(24, 23);
            this.txtFolder.Margin = new System.Windows.Forms.Padding(6);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(1040, 31);
            this.txtFolder.TabIndex = 1;
            // 
            // richLanguage
            // 
            this.richCommand.Enabled = false;
            this.richCommand.Location = new System.Drawing.Point(332, 112);
            this.richCommand.Margin = new System.Windows.Forms.Padding(6);
            this.richCommand.Name = "richLanguage";
            this.richCommand.Size = new System.Drawing.Size(732, 395);
            this.richCommand.TabIndex = 3;
            this.richCommand.Text = "";
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(1080, 167);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(6);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(150, 44);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1080, 112);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(150, 44);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1080, 463);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 44);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(24, 519);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1206, 35);
            this.progressBar.TabIndex = 7;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(332, 75);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(736, 31);
            this.labelControl1.TabIndex = 9;
            this.labelControl1.Text = "Comando MkvToolNix";
            // 
            // chkExtensions
            // 
            this.chkExtensions.FormattingEnabled = true;
            this.chkExtensions.Location = new System.Drawing.Point(26, 113);
            this.chkExtensions.Margin = new System.Windows.Forms.Padding(6);
            this.chkExtensions.Name = "chkExtensions";
            this.chkExtensions.Size = new System.Drawing.Size(290, 394);
            this.chkExtensions.TabIndex = 14;
            // 
            // lblExtensions
            // 
            this.lblExtensions.AutoSize = true;
            this.lblExtensions.Location = new System.Drawing.Point(26, 75);
            this.lblExtensions.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.lblExtensions.Name = "lblExtensions";
            this.lblExtensions.Size = new System.Drawing.Size(130, 25);
            this.lblExtensions.TabIndex = 15;
            this.lblExtensions.Text = "Extensiones";
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1254, 570);
            this.Controls.Add(this.lblExtensions);
            this.Controls.Add(this.chkExtensions);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.richCommand);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnForlder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MkvMassive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnForlder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.RichTextBox richCommand;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.CheckedListBox chkExtensions;
        private System.Windows.Forms.Label lblExtensions;
    }
}

