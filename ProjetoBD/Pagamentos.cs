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
    public partial class Pagamentos : Form
    {
        private SqlConnection cn;
        private DataTable originalDataTable;
        private int idRec;
        private int idPagamento;
        public Pagamentos(int idRec)
        {
            InitializeComponent();
            this.idRec = idRec;
        }

        private void tabelaPagamentos_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            btnEdit.Visible = true;

            if (e.RowIndex >= 0) // Verifica se uma linha válida foi selecionada
            {
                DataGridViewRow row = tabelaPagamentos.Rows[e.RowIndex];

                idPagamento = int.Parse(row.Cells["ID"].Value.ToString());


            }
        }

        private void FiltrarDataGridView(string valorFiltro)
        {
            if (originalDataTable != null)
            {
                DataView dataView = originalDataTable.DefaultView;
                if (valorFiltro == "Todos")
                {
                    dataView.RowFilter = string.Empty; 
                    tabelaPagamentos.DataSource = dataView.ToTable();
                }
                else
                {
                    
                    dataView.RowFilter = $"Estado = '{valorFiltro}'";
                    tabelaPagamentos.DataSource = dataView.ToTable();
                }
                
            }
        }

        private void Pagamentos_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add("Todos");
            comboBox1.Items.Add("Pago");
            comboBox1.Items.Add("Cancelado");
            comboBox1.Items.Add("Pendente");

            
            tabelaPagamentos.Visible = true;
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string query = "SELECT * FROM Ginasio.Pagamento";

            SqlCommand command = new SqlCommand(query, cn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            originalDataTable = dataTable;
            tabelaPagamentos.DataSource = dataTable;

            adapter.Fill(dataTable);

            tabelaPagamentos.DataSource = dataTable;
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string filtro = comboBox1.SelectedItem.ToString();
            FiltrarDataGridView(filtro);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var rececionista = new PaginaInicialRececionistas(idRec);
            rececionista.Show();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            var edit = new EditarPagamento(idPagamento);
            edit.FormClosed += Edit_FormClosed; 
            edit.Show();
        }

        private void Edit_FormClosed(object sender, FormClosedEventArgs e)
        {
            AtualizarPagina(); 
        }

        private void AtualizarPagina()
        {
            tabelaPagamentos.Visible = true;
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string query = "SELECT * FROM Ginasio.Pagamento";

            SqlCommand command = new SqlCommand(query, cn);

            SqlDataAdapter adapter = new SqlDataAdapter(command);

            DataTable dataTable = new DataTable();

            originalDataTable = dataTable;
            tabelaPagamentos.DataSource = dataTable;

            adapter.Fill(dataTable);

            tabelaPagamentos.DataSource = dataTable;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
