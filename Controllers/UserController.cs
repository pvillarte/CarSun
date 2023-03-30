using CarSun.Data;
using CarSun.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Mail;

namespace CarSun.Controllers;

[Authorize(Policy = "Admin")]
public class UserController : Controller
{
    #region Setup contexto
    private readonly ApplicationDbContext _context;
    private readonly UserManager<IdentityUser> _userManager;
    public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }
    #endregion

    #region CRUD
    public IActionResult Index()
    {
        return View(_context.Users.ToList());
    }

    public IActionResult Edit(string id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            return NotFound();
        }

        var selected = _context.UserRoles.FirstOrDefault(x => x.UserId == id)?.RoleId ?? "-1";
        var roles = new SelectList(_context.Roles, "Id", "Name", selected).ToList();
        roles.Insert(0, new SelectListItem { Text = "Ninguno", Value = "-1" });
        ViewBag.Roles = roles;
        return View(user);
    }

    [HttpPost][ValidateAntiForgeryToken]
    public IActionResult Edit(IdentityUser user, string? rolId )
    {
        if (ModelState.IsValid)
        {
            try
            {
                _context.UserRoles.RemoveRange(_context.UserRoles.Where(r => r.UserId == user.Id));
                if (!string.IsNullOrEmpty(rolId) && !rolId.Equals("-1"))
                {
                    _context.UserRoles.Add(new IdentityUserRole<string>(){ RoleId=rolId, UserId= user.Id});
                }
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(user.Id))
                {
                    return NotFound();
                }
                throw;
            }
            return RedirectToAction(nameof(Index));
        }
        return View(user);
    }

    public IActionResult Delete(string? id)
    {
        if (string.IsNullOrEmpty(id))
        {
            return NotFound();
        }

        var user = _context.Users.FirstOrDefault(x => x.Id == id);
        if (user is null)
        {
            return NotFound();
        }

        return View(user);
    }

    [HttpPost][ValidateAntiForgeryToken]
    public IActionResult Delete(IdentityUser user)
    {
        try
        {
            var userToDelete = _context.Users.FirstOrDefault(u => u.Id == user.Id);
            if (userToDelete is not null)
            {
                _context.Users.Remove(userToDelete);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
    #endregion

    #region Métodos privados
    private bool UserExists(string id)
    {
        return _context.Users.Any(marca => marca.Id == id);
    }

    #endregion

}
