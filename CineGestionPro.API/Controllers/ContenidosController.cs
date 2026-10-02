using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;

[Route("api/[controller]")]
[ApiController]
public class ContenidosController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public ContenidosController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/Contenido
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Contenido>>> GetContenido()
    {
        return await _context.Contenidos.ToListAsync();
    }

    // GET: api/Contenido/5
    [HttpGet("{id_contenido}")]
    public async Task<ActionResult<Contenido>> GetContenido(int id_contenido)
    {
        var contenido = await _context.Contenidos.FindAsync(id_contenido);

        if (contenido == null)
        {
            return NotFound();
        }

        return contenido;
    }

    // PUT: api/Contenido/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_contenido}")]
    public async Task<IActionResult> PutContenido(int? id_contenido, Contenido contenido)
    {
        if (id_contenido != contenido.id_contenido)
        {
            return BadRequest();
        }

        _context.Entry(contenido).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!ContenidoExists(id_contenido))
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

    // POST: api/Contenido
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Contenido>> PostContenido(Contenido contenido)
    {
        _context.Contenidos.Add(contenido);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetContenido", new { id_contenido = contenido.id_contenido }, contenido);
    }

    // DELETE: api/Contenido/5
    [HttpDelete("{id_contenido}")]
    public async Task<IActionResult> DeleteContenido(int? id_contenido)
    {
        var contenido = await _context.Contenidos.FindAsync(id_contenido);
        if (contenido == null)
        {
            return NotFound();
        }

        _context.Contenidos.Remove(contenido);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool ContenidoExists(int? id_contenido)
    {
        return _context.Contenidos.Any(e => e.id_contenido == id_contenido);
    }
}
