using LibreriaDefinitiva.Database;
using LibreriaDefinitiva.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LibreriaDefinitiva.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ApplicationDbContext _db;
        private readonly ILogger<LibroController> _logger;

        public LibroController(ILogger<LibroController> logger, ApplicationDbContext db)
        {
            _db = db;
            _logger = logger;
        }


        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [HttpGet("GetAllLibri", Name = "GetAllLibri")]
        public IActionResult GetAllBooks()
        {
            _logger.LogInformation("Get libri nello scaffale");
            var books = _db.Libreria.SelectMany(s => s.ScaffaleDiLibri);

            if (books == null || !books.Any())
            {
                return NoContent();
            }

            return Ok(books.ToList());
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Libro newBook)
        {
            var scaffale = _db.Libreria.FirstOrDefault(s => s.GenereId == newBook.Genere);
            if (scaffale == null)
            {
                scaffale = new Scaffale
                {
                    GenereId = newBook.Genere,
                    ScaffaleDiLibri = new List<Libro>()
                };
                _db.Libreria.Add(scaffale);
            }
            scaffale.ScaffaleDiLibri.Add(newBook);
            _db.SaveChanges();
            return CreatedAtAction(nameof(GetAllBooks), new { isbn = newBook.Isbn }, newBook);
        }

        [HttpGet("search")]
        public IActionResult SearchBooks([FromQuery] string query)
        {
            var books = _db.Libreria
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .Where(b => b.Titolo.Contains(query) || b.Autore.Contains(query))
                                .ToList();
            return Ok(books);
        }

        [HttpDelete("{isbn}")]
        public IActionResult DeleteBook(string isbn)
        {
            var book = _db.Libreria
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .FirstOrDefault(b => b.Isbn == isbn);
            if (book == null)
            {
                return NotFound();
            }

            var scaffale = _db.Libreria.FirstOrDefault(s => s.ScaffaleDiLibri.Contains(book));
            if (scaffale != null)
            {
                scaffale.ScaffaleDiLibri.Remove(book);
                _db.SaveChanges();
            }

            return NoContent();
        }
    }
}
