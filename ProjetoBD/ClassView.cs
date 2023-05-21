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

        public ClassView()
        {
            InitializeComponent();
        }

        private void ClassView_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

           string dados= ("SELECT * FROM Ginasio.Salas_AND_Aulas_VIEW ORDER BY [Número da Sala], CASE [Dia da semana] WHEN 'Segunda-feira' THEN 1 WHEN 'Terça-feira' THEN 2 WHEN 'Quarta-feira' THEN 3 WHEN 'Quinta-feira' THEN 4 WHEN 'Sexta-feira' THEN 5 WHEN 'Sábado' THEN 6 WHEN 'Domingo' THEN 7 ELSE 8 END");

            SqlCommand cmd = new SqlCommand(dados, cn);

            DataTable dt = new DataTable();

            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            tabelaClassView.DataSource = dt;
            tabelaClassView.Visible = true;

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
            // deixei aqui dependendo para onde queremos ligar isto
            //var MenuInicial = new MenuForm();
            //MenuInicial.Show();
        }
    }



}
