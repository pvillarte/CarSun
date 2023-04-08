using CarSun.Models.Enums;

namespace CarSun.Models;

public class Modelo
{
    #region Constructor
    public Modelo()
    {
        Nombre = string.Empty;
        ModeloMotores = new HashSet<ModeloMotor>();
        Vehiculos = new HashSet<Vehiculo>();
        Acabados = new HashSet<Acabado>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public int Plazas { get; set; }
    public string Nombre { get; set; }
    public TipoCarroceria Carroceria { get; set; }
    public int Maletero { get; set; }
    public int Largo { get; set; }
    public int Ancho { get; set; }
    public int Alto { get; set; }
    #endregion

    #region Relaciones a 1
    public Serie Serie { get; set; }
    public int SerieId { get; set; }
    public Generacion? Generacion { get; set; }
    public int? GeneracionId { get; set; }
    #endregion

    #region Colecciones
    public ICollection<ModeloMotor> ModeloMotores { get; set; }
    public ICollection<Vehiculo> Vehiculos { get; set; }
    public ICollection<Acabado> Acabados { get; set; }
    #endregion
}
