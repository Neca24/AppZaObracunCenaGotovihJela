using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Artikli",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Jmere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    Cena = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artikli", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Jela",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Naziv = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(254)", maxLength: 254, nullable: false),
                    JedinicaMere = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jela", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Recepture",
                columns: table => new
                {
                    IdJelo = table.Column<int>(type: "int", nullable: false),
                    IdArtikal = table.Column<int>(type: "int", nullable: false),
                    Kolicina = table.Column<decimal>(type: "decimal(18,3)", precision: 18, scale: 3, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recepture", x => new { x.IdArtikal, x.IdJelo });
                    table.ForeignKey(
                        name: "FK_Recepture_Artikli_IdArtikal",
                        column: x => x.IdArtikal,
                        principalTable: "Artikli",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Recepture_Jela_IdJelo",
                        column: x => x.IdJelo,
                        principalTable: "Jela",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Recepture_IdJelo",
                table: "Recepture",
                column: "IdJelo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Recepture");

            migrationBuilder.DropTable(
                name: "Artikli");

            migrationBuilder.DropTable(
                name: "Jela");
        }
    }
}
