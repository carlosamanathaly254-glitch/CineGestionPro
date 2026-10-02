
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class RolesController : Controller
{

    // GET: ROLS
    public ActionResult Index()
    {
        var roles = CRUD<Rol>.GetAll();
        return View(roles);
    }

    // GET: ROLS/Details/5
    public ActionResult Details(int id)
    {
        var rol = CRUD<Rol>.GetById(id);
        if (id == null)
        {
            return NotFound();
        }
        return View(rol);
    }

    // GET: ROLS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ROLS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Rol roles)
    {
        try
        {
            CRUD<Rol>.Create(roles);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(roles);
        }
    }

    // GET: ROLS/Edit/5
    public ActionResult Edit(int id)
    {
        var rol = CRUD<Rol>.GetById(id);
        if (rol == null)
        {
            return NotFound();
        }
        return View(rol);
    }

    // POST: ROLS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Rol rol)
    {
        try
        {
            CRUD<Rol>.Update(id, rol);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(rol);
        }
    }

    // GET: ROLS/Delete/5
    public ActionResult Delete(int id)
    {
        var rol = CRUD<Rol>.GetById(id);
        if (rol == null)
        {
            return NotFound();
        }

        return View(rol);
    }

    // POST: ROLS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, Rol rol)
    {
        try
        {
            CRUD<Rol>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(rol);
        }
    }
}
