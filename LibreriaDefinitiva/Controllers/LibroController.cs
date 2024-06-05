using Azure;
using LibreriaDefinitiva.Database;
using LibreriaDefinitiva.Models;
using LibreriaDefinitiva.Models.Dto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
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
            _logger.LogInformation("Get tutti i libri nella libreria");
            var books = _db.Scaffali.SelectMany(s => s.ScaffaleDiLibri);

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
            if (newBook == null)          return BadRequest(new { error = "Non puo aggiungere un libro senza caratteristiche."});
            if (newBook.Isbn.Length != 13 && newBook.Isbn.Length != 10) return BadRequest(new { error = "L'ISBN deve essere composto da 13 caratteri.", newBook.Isbn });
            if (newBook.Prezzo < 0)       return BadRequest(new { error = "Il prezzo non può essere negativo.", prezzo = newBook.Prezzo });

            var scaffale = _db.Scaffali.FirstOrDefault(s => s.Genere.ToLower() == newBook.Genere.ToLower());
            if (scaffale == null)
            {
                scaffale = new Scaffale
                {
                    Genere = newBook.Genere,
                    ScaffaleDiLibri = new List<Libro>()
                };
                _db.Scaffali.Add(scaffale);
            }

            Libro model = new()
            {
                Isbn = newBook.Isbn,
                Titolo = newBook.Titolo,
                Autore = newBook.Autore,
                Prezzo = newBook.Prezzo,
                Genere = newBook.Genere,
                Edizione = newBook.Edizione,
                Quantita = newBook.Quantita,
                ScaffaleId = scaffale.ScaffaleId,
                Scaffale = scaffale
            };

            scaffale.ScaffaleDiLibri.Add(model);
            _db.Libri.Add(model);

            _db.SaveChanges();
            return CreatedAtAction(nameof(SearchBooks), new { isbn = newBook.Isbn }, newBook);
        }

        [HttpGet("{query}", Name = "GetLibro")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult SearchBooks([FromQuery] string query)
        {
            if (query == null)
            {
                _logger.LogError("Titolo, autore o ISBN non validi.");
                return BadRequest(new {error = "Titolo, autore o ISBN non validi."});
            }
            var books = _db.Scaffali
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .Where(b => b.Titolo.ToLower().Contains(query.ToLower()) || b.Autore.ToLower().Contains(query.ToLower()) || b.Isbn.ToLower().Contains(query.ToLower()))
                                .ToList();
            if (!books.Any()) return NotFound(new {error = "Non sono presenti libri con queste caratteristiche"});
            return Ok(books);
        }

        //Tutto corretto fino a qui

        /*
        [HttpPatch("{isbn}", Name = "UpdatePrezzoLibro")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status201Created)]

        public IActionResult UpdatePrezzoLibro(string isbn, JsonPatchDocument<LibroDTO> patchDTO)
        {
            if (patchDTO == null || !_db.Libri.Any(l => l.Isbn.Equals(isbn))) return BadRequest();
        }
        */
        /*[HttpDelete("{isbn}/{quantita:int}")]
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

            var books = _db.Scaffali.SelectMany(s => s.ScaffaleDiLibri)
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
                    var libroToRemove = books[i];

                    if (libroToRemove != null)
                    {
                        //_db.Libri.Remove(libroToRemove);
                        _db.SaveChanges();
                    }

                    var scaffale = _db.Scaffali.ToList().FirstOrDefault(s => s.ScaffaleDiLibri.Contains(libroToRemove));
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

        private bool AskUserToContinue(int quantita, int availableBooks)
        {
            return true;
        }*/
        /*[HttpPatch("{isbn}/{quantita:int}")]
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

            var books = _db.Scaffali.SelectMany(s => s.ScaffaleDiLibri)
                                 .Where(l => l.Isbn.Equals(isbn))
                                 .ToList();
            if (!books.Any())
            {
                _logger.LogError("Non esiste un libro con ISBN: " + isbn);
                return NotFound();
            }

            var libroPatch = books
        }*/


    }
}
