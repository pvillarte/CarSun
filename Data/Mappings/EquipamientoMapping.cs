using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class EquipamientoMapping : IEntityTypeConfiguration<Equipamiento>
{
    public void Configure(EntityTypeBuilder<Equipamiento> builder)
    {
        builder.ToTable("Equipamientos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
    }
}
