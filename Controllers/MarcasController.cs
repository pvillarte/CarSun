using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSun.Data;
using CarSun.Models;
using Microsoft.AspNetCore.Authorization;

namespace CarSun.Controllers;

[Authorize]
public class MarcasController : Controller
{
    #region Setup contexto
    private readonly ApplicationDbContext _context;
    public MarcasController(ApplicationDbContext context)
    {
        _context = context;
    }
    #endregion

    #region CRUD
    public IActionResult Index()
    {
        return View(_context.Marcas.ToList());
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost][ValidateAntiForgeryToken][Authorize(Policy = "Edit")]
    public IActionResult Create(Marca marca)
    {
        if (ModelState.IsValid)
        {
            _context.Add(marca);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(marca);
    }

    public IActionResult Edit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var marca = _context.Marcas.Find(id);
        if (marca is null)
        {
            return NotFound();
        }
        return View(marca);
    }

    [HttpPost][ValidateAntiForgeryToken][Authorize(Policy = "Edit")]
    public IActionResult Edit(Marca marca)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(marca);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MarcaExists(marca.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(marca);
    }

    public IActionResult Delete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var marca = _context.Marcas.Find(id);
        if (marca is null)
        {
            return NotFound();
        }

        return View(marca);
    }

    [HttpPost][ValidateAntiForgeryToken][Authorize(Policy = "Edit")]
    public IActionResult Delete(int id)
    {
        var marca = _context.Marcas.Find(id);
        if (marca is not null)
        {
            _context.Marcas.Remove(marca);
            _context.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }

    #endregion

    #region Métodos privados
    private bool MarcaExists(int id)
    {
        return _context.Marcas.Any(marca => marca.Id == id);
    }

    #endregion
}
