using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class ModeloMapping : IEntityTypeConfiguration<Modelo>
{
    public void Configure(EntityTypeBuilder<Modelo> builder)
    {
        builder.ToTable("Modelos");
        builder.HasKey(g => g.Id);

        builder.Property(g => g.Nombre).HasMaxLength(40).HasColumnName("Nombre").IsRequired();
        builder.Property(g => g.Carroceria).HasColumnName("Carroceria").IsRequired();
        builder.Property(g => g.Plazas).HasColumnName("Plazas").IsRequired();
        builder.Property(g => g.Maletero).HasColumnName("Maletero").IsRequired();
        builder.Property(g => g.Largo).HasColumnName("Largo").IsRequired();
        builder.Property(g => g.Ancho).HasColumnName("Ancho").IsRequired();
        builder.Property(g => g.Alto).HasColumnName("Alto").IsRequired();
        builder.Property(g => g.SerieId).HasColumnName("Serie_Id").IsRequired();
        builder.Property(g => g.GeneracionId).HasColumnName("Generacion_Id");

        builder.HasOne(g => g.Serie).WithMany(s => s.Modelos).HasForeignKey(g => g.SerieId).IsRequired();
        builder.HasOne(g => g.Generacion).WithMany(s => s.Modelos).HasForeignKey(g => g.GeneracionId);
    }
}
