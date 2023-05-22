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
        private int idPag, ccCliente, idRec;
        private double valor;
        private DateTime dataPag, dataCanc, dataVenc;
        private string estado, metodo;

        public EditarPagamento(int idPag, int ccCliente, int idRec, double Valor, string estado, DateTime dataPag, DateTime dataCanc, DateTime dataVenc, string metodo)
        {
            InitializeComponent();
            this.idPag = idPag;
            this.ccCliente = ccCliente;
            this.idRec = idRec;
            this.valor= Valor;
            this.estado = estado;
            this.dataPag = dataPag;
            this.dataCanc = dataCanc;
            this.dataVenc = dataVenc;
            this.metodo = metodo;
           
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


            if(estado == "Pago")
            {
                rdbtnPago.Checked= true;
                datePag.Visible= true;
                lblPag.Visible= true;
                datePag.Value = dataPag;
            }else if (estado == "Cancelado")
            {
                rdbtnCancelado.Checked= true;
                dateCanc.Visible= true;
                lblCanc.Visible= true;
                dateCanc.Value = dataCanc;
            }else if (estado == "Pendente")
            {
                rdbtnPendente.Checked= true;
            }

            if (metodo == "Dinheiro")
            {
                rdbtnDinheiro.Checked = true;
            }
            else if (metodo == "Transferência Bancária")
            {
                rdbtnTB.Checked = true;
            }
            else if (metodo == "Cartão de Crédito")
            {
                rdbtnCC.Checked = true;
            }

            txtValor.Text = valor.ToString();
            dateVenc.Value = dataVenc;
           


        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
