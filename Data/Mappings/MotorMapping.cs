using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class MotorMapping : IEntityTypeConfiguration<Motor>
{
    public void Configure(EntityTypeBuilder<Motor> builder)
    {
        builder.ToTable("Motores");
        builder.HasKey(m => m.Id);

        builder.Property(m => m.Cubicaje).HasColumnName("Cubicaje");
        builder.Property(m => m.Especificacion).HasMaxLength(30).HasColumnName("Especificacion").IsRequired();
        builder.Property(m => m.Cilindros).HasColumnName("Cilindros");
        builder.Property(m => m.Valvulas).HasColumnName("Valvulas");
        builder.Property(m => m.TipoMotor).HasColumnName("Tipo_Motor").IsRequired();
        builder.Property(m => m.Hibridacion).HasColumnName("Hibridacion").IsRequired();
        builder.Property(m => m.Configuracion).HasColumnName("Configuracion");
        builder.Property(m => m.Alimentacion).HasColumnName("Alimentacion").IsRequired();
        builder.Property(m => m.Sobrealimentacion).HasColumnName("Sobrealimentacion");
    }
}
