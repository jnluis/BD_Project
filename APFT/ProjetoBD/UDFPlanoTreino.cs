using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoBD
{
    public partial class UDFPlanoTreino : Form
    {
        private SqlConnection cn;
        private int IDinical, idade;
        private string nTreino, nomeCliente, idCliente = "";
        public static BDConnection bdConnection = new BDConnection();
        public UDFPlanoTreino(int id)
        {
            InitializeComponent();
            IDinical = id;
        }

        private void UDFPlanoTreino_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string sql = "SELECT CC_cliente FROM Ginasio.Professor JOIN Ginasio.Plano_Treino ON Ginasio.Professor.Num_func = Ginasio.Plano_Treino.ID_Professor WHERE Ginasio.Professor.Num_func = @IDinical";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@IDinical", IDinical);

            // Criar uma lista para armazenar os valores retornados
            List<int> ccClientes = new List<int>();

            // Adicionar um item vazio à lista
            ccClientes.Add(-1);

            SqlDataReader reader = cmd.ExecuteReader();

            // Ler os resultados da consulta e adicionar à lista
            while (reader.Read())
            {
                int ccCliente = reader.GetInt32(0);
                ccClientes.Add(ccCliente);
            }

            // Fechar a conexão e liberar recursos
            reader.Close();
            cn.Close();

            // Preencher a ComboBox com os valores da lista
            cBoxClientes.DataSource = ccClientes;
            cBoxClientes.DisplayMember = "CC_cliente";
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var PaginaInicialProfs = new PaginaInicialProfs(IDinical);
            PaginaInicialProfs.Show();
        }

        private void lblNTreino_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cBoxClientes_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cBoxClientes.SelectedValue != null){
                idCliente = cBoxClientes.SelectedValue.ToString();
            }


            lblNCliente.Text= idCliente;


            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            DataTable nome = new DataTable();

            string name = "SELECT Fname, Lname FROM Ginasio.Cliente WHERE CC = @idCliente";
            SqlCommand cmd = new SqlCommand(name, cn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(nome);

            foreach (DataRow row in nome.Rows)
            {
                string Fname = row["Fname"].ToString();
                string Lanme = row["Lname"].ToString();
                nomeCliente = Fname + " " + Lanme;
                lblNome.Text = nomeCliente;
            }

            string queryAnoNasc = "SELECT YEAR(Data_Nasc) AS Ano FROM Ginasio.Cliente WHERE CC = @idCliente";
            cmd = new SqlCommand(queryAnoNasc, cn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            int anoNasc = 0;
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                if (reader.Read())
                {
                    if (!reader.IsDBNull(0))
                    {
                        anoNasc = reader.GetInt32(0);
                    }
                }
            }

            if (anoNasc != 0)
            {
                int anoAtual = DateTime.Now.Year;
                idade = anoAtual - anoNasc;

                lblAge.Text = idade.ToString();
            }

            string dados = "SELECT * FROM Ginasio.funcPlanoTreinoCliente(@idCliente)";
            cmd = new SqlCommand(dados , cn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            DataTable dt = new DataTable();

            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            tabelaExercicios.DataSource = dt;
            tabelaExercicios.Visible = true;


            string Ntreinos = "select Num_Treinos_Semanais from Ginasio.Plano_Treino where CC_Cliente = @idCliente";
            cmd = new SqlCommand(Ntreinos, cn);
            cmd.Parameters.AddWithValue("@idCliente", idCliente);

            SqlDataReader read = cmd.ExecuteReader();
            if (read.Read())
            {
                nTreino = read["Num_Treinos_Semanais"].ToString();
                lblNTreino.Text = nTreino;
            }


            cn.Close();

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            this.Close();
            var EditarPlanoTreino = new EditarPlanoTreino(nomeCliente, idCliente, nTreino, idade, IDinical);
            EditarPlanoTreino.Show();
        }
    }
}
