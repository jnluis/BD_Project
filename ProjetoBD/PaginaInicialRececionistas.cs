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
using static System.Net.Mime.MediaTypeNames;

namespace ProjetoBD
{
    public partial class PaginaInicialRececionistas : Form
    {
        private int idRec;
        private string nomeRec;
        private SqlConnection cn;
        public PaginaInicialRececionistas(int idRec)
        {
            InitializeComponent();
            this.idRec = idRec;
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            {
                this.Close();
                var VerClientesForm = new VerClientesForm(idRec);
                VerClientesForm.Show();
            }
        }

        private void PaginaInicialRececionistas_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;


            lblNum.Text = idRec.ToString();

            DataTable nome = new DataTable();

            string name = "SELECT Fname, Lname FROM Ginasio.Staff WHERE Num_func = @IDinicial";
            SqlCommand cmd = new SqlCommand(name, cn);
            cmd.Parameters.AddWithValue("@IDinicial", idRec);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(nome);

            foreach (DataRow row in nome.Rows)
            {
                string Fname = row["Fname"].ToString();
                string Lanme = row["Lname"].ToString();
                nomeRec = Fname + " " + Lanme;
                lblNome.Text = nomeRec;
            }

            string dados = "Select * From Ginasio.Plano_Adesao Where Num_Rec = @numFunc";
            cmd = new SqlCommand(dados, cn);
            cmd.Parameters.AddWithValue("@numFunc", idRec);

            DataTable dt = new DataTable();

            adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            tabelaPlanosAdesao.DataSource = dt;
            tabelaPlanosAdesao.Visible = true;

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

        private void tabelaPlanosAdesao_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnPagamentos_Click(object sender, EventArgs e)
        {
            this.Close();
            var pagamentos = new Pagamentos(idRec);
            pagamentos.Show();
        }

        private void btnCriarPA_Click(object sender, EventArgs e)
        {
            this.Close();
            var CriarPA = new CriarPlanoAdesao(idRec);
            CriarPA.Show();
        }

        private void btnAulas_Click(object sender, EventArgs e)
        {
            this.Close();
            var ClassView = new ClassView(idRec);
            ClassView.Show();
        }
    }
}