using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using RegistroPersona.Entidades;
using Microsoft.EntityFrameworkCore;

//using RegistroPersona.BLL;

namespace RegistroPersona
{ 
    public class Contexto : DbContext
    {
        public DbSet<Persona> Persona { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ///optionsBuilder.UseSqlServer(@"Server = .\SqlExpress; Database = PersonasDb; Trusted_Connection = True; ");
            optionsBuilder.UseSqlite(@" Data Source = Persona.db");
        }

    }

}


