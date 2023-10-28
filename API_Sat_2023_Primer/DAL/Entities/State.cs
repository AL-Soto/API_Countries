using System.ComponentModel.DataAnnotations;

namespace API_Sat_2023_Primer.DAL.Entities
{
    public class State : AudiBase
    {
        [Display(Name = "Estado/Departamento")]
        [MaxLength(50, ErrorMessage = "El campo {0} debe tener maximo{1} caracter")]
        [Required(ErrorMessage = "¡El campo {0} es obligatorio!")]
        public string Name { get; set; }

        [Display(Name="Pais")]
        public Country? Country { get; set; }

        [Display(Name = "Id Pais")]
        public Guid CountryId { get; set; }
    }
}
