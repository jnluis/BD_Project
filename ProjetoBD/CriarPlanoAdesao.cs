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
    public partial class CriarPlanoAdesao : Form
    {
        private int idRec;
        private SqlConnection cn;

        public CriarPlanoAdesao(int idRec)
        {
            InitializeComponent();
            this.idRec = idRec;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var paginaInicialRececionistas = new PaginaInicialRececionistas(idRec);
            paginaInicialRececionistas.Show();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            if (!verifySGBDConnection())
                return;

            string cc = txtCC.Text;
            DateTime dataInicio = dateTPInicio.Value.Date;
            DateTime dateFim = dateTPInicio.Value.Date;
            string tipo = null;
            string preco = null;

            if (rdAnual.Checked)
            {
                tipo = "Anual";
                preco = "360";
            }
            else if (rdSemestral.Checked)
            {
                tipo = "Semestral";
                preco = "180";
            }
            else if (RdMensal.Checked)
            {
                tipo = "Mensal";
                preco = "30";
            }

            try
            {
                if (cc.Length > 0 && dataInicio != null && dateFim != null && tipo != null && preco != null)
                {
                    SqlCommand cmd = new SqlCommand();

                    cmd.CommandText = "INSERT INTO Ginasio.Plano_Adesao (Tipo, CC_Cliente, Preco, Data_Fim, Data_Inicio, Num_Rec) " + "VALUES (@tipo, @cc, @preco, @dataFim, @dataInicio, @numRec)";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@tipo", tipo);
                    cmd.Parameters.AddWithValue("@cc", cc);
                    cmd.Parameters.AddWithValue("@preco", preco);
                    cmd.Parameters.AddWithValue("@dataFim", dateFim);
                    cmd.Parameters.AddWithValue("@dataInicio", dataInicio);
                    cmd.Parameters.AddWithValue("@numRec", idRec);

                    if (verifySGBDConnection())
                    {
                        try
                        {
                            cmd.Connection = cn;
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Plano de Adesão criado com sucesso!");
                        }
                        catch (SqlException ex)
                        {
                            MessageBox.Show("Ocorreu um erro ao inserir o cliente: " + ex.Message);
                        }
                        finally
                        {
                            cn.Close();
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("ERRO: " + ex.Message);
            }

            txtCC.Text = "";
       
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

        private void CriarPlanoAdesao_Load(object sender, EventArgs e)
        {
        }

        private void rdSemestral_CheckedChanged(object sender, EventArgs e)
        {
            lblPreco.Text = "180";
        }

        private void RdMensal_CheckedChanged(object sender, EventArgs e)
        {
            lblPreco.Text = "30";
        }

        private void rdAnual_CheckedChanged(object sender, EventArgs e)
        {
            lblPreco.Text = "360";
        }

        private void txtCC_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
