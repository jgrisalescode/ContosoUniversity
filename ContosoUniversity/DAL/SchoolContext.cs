using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using ContosoUniversity.Models;

namespace ContosoUniversity.DAL
{
    public class SchoolContext : DbContext
    {
        /*
         * Especificar la cadena de conexión.
         * El nombre de la cadena de conexión (que agregará al archivo Web. config más adelante) 
         * se pasa al constructor.
         */
        public SchoolContext() : base("SchoolContext")
        {
        }

        /*
         * Especificar conjuntos de entidades
         * Este código crea una propiedad DbSet para cada conjunto de entidades.
         * En Entity Framework terminología, un conjunto de entidades se corresponde 
         * normalmente con una tabla de base de datos y una entidad corresponde a una 
         * fila de la tabla
         */
        public DbSet<Student> Stundents { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            /*
             * La instrucción modelBuilder.Conventions.Remove en el método OnModelCreating 
             * impide que los nombres de tabla se confirmen. Si no lo hizo, 
             * las tablas generadas en la base de datos se denominarán Students, 
             * Coursesy Enrollments. En su lugar, los nombres de tabla se Student, 
             * Coursey Enrollment. Los desarrolladores están en desacuerdo sobre si 
             * los nombres de tabla deben ser plurales o no. En este tutorial se usa 
             * la forma singular, pero lo importante es que puede seleccionar cualquier 
             * forma que prefiera incluyendo u omitiendo esta línea de código.
             */
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}