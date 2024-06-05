using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace LibreriaDefinitiva.Migrations
{
    /// <inheritdoc />
    public partial class LibreriaDefinitiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Scaffali",
                columns: table => new
                {
                    ScaffaleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Scaffali", x => x.ScaffaleId);
                });

            migrationBuilder.CreateTable(
                name: "Libri",
                columns: table => new
                {
                    LibroId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isbn = table.Column<string>(type: "nvarchar(17)", maxLength: 17, nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Prezzo = table.Column<double>(type: "float", nullable: false),
                    Quantita = table.Column<int>(type: "int", nullable: false),
                    ScaffaleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libri", x => x.LibroId);
                    table.ForeignKey(
                        name: "FK_Libri_Scaffali_ScaffaleId",
                        column: x => x.ScaffaleId,
                        principalTable: "Scaffali",
                        principalColumn: "ScaffaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Scaffali",
                columns: new[] { "ScaffaleId", "Genere" },
                values: new object[,]
                {
                    { 1, "Poesia epica" },
                    { 2, "Romanzo storico" },
                    { 3, "Romanzo" },
                    { 4, "Letteratura per ragazzi" },
                    { 5, "Romanzo gotico" },
                    { 6, "Romanzo distopico" },
                    { 7, "Fantasy" },
                    { 8, "Romanzo parodico" },
                    { 9, "Romanzo d'avventura" },
                    { 10, "Romanzo breve" },
                    { 11, "Romanzo psicologico" },
                    { 12, "Romanzo fantasy" },
                    { 13, "Romanzo fantastico" },
                    { 14, "Romanzo per ragazzi" },
                    { 15, "Romanzo giallo" },
                    { 16, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Libri",
                columns: new[] { "LibroId", "Autore", "Edizione", "Genere", "Isbn", "Prezzo", "Quantita", "ScaffaleId", "Titolo" },
                values: new object[,]
                {
                    { 1, "Dante Alighieri", "Mondadori", "Poesia epica", "9788804507379", 1500.0, 15, 1, "Divina Commedia" },
                    { 2, "Giuseppe Tomasi di Lampedusa", "Mondadori", "Romanzo storico", "9788806213941", 1200.0, 3, 2, "Il Gattopardo" },
                    { 3, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804508994", 1600.0, 4, 2, "Il nome della rosa" },
                    { 4, "Lev Tolstoj", "Mondadori", "Romanzo storico", "9788804508932", 1700.0, 19, 2, "Guerra e pace" },
                    { 5, "Marguerite Yourcenar", "Mondadori", "Romanzo storico", "9788804587978", 1400.0, 12, 2, "Memorie di Adriano" },
                    { 6, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804617069", 1600.0, 18, 2, "L'isola del giorno prima" },
                    { 7, "Jane Austen", "Mondadori", "Romanzo", "9788804484144", 1000.0, 9, 3, "Orgoglio e pregiudizio" },
                    { 8, "Lev Tolstoj", "Mondadori", "Romanzo", "9788804527025", 1400.0, 16, 3, "Anna Karenina" },
                    { 9, "Gustave Flaubert", "Mondadori", "Romanzo", "9788804533163", 1200.0, 18, 3, "Madame Bovary" },
                    { 10, "James Joyce", "Mondadori", "Romanzo", "9788804489606", 1800.0, 20, 3, "Ulysses" },
                    { 11, "Stendhal", "Mondadori", "Romanzo", "9788804484274", 1000.0, 6, 3, "Il rosso e il nero" },
                    { 12, "Ernest Hemingway", "Mondadori", "Romanzo", "9788804522037", 1000.0, 17, 3, "Il vecchio e il mare" },
                    { 13, "F. Scott Fitzgerald", "Mondadori", "Romanzo", "9788804707181", 1200.0, 20, 3, "Il grande Gatsby" },
                    { 14, "Italo Calvino", "Arnoldo Mondadori Editore", "Romanzo", "9788804642928", 1500.0, 15, 3, "Il sentiero dei nidi di ragno" },
                    { 15, "Albert Camus", "Mondadori", "Romanzo", "9788804619223", 1100.0, 10, 3, "Lo straniero" },
                    { 16, "Victor Hugo", "Mondadori", "Romanzo", "9788804514193", 1800.0, 3, 3, "I miserabili" },
                    { 17, "Vladimir Nabokov", "Mondadori", "Romanzo", "9788804605370", 1500.0, 14, 3, "Lolita" },
                    { 18, "Luigi Pirandello", "Mondadori", "Romanzo", "9788804527438", 1000.0, 12, 3, "Il fu Mattia Pascal" },
                    { 19, "Dino Buzzati", "Mondadori", "Romanzo", "9788804694156", 1300.0, 5, 3, "Il deserto dei tartari" },
                    { 20, "J.D. Salinger", "Mondadori", "Romanzo", "9788804701783", 1200.0, 9, 3, "Il giovane Holden" },
                    { 21, "Carlo Cassola", "Mondadori", "Romanzo", "9788804656758", 1000.0, 11, 3, "La ragazza di Bube" },
                    { 22, "Isaac Asimov", "Mondadori", "Romanzo", "9788804607626", 1400.0, 15, 3, "Giorni di un futuro passato" },
                    { 23, "Miguel de Cervantes", "Mondadori", "Romanzo", "9788804514194", 1700.0, 2, 3, "Don Chisciotte" },
                    { 24, "Franz Kafka", "Mondadori", "Romanzo", "9788804706375", 1400.0, 10, 3, "Il processo" },
                    { 25, "Carlos Ruiz Zafón", "Mondadori", "Romanzo", "9788804708065", 1500.0, 8, 3, "L'ombra del vento" },
                    { 26, "Primo Levi", "Mondadori", "Romanzo", "9788804708027", 1200.0, 15, 3, "La tregua" },
                    { 27, "Gabriel Garcia Marquez", "Mondadori", "Romanzo", "9788804707037", 1300.0, 14, 3, "L'amore ai tempi del colera" },
                    { 28, "Isabel Allende", "Mondadori", "Romanzo", "9788804705088", 1500.0, 10, 3, "La casa degli spiriti" },
                    { 29, "Khaled Hosseini", "Mondadori", "Romanzo", "9788804705279", 1200.0, 16, 3, "Il cacciatore di aquiloni" },
                    { 30, "Gabriel Garcia Marquez", "Mondadori", "Romanzo", "9788804704258", 1400.0, 13, 3, "Cent'anni di solitudine" },
                    { 31, "Patrick Süskind", "Mondadori", "Romanzo", "9788804706184", 1300.0, 12, 3, "Il profumo" },
                    { 32, "Haruki Murakami", "Mondadori", "Romanzo", "9788804706320", 1400.0, 11, 3, "Norwegian Wood" },
                    { 33, "Milan Kundera", "Mondadori", "Romanzo", "9788804705415", 1200.0, 9, 3, "L'insostenibile leggerezza dell'essere" },
                    { 34, "Boris Pasternak", "Mondadori", "Romanzo", "9788804704470", 1600.0, 10, 3, "Il dottor Zivago" },
                    { 35, "Virginia Woolf", "Mondadori", "Romanzo", "9788804705569", 1100.0, 14, 3, "Le onde" },
                    { 36, "Richard Bach", "Mondadori", "Romanzo", "9788804705828", 900.0, 20, 3, "Il gabbiano Jonathan Livingston" },
                    { 37, "Harper Lee", "Mondadori", "Romanzo", "9788804706788", 1200.0, 17, 3, "Il buio oltre la siepe" },
                    { 38, "Mario Puzo", "Mondadori", "Romanzo", "9788804707587", 1400.0, 13, 3, "Il padrino" },
                    { 39, "Antoine de Saint-Exupéry", "Mondadori", "Letteratura per ragazzi", "9788804499179", 900.0, 7, 4, "Il Piccolo Principe" },
                    { 40, "Emily Brontë", "Mondadori", "Romanzo gotico", "9788806170350", 1300.0, 12, 5, "Cime tempestose" },
                    { 41, "Oscar Wilde", "Mondadori", "Romanzo gotico", "9788804673380", 1100.0, 16, 5, "Il ritratto di Dorian Gray" },
                    { 42, "Mary Shelley", "Mondadori", "Romanzo gotico", "9788804707228", 1300.0, 11, 5, "Frankenstein" },
                    { 43, "Bram Stoker", "Mondadori", "Romanzo gotico", "9788804707884", 1200.0, 19, 5, "Dracula" },
                    { 44, "George Orwell", "Mondadori", "Romanzo distopico", "9788804210366", 1100.0, 8, 6, "1984" },
                    { 45, "Aldous Huxley", "Mondadori", "Romanzo distopico", "9788804667136", 1200.0, 4, 6, "Il mondo nuovo" },
                    { 46, "George Orwell", "Mondadori", "Romanzo distopico", "9788804621462", 1300.0, 16, 6, "1984" },
                    { 47, "Ray Bradbury", "Mondadori", "Romanzo distopico", "9788804667137", 1200.0, 7, 6, "Fahrenheit 451" },
                    { 48, "J.R.R. Tolkien", "Mondadori", "Fantasy", "9788804474718", 2000.0, 10, 7, "Il signore degli anelli" },
                    { 49, "George R.R. Martin", "Mondadori", "Fantasy", "9788804566621", 2000.0, 9, 7, "Cronache del ghiaccio e del fuoco - Il Trono di Spade" },
                    { 50, "Miguel de Cervantes", "Mondadori", "Romanzo parodico", "9788804661905", 1800.0, 5, 8, "Don Chisciotte della Mancia" },
                    { 51, "Herman Melville", "Mondadori", "Romanzo d'avventura", "9788804527827", 1500.0, 2, 9, "Moby Dick" },
                    { 52, "Alexandre Dumas", "Mondadori", "Romanzo d'avventura", "9788804508185", 1400.0, 11, 9, "Il conte di Montecristo" },
                    { 53, "Franz Kafka", "Mondadori", "Romanzo breve", "9788804668706", 800.0, 1, 10, "La metamorfosi" },
                    { 54, "Fred Uhlman", "Mondadori", "Romanzo breve", "9788804707112", 1000.0, 12, 10, "L'amico ritrovato" },
                    { 55, "Elie Wiesel", "Mondadori", "Romanzo breve", "9788804706610", 1000.0, 8, 10, "La notte" },
                    { 56, "Italo Svevo", "Mondadori", "Romanzo psicologico", "9788804482621", 1100.0, 13, 11, "La coscienza di Zeno" },
                    { 57, "Fëdor Dostoevskij", "Mondadori", "Romanzo psicologico", "9788804530865", 1400.0, 7, 11, "Delitto e castigo" },
                    { 58, "Michael Ende", "Mondadori", "Romanzo fantasy", "9788804702148", 1000.0, 14, 12, "La storia infinita" },
                    { 59, "Italo Calvino", "Mondadori", "Romanzo fantastico", "9788804512816", 1300.0, 4, 13, "Il visconte dimezzato" },
                    { 60, "Italo Calvino", "Mondadori", "Romanzo fantastico", "9788804683336", 1100.0, 18, 13, "Il barone rampante" },
                    { 61, "Lewis Carroll", "Mondadori", "Romanzo per ragazzi", "9788804680371", 900.0, 2, 14, "Le avventure di Alice nel Paese delle Meraviglie" },
                    { 62, "Antoine de Saint-Exupéry", "Mondadori", "Romanzo per ragazzi", "9788804619224", 900.0, 19, 14, "Il piccolo principe" },
                    { 63, "Arthur Conan Doyle", "Mondadori", "Romanzo giallo", "9788804707358", 1000.0, 18, 15, "Il mastino dei Baskerville" },
                    { 64, "Dan Brown", "Mondadori", "Thriller", "9788804708096", 1300.0, 15, 16, "Il Codice Da Vinci" },
                    { 65, "Dan Brown", "Mondadori", "Thriller", "9788804708126", 1200.0, 12, 16, "Angeli e demoni" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libri_ScaffaleId",
                table: "Libri",
                column: "ScaffaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libri");

            migrationBuilder.DropTable(
                name: "Scaffali");
        }
    }
}
