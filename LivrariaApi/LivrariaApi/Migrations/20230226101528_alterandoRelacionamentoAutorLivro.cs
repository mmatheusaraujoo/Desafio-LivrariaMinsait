using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaApi.Migrations
{
    /// <inheritdoc />
    public partial class alterandoRelacionamentoAutorLivro : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_AutorId",
                table: "AutorLivro");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_LivroId",
                table: "AutorLivro");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_AutorId",
                table: "AutorLivro",
                column: "AutorId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_LivroId",
                table: "AutorLivro",
                column: "LivroId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_AutorId",
                table: "AutorLivro");

            migrationBuilder.DropForeignKey(
                name: "FK_LivroAutor_LivroId",
                table: "AutorLivro");

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_AutorId",
                table: "AutorLivro",
                column: "AutorId",
                principalTable: "Livro",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LivroAutor_LivroId",
                table: "AutorLivro",
                column: "LivroId",
                principalTable: "Autor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
