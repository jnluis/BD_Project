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
    public partial class StaffForm : Form
    {
        private SqlConnection cn;
        private int currentFunc;
        private bool adding;
        public static BDConnection bdConnection = new BDConnection();
        private int idGerente;

        public StaffForm(int Gerente)
        {
            InitializeComponent();
            this.idGerente = Gerente;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            listProfs.ClearSelected();
            listRecepcionistas.ClearSelected();

            if (listGerentes.SelectedIndex > -1)
            {
                currentFunc = listGerentes.SelectedIndex;
                ShowFunc(listGerentes);
            }
        }
    

        private void AtualizarData()
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand("SELECT * FROM Ginasio.Staff Join Ginasio.Professor On Ginasio.Professor.Num_func = Ginasio.Staff.Num_func ", cn);
            SqlDataReader reader = cmd.ExecuteReader();
            listProfs.Items.Clear();

            while (reader.Read())
            {
                Staff C = new Staff();
                C.CC = reader["CC"].ToString();
                C.Fname = reader["Fname"].ToString();
                C.Lname = reader["Lname"].ToString();
                C.Email = reader["Email"].ToString();
                C.NIF = reader["NIF"].ToString();
                C.Morada = reader["Morada"].ToString();
                C.Data_Nasc = reader["Data_Nasc"].ToString();
                C.Telemovel = reader["Telemovel"].ToString();
                C.Data_Contrat = reader["Data_Contr"].ToString();
                C.NGerente = reader["Gerente_Num"].ToString();
                C.NFunc = reader["Num_func"].ToString();
                C.Salario = reader["Salario"].ToString();
                C.Horario = reader["Horario_Lab"].ToString();
                C.Cargo = "Professor";
                listProfs.Items.Add(C);
            }

            reader.Close();

            cmd = new SqlCommand("SELECT * FROM Ginasio.Staff Join Ginasio.Gerente On Ginasio.Gerente.Num_func = Ginasio.Staff.Num_func ", cn);
            reader = cmd.ExecuteReader();
            listGerentes.Items.Clear();

            while (reader.Read())
            {
                Staff C = new Staff();
                C.CC = reader["CC"].ToString();
                C.Fname = reader["Fname"].ToString();
                C.Lname = reader["Lname"].ToString();
                C.Email = reader["Email"].ToString();
                C.NIF = reader["NIF"].ToString();
                C.Morada = reader["Morada"].ToString();
                C.Data_Nasc = reader["Data_Nasc"].ToString();
                C.Telemovel = reader["Telemovel"].ToString();
                C.Data_Contrat = reader["Data_Contr"].ToString();
                C.NGerente = reader["Gerente_Num"].ToString();
                C.NFunc = reader["Num_func"].ToString();
                C.Salario = reader["Salario"].ToString();
                C.Horario = reader["Horario_Lab"].ToString();
                C.Cargo = "Gerente";
                listGerentes.Items.Add(C);
            }

            reader.Close();

            cmd = new SqlCommand("SELECT * FROM Ginasio.Staff Join Ginasio.Rececionista On Ginasio.Rececionista.Num_func = Ginasio.Staff.Num_func ", cn);
            reader = cmd.ExecuteReader();
            listRecepcionistas.Items.Clear();

            while (reader.Read())
            {
                Staff C = new Staff();
                C.CC = reader["CC"].ToString();
                C.Fname = reader["Fname"].ToString();
                C.Lname = reader["Lname"].ToString();
                C.Email = reader["Email"].ToString();
                C.NIF = reader["NIF"].ToString();
                C.Morada = reader["Morada"].ToString();
                C.Data_Nasc = reader["Data_Nasc"].ToString();
                C.Telemovel = reader["Telemovel"].ToString();
                C.Data_Contrat = reader["Data_Contr"].ToString();
                C.NGerente = reader["Gerente_Num"].ToString();
                C.NFunc = reader["Num_func"].ToString();
                C.Salario = reader["Salario"].ToString();
                C.Horario = reader["Horario_Lab"].ToString();
                C.Cargo = "Rececionista";
                listRecepcionistas.Items.Add(C);
            }

            reader.Close();

            cn.Close();
            
        }
        

        private void StaffForm_Load(object sender, EventArgs e)
        {
            AtualizarData();
            currentFunc = 0;
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

        private void loadStaffToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AtualizarData();

            currentFunc = 0;

        }

        private bool VerificarCargo(string numFuncionario, string tableName)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return false;

            string query = $"SELECT COUNT(*) FROM Ginasio.{tableName} WHERE Num_func = @NumFuncionario";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@NumFuncionario", numFuncionario);
            int count = (int)cmd.ExecuteScalar();

            cn.Close();

            return count > 0;
        }

        private string VerificarNomeGerente(string numGerente, string tableName)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return "";

            string query = $"SELECT Fname + ' ' + Lname FROM Ginasio.{tableName} WHERE Num_func = @numGerente";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@numGerente", numGerente);
            string name = cmd.ExecuteScalar()?.ToString();

            cn.Close();

            return name;
        }
        private string VerificarCertificacoes(string numFunc, string tableName)
        {
            SqlConnection cn = getSGBDConnection(); // Declare e inicialize a variável cn
            if (!verifySGBDConnection())
                return "";

            string query = $"SELECT certificacoes FROM Ginasio.{tableName} WHERE Num_func = @numFunc";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@numFunc", numFunc);
            StringBuilder result = new StringBuilder();

            cn.Open();

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    string value = reader.GetString(0); // Obtém o valor da primeira coluna (índice 0)
                    result.Append(value + ", "); // Concatena o valor à string result com uma vírgula e um espaço
                }
            }

            cn.Close();

            string concatenatedValues = result.ToString().TrimEnd(',', ' ');

            return concatenatedValues;
        }


        public void LockControls()
        {
            txtCC.ReadOnly = true;
            txtFname.ReadOnly = true;
            txtLname.ReadOnly = true;
            txtMorada.ReadOnly = true;
            txtDataNasc.ReadOnly = true;
            txtEmail.ReadOnly = true;
            txtTel.ReadOnly = true;
            txtNIF.ReadOnly = true;
            txtDataContrat.ReadOnly = true;
            txtNomeGere.ReadOnly = true;
            txtNumGere.ReadOnly = true;
            txtSalario.ReadOnly = true;
            txtNfunc.ReadOnly = true;
            txtCertificados.ReadOnly = true;
            txtHorario.ReadOnly = true;
            listGerentes.Enabled = true;
            listProfs.Enabled = true;
            listRecepcionistas.Enabled = true;
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
            txtDataContrat.ReadOnly = false;
            txtNomeGere.ReadOnly = true;
            txtNumGere.ReadOnly = false;
            txtSalario.ReadOnly = false;
            txtNfunc.ReadOnly = false;
            txtCertificados.ReadOnly = false;
            txtHorario.ReadOnly = false;
            panelCargo.Enabled = true;
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
            txtDataContrat.Text = "";
            txtNomeGere.Text = "";
            txtNumGere.Text = "";
            txtSalario.Text = "";
            txtNfunc.Text = "";
            txtCertificados.Text = "";
            txtHorario.Text = "";
            btnGerente.Checked = false;
            btnProfessor.Checked = false;
            btnRecepcionista.Checked = false;

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


        public void ShowFunc(ListBox listBox)
        {

            if (listBox.Items.Count == 0 || listBox.SelectedIndex < 0)
                return;

            Staff func = new Staff();

            func = (Staff)listBox.SelectedItem;

            txtCC.Text = func.CC;
            txtFname.Text = func.Fname;
            txtLname.Text = func.Lname;
            txtMorada.Text = func.Morada;
            txtDataNasc.Text = func.Data_Nasc;
            txtTel.Text = func.Telemovel;
            txtEmail.Text = func.Email;
            txtNIF.Text = func.NIF;
            txtNfunc.Text = func.NFunc;
            txtNumGere.Text = func.NGerente;
            txtDataContrat.Text = func.Data_Contrat;
            txtSalario.Text = func.Salario;
            txtHorario.Text = func.Horario;


            bool isProfessor = VerificarCargo(txtNfunc.Text, "Professor");
            bool isGerente = VerificarCargo(txtNfunc.Text, "Gerente");
            bool isRecepcionista = VerificarCargo(txtNfunc.Text, "Rececionista");

            // Faça algo com os resultados, por exemplo, exiba mensagens adequadas
            if (isProfessor)
            {
                btnProfessor.Select();
                txtCertificados.Visible = true;
                labelCertificados.Visible=true;

                string certificados = VerificarCertificacoes(txtNfunc.Text, "Certificacoes_Prof");
                txtCertificados.Text = certificados;
            }
            else if (isGerente)
            {
                btnGerente.Select();
                txtCertificados.Visible = false;
                labelCertificados.Visible = false;
            }
            else if (isRecepcionista)
            {
                btnRecepcionista.Select();
                txtCertificados.Visible = false;
                labelCertificados.Visible = false;
            }

            string nomeGerente = VerificarNomeGerente(txtNumGere.Text, "Staff");
            txtNomeGere.Text = nomeGerente;


        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private bool SaveFunc()
        {
            Staff func = new Staff();
            try
            {
                func.CC = txtCC.Text;
                func.NIF = txtNIF.Text;
                func.Fname = txtFname.Text;
                func.Lname = txtLname.Text;
                func.Email = txtEmail.Text;
                func.Morada = txtMorada.Text;
                func.Data_Nasc = txtDataNasc.Text;
                func.Telemovel = txtTel.Text;
                func.NGerente = txtNumGere.Text;
                func.Salario = txtSalario.Text;
                func.Horario= txtHorario.Text;
                func.Data_Contrat = txtDataContrat.Text;
                func.NFunc = txtNfunc.Text;

                if (btnGerente.Checked)
                {
                    func.Cargo = "Gerente";
                }
                else if (btnProfessor.Checked)
                {
                    func.Cargo = "Professor";
                }
                else if (btnRecepcionista.Checked)
                {
                    func.Cargo = "Rececionista";
                }
                else
                {
                    func.Cargo = null;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            if (adding)
            {
                SubmitFunc(func);
                if (func.Cargo == "Gerente")
                {
                    listGerentes.Items.Add(func);

                }else if (func.Cargo == "Rececionista")
                {
                    listRecepcionistas.Items.Add(func);
                }else if (func.Cargo == "Professor")
                {
                    listProfs.Items.Add(func);
                }

            }
            else
            {
                UpdateFunc(func);
                if (func.Cargo == "Gerente")
                {
                    listGerentes.Items[currentFunc] = func;

                }
                else if (func.Cargo == "Rececionista")
                {
                    listRecepcionistas.Items[currentFunc] = func;
                }
                else if (func.Cargo == "Professor")
                {
                    listProfs.Items.Add(func);
                }
            }
            return true;
        }

        private void SubmitFunc(Staff C)
        {
            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "INSERT INTO Ginasio.Staff (CC, Fname, Lname, Email, Telemovel, NIF, Morada, Data_Nasc, Salario, Num_func, Data_Contr, Horario_Lab, Gerente_Num) " +
                              "VALUES (@CC, @Fname, @Lname, @Email, @Telemovel, @NIF, @Morada, @Data_Nasc, @Salario, @Num_func, @Data_Contr, @Horario, @Gerente_Num)";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@CC", int.Parse(C.CC));
            cmd.Parameters.AddWithValue("@Fname", C.Fname);
            cmd.Parameters.AddWithValue("@Lname", C.Lname);
            cmd.Parameters.AddWithValue("@Email", C.Email);
            cmd.Parameters.AddWithValue("@Telemovel", int.Parse(C.Telemovel));
            cmd.Parameters.AddWithValue("@NIF", int.Parse(C.NIF));
            cmd.Parameters.AddWithValue("@Morada", C.Morada);
            cmd.Parameters.AddWithValue("@Data_Nasc", DateTime.Parse(C.Data_Nasc));
            cmd.Parameters.AddWithValue("@Salario", decimal.Parse(C.Salario));
            cmd.Parameters.AddWithValue("@Num_func", int.Parse(C.NFunc));
            cmd.Parameters.AddWithValue("@Data_Contr", DateTime.Parse(C.Data_Contrat));
            cmd.Parameters.AddWithValue("@Horario",TimeSpan.Parse(C.Horario));
            cmd.Parameters.AddWithValue("@Gerente_Num", int.Parse(C.NGerente));


            if (verifySGBDConnection())
            {
                try
                {
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionário inserido com sucesso!");
                }
                catch (SqlException ex)
                {
                    // Lida com exceções do SQL Server aqui
                    MessageBox.Show("Ocorreu um erro ao inserir o Funcionário: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }

            cmd.Parameters.Clear(); 

            if (C.Cargo == "Professor")
            {
                cmd.CommandText = "INSERT INTO Ginasio.Professor (Num_func) " +
                                  "VALUES (@Num_func)";
                cmd.Parameters.AddWithValue("@Num_func", C.NFunc);
            }
            else if (C.Cargo == "Gerente")
            {

                cmd.CommandText = "INSERT INTO Ginasio.Gerente (Num_func) " + "VALUES (@Num_func)";
                cmd.Parameters.AddWithValue("@Num_func", C.NFunc);
            }
            else if (C.Cargo == "Recepcionista")
            {
                cmd.CommandText = "INSERT INTO Ginasio.Rececionista (Num_func) " + "VALUES (@Num_func)";
                cmd.Parameters.AddWithValue("@Num_func", C.NFunc);
            }

            if (verifySGBDConnection())
            {
                try
                {
                    cmd.Connection = cn;
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Funcionário inserido com sucesso!");
                }
                catch (SqlException ex)
                {
                    // Lida com exceções do SQL Server aqui
                    MessageBox.Show("Ocorreu um erro ao inserir o Funcionário: " + ex.Message);
                }
                finally
                {
                    cn.Close();
                }
            }

            AtualizarData();
        }

        private void UpdateFunc(Staff C)
        {
            int rows = 0;

            if (!verifySGBDConnection())
                return;
            SqlCommand cmd = new SqlCommand();

            cmd.CommandText = "UPDATE Ginasio.Staff " + "SET Fname = @Fname, " + "Lname = @Lname, " + " Email = @Email, " + " Telemovel = @Telemovel, " + " Morada = @Morada, " + " Data_Nasc = @Data_Nasc, " + " Gerente_Num = @Gerente_Num, " + " Salario = @Salario, " + " Horario_Lab = @Horario " + "WHERE Num_func = @Num_func";
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@Num_Func", int.Parse(C.NFunc));
            cmd.Parameters.AddWithValue("@Fname", C.Fname);
            cmd.Parameters.AddWithValue("@Lname", C.Lname);
            cmd.Parameters.AddWithValue("@Email", C.Email);
            cmd.Parameters.AddWithValue("@Telemovel", int.Parse(C.Telemovel));
            cmd.Parameters.AddWithValue("@Morada", C.Morada);
            cmd.Parameters.AddWithValue("@Data_nasc", DateTime.Parse(C.Data_Nasc));
            cmd.Parameters.AddWithValue("@Gerente_Num", int.Parse(C.NGerente));
            cmd.Parameters.AddWithValue("@Horario", TimeSpan.Parse(C.Horario));
            cmd.Parameters.AddWithValue("@Salario", decimal.Parse(C.Salario));
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

            AtualizarData();

        }

        private void RemoveFunc(string Num_func, string cargo)
        {
            if (!verifySGBDConnection())
                return;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = cn;

            try
            {
                // Delete from the specific table
                if (cargo == "Professor")
                {
                    cmd.CommandText = "DELETE FROM Ginasio.Professor WHERE Num_func = @Num_func";
                }
                else if (cargo == "Gerente")
                {
                    cmd.CommandText = "DELETE FROM Ginasio.Gerente WHERE Num_func = @Num_func";
                }
                else if (cargo == "Rececionista")
                {
                    cmd.CommandText = "DELETE FROM Ginasio.Rececionista WHERE Num_func = @Num_func";
                }
                else
                {
                    throw new ArgumentException("Cargo inválido.");
                }

                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Num_func", Num_func);

                cmd.ExecuteNonQuery();

                // Delete from the Staff table
                cmd.CommandText = "DELETE FROM Ginasio.Staff WHERE Num_func = @Num_func";
                cmd.ExecuteNonQuery();

                MessageBox.Show("Funcionário removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao remover funcionário da base de dados. \nMENSAGEM DE ERRO: \n" + ex.Message);
            }
            finally
            {
                cn.Close();
            }

            AtualizarData();
        }

        private void bttnAdd_Click(object sender, EventArgs e)
        {
            adding = true;
            ClearFields();
            HideButtons();
            listGerentes.Enabled = false;
            listProfs.Enabled = false;
            listRecepcionistas.Enabled = false;
            txtNfunc.Enabled = true;
            txtCertificados.Visible = false;
            labelCertificados.Visible = false;
        }

        private void bttnCancel_Click(object sender, EventArgs e)
        {
            ListBox selectedList = null;

            if (listGerentes.Enabled && listGerentes.Items.Count > 0 && listGerentes.SelectedIndex > -1)
            {
                selectedList = listGerentes;
            }
            else if (listProfs.Enabled && listProfs.Items.Count > 0 && listProfs.SelectedIndex > -1)
            {
                selectedList = listProfs;
            }
            else if (listRecepcionistas.Enabled && listRecepcionistas.Items.Count > 0 && listRecepcionistas.SelectedIndex > -1)
            {
                selectedList = listRecepcionistas;
            }

            if (selectedList == null)
            {
                ClearFields();
                ShowButtons();
                return;
            }

            currentFunc = selectedList.SelectedIndex;
            if (currentFunc < 0)
                currentFunc = 0;
            ShowButtons();
            ShowFunc(selectedList);
            
        }

        private void bttnEdit_Click(object sender, EventArgs e)
        {
            ListBox selectedList = null;

            if (listGerentes.Enabled && listGerentes.Items.Count > 0 && listGerentes.SelectedIndex > -1)
            {
                selectedList = listGerentes;
            }
            else if (listProfs.Enabled && listProfs.Items.Count > 0 && listProfs.SelectedIndex > -1)
            {
                selectedList = listProfs;
            }
            else if (listRecepcionistas.Enabled && listRecepcionistas.Items.Count > 0 && listRecepcionistas.SelectedIndex > -1)
            {
                selectedList = listRecepcionistas;
            }

            currentFunc = selectedList.SelectedIndex;
            if (currentFunc < 0)
            {
                MessageBox.Show("Por favor seleciona um funcionário para editar");
                return;
            }

            adding = false;
            HideButtons();
            selectedList.Enabled = false;
            txtDataContrat.Enabled = false;
            txtNfunc.Enabled = false;
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

            listRecepcionistas.Enabled = true;
            listGerentes.Enabled = true;
            listProfs.Enabled = true;

            ShowButtons();
        }

        private void bttnDelete_Click(object sender, EventArgs e)
        {
            ListBox selectedList = null;

            if (listGerentes.SelectedIndex > -1)
            {
                selectedList = listGerentes;
            }
            else if (listProfs.SelectedIndex > -1)
            {
                selectedList = listProfs;
            }
            else if (listRecepcionistas.SelectedIndex > -1)
            {
                selectedList = listRecepcionistas;
            }
            else
            {
                return; // Nenhum item selecionado em nenhuma lista
            }

            try
            {
                RemoveFunc(((Staff)selectedList.SelectedItem).NFunc, ((Staff)selectedList.SelectedItem).Cargo);
                selectedList.Items.RemoveAt(selectedList.SelectedIndex);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return;
            }

            if (currentFunc == selectedList.Items.Count)
                currentFunc = selectedList.Items.Count - 1;

            if (currentFunc == -1)
            {
                ClearFields();
                MessageBox.Show("Não há mais funcionários");
            }
            else
            {
                ShowFunc(selectedList);
            }
        }

        private void listProfs_SelectedIndexChanged(object sender, EventArgs e)
        {
            listGerentes.ClearSelected();
            listRecepcionistas.ClearSelected();

            if (listProfs.SelectedIndex > -1)
            {
                currentFunc = listProfs.SelectedIndex;
                ShowFunc(listProfs);
            }
        }

        private void listRecepcionistas_SelectedIndexChanged(object sender, EventArgs e)
        {
            listGerentes.ClearSelected();
            listProfs.ClearSelected();

            if (listRecepcionistas.SelectedIndex > -1)
            {
                currentFunc = listRecepcionistas.SelectedIndex;
                ShowFunc(listRecepcionistas);
            }
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var paginaInicialGerentes = new PaginaInicialGerente(idGerente);
            paginaInicialGerentes.Show();
        }
    }
}
