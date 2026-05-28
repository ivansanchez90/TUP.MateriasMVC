using Microsoft.EntityFrameworkCore;
using TUP.MateriasMVC.Data;

var builder = WebApplication.CreateBuilder(args);

// 1. Registrar MVC
builder.Services.AddControllersWithViews();

// 2. Registrar EF Core con SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// 3. Aplicar migraciones automáticamente al iniciar
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.Migrate();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// 4. Ruta por defecto apunta a MateriasController
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Materias}/{action=Index}/{id?}");

app.Run();