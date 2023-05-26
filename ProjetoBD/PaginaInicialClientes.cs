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
    public partial class PaginaInicialClientes : Form
    {
        private SqlConnection cn;
        private int CC_Cliente;
        private string nomeCliente;
        public static BDConnection bdConnection = new BDConnection();

        public PaginaInicialClientes(int cc)
        {
            this.CC_Cliente = cc;
            InitializeComponent();
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void PaginaIncialClientes_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            DataTable resultado = new DataTable();

            string sql = "SELECT * FROM Ginasio.funcAulasInscritas(@ccCliente)";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@ccCliente", CC_Cliente);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(resultado);

            foreach (DataRow row in resultado.Rows)
            {
                string aula = row["Aula"].ToString();
                string diaSemana = row["Dia_Semana"].ToString();
                string horaInicio = row["Hora_Inicio"].ToString();
                string horaFim = row["Hora_Fim"].ToString();
                string estado = row["Estado"].ToString();

                // Atribuir os valores às text boxes correspondentes com base no dia da semana
                switch (diaSemana)
                {
                    case "Segunda-feira":
                        txtSegunda.Text += horaInicio + " - " + horaFim + ": " + aula + "(" + estado + ")" + '\n';
                        break;
                    case "Terça-feira":
                        txtTerca.Text += horaInicio + " - " + horaFim + ": " + aula + "(" + estado + ")" + '\n';
                        break;
                    case "Quarta-feira":
                        txtQuarta.Text += horaInicio + " - " + horaFim + ": " + aula + "(" + estado + ")" + '\n';
                        break;
                    case "Quinta-feira":
                        txtQuinta.Text += horaInicio + " - " + horaFim + ": " + aula + "(" + estado + ")" + '\n';
                        break;
                    case "Sexta-feira":
                        txtSexta.Text += horaInicio + " - " + horaFim + ": " + aula + "(" + estado + ")" + '\n';
                        break;
                    case "Sábado":
                        txtSabado.Text += horaInicio + " - " + horaFim + ": " + aula + "(" + estado + ")" + '\n';
                        break;
                }
            }
            DataTable nome = new DataTable();

            string name = "SELECT Fname, Lname FROM Ginasio.Cliente WHERE CC = @ccCliente";
            cmd = new SqlCommand(name, cn);
            cmd.Parameters.AddWithValue("@ccCliente", CC_Cliente);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(nome);

            foreach (DataRow row in nome.Rows)
            {
                string Fname = row["Fname"].ToString();
                string Lanme = row["Lname"].ToString();
                nomeCliente = Fname + " " + Lanme;
                lblNomeProf.Text = nomeCliente;
            }

            lblNum.Text = CC_Cliente.ToString();

            cn.Close();
        }

        private SqlConnection getSGBDConnection()
        {
            return bdConnection.getSGBDConnection();
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void btnFeedback_Click(object sender, EventArgs e)
        {
            this.Close();
            var DarFeedback = new DarFeedback(CC_Cliente, nomeCliente);
            DarFeedback.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            var VerPlanoTreino = new VerPlanoTreino(CC_Cliente, nomeCliente);
            VerPlanoTreino.Show();
        }
    }
}
