using LibreriaDefinitiva.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LibreriaDefinitiva.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Scaffale> Libreria { get; set; }
        public DbSet<Scaffale> Libri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Scaffale>()
                .HasMany(s => s.ScaffaleDiLibri)
                .WithOne(l => l.Scaffale)
                .HasForeignKey(l => l.ScaffaleId);

            // Configurazione di Isbn come chiave primaria per Libro
            modelBuilder.Entity<Libro>().HasKey(l => l.Isbn);
            
            modelBuilder.Entity<Scaffale>(entity =>
            {
                entity.Property(e => e.ScaffaleId)
                      .ValueGeneratedOnAdd();
            });
            // Seed data during model creation
            var scaffali = SeedScaffali();
            var libri = SeedLibri(scaffali);

            modelBuilder.Entity<Scaffale>().HasData(scaffali);
            modelBuilder.Entity<Libro>().HasData(libri);
        }

        private List<Scaffale> SeedScaffali()
        {
            var lines = File.ReadAllLines("Libri.csv");

            var genres = lines.Skip(1)
                              .Select(line => line.Split(';')[3])
                              .Distinct()
                              .ToList();

            var scaffali = genres.Select((g, i) =>
            {
                return new Scaffale
                {
                    ScaffaleId = (i + 1), //Rimosso meno per evitare di avere conflitti negli ID degli scaffali 
                    Genere = g
                };
            }).OrderBy(s => s.ScaffaleId).ToList();

            return scaffali;
        }

        private List<Libro> SeedLibri(List<Scaffale> scaffali)
        {
            var lines = File.ReadAllLines("Libri.csv");

            var uniqueBooks = lines.Skip(1)
                                  .Select(line => line.Split(';'))
                                  .GroupBy(parts => parts[0]) // Group by ISBN
                                  .Select(g => g.First()) // Select the first row of each group
                                  .Select(parts => new Libro
                                  {
                                      Isbn = parts[0],
                                      Titolo = parts[1],
                                      Autore = parts[2],
                                      Genere = parts[3],
                                      Edizione = parts[4],
                                      ScaffaleId = scaffali.First(s => s.Genere == parts[3]).ScaffaleId
                                  })
                                  .ToList();

            return uniqueBooks;
        }
    }
}