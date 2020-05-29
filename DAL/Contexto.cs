using Microsoft.EntityFrameworkCore;
using RegistroPersona.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace RegistroPersona.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(@"Data Source=C:\SQLlite\RPersonas.db");
        }

    }
}
