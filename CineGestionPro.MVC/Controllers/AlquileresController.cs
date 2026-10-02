using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        if (alquiler == null)
        {
            return NotFound();
        }
        return View(alquiler);
    }

    // Método para cargar usuarios y asociarlos al ViewBag correcto
    private List<SelectListItem> GetUsuarios()
    {
        var usuarios = CRUD<Usuario>.GetAll();
        return usuarios.Select(u => new SelectListItem
        {
            Value = u.id_usuario.ToString(),
            Text = $"{u.nombre} {u.apellido}"
        }).ToList();
    }

    // GET: ALQUILERS/Create
    public ActionResult Create()
    {
       
        ViewBag.id_usuario = GetUsuarios();
        return View();
    }

    // POST: ALQUILERS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Alquiler alquiler)
    {
        try
        {
            
            alquiler.id_alquiler = 0;

            CRUD<Alquiler>.Create(alquiler);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            
            ViewBag.id_usuario = GetUsuarios();
            ModelState.AddModelError("", ex.Message);
            return View(alquiler);
        }
    }

    // GET: ALQUILERS/Edit/5
    public ActionResult Edit(int id)
    {
        ViewBag.id_usuario = GetUsuarios();
        var alquiler = CRUD<Alquiler>.GetById(id);
        if (alquiler == null)
        {
            return NotFound();
        }
        return View(alquiler);
    }

    // POST: ALQUILERS/Edit/5
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
            ViewBag.id_usuario = GetUsuarios();
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
    public ActionResult DeleteConfirmed(int id)
    {
        try
        {
            CRUD<Alquiler>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View();
        }
    }
}