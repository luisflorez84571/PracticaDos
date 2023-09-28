using Microsoft.AspNetCore.Mvc;
using Academic.Shared.Entities;
using Academic.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/Programaciones")]
    public class ProgramacionController : ControllerBase
    {
        private readonly DataContext _context;

        public ProgramacionController(DataContext context)
        {



            _context = context;
        }


        //get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Programaciones.ToListAsync());
        }


        //Get por parámetro
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var programacion = await _context.Programaciones.FirstOrDefaultAsync(x => x.Id == id);
            if (programacion == null)
            {

                return NotFound();
            }

            return Ok(programacion);

        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Programacion programacion)
        {

            _context.Add(programacion);
            await _context.SaveChangesAsync();
            return Ok(programacion);
        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(Programacion programacion)
        {

            _context.Update(programacion);
            await _context.SaveChangesAsync();
            return Ok(programacion);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Participantes.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {

                return NotFound();

            }

            return NoContent();



        }
    }
}
