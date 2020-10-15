using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using ExamenT2.BD;
using ExamenT2.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace ExamenT2.Controllers

{

    public class AuthController : Controller
    {
        T2Context _context = new T2Context();
        private IConfiguration _configuration;
        public AuthController(IConfiguration _configuration)
        {
            this._configuration = _configuration;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(String username, String password)
        {
            var userv = _context.usuarios.FirstOrDefault(o => o.Username == username && o.Password == password);

            if (userv == null)
                return View();


            //     HttpContext.Session.Set("sessionUser", userv);
            HttpContext.Session.Set("sessionUser", userv);

            var claims = new List<Claim>()
           {
               new Claim(ClaimTypes.Name, userv.Username),
           };

            var userIdentity = new ClaimsIdentity(claims, "login");
            var principal = new ClaimsPrincipal(userIdentity);

            HttpContext.SignInAsync(principal);

            return RedirectToAction("TodosLosPokemons", "Pokemon");
        }
    }
}
