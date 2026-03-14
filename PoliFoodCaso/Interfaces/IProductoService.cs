using PoliFoodCaso.Models;
using System.Diagnostics;

namespace PoliFoodCaso.Interfaces
{
    public interface IProductoService
    {
        Task<List<Producto>> GetByTienda(Guid tiendaId); //Recorrer por tienda
        Task<Producto?> GetById(Guid id);

        Task<Producto> Create(Producto producto);

        Task<bool> Update(Guid id, Producto producto);

        Task<bool> ChangeStatus(Guid id);
    }
}
