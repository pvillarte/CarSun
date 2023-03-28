using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace CarSun.Data.Mappings;

public class SerieMapping : IEntityTypeConfiguration<Serie>
{
    public void Configure(EntityTypeBuilder<Serie> builder)
    {
        builder.ToTable("Series");
        builder.HasKey(s => s.Id);

        builder.Property(s => s.Nombre).HasMaxLength(30).HasColumnName("Nombre").IsRequired();
        builder.Property(s => s.MarcaId).HasMaxLength(30).HasColumnName("Marca_Id").IsRequired();

        builder.HasOne(s => s.Marca).WithMany(m => m.Series).HasForeignKey(s => s.MarcaId).IsRequired();
    }
}