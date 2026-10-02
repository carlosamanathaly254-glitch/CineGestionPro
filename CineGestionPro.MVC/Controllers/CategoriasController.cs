
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class CategoriasController : Controller
{

    // GET: CATEGORIAS
    public ActionResult Index()
    {
        var categorias = CRUD<Categoria>.GetAll();
        return View(categorias);
    }

    // GET: CATEGORIAS/Details/5
    public ActionResult Details(int id)
    {
        var categoria = CRUD<Categoria>.GetById(id);
        if (id == null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    // GET: CATEGORIAS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: CATEGORIAS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Categoria categoria)
    {
        try
        {
            CRUD<Categoria>.Create(categoria);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(categoria);
        }
    }

    // GET: CATEGORIAS/Edit/5
    public ActionResult Edit(int id)
    {
        var categoria = CRUD<Categoria>.GetById(id);
        if (categoria == null)
        {
            return NotFound();
        }
        return View(categoria);
    }

    // POST: CATEGORIAS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Categoria categoria)
    {
        try
        {
            CRUD<Categoria>.Update(id, categoria);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(categoria);
        }
    }

    // GET: CATEGORIAS/Delete/5
    public ActionResult Delete(int id)
    {
        var categoria = CRUD<Categoria>.GetById(id);
        if (categoria == null)
        {
            return NotFound();
        }

        return View(categoria);
    }

    // POST: CATEGORIAS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, Categoria categoria)
    {
        try
        {
            CRUD<Categoria>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(categoria);
        }
    }
}
