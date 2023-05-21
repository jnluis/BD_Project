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
    public partial class EditarPagamento : Form
    {
        private SqlConnection cn;
        private int idPag;
        public EditarPagamento(int idPag)
        {
            InitializeComponent();
            this.idPag = idPag;
        }

        private void lblAula_Click(object sender, EventArgs e)
        {

        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            lblPag.Visible = false;
            datePag.Visible = false;
            lblCanc.Visible = true;
            dateCanc.Visible = true;
        }

        private void rdbtnPago_CheckedChanged(object sender, EventArgs e)
        {
            lblPag.Visible = true;
            datePag.Visible = true;
            lblCanc.Visible = false;
            dateCanc.Visible = false;
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void rdbtnPendente_CheckedChanged(object sender, EventArgs e)
        {
            lblPag.Visible = false;
            datePag.Visible = false;
            lblCanc.Visible = false;
            dateCanc.Visible = false;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string estado = "";
            DateTime? data = null;

            if (rdbtnCancelado.Checked)
            {
                estado = "Cancelado";
                data = dateCanc.Value.Date;
            }else if (rdbtnPago.Checked){
                estado = "Pago";
                data = datePag.Value.Date;
            }else if (rdbtnPendente.Checked)
            {
                estado = "Pendente";
            }

            string query = "UPDATE Ginasio.Pagamento SET Estado = @estado, Data_Pagamento = @dataPag, Data_canc = @dataCanc WHERE ID = @idPag";
            using (SqlCommand command = new SqlCommand(query, cn))
            {
                command.Parameters.AddWithValue("@estado", estado);
                command.Parameters.AddWithValue("@dataPag", data);
                command.Parameters.AddWithValue("@dataCanc", data);
                command.Parameters.AddWithValue("@idPag", idPag);

                int rowsAffected = command.ExecuteNonQuery();

                if (rowsAffected > 0)
                {
                    MessageBox.Show("Update Ok");
                }
                else
                {
                    MessageBox.Show("Update falhou");
                }
            }

            this.Close();

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

        private void EditarPagamento_Load(object sender, EventArgs e)
        {
            lblPagamento.Text = idPag.ToString();
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
