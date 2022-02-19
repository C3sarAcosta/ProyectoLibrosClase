using ProyectoLibros.Data;
using ProyectoLibros.Models;
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
    public partial class FrmCategorias : Form
    {
        private int id = 0;
        public FrmCategorias()
        {
            InitializeComponent();
        }

        private void FrmCategorias_Load(object sender, EventArgs e)
        {
            TodoCategorias();
        }

        private void TodoCategorias()
        {
            using(var context = new ApplicationDbContext())
            {
                var categorias = context.Categorias.ToList();
                dgvCategorias.DataSource = categorias;
            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using(var context = new ApplicationDbContext())
            {
                //Creamos el objeto
                var categoria = new Categorias();
                //Le pasamos valores a las propiedades del objeto
                categoria.Nombre = txtNombre.Text;

                //Actualizamos el contexto
                context.Categorias.Add(categoria);

                //Guardamos los cambios
                context.SaveChanges();
            }
            TodoCategorias();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using(var context = new ApplicationDbContext())
            {
                if(id != 0)
                {
                    var categoria = context.Categorias.First(x => x.Id == id);
                    if(categoria != null)
                    {
                        categoria.Nombre = txtNombre.Text;
                        context.SaveChanges();
                    }
                    TodoCategorias();
                }
            }
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using(var context = new ApplicationDbContext())
            {
                //Validamos de que le dimos clic a una categoria
                if (id != 0)
                {
                    //Buscando en la base de datos que la categoria seleccionada si existe
                    var categoria = context.Categorias.First(x =>x.Id == id);
                    if(categoria!= null)
                    {
                        //Removemos del contexto la categoria
                        context.Categorias.Remove(categoria);
                        //Guardamos los cambios en la base de datos
                        context.SaveChanges();
                    }
                    TodoCategorias();
                }
            }
        }
    }
}
