using Microsoft.EntityFrameworkCore;
using PoliFoodCaso.DAO;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using PoliFoodCaso.Models.DTOs;

namespace PoliFoodCaso.Services
{
    public class OrdenService : IOrdenService
    {
        private readonly ApplicationDbContext _context;

        public OrdenService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Orden> Create(CheckoutDTO checkout, string studentId)
        {
            //Validar que el carrito no esté vacío
            if (checkout.items == null || !checkout.items.Any())
                throw new Exception("El carrito no puede estar vacío.");

            double total = 0;
            int maxMinutos = 0;
            var ordenItems = new List<OrdenItem>();

            foreach (var item in checkout.items)
            {
                //Validar el producto
                var producto = await _context.Producto.FindAsync(item.productoId);
                if (producto == null)
                    throw new Exception($"El producto {item.productoId} no existe.");
                if (!producto.disponible)
                    throw new Exception($"El producto {producto.nombre_producto} no está disponible.");

                //Calcular total
                total += producto.precio * item.cantidad;

                //Obtener el mayor tiempo de preparación
                if (producto.minutos_preparacion > maxMinutos)
                    maxMinutos = producto.minutos_preparacion;

                ordenItems.Add(new OrdenItem
                {
                    productoId = item.productoId,
                    cantidad = item.cantidad,
                    precio_unitario = producto.precio
                });
            }

            //Calcular ETA
            var eta = await GetETA(ordenItems.First().productoId);

            var orden = new Orden
            {
                studentId = studentId,
                tiendaId = (await _context.Producto.Include(p => p.categoria).FirstAsync(p => p.id_producto == checkout.items.First().productoId)).categoria.tiendaId,
                total = total,
                minutos_estimados = maxMinutos + eta,
                estado = EstadoOrden.Recibida,
                fecha_creacion = DateTime.Now
            };

            _context.Orden.Add(orden);
            await _context.SaveChangesAsync();

            //Guardar los items de la orden
            foreach (var item in ordenItems)
            {
                item.ordenId = orden.id_orden;
                _context.OrdenItem.Add(item);
            }

            await _context.SaveChangesAsync();
            return orden;
        }

        public async Task<bool> ConfirmarPago(Guid ordenId)
        {
            var orden = await _context.Orden.FindAsync(ordenId);
            if (orden == null) return false;

            orden.pago_confirmado = true;
            orden.fecha_pago = DateTime.Now.ToString();

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<Orden>> GetByStudent(string studentId)
        {
            return await _context.Orden
                .Where(o => o.studentId == studentId)
                .Include(o => o.tienda)
                .OrderByDescending(o => o.fecha_creacion)
                .ToListAsync();
        }

        public async Task<List<Orden>> GetByTienda(Guid tiendaId)
        {
            return await _context.Orden
                .Where(o => o.tiendaId == tiendaId && o.estado != EstadoOrden.Entregada)
                .Include(o => o.tienda)
                .OrderBy(o => o.fecha_creacion)
                .ToListAsync();
        }

        public async Task<bool> UpdateEstado(Guid ordenId, EstadoOrden nuevoEstado)
        {
            var orden = await _context.Orden.FindAsync(ordenId);
            if (orden == null) return false;

            //Validar estado
            if ((int)nuevoEstado != (int)orden.estado + 1)
                throw new Exception($"Transición de estado inválida. Estado actual: {orden.estado}");

            orden.estado = nuevoEstado;
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<int> GetETA(Guid tiendaId)
        {
            //Sumar minutos de preparación de todos los productos en ordenes activas
            var minutosEnCola = await _context.OrdenItem
                .Include(oi => oi.orden)
                .Include(oi => oi.producto)
                .Where(oi => oi.orden.tiendaId == tiendaId &&
                             oi.orden.estado != EstadoOrden.Entregada)
                .SumAsync(oi => oi.producto.minutos_preparacion * oi.cantidad);

            return minutosEnCola;
        }
    }
}