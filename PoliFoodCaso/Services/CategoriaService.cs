using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly ApplicationDbContext _context;

        public CategoriaService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Categoria>> GetByTienda(Guid tiendaId)
        {
            return await _context.Categoria
                .Where(c => c.tiendaId == tiendaId && c.isActive == 1)
                .ToListAsync();
        }

        public async Task<Categoria?> GetById(Guid id) => await _context.Categoria.FindAsync(id);

        public async Task<Categoria> Create(Categoria newCategoria)
        {
            _context.Categoria.Add(newCategoria);
            await _context.SaveChangesAsync();
            return newCategoria;
        }

        public async Task<bool> Update(Guid id, Categoria editedCategoria)
        {
            var categoriaExiste = await GetById(id);
            if (categoriaExiste == null) return false;

            categoriaExiste.nombre_categoria = editedCategoria.nombre_categoria;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            var categoriaExiste = await GetById(id);
            if (categoriaExiste == null) return false;

            categoriaExiste.isActive = categoriaExiste.isActive == 1 ? 0 : 1;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
