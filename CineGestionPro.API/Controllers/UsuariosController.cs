using CineGestionPro.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

[Route("api/[controller]")]
[ApiController]
public class UsuariosController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public UsuariosController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/Usuario
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Usuario>>> GetUsuario()
    {
        return await _context.Usuarios
        .Include(u => u.Rol)
        .Include(u => u.Alquileres)
            .ThenInclude(a => a.DetalleAlquileres)
        .ToListAsync();
    }

    // GET: api/Usuario/5
    [HttpGet("{id_usuario}")]
    public async Task<ActionResult<Usuario>> GetUsuario(int id_usuario)
    {
        var usuario = await _context.Usuarios
            .Include(u => u.Rol)
            .Include(u => u.Alquileres)
                .ThenInclude(a => a.DetalleAlquileres)
            .FirstOrDefaultAsync(u => u.id_usuario == id_usuario);

        if (usuario == null)
        {
            return NotFound();
        }

        return usuario;
    }


    // PUT: api/Usuario/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_usuario}")]
    public async Task<IActionResult> PutUsuario(int? id_usuario, Usuario usuario)
    {
        if (id_usuario != usuario.id_usuario)
        {
            return BadRequest();
        }

        _context.Entry(usuario).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!UsuarioExists(id_usuario))
            {
                return NotFound();
            }
            else
            {
                throw;
            }
        }

        return NoContent();
    }

    // POST: api/Usuario
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
    {
        _context.Usuarios.Add(usuario);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetUsuario", new { id_usuario = usuario.id_usuario }, usuario);
    }

    // DELETE: api/Usuario/5
    [HttpDelete("{id_usuario}")]
    public async Task<IActionResult> DeleteUsuario(int? id_usuario)
    {
        var usuario = await _context.Usuarios.FindAsync(id_usuario);
        if (usuario == null)
        {
            return NotFound();
        }

        _context.Usuarios.Remove(usuario);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool UsuarioExists(int? id_usuario)
    {
        return _context.Usuarios.Any(e => e.id_usuario == id_usuario);
    }
}
