
using CineGestionPro.Consumer;
using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class UsuariosController : Controller
{
    // GET: USUARIOS
    public ActionResult Index()
    {
        var usuarios = CRUD<Usuario>.GetAll();
        return View(usuarios);
    }

    // GET: USUARIOS/Details/5
    public ActionResult Details(int id_usuario)
    {
        var usuario = CRUD<Usuario>.GetById(id_usuario);
        if (id_usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    // GET: USUARIOS/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: USUARIOS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Usuario usuario)
    {
        try
        {
            CRUD<Usuario>.Create(usuario);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(usuario);
        }
    }

    // GET: USUARIOS/Edit/5
    public ActionResult Edit(int id_usuario)
    {
        var usuario = CRUD<Usuario>.GetById(id_usuario);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    // POST: USUARIOS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id_usuario, Usuario usuario)
    {
        try
        {
            CRUD<Usuario>.Update(id_usuario, usuario);
            return RedirectToAction(nameof(Index));

        }
        catch (Exception ex)
        {
            // Handle the exception (e.g., log it, display an error message, etc.)
            ModelState.AddModelError("", ex.Message);
            return View(usuario);
        }
    }

    // GET: USUARIOS/Delete/5
    public ActionResult Delete(int id_usuario)
    {
        var usuario = CRUD<Usuario>.GetById(id_usuario);
        if (usuario == null)
        {
            return NotFound();
        }

        return View(usuario);
    }

    // POST: USUARIOS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id_usuario, Usuario usuario)
    {
        try
        {
            CRUD<Usuario>.Delete(id_usuario);
            return RedirectToAction(nameof(Index));
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", ex.Message);
            return View(usuario);
        }
    }
}
