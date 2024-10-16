using GestionTareasAPI.DataAccess;
using GestionTareasAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GestionTareasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize] //Requiere autenticación para todos los endpoints
    public class TareasController : ControllerBase
    {
        private readonly TareasContext _context;

        public TareasController(TareasContext context)
        {
            _context = context;
        }

        //GET: api/Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Tarea>>> ObtenerTareas()
        {
            return await _context.Tareas.ToListAsync();
        }

        //GET: api/Tareas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tarea>> ObtenerTareas(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);

            if (tarea == null)
            {
                return NotFound();
            }
            return tarea;
        }

        //POST: api/Tareas
        [HttpPost]
        public async Task<ActionResult<Tarea>> EnviarTarea(Tarea tarea)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(ObtenerTareas), new { id = tarea.Id}, tarea);
        }

        //PUT: api/Tareas/5
        [HttpPut("{id}")]
        public async Task<ActionResult>ActualizarTarea(int id, Tarea tarea)
        {
            if (id != tarea.Id)
            {
                return BadRequest();
            }

            _context.Entry(tarea).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TareaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        //DELETE: api/Tareas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult> EliminarTarea(int id)
        {
            var tarea = await _context.Tareas.FindAsync(id);
            if (tarea == null)
            {
                return NotFound();
            }

            _context.Tareas.Remove(tarea);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TareaExists(int id)
        {
            return _context.Tareas.Any(t => t.Id == id);
        }
    }
}
