using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class MarcaMapping : IEntityTypeConfiguration<Marca>
{
    public void Configure(EntityTypeBuilder<Marca> builder) 
    {
        builder.ToTable("Marcas");
        builder.HasKey(x => x.Id);

        builder.Property(a => a.Pais).HasMaxLength(30).HasColumnName("Pais").IsRequired();
        builder.Property(a => a.Nombre).HasMaxLength(30).HasColumnName("Nombre").IsRequired();
    }
}
