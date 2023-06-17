using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSun.Data;
using CarSun.Models;
using Microsoft.AspNetCore.Authorization;
using CarSun.Models.Helper;

namespace CarSun.Controllers;

[Authorize]
public class SeriesController : Controller
{
    #region Setup contexto
    private readonly ApplicationDbContext _context;
    public SeriesController(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region CRUD
    public IActionResult Index(int pagina = 1, int registrosPorPagina=10)
    {
        var seriesPaginadas = new Paginador<Serie>(_context.Series.Include(s => s.Marca).Include(s => s.Generaciones), pagina, registrosPorPagina);
        return View(seriesPaginadas);
    }

    public IActionResult Create(int? marcaId)
    {
        var serie = new Serie();
        if (marcaId.HasValue)
        {
            serie.MarcaId = marcaId.Value;
        }
        ViewBag.Marcas = Selector<Marca>.GetSelectList(_context.Marcas.OrderBy(m => m.Nombre).ToList(), "Id", "Nombre");
        return View(serie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Edit")]
    public async Task<IActionResult> Create(Serie serie)
    {
        try
        {
            _context.Add(serie);
            await _context.SaveChangesAsync(true);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(serie);
        }
    }

    public IActionResult Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var serie = _context.Series.Include(s => s.Generaciones).FirstOrDefault(x => x.Id == id);
        if (serie is null)
        {
            return NotFound();
        }
        ViewBag.Marcas = Selector<Marca>.GetSelectList(_context.Marcas.OrderBy(m => m.Nombre).ToList(), "Id", "Nombre", serie.MarcaId);
        return View(serie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Edit")]
    public async Task<IActionResult> Edit(Serie serie)
    {
        try
        {
            _context.Update(serie);
            await _context.SaveChangesAsync(true);
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!SerieExists(serie.Id))
            {
                return NotFound();
            }
            return View(serie);
        }
        return RedirectToAction(nameof(Index)); 
    }

    public IActionResult Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var serie = _context.Series.Include(s => s.Generaciones).Include(s => s.Marca).FirstOrDefault(s => s.Id == id);
        if (serie is null)
        {
            return NotFound();
        }
        ViewBag.NumGeneraciones = serie.Generaciones.Count;
        return View(serie);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Policy = "Edit")]
    public async Task<IActionResult> Delete(int id)
    {
        var serie = _context.Series.Find(id);
        if (serie is not null)
        {
            _context.Series.Remove(serie);
            await _context.SaveChangesAsync(true);
        }
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Métodos privados
    private bool SerieExists(int id)
    {
        return _context.Series.Any(serie => serie.Id == id);
    }

    #endregion
}
