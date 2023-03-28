using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class GeneracionMapping : IEntityTypeConfiguration<Generacion>
{
    public void Configure(EntityTypeBuilder<Generacion> builder)
    {
        builder.ToTable("Generaciones");
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Nombre).HasColumnName("Nombre").IsRequired();
        builder.Property(g => g.FechaInicio).HasColumnName("Fecha_Inicio").IsRequired();
        builder.Property(g => g.FechaFin).HasColumnName("Fecha_Fin");
        builder.Property(g => g.Iteracion).HasColumnName("Iteracion").IsRequired();
        builder.Property(g => g.SerieId).HasColumnName("Serie_Id").IsRequired();

        builder.HasOne(g => g.Serie).WithMany(s => s.Generaciones).HasForeignKey(g => g.SerieId).IsRequired();
    }
}
