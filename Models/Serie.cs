using CarSun.Models;

namespace CarSun.Data.Mappings;

public class Serie
{
    #region Constructor
    public Serie()
    {
        Nombre = string.Empty;
        Generaciones = new HashSet<Generacion>();
        Modelos = new HashSet<Modelo>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public string Nombre { get; set; }
    #endregion

    #region Relaciones a 1
    public Marca Marca { get; set; }
    public int MarcaId { get; set; }
    #endregion

    #region Colecciones
    public ICollection<Generacion> Generaciones { get; set; }
    public ICollection<Modelo> Modelos { get; set; }
    #endregion
}
