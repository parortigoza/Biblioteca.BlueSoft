using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class Agregatablas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categoria",
                schema: "dbo",
                columns: table => new
                {
                    CategoriaId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nombre = table.Column<string>(type: "varchar(150)", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(150)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categoria", x => x.CategoriaId);
                });

            migrationBuilder.CreateTable(
                name: "Libro",
                schema: "dbo",
                columns: table => new
                {
                    Isbn = table.Column<string>(type: "varchar(13)", nullable: false),
                    NombreLibro = table.Column<string>(type: "varchar(150)", nullable: false),
                    AutorId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Libro", x => x.Isbn);
                    table.ForeignKey(
                        name: "FK_Libro_Autor_AutorId",
                        column: x => x.AutorId,
                        principalSchema: "dbo",
                        principalTable: "Autor",
                        principalColumn: "AutorId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LibroCategoria",
                schema: "dbo",
                columns: table => new
                {
                    Isbn = table.Column<string>(nullable: false),
                    CategoriaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LibroCategoria", x => new { x.Isbn, x.CategoriaId });
                    table.ForeignKey(
                        name: "FK_LibroCategoria_Categoria_CategoriaId",
                        column: x => x.CategoriaId,
                        principalSchema: "dbo",
                        principalTable: "Categoria",
                        principalColumn: "CategoriaId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LibroCategoria_Libro_Isbn",
                        column: x => x.Isbn,
                        principalSchema: "dbo",
                        principalTable: "Libro",
                        principalColumn: "Isbn",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Libro_AutorId",
                schema: "dbo",
                table: "Libro",
                column: "AutorId");

            migrationBuilder.CreateIndex(
                name: "IX_Libro_Isbn",
                schema: "dbo",
                table: "Libro",
                column: "Isbn",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LibroCategoria_CategoriaId",
                schema: "dbo",
                table: "LibroCategoria",
                column: "CategoriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LibroCategoria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Categoria",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Libro",
                schema: "dbo");
        }
    }
}
