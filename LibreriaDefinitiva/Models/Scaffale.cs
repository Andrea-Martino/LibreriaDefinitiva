using System.ComponentModel.DataAnnotations;

namespace LibreriaDefinitiva.Models
{
    public class Scaffale
    {
        [Key]
        public string GenereId { get; set; }
        public List<Libro> ScaffaleDiLibri { get; set; }
    }
}
