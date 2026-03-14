using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PoliFoodCaso.Models
{
    public enum EstadoOrden
    {
        Recibida = 0,
        Preparando = 1,
        Lista = 2,
        Entregada = 3
    }

    public class Orden
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id_orden { get; set; }

        public EstadoOrden estado { get; set; } = EstadoOrden.Recibida;

        [Range(0.01, double.MaxValue, ErrorMessage = "El total debe ser mayor a 0")]
        public double total { get; set; }

        [Range(1, 120, ErrorMessage = "Los minutos estimados deben estar entre 1 y 120")]
        public int minutos_estimados { get; set; }

        public bool pago_confirmado { get; set; } = false;

        public string? fecha_pago { get; set; }

        public DateTime fecha_creacion { get; set; } = DateTime.Now;

        public int isActive { get; set; } = 1;

        [Required]
        public string studentId { get; set; }

        [Required]
        public Guid tiendaId { get; set; }

        [ForeignKey("tiendaId")]
        public Tienda? tienda { get; set; }
    }
}