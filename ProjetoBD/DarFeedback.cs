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
    public partial class DarFeedback : Form
    {
        private SqlConnection cn;
        private int CC_Cliente;
        private string nomeCliente;
        public static BDConnection bdConnection = new BDConnection();

        public DarFeedback(int cc, string nome)
        {
            this.CC_Cliente = cc;
            this.nomeCliente = nome;
            InitializeComponent();
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
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string idProf = txtNProf.Text;

            SqlCommand command = new SqlCommand("Ginasio.CheckIDExists", cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.Clear();
            command.Parameters.AddWithValue("@ID", idProf);
            command.Parameters.AddWithValue("@IsClient", 2);
            int result = (int)command.ExecuteScalar();
            Boolean validation = Convert.ToBoolean(result);
            try
            {

                if (!validation)
                {
                    if(!string.IsNullOrEmpty(txtFeedback.Text.Trim()))
                    {
                        DateTime dataAtual = DateTime.Now;

                        string insert = "INSERT INTO Ginasio.Feedback(CC_Cliente, ID_Professor, Comentários, Data) Values (@cc, @idProf, @comment, @data)";
                        command = new SqlCommand(insert, cn);

                        command.Parameters.AddWithValue("@cc", CC_Cliente);
                        command.Parameters.AddWithValue("@idProf", idProf);
                        command.Parameters.AddWithValue("@comment", txtFeedback.Text);
                        command.Parameters.AddWithValue("@data", dataAtual);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Feedback adicionado com sucesso!");
                    }
                    else
                    {
                        MessageBox.Show("Escreve um feedback!");
                    }
                }
                else
                {
                    MessageBox.Show("Insira um ID de um professor existente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Falha na SP CheckProfessorIDExists. \n MENSAGEM DE ERRO: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            txtFeedback.Text = "";
            txtNProf.Text = "";
        }

        private void DarFeedback_Load(object sender, EventArgs e)
        {
            lblNomeProf.Text = nomeCliente;
            lblNum.Text = CC_Cliente.ToString();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var PaginaInicialClientes = new PaginaInicialClientes(CC_Cliente);
            PaginaInicialClientes.Show();
        }
    }
}
