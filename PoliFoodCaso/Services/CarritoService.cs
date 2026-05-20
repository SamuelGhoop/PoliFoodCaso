using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;

namespace PoliFoodCaso.Services
{
    public class CarritoService : ICarritoService
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

        public async Task<CarritoItem> AddOrIncrement(string studentId, Guid productoId, int cantidad)
        {
            //Validar producto
            var producto = await _context.Producto.FindAsync(productoId);
            if (producto == null)
                throw new Exception($"El producto {productoId} no existe.");
            if (!producto.disponible)
                throw new Exception($"El producto {producto.nombre_producto} no está disponible.");
            if (producto.existencias <= 0)
                throw new Exception($"El producto {producto.nombre_producto} está agotado.");

            //Buscar duplicado
            var existing = await _context.CarritoItem
                .FirstOrDefaultAsync(c => c.studentId == studentId && c.productoId == productoId);

            if (existing != null)
            {
                var nuevaCantidad = existing.cantidad + cantidad;
                if (nuevaCantidad > producto.existencias)
                    throw new Exception($"Solo hay {producto.existencias} unidades de {producto.nombre_producto}.");
                existing.cantidad = nuevaCantidad;
                await _context.SaveChangesAsync();
                return existing;
            }

            if (cantidad > producto.existencias)
                throw new Exception($"Solo hay {producto.existencias} unidades de {producto.nombre_producto}.");

            var nuevo = new CarritoItem
            {
                studentId = studentId,
                productoId = productoId,
                cantidad = cantidad
            };
            _context.CarritoItem.Add(nuevo);
            await _context.SaveChangesAsync();
            return nuevo;
        }

        public async Task<bool> UpdateItem(string studentId, Guid id, int cantidad)
        {
            var item = await _context.CarritoItem
                .Include(c => c.producto)
                .FirstOrDefaultAsync(c => c.id_carrito_item == id && c.studentId == studentId);
            if (item == null) return false;

            if (cantidad <= 0)
            {
                _context.CarritoItem.Remove(item);
            }
            else
            {
                if (item.producto != null && cantidad > item.producto.existencias)
                    throw new Exception($"Solo hay {item.producto.existencias} unidades de {item.producto.nombre_producto}.");
                item.cantidad = cantidad;
            }
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RemoveItem(string studentId, Guid id)
        {
            var item = await _context.CarritoItem
                .FirstOrDefaultAsync(c => c.id_carrito_item == id && c.studentId == studentId);
            if (item == null) return false;
            _context.CarritoItem.Remove(item);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> Clear(string studentId)
        {
            var items = _context.CarritoItem.Where(c => c.studentId == studentId);
            _context.CarritoItem.RemoveRange(items);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
