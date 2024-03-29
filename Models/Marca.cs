﻿using System.ComponentModel.DataAnnotations;
using CarSun.Models.Helper;
using CarSun.Models.Interfaces;

namespace CarSun.Models;

public class Marca : Auditable, IAuditable
{
    #region Constructor
    public Marca()
    {
        Nombre = string.Empty;
        Pais = string.Empty;
        Series = new HashSet<Serie>();
    }
    #endregion

    #region Propiedades
    public int Id { get; set; }

    [Display(Name = "Marca")]
    public string Nombre { get; set; }
    public string Pais { get; set; }
    #endregion

    #region Relaciones a 1
    #endregion

    #region Colecciones
    public ICollection<Serie> Series { get; set; }
    #endregion
}
