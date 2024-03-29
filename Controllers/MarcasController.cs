﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarSun.Data;
using CarSun.Models;
using Microsoft.AspNetCore.Authorization;
using CarSun.Models.Helper;

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
    public IActionResult Index(int pagina = 1, int registrosPorPagina = 10, string marcaBusqueda = "")
    {
        ViewData["marcaBusqueda"] = marcaBusqueda != string.Empty ? marcaBusqueda : ViewData["marcaBusqueda"] ?? string.Empty;
        var marcasPaginadas = new Paginador<Marca>(_context.Marcas.Where(m => m.Nombre.Contains(marcaBusqueda)).OrderBy(m => m.Nombre), pagina, registrosPorPagina);
        return View(marcasPaginadas);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost][ValidateAntiForgeryToken][Authorize(Policy = "Edit")]
    public async Task<IActionResult> Create(Marca marca)
    {
        if (ModelState.IsValid)
        {
            _context.Add(marca);
            await _context.SaveChangesAsync(true, default, marca.UserNameAudit);
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

        var marca = _context.Marcas.Include(m => m.Series).FirstOrDefault(m => m.Id == id);
        if (marca is null)
        {
            return NotFound();
        }
        return View(marca);
    }

    [HttpPost][ValidateAntiForgeryToken][Authorize(Policy = "Edit")]
    public async Task<IActionResult> Edit(Marca marca)
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(marca);
                await _context.SaveChangesAsync(true, default, marca.UserNameAudit);
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
    public async Task<IActionResult> Delete(int id, string? userNameAudit)
    {
        var marca = _context.Marcas.Find(id);
        if (marca is not null)
        {
            _context.Marcas.Remove(marca);
            await _context.SaveChangesAsync(true, default, userNameAudit);
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
