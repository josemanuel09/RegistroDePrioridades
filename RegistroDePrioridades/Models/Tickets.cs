using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RegistroDePrioridades.Models
{
    public class Tickets
    {
        [Key]
        public int TicketId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public DateTime Fecha { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [ForeignKey("ClienteId")]
        public int ClienteId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [ForeignKey("SistemaId")]
        public int SistemaId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        [ForeignKey("PrioridadId")]
        public int PrioridadId { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? SolicitadoPor { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Asunto { get; set; }
        [Required(ErrorMessage = "El campo es obligatorio")]
        public string? Descripcion { get; set; }
    }
}
