﻿// <auto-generated />
using LibreriaDefinitiva.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibreriaDefinitiva.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("LibreriaDefinitiva.Models.Libro", b =>
                {
                    b.Property<int>("LibroId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("LibroId"));

                    b.Property<string>("Autore")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Edizione")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Isbn")
                        .IsRequired()
                        .HasMaxLength(17)
                        .HasColumnType("nvarchar(17)");

                    b.Property<double>("Prezzo")
                        .HasColumnType("float");

                    b.Property<int>("Quantita")
                        .HasColumnType("int");

                    b.Property<int>("ScaffaleId")
                        .HasColumnType("int");

                    b.Property<string>("Titolo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LibroId");

                    b.HasIndex("ScaffaleId");

                    b.ToTable("Libro");

                    b.HasData(
                        new
                        {
                            LibroId = 1,
                            Autore = "Dante Alighieri",
                            Edizione = "Mondadori",
                            Genere = "Poesia epica",
                            Isbn = "9788804507379",
                            Prezzo = 1500.0,
                            Quantita = 15,
                            ScaffaleId = 0,
                            Titolo = "Divina Commedia"
                        },
                        new
                        {
                            LibroId = 2,
                            Autore = "Giuseppe Tomasi di Lampedusa",
                            Edizione = "Mondadori",
                            Genere = "Romanzo storico",
                            Isbn = "9788806213941",
                            Prezzo = 1200.0,
                            Quantita = 3,
                            ScaffaleId = 0,
                            Titolo = "Il Gattopardo"
                        },
                        new
                        {
                            LibroId = 3,
                            Autore = "Umberto Eco",
                            Edizione = "Mondadori",
                            Genere = "Romanzo storico",
                            Isbn = "9788804508994",
                            Prezzo = 1600.0,
                            Quantita = 4,
                            ScaffaleId = 0,
                            Titolo = "Il nome della rosa"
                        },
                        new
                        {
                            LibroId = 4,
                            Autore = "Lev Tolstoj",
                            Edizione = "Mondadori",
                            Genere = "Romanzo storico",
                            Isbn = "9788804508932",
                            Prezzo = 1700.0,
                            Quantita = 19,
                            ScaffaleId = 0,
                            Titolo = "Guerra e pace"
                        },
                        new
                        {
                            LibroId = 5,
                            Autore = "Marguerite Yourcenar",
                            Edizione = "Mondadori",
                            Genere = "Romanzo storico",
                            Isbn = "9788804587978",
                            Prezzo = 1400.0,
                            Quantita = 12,
                            ScaffaleId = 0,
                            Titolo = "Memorie di Adriano"
                        },
                        new
                        {
                            LibroId = 6,
                            Autore = "Umberto Eco",
                            Edizione = "Mondadori",
                            Genere = "Romanzo storico",
                            Isbn = "9788804617069",
                            Prezzo = 1600.0,
                            Quantita = 18,
                            ScaffaleId = 0,
                            Titolo = "L'isola del giorno prima"
                        },
                        new
                        {
                            LibroId = 7,
                            Autore = "Umberto Eco",
                            Edizione = "Mondadori",
                            Genere = "Romanzo storico",
                            Isbn = "9788804673381",
                            Prezzo = 1500.0,
                            Quantita = 3,
                            ScaffaleId = 0,
                            Titolo = "Il nome della rosa"
                        },
                        new
                        {
                            LibroId = 8,
                            Autore = "Jane Austen",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804484144",
                            Prezzo = 1000.0,
                            Quantita = 9,
                            ScaffaleId = 0,
                            Titolo = "Orgoglio e pregiudizio"
                        },
                        new
                        {
                            LibroId = 9,
                            Autore = "Lev Tolstoj",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804527025",
                            Prezzo = 1400.0,
                            Quantita = 16,
                            ScaffaleId = 0,
                            Titolo = "Anna Karenina"
                        },
                        new
                        {
                            LibroId = 10,
                            Autore = "Gustave Flaubert",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804533163",
                            Prezzo = 1200.0,
                            Quantita = 18,
                            ScaffaleId = 0,
                            Titolo = "Madame Bovary"
                        },
                        new
                        {
                            LibroId = 11,
                            Autore = "James Joyce",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804489606",
                            Prezzo = 1800.0,
                            Quantita = 20,
                            ScaffaleId = 0,
                            Titolo = "Ulysses"
                        },
                        new
                        {
                            LibroId = 12,
                            Autore = "Stendhal",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804484274",
                            Prezzo = 1000.0,
                            Quantita = 6,
                            ScaffaleId = 0,
                            Titolo = "Il rosso e il nero"
                        },
                        new
                        {
                            LibroId = 13,
                            Autore = "Ernest Hemingway",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804522037",
                            Prezzo = 1000.0,
                            Quantita = 17,
                            ScaffaleId = 0,
                            Titolo = "Il vecchio e il mare"
                        },
                        new
                        {
                            LibroId = 14,
                            Autore = "F. Scott Fitzgerald",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804707181",
                            Prezzo = 1200.0,
                            Quantita = 20,
                            ScaffaleId = 0,
                            Titolo = "Il grande Gatsby"
                        },
                        new
                        {
                            LibroId = 15,
                            Autore = "Italo Calvino",
                            Edizione = "Arnoldo Mondadori Editore",
                            Genere = "Romanzo",
                            Isbn = "9788804642928",
                            Prezzo = 1500.0,
                            Quantita = 15,
                            ScaffaleId = 0,
                            Titolo = "Il sentiero dei nidi di ragno"
                        },
                        new
                        {
                            LibroId = 16,
                            Autore = "Albert Camus",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804619223",
                            Prezzo = 1100.0,
                            Quantita = 10,
                            ScaffaleId = 0,
                            Titolo = "Lo straniero"
                        },
                        new
                        {
                            LibroId = 17,
                            Autore = "Victor Hugo",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804514193",
                            Prezzo = 1800.0,
                            Quantita = 3,
                            ScaffaleId = 0,
                            Titolo = "I miserabili"
                        },
                        new
                        {
                            LibroId = 18,
                            Autore = "Vladimir Nabokov",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804605370",
                            Prezzo = 1500.0,
                            Quantita = 14,
                            ScaffaleId = 0,
                            Titolo = "Lolita"
                        },
                        new
                        {
                            LibroId = 19,
                            Autore = "Luigi Pirandello",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804527438",
                            Prezzo = 1000.0,
                            Quantita = 12,
                            ScaffaleId = 0,
                            Titolo = "Il fu Mattia Pascal"
                        },
                        new
                        {
                            LibroId = 20,
                            Autore = "Dino Buzzati",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804694156",
                            Prezzo = 1300.0,
                            Quantita = 5,
                            ScaffaleId = 0,
                            Titolo = "Il deserto dei tartari"
                        },
                        new
                        {
                            LibroId = 21,
                            Autore = "J.D. Salinger",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804701783",
                            Prezzo = 1200.0,
                            Quantita = 9,
                            ScaffaleId = 0,
                            Titolo = "Il giovane Holden"
                        },
                        new
                        {
                            LibroId = 22,
                            Autore = "Carlo Cassola",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804656758",
                            Prezzo = 1000.0,
                            Quantita = 11,
                            ScaffaleId = 0,
                            Titolo = "La ragazza di Bube"
                        },
                        new
                        {
                            LibroId = 23,
                            Autore = "Isaac Asimov",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804607626",
                            Prezzo = 1400.0,
                            Quantita = 15,
                            ScaffaleId = 0,
                            Titolo = "Giorni di un futuro passato"
                        },
                        new
                        {
                            LibroId = 24,
                            Autore = "Miguel de Cervantes",
                            Edizione = "Mondadori",
                            Genere = "Romanzo",
                            Isbn = "9788804514194",
                            Prezzo = 1700.0,
                            Quantita = 2,
                            ScaffaleId = 0,
                            Titolo = "Don Chisciotte"
                        },
                        new
                        {
                            LibroId = 25,
                            Autore = "Antoine de Saint-Exupéry",
                            Edizione = "Mondadori",
                            Genere = "Letteratura per ragazzi",
                            Isbn = "9788804499179",
                            Prezzo = 900.0,
                            Quantita = 7,
                            ScaffaleId = 0,
                            Titolo = "Il Piccolo Principe"
                        },
                        new
                        {
                            LibroId = 26,
                            Autore = "Emily Brontë",
                            Edizione = "Mondadori",
                            Genere = "Romanzo gotico",
                            Isbn = "9788806170350",
                            Prezzo = 1300.0,
                            Quantita = 12,
                            ScaffaleId = 0,
                            Titolo = "Cime tempestose"
                        },
                        new
                        {
                            LibroId = 27,
                            Autore = "Oscar Wilde",
                            Edizione = "Mondadori",
                            Genere = "Romanzo gotico",
                            Isbn = "9788804673380",
                            Prezzo = 1100.0,
                            Quantita = 16,
                            ScaffaleId = 0,
                            Titolo = "Il ritratto di Dorian Gray"
                        },
                        new
                        {
                            LibroId = 28,
                            Autore = "George Orwell",
                            Edizione = "Mondadori",
                            Genere = "Romanzo distopico",
                            Isbn = "9788804210366",
                            Prezzo = 1100.0,
                            Quantita = 8,
                            ScaffaleId = 0,
                            Titolo = "1984"
                        },
                        new
                        {
                            LibroId = 29,
                            Autore = "Aldous Huxley",
                            Edizione = "Mondadori",
                            Genere = "Romanzo distopico",
                            Isbn = "9788804667136",
                            Prezzo = 1200.0,
                            Quantita = 4,
                            ScaffaleId = 0,
                            Titolo = "Il mondo nuovo"
                        },
                        new
                        {
                            LibroId = 30,
                            Autore = "George Orwell",
                            Edizione = "Mondadori",
                            Genere = "Romanzo distopico",
                            Isbn = "9788804621462",
                            Prezzo = 1300.0,
                            Quantita = 16,
                            ScaffaleId = 0,
                            Titolo = "1984"
                        },
                        new
                        {
                            LibroId = 31,
                            Autore = "Ray Bradbury",
                            Edizione = "Mondadori",
                            Genere = "Romanzo distopico",
                            Isbn = "9788804667137",
                            Prezzo = 1200.0,
                            Quantita = 7,
                            ScaffaleId = 0,
                            Titolo = "Fahrenheit 451"
                        },
                        new
                        {
                            LibroId = 32,
                            Autore = "J.R.R. Tolkien",
                            Edizione = "Mondadori",
                            Genere = "Fantasy",
                            Isbn = "9788804474718",
                            Prezzo = 2000.0,
                            Quantita = 10,
                            ScaffaleId = 0,
                            Titolo = "Il signore degli anelli"
                        },
                        new
                        {
                            LibroId = 33,
                            Autore = "George R.R. Martin",
                            Edizione = "Mondadori",
                            Genere = "Fantasy",
                            Isbn = "9788804566621",
                            Prezzo = 2000.0,
                            Quantita = 9,
                            ScaffaleId = 0,
                            Titolo = "Cronache del ghiaccio e del fuoco - Il Trono di Spade"
                        },
                        new
                        {
                            LibroId = 34,
                            Autore = "Miguel de Cervantes",
                            Edizione = "Mondadori",
                            Genere = "Romanzo parodico",
                            Isbn = "9788804661905",
                            Prezzo = 1800.0,
                            Quantita = 5,
                            ScaffaleId = 0,
                            Titolo = "Don Chisciotte della Mancia"
                        },
                        new
                        {
                            LibroId = 35,
                            Autore = "Herman Melville",
                            Edizione = "Mondadori",
                            Genere = "Romanzo d'avventura",
                            Isbn = "9788804527827",
                            Prezzo = 1500.0,
                            Quantita = 2,
                            ScaffaleId = 0,
                            Titolo = "Moby Dick"
                        },
                        new
                        {
                            LibroId = 36,
                            Autore = "Alexandre Dumas",
                            Edizione = "Mondadori",
                            Genere = "Romanzo d'avventura",
                            Isbn = "9788804508185",
                            Prezzo = 1400.0,
                            Quantita = 11,
                            ScaffaleId = 0,
                            Titolo = "Il conte di Montecristo"
                        },
                        new
                        {
                            LibroId = 37,
                            Autore = "Franz Kafka",
                            Edizione = "Mondadori",
                            Genere = "Romanzo breve",
                            Isbn = "9788804668706",
                            Prezzo = 800.0,
                            Quantita = 1,
                            ScaffaleId = 0,
                            Titolo = "La metamorfosi"
                        },
                        new
                        {
                            LibroId = 38,
                            Autore = "Italo Svevo",
                            Edizione = "Mondadori",
                            Genere = "Romanzo psicologico",
                            Isbn = "9788804482621",
                            Prezzo = 1100.0,
                            Quantita = 13,
                            ScaffaleId = 0,
                            Titolo = "La coscienza di Zeno"
                        },
                        new
                        {
                            LibroId = 39,
                            Autore = "Fëdor Dostoevskij",
                            Edizione = "Mondadori",
                            Genere = "Romanzo psicologico",
                            Isbn = "9788804530865",
                            Prezzo = 1400.0,
                            Quantita = 7,
                            ScaffaleId = 0,
                            Titolo = "Delitto e castigo"
                        },
                        new
                        {
                            LibroId = 40,
                            Autore = "Michael Ende",
                            Edizione = "Mondadori",
                            Genere = "Romanzo fantasy",
                            Isbn = "9788804702148",
                            Prezzo = 1000.0,
                            Quantita = 14,
                            ScaffaleId = 0,
                            Titolo = "La storia infinita"
                        },
                        new
                        {
                            LibroId = 41,
                            Autore = "Italo Calvino",
                            Edizione = "Mondadori",
                            Genere = "Romanzo fantastico",
                            Isbn = "9788804512816",
                            Prezzo = 1300.0,
                            Quantita = 4,
                            ScaffaleId = 0,
                            Titolo = "Il visconte dimezzato"
                        },
                        new
                        {
                            LibroId = 42,
                            Autore = "Italo Calvino",
                            Edizione = "Mondadori",
                            Genere = "Romanzo fantastico",
                            Isbn = "9788804683336",
                            Prezzo = 1100.0,
                            Quantita = 18,
                            ScaffaleId = 0,
                            Titolo = "Il barone rampante"
                        },
                        new
                        {
                            LibroId = 43,
                            Autore = "Lewis Carroll",
                            Edizione = "Mondadori",
                            Genere = "Romanzo per ragazzi",
                            Isbn = "9788804680371",
                            Prezzo = 900.0,
                            Quantita = 2,
                            ScaffaleId = 0,
                            Titolo = "Le avventure di Alice nel Paese delle Meraviglie"
                        },
                        new
                        {
                            LibroId = 44,
                            Autore = "Antoine de Saint-Exupéry",
                            Edizione = "Mondadori",
                            Genere = "Romanzo per ragazzi",
                            Isbn = "9788804619224",
                            Prezzo = 900.0,
                            Quantita = 19,
                            ScaffaleId = 0,
                            Titolo = "Il piccolo principe"
                        });
                });

            modelBuilder.Entity("LibreriaDefinitiva.Models.Scaffale", b =>
                {
                    b.Property<int>("ScaffaleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ScaffaleId"));

                    b.Property<string>("Genere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ScaffaleId");

                    b.ToTable("Scaffali");

                    b.HasData(
                        new
                        {
                            ScaffaleId = -1,
                            Genere = "Poesia epica"
                        },
                        new
                        {
                            ScaffaleId = -2,
                            Genere = "Romanzo storico"
                        },
                        new
                        {
                            ScaffaleId = -3,
                            Genere = "Romanzo"
                        },
                        new
                        {
                            ScaffaleId = -4,
                            Genere = "Letteratura per ragazzi"
                        },
                        new
                        {
                            ScaffaleId = -5,
                            Genere = "Romanzo gotico"
                        },
                        new
                        {
                            ScaffaleId = -6,
                            Genere = "Romanzo distopico"
                        },
                        new
                        {
                            ScaffaleId = -7,
                            Genere = "Fantasy"
                        },
                        new
                        {
                            ScaffaleId = -8,
                            Genere = "Romanzo parodico"
                        },
                        new
                        {
                            ScaffaleId = -9,
                            Genere = "Romanzo d'avventura"
                        },
                        new
                        {
                            ScaffaleId = -10,
                            Genere = "Romanzo breve"
                        },
                        new
                        {
                            ScaffaleId = -11,
                            Genere = "Romanzo psicologico"
                        },
                        new
                        {
                            ScaffaleId = -12,
                            Genere = "Romanzo fantasy"
                        },
                        new
                        {
                            ScaffaleId = -13,
                            Genere = "Romanzo fantastico"
                        },
                        new
                        {
                            ScaffaleId = -14,
                            Genere = "Romanzo per ragazzi"
                        });
                });

            modelBuilder.Entity("LibreriaDefinitiva.Models.Libro", b =>
                {
                    b.HasOne("LibreriaDefinitiva.Models.Scaffale", "Scaffale")
                        .WithMany("ScaffaleDiLibri")
                        .HasForeignKey("ScaffaleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scaffale");
                });

            modelBuilder.Entity("LibreriaDefinitiva.Models.Scaffale", b =>
                {
                    b.Navigation("ScaffaleDiLibri");
                });
#pragma warning restore 612, 618
        }
    }
}
