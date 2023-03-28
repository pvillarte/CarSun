using CarSun.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarSun.Data.Mappings;

public class EquipamientoVehiculoMapping : IEntityTypeConfiguration<EquipamientoVehiculo>
{
    public void Configure(EntityTypeBuilder<EquipamientoVehiculo> builder)
    {
        builder.ToTable("Equipamientos_Vehiculos");
        builder.HasKey(e => new { e.EquipamientoId, e.VehiculoId });

        builder.Property(x => x.VehiculoId).HasColumnName("Vehiculo_Id").IsRequired();
        builder.Property(x => x.EquipamientoId).HasColumnName("Equipamiento_Id").IsRequired();

        builder.HasOne(x => x.Equipamiento).WithMany(c => c.EquipamientoVehiculos).HasForeignKey(x => x.EquipamientoId).IsRequired();
        builder.HasOne(x => x.Vehiculo).WithMany(c => c.VehiculoEquipamientos).HasForeignKey(x => x.VehiculoId).IsRequired();
    }
}
