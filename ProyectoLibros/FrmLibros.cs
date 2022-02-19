using ProyectoLibros.Data;
using ProyectoLibros.Models;

namespace ProyectoLibros
{
    public partial class FrmLibros : Form
    {
        private int idCategoria = 0;
        private int idAutor = 0;
        private int idLibro = 0;
        public FrmLibros()
        {
            InitializeComponent();
        }

        private void FrmLibros_Load(object sender, EventArgs e)
        {
            TodoAutores();
            TodoCategorias();
            TodoLibros();
        }

        private void TodoAutores()
        {
            using(var context = new ApplicationDbContext())
            {
                var autores = context.Autores.ToList();
                dgvAutores.DataSource = autores;
            }
        }

        private void TodoCategorias()
        {
            using (var context = new ApplicationDbContext())
            {
                var categorias = context.Categorias.ToList();
                dgvCategorias.DataSource = categorias;
            }
        }

        private void TodoLibros()
        {
            using (var context = new ApplicationDbContext())
            {
                var libros = context.Libros.ToList();
                dgvLibros.DataSource = libros;
            }
        }

        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idAutor = Convert.ToInt32(dgvAutores.CurrentRow.Cells[0].Value);
            txtAutorId.Text = idAutor.ToString();
            txtAutorNombre.Text = dgvAutores.CurrentRow.Cells[1].Value.ToString() +
                " " + dgvAutores.CurrentRow.Cells[2].Value.ToString() +
                " " + dgvAutores.CurrentRow.Cells[3].Value.ToString();
        }

        private void dgvCategorias_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            idCategoria = Convert.ToInt32(dgvCategorias.CurrentRow.Cells[0].Value);
            txtCategoriaId.Text = idCategoria.ToString();
            txtCategoriaNombre.Text = dgvCategorias.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                if (idAutor != 0 || idCategoria != 0)
                {
                    var libro = new Libros();
                    libro.Nombre = txtNombre.Text;
                    libro.Editorial = txtEditorial.Text;
                    libro.Precio = Convert.ToDouble(txtPrecio.Text);
                    libro.AutoresId = idAutor;
                    libro.CategoriasId = idCategoria;

                    context.Libros.Add(libro);

                    context.SaveChanges();

                    TodoLibros();
                }
            }
        }
    }
}