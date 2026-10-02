using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;

[Route("api/[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly CineGestionProAPIContext _context;
    public CategoriasController(CineGestionProAPIContext context)
    {
        _context = context;
    }

    // GET: api/Categoria
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Categoria>>> GetCategoria()
    {
        return await _context.Categorias
        .Include(c => c.Contenidos)
            .ThenInclude(co => co.Ejemplares)
        .ToListAsync();
    }

    // GET: api/Categoria/5
    [HttpGet("{id_categoria}")]
    public async Task<ActionResult<Categoria>> GetCategoria(int id_categoria)
    {
        var categoria = await _context.Categorias
            .Include(c => c.Contenidos)
                .ThenInclude(co => co.Ejemplares)
            .FirstOrDefaultAsync(c => c.id_categoria == id_categoria);

        if (categoria == null)
        {
            return NotFound();
        }

        return categoria;
    }

    // PUT: api/Categoria/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPut("{id_categoria}")]
    public async Task<IActionResult> PutCategoria(int? id_categoria, Categoria categoria)
    {
        if (id_categoria != categoria.id_categoria)
        {
            return BadRequest();
        }

        _context.Entry(categoria).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!CategoriaExists(id_categoria))
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

    // POST: api/Categoria
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<Categoria>> PostCategoria(Categoria categoria)
    {
        _context.Categorias.Add(categoria);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetCategoria", new { id_categoria = categoria.id_categoria }, categoria);
    }

    // DELETE: api/Categoria/5
    [HttpDelete("{id_categoria}")]
    public async Task<IActionResult> DeleteCategoria(int? id_categoria)
    {
        var categoria = await _context.Categorias.FindAsync(id_categoria);
        if (categoria == null)
        {
            return NotFound();
        }

        _context.Categorias.Remove(categoria);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool CategoriaExists(int? id_categoria)
    {
        return _context.Categorias.Any(e => e.id_categoria == id_categoria);
    }
}
