
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class EjemplaresController : Controller
{

    // GET: EJEMPLARS
    public ActionResult Index()
    {
        var ejemplares = CRUD<Ejemplar>.GetAll();
        return View(ejemplares);
    }

    // GET: EJEMPLARS/Details/5
    public ActionResult Details(int id_ejemplar)
    {
        var ejemplar = CRUD<Ejemplar>.GetById(id_ejemplar);
        if (id_ejemplar == null)
        {
            return NotFound();
        }
        return View(ejemplar);
    }

    // GET: EJEMPLARS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: EJEMPLARS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Ejemplar ejemplar)
    {
        try
        {
            CRUD<Ejemplar>.Create(ejemplar);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(ejemplar);
        }
    }

    // GET: EJEMPLARS/Edit/5
    public ActionResult Edit(int id_ejemplar)
    {
        var ejemplar = CRUD<Ejemplar>.GetById(id_ejemplar);
        if (ejemplar == null)
        {
            return NotFound();
        }
        return View(ejemplar);
    }

    // POST: EJEMPLARS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_ejemplar, Ejemplar ejemplar)
    {
        try
        {
            CRUD<Ejemplar>.Update(id_ejemplar, ejemplar);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(ejemplar);
        }
    }

    // GET: EJEMPLARS/Delete/5
    public ActionResult Delete(int id_ejemplar)
    {
        var ejemplar = CRUD<Ejemplar>.GetById(id_ejemplar);
        if (ejemplar == null)
        {
            return NotFound();
        }

        return View(ejemplar);
    }

    // POST: EJEMPLARS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id_ejemplar, Ejemplar ejemplar)
    {
        try
        {
            CRUD<Ejemplar>.Delete(id_ejemplar);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(ejemplar);
        }
    }
}
