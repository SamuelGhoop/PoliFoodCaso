using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliFoodCaso.Models
{
    public class Categoria
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_categoria { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre de la categoría")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string nombre_categoria { get; set; }

        public int isActive { get; set; } = 1;

        [Required]
        public Guid tiendaId { get; set; }

        [ForeignKey("tiendaId")]
        public Tienda? tienda { get; set; }
    }
}