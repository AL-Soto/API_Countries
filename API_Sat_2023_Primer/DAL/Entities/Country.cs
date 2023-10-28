using System.ComponentModel.DataAnnotations;

namespace API_Sat_2023_Primer.DAL.Entities
{
    public class Country : AudiBase
    {
        [Display(Name = "Pais")] //Para pintar el nombre bonito en el frontend
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo{1} caracter")] //Longituda maxima de caracteres que la propiedad permite tener (50)
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Name { get; set; } //Varchar(50)

        [Display(Name = "Estados")]
        public ICollection<State>? States { get; set;}
    }
}
