namespace CarSun.Models;

public class Acabado
{
    #region Constructor
    public Acabado()
    {
        Nombre = string.Empty;
        Vehiculos = new HashSet<Vehiculo>();
        AcabadoEquipamientos = new HashSet<AcabadoEquipamiento>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    #endregion

    #region Relaciones a 1
    public int ModeloId { get; set; }
    public Modelo Modelo { get; set; }
    #endregion

    #region Colecciones
    public ICollection<Vehiculo> Vehiculos { get; set; }
    public ICollection<AcabadoEquipamiento> AcabadoEquipamientos { get; set; }
    #endregion
}
