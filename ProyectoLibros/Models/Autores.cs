using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLibros.Models
{
    /*Nombre de la tabla*/
    internal class Autores
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public string Sexo { get; set; }
        [Column(TypeName = "Date")]
        public DateTime FechaNacimiento { get; set; }
        public string RFC { get; set; }
        public string Nacionalidad { get; set; }
        //RELACION UN AUTOR A MUCHOS LIBROS
        public ICollection<Libros> Libros { get; set; }
    }
}
