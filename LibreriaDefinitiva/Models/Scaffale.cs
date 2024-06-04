using System.ComponentModel.DataAnnotations;

namespace LibreriaDefinitiva.Models
{
    public class Scaffale
    {
        [Key]
        public string ScaffaleId { get; set; }
        public string Genere { get; set; }
        public List<Libro> ScaffaleDiLibri { get; set; }
    }
}
