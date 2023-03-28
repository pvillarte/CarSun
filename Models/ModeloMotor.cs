using CarSun.Models.Enums;

namespace CarSun.Models;

public class ModeloMotor
{
    #region Constructor
    public ModeloMotor()
    {
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }
    public int Potencia { get; set; }
    public int Par { get; set; }
    public int RPMPotencia { get; set; }
    public int RPMPar { get; set; }
    public int Aceleracion { get; set; }
    public int VelocidadMaxima { get; set; }
    public int Deposito { get; set; }
    #endregion

    #region Relaciones a 1
    public Motor Motor { get; set; }
    public int MotorId { get; set; }
    public Modelo Modelo { get; set; }
    public int ModeloId { get; set; }
    public WLTP? WLTP { get; set; }
    public NEDC? NEDC { get; set; }
    #endregion

    #region Colecciones
    #endregion
}
