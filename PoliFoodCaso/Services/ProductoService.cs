using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace PoliFoodCaso.Services
{
    public class ProductoService : IProductoService
    {
        private readonly ApplicationDbContext _context;

        public ProductoService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> GetByTienda(Guid tiendaId)
        {
            return await _context.Producto
                .Where(p => p.categoria.tiendaId == tiendaId && p.isActive == 1)
                .Include(p => p.categoria)
                .ToListAsync();
        }

        public async Task<Producto?> GetById(Guid id) => await _context.Producto.FindAsync(id);


        public async Task<Producto> Create(Producto newProducto)
        {
            //Agregamos el registro a la lista
            _context.Producto.Add(newProducto);
            await _context.SaveChangesAsync();
            return newProducto;
        }

        public async Task<bool> Update(Guid id, Producto editedProducto)
        {
            //validar la existencia de un ente supremo
            var productoExiste = await GetById(id);
            if (productoExiste == null) return false;
            productoExiste.nombre_producto = editedProducto.nombre_producto;
            productoExiste.descripcion = editedProducto.descripcion;
            productoExiste.precio = editedProducto.precio;
            productoExiste.imagen_url = editedProducto.imagen_url;
            productoExiste.disponible = editedProducto.disponible;
            productoExiste.minutos_preparacion = editedProducto.minutos_preparacion;

            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ChangeStatus(Guid id)
        {
            var productoExiste = await GetById(id);
            if (productoExiste == null) return false;

            productoExiste.isActive = productoExiste.isActive == 1 ? 0 : 1;

            await _context.SaveChangesAsync();
            return true;
        }
    }
}
