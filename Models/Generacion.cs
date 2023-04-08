using System.ComponentModel.DataAnnotations;
using CarSun.Data.Mappings;

namespace CarSun.Models;

public class Generacion
{
    #region Constructor
    public Generacion()
    {
        Nombre = string.Empty;
        Modelos = new HashSet<Modelo>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public int Iteracion { get; set; }
    public string Nombre { get; set; }
    [Display(Name = "Fecha inicio")]
    public DateTime FechaInicio { get; set; }
    [Display(Name = "Fecha fin")]
    public DateTime? FechaFin { get; set; }
    #endregion

    #region Relaciones a 1
    public Serie Serie{ get; set; }
    public int SerieId { get; set; }
    #endregion

    #region Colecciones
    public ICollection<Modelo> Modelos { get; set; }
    #endregion
}
