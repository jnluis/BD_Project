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

namespace ProjetoBD
{
    public partial class AddPlanoTreino : Form
    {
        private int IDProf;
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

                            cn.Close();
                        }
                        else
                        {
                            MessageBox.Show("Esse cliente não existe.");
                        }
                    }
                }
                catch (SqlException ex)
                {
                    // Exibir a mensagem do trigger em um MessageBox
                    MessageBox.Show("ERRO: " + ex.Message);
                }
            }

        }


    }
}
