using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class WLTPMapping : IEntityTypeConfiguration<WLTP>
{
    public void Configure(EntityTypeBuilder<WLTP> builder)
    {
        builder.ToTable("WLTPs");
        builder.HasKey(w => w.ModeloMotorId);
        builder.Property(w => w.ModeloMotorId).HasColumnName("Modelo_Motor_Id").IsRequired();

        builder.Property(w => w.CicloBajo).HasPrecision(3, 1).HasColumnName("Ciclo_Bajo").IsRequired();
        builder.Property(w => w.CicloMedio).HasPrecision(3, 1).HasColumnName("Ciclo_Medio").IsRequired();
        builder.Property(w => w.CicloAlto).HasPrecision(3, 1).HasColumnName("Ciclo_Alto").IsRequired();
        builder.Property(w => w.CicloExtraAlto).HasPrecision(3, 1).HasColumnName("Ciclo_Extra_Alto").IsRequired();
        builder.Property(w => w.CicloCombinado).HasPrecision(3, 1).HasColumnName("Ciclo_Combinado").IsRequired();
        builder.Property(w => w.Emisiones).HasColumnName("Emisiones").IsRequired();

    }
}
