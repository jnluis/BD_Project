﻿using System;
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
        private int idPagamento, ccCliente;
        private double valor;
        private DateTime dataPag, dataCanc, dataVenc;
        private string estado, metodo;
        public static BDConnection bdConnection = new BDConnection();
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
                valor = double.Parse(row.Cells["Valor"].Value.ToString());
                metodo = row.Cells["Metodo"].Value.ToString();
                estado = row.Cells["Estado"].Value.ToString();
                dataVenc = DateTime.Parse(row.Cells["Data_venc"].Value.ToString());
                if (DateTime.TryParse(row.Cells["Data_canc"].Value.ToString(), out dataCanc)){}
                else{ dataCanc = DateTime.MinValue;}
                if (DateTime.TryParse(row.Cells["Data_Pagamento"].Value.ToString(), out dataPag)) { }
                else { dataPag = DateTime.MinValue; }

                ccCliente = int.Parse(row.Cells["CC_Cliente"].Value.ToString());
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
            var edit = new EditarPagamento(idPagamento, ccCliente,idRec, valor, estado, dataPag,dataCanc,dataVenc,metodo);
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
