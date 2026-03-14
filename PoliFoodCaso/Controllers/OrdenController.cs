using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using PoliFoodCaso.Models.DTOs;
using System.Security.Claims;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class OrdenController : Controller
    {
        private readonly IOrdenService _ordenService;

        public OrdenController(IOrdenService ordenService)
        {
            _ordenService = ordenService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("checkout")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> Create([FromBody] CheckoutDTO checkout)
        {
            //Obtener el studentId del token JWT
            var studentId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (studentId == null) return Unauthorized();

            var orden = await _ordenService.Create(checkout, studentId);
            return Ok(orden);
        }

        [HttpPatch("{ordenId}/confirmar-pago")]
        [Authorize(Roles = "Student")]
        public async Task<IActionResult> ConfirmarPago(Guid ordenId)
        {
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
            return Ok(await _ordenService.GetByTienda(tiendaId));
        }

        [HttpPatch("{ordenId}/estado")]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> UpdateEstado(Guid ordenId, [FromBody] EstadoOrden editedEstado)
        {
            return await _ordenService.UpdateEstado(ordenId, editedEstado) ? Ok("Estado actualizado") : NotFound();
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