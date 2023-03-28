using System.Drawing;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using CarSun.Models.Enums;

namespace CarSun.Models;

public class Vehiculo
{
    #region Constructor
    public Vehiculo()
    {
        VehiculoEquipamientos = new HashSet<EquipamientoVehiculo>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public TipoEtiqueta Etiqueta { get; set; }
    public TipoColor Color { get; set; }
    public int Kms { get; set; }
    public TipoTraccion Traccion { get; set; }
    public DateTime Fecha { get; set; }
    public TipoCambio Cambio { get; set; }
    public int? Relaciones { get; set; }
    #endregion

    #region Relaciones a 1
    public int MotorId { get; set; }
    public Motor Motor { get; set; }
    public int ModeloId { get; set; }
    public Modelo Modelo { get; set; }
    public int? AcabadoId { get; set; }
    public Acabado? Acabado { get; set; }
    #endregion

    #region Colecciones
    public ICollection<EquipamientoVehiculo> VehiculoEquipamientos { get; set; }
    #endregion
}
