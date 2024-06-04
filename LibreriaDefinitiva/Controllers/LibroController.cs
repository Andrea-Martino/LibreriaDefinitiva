using LibreriaDefinitiva.Database;
using LibreriaDefinitiva.Models;
using LibreriaDefinitiva.Models.Dto;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

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
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult AddBook([FromBody] LibroDTO newBook)
        {
            if (newBook == null) return BadRequest();
            if (newBook.Isbn.Length != 13 && newBook.Isbn.Length != 10) return BadRequest(newBook.Isbn);

            var scaffale = _db.Libreria.FirstOrDefault(s => s.Genere == newBook.Genere);
            if (scaffale == null)
            {
                scaffale = new Scaffale
                {
                    Genere = newBook.Genere,
                    ScaffaleDiLibri = new List<Libro>()
                };
                _db.Libreria.Add(scaffale);
            }

            Libro model = new()
            {
                Isbn = newBook.Isbn,
                Titolo = newBook.Titolo,
                Autore = newBook.Autore,
                Genere = newBook.Genere,
                Edizione = newBook.Edizione,
                ScaffaleId = scaffale.ScaffaleId,
                Scaffale = scaffale
            };

            scaffale.ScaffaleDiLibri.Add(model);
            _db.SaveChanges();
            return CreatedAtAction(nameof(SearchBooks), new { isbn = newBook.Isbn }, newBook);
        }

        [HttpGet("{isbn}", Name = "GetLibroByIsbn")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SearchBookByIsbn(string isbn)
        {
            if (isbn == null || isbn.Length != 13 && isbn.Length != 10)
            {
                _logger.LogError("Non esiste un libro con ISBN: " + isbn);
                return BadRequest();
            }

            var book = _db.Libreria
                              .SelectMany(s => s.ScaffaleDiLibri)
                              .Where(b => b.Isbn.Equals(isbn))
                              .ToList().FirstOrDefault();
            if (book == null)   return NotFound();
            return Ok(book);
        }

        [HttpGet("{query}", Name = "GetLibroByTitoloOrAutore")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SearchBooks([FromQuery] string query)
        {
            if (query == null)
            {
                _logger.LogError("Titolo o autore non validi");
                return BadRequest();
            }
            var books = _db.Libreria
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .Where(b => b.Titolo.Contains(query) || b.Autore.Contains(query))
                                .ToList();
            if (!books.Any()) return NotFound();
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

