using CarSun.Models.Enums;
using CarSun.Data.Mappings;

namespace CarSun.Models;

public class AcabadoEquipamiento
{
    #region Constructor
    public AcabadoEquipamiento()
    {
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public bool Opcional { get; set; }
    #endregion

    #region Relaciones a 1
    public int AcabadoId { get; set; }
    public Acabado Acabado { get; set; }
    public int EquipamientoId { get; set; }
    public Equipamiento Equipamiento { get; set; }

    #endregion

    #region Colecciones
    #endregion
}
