using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLibros.Models
{
    /*PASOS
     1. Crear la clase
     2. Actualizar el ApplicationDbContext
     3. Add-Migration "Nombre de la migracion"
     4. Update-Database
     */
    internal class Categorias
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //RELACION UN AUTOR A MUCHOS LIBROS
        public ICollection<Libros> Libros { get; set; }
    }
}
