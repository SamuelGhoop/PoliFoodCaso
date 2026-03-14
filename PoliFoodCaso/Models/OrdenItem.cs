using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliFoodCaso.Models
{
    public class OrdenItem
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_orden_item { get; set; }
        [Required]
        [Range(1, 150, ErrorMessage = "La cantidad debe estar entre 1 y 150")]
        public int cantidad { get; set; }

        // Precio al momento de la compra, no referencia al precio actual del producto
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double precio_unitario { get; set; }

        [Required]
        public Guid ordenId { get; set; }

        [ForeignKey("ordenId")]
        public Orden? orden { get; set; }

        [Required]
        public Guid productoId { get; set; }

        [ForeignKey("productoId")]
        public Producto? producto { get; set; }
    }
}