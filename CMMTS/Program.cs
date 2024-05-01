using CMMTS.Domain;
using CMMTS.Domain.Interfaces;
using CMMTS.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura��o das depend�ncias
builder.Services.AddSingleton<Connection>(new Connection(builder.Configuration));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Servir arquivos est�ticos
app.UseDefaultFiles(); // Serve arquivos padr�o como index.html, index.htm, etc.
app.UseStaticFiles(); // Serve arquivos est�ticos como HTML, CSS, JavaScript, etc.

// Configura��o de endpoints personalizados
app.Map("/api/usuario", HandleUsuarioEndpoint); // Endpoint customizado para manipular usu�rios

app.Run();

// L�gica para manipula��o do endpoint de usu�rio
void HandleUsuarioEndpoint(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        // L�gica para manipular as requisi��es do endpoint de usu�rio
        // Exemplo: ler os dados da requisi��o, chamar m�todos do reposit�rio, etc.
        await context.Response.WriteAsync("Endpoint de usu�rio");
    });
}
