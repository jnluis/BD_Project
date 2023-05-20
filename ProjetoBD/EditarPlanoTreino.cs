using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBD
{
    public partial class EditarPlanoTreino : Form
    {
        private string nome, numT, id;
        private int idade, idProf;
        private SqlConnection cn;
        private string nomeEXdel;

        private void tabelaExercicios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnDel.Visible = true;

            if (e.RowIndex >= 0) // Verifica se uma linha válida foi selecionada
            {
                DataGridViewRow row = tabelaExercicios.Rows[e.RowIndex];

                nomeEXdel = row.Cells["Exercicio"].Value.ToString();


            }
        }


        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var UDFPlanoTreino = new UDFPlanoTreino(idProf);
            UDFPlanoTreino.Show();
        }

        public EditarPlanoTreino(string nome, string id, string nTreinos, int idade, int idProf)
        {
            InitializeComponent();
            this.nome = nome;
            this.id = id;
            this.idade = idade;
            this.numT = nTreinos;
            this.idProf = idProf;
        }

        private void lstboxExercicios_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            lblReps.Visible = true;
            lblSeries.Visible = true;
            lblTempo.Visible = true;
            txtReps.Visible = true;
            txtSeries.Visible = true;
            txtTempo.Visible = true;
            btnDel.Visible = false;


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            object selectedItem = lstboxExercicios.SelectedItem;
            if (selectedItem != null)
            {
                string exercicio = selectedItem.ToString();

                if ((txtTempo.Text != "" && txtSeries.Text != "") || (txtReps.Text != "" && txtSeries.Text != ""))
                {
                    string spName = "Ginasio.InserirExercicioNumPlanoTreino";
                    SqlCommand command = new SqlCommand(spName, cn);
                    command.CommandType = CommandType.StoredProcedure;

                    command.Parameters.AddWithValue("@Nome", exercicio);
                    if(txtReps.Text == null)
                    {
                        command.Parameters.AddWithValue("@Tempo", null);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Tempo", txtTempo.Text.ToString());
                    }
                    command.Parameters.AddWithValue("@Num_Series", txtSeries.Text.ToString());
                    if (txtReps.Text == null)
                    {
                        command.Parameters.AddWithValue("@Num_Reps", null);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@Num_Reps", txtReps.Text.ToString());
                    }
                    command.Parameters.AddWithValue("@idCliente", id);

                    command.ExecuteNonQuery(); // Executar a stored procedure

                    cn.Close();

                }
                else
                {
                    MessageBox.Show("EERO: Tem de preencher o numéro de vezes que é para fazer o exercício.");
                }

            }

            AtualizarComponentes();
        }

        private void EditarPlanoTreino_Load(object sender, EventArgs e)
        {

            AtualizarComponentes();

        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string spName = "Ginasio.EliminarExercicioNumPlanoTreino";
            SqlCommand command = new SqlCommand(spName, cn);
            command.CommandType = CommandType.StoredProcedure;
            command.Parameters.AddWithValue("@Nome", nomeEXdel);
            command.Parameters.AddWithValue("@idCliente", id);

            command.ExecuteNonQuery(); // Executar a stored procedure

            cn.Close();

            AtualizarComponentes();


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

        private void AtualizarComponentes()
        {
            btnAdd.Visible = false;
            lblReps.Visible = false;
            lblSeries.Visible = false;
            lblTempo.Visible = false;
            txtReps.Visible = false;
            txtSeries.Visible = false;
            txtTempo.Visible = false;
            btnDel.Visible = false;

            txtReps.Text = "";
            txtSeries.Text = "";
            txtTempo.Text = "";



            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            DataTable dt = new DataTable();

            lblAge.Text = idade.ToString();
            lblNCliente.Text = id;
            MessageBox.Show(nome);
            lblNome.Text = nome;
            lblNTreino.Text = numT.ToString();

            string dados = "SELECT * FROM Ginasio.funcPlanoTreinoCliente(@idCliente)";

            SqlCommand cmd = new SqlCommand(dados, cn);
            cmd.Parameters.AddWithValue("@idCliente", id);

            SqlDataAdapter adapter = new SqlDataAdapter();
            adapter.SelectCommand = cmd;

            adapter.Fill(dt);
            tabelaExercicios.DataSource = dt;
            tabelaExercicios.Visible = true;

            DataTable resultado = new DataTable();

            string exercicios = "SELECT Nome FROM Ginasio.Exercicio ORDER BY Nome";
            cmd = new SqlCommand(exercicios, cn);
            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(resultado);

            lstboxExercicios.Items.Clear(); // Limpar itens existentes na ListBox

            foreach (DataRow row in resultado.Rows)
            {
                string exercicio = row["Nome"].ToString();
                lstboxExercicios.Items.Add(exercicio);
            }

            cn.Close();
        }
    }
}
