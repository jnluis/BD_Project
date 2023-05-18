namespace ProjetoBD
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            this.btnClientes = new System.Windows.Forms.Button();
            this.btnStaff = new System.Windows.Forms.Button();
            this.ClassView = new System.Windows.Forms.Button();
            this.btnPlanoT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelCargo = new System.Windows.Forms.Panel();
            this.btnCliente = new System.Windows.Forms.RadioButton();
            this.label14 = new System.Windows.Forms.Label();
            this.btnRecepcionista = new System.Windows.Forms.RadioButton();
            this.btnProfessor = new System.Windows.Forms.RadioButton();
            this.btnGerente = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.btnEntrar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panelCargo.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClientes
            // 
            this.btnClientes.Location = new System.Drawing.Point(64, 565);
            this.btnClientes.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnClientes.Name = "btnClientes";
            this.btnClientes.Size = new System.Drawing.Size(149, 105);
            this.btnClientes.TabIndex = 0;
            this.btnClientes.Text = "Clientes";
            this.btnClientes.UseVisualStyleBackColor = true;
            this.btnClientes.Click += new System.EventHandler(this.btnClientes_Click);
            // 
            // btnStaff
            // 
            this.btnStaff.Location = new System.Drawing.Point(219, 565);
            this.btnStaff.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.btnStaff.Name = "btnStaff";
            this.btnStaff.Size = new System.Drawing.Size(149, 105);
            this.btnStaff.TabIndex = 1;
            this.btnStaff.Text = "Staff";
            this.btnStaff.UseVisualStyleBackColor = true;
            this.btnStaff.Click += new System.EventHandler(this.btnStaff_Click);
            // 
            // ClassView
            // 
            this.ClassView.Location = new System.Drawing.Point(64, 686);
            this.ClassView.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.ClassView.Name = "ClassView";
            this.ClassView.Size = new System.Drawing.Size(213, 92);
            this.ClassView.TabIndex = 2;
            this.ClassView.Text = "View Classes";
            this.ClassView.UseVisualStyleBackColor = true;
            this.ClassView.Click += new System.EventHandler(this.btnClassView_Click);
            // 
            // btnPlanoT
            // 
            this.btnPlanoT.Location = new System.Drawing.Point(374, 565);
            this.btnPlanoT.Name = "btnPlanoT";
            this.btnPlanoT.Size = new System.Drawing.Size(166, 105);
            this.btnPlanoT.TabIndex = 3;
            this.btnPlanoT.Text = "Planos de Treino";
            this.btnPlanoT.UseVisualStyleBackColor = true;
            this.btnPlanoT.Click += new System.EventHandler(this.btnPlanoT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(307, 313);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 20);
            this.label1.TabIndex = 4;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(64, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(506, 247);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panelCargo
            // 
            this.panelCargo.Controls.Add(this.btnCliente);
            this.panelCargo.Controls.Add(this.label14);
            this.panelCargo.Controls.Add(this.btnRecepcionista);
            this.panelCargo.Controls.Add(this.btnProfessor);
            this.panelCargo.Controls.Add(this.btnGerente);
            this.panelCargo.Location = new System.Drawing.Point(64, 291);
            this.panelCargo.Name = "panelCargo";
            this.panelCargo.Size = new System.Drawing.Size(226, 199);
            this.panelCargo.TabIndex = 234;
            this.panelCargo.Paint += new System.Windows.Forms.PaintEventHandler(this.panelCargo_Paint);
            // 
            // btnCliente
            // 
            this.btnCliente.AutoSize = true;
            this.btnCliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCliente.Location = new System.Drawing.Point(16, 13);
            this.btnCliente.Name = "btnCliente";
            this.btnCliente.Size = new System.Drawing.Size(114, 33);
            this.btnCliente.TabIndex = 234;
            this.btnCliente.TabStop = true;
            this.btnCliente.Text = "Cliente";
            this.btnCliente.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(0, 20);
            this.label14.TabIndex = 233;
            // 
            // btnRecepcionista
            // 
            this.btnRecepcionista.AutoSize = true;
            this.btnRecepcionista.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecepcionista.Location = new System.Drawing.Point(16, 130);
            this.btnRecepcionista.Name = "btnRecepcionista";
            this.btnRecepcionista.Size = new System.Drawing.Size(191, 33);
            this.btnRecepcionista.TabIndex = 232;
            this.btnRecepcionista.TabStop = true;
            this.btnRecepcionista.Text = "Recepcionista";
            this.btnRecepcionista.UseVisualStyleBackColor = true;
            this.btnRecepcionista.CheckedChanged += new System.EventHandler(this.btnRecepcionista_CheckedChanged);
            // 
            // btnProfessor
            // 
            this.btnProfessor.AutoSize = true;
            this.btnProfessor.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProfessor.Location = new System.Drawing.Point(16, 91);
            this.btnProfessor.Name = "btnProfessor";
            this.btnProfessor.Size = new System.Drawing.Size(142, 33);
            this.btnProfessor.TabIndex = 231;
            this.btnProfessor.TabStop = true;
            this.btnProfessor.Text = "Professor";
            this.btnProfessor.UseVisualStyleBackColor = true;
            // 
            // btnGerente
            // 
            this.btnGerente.AutoSize = true;
            this.btnGerente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGerente.Location = new System.Drawing.Point(16, 52);
            this.btnGerente.Name = "btnGerente";
            this.btnGerente.Size = new System.Drawing.Size(125, 33);
            this.btnGerente.TabIndex = 230;
            this.btnGerente.TabStop = true;
            this.btnGerente.Text = "Gerente";
            this.btnGerente.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(306, 307);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 29);
            this.label2.TabIndex = 235;
            this.label2.Text = "ID:";
            // 
            // txtID
            // 
            this.txtID.BackColor = System.Drawing.Color.White;
            this.txtID.Location = new System.Drawing.Point(354, 311);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(216, 26);
            this.txtID.TabIndex = 236;
            // 
            // btnEntrar
            // 
            this.btnEntrar.BackColor = System.Drawing.Color.White;
            this.btnEntrar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEntrar.Location = new System.Drawing.Point(354, 421);
            this.btnEntrar.Name = "btnEntrar";
            this.btnEntrar.Size = new System.Drawing.Size(216, 69);
            this.btnEntrar.TabIndex = 237;
            this.btnEntrar.Text = "Entrar";
            this.btnEntrar.UseVisualStyleBackColor = false;
            this.btnEntrar.Click += new System.EventHandler(this.btnEntrar_Click);
            // 
            // MenuForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(637, 836);
            this.Controls.Add(this.btnEntrar);
            this.Controls.Add(this.txtID);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.panelCargo);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnPlanoT);
            this.Controls.Add(this.ClassView);
            this.Controls.Add(this.btnStaff);
            this.Controls.Add(this.btnClientes);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "MenuForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Power Fit";
            this.Load += new System.EventHandler(this.MenuForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panelCargo.ResumeLayout(false);
            this.panelCargo.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClientes;
        private System.Windows.Forms.Button btnStaff;
        private System.Windows.Forms.Button ClassView;
        private System.Windows.Forms.Button btnPlanoT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelCargo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.RadioButton btnRecepcionista;
        private System.Windows.Forms.RadioButton btnProfessor;
        private System.Windows.Forms.RadioButton btnGerente;
        private System.Windows.Forms.RadioButton btnCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Button btnEntrar;
    }
}