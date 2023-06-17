using CarSun.Data.Mappings;
using CarSun.Models;
using CarSun.Models.Interfaces;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace CarSun.Data;
public class ApplicationDbContext : IdentityDbContext
{
    #region Constructor
    private string _username;
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
        : base(options)
    {
        // Get the claims principal from the HttpContext
        // Get the username claim from the claims principal - if the user is not authenticated the claim will be null
        _username = httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "Unauthenticated user";
    }
    #endregion

    #region DbSets
    public DbSet<AuditEntry> AuditEntries { get; set; }
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

        #region Auditoría
        modelBuilder.Entity<AuditEntry>().Property(ae => ae.Changes).HasConversion(
            value => JsonConvert.SerializeObject(value),
            serializedValue => JsonConvert.DeserializeObject<Dictionary<string, object>>(serializedValue));
        #endregion

    }
    #endregion

    #region Auditoria
    public async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default, string? user = null)
    {
        if (!string.IsNullOrEmpty(user))
        {
            _username = user;
        }
        // Get audit entries
        var auditEntries = OnBeforeSaveChanges();

        // Save current entity
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        // Save audit entries
        await OnAfterSaveChangesAsync(auditEntries);
        return result;
    }


    public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        // Get audit entries
        var auditEntries = OnBeforeSaveChanges();

        // Save current entity
        var result = await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);

        // Save audit entries
        await OnAfterSaveChangesAsync(auditEntries);
        return result;
    }

    private List<AuditEntry> OnBeforeSaveChanges()
    {
        ChangeTracker.DetectChanges();
        var entries = new List<AuditEntry>();

        foreach (var entry in ChangeTracker.Entries())
        {
            // Dot not audit entities that are not tracked, not changed, or not of type IAuditable
            if (entry.State == EntityState.Detached || entry.State == EntityState.Unchanged || !(entry.Entity is IAuditable))
                continue;

            var auditEntry = new AuditEntry
            {
                ActionType = entry.State == EntityState.Added ? "INSERT" : entry.State == EntityState.Deleted ? "DELETE" : "UPDATE",
                EntityId = entry.Properties.Single(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString(),
                EntityName = entry.Metadata.ClrType.Name,
                Username = _username,
                TimeStamp = DateTime.UtcNow,
                Changes = entry.Properties.Select(p => new { p.Metadata.Name, p.CurrentValue }).ToDictionary(i => i.Name, i => i.CurrentValue),

                // TempProperties are properties that are only generated on save, e.g. ID's
                // These properties will be set correctly after the audited entity has been saved
                TempProperties = entry.Properties.Where(p => p.IsTemporary).ToList(),
            };

            entries.Add(auditEntry);
        }

        return entries;
    }

    private Task OnAfterSaveChangesAsync(List<AuditEntry> auditEntries)
    {
        if (auditEntries == null || auditEntries.Count == 0)
            return Task.CompletedTask;

        // For each temporary property in each audit entry - update the value in the audit entry to the actual (generated) value
        foreach (var entry in auditEntries)
        {
            foreach (var prop in entry.TempProperties)
            {
                if (prop.Metadata.IsPrimaryKey())
                {
                    entry.EntityId = prop.CurrentValue.ToString();
                    entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                }
                else
                {
                    entry.Changes[prop.Metadata.Name] = prop.CurrentValue;
                }
            }
        }

        AuditEntries.AddRange(auditEntries);
        return SaveChangesAsync();
    }

    #endregion
}
