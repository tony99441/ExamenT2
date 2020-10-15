using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT2.Models
{
    public class DetalleUsuarioPokemon
    {
        public int Id { get; set; }
        public int IdUsuario{ get; set; }
        public int IdPokemon { get; set; }

        public Pokemon pokemon { get; set; }
        public Usuario usuario{ get; set; }
    }
}
