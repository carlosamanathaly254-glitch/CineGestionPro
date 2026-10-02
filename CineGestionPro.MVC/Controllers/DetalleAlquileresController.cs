
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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

    //Metodos para alquiler y ejemplar
    private List<SelectListItem> GetAlquileres()
    {
        var alquileres = CRUD<Alquiler>.GetAll();
        return alquileres.Select(a => new SelectListItem
        {
            Value = a.id_alquiler.ToString(),
            Text = $"Alquiler #{a.id_alquiler} - {a.fecha_alquiler:dd/MM/yyyy}"
        }).ToList();
    }

    private List<SelectListItem> GetEjemplares()
    {
        var ejemplares = CRUD<Ejemplar>.GetAll();
        return ejemplares.Select(e => new SelectListItem
        {
            Value = e.id_ejemplar.ToString(),
            Text = $"{e.codigo_identificacion} ({e.formato})"
        }).ToList();
    }
    // GET: DETALLEALQUILERS/Create
    // GET: DetalleAlquilers/Create
    public ActionResult Create()
    {
        ViewBag.id_alquiler = new SelectList(CRUD<Alquiler>.GetAll(), "id_alquiler", "id_alquiler");

   
        ViewBag.id_ejemplar = new SelectList(CRUD<Ejemplar>.GetAll(), "id_ejemplar", "codigo_identificacion");

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
        ViewBag.Alquileres = GetAlquileres();
        ViewBag.Ejemplares = GetEjemplares();
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
