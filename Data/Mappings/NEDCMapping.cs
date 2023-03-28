using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class NEDCMapping : IEntityTypeConfiguration<NEDC>
{
    public void Configure(EntityTypeBuilder<NEDC> builder)
    {
        builder.ToTable("NEDCs");
        builder.HasKey(w => w.ModeloMotorId);
        builder.Property(w => w.ModeloMotorId).HasColumnName("Modelo_Motor_Id").IsRequired();

        builder.Property(w => w.CicloUrbano).HasPrecision(3, 1).HasColumnName("Ciclo_Urbano").IsRequired();
        builder.Property(w => w.CicloExtraurbano).HasPrecision(3, 1).HasColumnName("Ciclo_Extraurbano").IsRequired();
        builder.Property(w => w.CicloCombinado).HasPrecision(3, 1).HasColumnName("Ciclo_Combinado").IsRequired();
        builder.Property(w => w.Emisiones).HasColumnName("Emisiones").IsRequired();

    }
}
