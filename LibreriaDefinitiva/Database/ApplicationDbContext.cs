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
            modelBuilder.Entity<Scaffale>().HasData(scaffali.Select(s => new { s.ScaffaleId, s.Genere }));

            foreach (var scaffale in scaffali)
            {
                modelBuilder.Entity<Scaffale>().OwnsMany(s => s.ScaffaleDiLibri).HasData(
                    scaffale.ScaffaleDiLibri.Select(l => new
                    {
                        l.LibroId,
                        l.Isbn,
                        l.Titolo,
                        l.Autore,
                        l.Genere,
                        l.Edizione,
                        l.Prezzo, 
                        scaffale.ScaffaleId
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
                                 LibroId=0,
                                 Isbn = parts[0],
                                 Titolo = parts[1],
                                 Autore = parts[2],
                                 Genere = parts[3],
                                 Edizione = parts[4], 
                                 Prezzo = double.Parse(parts[5])
                             })
                             .ToList();

            var genres = libri.Select(l => l.Genere)
                              .Distinct()
                              .ToList();

            var scaffali = genres.Select((g, i) => new Scaffale
            {
                ScaffaleId = i + 1,
                Genere = g,
                ScaffaleDiLibri = libri.Where(l => l.Genere == g).ToList()
            }).ToList();

            return scaffali;
        }
    }
}
