using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;

[Route("api/[controller]")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public RolesController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/Rol
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
    {
        return await _context.Roles
        .Include(r => r.Usuarios)
        .ToListAsync();
    }

    // GET: api/Rol/5
    [HttpGet("{id_rol}")]
    public async Task<ActionResult<Rol>> GetRol(int id_rol)
    {
        var rol = await _context.Roles
            .Include(r => r.Usuarios)
            .FirstOrDefaultAsync(r => r.id_rol == id_rol);

        if (rol == null)
        {
            return NotFound();
        }

        return rol;
    }

    // PUT: api/Rol/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_rol}")]
    public async Task<IActionResult> PutRol(int? id_rol, Rol rol)
    {
        if (id_rol != rol.id_rol)
        {
            return BadRequest();
        }

        _context.Entry(rol).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!RolExists(id_rol))
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

    // POST: api/Rol
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Rol>> PostRol(Rol rol)
    {
        _context.Roles.Add(rol);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetRol", new { id_rol = rol.id_rol }, rol);
    }

    // DELETE: api/Rol/5
    [HttpDelete("{id_rol}")]
    public async Task<IActionResult> DeleteRol(int? id_rol)
    {
        var rol = await _context.Roles.FindAsync(id_rol);
        if (rol == null)
        {
            return NotFound();
        }

        _context.Roles.Remove(rol);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool RolExists(int? id_rol)
    {
        return _context.Roles.Any(e => e.id_rol == id_rol);
    }
}
