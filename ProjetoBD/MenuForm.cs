using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjetoBD
{
    public partial class MenuForm : Form
    {
        public MenuForm()
        {
            InitializeComponent();
        }

        private void btnClientes_Click(object sender, EventArgs e)
        {
            // Abrir a janela ou formulário de clientes
            var clientesForm = new VerClientesForm();
            clientesForm.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            // Abrir a janela ou formulário de clientes
            var StaffForm = new StaffForm();
            StaffForm.Show();
        }

        private void btnClassView_Click(object sender, EventArgs e)
        {
            // Abrir a janela ou formulário de clientes
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

        private void btnEntrar_Click(object sender, EventArgs e)
        {

            int ID = int.Parse(txtID.Text);

            if (btnRecepcionista.Checked) { 
            }
            else if (btnCliente.Checked)
            {
                var ClientesForms = new ClientesForms();
                ClientesForms.Show();
            }
            else if (btnGerente.Checked)
            {

            }
            else if (btnProfessor.Checked)
            {
                var PaginaInicialProfs = new PaginaInicialProfs(ID);
                PaginaInicialProfs.Show();
            }
        }
    }
}
