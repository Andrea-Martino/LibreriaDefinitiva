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
                    { 1, "Dante Alighieri", "Mondadori", "Poesia epica", "9788804507379", 15.0, 15, 1, "Divina Commedia" },
                    { 2, "Giuseppe Tomasi di Lampedusa", "Mondadori", "Romanzo storico", "9788806213941", 12.0, 3, 2, "Il Gattopardo" },
                    { 3, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804508994", 16.0, 4, 2, "Il nome della rosa" },
                    { 4, "Lev Tolstoj", "Mondadori", "Romanzo storico", "9788804508932", 17.0, 19, 2, "Guerra e pace" },
                    { 5, "Marguerite Yourcenar", "Mondadori", "Romanzo storico", "9788804587978", 14.0, 12, 2, "Memorie di Adriano" },
                    { 6, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804617069", 16.0, 18, 2, "L'isola del giorno prima" },
                    { 7, "Jane Austen", "Mondadori", "Romanzo", "9788804484144", 10.0, 9, 3, "Orgoglio e pregiudizio" },
                    { 8, "Lev Tolstoj", "Mondadori", "Romanzo", "9788804527025", 14.0, 16, 3, "Anna Karenina" },
                    { 9, "Gustave Flaubert", "Mondadori", "Romanzo", "9788804533163", 12.0, 18, 3, "Madame Bovary" },
                    { 10, "James Joyce", "Mondadori", "Romanzo", "9788804489606", 18.0, 20, 3, "Ulysses" },
                    { 11, "Stendhal", "Mondadori", "Romanzo", "9788804484274", 10.0, 6, 3, "Il rosso e il nero" },
                    { 12, "Ernest Hemingway", "Mondadori", "Romanzo", "9788804522037", 10.0, 17, 3, "Il vecchio e il mare" },
                    { 13, "F. Scott Fitzgerald", "Mondadori", "Romanzo", "9788804707181", 12.0, 20, 3, "Il grande Gatsby" },
                    { 14, "Italo Calvino", "Arnoldo Mondadori Editore", "Romanzo", "9788804642928", 15.0, 15, 3, "Il sentiero dei nidi di ragno" },
                    { 15, "Albert Camus", "Mondadori", "Romanzo", "9788804619223", 11.0, 10, 3, "Lo straniero" },
                    { 16, "Victor Hugo", "Mondadori", "Romanzo", "9788804514193", 18.0, 3, 3, "I miserabili" },
                    { 17, "Vladimir Nabokov", "Mondadori", "Romanzo", "9788804605370", 15.0, 14, 3, "Lolita" },
                    { 18, "Luigi Pirandello", "Mondadori", "Romanzo", "9788804527438", 10.0, 12, 3, "Il fu Mattia Pascal" },
                    { 19, "Dino Buzzati", "Mondadori", "Romanzo", "9788804694156", 13.0, 5, 3, "Il deserto dei tartari" },
                    { 20, "J.D. Salinger", "Mondadori", "Romanzo", "9788804701783", 12.0, 9, 3, "Il giovane Holden" },
                    { 21, "Carlo Cassola", "Mondadori", "Romanzo", "9788804656758", 10.0, 11, 3, "La ragazza di Bube" },
                    { 22, "Isaac Asimov", "Mondadori", "Romanzo", "9788804607626", 14.0, 15, 3, "Giorni di un futuro passato" },
                    { 23, "Miguel de Cervantes", "Mondadori", "Romanzo", "9788804514194", 17.0, 2, 3, "Don Chisciotte" },
                    { 24, "Franz Kafka", "Mondadori", "Romanzo", "9788804706375", 14.0, 10, 3, "Il processo" },
                    { 25, "Carlos Ruiz Zafón", "Mondadori", "Romanzo", "9788804708065", 15.0, 8, 3, "L'ombra del vento" },
                    { 26, "Primo Levi", "Mondadori", "Romanzo", "9788804708027", 12.0, 15, 3, "La tregua" },
                    { 27, "Gabriel Garcia Marquez", "Mondadori", "Romanzo", "9788804707037", 13.0, 14, 3, "L'amore ai tempi del colera" },
                    { 28, "Isabel Allende", "Mondadori", "Romanzo", "9788804705088", 15.0, 10, 3, "La casa degli spiriti" },
                    { 29, "Khaled Hosseini", "Mondadori", "Romanzo", "9788804705279", 12.0, 16, 3, "Il cacciatore di aquiloni" },
                    { 30, "Gabriel Garcia Marquez", "Mondadori", "Romanzo", "9788804704258", 14.0, 13, 3, "Cent'anni di solitudine" },
                    { 31, "Patrick Süskind", "Mondadori", "Romanzo", "9788804706184", 13.0, 12, 3, "Il profumo" },
                    { 32, "Haruki Murakami", "Mondadori", "Romanzo", "9788804706320", 14.0, 11, 3, "Norwegian Wood" },
                    { 33, "Milan Kundera", "Mondadori", "Romanzo", "9788804705415", 12.0, 9, 3, "L'insostenibile leggerezza dell'essere" },
                    { 34, "Boris Pasternak", "Mondadori", "Romanzo", "9788804704470", 16.0, 10, 3, "Il dottor Zivago" },
                    { 35, "Virginia Woolf", "Mondadori", "Romanzo", "9788804705569", 11.0, 14, 3, "Le onde" },
                    { 36, "Richard Bach", "Mondadori", "Romanzo", "9788804705828", 9.0, 20, 3, "Il gabbiano Jonathan Livingston" },
                    { 37, "Harper Lee", "Mondadori", "Romanzo", "9788804706788", 12.0, 17, 3, "Il buio oltre la siepe" },
                    { 38, "Mario Puzo", "Mondadori", "Romanzo", "9788804707587", 14.0, 13, 3, "Il padrino" },
                    { 39, "Antoine de Saint-Exupéry", "Mondadori", "Letteratura per ragazzi", "9788804499179", 9.0, 7, 4, "Il Piccolo Principe" },
                    { 40, "Emily Brontë", "Mondadori", "Romanzo gotico", "9788806170350", 13.0, 12, 5, "Cime tempestose" },
                    { 41, "Oscar Wilde", "Mondadori", "Romanzo gotico", "9788804673380", 11.0, 16, 5, "Il ritratto di Dorian Gray" },
                    { 42, "Mary Shelley", "Mondadori", "Romanzo gotico", "9788804707228", 13.0, 11, 5, "Frankenstein" },
                    { 43, "Bram Stoker", "Mondadori", "Romanzo gotico", "9788804707884", 12.0, 19, 5, "Dracula" },
                    { 44, "George Orwell", "Mondadori", "Romanzo distopico", "9788804210366", 11.0, 8, 6, "1984" },
                    { 45, "Aldous Huxley", "Mondadori", "Romanzo distopico", "9788804667136", 12.0, 4, 6, "Il mondo nuovo" },
                    { 46, "George Orwell", "Mondadori", "Romanzo distopico", "9788804621462", 13.0, 16, 6, "1984" },
                    { 47, "Ray Bradbury", "Mondadori", "Romanzo distopico", "9788804667137", 12.0, 7, 6, "Fahrenheit 451" },
                    { 48, "J.R.R. Tolkien", "Mondadori", "Fantasy", "9788804474718", 20.0, 10, 7, "Il signore degli anelli" },
                    { 49, "George R.R. Martin", "Mondadori", "Fantasy", "9788804566621", 20.0, 9, 7, "Cronache del ghiaccio e del fuoco - Il Trono di Spade" },
                    { 50, "Miguel de Cervantes", "Mondadori", "Romanzo parodico", "9788804661905", 18.0, 5, 8, "Don Chisciotte della Mancia" },
                    { 51, "Herman Melville", "Mondadori", "Romanzo d'avventura", "9788804527827", 15.0, 2, 9, "Moby Dick" },
                    { 52, "Alexandre Dumas", "Mondadori", "Romanzo d'avventura", "9788804508185", 14.0, 11, 9, "Il conte di Montecristo" },
                    { 53, "Franz Kafka", "Mondadori", "Romanzo breve", "9788804668706", 8.0, 1, 10, "La metamorfosi" },
                    { 54, "Fred Uhlman", "Mondadori", "Romanzo breve", "9788804707112", 10.0, 12, 10, "L'amico ritrovato" },
                    { 55, "Elie Wiesel", "Mondadori", "Romanzo breve", "9788804706610", 10.0, 8, 10, "La notte" },
                    { 56, "Italo Svevo", "Mondadori", "Romanzo psicologico", "9788804482621", 11.0, 13, 11, "La coscienza di Zeno" },
                    { 57, "Fëdor Dostoevskij", "Mondadori", "Romanzo psicologico", "9788804530865", 14.0, 7, 11, "Delitto e castigo" },
                    { 58, "Michael Ende", "Mondadori", "Romanzo fantasy", "9788804702148", 10.0, 14, 12, "La storia infinita" },
                    { 59, "Italo Calvino", "Mondadori", "Romanzo fantastico", "9788804512816", 13.0, 4, 13, "Il visconte dimezzato" },
                    { 60, "Italo Calvino", "Mondadori", "Romanzo fantastico", "9788804683336", 11.0, 18, 13, "Il barone rampante" },
                    { 61, "Lewis Carroll", "Mondadori", "Romanzo per ragazzi", "9788804680371", 9.0, 2, 14, "Le avventure di Alice nel Paese delle Meraviglie" },
                    { 62, "Antoine de Saint-Exupéry", "Mondadori", "Romanzo per ragazzi", "9788804619224", 9.0, 19, 14, "Il piccolo principe" },
                    { 63, "Arthur Conan Doyle", "Mondadori", "Romanzo giallo", "9788804707358", 10.0, 18, 15, "Il mastino dei Baskerville" },
                    { 64, "Dan Brown", "Mondadori", "Thriller", "9788804708096", 13.0, 15, 16, "Il Codice Da Vinci" },
                    { 65, "Dan Brown", "Mondadori", "Thriller", "9788804708126", 12.0, 12, 16, "Angeli e demoni" }
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
