using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class AcabadoEquipamientoMapping : IEntityTypeConfiguration<AcabadoEquipamiento>
{
    public void Configure(EntityTypeBuilder<AcabadoEquipamiento> builder)
    {
        builder.ToTable("Acabados_Equipamientos");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Opcional).HasColumnName("Opcional").IsRequired();
        builder.Property(x => x.EquipamientoId).HasColumnName("Equipamiento_Id").IsRequired();
        builder.Property(x => x.AcabadoId).HasColumnName("Acabado_Id").IsRequired();

        builder.HasOne(x => x.Equipamiento).WithMany(c => c.EquipamientoAcabados).HasForeignKey(x => x.EquipamientoId);
        builder.HasOne(x => x.Acabado).WithMany(c => c.AcabadoEquipamientos).HasForeignKey(x => x.AcabadoId);
    }
}
