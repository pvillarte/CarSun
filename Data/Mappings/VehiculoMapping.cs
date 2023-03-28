using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class VehiculoMapping : IEntityTypeConfiguration<Vehiculo>
{
    public void Configure(EntityTypeBuilder<Vehiculo> builder)
    {
        builder.ToTable("Vehiculos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Etiqueta).HasColumnName("Etiqueta").IsRequired();
        builder.Property(x => x.Color).HasColumnName("Color").IsRequired();
        builder.Property(x => x.Kms).HasColumnName("Kms").IsRequired();
        builder.Property(x => x.Traccion).HasColumnName("Traccion").IsRequired();
        builder.Property(x => x.Fecha).HasColumnName("Fecha").IsRequired();
        builder.Property(x => x.Cambio).HasColumnName("Cambio").IsRequired();
        builder.Property(x => x.Relaciones).HasColumnName("Relaciones");
        builder.Property(x => x.MotorId).HasColumnName("Motor_Id").IsRequired();
        builder.Property(x => x.ModeloId).HasColumnName("Modelo_Id").IsRequired();
        builder.Property(x => x.AcabadoId).HasColumnName("Acabado_Id");


        builder.HasOne(x => x.Motor).WithMany(c => c.Vehiculos).HasForeignKey(x => x.MotorId).IsRequired();
        builder.HasOne(x => x.Modelo).WithMany(c => c.Vehiculos).HasForeignKey(x => x.ModeloId).IsRequired();
        builder.HasOne(x => x.Acabado).WithMany(c => c.Vehiculos).HasForeignKey(x => x.AcabadoId);
    }
}
