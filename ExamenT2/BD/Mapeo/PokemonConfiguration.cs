using ExamenT2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT2.BD.Mapeo
{
    public class PokemonConfiguration:  IEntityTypeConfiguration<Pokemon>
    {

        public void Configure(EntityTypeBuilder<Pokemon> builder)
        {
            builder.ToTable("Pokemon");
            builder.HasKey(o => o.Id);

            builder.HasMany(o => o.DetalleUsuarioPokemons).WithOne(o => o.pokemon).HasForeignKey(o => o.IdPokemon);
        }
    }
}
