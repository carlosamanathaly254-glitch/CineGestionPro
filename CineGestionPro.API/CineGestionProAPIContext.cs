using Microsoft.EntityFrameworkCore;

public class CineGestionProAPIContext(DbContextOptions<CineGestionProAPIContext> options) : DbContext(options)
{
    public DbSet<CineGestionPro.Modelos.Alquiler> Alquileres { get; set; } = default!;
    public DbSet<CineGestionPro.Modelos.Categoria> Categorias { get; set; } = default!;
    public DbSet<CineGestionPro.Modelos.Contenido> Contenidos { get; set; } = default!;
    public DbSet<CineGestionPro.Modelos.DetalleAlquiler> DetalleAlquileres { get; set; } = default!;
    public DbSet<CineGestionPro.Modelos.Ejemplar> Ejemplares { get; set; } = default!;
    public DbSet<CineGestionPro.Modelos.Rol> Roles { get; set; } = default!;
    public DbSet<CineGestionPro.Modelos.Usuario> Usuarios { get; set; } = default!;
}
