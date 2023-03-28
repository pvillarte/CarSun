namespace CarSun.Models;

public class WLTP
{
    #region Constructor
    public WLTP()
    {
    }
    #endregion

    #region Propiedades
    public decimal CicloBajo { get; set; }
    public decimal CicloMedio { get; set; }
    public decimal CicloAlto { get; set; }
    public decimal CicloExtraAlto { get; set; }
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
