using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PoliFoodCaso.Services
{
    public class TiendaService : ITiendaService
    {
        private readonly ApplicationDbContext _context;

        public TiendaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Tienda>> GetAll()
        {
            return await _context.Tienda.Where(e => e.isActive == 1).ToListAsync();
        }

        public async Task<Tienda?> GetById(Guid id) => await _context.Tienda.FindAsync(id);

        public async Task<bool> Update(Guid id, Tienda editedTienda)
        {
            //validar la existencia de un ente supremo
            var tiendaExiste = await GetById(id);
            if (tiendaExiste == null) return false;

            tiendaExiste.nombre_tienda = editedTienda.nombre_tienda;
           

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            // Verificamos si existe o no el registro
            var existe = await GetById(id);
            if (existe == null) return false;

            existe.isActive = existe.isActive == 1 ? 0 : 1;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
