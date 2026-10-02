using Microsoft.EntityFrameworkCore;

public class CineGestionProAPIContext(DbContextOptions<CineGestionProAPIContext> options) : DbContext(options)
{
    public DbSet<CineGestionPro.Modelos.Ejemplar> Ejemplar { get; set; } = default!;
}
