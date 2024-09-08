using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Ajouter le service DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

// Ajouter les services Swagger
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "CineMatique API", Version = "v1" });
});

var app = builder.Build();

// Configurer Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CineMatique API v1"));
}

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Accueil}");
app.MapControllerRoute(
    name: "films",
    pattern: "{controller=Film}/{action=Create}");

app.Run();
