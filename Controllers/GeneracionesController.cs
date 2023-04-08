using CarSun.Data;
using CarSun.Models.Helper;
using CarSun.Models;
using Microsoft.AspNetCore.Mvc;

namespace CarSun.Controllers;
public class GeneracionesController : Controller
{
    #region Setup contexto
    private readonly ApplicationDbContext _context;
    public GeneracionesController(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion
    #region CRUD
    public IActionResult Index(int pagina = 1, int registrosPorPagina = 10, int marcaId = -1, int serieId = -1)
    {
        ViewBag.MarcaId = Selector<Marca>.GetSelectList(_context.Marcas.ToList(), "Id", "Nombre", marcaId);
        ViewBag.SerieId = Selector<Serie>.GetSelectList(_context.Series.Where(s => s.MarcaId == marcaId).ToList(), "Id", "Nombre", serieId);
        var generacionesPaginadas = new Paginador<Generacion>(_context.Generaciones.Where(g => g.SerieId == serieId), pagina, registrosPorPagina);
        return View(generacionesPaginadas);
    }

    public IActionResult Create(int serieId = -1)
    {
        var generacion = new Generacion() { SerieId = serieId };
        ViewBag.Series = Selector<Serie>.GetSelectList(_context.Series.OrderBy(m => m.Nombre).ToList(), "Id", "Nombre", serieId);
        return View(generacion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Generacion generacion)
    {
        try
        {
            _context.Add(generacion);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(generacion);
        }
    }

    public IActionResult Edit(int id)
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    public ActionResult Delete(int id)
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    #endregion
}
