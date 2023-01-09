using miCondominio.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace miCondominio.Controllers
{
    public class PersonaController : Controller
    {
        private readonly miCondominioContext _context;

        public PersonaController(miCondominioContext context)
        {
            _context = context;
        }

        // GET: api/<PersonaController>
        [HttpGet]
        public IEnumerable<Persona> Get()
        {
            return _context.Set<Persona>();
        }

        // GET api/<PersonaController>/5
        [HttpGet("{DNI}")]
        public IActionResult Get(int DNI)
        {
            var Persona = _context.Set<Persona>().FirstOrDefault(x => x.Dni == DNI);

            if (Persona == null)
            {
                return NotFound(new
                {
                    DNI = DNI,
                    Message = "No se encontró"
                });
            }

            return Ok(Persona);
        }

        // POST api/<PersonaController>
        [HttpPost("PostPersona")]
        public IActionResult Post(Persona oPersona)
        {
            var PersonaEntity = new Persona
            {
                Dni = oPersona.Dni,
                Nombres = oPersona.Nombres,
                ApellidoPat = oPersona.ApellidoPat,
                ApellidoMat = oPersona.ApellidoMat,
                Edad = oPersona.Edad,
                IdDepartamento = oPersona.IdDepartamento,

            };


            _context.Set<Persona>().Add(PersonaEntity);

            _context.SaveChanges();

            return Ok(PersonaEntity);
        }
        // PUT api/<PersonaController>/1
        [HttpPut("{DNI}")]
        public IActionResult Put(int DNI, [FromBody] Persona oPersona)
        {
            var item = _context.Set<Persona>().FirstOrDefault(x => x.Dni == DNI);

            if (item == null)
            {
                return NotFound(new
                {
                    Id = DNI,
                    Message = "No se encontró"
                });
            }

            item.Nombres = oPersona.Nombres;
            item.ApellidoPat = oPersona.ApellidoPat;
            item.ApellidoMat = oPersona.ApellidoMat;
            item.Edad = oPersona.Edad;
            item.IdDepartamento = oPersona.IdDepartamento;

            _context.SaveChanges();

            return Ok(item);
        }

        // DELETE api/<PersonaController>/5
        [HttpDelete("{DNI}")]
        public IActionResult Delete(int DNI)
        {
            var item = _context.Set<Persona>().FirstOrDefault(x => x.Dni == DNI);

            if (item == null)
            {
                return NotFound(new
                {
                    Id = DNI,
                    Message = "No se encontró"
                });
            }

            item.ApellidoMat = "Cesado";

            _context.SaveChanges();

            return Ok();
        }

    }
}
