using PoliFoodCaso.Models;
using PoliFoodCaso.Models.DTOs;

namespace PoliFoodCaso.Interfaces
{
    public interface IOrdenService
    {
        Task<Orden> Create(CheckoutDTO checkout, string studentId);
        Task<bool> ConfirmarPago(Guid ordenId);
        Task<List<Orden>> GetByStudent(string studentId);
        Task<List<Orden>> GetByTienda(Guid tiendaId);
        Task<bool> UpdateEstado(Guid ordenId, EstadoOrden nuevoEstado);
        Task<int> GetETA(Guid tiendaId);
    }
}