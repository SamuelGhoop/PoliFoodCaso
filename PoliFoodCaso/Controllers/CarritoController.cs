using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models.DTOs;
using System.Security.Claims;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Student")]
    public class CarritoController : ControllerBase
    {
        private readonly ICarritoService _carritoService;

        public CarritoController(ICarritoService carritoService)
        {
            _carritoService = carritoService;
        }

        private string? GetStudentId() => User.FindFirstValue(ClaimTypes.NameIdentifier);

        [HttpGet]
        public async Task<IActionResult> GetMine()
        {
            var studentId = GetStudentId();
            if (studentId == null) return Unauthorized();
            return Ok(await _carritoService.GetByStudent(studentId));
        }

        [HttpPost]
        public async Task<IActionResult> AddItem([FromBody] CarritoItemDTO dto)
        {
            var studentId = GetStudentId();
            if (studentId == null) return Unauthorized();

            try
            {
                var item = await _carritoService.AddOrIncrement(studentId, dto.productoId, dto.cantidad);
                return Ok(item);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{id}")]
        public async Task<IActionResult> UpdateItem(Guid id, [FromBody] int cantidad)
        {
            var studentId = GetStudentId();
            if (studentId == null) return Unauthorized();

            try
            {
                return await _carritoService.UpdateItem(studentId, id, cantidad)
                    ? Ok("Cantidad actualizada en el carrito")
                    : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveItem(Guid id)
        {
            var studentId = GetStudentId();
            if (studentId == null) return Unauthorized();

            return await _carritoService.RemoveItem(studentId, id)
                ? Ok("Producto eliminado del carrito")
                : NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Clear()
        {
            var studentId = GetStudentId();
            if (studentId == null) return Unauthorized();
            await _carritoService.Clear(studentId);
            return Ok("Carrito vaciado");
        }
    }
}
