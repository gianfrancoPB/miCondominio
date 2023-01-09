using miCondominio.Models;
using Microsoft.AspNetCore.Mvc;

namespace miCondominio.Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly miCondominioContext _context;

        public DepartamentoController(miCondominioContext context)
        {
            _context = context;
        }

        // GET: api/<DepartamentoController>
        [HttpGet]
        public IEnumerable<Departamento> Get()
        {
            return _context.Set<Departamento>();
        }

        // GET api/<DepartamentoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var Departamento = _context.Set<Departamento>().FirstOrDefault(x => x.IdDepartamento == id);

            if (Departamento == null)
            {
                return NotFound(new
                {
                    Id = id,
                    Message = "No se encontró"
                });
            }

            return Ok(Departamento);
        }


        // POST api/<DepartamentoController>
        [HttpPost("Post")]
        public IActionResult Post(Departamento oDepartamento)
        {
            var DepartamentoEntity = new Departamento
            {   IdDepartamento      = oDepartamento.IdDepartamento,
                NumeroPiso          = oDepartamento.NumeroPiso,
                NumeroDep           = oDepartamento.NumeroDep,
                CantidadCuartos     = oDepartamento.CantidadCuartos,
                CantidadBaños       = oDepartamento.CantidadBaños,
                BAmoblado           = oDepartamento.BAmoblado,

            };


            _context.Set<Departamento>().Add(DepartamentoEntity);

            _context.SaveChanges();

            return Ok(DepartamentoEntity);
        }

        // PUT api/<DepartamentoController>/1
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Departamento oDepartamento)
        {            
            var item = _context.Set<Departamento>().FirstOrDefault(x => x.IdDepartamento == id);

            if (item == null)
            {
                return NotFound(new
                {
                    Id = id,
                    Message = "No se encontró"
                });
            }

            item.NumeroPiso = oDepartamento.NumeroPiso;
            item.NumeroDep = oDepartamento.NumeroDep;
            item.CantidadCuartos = oDepartamento.CantidadCuartos;
            item.CantidadBaños = oDepartamento.CantidadBaños;
            item.BAmoblado = oDepartamento.BAmoblado;

            _context.SaveChanges();

            return Ok(item);
        }

        // DELETE api/<DepartamentoController>/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var item = _context.Set<Departamento>().Find(id);

            if (item == null)
            {
                return NotFound(new
                {
                    Id = id,
                    Message = "No se encontró"
                });
            }

            item.BAmoblado = false;

            _context.SaveChanges();

            return Ok();
        }

    }
}
