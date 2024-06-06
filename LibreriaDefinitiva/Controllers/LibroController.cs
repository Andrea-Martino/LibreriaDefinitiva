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
            if (newBook == null)                                            return BadRequest(new { error = "Impossibile aggiungere un libro senza caratteristiche." });
            if (newBook.Isbn.Length != 13 && newBook.Isbn.Length != 10)     return BadRequest(new { error = "L'ISBN deve essere composto da 10 o 13 caratteri." });
            if (newBook.Prezzo < 0)                                         return BadRequest(new { error = "Il prezzo non può essere negativo." });

            var libroPresente = _db.Libri.FirstOrDefault(l => l.Isbn.ToLower() == newBook.Isbn.ToLower());
            if (libroPresente != null)
            {
                libroPresente.Quantita++;
                _db.SaveChanges();
                return CreatedAtAction(nameof(SearchBooks), new { isbn = libroPresente.Isbn }, libroPresente);
            }
            else
            {
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

                Libro model = new Libro
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
                return CreatedAtAction(nameof(SearchBooks), new { isbn = model.Isbn }, model);
            }
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
                return BadRequest(new { error = "Titolo, autore o ISBN non validi." });
            }
            var books = _db.Scaffali
                                .SelectMany(s => s.ScaffaleDiLibri)
                                .Where(b => b.Titolo.ToLower().Contains(query.ToLower()) || b.Autore.ToLower().Contains(query.ToLower()) || b.Isbn.Contains(query) || b.Genere.ToLower() == query.ToLower())
                                .ToList();
            if (!books.Any()) return NotFound(new { error = "Non sono presenti libri con queste caratteristiche" });
            return Ok(books);
        }

        //Tutto corretto fino a qui


        [HttpPatch("{isbn}", Name = "UpdateLibro")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult UpdateLibro(string isbn, JsonPatchDocument<LibroDTO> patchDTO)
        {
            if (patchDTO == null || !_db.Libri.Any(l => l.Isbn == isbn))
            {
                _logger.LogError("patchDTO non valido o non è presente un libro con isbn uguale a quello passato come parametro.");
                return BadRequest(new { error = "Ciò che vuoi cambiare è scritto in maniera incorretta." });
            }

            var libro = _db.Libri.AsNoTracking().First(l => l.Isbn.ToLower() == isbn.ToLower());

            LibroDTO libroDTO = new()
            {
                Isbn = libro.Isbn,
                Edizione = libro.Edizione,
                Prezzo = libro.Prezzo,
                Autore = libro.Autore,
                Genere = libro.Genere,
                Titolo = libro.Titolo,
                Quantita = libro.Quantita
            };

            patchDTO.ApplyTo(libroDTO);

            Libro model = new Libro()
            {
                Isbn = libroDTO.Isbn,
                Edizione = libroDTO.Edizione,
                Prezzo = libroDTO.Prezzo,
                Autore = libroDTO.Autore,
                Genere = libroDTO.Genere,
                Titolo = libroDTO.Titolo,
                Quantita = libroDTO.Quantita
            };

            if (model.Quantita == 0)
            {
                _db.Libri.Remove(model);
                _db.Scaffali
                    .SelectMany(s => s.ScaffaleDiLibri)
                    .Where(l => l.Isbn.ToLower() == isbn.ToLower())
                    .ToList()
                    .Remove(model);
                return NoContent();
            }

            _db.Libri.Update(model);
            _db.SaveChanges();

            if (!ModelState.IsValid) return BadRequest(ModelState);

            return Ok(model);
        }
    }
}
