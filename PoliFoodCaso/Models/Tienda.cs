using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliFoodCaso.Models
{
    public class Tienda
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_tienda { get; set; }

        [Required(ErrorMessage = "Debe ingresar el nombre de la tienda")]
        [MinLength(2, ErrorMessage = "El nombre debe tener al menos 2 caracteres")]
        public string nombre_tienda { get; set; }

        public int isActive { get; set; } = 1;

        // ID del vendor dueño (string porque Identity guarda IDs así)
        [Required]
        public string vendorId { get; set; }
    }
}