using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibreriaDefinitiva.Migrations
{
    /// <inheritdoc />
    public partial class LibreriaDefinitiva : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Libreria",
                columns: table => new
                {
                    ScaffaleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libreria", x => x.ScaffaleId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "nvarchar(13)", maxLength: 13, nullable: false),
                    Titolo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Autore = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Genere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Edizione = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ScaffaleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Isbn);
                    table.ForeignKey(
                        name: "FK_Libro_Libreria_ScaffaleId",
                        column: x => x.ScaffaleId,
                        principalTable: "Libreria",
                        principalColumn: "ScaffaleId",
                        onDelete: ReferentialAction.Cascade);
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
                name: "Libreria");
        }
    }
}
