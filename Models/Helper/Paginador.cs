using Microsoft.EntityFrameworkCore;

namespace CarSun.Models.Helper;

public class Paginador<T> where T : class
{
    #region Constructores
    public Paginador(DbSet<T> items, int paginaActual = 1, int registrosPorPagina = 10)
    {
        RegistrosPorPagina = registrosPorPagina;
        TotalRegistros = items.Count();
        TotalPaginas = (int)Math.Ceiling((double)TotalRegistros / registrosPorPagina);
        PaginaActual = (TotalPaginas < paginaActual) ? TotalPaginas : paginaActual;
        Resultado = items.Skip((((PaginaActual - 1) < 0) ? 0 : (PaginaActual - 1)) * registrosPorPagina).Take(registrosPorPagina).ToList();
    }

    public Paginador(IQueryable<T> items, int paginaActual = 1, int registrosPorPagina = 10)
    {
        RegistrosPorPagina = registrosPorPagina;
        TotalRegistros = items.Count();
        TotalPaginas = (int)Math.Ceiling((double)TotalRegistros / registrosPorPagina);
        PaginaActual = (TotalPaginas < paginaActual)? TotalPaginas : paginaActual;
        Resultado = items.Skip((((PaginaActual - 1)<0)? 0 : (PaginaActual - 1)) * registrosPorPagina).Take(registrosPorPagina).ToList();
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

