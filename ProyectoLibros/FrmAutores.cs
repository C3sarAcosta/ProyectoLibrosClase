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
    public partial class FrmAutores : Form
    {
        private int id = 0;
        public FrmAutores()
        {
            InitializeComponent();
        }

        private void FrmAutores_Load(object sender, EventArgs e)
        {
            ListaAutores();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                //Crear objeto de Autores
                var autor = new Autores();
                //Pasando los valores de los textBox a las propiedadesd el objeto
                autor.Nombre = txtNombre.Text;
                autor.ApellidoPaterno = txtApellidoPaterno.Text;
                autor.ApellidoMaterno = txtApellidoMaterno.Text;
                autor.RFC = txtRFC.Text;
                autor.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                            //if(rbtnFemenino.Cheched == true){"femenino"} else {"masculino"}
                autor.Sexo = rbtnFemenino.Checked ? "Femenino" : "Masculino";
                autor.Nacionalidad = txtNacionalidad.Text;

                //Notificamos a EFC que vamos a agregar un autor
                context.Autores.Add(autor);

                //Guardamos los cambios
                context.SaveChanges();

                ListaAutores();

            }
        }

        private void ListaAutores()
        {
            //Usamos el contexto de datos
            using (var context = new ApplicationDbContext())
            {
                //Creamos una consulta SELECT * FROM Autores
                var autores = context.Autores.ToList();
                //Pasamos la lista de la consulta anterior al dataGridView
                dgvAutores.DataSource = autores;
            }
        }

        private void dgvAutores_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = Convert.ToInt32(dgvAutores.CurrentRow.Cells[0].Value);
            txtNombre.Text = dgvAutores.CurrentRow.Cells[1].Value.ToString();
            txtApellidoPaterno.Text = dgvAutores.CurrentRow.Cells[2].Value.ToString();
            txtApellidoMaterno.Text = dgvAutores.CurrentRow.Cells[3].Value.ToString();
            txtRFC.Text = dgvAutores.CurrentRow.Cells[6].Value.ToString();
            dtpFechaNacimiento.Value = Convert.ToDateTime(dgvAutores.CurrentRow.Cells[5].Value.ToString());
            if(dgvAutores.CurrentRow.Cells[4].Value.ToString() == "Femenino")
            {
                rbtnFemenino.Checked = true;
            }
            else
            {
                rbtnMasculino.Checked = true;
            }
            txtNacionalidad.Text = dgvAutores.CurrentRow.Cells[7].Value.ToString();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            using (var context = new ApplicationDbContext())
            {
                if(id != 0)
                {
                    //Consulta select * from "Autores" a where a."Id" = 1
                    var autor = context.Autores.First(x => x.Id == id);
                    if(autor != null)
                    {
                        autor.Nombre = txtNombre.Text;
                        autor.ApellidoPaterno = txtApellidoPaterno.Text;
                        autor.ApellidoMaterno = txtApellidoMaterno.Text;
                        autor.RFC = txtRFC.Text;
                        autor.FechaNacimiento = dtpFechaNacimiento.Value.Date;
                        //if(rbtnFemenino.Cheched == true){"femenino"} else {"masculino"}
                        autor.Sexo = rbtnFemenino.Checked ? "Femenino" : "Masculino";
                        autor.Nacionalidad = txtNacionalidad.Text;
                        context.SaveChanges();
                        ListaAutores();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            id = 0;
            txtNombre.Text = "";
            txtApellidoPaterno.Text = "";
            txtApellidoMaterno.Text = "";
            txtRFC.Text = "";
            txtNacionalidad.Text = "";
            dtpFechaNacimiento.Value = Convert.ToDateTime(DateTime.Now);
            rbtnFemenino.Checked = true;
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            using(var context = new ApplicationDbContext())
            {
                if(id != 0)
                {
                    //Consulta select * from "Autores" a where a."Id" = 1
                    var autor = context.Autores.First(x => x.Id == id);
                    if(autor != null)
                    {
                        context.Autores.Remove(autor);
                        context.SaveChanges();
                        ListaAutores();
                    }
                }
            }
        }
    }
}
