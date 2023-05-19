namespace ProjetoBD
{
    partial class AddPlanoTreino
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AddPlanoTreino));
            this.txtTempo = new System.Windows.Forms.TextBox();
            this.txtSeries = new System.Windows.Forms.TextBox();
            this.txtReps = new System.Windows.Forms.TextBox();
            this.lblTempo = new System.Windows.Forms.Label();
            this.lblSeries = new System.Windows.Forms.Label();
            this.lblReps = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lstboxExercicios = new System.Windows.Forms.ListBox();
            this.tabelaExercicios = new System.Windows.Forms.DataGridView();
            this.lblNTreino = new System.Windows.Forms.Label();
            this.lblNome = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnVoltar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtCCcliente = new System.Windows.Forms.TextBox();
            this.txtNtreinos = new System.Windows.Forms.TextBox();
            this.txtDataIn = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDataFim = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tabelaExercicios)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtTempo
            // 
            this.txtTempo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTempo.Location = new System.Drawing.Point(587, 925);
            this.txtTempo.Name = "txtTempo";
            this.txtTempo.Size = new System.Drawing.Size(453, 39);
            this.txtTempo.TabIndex = 45;
            this.txtTempo.Visible = false;
            // 
            // txtSeries
            // 
            this.txtSeries.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSeries.Location = new System.Drawing.Point(726, 855);
            this.txtSeries.Name = "txtSeries";
            this.txtSeries.Size = new System.Drawing.Size(314, 39);
            this.txtSeries.TabIndex = 44;
            this.txtSeries.Visible = false;
            // 
            // txtReps
            // 
            this.txtReps.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtReps.Location = new System.Drawing.Point(795, 781);
            this.txtReps.Name = "txtReps";
            this.txtReps.Size = new System.Drawing.Size(245, 39);
            this.txtReps.TabIndex = 43;
            this.txtReps.Visible = false;
            // 
            // lblTempo
            // 
            this.lblTempo.AutoSize = true;
            this.lblTempo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTempo.Location = new System.Drawing.Point(471, 928);
            this.lblTempo.Name = "lblTempo";
            this.lblTempo.Size = new System.Drawing.Size(110, 32);
            this.lblTempo.TabIndex = 42;
            this.lblTempo.Text = "Tempo:";
            this.lblTempo.Visible = false;
            // 
            // lblSeries
            // 
            this.lblSeries.AutoSize = true;
            this.lblSeries.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSeries.Location = new System.Drawing.Point(471, 858);
            this.lblSeries.Name = "lblSeries";
            this.lblSeries.Size = new System.Drawing.Size(249, 32);
            this.lblSeries.TabIndex = 41;
            this.lblSeries.Text = "Número de Séries:";
            this.lblSeries.Visible = false;
            // 
            // lblReps
            // 
            this.lblReps.AutoSize = true;
            this.lblReps.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblReps.Location = new System.Drawing.Point(471, 784);
            this.lblReps.Name = "lblReps";
            this.lblReps.Size = new System.Drawing.Size(318, 32);
            this.lblReps.TabIndex = 40;
            this.lblReps.Text = "Número de Repetiçoes: ";
            this.lblReps.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(1174, 62);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 37);
            this.label2.TabIndex = 39;
            this.label2.Text = "Exercícios:";
            this.label2.Visible = false;
            // 
            // lstboxExercicios
            // 
            this.lstboxExercicios.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstboxExercicios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstboxExercicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lstboxExercicios.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstboxExercicios.FormattingEnabled = true;
            this.lstboxExercicios.ItemHeight = 32;
            this.lstboxExercicios.Location = new System.Drawing.Point(1172, 124);
            this.lstboxExercicios.Name = "lstboxExercicios";
            this.lstboxExercicios.Size = new System.Drawing.Size(478, 896);
            this.lstboxExercicios.TabIndex = 38;
            this.lstboxExercicios.Visible = false;
            // 
            // tabelaExercicios
            // 
            this.tabelaExercicios.AllowUserToAddRows = false;
            this.tabelaExercicios.AllowUserToDeleteRows = false;
            this.tabelaExercicios.AllowUserToResizeColumns = false;
            this.tabelaExercicios.AllowUserToResizeRows = false;
            this.tabelaExercicios.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabelaExercicios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.tabelaExercicios.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.tabelaExercicios.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.tabelaExercicios.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabelaExercicios.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.tabelaExercicios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.tabelaExercicios.DefaultCellStyle = dataGridViewCellStyle4;
            this.tabelaExercicios.Location = new System.Drawing.Point(370, 338);
            this.tabelaExercicios.Name = "tabelaExercicios";
            this.tabelaExercicios.ReadOnly = true;
            this.tabelaExercicios.RowHeadersWidth = 62;
            this.tabelaExercicios.RowTemplate.Height = 28;
            this.tabelaExercicios.Size = new System.Drawing.Size(779, 411);
            this.tabelaExercicios.TabIndex = 37;
            this.tabelaExercicios.Visible = false;
            // 
            // lblNTreino
            // 
            this.lblNTreino.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNTreino.AutoSize = true;
            this.lblNTreino.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNTreino.Location = new System.Drawing.Point(363, 189);
            this.lblNTreino.Name = "lblNTreino";
            this.lblNTreino.Size = new System.Drawing.Size(379, 37);
            this.lblNTreino.TabIndex = 35;
            this.lblNTreino.Text = "N. de Treinos Semanais: ";
            // 
            // lblNome
            // 
            this.lblNome.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNome.AutoSize = true;
            this.lblNome.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNome.Location = new System.Drawing.Point(362, 106);
            this.lblNome.Name = "lblNome";
            this.lblNome.Size = new System.Drawing.Size(131, 46);
            this.lblNome.TabIndex = 32;
            this.lblNome.Text = "Nome";
            this.lblNome.Visible = false;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(362, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 46);
            this.label1.TabIndex = 30;
            this.label1.Text = "Cliente n. ";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.Controls.Add(this.btnCreate);
            this.panel1.Controls.Add(this.btnDel);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnVoltar);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Location = new System.Drawing.Point(1, -1);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 1036);
            this.panel1.TabIndex = 29;
            // 
            // btnCreate
            // 
            this.btnCreate.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCreate.Location = new System.Drawing.Point(30, 190);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(268, 55);
            this.btnCreate.TabIndex = 7;
            this.btnCreate.Text = "Criar Plano";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(30, 288);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(268, 55);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "Eliminar";
            this.btnDel.UseVisualStyleBackColor = true;
            this.btnDel.Visible = false;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(30, 190);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(268, 55);
            this.btnAdd.TabIndex = 5;
            this.btnAdd.Text = "Adicionar";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Visible = false;
            // 
            // btnVoltar
            // 
            this.btnVoltar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnVoltar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVoltar.Location = new System.Drawing.Point(30, 914);
            this.btnVoltar.Name = "btnVoltar";
            this.btnVoltar.Size = new System.Drawing.Size(268, 55);
            this.btnVoltar.TabIndex = 4;
            this.btnVoltar.Text = "Voltar";
            this.btnVoltar.UseVisualStyleBackColor = true;
            this.btnVoltar.Click += new System.EventHandler(this.btnVoltar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(332, 149);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // txtCCcliente
            // 
            this.txtCCcliente.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtCCcliente.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCCcliente.Location = new System.Drawing.Point(578, 51);
            this.txtCCcliente.Name = "txtCCcliente";
            this.txtCCcliente.Size = new System.Drawing.Size(571, 53);
            this.txtCCcliente.TabIndex = 46;
            this.txtCCcliente.TextChanged += new System.EventHandler(this.txtCCcliente_TextChanged);
            // 
            // txtNtreinos
            // 
            this.txtNtreinos.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtNtreinos.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNtreinos.Location = new System.Drawing.Point(730, 186);
            this.txtNtreinos.Name = "txtNtreinos";
            this.txtNtreinos.Size = new System.Drawing.Size(129, 44);
            this.txtNtreinos.TabIndex = 47;
            // 
            // txtDataIn
            // 
            this.txtDataIn.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDataIn.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataIn.Location = new System.Drawing.Point(546, 260);
            this.txtDataIn.Name = "txtDataIn";
            this.txtDataIn.Size = new System.Drawing.Size(216, 44);
            this.txtDataIn.TabIndex = 49;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(363, 267);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(177, 37);
            this.label3.TabIndex = 48;
            this.label3.Text = "Data Inicio:";
            // 
            // txtDataFim
            // 
            this.txtDataFim.BackColor = System.Drawing.Color.WhiteSmoke;
            this.txtDataFim.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDataFim.Location = new System.Drawing.Point(946, 260);
            this.txtDataFim.Name = "txtDataFim";
            this.txtDataFim.Size = new System.Drawing.Size(203, 44);
            this.txtDataFim.TabIndex = 51;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(783, 263);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(157, 37);
            this.label4.TabIndex = 50;
            this.label4.Text = "Data Fim:";
            // 
            // AddPlanoTreino
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1626, 1002);
            this.Controls.Add(this.txtDataFim);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDataIn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtNtreinos);
            this.Controls.Add(this.txtCCcliente);
            this.Controls.Add(this.txtTempo);
            this.Controls.Add(this.txtSeries);
            this.Controls.Add(this.txtReps);
            this.Controls.Add(this.lblTempo);
            this.Controls.Add(this.lblSeries);
            this.Controls.Add(this.lblReps);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstboxExercicios);
            this.Controls.Add(this.tabelaExercicios);
            this.Controls.Add(this.lblNTreino);
            this.Controls.Add(this.lblNome);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AddPlanoTreino";
            this.Text = "Adicionar Plano de Treino";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AddPlanoTreino_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tabelaExercicios)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTempo;
        private System.Windows.Forms.TextBox txtSeries;
        private System.Windows.Forms.TextBox txtReps;
        private System.Windows.Forms.Label lblTempo;
        private System.Windows.Forms.Label lblSeries;
        private System.Windows.Forms.Label lblReps;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lstboxExercicios;
        private System.Windows.Forms.DataGridView tabelaExercicios;
        private System.Windows.Forms.Label lblNTreino;
        private System.Windows.Forms.Label lblNome;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnVoltar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtCCcliente;
        private System.Windows.Forms.TextBox txtNtreinos;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.TextBox txtDataIn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDataFim;
        private System.Windows.Forms.Label label4;
    }
}