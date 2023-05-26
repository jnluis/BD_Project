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
using System.Windows.Forms.DataVisualization.Charting;
using System.Xml.Linq;

namespace ProjetoBD
{
    public partial class PaginaInicialGerente : Form
    {
        private int nGerente;
        private SqlConnection cn;
        public static BDConnection bdConnection = new BDConnection();
        public PaginaInicialGerente(int nGerente)
        {
            InitializeComponent();
            this.nGerente = nGerente;
        }

        private void PaginaInicialGerente_Load(object sender, EventArgs e)
        {
            chartInscricoes.Series.Clear(); // Limpa as séries existentes (se houver)
            chartInscricoes.Series.Add("Inscrições"); // Adiciona uma nova série ao gráfico
            chartInscricoes.Series["Inscrições"].ChartType = SeriesChartType.Column; // Define o tipo de gráfico como barras

            // Obtém os dados do banco de dados
            DataTable dataTable = GetChartInscricoesAulas();

            foreach (DataRow row in dataTable.Rows)
            {
                string aula = row["Aula"].ToString();
                int inscricoes = Convert.ToInt32(row["Número Inscrições"]);

                chartInscricoes.Series["Inscrições"].Points.AddXY(aula, inscricoes);
            }

            dataTable = GetChartPlanoAdesao();

            chartTiposPlanoA.Series.Clear(); // Limpa as séries existentes (se houver)
            chartTiposPlanoA.Series.Add("Tipos Plano Adesão"); // Adiciona uma nova série ao gráfico
            chartTiposPlanoA.Series["Tipos Plano Adesão"].ChartType = SeriesChartType.Pie;

            foreach (DataRow row in dataTable.Rows)
            {
                string tipo = row["Tipo"].ToString();
                int quantidade = Convert.ToInt32(row["Quantidade"]);

                // Calcular a porcentagem
                double percentagem = (double)quantidade / dataTable.AsEnumerable().Sum(r => r.Field<int>("Quantidade")) * 100;

                chartTiposPlanoA.Series["Tipos Plano Adesão"].Points.AddXY("", percentagem);
                chartTiposPlanoA.Series["Tipos Plano Adesão"].Points.Last().Label = "#PERCENT{P0}";

                chartTiposPlanoA.Series["Tipos Plano Adesão"].Points.Last().LegendText = tipo;
            }

            chartTiposPlanoA.Series["Tipos Plano Adesão"].IsVisibleInLegend = true;

            dataTable = GetChartEstadoPagamentos();

            charPagamentos.Series.Clear(); // Limpa as séries existentes (se houver)
            charPagamentos.Series.Add("Estado Pagamentos"); // Adiciona uma nova série ao gráfico
            charPagamentos.Series["Estado Pagamentos"].ChartType = SeriesChartType.Pie;

            foreach (DataRow row in dataTable.Rows)
            {
                string estado = row["Estado"].ToString();
                int quantidade = Convert.ToInt32(row["Quantidade"]);

                // Calcular a porcentagem
                double percentagem = (double)quantidade / dataTable.AsEnumerable().Sum(r => r.Field<int>("Quantidade")) * 100;

                charPagamentos.Series["Estado Pagamentos"].Points.AddXY("", percentagem);
                charPagamentos.Series["Estado Pagamentos"].Points.Last().Label = "#PERCENT{P0}";

                charPagamentos.Series["Estado Pagamentos"].Points.Last().LegendText = estado;
            }

            charPagamentos.Series["Estado Pagamentos"].IsVisibleInLegend = true;

            dataTable = GetChartSalarios();

            chartSalarios.Series.Clear(); // Limpa as séries existentes (se houver)
            chartSalarios.Series.Add("Salarios"); // Adiciona uma nova série ao gráfico
            chartSalarios.Series["Salarios"].ChartType = SeriesChartType.Column; // Define o tipo de gráfico como barras


            foreach (DataRow row in dataTable.Rows)
            {
                string cargo = row["Cargo"].ToString();
                int mediaSal = Convert.ToInt32(row["MediaSalario"]);

                chartSalarios.Series["Salarios"].Points.AddXY(cargo, mediaSal);
            }



        }

        private DataTable GetChartInscricoesAulas()
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return null;

            string query = "SELECT * FROM Ginasio.Inscricoes()";

            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            // Preenche o DataTable com os dados do banco de dados
            adapter.Fill(dataTable);

            // Retorna o DataTable com os dados
            return dataTable;
        }

        private DataTable GetChartPlanoAdesao()
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return null;

            string query = "SELECT * FROM Ginasio.TiposPlanosAdesao()";

            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();

            // Preenche o DataTable com os dados do banco de dados
            adapter.Fill(dataTable);

            // Retorna o DataTable com os dados
            return dataTable;
        }

        private DataTable GetChartEstadoPagamentos()
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return null;

            string query = "SELECT * FROM Ginasio.EstadoPagamentos()";

            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();


            adapter.Fill(dataTable);


            return dataTable;
        }

        private DataTable GetChartSalarios()
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return null;

            string query = "SELECT * FROM Ginasio.MediasSalarios()";

            SqlCommand cmd = new SqlCommand(query, cn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dataTable = new DataTable();


            adapter.Fill(dataTable);


            return dataTable;
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

        private void charPagamentos_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void btnFunc_Click(object sender, EventArgs e)
        {
            this.Close();
            var funcionarios = new StaffForm(nGerente);
            funcionarios.Show();
        }
    }
}
