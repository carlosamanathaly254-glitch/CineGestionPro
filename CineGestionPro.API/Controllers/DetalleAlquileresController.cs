using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;

[Route("api/[controller]")]
[ApiController]
public class DetalleAlquileresController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public DetalleAlquileresController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/DetalleAlquiler
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DetalleAlquiler>>> GetDetalleAlquiler()
    {
        return await _context.DetalleAlquileres.ToListAsync();
    }

    // GET: api/DetalleAlquiler/5
    [HttpGet("{id_detalle}")]
    public async Task<ActionResult<DetalleAlquiler>> GetDetalleAlquiler(int id_detalle)
    {
        var detallealquiler = await _context.DetalleAlquileres.FindAsync(id_detalle);

        if (detallealquiler == null)
        {
            return NotFound();
        }

        return detallealquiler;
    }

    // PUT: api/DetalleAlquiler/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_detalle}")]
    public async Task<IActionResult> PutDetalleAlquiler(int? id_detalle, DetalleAlquiler detallealquiler)
    {
        if (id_detalle != detallealquiler.id_detalle)
        {
            return BadRequest();
        }

        _context.Entry(detallealquiler).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!DetalleAlquilerExists(id_detalle))
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

    // POST: api/DetalleAlquiler
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<DetalleAlquiler>> PostDetalleAlquiler(DetalleAlquiler detallealquiler)
    {
        _context.DetalleAlquileres.Add(detallealquiler);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetDetalleAlquiler", new { id_detalle = detallealquiler.id_detalle }, detallealquiler);
    }

    // DELETE: api/DetalleAlquiler/5
    [HttpDelete("{id_detalle}")]
    public async Task<IActionResult> DeleteDetalleAlquiler(int? id_detalle)
    {
        var detallealquiler = await _context.DetalleAlquileres.FindAsync(id_detalle);
        if (detallealquiler == null)
        {
            return NotFound();
        }

        _context.DetalleAlquileres.Remove(detallealquiler);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool DetalleAlquilerExists(int? id_detalle)
    {
        return _context.DetalleAlquileres.Any(e => e.id_detalle == id_detalle);
    }
}
