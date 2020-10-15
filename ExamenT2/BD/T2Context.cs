using ExamenT2.BD.Mapeo;
using ExamenT2.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT2.BD
{
    public class T2Context : DbContext 
    {

        public DbSet<Usuario> usuarios { get; set; }
        public DbSet<Pokemon> pokemons { get; set; }
        public DbSet<DetalleUsuarioPokemon> detalleUsuarioPokemons{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                "Server=DESKTOP-BIGBBRB\\SQLEXPRESS;Database=ExamenT2;Trusted_Connection=True;MultipleActiveResultSets=true");
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UsuarioConfiguration());
            modelBuilder.ApplyConfiguration(new PokemonConfiguration());
            modelBuilder.ApplyConfiguration(new DetalleUsuarioPokemonConfiguration());



        }

    }
}
