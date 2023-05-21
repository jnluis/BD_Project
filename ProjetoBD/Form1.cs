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
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        public Form1()
        {
            InitializeComponent();
        }

        private bool SaveFunc()
        {
            Staff func = new Staff();
            try
            {
                func.Salario = txtSalary.Text;
                func.NFunc = txtID_Func.Text;


                SqlCommand cmd = new SqlCommand();

                cmd.CommandText = "UPDATE Ginasio.Staff SET Salario = @salario WHERE Num_Func = @numFunc";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@salario", func.Salario);
                cmd.Parameters.AddWithValue("@numFunc", func.NFunc);

                if (verifySGBDConnection())
                {
                    try
                    {
                        cmd.Connection = cn;
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Salário atualizado com sucesso!");
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show("Ocorreu um erro ao atualizar o salário: " + ex.Message);
                    }
                    finally
                    {
                        cn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFunc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFunc();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
