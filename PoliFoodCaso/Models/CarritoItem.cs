using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliFoodCaso.Models
{
    public class CarritoItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_carrito_item { get; set; }

        [Required]
        [Range(1, 150, ErrorMessage = "La cantidad debe estar entre 1 y 150")]
        public int cantidad { get; set; }

        // ID del student dueño del carrito (string porque Identity guarda IDs así)
        [Required]
        public string studentId { get; set; }

        [Required]
        public Guid productoId { get; set; }

        [ForeignKey("productoId")]
        public Producto? producto { get; set; }
    }
}