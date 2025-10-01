using Microsoft.AspNetCore.Mvc;
using Application.Interfaces;
using Application.DTOs;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AutomovilController : ControllerBase
    {
        private readonly IAutomovilService _automovilService;

        public AutomovilController(IAutomovilService automovilService)
        {
            _automovilService = automovilService;
        }

        // 1. CREATE - POST: /api/v1/automovil
        [HttpPost]
        public async Task<ActionResult<AutomovilDto>> CrearAutomovil([FromBody] CrearAutomovilDto dto)
        {
            var automovil = await _automovilService.CrearAsync(dto);
            return CreatedAtAction(nameof(ObtenerPorId), new { id = automovil.Id }, automovil);
        }

        // 2. DELETE - DELETE: /api/v1/automovil/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> EliminarAutomovil(int id)
        {
            var eliminado = await _automovilService.EliminarAsync(id);
            if (!eliminado)
                return NotFound(new { mensaje = "Automóvil no encontrado." });

            return Ok(new { mensaje = "Automóvil eliminado correctamente." });
        }

        // 3. UPDATE - PUT: /api/v1/automovil/{id}
        [HttpPut("{id}")]
        public async Task<ActionResult<AutomovilDto>> ActualizarAutomovil(int id, [FromBody] ActualizarAutomovilDto dto)
        {
            var actualizado = await _automovilService.ActualizarAsync(id, dto);
            if (actualizado == null)
                return NotFound(new { mensaje = "Automóvil no encontrado." });

            return Ok(actualizado);
        }

        // 4. GET BY ID - GET: /api/v1/automovil/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<AutomovilDto>> ObtenerPorId(int id)
        {
            var automovil = await _automovilService.ObtenerPorIdAsync(id);
            if (automovil == null)
                return NotFound(new { mensaje = "Automóvil no encontrado." });

            return Ok(automovil);
        }

        // 5. GET BY CHASIS - GET: /api/v1/automovil/chasis/{numeroChasis}
        [HttpGet("chasis/{numeroChasis}")]
        public async Task<ActionResult<AutomovilDto>> ObtenerPorChasis(string numeroChasis)
        {
            var automovil = await _automovilService.ObtenerPorChasisAsync(numeroChasis);
            if (automovil == null)
                return NotFound(new { mensaje = "Automóvil no encontrado." });

            return Ok(automovil);
        }

        // 6. GET ALL - GET: /api/v1/automovil
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AutomovilDto>>> ObtenerTodos()
        {
            var autos = await _automovilService.ObtenerTodosAsync();
            return Ok(autos);
        }
    }
}