using CarSun.Data.Mappings;
using CarSun.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarSun.Data;
public class ApplicationDbContext : IdentityDbContext
{
    #region Constructor
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
    #endregion

    #region DbSets
    public DbSet<Marca> Marcas { get; set; }
    public DbSet<Serie> Series { get; set; }
    public DbSet<Generacion> Generaciones { get; set; }
    public DbSet<Motor> Motores { get; set; }
    public DbSet<WLTP> ModelosMotores { get; set; }
    public DbSet<Acabado> Acabados { get; set; }
    public DbSet<AcabadoEquipamiento> AcabadosEquipamientos { get; set; }
    public DbSet<Equipamiento> Equipamientos { get; set; }
    public DbSet<EquipamientoVehiculo> EquipamientosVehiculos { get; set; }
    public DbSet<Modelo> Modelos { get; set; }
    public DbSet<NEDC> NEDCs { get; set; }
    public DbSet<WLTP> WLTPs { get; set; }
    public DbSet<Vehiculo> Vehiculos { get; set; }
    #endregion

    #region Configurations
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new MarcaMapping());
        modelBuilder.ApplyConfiguration(new SerieMapping());
        modelBuilder.ApplyConfiguration(new GeneracionMapping());
        modelBuilder.ApplyConfiguration(new MotorMapping());
        modelBuilder.ApplyConfiguration(new ModeloMotorMapping());
        modelBuilder.ApplyConfiguration(new AcabadoMapping());
        modelBuilder.ApplyConfiguration(new VehiculoMapping());
        modelBuilder.ApplyConfiguration(new AcabadoEquipamientoMapping());
        modelBuilder.ApplyConfiguration(new EquipamientoMapping());
        modelBuilder.ApplyConfiguration(new EquipamientoVehiculoMapping());
        modelBuilder.ApplyConfiguration(new ModeloMapping());
        modelBuilder.ApplyConfiguration(new NEDCMapping());
        modelBuilder.ApplyConfiguration(new WLTPMapping());
    }
    #endregion
}
