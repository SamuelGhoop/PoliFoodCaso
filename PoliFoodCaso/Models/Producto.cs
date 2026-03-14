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
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0")]
        public double precio { get; set; }

        public string imagen_url { get; set; }

        public bool disponible { get; set; } = true;


        [Required(ErrorMessage = "Debe ingresar el tiempo de preparación")]
        [Range(1, 120, ErrorMessage = "El tiempo de preparación debe estar entre 1 y 120 minutos")]
        public int minutos_preparacion { get; set; }

        public int isActive { get; set; } = 1;

        [Required]
        public Guid categoriaId { get; set; }

        [ForeignKey("categoriaId")]
        public Categoria? categoria { get; set; }
    }
}