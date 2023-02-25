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

        }
    }
}
