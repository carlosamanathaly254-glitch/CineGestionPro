
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class DetalleAlquileresController : Controller
{

    // GET: DETALLEALQUILERS
    public ActionResult Index()
    {
        var detallealquileres = CRUD<DetalleAlquiler>.GetAll();
        return View(detallealquileres);
    }

    // GET: DETALLEALQUILERS/Details/5
    public ActionResult Details(int id)
    {
        var detallealquiler = CRUD<DetalleAlquiler>.GetById(id);
        if (id == null)
        {
            return NotFound();
        }
        return View(detallealquiler);
    }

    // GET: DETALLEALQUILERS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DETALLEALQUILERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(DetalleAlquiler detallealquiler)
    {
        try
        {
            CRUD<DetalleAlquiler>.Create(detallealquiler);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallealquiler);
        }
    }

    // GET: DETALLEALQUILERS/Edit/5
    public ActionResult Edit(int id)
    {
        var detallealquiler = CRUD<DetalleAlquiler>.GetById(id);
        if (detallealquiler == null)
        {
            return NotFound();
        }
        return View(detallealquiler);
    }

    // POST: DETALLEALQUILERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, DetalleAlquiler detallealquiler)
    {
        try
        {
            CRUD<DetalleAlquiler>.Update(id, detallealquiler);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(detallealquiler);
        }
    }

    // GET: DETALLEALQUILERS/Delete/5
    public ActionResult Delete(int id)
    {
        var detallealquiler = CRUD<DetalleAlquiler>.GetById(id);
        if (detallealquiler == null)
        {
            return NotFound();
        }

        return View(detallealquiler);
    }

    // POST: DETALLEALQUILERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, DetalleAlquiler detallealquiler)
    {
        try
        {
            CRUD<DetalleAlquiler>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(detallealquiler);
        }
    }
}
