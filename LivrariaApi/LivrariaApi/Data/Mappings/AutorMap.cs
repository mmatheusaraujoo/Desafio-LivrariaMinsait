using LivrariaApi.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace LivrariaApi.Data.Mappings
{
    public class AutorMap : IEntityTypeConfiguration<Autor>
    {
        public void Configure(EntityTypeBuilder<Autor> builder)
        {
            builder.ToTable("Autor");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn();

            builder.Property(x => x.Nome)
                .IsRequired()
                .HasColumnName("Nome")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(50);

            builder.HasIndex(x => x.Nome, "IX_Autor_Nome");

            builder.Property(x => x.DataDeNascimento)
                .IsRequired(false)
                .HasColumnName("DataDeNascimento")
                .HasColumnType("DATE");

            builder.Property(x => x.Nacionalidade)
                .IsRequired(false)
                .HasColumnName("Nacionalidade")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(100);

            builder.Property(x => x.ResumoBibliografico)
                .IsRequired(false)
                .HasColumnName("ResumoBibliografico")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(1200);

            builder.Property(x => x.Foto)
                .IsRequired(false)
                .HasColumnName("Foto")
                .HasColumnType("NVARCHAR")
                .HasMaxLength(500);

            builder.HasMany(x => x.Livros)
            .WithMany(x => x.Autores)
            .UsingEntity<Dictionary<string, object>>(
                "AutorLivro",
                livro => livro.HasOne<Livro>()
                    .WithMany()
                    .HasForeignKey("LivroId")
                    .HasConstraintName("FK_LivroAutor_LivroId")
                    .OnDelete(DeleteBehavior.Restrict),
                autor => autor.HasOne<Autor>()
                    .WithMany()
                    .HasForeignKey("AutorId")
                    .HasConstraintName("FK_LivroAutor_AutorId")
                    .OnDelete(DeleteBehavior.Restrict));

        }
    }
}
