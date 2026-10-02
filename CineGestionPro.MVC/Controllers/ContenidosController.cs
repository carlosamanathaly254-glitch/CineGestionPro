
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public ActionResult Details(int id)
    {
        var contenido = CRUD<Contenido>.GetById(id);
        if (id == null)
        {
            return NotFound();
        }
        return View(contenido);
    }

    //Metodo interno para Categorias

    private List<SelectListItem> GetCategorias()
    {
        var categorias = CRUD<Categoria>.GetAll();
        return categorias.Select(c => new SelectListItem
        {
            Value = c.id_categoria.ToString(),
            Text = c.nombre_categoria
        }).ToList();
    }

    // GET: CONTENIDOS/Create
    public ActionResult Create()
    {
        ViewBag.id_categoria = new SelectList(CRUD<Categoria>.GetAll(), "id_categoria", "nombre_categoria");
        var tiposExistentes = CRUD<Contenido>.GetAll()
                                            .Select(c => c.tipo)
                                            .Where(t => !string.IsNullOrEmpty(t))
                                            .Distinct()
                                            .ToList();

        ViewBag.ListaTipos = new SelectList(tiposExistentes);
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
    public ActionResult Edit(int id)
    {
        ViewBag.Categorias = GetCategorias();
        var contenido = CRUD<Contenido>.GetById(id);
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
    public ActionResult Edit(int id, Contenido contenido)
    {
        try
        {
            CRUD<Contenido>.Update(id, contenido);
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
    public ActionResult Delete(int id)
    {
        var contenido = CRUD<Contenido>.GetById(id);
        if (contenido == null)
        {
            return NotFound();
        }

        return View(contenido);
    }

    // POST: CONTENIDOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id, Contenido contenido)
    {
        try
        {
            CRUD<Contenido>.Delete(id);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(contenido);
        }
    }
}
