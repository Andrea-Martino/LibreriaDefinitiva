using LibreriaDefinitiva.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using static System.Reflection.Metadata.BlobBuilder;

namespace LibreriaDefinitiva.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Scaffale> Libreria { get; set; }
        public DbSet<Libro> Libri { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Scaffale>()
                .HasMany(s => s.ScaffaleDiLibri)
                .WithOne(l => l.Scaffale)
                .HasForeignKey(l => l.ScaffaleId);
        }
        public void InitializeData()
        {

            if (Libreria.Any())
                return;

            var lines = File.ReadAllLines("Libri.csv");

            var genres = lines.Skip(1)
                              .Select(line => line.Split(';')[3])
                              .Distinct()
                              .ToList();

            var scaffali = genres.Select(g => new Scaffale
            {
                ScaffaleId = Guid.NewGuid().ToString(), 
                Genere = g,
                ScaffaleDiLibri = new List<Libro>()
            })
            .ToList();

            Libreria.AddRange(scaffali);
            SaveChanges();

            List<Libro> allBooks = lines.Skip(1)
                                        .Select(line => line.Split(';'))
                                        .Select(parts => new Libro
                                        {
                                            Isbn = parts[0],
                                            Titolo = parts[1],
                                            Autore = parts[2],
                                            Genere = parts[3],
                                            Edizione = parts[4],
                                            ScaffaleId = scaffali.First(s => s.Genere == parts[3]).ScaffaleId,
                                            Scaffale = scaffali.First(s => s.Genere == parts[3])
                                        })
                                        .ToList();
            Libri.AddRange(allBooks);
            SaveChanges();
        }

    }
}
