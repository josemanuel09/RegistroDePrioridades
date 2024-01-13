using System.ComponentModel.DataAnnotations;

namespace RegistroDePrioridades.Models
{
    public class Prioridades
    {
        [Key]
        public int PrioridadId { get; set; }

        [Required(ErrorMessage = "El descripcion es obligatorio")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "Los dias de comprimiso deben ser validos")]
        [Range(1, 31, ErrorMessage = "Los dias de comprimiso deben ser validos")]
        public int DiasCompromiso { get; set; }
    }
}
