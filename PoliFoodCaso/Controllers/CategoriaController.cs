using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using System.Security.Claims;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Vendor")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;
        private readonly ApplicationDbContext _context;

        public CategoriaController(ICategoriaService categoriaService, ApplicationDbContext context)
        {
            _categoriaService = categoriaService;
            _context = context;
        }

        private async Task<bool> VendorOwnsTienda(string userId, Guid tiendaId)
        {
            return await _context.Tienda.AnyAsync(t => t.id_tienda == tiendaId && t.vendorId == userId);
        }

        [HttpGet("{tiendaId}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetByTienda(Guid tiendaId) =>
            Ok(await _categoriaService.GetByTienda(tiendaId));

        [HttpGet("detalle/{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetById(Guid id)
        {
            var categoria = await _categoriaService.GetById(id);
            return categoria != null ? Ok(categoria) : NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Categoria newCategoria)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();
            if (!await VendorOwnsTienda(userId, newCategoria.tiendaId))
                return Forbid();

            var createdCategoria = await _categoriaService.Create(newCategoria);
            return CreatedAtAction(nameof(GetById), new { id = createdCategoria.id_categoria }, createdCategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Categoria editedCategoria)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var existente = await _categoriaService.GetById(id);
            if (existente == null) return NotFound();
            if (!await VendorOwnsTienda(userId, existente.tiendaId))
                return Forbid();

            //Preservar tiendaId original
            editedCategoria.tiendaId = existente.tiendaId;
            return await _categoriaService.Update(id, editedCategoria) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (userId == null) return Unauthorized();

            var existente = await _categoriaService.GetById(id);
            if (existente == null) return NotFound();
            if (!await VendorOwnsTienda(userId, existente.tiendaId))
                return Forbid();

            return await _categoriaService.ChangeStatus(id) ? Ok("Se ha cambiado el estado de la categoría") : NotFound();
        }
    }
}
