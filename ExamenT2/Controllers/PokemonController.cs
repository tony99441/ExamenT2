using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ExamenT2.BD;
using ExamenT2.Extensions;
using ExamenT2.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewFeatures;

namespace ExamenT2.Controllers
{
    [Authorize]
    public class PokemonController : Controller
    {
        private T2Context _context;
        private IHostingEnvironment env;

        public PokemonController(IHostingEnvironment env)
        {
            _context = new T2Context();
            this.env = env;
        }




        public IActionResult TodosLosPokemons() {
            var AllPokemons = _context.pokemons.ToList();
            return View(AllPokemons);
        }

        public IActionResult RegistrarPokemons() {
         
            var tipos = Tipo();
            ViewBag.tipos = tipos;
            return View(new Pokemon());
        }
        public IActionResult RegistrarPokemonsP(Pokemon pokemon, IFormFile Imagen)
        {
          
            if (Imagen.Length > 0)
            {
                var filePath = Path.Combine(env.WebRootPath, "images", Imagen.FileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    Imagen.CopyTo(stream);
                }
            }
            pokemon.Imagen = Imagen.FileName;

            _context.pokemons.Add(pokemon);
            _context.SaveChanges();

            return RedirectToAction("TodosLosPokemons");
        }
        public IActionResult MisPokemones() {
            var user = HttpContext.Session.Get<Usuario>("sessionUser");
            var detalle = _context.detalleUsuarioPokemons.Where(o => o.IdUsuario == user.Id).ToList().Select(o => o.IdPokemon).ToList();
            var pokemon = _context.pokemons.ToList();
            List<Pokemon> misPokemons = new List<Pokemon>();
            foreach ( var items in detalle) {
               var  pokemonAgregar = pokemon.Where(o => o.Id == items).FirstOrDefault();
                misPokemons.Add(pokemonAgregar);
            }
           
            ViewBag.Entrenador = user;
            ViewBag.MisPokemones = misPokemons;
            return View(pokemon);
        }

        public IActionResult CapturarPokemon(int IdPokemon) {

            var user = HttpContext.Session.Get<Usuario>("sessionUser");
            DetalleUsuarioPokemon nuevopokemon = new DetalleUsuarioPokemon();
            nuevopokemon.IdPokemon = IdPokemon;
            nuevopokemon.IdUsuario = user.Id;
            _context.detalleUsuarioPokemons.Add(nuevopokemon);
            _context.SaveChanges();
            return RedirectToAction("TodosLosPokemons");
        }

        public IActionResult EliminarPokemon(int IdPokemon)
        {

            var user = HttpContext.Session.Get<Usuario>("sessionUser");
            var pokemonEliminar = _context.detalleUsuarioPokemons.Where(o => o.IdPokemon == IdPokemon && o.IdUsuario == user.Id).FirstOrDefault();
            _context.detalleUsuarioPokemons.Remove(pokemonEliminar);
            _context.SaveChanges();
            return RedirectToAction("TodosLosPokemons");
        }




        public List<string> Tipo()
        {
            return new List<string> {
            "Agua","Fuego", "Tierra","Fantasma","Volador"
            };

        }
    }
}
