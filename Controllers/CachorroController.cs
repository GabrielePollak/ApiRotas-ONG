using ApiRotas_ONGG.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ApiRotas_ONGG.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CachorroController : ControllerBase
    {
        List<Cachorro> _dogs = new List<Cachorro>();

        public CachorroController()
        {
            Cachorro c = new Cachorro { Nome = "Joaquim", Idade = 3, Apelido = "Jojo" };

            _dogs.Add(c);
        }

        [HttpGet]
        public List<Cachorro> GetDog()
        {
            return _dogs;
        }
        [HttpGet("Nome/{n}", Name = "BuscaNome")]
        public Cachorro GetDogName(string n)
        {
            return _dogs.Find(x => x.Nome == n);
        }

        [HttpPost("/{n}/{i}/{a}")]
        public ActionResult AdicionaDog(string n, int i, string a)
        {
            var dog = new Cachorro() { Nome = n, Idade = i, Apelido = a };
            _dogs.Add(dog);
            return CreatedAtRoute("BuscaNome", dog.Nome);
        }

    }
}
