using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TiendaController : Controller
    {
        private readonly ITiendaService _tiendaService;

        public TiendaController(ITiendaService tiendaService)
        {
            _tiendaService = tiendaService;
        }

        public IActionResult Index()
        {
            return View();
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
            return await _tiendaService.Update(id, tienda) ? NoContent() : NotFound();
        }

        [HttpPatch("{id}/change-status")]
        [Authorize(Roles = "Admin,Vendor")]
        public async Task<IActionResult> ChangeStatus(Guid id)
        {
            return await _tiendaService.ChangeStatus(id) ? Ok("Se ha cambiado el estado de la tienda") : NotFound();
        }
    }
}