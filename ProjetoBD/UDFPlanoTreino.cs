using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProjetoBD
{
    public partial class UDFPlanoTreino : Form
    {
        private SqlConnection cn;
        public int IDinical;
        public UDFPlanoTreino(int id)
        {
            InitializeComponent();
            IDinical = id;
        }

        private void UDFPlanoTreino_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            string sql = "SELECT CC_cliente FROM Ginasio.Professor JOIN Ginasio.Plano_Treino ON Ginasio.Professor.Num_func = Ginasio.Plano_Treino.ID_Professor WHERE Ginasio.Professor.Num_func = @IDinical";
            SqlCommand cmd = new SqlCommand(sql, cn);
            cmd.Parameters.AddWithValue("@IDinical", IDinical);

            // Criar uma lista para armazenar os valores retornados
            List<int> ccClientes = new List<int>();
            SqlDataReader reader = cmd.ExecuteReader();

            // Ler os resultados da consulta e adicionar à lista
            while (reader.Read())
            {
                int ccCliente = reader.GetInt32(0);
                ccClientes.Add(ccCliente);
            }

            // Fechar a conexão e liberar recursos
            reader.Close();
            cn.Close();

            // Preencher a ComboBox com os valores da lista
            cBoxClientes.DataSource = ccClientes;
            cBoxClientes.DisplayMember = "CC_cliente";

            cBoxClientes.SelectedIndex = -1;
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

    }
}
