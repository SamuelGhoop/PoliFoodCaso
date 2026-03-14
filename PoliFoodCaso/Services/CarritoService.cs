using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.Services
{
    public class CarritoService: ICarritoService
    {
        private readonly ApplicationDbContext _context;

        public CarritoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<CarritoItem>> GetByStudent(string studentId)
        {
            return await _context.CarritoItem
                .Where(c => c.studentId == studentId)
                .Include(c => c.producto)
                .ToListAsync();
        }

        public async Task<CarritoItem> AddItem(CarritoItem newItem)
        {
            _context.CarritoItem.Add(newItem);
            await _context.SaveChangesAsync();
            return newItem;
        }

        public async Task<bool> UpdateItem(Guid id, int cantidad)
        {
            var itemExiste = await _context.CarritoItem.FindAsync(id);
            if (itemExiste == null) return false;

            itemExiste.cantidad = cantidad;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItem(Guid id)
        {
            var itemExiste = await _context.CarritoItem.FindAsync(id);
            if (itemExiste == null) return false;
            _context.CarritoItem.Remove(itemExiste);
            await _context.SaveChangesAsync();
            return true;
        }
    }

}
