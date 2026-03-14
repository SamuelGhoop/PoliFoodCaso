using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Vendor")]
    public class CategoriaController : Controller
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        public IActionResult Index()
        {
            return View();
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
            var createdCategoria = await _categoriaService.Create(newCategoria);
            return CreatedAtAction(nameof(GetById), new { id = createdCategoria.id_categoria }, createdCategoria);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] Categoria editedCategoria)
        {
            return await _categoriaService.Update(id, editedCategoria) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _categoriaService.ChangeStatus(id) ? Ok("Se ha cambiado el estado de la categoría") : NotFound();
        }
    }
}