using Academic.Shared.Entities;
using Academic.API.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace Academic.API.Controllers
{
    [ApiController]
    [Route("api/Eventos")]
    public class EventoController:ControllerBase
    {
        private readonly DataContext _context;

        public EventoController(DataContext context)
        {



            _context = context;
        }


        //get por lista
        [HttpGet]
        public async Task<ActionResult> Get()
        {
            return Ok(await _context.Eventos.ToListAsync());
        }


        //Get por parámetro
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {

            var evento = await _context.Eventos.FirstOrDefaultAsync(x => x.Id==id);
            if (evento == null)
            {

                return NotFound();
            }

            return Ok(evento);

        }

        // Post- Create
        [HttpPost]
        public async Task<ActionResult> Post(Evento evento)
        {

            _context.Add(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }

        // Put-- update
        [HttpPut]
        public async Task<ActionResult> Put(Evento evento)
        {

            _context.Update(evento);
            await _context.SaveChangesAsync();
            return Ok(evento);
        }


        [HttpDelete("{id:int}")]
        public async Task<ActionResult> Delete(int id)
        {

            var filaafectada = await _context.Eventos.Where(x => x.Id == id).ExecuteDeleteAsync();

            if (filaafectada == 0)
            {

                return NotFound();

            }

            return NoContent();



        }

    }
}
