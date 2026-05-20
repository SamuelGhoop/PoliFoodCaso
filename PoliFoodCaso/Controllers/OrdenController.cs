using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using PoliFoodCaso.Models.DTOs;
using System.Security.Claims;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdenController : ControllerBase
    {
        private readonly IOrdenService _ordenService;
        private readonly ApplicationDbContext _context;

        public OrdenController(IOrdenService ordenService, ApplicationDbContext context)
        {
            _ordenService = ordenService;
            _context = context;
        }

        [HttpPost("checkout")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create([FromBody] CheckoutDTO checkout)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null) return Unauthorized();

            try
            {
                var orden = await _ordenService.Create(checkout, studentId);
                return Ok(orden);
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpPatch("{ordenId}/confirmar-pago")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> ConfirmarPago(Guid ordenId)
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null) return Unauthorized();

            var orden = await _context.Orden.FindAsync(ordenId);
            if (orden == null) return NotFound();
            if (orden.studentId != studentId) return Forbid();

            return await _ordenService.ConfirmarPago(ordenId) ? Ok("Pago confirmado") : NotFound();
        }

        [HttpGet("student")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> GetByStudent()
        {
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null) return Unauthorized();

            return Ok(await _ordenService.GetByStudent(studentId));
        }

        [HttpGet("tienda/{tiendaId}")]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> GetByTienda(Guid tiendaId)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var esDueno = await _context.Tienda
                .AnyAsync(t => t.id_tienda == tiendaId && t.vendorId == userId);
            if (!esDueno) return Forbid();

            return Ok(await _ordenService.GetByTienda(tiendaId));
        }

        [HttpPatch("{ordenId}/estado")]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> UpdateEstado(Guid ordenId, [FromBody] EstadoOrden editedEstado)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var orden = await _context.Orden.FindAsync(ordenId);
            if (orden == null) return NotFound();

            var esDueno = await _context.Tienda
                .AnyAsync(t => t.id_tienda == orden.tiendaId && t.vendorId == userId);
            if (!esDueno) return Forbid();

            try
            {
                return await _ordenService.UpdateEstado(ordenId, editedEstado) ? Ok("Estado actualizado") : NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(new { message = ex.Message });
            }
        }

        [HttpGet("eta/{tiendaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetETA(Guid tiendaId)
        {
            var eta = await _ordenService.GetETA(tiendaId);
            return Ok(new { minutos_estimados = eta });
        }
    }
}
