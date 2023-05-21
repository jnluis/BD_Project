namespace ProjetoBD
{
    partial class EditarPagamento
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EditarPagamento));
            this.btnclose = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblPag = new System.Windows.Forms.Label();
            this.lblPagamento = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbtnPendente = new System.Windows.Forms.RadioButton();
            this.rdbtnPago = new System.Windows.Forms.RadioButton();
            this.rdbtnCancelado = new System.Windows.Forms.RadioButton();
            this.datePag = new System.Windows.Forms.DateTimePicker();
            this.dateCanc = new System.Windows.Forms.DateTimePicker();
            this.lblCanc = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnclose
            // 
            this.btnclose.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnclose.Location = new System.Drawing.Point(440, 644);
            this.btnclose.Name = "btnclose";
            this.btnclose.Size = new System.Drawing.Size(141, 55);
            this.btnclose.TabIndex = 18;
            this.btnclose.Text = "Fechar";
            this.btnclose.UseVisualStyleBackColor = true;
            this.btnclose.Click += new System.EventHandler(this.btnclose_Click);
            // 
            // btnOk
            // 
            this.btnOk.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOk.Location = new System.Drawing.Point(288, 644);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(108, 55);
            this.btnOk.TabIndex = 17;
            this.btnOk.Text = "Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblPag
            // 
            this.lblPag.AutoSize = true;
            this.lblPag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPag.Location = new System.Drawing.Point(347, 403);
            this.lblPag.Name = "lblPag";
            this.lblPag.Size = new System.Drawing.Size(140, 32);
            this.lblPag.TabIndex = 13;
            this.lblPag.Text = "Data Pag.";
            this.lblPag.Visible = false;
            // 
            // lblPagamento
            // 
            this.lblPagamento.AutoSize = true;
            this.lblPagamento.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagamento.Location = new System.Drawing.Point(304, 280);
            this.lblPagamento.Name = "lblPagamento";
            this.lblPagamento.Size = new System.Drawing.Size(92, 32);
            this.lblPagamento.TabIndex = 12;
            this.lblPagamento.Text = "label2";
            this.lblPagamento.Click += new System.EventHandler(this.lblAula_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(96, 280);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(202, 32);
            this.label1.TabIndex = 11;
            this.label1.Text = "ID Pagamento:";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(169, 38);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(595, 201);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbtnCancelado);
            this.groupBox1.Controls.Add(this.rdbtnPago);
            this.groupBox1.Controls.Add(this.rdbtnPendente);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(102, 343);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(215, 260);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estado";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // rdbtnPendente
            // 
            this.rdbtnPendente.AutoSize = true;
            this.rdbtnPendente.Location = new System.Drawing.Point(6, 107);
            this.rdbtnPendente.Name = "rdbtnPendente";
            this.rdbtnPendente.Size = new System.Drawing.Size(162, 36);
            this.rdbtnPendente.TabIndex = 0;
            this.rdbtnPendente.TabStop = true;
            this.rdbtnPendente.Text = "Pendente";
            this.rdbtnPendente.UseVisualStyleBackColor = true;
            this.rdbtnPendente.CheckedChanged += new System.EventHandler(this.rdbtnPendente_CheckedChanged);
            // 
            // rdbtnPago
            // 
            this.rdbtnPago.AutoSize = true;
            this.rdbtnPago.Location = new System.Drawing.Point(6, 56);
            this.rdbtnPago.Name = "rdbtnPago";
            this.rdbtnPago.Size = new System.Drawing.Size(106, 36);
            this.rdbtnPago.TabIndex = 1;
            this.rdbtnPago.TabStop = true;
            this.rdbtnPago.Text = "Pago";
            this.rdbtnPago.UseVisualStyleBackColor = true;
            this.rdbtnPago.CheckedChanged += new System.EventHandler(this.rdbtnPago_CheckedChanged);
            // 
            // rdbtnCancelado
            // 
            this.rdbtnCancelado.AutoSize = true;
            this.rdbtnCancelado.Location = new System.Drawing.Point(6, 158);
            this.rdbtnCancelado.Name = "rdbtnCancelado";
            this.rdbtnCancelado.Size = new System.Drawing.Size(176, 36);
            this.rdbtnCancelado.TabIndex = 2;
            this.rdbtnCancelado.TabStop = true;
            this.rdbtnCancelado.Text = "Cancelado";
            this.rdbtnCancelado.UseVisualStyleBackColor = true;
            this.rdbtnCancelado.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // datePag
            // 
            this.datePag.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.datePag.Location = new System.Drawing.Point(508, 398);
            this.datePag.Name = "datePag";
            this.datePag.Size = new System.Drawing.Size(352, 39);
            this.datePag.TabIndex = 20;
            this.datePag.Visible = false;
            // 
            // dateCanc
            // 
            this.dateCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dateCanc.Location = new System.Drawing.Point(508, 473);
            this.dateCanc.Name = "dateCanc";
            this.dateCanc.Size = new System.Drawing.Size(352, 39);
            this.dateCanc.TabIndex = 22;
            this.dateCanc.Visible = false;
            // 
            // lblCanc
            // 
            this.lblCanc.AutoSize = true;
            this.lblCanc.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCanc.Location = new System.Drawing.Point(347, 478);
            this.lblCanc.Name = "lblCanc";
            this.lblCanc.Size = new System.Drawing.Size(155, 32);
            this.lblCanc.TabIndex = 21;
            this.lblCanc.Text = "Data Canc.";
            this.lblCanc.Visible = false;
            // 
            // EditarPagamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(901, 741);
            this.Controls.Add(this.dateCanc);
            this.Controls.Add(this.lblCanc);
            this.Controls.Add(this.datePag);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnclose);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.lblPag);
            this.Controls.Add(this.lblPagamento);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EditarPagamento";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "EditarPagamento";
            this.Load += new System.EventHandler(this.EditarPagamento_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnclose;
        private System.Windows.Forms.Button btnOk;
        public System.Windows.Forms.Label lblPagamento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbtnCancelado;
        private System.Windows.Forms.RadioButton rdbtnPago;
        private System.Windows.Forms.RadioButton rdbtnPendente;
        private System.Windows.Forms.Label lblPag;
        private System.Windows.Forms.DateTimePicker datePag;
        private System.Windows.Forms.DateTimePicker dateCanc;
        private System.Windows.Forms.Label lblCanc;
    }
}