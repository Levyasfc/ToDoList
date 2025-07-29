using Microsoft.AspNetCore.Mvc;
using ToDoListPractice1.Models;
using Microsoft.EntityFrameworkCore;
using ToDoListPractice1.Data;


namespace ToDoListPractice1.Controllers
{

    //Creacion de un controlador para manejar las tareas IMPORTANTE el colocar 
    // ApiController para que se pueda manejar las peticiones de forma correcta
    // Y la ruta del controlador

    [ApiController]
    [Route("[controller]")]
    public class TareasController: ControllerBase
    {
        private readonly ToDoContext _context; // Instancia de la clase ToDoContext para acceder a la base de datos

        public TareasController(ToDoContext context)
        {
            _context = context;
        }

        // Es la opcion del crud de GET

        #region ObtenerTareas

        [HttpGet("/Tareas")]

        public async Task<IActionResult> GetTareas() // Si es asincrono el IACTIONRESULT debe ser un TASK ahora
        {
            var tareas = await _context.Tareas.ToListAsync();
            return Ok(tareas);
        }

        #endregion

        // Es la opcion del crud de Post o Publicar por id

        #region CrearTareas

        [HttpPost("/Tareas")]

        public async Task <IActionResult> CrearTarea([FromBody] Tarea tarea)
        {
            _context.Tareas.Add(tarea);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetTareas), new { id = tarea.Id }, tarea);

            /*
             * Al crear la accion de
             * 
             */
        }

        #endregion

        // Es la opcion del crud de Put o Actualizar por id

        #region Actualizar

        [HttpPut("/Tareas/{id}")]

        public async Task<IActionResult> UpdateTarea(int id, [FromBody] Tarea tareaActualizada)
        {
            var tareaExistente = await _context.Tareas.FindAsync(id);
            if (tareaExistente == null)return NotFound("Tarea no encontrada."); // Funcion Rapida

            tareaExistente.Labor = tareaActualizada.Labor;
            tareaExistente.Descripcion = tareaActualizada.Descripcion;
            tareaExistente.Completado = tareaActualizada.Completado;

            await _context.SaveChangesAsync();
            return Ok(tareaExistente);

        }

        #endregion

        // Es la opcion del crud de Delete o Eliminar por id

        #region EliminarTarea

        [HttpDelete("/Tareas/{id}")]

        public async Task<IActionResult> DeleteTarea (int id)
        {
            var tareaExistente = await _context.Tareas.FindAsync(id);
            if (tareaExistente == null) return NotFound("Tarea no encontrada.");

            _context.Tareas.Remove(tareaExistente);
            await _context.SaveChangesAsync();
            return NoContent(); // Devuelve un 204 No Content, indicando que la tarea fue eliminada correctamente.
        }


        #endregion


    }
}
