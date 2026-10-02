using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;

[Route("api/[controller]")]
[ApiController]
public class EjemplaresController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public EjemplaresController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/Ejemplar
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Ejemplar>>> GetEjemplar()
    {
        return await _context.Ejemplares
        .Include(e => e.Contenido)
            .ThenInclude(c => c.Categoria)
        .Include(e => e.DetallesAlquiler)
            .ThenInclude(d => d.Alquiler)
        .ToListAsync();
    }

    // GET: api/Ejemplar/5
    [HttpGet("{id_ejemplar}")]
    public async Task<ActionResult<Ejemplar>> GetEjemplar(int id_ejemplar)
    {
        var ejemplar = await _context.Ejemplares
            .Include(e => e.Contenido)
                .ThenInclude(c => c.Categoria)
            .Include(e => e.DetallesAlquiler)
                .ThenInclude(d => d.Alquiler)
            .FirstOrDefaultAsync(e => e.id_ejemplar == id_ejemplar);

        if (ejemplar == null)
        {
            return NotFound();
        }

        return ejemplar;
    }

    // PUT: api/Ejemplar/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_ejemplar}")]
    public async Task<IActionResult> PutEjemplar(int? id_ejemplar, Ejemplar ejemplar)
    {
        if (id_ejemplar != ejemplar.id_ejemplar)
        {
            return BadRequest();
        }

        _context.Entry(ejemplar).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!EjemplarExists(id_ejemplar))
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

    // POST: api/Ejemplar
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Ejemplar>> PostEjemplar(Ejemplar ejemplar)
    {
        _context.Ejemplares.Add(ejemplar);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEjemplar", new { id_ejemplar = ejemplar.id_ejemplar }, ejemplar);
    }

    // DELETE: api/Ejemplar/5
    [HttpDelete("{id_ejemplar}")]
    public async Task<IActionResult> DeleteEjemplar(int? id_ejemplar)
    {
        var ejemplar = await _context.Ejemplares.FindAsync(id_ejemplar);
        if (ejemplar == null)
        {
            return NotFound();
        }

        _context.Ejemplares.Remove(ejemplar);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EjemplarExists(int? id_ejemplar)
    {
        return _context.Ejemplares.Any(e => e.id_ejemplar == id_ejemplar);
    }
}
