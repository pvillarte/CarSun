using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using CarSun.Models;

namespace CarSun.Data.Mappings;

public class AcabadoMapping : IEntityTypeConfiguration<Acabado>
{
    public void Configure(EntityTypeBuilder<Acabado> builder)
    {
        builder.ToTable("Acabados");
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Nombre).HasColumnName("Nombre").IsRequired();
        builder.Property(x => x.ModeloId).HasColumnName("Modelo_Id").IsRequired();

        builder.HasOne(x => x.Modelo).WithMany(c => c.Acabados).HasForeignKey(x => x.ModeloId).IsRequired();
    }
}
