using System.ComponentModel.DataAnnotations;

namespace PoliFoodCaso.Models.DTOs
{
    public class CreateVendorDTO
    {
        [Required(ErrorMessage = "El email es obligatorio")]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [MinLength(8)]
        public string Password { get; set; } = null!;

        [Required(ErrorMessage = "Debe ingresar el nombre de la tienda")]
        [MinLength(2)]
        public string nombre_tienda { get; set; } = null!;
    }
}
