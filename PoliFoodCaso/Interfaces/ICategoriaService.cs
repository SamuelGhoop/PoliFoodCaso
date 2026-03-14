using PoliFoodCaso.Models;

namespace PoliFoodCaso.Interfaces
{
    public interface ICategoriaService
    {
        Task<List<Categoria>> GetByTienda(Guid tiendaId);
        Task<Categoria?> GetById(Guid id);
        Task<Categoria> Create(Categoria categoria);
        Task<bool> Update(Guid id, Categoria categoria);
        Task<bool> ChangeStatus(Guid id);
    }
}
