using Microsoft.EntityFrameworkCore;

namespace CarSun.Models.Helper;

public class Paginador<T> where T : class
{
    #region Constructor
    public Paginador(DbSet<T> items, int paginaActual=1, int registrosPorPagina = 8)
    {
        RegistrosPorPagina = registrosPorPagina;
        PaginaActual = paginaActual;
        TotalRegistros = items.Count();
        Resultado = items.Skip((paginaActual - 1) * registrosPorPagina).Take(registrosPorPagina).ToList();
        TotalPaginas = (int)Math.Ceiling((double)TotalRegistros / registrosPorPagina);
    }
    #endregion

    #region Properties
    public int PaginaActual { get; set; }
    public int RegistrosPorPagina { get; set; }
    public int TotalRegistros { get; set; }
    public int TotalPaginas { get; set; }
    public ICollection<T> Resultado { get; set; }
    #endregion
}

