using CMMTS.Domain;
using CMMTS.Domain.Interfaces;
using CMMTS.Domain.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração das dependências
builder.Services.AddSingleton<Connection>(new Connection(builder.Configuration));
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// Servir arquivos estáticos
app.UseDefaultFiles(); // Serve arquivos padrão como index.html, index.htm, etc.
app.UseStaticFiles(); // Serve arquivos estáticos como HTML, CSS, JavaScript, etc.

// Configuração de endpoints personalizados
app.Map("/api/usuario", HandleUsuarioEndpoint); // Endpoint customizado para manipular usuários

app.Run();

// Lógica para manipulação do endpoint de usuário
void HandleUsuarioEndpoint(IApplicationBuilder app)
{
    app.Run(async context =>
    {
        // Lógica para manipular as requisições do endpoint de usuário
        // Exemplo: ler os dados da requisição, chamar métodos do repositório, etc.
        await context.Response.WriteAsync("Endpoint de usuário");
    });
}
