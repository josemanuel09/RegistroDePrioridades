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
        [Required(ErrorMessage = "El Campo Email es obligatorio")]
        [StringLength(30, ErrorMessage = "No Puede Exceder los 30 Caracteres")]
        [EmailAddress(ErrorMessage = "El formato del email no es Valido")]
        [ArrobaValidation(ErrorMessage = "El Email Debe Contener @")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "El campo Direccion es Obligatoeio")]
        [StringLength(50, ErrorMessage = "No Puede Exceder los 50 Caracteres")]
        public string? Direccion { get; set; }
    }

    public class ArrobaValidation : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? valor, ValidationContext validationContext)
        {
            if (valor != null)
            {
                string email = valor.ToString();
                if (!email.Contains("@"))
                    return ValidationResult.Success;
                else
                    return new ValidationResult("El Email Debe Contener @");
            }
            return new ValidationResult("Debes Colocar un Email");
        }
    }
}

