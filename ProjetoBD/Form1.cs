using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Net.NetworkInformation;

namespace ProjetoBD
{
    public partial class Form1 : Form
    {
        private SqlConnection cn;
        private int currentClient;
        private bool adding;

        public Form1()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ginasio.Cliente", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Cliente C = new Cliente();
                C.CC = reader["CC"].ToString();
                C.Fname = reader["Fname"].ToString();
                C.Lname = reader["Lname"].ToString();
                C.Email = reader["Email"].ToString();
                C.NIF = reader["NIF"].ToString();
                C.Morada = reader["Morada"].ToString();
                C.Data_Nasc = reader["Data_Nasc"].ToString();
                C.Telemovel = reader["Telemovel"].ToString();
                listBox1.Items.Add(C);
            }

            cn.Close();


            currentClient = 0;
            ShowClient();
        }
        private SqlConnection getSGBDConnection()
        {
            return new SqlConnection("data source= LAPTOP-L0GR83Q7\\SQLEXPRESS;integrated security=true;initial catalog=proj");
        }

        private bool verifySGBDConnection()
        {
            if (cn == null)
                cn = getSGBDConnection();

            if (cn.State != ConnectionState.Open)
                cn.Open();

            return cn.State == ConnectionState.Open;
        }

        private void loadCustomersToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ginasio.Cliente", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listBox1.Items.Clear();

            while (reader.Read())
            {
                Cliente C = new Cliente();
                C.CC = reader["CC"].ToString();
                C.Fname= reader["Fname"].ToString();
                C.Lname = reader["Lname"].ToString();
                C.Email = reader["Email"].ToString();
                C.NIF = reader["NIF"].ToString();
                C.Morada = reader["Morada"].ToString();
                C.Data_Nasc = reader["Data_Nasc"].ToString();
                C.Telemovel = reader["Telemovel"].ToString();
                listBox1 .Items.Add(C);

            }

            cn.Close();


            currentClient = 0;
            ShowClient();
        }

        private void SubmitClient(Cliente C)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Ginasio.Cliente (CC, Fname, Lname, Email, Telemovel, NIF, Morada, Data_Nasc) " + "VALUES (@CC @Fname @Lname @Email @Telemovel @NIF @Morada @Data_Nasc)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", C.CC);
            cmd.Parameters.AddWithValue("@Fname", C.Fname);
            cmd.Parameters.AddWithValue("@Lname", C.Lname);
            cmd.Parameters.AddWithValue("@Email", C.Email);
            cmd.Parameters.AddWithValue("@Telemovel", C.Telemovel);
            cmd.Parameters.AddWithValue("@NIF", C.NIF);
            cmd.Parameters.AddWithValue("@Morada", C.Morada);
            cmd.Parameters.AddWithValue("@Data_nasc", C.Data_Nasc);
        }

        private void UpdateClient(Cliente C)
        {
            int rows = 0;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Ginasio.Cliente " + "SET Fname = @Fname, " + "Lname = @Lname, " + " Email = @Email, " + " Telemovel = @Telemovel, " + " NIF = @NIF, " + " Morada = @Morada, " + " Data_Nasc = @Data_Nasc " + "WHERE CC = @CC";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", C.CC);
            cmd.Parameters.AddWithValue("@Fname", C.Fname);
            cmd.Parameters.AddWithValue("@Lname", C.Lname);
            cmd.Parameters.AddWithValue("@Email", C.Email);
            cmd.Parameters.AddWithValue("@Telemovel", C.Telemovel);
            cmd.Parameters.AddWithValue("@NIF", C.NIF);
            cmd.Parameters.AddWithValue("@Morada", C.Morada);
            cmd.Parameters.AddWithValue("@Data_nasc", C.Data_Nasc);
            cmd.Connection = cn;

            try
            {
                rows = cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            { 
                throw new Exception("Erro a atualizar a base de dados. \nERROR MESSAGE: \n " + ex.Message);
            }
            finally
            {
                if (rows == 1)
                    MessageBox.Show("Update OK");
                else
                    MessageBox.Show("Update não correu bem");

                cn.Close();
            }
        }

        private void RemoveClient(string CC)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "DELETE Ginasio.Cliente WHERE CC=@CC";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", CC);
            cmd.Connection= cn;

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao eliminar cliente da base de dados. \n ERROR MESSAGE: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }
        }

        public void LockControls()
        {
            txtCC.ReadOnly = true;
            txtFname.ReadOnly = true;
            txtLname.ReadOnly = true;
            txtMorada.ReadOnly = true;
            txtDataNasc.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTel.ReadOnly= true;
            txtNIF.ReadOnly = true;

        }
        public void UnlockControls()
        {
            txtCC.ReadOnly = false;
            txtFname.ReadOnly = false;
            txtLname.ReadOnly = false;
            txtMorada.ReadOnly = false;
            txtDataNasc.ReadOnly = false;
            txtEmail.ReadOnly = false;
            txtTel.ReadOnly = false;
            txtNIF.ReadOnly = false;

        }

        public void ClearFields()
        {
            txtCC.Text = "";
            txtFname.Text = "";
            txtLname.Text = "";
            txtMorada.Text = "";
            txtDataNasc.Text = "";
            txtEmail.Text = "";
            txtTel.Text = "";
            txtNIF.Text = "";
        }

        public void ShowButtons()
        {
            LockControls();
            bttnAdd.Visible = true;
            bttnDelete.Visible = true;
            bttnEdit.Visible = true;
            bttnOK.Visible = false;
            bttnCancel.Visible = false;
        }
        public void HideButtons()
        {
            UnlockControls();
            bttnAdd.Visible = false;
            bttnDelete.Visible = false;
            bttnEdit.Visible = false;
            bttnOK.Visible = true;
            bttnCancel.Visible = true;
        }

        public void ShowClient()
        {
            if (listBox1.Items.Count == 0 | currentClient < 0)
                return;
            Cliente cliente = new Cliente();
            cliente = (Cliente)listBox1.Items[currentClient];
            txtCC.Text = cliente.CC;
            txtFname.Text = cliente.Fname;
            txtLname.Text = cliente.Lname;
            txtMorada.Text = cliente.Morada;
            txtDataNasc.Text = cliente.Data_Nasc;
            txtTel.Text = cliente.Telemovel;
            txtEmail.Text = cliente.Email;
            txtNIF.Text = cliente.NIF;

        }

        private bool SaveClient()
        {
            Cliente client = new Cliente();
            try
            {
                client.CC = txtCC.Text;
                client.NIF = txtNIF.Text;
                client.Fname = txtFname.Text;
                client.Lname = txtLname.Text;
                client.Email = txtEmail.Text;
                client.Morada = txtMorada.Text;
                client.Data_Nasc = txtDataNasc.Text;
                client.Telemovel = txtTel.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            if (adding)
            {
                SubmitClient(client);
                listBox1.Items.Add(client);
            }
            else
            {
                UpdateClient(client);
                listBox1.Items[currentClient] = client;
            }
            return true;
        }

        private void Label11_Click(object sender, EventArgs e)
        {

        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            adding = true;
            ClearFields();
            HideButtons();
            listBox1.Enabled = false;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            listBox1.Enabled = true;
            if (listBox1.Items.Count > 0)
            {
                currentClient = listBox1.SelectedIndex;
                if (currentClient < 0)
                    currentClient = 0;
                ShowClient();
            }
            else
            {
                ClearFields();
                LockControls();
            }
            ShowButtons();
        }

        private void bttnEdit_Click(object sender, EventArgs e)
        {
            currentClient = listBox1.SelectedIndex;
            if (currentClient < 0)
            {
                MessageBox.Show("Por favor seleciona um cliente para editar");
                return;
            }
            adding = false;
            HideButtons();
            listBox1.Enabled = false;
        }

        private void bttnOK_Click(object sender, EventArgs e)
        {
            try
            {
                SaveClient();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            listBox1.Enabled = true;
            int idx = listBox1.FindString(txtCC.Text);
            listBox1.SelectedIndex = idx;
            ShowButtons();
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                try
                {
                    RemoveClient(((Cliente)listBox1.SelectedItem).CC);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return;
                }
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
                if (currentClient == listBox1.Items.Count)
                    currentClient = listBox1.Items.Count - 1;
                if (currentClient == -1)
                {
                    ClearFields();
                    MessageBox.Show("There are no more contacts");
                }
                else
                {
                    ShowClient();
                }
            }
        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void listBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                currentClient = listBox1.SelectedIndex;
                ShowClient();
            }
        }
    }
}
