using Microsoft.EntityFrameworkCore;
using ProyectoLibros.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoLibros.Data
{
    internal class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            /* Crear la conexion a la base de datos
                *Host = localhost = 127.0.0.1
                *Database = Nombre de la base de datos = proyectoLibros
                *Username = postgres
                *Password = nada123
            */

            optionsBuilder.UseNpgsql("Host=localhost; Database=proyectoLibros; Username=postgres; password=nada123");

            base.OnConfiguring(optionsBuilder);
        }
        //Le especificamos a nuestro contexto que tenemos un modelo llamado Autores
        public DbSet<Autores> Autores { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Libros> Libros { get; set; }
    }
}
