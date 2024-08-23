using SocialAPI.Aplicaciones.Interfaces;
using SocialAPI.Aplicaciones.Servicios;
using SocialAPI.Dominio;
using SocialAPI.Dominio.Interfaces.Repositorios;
using SocialAPI.Infraestructura.Memoria.Repositorios;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Registro de servicios en el contenedor de DI
builder.Services.AddSingleton<IRepositorioUser<Usuario, Guid>, RepositorioUsuarios>();
builder.Services.AddScoped<IUsuarioService<Usuario, Guid>, UsuarioServicio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
