using System.ComponentModel.DataAnnotations;

namespace RegistroDePrioridades.Models
{
    public class Clientes
    {
        [Key]
        public int ClienteId { get; set; }
        [StringLength(30, ErrorMessage = "No Puede Exceder los 30 Caracteres")]
        [Required(ErrorMessage = " El Campo Nombre es Obligarotio")]
        public string? Nombres { get; set; }
        [StringLength(10, ErrorMessage = "No Puede Exceder los 10 Caracteres")]
        [Required(ErrorMessage = "El Campo Telefono es Obligatorio")]
        public string? Telefono { get; set; }
        [StringLength(12, ErrorMessage = "No Puede Exceder los 12 Caracteres")]
        [Required(ErrorMessage = "El Campo Celular es Obligatorio")]
        public string? Celular { get; set; }
        [StringLength(9, ErrorMessage = "No Puede Exceder los 9 Caracteres")]
        [Required(ErrorMessage = "El Campo Rnc es Obligatorio")]
        public string? Rnc { get; set; }
        [Required(ErrorMessage = "El campo email es Obligatoeio")]
        [EmailAddress(ErrorMessage = "El formato del email no es Valido")]
        
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo Direccion es Obligatoeio")]
        [StringLength(50, ErrorMessage = "No Puede Exceder los 50 Caracteres")]
        public string? Direccion { get; set; }
    }

    
}

