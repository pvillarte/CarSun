using CarSun.Data;
using CarSun.Models.Helper;
using CarSun.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
    public IActionResult Index(int marcaId = -1, int serieId = -1)
    {
        ViewBag.MarcaId = Selector<Marca>.GetSelectList(_context.Marcas.ToList(), "Id", "Nombre", marcaId);
        ViewBag.SerieId = Selector<Serie>.GetSelectList(_context.Series.Where(s => s.MarcaId == marcaId).ToList(), "Id", "Nombre", serieId);
        var generaciones = _context.Generaciones.Where(g => g.SerieId == serieId).ToList();
        return View(generaciones);
    }

    public IActionResult Create(int serieId = -1)
    {
        var generacion = new Generacion() { SerieId = serieId };
        ViewBag.Series = Selector<Serie>.GetSelectList(_context.Series.OrderBy(m => m.Nombre).ToList(), "Id", "Nombre", serieId);
        return View(generacion);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Generacion generacion)
    {
        try
        {
            _context.Add(generacion);
            await _context.SaveChangesAsync(true);
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View(generacion);
        }
    }

    public IActionResult Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var generacion = _context.Generaciones.Include(m => m.Modelos).FirstOrDefault(m => m.Id == id);
        if (generacion is null)
        {
            return NotFound();
        }
        ViewBag.Serie = Selector<Serie>.GetSelectList(_context.Series.OrderBy(m => m.Nombre).ToList(), "Id", "Nombre", generacion.SerieId);
        return View(generacion);
    }

    [HttpPost][ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(Generacion generacion)
    {
        try
        {
            _context.Update(generacion);
            await _context.SaveChangesAsync(true);
        }
        catch (DbUpdateConcurrencyException)
        {
            return View(generacion);
        }
        return RedirectToAction(nameof(Index));
    }

    public IActionResult Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var marca = _context.Generaciones.Include(x => x.Serie).FirstOrDefault(x => x.Id == id);
        if (marca is null)
        {
            return NotFound();
        }

        return View(marca);
    }

    [HttpPost][ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var generacion = _context.Generaciones.Find(id);
        if (generacion is not null)
        {
            _context.Generaciones.Remove(generacion);
            await _context.SaveChangesAsync(true);
        }
        return RedirectToAction(nameof(Index));
    }
    #endregion
}
