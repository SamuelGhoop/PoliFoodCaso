using System.ComponentModel.DataAnnotations;

namespace PoliFoodCaso.Models.DTOs
{
    public class CheckoutItemDTO
    {
        [Required]
        public Guid productoId { get; set; }

        [Required]
        [Range(1, 50, ErrorMessage = "La cantidad debe estar entre 1 y 50")]
        public int cantidad { get; set; }
    }

    public class CheckoutDTO
    {
        [Required(ErrorMessage = "El carrito no puede estar vacío")]
        public List<CheckoutItemDTO> items { get; set; }

        public string? notas { get; set; }
    }
}