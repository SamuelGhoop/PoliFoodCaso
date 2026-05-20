using System.ComponentModel.DataAnnotations;

namespace PoliFoodCaso.Models.DTOs
{
    public class CarritoItemDTO
    {
        [Required]
        public Guid productoId { get; set; }

        [Required]
        [Range(1, 150, ErrorMessage = "La cantidad debe estar entre 1 y 150")]
        public int cantidad { get; set; }
    }
}
