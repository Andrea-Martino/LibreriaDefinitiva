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
        private readonly ApplicationDbContext _context;

        public LibroController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAllBooks()
        {
            var books = _context.Libreria.SelectMany(s => s.ScaffaleDiLibri).ToList();
            return Ok(books);
        }

        [HttpPost]
        public IActionResult AddBook([FromBody] Libro newBook)
        {
            var scaffale = _context.Libreria.FirstOrDefault(s => s.GenereId == newBook.Genere);
            if (scaffale == null)
            {
                scaffale = new Scaffale
                {
                    GenereId = newBook.Genere,
                    ScaffaleDiLibri = new List<Libro>()
                };
                _context.Libreria.Add(scaffale);
            }
            scaffale.ScaffaleDiLibri.Add(newBook);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetAllBooks), new { isbn = newBook.Isbn }, newBook);
        }

        [HttpGet("search")]
        public IActionResult SearchBooks([FromQuery] string query)
        {
            var books = _context.Libreria
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .Where(b => b.Titolo.Contains(query) || b.Autore.Contains(query))
                                .ToList();
            return Ok(books);
        }

        [HttpDelete("{isbn}")]
        public IActionResult DeleteBook(string isbn)
        {
            var book = _context.Libreria
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .FirstOrDefault(b => b.Isbn == isbn);
            if (book == null)
            {
                return NotFound();
            }

            var scaffale = _context.Libreria.FirstOrDefault(s => s.ScaffaleDiLibri.Contains(book));
            if (scaffale != null)
            {
                scaffale.ScaffaleDiLibri.Remove(book);
                _context.SaveChanges();
            }

            return NoContent();
        }
    }
}
