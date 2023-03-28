using CarSun.Models.Enums;
using CarSun.Data.Mappings;

namespace CarSun.Models;

public class Equipamiento
{
    #region Constructor
    public Equipamiento()
    {
        Nombre = string.Empty;
        EquipamientoVehiculos = new HashSet<EquipamientoVehiculo>();
        EquipamientoAcabados = new HashSet<AcabadoEquipamiento>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    #endregion

    #region Relaciones a 1
    #endregion

    #region Colecciones
    public ICollection<EquipamientoVehiculo> EquipamientoVehiculos { get; set; }
    public ICollection<AcabadoEquipamiento> EquipamientoAcabados { get; set; }
    #endregion
}
