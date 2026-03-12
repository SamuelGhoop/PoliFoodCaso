using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliFoodCaso.Models
{
    public class Producto
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_producto { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre del producto")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string nombre_producto { get; set; }

        [Required(ErrorMessage = "Debe ingresar una descripción")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "Debe ingresar el precio")]
        public double precio { get; set; }

        public string imagen_url { get; set; }

        public bool disponible { get; set; } = true;

        [Required(ErrorMessage = "Debe ingresar el tiempo de preparación")]
        public int minutos_preparacion { get; set; }

        public int isActive { get; set; } = 1;

        [Required]
        public Guid categoriaId { get; set; }

        [ForeignKey("categoriaId")]
        public Categoria? categoria { get; set; }
    }
}