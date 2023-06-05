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
using System.Data.Common;

namespace ProjetoBD
{
    public partial class MenuForm : Form
    {
        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
        }

        private void btnClassView_Click(object sender, EventArgs e)
        {
           
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
            return bdConnection.getSGBDConnection();
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
                    SqlCommand command = new SqlCommand("Ginasio.CheckIDExists", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@IsClient", 4);
                    int result = (int)command.ExecuteScalar();
                    Boolean validation = Convert.ToBoolean(result);
                    try
                    {

                        if (!validation)
                        {
                            var paginaInicialRececionistas = new PaginaInicialRececionistas(ID);
                            paginaInicialRececionistas.Show();
                        }
                        else
                        {
                            MessageBox.Show("Insira um ID de um rececionista existeste", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    SqlCommand command = new SqlCommand("Ginasio.CheckIDExists", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@IsClient", 3);
                    int result = (int)command.ExecuteScalar();
                    Boolean validation = Convert.ToBoolean(result);
                    try
                    {

                        if (!validation)
                        {
                            var paginaInicialGerentes = new PaginaInicialGerente(ID);
                            paginaInicialGerentes.Show();
                        }
                        else
                        {
                            MessageBox.Show("Insira um ID válido para o gerente", "ERRO", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                else if (btnProfessor.Checked)
                {
                    SqlCommand command = new SqlCommand("Ginasio.CheckIDExists", cn);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.Clear();
                    command.Parameters.AddWithValue("@ID", ID);
                    command.Parameters.AddWithValue("@IsClient", 2); // Esta verficação é um TINYINT para dizer quando é cliente ou os outros tipos
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
