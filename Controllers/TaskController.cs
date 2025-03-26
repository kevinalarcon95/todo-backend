using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using todoApp.Data;
using todoApp.Models;

namespace todoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskApiController : ControllerBase
    {
        private readonly TaskContext _context;

        public TaskApiController(TaskContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna la lista de tareas en JSON.
        /// </summary>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.Task>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        /// <summary>
        /// Retorna una tarea específica por ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.Task>> GetTaskById(int id)
        {
            var task = await _context.Tasks.FindAsync(id); // Cambiado de "Task" a "Tasks"
            if (task == null)
            {
                return NotFound();
            }
            return task!;
        }

        /// <summary>
        /// Crea una nueva tarea.
        /// </summary>
        [HttpPost]
        public async Task<ActionResult<Models.Task>> CreateTask(Models.Task task)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value != null && ms.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    Message = "Errores de validación.",
                    Errors = errors
                });
            }

            task.CreatedAt = DateTime.UtcNow;
            task.CompletedAt = DateTime.UtcNow;
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTaskById), new { id = task.Id }, task);
        }

        /// <summary>
        /// Actualiza una tarea existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTask(int id, [FromBody] todoApp.Models.Task task)
        {
            if (id != task.Id)
            {
                return BadRequest(new { Message = "El ID de la tarea no coincide." });
            }

            if (!ModelState.IsValid)
            {
                var errors = ModelState
                    .Where(ms => ms.Value != null && ms.Value.Errors.Count > 0)
                    .ToDictionary(
                        kvp => kvp.Key,
                        kvp => kvp.Value!.Errors.Select(e => e.ErrorMessage).ToArray()
                    );

                return BadRequest(new
                {
                    Message = "Errores de validación.",
                    Errors = errors
                });
            }

            _context.Entry(task).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Tasks.Any(e => e.Id == id))
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

        /// <summary>
        /// Elimina una tarea.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            var task = await _context.Tasks.FindAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
