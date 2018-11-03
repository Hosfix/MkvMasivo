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
            this.BtnForlder = new System.Windows.Forms.Button();
            this.txtFolder = new System.Windows.Forms.TextBox();
            this.richCommand = new System.Windows.Forms.RichTextBox();
            this.BtnPaste = new System.Windows.Forms.Button();
            this.BtnCopy = new System.Windows.Forms.Button();
            this.BtnRun = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LabelComando = new System.Windows.Forms.Label();
            this.chkExtensions = new System.Windows.Forms.CheckedListBox();
            this.LabelExtensions = new System.Windows.Forms.Label();
            this.LabelInformation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BtnForlder
            // 
            this.BtnForlder.Location = new System.Drawing.Point(1080, 19);
            this.BtnForlder.Margin = new System.Windows.Forms.Padding(6);
            this.BtnForlder.Name = "BtnForlder";
            this.BtnForlder.Size = new System.Drawing.Size(150, 44);
            this.BtnForlder.TabIndex = 0;
            this.BtnForlder.Text = "Select...";
            this.BtnForlder.Click += new System.EventHandler(this.btnForlder_Click);
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
            // richCommand
            // 
            this.richCommand.Enabled = false;
            this.richCommand.Location = new System.Drawing.Point(332, 112);
            this.richCommand.Margin = new System.Windows.Forms.Padding(6);
            this.richCommand.Name = "richCommand";
            this.richCommand.Size = new System.Drawing.Size(732, 391);
            this.richCommand.TabIndex = 3;
            this.richCommand.Text = "";
            // 
            // BtnPaste
            // 
            this.BtnPaste.Location = new System.Drawing.Point(1080, 167);
            this.BtnPaste.Margin = new System.Windows.Forms.Padding(6);
            this.BtnPaste.Name = "BtnPaste";
            this.BtnPaste.Size = new System.Drawing.Size(150, 44);
            this.BtnPaste.TabIndex = 4;
            this.BtnPaste.Text = "Paste";
            this.BtnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // BtnCopy
            // 
            this.BtnCopy.Location = new System.Drawing.Point(1080, 112);
            this.BtnCopy.Margin = new System.Windows.Forms.Padding(6);
            this.BtnCopy.Name = "BtnCopy";
            this.BtnCopy.Size = new System.Drawing.Size(150, 44);
            this.BtnCopy.TabIndex = 5;
            this.BtnCopy.Text = "Copy";
            this.BtnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // BtnRun
            // 
            this.BtnRun.Location = new System.Drawing.Point(1080, 463);
            this.BtnRun.Margin = new System.Windows.Forms.Padding(6);
            this.BtnRun.Name = "BtnRun";
            this.BtnRun.Size = new System.Drawing.Size(150, 44);
            this.BtnRun.TabIndex = 6;
            this.BtnRun.Text = "Start";
            this.BtnRun.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(24, 519);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6);
            this.progressBar.MarqueeAnimationSpeed = 50;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(1206, 35);
            this.progressBar.TabIndex = 7;
            // 
            // LabelComando
            // 
            this.LabelComando.Location = new System.Drawing.Point(332, 75);
            this.LabelComando.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelComando.Name = "LabelComando";
            this.LabelComando.Size = new System.Drawing.Size(736, 31);
            this.LabelComando.TabIndex = 9;
            this.LabelComando.Text = "Comando MkvToolNix";
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
            // LabelExtensions
            // 
            this.LabelExtensions.AutoSize = true;
            this.LabelExtensions.Location = new System.Drawing.Point(26, 75);
            this.LabelExtensions.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.LabelExtensions.Name = "LabelExtensions";
            this.LabelExtensions.Size = new System.Drawing.Size(130, 25);
            this.LabelExtensions.TabIndex = 15;
            this.LabelExtensions.Text = "Extensiones";
            // 
            // LabelInformation
            // 
            this.LabelInformation.Location = new System.Drawing.Point(26, 563);
            this.LabelInformation.Margin = new System.Windows.Forms.Padding(3);
            this.LabelInformation.Name = "LabelInformation";
            this.LabelInformation.Size = new System.Drawing.Size(1204, 35);
            this.LabelInformation.TabIndex = 16;
            this.LabelInformation.Text = "Information";
            this.LabelInformation.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1254, 604);
            this.Controls.Add(this.LabelInformation);
            this.Controls.Add(this.LabelExtensions);
            this.Controls.Add(this.chkExtensions);
            this.Controls.Add(this.LabelComando);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.BtnRun);
            this.Controls.Add(this.BtnCopy);
            this.Controls.Add(this.BtnPaste);
            this.Controls.Add(this.richCommand);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.BtnForlder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MkvMassive";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnForlder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.RichTextBox richCommand;
        private System.Windows.Forms.Button BtnPaste;
        private System.Windows.Forms.Button BtnCopy;
        private System.Windows.Forms.Button BtnRun;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label LabelComando;
        private System.Windows.Forms.CheckedListBox chkExtensions;
        private System.Windows.Forms.Label LabelExtensions;
        private System.Windows.Forms.Label LabelInformation;
    }
}

