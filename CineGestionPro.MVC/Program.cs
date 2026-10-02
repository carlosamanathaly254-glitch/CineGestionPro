using Microsoft.EntityFrameworkCore;
using CineGestionPro.Modelos;
using CineGestionPro.Consumer;
namespace CineGestionPro.MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var connectionString = builder.Configuration.GetConnectionString("CineGestionProAPIContext") ?? throw new InvalidOperationException("Connection string 'CineGestionProAPIContext' not found.");

            builder.Services.AddDbContext<CineGestionProAPIContext>(options => options.UseNpgsql(connectionString));

           CRUD<Alquiler>.Endpoint = "https://localhost:7225/api/Alquileres";
            CRUD<Categoria>.Endpoint = "https://localhost:7225/api/Categorias";
            CRUD<Contenido>.Endpoint = "https://localhost:7225/api/Contenidos";
            CRUD<DetalleAlquiler>.Endpoint = "https://localhost:7225/api/DetalleAlquileres";
            CRUD<Ejemplar>.Endpoint = "https://localhost:7225/api/Ejemplares";
            CRUD<Rol>.Endpoint = "https://localhost:7225/api/Roles";
            CRUD<Usuario>.Endpoint = "https://localhost:7225/api/Usuarios";

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
