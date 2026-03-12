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
            ApplicationDbContext contexto
        )
        {
            _manejadorUsuarios = manejadorUsuarios;
            _manejadorRoles = manejadorRoles;
            _configuracion = configuracion;
            _context = contexto;
        }

        public async Task<IdentityResult> Register(string correo, string contrasena)
        {
            var usuario = new IdentityUser { UserName = correo, Email = correo };
            var resultado = await _manejadorUsuarios.CreateAsync(usuario, contrasena);

            if (resultado.Succeeded)
            {
                if (!await _manejadorRoles.RoleExistsAsync("Student"))
                    await _manejadorRoles.CreateAsync(new IdentityRole("Student"));

                await _manejadorUsuarios.AddToRoleAsync(usuario, "Student");
            }

            return resultado;
        }

        public async Task<IdentityResult> CreateVendor(string correo, string contrasena, string nombreTienda)
        {
            var usuario = new IdentityUser { UserName = correo, Email = correo };
            var resultado = await _manejadorUsuarios.CreateAsync(usuario, contrasena);

            if (resultado.Succeeded)
            {
                if (!await _manejadorRoles.RoleExistsAsync("Vendor"))
                    await _manejadorRoles.CreateAsync(new IdentityRole("Vendor"));

                await _manejadorUsuarios.AddToRoleAsync(usuario, "Vendor");

                var tienda = new Tienda
                {
                    nombre_tienda = nombreTienda,
                    vendorId = usuario.Id,
                    isActive = 1
                };

                _context.Tienda.Add(tienda);
                await _context.SaveChangesAsync();
            }

            return resultado;
        }

        public async Task<string?> Login(string correo, string contrasena)
        {
            var usuario = await _manejadorUsuarios.FindByEmailAsync(correo);

            if (usuario != null && await _manejadorUsuarios.CheckPasswordAsync(usuario, contrasena))
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