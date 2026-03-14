using PoliFoodCaso.Models;

namespace PoliFoodCaso.Interfaces
{
    public interface ICarritoService
    {
        Task<List<CarritoItem>> GetByStudent(string studentId);

        Task<CarritoItem> AddItem(CarritoItem item);

        Task<bool> UpdateItem(Guid id, int cantidad);

        Task<bool> RemoveItem(Guid id);
    }
}
