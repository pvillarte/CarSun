namespace CarSun.Models;

public class EquipamientoVehiculo
{
    #region Constructor
    #endregion

    #region Propiedades
    #endregion

    #region Relaciones a 1
    public int EquipamientoId { get; set; }
    public Equipamiento Equipamiento { get; set; }
    public int VehiculoId { get; set; }
    public Vehiculo Vehiculo { get; set; }

    #endregion

    #region Colecciones
    #endregion
}
