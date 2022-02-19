using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoLibros
{
    public partial class Dashboard : Form
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void btnAutores_Click(object sender, EventArgs e)
        {
            FrmAutores frmAutores = new FrmAutores();
            frmAutores.Show();
        }

        private void btnCategorias_Click(object sender, EventArgs e)
        {
            FrmCategorias frmCategorias = new FrmCategorias();
            frmCategorias.Show();
        }

        private void btnLibros_Click(object sender, EventArgs e)
        {
            FrmLibros frmLibros = new FrmLibros();
            frmLibros.Show();
        }
    }
}
