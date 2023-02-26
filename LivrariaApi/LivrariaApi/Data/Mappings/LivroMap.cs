using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Data.Mappings
{
    public class LivroMap : IEntityTypeConfiguration<Livro>
    {
        public void Configure(EntityTypeBuilder<Livro> builder)
        {

            builder.ToTable("Livro");

            // Key
            builder.HasKey(x => x.Id);

            // Identity
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            // Propiedades
            builder.Property(x => x.Titulo)
                .IsRequired()
                .HasColumnName("Titulo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);
            builder.HasIndex(x => x.Titulo, "IX_Livro_Titulo");

            builder.Property(x => x.Subtitulo)
                .IsRequired(false)
                .HasColumnName("Subtitulo")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.Resumo)
               .IsRequired(false)
               .HasColumnName("Resumo")
               .HasColumnType("NVARCHAR")
               .HasMaxLength(500);

            builder.Property(x => x.QuantidadeDePaginas)
               .IsRequired()
               .HasColumnName("QuantidadeDePaginas")
               .HasColumnType("SMALLINT");

            builder.Property(x => x.DataDePublicacao)
                .IsRequired()
                .HasColumnName("DataDePublicacao")
                .HasColumnType("DATE");

            builder.Property(x => x.Editora)
                .IsRequired()
                .HasColumnName("Editora")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(150);

            builder.Property(x => x.Edicao)
                .IsRequired(false)
                .HasColumnName("Edicao")
                .HasColumnType("TINYINT");

            builder.Property(x => x.ISBN)
                .IsRequired(false)
                .HasColumnType("VARCHAR")
                .HasMaxLength(13);
            builder.HasIndex(x => x.ISBN, "IX_Livro_ISBN");

            builder.Property(x => x.QuantidadeEmEstoque)
                .IsRequired()
                .HasColumnName("QuantidadeEmEstoque")
                .HasColumnType("SMALLINT")
                .HasDefaultValue(0);

            builder.Property(x => x.FotoDaCapa)
                .IsRequired(false)
                .HasColumnName("FotoDaCapa")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);



            // Relacionamento

            builder.HasMany(x => x.Autores)
                .WithMany(x => x.Livros)
                .UsingEntity<Dictionary<string, object>>(
                    "AutorLivro",
                    livro => livro.HasOne<Autor>()
                        .WithMany()
                        .HasForeignKey("AutorId")
                        .HasConstraintName("FK_LivroAutor_AutorId")
                        .OnDelete(DeleteBehavior.Restrict),
                    autor => autor.HasOne<Livro>()
                        .WithMany()
                        .HasForeignKey("LivroId")
                        .HasConstraintName("FK_LivroAutor_LivroId")
                        .OnDelete(DeleteBehavior.Restrict));
        }
    }
}
