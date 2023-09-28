using Microsoft.AspNetCore.Mvc;
using Academic.Shared.Entities;
using Academic.API.Data;
using Microsoft.EntityFrameworkCore;

namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/Participantes")]
    public class ParticipanteController:ControllerBase
    {
        private readonly DataContext _context;

        public ParticipanteController(DataContext context)
        {



            _context = context;
        }


        //get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Participantes.ToListAsync());
        }


        //Get por parámetro
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var participante = await _context.Participantes.FirstOrDefaultAsync(x => x.Id == id);
            if (participante == null)
            {

                return NotFound();
            }

            return Ok(participante);

        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Participante participante)
        {

            _context.Add(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);
        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(Participante participante)
        {

            _context.Update(participante);
            await _context.SaveChangesAsync();
            return Ok(participante);
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
