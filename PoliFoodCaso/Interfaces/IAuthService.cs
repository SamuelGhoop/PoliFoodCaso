using Microsoft.AspNetCore.Identity;

namespace PoliFoodCaso.Interfaces
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(string email, string password, string role);
        Task<string?> Login(string email, string password);
        Task<IdentityResult> CreateVendor(string email, string password, string nombre_tienda);
    }
}