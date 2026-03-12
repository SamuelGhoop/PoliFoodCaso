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
        public int cantidad { get; set; }

        // Precio al momento de la compra, no referencia al precio actual del producto
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