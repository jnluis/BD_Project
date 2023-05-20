using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace ProjetoBD
{
    public partial class AddPlanoTreino : Form
    {
        private int IDProf, idade;
        private string nTreinos, nomeCliente, IDCliente;
        private SqlConnection cn;

        public AddPlanoTreino(int idProf)
        {
            InitializeComponent();
            IDProf = idProf;

        }

        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= LAPTOP-L0GR83Q7\\SQLEXPRESS;integrated security=true;initial catalog=proj"); // BD da Diana
            //return new SqlConnection("data source= LAPTOP-TN3JSRQ8\\SQLEXPRESS;integrated security=true;initial catalog=master"); // BD do João
        }

        private void txtCCcliente_TextChanged(object sender, EventArgs e)
        {


            
        }

        private void AddPlanoTreino_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var UDFPlanoTreino = new UDFPlanoTreino(IDProf);
            UDFPlanoTreino.Show();
        }

        private void tabelaExercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

            if(txtCCcliente.Text != null && txtNtreinos.Text != null && txtDataIn.Text != null)
            {
                cn = getSGBDConnection();
                if (!verifySGBDConnection())
                    return;

                DataTable nome = new DataTable();
                IDCliente = txtCCcliente.Text;

                string cliente = "Select Fname, Lname From Ginasio.Cliente Where CC = @ccCliente";
                SqlCommand cmd = new SqlCommand(cliente, cn);
                cmd.Parameters.AddWithValue("@ccCliente", IDCliente);
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(nome);

                try
                {
                    foreach (DataRow row in nome.Rows)
                    {
                        string Fname = row["Fname"].ToString();
                        string Lname = row["Lname"].ToString();

                        if (Fname.Length > 0 && Lname.Length > 0)
                        {
                            nomeCliente = Fname + " " + Lname;
                            lblNome.Visible = true;
                            lblNome.Text = nomeCliente;

                            string dataIn = txtDataIn.Text;
                            string dataFim = txtDataFim.Text;
                            nTreinos = txtNtreinos.Text;

                            string maxID = "SELECT MAX(ID) FROM Ginasio.Plano_Treino";
                            cmd = new SqlCommand(maxID, cn);
                            int IDmax = (int)cmd.ExecuteScalar();

                            string plano = "INSERT INTO Ginasio.Plano_Treino(ID, Data_Inicio, Data_Fim, Num_Treinos_Semanais, ID_Professor, CC_Cliente) VALUES (@ID, @DataIn, @DataFim, @nTreinos, @idProf, @idCliente)";
                            cmd = new SqlCommand(plano, cn);

                            cmd.Parameters.AddWithValue("@ID", IDmax + 1);
                            cmd.Parameters.AddWithValue("@DataIn", dataIn);
                            cmd.Parameters.AddWithValue("@DataFim", dataFim);
                            cmd.Parameters.AddWithValue("@nTreinos", nTreinos);
                            cmd.Parameters.AddWithValue("@idProf", IDProf);
                            cmd.Parameters.AddWithValue("@idCliente", IDCliente);

                            // Execute o comando SQL
                            cmd.ExecuteNonQuery();

                            string queryAnoNasc = "SELECT YEAR(Data_Nasc) AS Ano FROM Ginasio.Cliente WHERE CC = @idCliente";
                            cmd = new SqlCommand(queryAnoNasc, cn);
                            cmd.Parameters.AddWithValue("@idCliente", IDCliente);

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
                            }


                            this.Close();
                            var EditarPlanoTreino = new EditarPlanoTreino(nomeCliente, IDCliente, nTreinos, idade, IDProf);
                            EditarPlanoTreino.Show();
                        }
                        else
                        {
                            MessageBox.Show("Esse cliente não existe.");
                        }

                        cn.Close();
                    }

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("ERRO: " + ex.Message);
                }
            }

        }


    }
}
