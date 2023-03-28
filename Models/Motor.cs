using CarSun.Models.Enums;
using CarSun.Data.Mappings;

namespace CarSun.Models;

public class Motor
{
    #region Constructor
    public Motor()
    {
        Especificacion = string.Empty;
        MotorModelos = new HashSet<ModeloMotor>();
        Vehiculos = new HashSet<Vehiculo>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public int? Cubicaje { get; set; }
    public string Especificacion { get; set; }  
    public int? Cilindros { get; set; }
    public int? Valvulas { get; set; }
    public TipoMotor TipoMotor { get; set; }
    public TipoHibridacion Hibridacion { get; set; }
    public TipoConfiguracion? Configuracion { get; set; }
    public TipoAlimentacion Alimentacion { get; set; }  
    public TipoSobrealimentacion? Sobrealimentacion { get; set; }
    #endregion

    #region Relaciones a 1
    #endregion

    #region Colecciones
    public ICollection<ModeloMotor> MotorModelos { get; set; }
    public ICollection<Vehiculo> Vehiculos { get; set; }
    #endregion
}
