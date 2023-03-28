using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class ModeloMotorMapping : IEntityTypeConfiguration<ModeloMotor>
{
    public void Configure(EntityTypeBuilder<ModeloMotor> builder)
    {
        builder.ToTable("Modelos_Motores");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Potencia).HasColumnName("Potencia").IsRequired();
        builder.Property(x => x.Par).HasColumnName("Par").IsRequired();
        builder.Property(x => x.RPMPotencia).HasColumnName("RPM_Potencia").IsRequired();
        builder.Property(x => x.RPMPar).HasColumnName("RPM_Par").IsRequired();
        builder.Property(x => x.Aceleracion).HasColumnName("Aceleracion").IsRequired();
        builder.Property(x => x.VelocidadMaxima).HasColumnName("Velocidad_Maxima").IsRequired();
        builder.Property(x => x.Deposito).HasColumnName("Deposito").IsRequired();
        builder.Property(x => x.ModeloId).HasColumnName("Modelo_Id").IsRequired();
        builder.Property(x => x.MotorId).HasColumnName("Motor_Id").IsRequired();


        builder.HasOne(g => g.Modelo).WithMany(s => s.ModeloMotores).HasForeignKey(g => g.ModeloId).IsRequired();
        builder.HasOne(g => g.Motor).WithMany(s => s.MotorModelos).HasForeignKey(g => g.MotorId).IsRequired();

        builder.HasOne(w => w.WLTP).WithOne(m => m.ModeloMotor).HasForeignKey<WLTP>(b => b.ModeloMotorId).IsRequired();
        builder.HasOne(w => w.NEDC).WithOne(m => m.ModeloMotor).HasForeignKey<NEDC>(b => b.ModeloMotorId).IsRequired();
    }
}
