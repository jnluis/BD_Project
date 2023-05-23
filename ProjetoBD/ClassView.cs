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
        private int id;
        private string idAula;

        public ClassView(int id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            AtualizarDados();
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




        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
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

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var PaginaInicialRececionistas = new PaginaInicialRececionistas(id);
            PaginaInicialRececionistas.Show();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabelaClassView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnInscreve.Visible = true;

            if (e.RowIndex >= 0) // Verifica se uma linha válida foi selecionada
            {
                DataGridViewRow row = tabelaClassView.Rows[e.RowIndex];

                idAula = row.Cells["Nº da Aula"].Value.ToString();

            }

            
        }

        private void btnInscreve_Click(object sender, EventArgs e)
        {
            
            var InscreverAula = new InscreverAula(int.Parse(idAula));
            InscreverAula.FormClosed += Edit_FormClosed;
            InscreverAula.Show();

           
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            AtualizarDados();
        }

        private void AtualizarDados()
        {
            btnInscreve.Visible = false;
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string dados = ("SELECT * FROM Ginasio.Salas_AND_Aulas_VIEW ORDER BY [Número da Sala], CASE [Dia da semana] WHEN 'Segunda-feira' THEN 1 WHEN 'Terça-feira' THEN 2 WHEN 'Quarta-feira' THEN 3 WHEN 'Quinta-feira' THEN 4 WHEN 'Sexta-feira' THEN 5 WHEN 'Sábado' THEN 6 WHEN 'Domingo' THEN 7 ELSE 8 END");

            SqlCommand cmd = new SqlCommand(dados, cn);

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            tabelaClassView.DataSource = dt;
            tabelaClassView.Visible = true;

            cn.Close();
        }



    }
}
