
using Microsoft.AspNetCore.Mvc;
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;

public class AlquileresController : Controller
{
   
    // GET: ALQUILERS
    public ActionResult Index()    
    {
        var alquileres = CRUD<Alquiler>.GetAll();
        return View(alquileres);
    }

    // GET: ALQUILERS/Details/5
    public ActionResult Details(int id)
    {
        var alquiler = CRUD<Alquiler>.GetById(id);
        if(id== null)
        {
            return NotFound();
        }
        return View(alquiler);
    }

    // GET: ALQUILERS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ALQUILERS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Alquiler alquiler)
    {
        try
        {
            CRUD<Alquiler>.Create(alquiler);
            return RedirectToAction(nameof(Index));
        }
        catch(Exception ex)
        {
            ModelState.AddModelError("",ex.Message);
            return View(alquiler);
        }
    }

    // GET: ALQUILERS/Edit/5
    public ActionResult Edit(int id)
    {
        var alquiler = CRUD<Alquiler>.GetById(id);
        if (alquiler == null)
        {
            return NotFound();
        }
        return View(alquiler);
    }

    // POST: ALQUILERS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, Alquiler alquiler)
    {
        try
        {
            CRUD<Alquiler>.Update(id, alquiler);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(alquiler);
        }
    }

    // GET: ALQUILERS/Delete/5
    public ActionResult Delete(int id)
    {
        var alquiler = CRUD<Alquiler>.GetById(id);
        if (alquiler == null)
        {
            return NotFound();
        }

        return View(alquiler);
    }

    // POST: ALQUILERS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, Alquiler alquiler)
    {
        try
        {
            CRUD<Alquiler>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(alquiler);
        }
    }

  
}
