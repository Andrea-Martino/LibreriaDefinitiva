using System.ComponentModel.DataAnnotations;

namespace LibreriaDefinitiva.Models.Dto
{
    public class ScaffaleDTO
    {
        [Key]
        public string GenereId { get; set; }
        public List<Libro> ScaffaleDiLibri { get; set; }
    }
}
