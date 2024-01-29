using System.ComponentModel.DataAnnotations;

namespace RegistroDePrioridades.Models
{
    public class Sistemas
    {
       
            [Key]
            public int SistemaId { get; set; }

            [Required(ErrorMessage = "Campo Obligatorio")]
            public string? NombreSistema { get; set; }
    }
}
