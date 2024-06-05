using LibreriaDefinitiva.Database;
using LibreriaDefinitiva.Models;
using LibreriaDefinitiva.Models.Dto;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.IO.IsolatedStorage;
using System.Linq;
using System.Reflection.Metadata;
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

        [HttpDelete("{isbn}, {quantita: int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public IActionResult DeleteBook(string isbn, int quantita)
        {
            if (string.IsNullOrEmpty(isbn) || (isbn.Length != 13 && isbn.Length != 10))
            {
                _logger.LogError("ISBN non valido: " + isbn);
                return BadRequest();
            }

            var books = _db.Libreria.SelectMany(s => s.ScaffaleDiLibri)
                                 .Where(l => l.Isbn.Equals(isbn))
                                 .ToList();

            if (!books.Any())
            {
                _logger.LogError("Non esiste un libro con ISBN: " + isbn);
                return NotFound();
            }

            if (quantita > books.Count())
            {
                bool continueOperation = AskUserToContinue(quantita, books.Count());
                if (!continueOperation)
                {
                    return BadRequest("La quantità richiesta è maggiore dei libri disponibili.");
                }
            }

            for (int i = 0; i < quantita; i++)
            {
                try
                {
                    _db.Libri.Remove(books[i]);
                    var libroToRemove = books[i];

                    if (libroToRemove != null)
                    {
                        _db.Libri.Remove(libroToRemove);
                        _db.SaveChanges();
                    }

                    var scaffale = _db.Libreria.ToList().FirstOrDefault(s => s.ScaffaleDiLibri.Contains(libroToRemove));
                    scaffale.ScaffaleDiLibri.Remove(libroToRemove);
                    _db.SaveChanges();
                }
                catch (Exception e)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
            }
            return NoContent();
        }
        /*
        [HttpPatch("{isbn}", Name = "UpdatePartialScaffale")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public IActionResult UpdatePartialScaffale(string isbn, JsonPatchDocument<LibroDTO> patchDTO)
        {
            if (patchDTO == null || !_db.Libri.Any(l => l.Isbn.Equals(isbn))) return BadRequest();

            var libro = _db.Libri.AsNoTracking().FirstOrDefault(l => l.Isbn == isbn);
            if (libro == null) return NotFound();

            LibroDTO libroDTO = new()
            {
                Isbn = libro.Isbn,
                Autore = libro.Autore,
                Genere = libro.Genere,
                Titolo = libro.Titolo,
            };

            patchDTO.ApplyTo(libroDTO);

            Libro model = new Libro()
            {
                Isbn = libroDTO.Isbn,
                Autore = libroDTO.Autore,
                Genere = libroDTO.Genere,
                Titolo = libroDTO.Titolo,
            };

            _db.Libri.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return CreatedAtAction(nameof(SearchBookByIsbn), new { isbn = libro.Isbn }, libro);
        }
        */



        private bool AskUserToContinue(int quantita, int availableBooks)
        {
            return true;
        }
    }
}
