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
    public partial class InscreverAula : Form
    {

        private int idAula;
        private SqlConnection cn;
        public InscreverAula(int idAula)
        {
            InitializeComponent();
            this.idAula = idAula;
        }

        private void InscreverAula_Load(object sender, EventArgs e)
        {
            lblAula.Text = idAula.ToString();
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

        private void btnOk_Click(object sender, EventArgs e)
        {


            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;
            
            string estado = txtEstado.Text;
            string cc = txtCC.Text;
            if (estado != null && cc != null)
            {
                try
                {
                    string sqlInsert = "INSERT INTO Ginasio.Inscreve (ID_HAula, CC_Cliente, Estado) VALUES (@nAula, @cc, @estado)";

                    using (SqlCommand command = new SqlCommand(sqlInsert, cn))
                    {
                        command.Parameters.AddWithValue("@nAula", idAula);
                        command.Parameters.AddWithValue("@cc", cc);
                        command.Parameters.AddWithValue("@estado", estado);

                        command.ExecuteNonQuery();

                        txtCC.Text = "";
                        txtEstado.Text = "";
                    }

                    MessageBox.Show("Inscrição feita com sucesso!");
                }
                catch (Exception ex)
                {
                    string mensagem = ex.Message;
                    MessageBox.Show("Ocorreu um erro: " + mensagem, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

            this.Close();

        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }


 

}
