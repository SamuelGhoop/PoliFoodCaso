using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using System.Security.Claims;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : ControllerBase
    {
        private readonly ITiendaService _tiendaService;
        private readonly ApplicationDbContext _context;

        public TiendaController(ITiendaService tiendaService, ApplicationDbContext context)
        {
            _tiendaService = tiendaService;
            _context = context;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAll() => Ok(await _tiendaService.GetAll());

        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var tienda = await _tiendaService.GetById(id);
            return tienda != null ? Ok(tienda) : NotFound();
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "Vendor")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Tienda tienda)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var existente = await _tiendaService.GetById(id);
            if (existente == null) return NotFound();
            if (existente.vendorId != userId)
                return Forbid();

            //Preservar vendorId original para que el body no pueda transferir la tienda
            tienda.vendorId = existente.vendorId;
            return await _tiendaService.Update(id, tienda) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        [Authorize(Roles = "Admin,Vendor")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var isAdmin = User.IsInRole("Admin");
            if (!isAdmin)
            {
                var existente = await _tiendaService.GetById(id);
                if (existente == null) return NotFound();
                if (existente.vendorId != userId) return Forbid();
            }
            return await _tiendaService.ChangeStatus(id) ? Ok("Se ha cambiado el estado de la tienda") : NotFound();
        }
    }
}
