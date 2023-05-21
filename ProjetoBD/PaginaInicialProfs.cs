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
    public partial class PaginaInicialProfs : Form
    {
        private SqlConnection cn;
        private int IDinical;
        private string nomeProf;
        public PaginaInicialProfs(int ID)
        {
            this.IDinical = ID;
            InitializeComponent(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void PaginaInicialProfs_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            DataTable resultado = new DataTable();

            string sql = "SELECT * FROM Ginasio.funcHorarioProfessor(@IDinical)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@IDinical", IDinical);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(resultado);

            foreach (DataRow row in resultado.Rows)
            {
                string diaSemana = row["Dia_Semana"].ToString();
                string horaInicio = row["Hora_Inicio"].ToString();
                string horaFim = row["Hora_Fim"].ToString();
                string tipo = row["Tipo"].ToString();

                // Atribuir os valores às text boxes correspondentes com base no dia da semana
                switch (diaSemana)
                {
                    case "Segunda-feira":
                        txtSegunda.Text += horaInicio + " - " + horaFim + ": " + tipo + '\n';
                        break;
                    case "Terça-feira":
                        txtTerca.Text += horaInicio + " - " + horaFim + ": " + tipo + '\n';
                        break;
                    case "Quarta-feira":
                        txtQuarta.Text += horaInicio + " - " + horaFim + ": " + tipo + '\n';
                        break;
                    case "Quinta-feira":
                        txtQuinta.Text += horaInicio + " - " + horaFim + ": " + tipo + '\n';
                        break;
                    case "Sexta-feira":
                        txtSexta.Text += horaInicio + " - " + horaFim + ": " + tipo + '\n';
                        break;
                    case "Sábado":
                        txtSabado.Text += horaInicio + " - " + horaFim + ": " + tipo + '\n';
                        break;
                }
            }
            DataTable nome = new DataTable();

            string name = "SELECT Fname, Lname FROM Ginasio.Staff WHERE Num_func = @IDinicial";
            cmd = new SqlCommand(name, cn);
            cmd.Parameters.AddWithValue("@IDinicial", IDinical);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(nome);

            foreach (DataRow row in nome.Rows)
            {
                string Fname = row["Fname"].ToString();
                string Lanme = row["Lname"].ToString();
                nomeProf = Fname + " " + Lanme;
                lblNomeProf.Text = nomeProf;
            }

            lblNum.Text = IDinical.ToString();

            cn.Close();
        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= LAPTOP-L0GR83Q7\\SQLEXPRESS;integrated security=true;initial catalog=proj"); // BD da Diana
            //return new SqlConnection("data source= LAPTOP-TN3JSRQ8\\SQLEXPRESS;integrated security=true;initial catalog=master"); // BD do João
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void txtQuarta_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAlunos_Click(object sender, EventArgs e)
        {
            this.Close();
            var UDFPlanoTreino = new UDFPlanoTreino(IDinical);
            UDFPlanoTreino.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            var AddPlanoTreino = new AddPlanoTreino(IDinical);
            AddPlanoTreino.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
            var VerFeedbackForm = new VerFeedbackForm(IDinical, nomeProf);
            VerFeedbackForm.Show();
        }
    }
}
