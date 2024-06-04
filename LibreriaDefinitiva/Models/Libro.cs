using System.ComponentModel.DataAnnotations;

namespace LibreriaDefinitiva.Models
{
    public class Libro
    {
        [Key]
        [Required]
        [MaxLength(13)]
        [MinLength(10)]
        public string Isbn { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public string Edizione { get; set; } //Einaudi(2019)
        public Scaffale Scaffale { get; set; }
    }
}
