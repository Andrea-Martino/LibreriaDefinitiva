using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibreriaDefinitiva.Models
{
    public class Libro
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LibroId { get; set; }    
        [Required]
        [MaxLength(13)]
        [MinLength(10)]
        public string Isbn { get; set; }
        public string Titolo { get; set; }
        public string Autore { get; set; }
        public string Genere { get; set; }
        public string Edizione { get; set; } //Einaudi(2019)
        public string ScaffaleId { get; set; }
        public Scaffale? Scaffale { get; set; }
    }
}
