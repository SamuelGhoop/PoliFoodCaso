using PoliFoodCaso.Models;
using System.Diagnostics;

namespace PoliFoodCaso.Interfaces
{
    public interface ITiendaService
    {
        Task<List<Tienda>> GetAll();
        Task<Tienda?> GetById(Guid id);

        //Task<Tienda> Create(Tienda tienda); //Tienda se crea con el vendedor, no se necesita un endpoint para crearla

        Task<bool> Update(Guid id, Tienda tienda);

        Task<bool> ChangeStatus(Guid id);
    }
}
