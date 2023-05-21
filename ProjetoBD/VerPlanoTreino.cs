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
    public partial class VerPlanoTreino : Form
    {
        private SqlConnection cn;
        private int idCliente, idade;
        private string nTreino, nomeCliente;
        public VerPlanoTreino(int idCliente, string nome)
        {
            InitializeComponent();
            this.idCliente = idCliente;
            this.nomeCliente = nome;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void VerPlanoTreino_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            lblNomeProf.Text = nomeCliente;
            lblNum.Text = idCliente.ToString();


            string dados = "SELECT * FROM Ginasio.funcPlanoTreinoCliente(@idCliente)";
            SqlCommand cmd = new SqlCommand(dados, cn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            tabelaExercicios.DataSource = dt;
            tabelaExercicios.Visible = true;

            cn.Close();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var PaginaInicialClientes = new PaginaInicialClientes(idCliente);
            PaginaInicialClientes.Show();
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
    }
}