using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLibros.Models
{
    internal class Libros
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Editorial { get; set; }
        public double Precio { get; set; }

        //RELACION UN AUTOR A MUCHOS LIBROS
        public int AutoresId { get; set; }
        public Autores Autores { get; set; }

        //RELACION UNA CATEGORIA A MUCHOS LIBROS
        public int CategoriasId { get; set; }
        public Categorias Categorias { get; set; }
    }
}
