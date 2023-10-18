using System.ComponentModel.DataAnnotations;

namespace API_Sat_2023_Primer.DAL.Entities
{
    public class AudiBase
    {
        [Key] //DataAnnotation me sirve para definir que esta propiedad ID es un PK
        [Required] //no permite nulos 
        public virtual Guid ID { get; set; }  //Sera la Pk de todas las tablas de mi BD
        public virtual DateTime? CreateDate { get; set; } //Campos nulleables notacion Elvis (?) 
        public virtual DateTime? ModifiedDate { get; set; } //Campos nulleables 
    }
}
