using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ExamenT2.Models
{
    public class Pokemon
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        [Required (ErrorMessage ="Elija un tipo de pokemon")]
        public string Tipo{ get; set; }
        [Required(ErrorMessage = "Elija una imagen")]
        public string Imagen { get; set; }

      
        public List<DetalleUsuarioPokemon> DetalleUsuarioPokemons { get; set; }



    }
}
