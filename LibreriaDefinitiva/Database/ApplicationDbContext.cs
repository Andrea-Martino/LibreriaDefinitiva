using LibreriaDefinitiva.Models;
using Microsoft.EntityFrameworkCore;

namespace LibreriaDefinitiva.Database
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Scaffale> Libreria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*var lines = System.IO.File.ReadAllLines("books.csv");
            List<Libro> allBooks = lines.Skip(1)
                                .Select(line => line.Split(';'))
                                .Select(parts => new Libro
                                {
                                    Isbn = parts[0],
                                    Titolo = parts[1],
                                    Autore = parts[2],
                                    Genere = parts[3],
                                    Edizione = parts[4]
                                })
                                .ToList();
            //Aggiungi libri nello scaffale
            foreach (var book in allBooks)
            {
                if (!(Libreria.Any(s => s.GenereId.Equals(book.Genere))))
                {
                    Libreria.Add(new Scaffale
                    {
                        GenereId = book.Genere,
                        ScaffaleDiLibri = allBooks.Where(g => g.Genere.Equals(book.Genere)).ToList()
                    });
                }
            }
            modelBuilder.Entity<Libro>().HasData(allBooks.ToArray());*/
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Scaffale>().HasMany(s=>s.ScaffaleDiLibri).WithOne(l=>l.Scaffale).HasForeignKey(e=>e.Scaffale.GenereId);

        }
        public void InizializeData()
        {
            var lines = System.IO.File.ReadAllLines("books.csv");
            List<Libro> allBooks = lines.Skip(1)
                                .Select(line => line.Split(';'))
                                .Select(parts => new Libro
                                {
                                    Isbn = parts[0],
                                    Titolo = parts[1],
                                    Autore = parts[2],
                                    Genere = parts[3],
                                    Edizione = parts[4]
                                })
                                .ToList();
            //Raggruppa i libri per genere e crea gli scaffali
            var scaffali= allBooks.GroupBy(l => l.Genere)
                                   .Select(g => new Scaffale
                                   {
                                       GenereId = g.Key,
                                       ScaffaleDiLibri = g.ToList()
                                   })
                                   .ToList();
            //Aggiungi scaffali e libri al contesto
            Libreria.AddRange(scaffali);
            SaveChanges();
        }
    }
}
