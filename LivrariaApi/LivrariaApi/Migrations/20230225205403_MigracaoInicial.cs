using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LivrariaApi.Migrations
{
    /// <inheritdoc />
    public partial class MigracaoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Autor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    DataDeNascimento = table.Column<DateTime>(type: "DATE", nullable: true),
                    Nacionalidade = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    ResumoBibliografico = table.Column<string>(type: "NVARCHAR(1200)", maxLength: 1200, nullable: true),
                    Foto = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autor", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Livro",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: false),
                    Subtitulo = table.Column<string>(type: "NVARCHAR(100)", maxLength: 100, nullable: true),
                    Resumo = table.Column<string>(type: "NVARCHAR(500)", maxLength: 500, nullable: true),
                    QuantidadeDePaginas = table.Column<short>(type: "SMALLINT", nullable: false),
                    DataDePublicacao = table.Column<DateTime>(type: "DATE", nullable: false),
                    Editora = table.Column<string>(type: "NVARCHAR(150)", maxLength: 150, nullable: false),
                    Edicao = table.Column<byte>(type: "TINYINT", nullable: true),
                    ISBN = table.Column<string>(type: "VARCHAR(13)", maxLength: 13, nullable: true),
                    QuantidadeEmEstoque = table.Column<short>(type: "SMALLINT", nullable: false, defaultValue: (short)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Livro", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AutorLivro",
                columns: table => new
                {
                    AutorId = table.Column<int>(type: "int", nullable: false),
                    LivroId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutorLivro", x => new { x.AutorId, x.LivroId });
                    table.ForeignKey(
                        name: "FK_LivroAutor_AutorId",
                        column: x => x.AutorId,
                        principalTable: "Livro",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LivroAutor_LivroId",
                        column: x => x.LivroId,
                        principalTable: "Autor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autor_Nome",
                table: "Autor",
                column: "Nome");

            migrationBuilder.CreateIndex(
                name: "IX_AutorLivro_LivroId",
                table: "AutorLivro",
                column: "LivroId");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_ISBN",
                table: "Livro",
                column: "ISBN");

            migrationBuilder.CreateIndex(
                name: "IX_Livro_Titulo",
                table: "Livro",
                column: "Titulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutorLivro");

            migrationBuilder.DropTable(
                name: "Livro");

            migrationBuilder.DropTable(
                name: "Autor");
        }
    }
}
