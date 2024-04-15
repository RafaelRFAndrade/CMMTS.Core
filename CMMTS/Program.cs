using CMMTS.Domain;
using CMMTS.Domain.Interfaces;
using CMMTS.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

var configuration = builder.Configuration;

// AQUI VAI SER O GRROOSSSSOOOO DAS DEPENDENCIAS 
builder.Services.AddSingleton<Connection>(new Connection(configuration));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
