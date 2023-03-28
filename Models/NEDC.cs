namespace CarSun.Models;

public class NEDC
{
    #region Constructor
    public NEDC()
    {
    }
    #endregion

    #region Propiedades
    public decimal CicloUrbano { get; set; }
    public decimal CicloExtraurbano { get; set; }
    public decimal CicloCombinado { get; set; }
    public int Emisiones { get; set; }

    #endregion

    #region Relaciones a 1
    public ModeloMotor ModeloMotor { get; set; }
    public int ModeloMotorId { get; set; }
    #endregion

    #region Colecciones
    #endregion
}
