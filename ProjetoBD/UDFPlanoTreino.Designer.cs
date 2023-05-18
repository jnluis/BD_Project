namespace ProjetoBD
{
    partial class UDFPlanoTreino
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UDFPlanoTreino));
            this.cBoxClientes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cBoxClientes
            // 
            this.cBoxClientes.FormattingEnabled = true;
            this.cBoxClientes.Location = new System.Drawing.Point(549, 100);
            this.cBoxClientes.Name = "cBoxClientes";
            this.cBoxClientes.Size = new System.Drawing.Size(121, 28);
            this.cBoxClientes.TabIndex = 0;
            // 
            // UDFPlanoTreino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightBlue;
            this.ClientSize = new System.Drawing.Size(1179, 692);
            this.Controls.Add(this.cBoxClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "UDFPlanoTreino";
            this.Text = "UDFPlanoTreino";
            this.Load += new System.EventHandler(this.UDFPlanoTreino_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cBoxClientes;
    }
}