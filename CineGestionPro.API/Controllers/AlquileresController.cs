using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;

[Route("api/[controller]")]
[ApiController]
public class AlquileresController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public AlquileresController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/Alquiler
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Alquiler>>> GetAlquiler()
    {
        return await _context.Alquileres
        .Include(a => a.DetalleAlquileres)
            .ThenInclude(d => d.Ejemplar)
                .ThenInclude(e => e.Contenido)
                    .ThenInclude(c => c.Categoria)
        .ToListAsync();
    }

    // GET: api/Alquiler/5
    [HttpGet("{id_alquiler}")]
    public async Task<ActionResult<Alquiler>> GetAlquiler(int id_alquiler)
    {
        var alquiler = await _context.Alquileres.
            Include(a => a.DetalleAlquileres)
            .ThenInclude(d => d.Ejemplar)
                .ThenInclude(e => e.Contenido)
                    .ThenInclude(c => c.Categoria).
            FirstOrDefaultAsync(a => a.id_alquiler == id_alquiler);

        if (alquiler == null)
        {
            return NotFound();
        }

        return alquiler;
    }

    // PUT: api/Alquiler/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_alquiler}")]
    public async Task<IActionResult> PutAlquiler(int? id_alquiler, Alquiler alquiler)
    {
        if (id_alquiler != alquiler.id_alquiler)
        {
            return BadRequest();
        }

        _context.Entry(alquiler).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!AlquilerExists(id_alquiler))
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

    // POST: api/Alquiler
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Alquiler>> PostAlquiler(Alquiler alquiler)
    {
        _context.Alquileres.Add(alquiler);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetAlquiler", new { id_alquiler = alquiler.id_alquiler }, alquiler);
    }

    // DELETE: api/Alquiler/5
    [HttpDelete("{id_alquiler}")]
    public async Task<IActionResult> DeleteAlquiler(int? id_alquiler)
    {
        var alquiler = await _context.Alquileres.FindAsync(id_alquiler);
        if (alquiler == null)
        {
            return NotFound();
        }

        _context.Alquileres.Remove(alquiler);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool AlquilerExists(int? id_alquiler)
    {
        return _context.Alquileres.Any(e => e.id_alquiler == id_alquiler);
    }
}
