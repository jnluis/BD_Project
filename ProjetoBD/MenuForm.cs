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
using System.Diagnostics;

namespace ProjetoBD
{
    public partial class MenuForm : Form
    {
        private SqlConnection cn;
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            // Abrir a janela ou formulário de clientes
            var TestForm = new Form1();
            TestForm.Show();
        }

        private void btnClassView_Click(object sender, EventArgs e)
        {
            var classView = new ClassView();
            classView.Show();
        }

        private void MenuForm_Load(object sender, EventArgs e)
        {

        }

        private void btnPlanoT_Click(object sender, EventArgs e)
        {
            var UDFPlanoTreino = new UDFPlanoTreino(1004);
            UDFPlanoTreino.Show();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panelCargo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnRecepcionista_CheckedChanged(object sender, EventArgs e)
        {

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
        private void btnEntrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtID.Text))
            {
                MessageBox.Show("Não inseriu nenhum ID", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int ID = int.Parse(txtID.Text);
            
         

            cn = getSGBDConnection();

            if (!verifySGBDConnection())
                return;
            using (cn)
            {
                if (btnRecepcionista.Checked)
                {
                    var paginaInicialRececionistas = new PaginaInicialRececionistas(ID);
                    paginaInicialRececionistas.Show();

                }
                else if (btnCliente.Checked)
                {
                    SqlCommand command = new SqlCommand("Ginasio.CheckIDExists", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@IsClient", 1);
                    int result = (int)command.ExecuteScalar();
                    Boolean validation = Convert.ToBoolean(result);
                    try
                    {

                        if (!validation)
                        {
                            var PaginaInicialClientes = new PaginaInicialClientes(ID);
                            PaginaInicialClientes.Show();
                        }
                        else
                        {
                            MessageBox.Show("Insira um ID de um cliente registado no ginásio", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Falha na SP CheckIDExists. \n MENSAGEM DE ERRO: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
                else if (btnGerente.Checked)
                {

                }
                else if (btnProfessor.Checked)
                {
                    SqlCommand command = new SqlCommand("Ginasio.CheckIDExists", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@IsClient", 0); // Esta verficação é um bit para dizer quando é cliente ou não
                    int result = (int)command.ExecuteScalar();
                    Boolean validation = Convert.ToBoolean(result);
                    try
                    {

                        if (!validation)
                        {
                            var PaginaInicialProfs = new PaginaInicialProfs(ID);
                            PaginaInicialProfs.Show();
                        }
                        else
                        {
                            MessageBox.Show("Insira um ID de um professor existente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Falha na SP CheckIDExists. \n MENSAGEM DE ERRO: \n" + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }
            }
        }
    }
}
