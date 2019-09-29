using Microsoft.EntityFrameworkCore.Migrations;

namespace Biblioteca.Migrations
{
    public partial class actualizaLibro : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_Fk_AutorInfo",
                schema: "dbo",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "Fk_AutorInfo",
                schema: "dbo",
                table: "Libro",
                newName: "AutorId");

            migrationBuilder.RenameIndex(
                name: "IX_Libro_Fk_AutorInfo",
                schema: "dbo",
                table: "Libro",
                newName: "IX_Libro_AutorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_AutorId",
                schema: "dbo",
                table: "Libro",
                column: "AutorId",
                principalSchema: "dbo",
                principalTable: "Autor",
                principalColumn: "AutorId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Libro_Autor_AutorId",
                schema: "dbo",
                table: "Libro");

            migrationBuilder.RenameColumn(
                name: "AutorId",
                schema: "dbo",
                table: "Libro",
                newName: "Fk_AutorInfo");

            migrationBuilder.RenameIndex(
                name: "IX_Libro_AutorId",
                schema: "dbo",
                table: "Libro",
                newName: "IX_Libro_Fk_AutorInfo");

            migrationBuilder.AddForeignKey(
                name: "FK_Libro_Autor_Fk_AutorInfo",
                schema: "dbo",
                table: "Libro",
                column: "Fk_AutorInfo",
                principalSchema: "dbo",
                principalTable: "Autor",
                principalColumn: "AutorId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
