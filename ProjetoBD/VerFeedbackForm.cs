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
    public partial class VerFeedbackForm : Form
    {
        private SqlConnection cn;
        private int IDProf;
        private string nomeProf;
        public VerFeedbackForm(int IDProf, string nomeProf)
        {
            InitializeComponent();
            this.nomeProf = nomeProf;
            this.IDProf = IDProf;
        }

        private void VerFeedbackForm_Load(object sender, EventArgs e)
        {
            cn = getSGBDConnection();
            if (!verifySGBDConnection())
                return;

            lblNum.Text = IDProf.ToString();
            lblNomeProf.Text = nomeProf;

            string query = "Select CC_Cliente, Fname, Lname, Comentários, [Data] from Ginasio.Feedback join Ginasio.Cliente on CC= CC_Cliente where ID_Professor = @idProf";
            SqlCommand cmd = new SqlCommand(query, cn);
            cmd.Parameters.AddWithValue("@idProf", IDProf);

            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                int yOffset = 200; // Posição Y inicial dos controles
                int controlSpacing = 40; // Espaçamento vertical entre os controles

                // Itere sobre as linhas do resultado
                while (reader.Read())
                {
                    // Obtenha os valores de cada coluna para a linha atual
                    string idCliente = reader["CC_Cliente"].ToString();
                    string Fname = reader["Fname"].ToString();
                    string Lname = reader["Lname"].ToString();
                    string data = reader["Data"].ToString();
                    string comentarios = reader["Comentários"].ToString();

                    Label lblNumero = new Label();
                    lblNumero.Text = "CC: " + idCliente;
                    lblNumero.Location = new Point(230, yOffset);
                    lblNumero.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                    
                    lblNumero.AutoSize = true;
                    this.Controls.Add(lblNumero);

                    Label lblNome = new Label();
                    lblNome.Text = Fname + ' ' + Lname;
                    lblNome.Location = new Point(400, yOffset);
                    lblNome.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                    lblNome.AutoSize = true;
                    this.Controls.Add(lblNome);

                    Label lblData = new Label();
                    lblData.Text = "Data: " + data;
                    lblData.Location = new Point(560, yOffset);
                    lblData.Width = 150;
                    lblData.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);

                    this.Controls.Add(lblData);

                    TextBox txtComentarios = new TextBox();
                    txtComentarios.Text = comentarios;
                    txtComentarios.Location = new Point(730, yOffset);
                    txtComentarios.Width = 800;
                    txtComentarios.Height = 50;
                    txtComentarios.Multiline = true;
                    txtComentarios.ReadOnly = true;
                    txtComentarios.AutoSize = true;
                    txtComentarios.Font = new Font("Microsoft Sans Serif", 14, FontStyle.Regular);
                    this.Controls.Add(txtComentarios);

                    yOffset += controlSpacing + 50;
                }
            }

            cn.Close();
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

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();
            var PaginaInicialProfs = new PaginaInicialProfs(IDProf);
            PaginaInicialProfs.Show();
        }
    }
}
