
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ContenidosController : Controller
{


    // GET: CONTENIDOS
    public ActionResult Index()
    {
        var contenidos = CRUD<Contenido>.GetAll();
        return View(contenidos);
    }

    // GET: CONTENIDOS/Details/5
    public ActionResult Details(int id_contenido)
    {
        var contenido = CRUD<Contenido>.GetById(id_contenido);
        if (id_contenido == null)
        {
            return NotFound();
        }
        return View(contenido);
    }

    // GET: CONTENIDOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CONTENIDOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Contenido contenido)
    {
        try
        {
            CRUD<Contenido>.Create(contenido);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(contenido);
        }
    }

    // GET: CONTENIDOS/Edit/5
    public ActionResult Edit(int id_contenido)
    {
        var contenido = CRUD<Contenido>.GetById(id_contenido);
        if (contenido == null)
        {
            return NotFound();
        }
        return View(contenido);
    }

    // POST: CONTENIDOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_contenido, Contenido contenido)
    {
        try
        {
            CRUD<Contenido>.Update(id_contenido, contenido);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(contenido);
        }
    }

    // GET: CONTENIDOS/Delete/5
    public ActionResult Delete(int id_contenido)
    {
        var contenido = CRUD<Contenido>.GetById(id_contenido);
        if (contenido == null)
        {
            return NotFound();
        }

        return View(contenido);
    }

    // POST: CONTENIDOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id_contenido, Contenido contenido)
    {
        try
        {
            CRUD<Contenido>.Delete(id_contenido);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(contenido);
        }
    }
}
