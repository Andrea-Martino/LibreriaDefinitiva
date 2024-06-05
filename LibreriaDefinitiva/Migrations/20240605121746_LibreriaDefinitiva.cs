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
                name: "Libro",
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
                    table.PrimaryKey("PK_Libro", x => x.LibroId);
                    table.ForeignKey(
                        name: "FK_Libro_Scaffali_ScaffaleId",
                        column: x => x.ScaffaleId,
                        principalTable: "Scaffali",
                        principalColumn: "ScaffaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Libro",
                columns: new[] { "LibroId", "Autore", "Edizione", "Genere", "Isbn", "Prezzo", "Quantita", "ScaffaleId", "Titolo" },
                values: new object[,]
                {
                    { 1, "Dante Alighieri", "Mondadori", "Poesia epica", "9788804507379", 1500.0, 15, 0, "Divina Commedia" },
                    { 2, "Giuseppe Tomasi di Lampedusa", "Mondadori", "Romanzo storico", "9788806213941", 1200.0, 3, 0, "Il Gattopardo" },
                    { 3, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804508994", 1600.0, 4, 0, "Il nome della rosa" },
                    { 4, "Lev Tolstoj", "Mondadori", "Romanzo storico", "9788804508932", 1700.0, 19, 0, "Guerra e pace" },
                    { 5, "Marguerite Yourcenar", "Mondadori", "Romanzo storico", "9788804587978", 1400.0, 12, 0, "Memorie di Adriano" },
                    { 6, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804617069", 1600.0, 18, 0, "L'isola del giorno prima" },
                    { 7, "Umberto Eco", "Mondadori", "Romanzo storico", "9788804673381", 1500.0, 3, 0, "Il nome della rosa" },
                    { 8, "Jane Austen", "Mondadori", "Romanzo", "9788804484144", 1000.0, 9, 0, "Orgoglio e pregiudizio" },
                    { 9, "Lev Tolstoj", "Mondadori", "Romanzo", "9788804527025", 1400.0, 16, 0, "Anna Karenina" },
                    { 10, "Gustave Flaubert", "Mondadori", "Romanzo", "9788804533163", 1200.0, 18, 0, "Madame Bovary" },
                    { 11, "James Joyce", "Mondadori", "Romanzo", "9788804489606", 1800.0, 20, 0, "Ulysses" },
                    { 12, "Stendhal", "Mondadori", "Romanzo", "9788804484274", 1000.0, 6, 0, "Il rosso e il nero" },
                    { 13, "Ernest Hemingway", "Mondadori", "Romanzo", "9788804522037", 1000.0, 17, 0, "Il vecchio e il mare" },
                    { 14, "F. Scott Fitzgerald", "Mondadori", "Romanzo", "9788804707181", 1200.0, 20, 0, "Il grande Gatsby" },
                    { 15, "Italo Calvino", "Arnoldo Mondadori Editore", "Romanzo", "9788804642928", 1500.0, 15, 0, "Il sentiero dei nidi di ragno" },
                    { 16, "Albert Camus", "Mondadori", "Romanzo", "9788804619223", 1100.0, 10, 0, "Lo straniero" },
                    { 17, "Victor Hugo", "Mondadori", "Romanzo", "9788804514193", 1800.0, 3, 0, "I miserabili" },
                    { 18, "Vladimir Nabokov", "Mondadori", "Romanzo", "9788804605370", 1500.0, 14, 0, "Lolita" },
                    { 19, "Luigi Pirandello", "Mondadori", "Romanzo", "9788804527438", 1000.0, 12, 0, "Il fu Mattia Pascal" },
                    { 20, "Dino Buzzati", "Mondadori", "Romanzo", "9788804694156", 1300.0, 5, 0, "Il deserto dei tartari" },
                    { 21, "J.D. Salinger", "Mondadori", "Romanzo", "9788804701783", 1200.0, 9, 0, "Il giovane Holden" },
                    { 22, "Carlo Cassola", "Mondadori", "Romanzo", "9788804656758", 1000.0, 11, 0, "La ragazza di Bube" },
                    { 23, "Isaac Asimov", "Mondadori", "Romanzo", "9788804607626", 1400.0, 15, 0, "Giorni di un futuro passato" },
                    { 24, "Miguel de Cervantes", "Mondadori", "Romanzo", "9788804514194", 1700.0, 2, 0, "Don Chisciotte" },
                    { 25, "Antoine de Saint-Exupéry", "Mondadori", "Letteratura per ragazzi", "9788804499179", 900.0, 7, 0, "Il Piccolo Principe" },
                    { 26, "Emily Brontë", "Mondadori", "Romanzo gotico", "9788806170350", 1300.0, 12, 0, "Cime tempestose" },
                    { 27, "Oscar Wilde", "Mondadori", "Romanzo gotico", "9788804673380", 1100.0, 16, 0, "Il ritratto di Dorian Gray" },
                    { 28, "George Orwell", "Mondadori", "Romanzo distopico", "9788804210366", 1100.0, 8, 0, "1984" },
                    { 29, "Aldous Huxley", "Mondadori", "Romanzo distopico", "9788804667136", 1200.0, 4, 0, "Il mondo nuovo" },
                    { 30, "George Orwell", "Mondadori", "Romanzo distopico", "9788804621462", 1300.0, 16, 0, "1984" },
                    { 31, "Ray Bradbury", "Mondadori", "Romanzo distopico", "9788804667137", 1200.0, 7, 0, "Fahrenheit 451" },
                    { 32, "J.R.R. Tolkien", "Mondadori", "Fantasy", "9788804474718", 2000.0, 10, 0, "Il signore degli anelli" },
                    { 33, "George R.R. Martin", "Mondadori", "Fantasy", "9788804566621", 2000.0, 9, 0, "Cronache del ghiaccio e del fuoco - Il Trono di Spade" },
                    { 34, "Miguel de Cervantes", "Mondadori", "Romanzo parodico", "9788804661905", 1800.0, 5, 0, "Don Chisciotte della Mancia" },
                    { 35, "Herman Melville", "Mondadori", "Romanzo d'avventura", "9788804527827", 1500.0, 2, 0, "Moby Dick" },
                    { 36, "Alexandre Dumas", "Mondadori", "Romanzo d'avventura", "9788804508185", 1400.0, 11, 0, "Il conte di Montecristo" },
                    { 37, "Franz Kafka", "Mondadori", "Romanzo breve", "9788804668706", 800.0, 1, 0, "La metamorfosi" },
                    { 38, "Italo Svevo", "Mondadori", "Romanzo psicologico", "9788804482621", 1100.0, 13, 0, "La coscienza di Zeno" },
                    { 39, "Fëdor Dostoevskij", "Mondadori", "Romanzo psicologico", "9788804530865", 1400.0, 7, 0, "Delitto e castigo" },
                    { 40, "Michael Ende", "Mondadori", "Romanzo fantasy", "9788804702148", 1000.0, 14, 0, "La storia infinita" },
                    { 41, "Italo Calvino", "Mondadori", "Romanzo fantastico", "9788804512816", 1300.0, 4, 0, "Il visconte dimezzato" },
                    { 42, "Italo Calvino", "Mondadori", "Romanzo fantastico", "9788804683336", 1100.0, 18, 0, "Il barone rampante" },
                    { 43, "Lewis Carroll", "Mondadori", "Romanzo per ragazzi", "9788804680371", 900.0, 2, 0, "Le avventure di Alice nel Paese delle Meraviglie" },
                    { 44, "Antoine de Saint-Exupéry", "Mondadori", "Romanzo per ragazzi", "9788804619224", 900.0, 19, 0, "Il piccolo principe" }
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
                    { 14, "Romanzo per ragazzi" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_ScaffaleId",
                table: "Libro",
                column: "ScaffaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Libro");

            migrationBuilder.DropTable(
                name: "Scaffali");
        }
    }
}
