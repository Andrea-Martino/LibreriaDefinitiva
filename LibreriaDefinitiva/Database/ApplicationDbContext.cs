using LibreriaDefinitiva.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace LibreriaDefinitiva.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Scaffale> Scaffali { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Scaffale>(entity =>
            {
                entity.Property(e => e.ScaffaleId)
                      .ValueGeneratedOnAdd();
            });

            var scaffali = SeedScaffali();

            // Inserimento dei dati per gli scaffali
            modelBuilder.Entity<Scaffale>().HasData(scaffali.Select((s, index) => new { ScaffaleId = -(index + 1), s.Genere }));

            // Inserimento dei dati per i libri
            var libroIdCounter = 1; // Iniziamo da 1 per evitare la chiave primaria 0
            foreach (var scaffale in scaffali)
            {
                modelBuilder.Entity<Libro>().HasData(
                    scaffale.ScaffaleDiLibri.Select(libro =>
                    {
                        var uniqueLibroId = libroIdCounter++;
                        return new Libro
                        {
                            LibroId = uniqueLibroId,
                            Isbn = libro.Isbn,
                            Titolo = libro.Titolo,
                            Autore = libro.Autore,
                            Genere = libro.Genere,
                            Edizione = libro.Edizione,
                            Prezzo = libro.Prezzo,
                            Quantita = libro.Quantita,
                            ScaffaleId = scaffale.ScaffaleId
                        };
                    }).ToArray());
            }
        }


        private List<Scaffale> SeedScaffali()
        {
            var lines = File.ReadAllLines("Libri.csv");

            var libri = lines.Skip(1)
                             .Select(line => line.Split(';'))
                             .Select(parts => new Libro
                             {
                                 Isbn = parts[0],
                                 Titolo = parts[1],
                                 Autore = parts[2],
                                 Genere = parts[3],
                                 Edizione = parts[4],
                                 Prezzo = double.Parse(parts[5]),
                                 Quantita = int.Parse(parts[6])
                             })
                             .ToList();

            var genres = libri.Select(l => l.Genere)
                              .Distinct()
                              .ToList();

            var scaffali = genres.Select((g, i) => new Scaffale
            {
                Genere = g,
                ScaffaleDiLibri = libri.Where(l => l.Genere == g).ToList()
            }).ToList();

            return scaffali;
        }
    }
}