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
            this.richLanguage = new System.Windows.Forms.RichTextBox();
            this.btnPaste = new System.Windows.Forms.Button();
            this.btnCopy = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelControl1 = new System.Windows.Forms.Label();
            this.labelControl2 = new System.Windows.Forms.Label();
            this.richOrder = new System.Windows.Forms.RichTextBox();
            this.btnCopyOrder = new System.Windows.Forms.Button();
            this.btnPasteOrder = new System.Windows.Forms.Button();
            this.chkExtensions = new System.Windows.Forms.CheckedListBox();
            this.lblExtensions = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnForlder
            // 
            this.btnForlder.Location = new System.Drawing.Point(1080, 19);
            this.btnForlder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.txtFolder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.txtFolder.Name = "txtFolder";
            this.txtFolder.Size = new System.Drawing.Size(1040, 31);
            this.txtFolder.TabIndex = 1;
            // 
            // richLanguage
            // 
            this.richLanguage.Enabled = false;
            this.richLanguage.Location = new System.Drawing.Point(332, 112);
            this.richLanguage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.richLanguage.Name = "richLanguage";
            this.richLanguage.Size = new System.Drawing.Size(732, 177);
            this.richLanguage.TabIndex = 3;
            this.richLanguage.Text = "";
            // 
            // btnPaste
            // 
            this.btnPaste.Location = new System.Drawing.Point(1080, 167);
            this.btnPaste.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPaste.Name = "btnPaste";
            this.btnPaste.Size = new System.Drawing.Size(150, 44);
            this.btnPaste.TabIndex = 4;
            this.btnPaste.Text = "Paste";
            this.btnPaste.Click += new System.EventHandler(this.btnPaste_Click);
            // 
            // btnCopy
            // 
            this.btnCopy.Location = new System.Drawing.Point(1080, 112);
            this.btnCopy.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(150, 44);
            this.btnCopy.TabIndex = 5;
            this.btnCopy.Text = "Copy";
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(1080, 487);
            this.btnStart.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(150, 44);
            this.btnStart.TabIndex = 6;
            this.btnStart.Text = "Start";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(24, 548);
            this.progressBar.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.labelControl1.Text = "Idiomas";
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(332, 306);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(736, 33);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Orden de las pistas";
            // 
            // richOrder
            // 
            this.richOrder.Enabled = false;
            this.richOrder.Location = new System.Drawing.Point(332, 344);
            this.richOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.richOrder.Name = "richOrder";
            this.richOrder.Size = new System.Drawing.Size(732, 183);
            this.richOrder.TabIndex = 11;
            this.richOrder.Text = "";
            // 
            // btnCopyOrder
            // 
            this.btnCopyOrder.Location = new System.Drawing.Point(1080, 340);
            this.btnCopyOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnCopyOrder.Name = "btnCopyOrder";
            this.btnCopyOrder.Size = new System.Drawing.Size(150, 44);
            this.btnCopyOrder.TabIndex = 13;
            this.btnCopyOrder.Text = "Copy";
            this.btnCopyOrder.Click += new System.EventHandler(this.btnCopyOrder_Click);
            // 
            // btnPasteOrder
            // 
            this.btnPasteOrder.Location = new System.Drawing.Point(1080, 396);
            this.btnPasteOrder.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.btnPasteOrder.Name = "btnPasteOrder";
            this.btnPasteOrder.Size = new System.Drawing.Size(150, 44);
            this.btnPasteOrder.TabIndex = 12;
            this.btnPasteOrder.Text = "Paste";
            this.btnPasteOrder.Click += new System.EventHandler(this.btnPasteOrder_Click);
            // 
            // chkExtensions
            // 
            this.chkExtensions.FormattingEnabled = true;
            this.chkExtensions.Location = new System.Drawing.Point(26, 113);
            this.chkExtensions.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
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
            this.ClientSize = new System.Drawing.Size(1254, 606);
            this.Controls.Add(this.lblExtensions);
            this.Controls.Add(this.chkExtensions);
            this.Controls.Add(this.btnCopyOrder);
            this.Controls.Add(this.btnPasteOrder);
            this.Controls.Add(this.richOrder);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.btnPaste);
            this.Controls.Add(this.richLanguage);
            this.Controls.Add(this.txtFolder);
            this.Controls.Add(this.btnForlder);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Name = "Form";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MkvMassive";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnForlder;
        private System.Windows.Forms.TextBox txtFolder;
        private System.Windows.Forms.RichTextBox richLanguage;
        private System.Windows.Forms.Button btnPaste;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelControl1;
        private System.Windows.Forms.Label labelControl2;
        private System.Windows.Forms.RichTextBox richOrder;
        private System.Windows.Forms.Button btnCopyOrder;
        private System.Windows.Forms.Button btnPasteOrder;
        private System.Windows.Forms.CheckedListBox chkExtensions;
        private System.Windows.Forms.Label lblExtensions;
    }
}

