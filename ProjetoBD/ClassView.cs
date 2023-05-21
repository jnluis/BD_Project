using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBD
{
    public partial class ClassView : Form
    {

        private SqlConnection cn;
        private int currentClient;
        private bool adding;

        public ClassView()
        {
            InitializeComponent();
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ginasio.Salas_AND_Aulas_VIEW ORDER BY Sala_ID, CASE Dia_Semana WHEN 'Segunda-feira' THEN 1 WHEN 'Terça-feira' THEN 2 WHEN 'Quarta-feira' THEN 3 WHEN 'Quinta-feira' THEN 4 WHEN 'Sexta-feira' THEN 5 WHEN 'Sábado' THEN 6 WHEN 'Domingo' THEN 7 ELSE 8 END", cn);

            SqlDataReader reader = cmd.ExecuteReader();



            while (reader.Read())
            {
                Cliente C = new Cliente();
                {
                    C.CC = reader["Sala_ID"].ToString();
                    C.Fname = reader["Fname"].ToString();
                    C.Lname = reader["Lname"].ToString();
                    C.Email = reader["Hora_Inicio"].ToString();
                    C.NIF = reader["Hora_Fim"].ToString();
                    C.Morada = reader["Dia_Semana"].ToString();
                    C.Data_Nasc = reader["Tipo"].ToString();
                    C.Telemovel = reader["Num_Max_alunos"].ToString();
                    //totalItems++;

                    Label labelSala_ID = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.CC,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelSala_ID);

                    Label labelTipo_Aula = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.Data_Nasc,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelTipo_Aula);

                    Label labelMax_Alunos = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.Telemovel,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelMax_Alunos);

                    Label labelHora_inicio = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.Email,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelHora_inicio);

                    Label labelHora_fim = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.NIF,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelHora_fim);

                    Label labelDia_Semana = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.Morada,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelDia_Semana);

                    Label labelF_Name = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.Fname,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelF_Name);

                    Label labelL_Name = new Label
                    {
                        Font = new Font("Verdana", 9),
                        Text = C.Lname,
                        ForeColor = Color.Black,
                        AutoSize = true
                    };
                    tableLayoutPanel1.Controls.Add(labelL_Name);



                };

            }

            currentClient = 0;
            ShowClient();
            cn.Close();

        }

        private SqlConnection getSGBDConnection()
        {
            //return new SqlConnection("data source= LAPTOP-L0GR83Q7\\SQLEXPRESS;integrated security=true;initial catalog=proj"); // BD da Diana
            return new SqlConnection("data source= LAPTOP-TN3JSRQ8\\SQLEXPRESS;integrated security=true;initial catalog=master"); // BD do João
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        public void LockControls()
        {
            txtCC.ReadOnly = true;
            txtFname.ReadOnly = true;
            txtLname.ReadOnly = true;
            txtMorada.ReadOnly = true;
            txtDataNasc.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTel.ReadOnly = true;
            txtNIF.ReadOnly = true;

        }
        public void UnlockControls()
        {
            txtCC.ReadOnly = false;
            txtFname.ReadOnly = false;
            txtLname.ReadOnly = false;
            txtMorada.ReadOnly = false;
            txtDataNasc.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtNIF.ReadOnly = false;

        }

        public void ClearFields()
        {
            txtCC.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtMorada.Text = "";
            txtDataNasc.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtNIF.Text = "";
        }

        public void ShowButtons()
        {
            LockControls(); 
        }
        public void HideButtons()
        {
            UnlockControls();
        }

        public void ShowClient()
        {
            Cliente cliente = new Cliente();
            txtCC.Text = cliente.CC;
            txtFname.Text = cliente.Fname;
            txtLname.Text = cliente.Lname;
            txtMorada.Text = cliente.Morada;
            txtDataNasc.Text = cliente.Data_Nasc;
            txtTel.Text = cliente.Telemovel;
            txtEmail.Text = cliente.Email;
            txtNIF.Text = cliente.NIF;

        }



        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void Label7_Click(object sender, EventArgs e)
        {

        }

        private void Label5_Click(object sender, EventArgs e)
        {

        }

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDataNasc_TextChanged(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtCC_TextChanged(object sender, EventArgs e)
        {

        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }



}
