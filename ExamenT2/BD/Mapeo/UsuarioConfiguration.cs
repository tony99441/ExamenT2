using ExamenT2.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT2.BD.Mapeo
{
    public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(o => o.Id);


            builder.HasMany(o => o.DetalleUsuarioPokemons).WithOne(o => o.usuario).HasForeignKey(o => o.IdUsuario);
        }
    }
}
