using PoliFoodCaso.Models;

namespace PoliFoodCaso.Interfaces
{
    public interface ICarritoService
    {
        Task<List<CarritoItem>> GetByStudent(string studentId);

        Task<CarritoItem> AddOrIncrement(string studentId, Guid productoId, int cantidad);

        Task<bool> UpdateItem(string studentId, Guid id, int cantidad);

        Task<bool> RemoveItem(string studentId, Guid id);

        Task<bool> Clear(string studentId);
    }
}
