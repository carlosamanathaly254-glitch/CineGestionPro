using Microsoft.EntityFrameworkCore;

public class CineGestionProAPIContext(DbContextOptions<CineGestionProAPIContext> options) : DbContext(options)
{
    public DbSet<CineGestionPro.Modelos.Usuario> Usuario { get; set; } = default!;
}
