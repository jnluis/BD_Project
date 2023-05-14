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
            var clientesForm = new ClientesForm();
            clientesForm.Show();
        }

        private void btnStaff_Click(object sender, EventArgs e)
        {
            // Abrir a janela ou formulário de clientes
            var StaffForm = new StaffForm();
            StaffForm.Show();
        }
    }
}
