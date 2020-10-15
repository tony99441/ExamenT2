using ExamenT2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT2.BD.Mapeo
{
    public class DetalleUsuarioPokemonConfiguration :IEntityTypeConfiguration<DetalleUsuarioPokemon>
    {

     
        public void Configure(EntityTypeBuilder<DetalleUsuarioPokemon> builder)
        {
            builder.ToTable("DetalleUsuarioPokemons");
            builder.HasKey(o => o.Id);

            builder.HasOne(o => o.usuario).WithMany(o => o.DetalleUsuarioPokemons).HasForeignKey(o => o.IdUsuario);

            builder.HasOne(o => o.pokemon).WithMany(o => o.DetalleUsuarioPokemons).HasForeignKey(o => o.IdPokemon);


        }
    }
}
