using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using PoliFoodCaso.Interfaces;
using PoliFoodCaso.Models;
using PoliFoodCaso.DAO;

namespace PoliFoodCaso.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<IdentityUser> _manejadorUsuarios;
        private readonly RoleManager<IdentityRole> _manejadorRoles;
        private readonly IConfiguration _configuracion;
        private readonly ApplicationDbContext _context;

        public AuthService(
            UserManager<IdentityUser> manejadorUsuarios,
            RoleManager<IdentityRole> manejadorRoles,
            IConfiguration configuracion,
            ApplicationDbContext context
        )
        {
            _manejadorUsuarios = manejadorUsuarios;
            _manejadorRoles = manejadorRoles;
            _configuracion = configuracion;
            _context = context;
        }

        public async Task<IdentityResult> Register(string email, string password, string role)
        {
            var usuario = new IdentityUser { UserName = email, Email = email };
            var resultado = await _manejadorUsuarios.CreateAsync(usuario, password);

            if (resultado.Succeeded)
            {
                //Solo Admin puede venir del register, cualquier otro queda como Student
                var rolValido = role == "Admin" ? "Admin" : "Student";

                if (!await _manejadorRoles.RoleExistsAsync(rolValido))
                    await _manejadorRoles.CreateAsync(new IdentityRole(rolValido));

                await _manejadorUsuarios.AddToRoleAsync(usuario, rolValido);
            }

            return resultado;
        }

        public async Task<IdentityResult> CreateVendor(string email, string password, string nombre_tienda)
        {
            var usuario = new IdentityUser { UserName = email, Email = email };
            var resultado = await _manejadorUsuarios.CreateAsync(usuario, password);

            if (resultado.Succeeded)
            {
                if (!await _manejadorRoles.RoleExistsAsync("Vendor"))
                    await _manejadorRoles.CreateAsync(new IdentityRole("Vendor"));

                await _manejadorUsuarios.AddToRoleAsync(usuario, "Vendor");

                var nueva_tienda = new Tienda
                {
                    nombre_tienda = nombre_tienda,
                    vendorId = usuario.Id,
                    isActive = 1
                };

                _context.Tienda.Add(nueva_tienda);
                await _context.SaveChangesAsync();
            }

            return resultado;
        }

        public async Task<string?> Login(string email, string password)
        {
            var usuario = await _manejadorUsuarios.FindByEmailAsync(email);

            if (usuario != null && await _manejadorUsuarios.CheckPasswordAsync(usuario, password))
            {
                var rolesUsuario = await _manejadorUsuarios.GetRolesAsync(usuario);
                return GenerarTokenJwt(usuario, rolesUsuario);
            }

            return null;
        }

        private string GenerarTokenJwt(IdentityUser usuario, IList<string> roles)
        {
            var reclamaciones = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, usuario.Id),
                new Claim(JwtRegisteredClaimNames.Email, usuario.Email!),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            foreach (var rol in roles)
                reclamaciones.Add(new Claim(ClaimTypes.Role, rol));

            var firmaServidor = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                _configuracion["Jwt:Key"]!));

            var token = new JwtSecurityToken(
                issuer: _configuracion["Jwt:Issuer"],
                audience: _configuracion["Jwt:Audience"],
                expires: DateTime.Now.AddHours(3),
                claims: reclamaciones,
                signingCredentials: new SigningCredentials(
                    firmaServidor, SecurityAlgorithms.HmacSha256)
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}