using Infrastructure.Persistence;          // DbContext y extensión de infraestructura
using Application.Interfaces;              // Interfaces de servicios de Application
using Application.Services;                // Implementaciones concretas de servicios
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 1️⃣ Configurar DbContext (Infrastructure)
builder.Services.AddInfrastructure(builder.Configuration);

// 2️⃣ Registrar servicios de Application
builder.Services.AddScoped<IAutomovilService, AutomovilService>();

// 3️⃣ Agregar controladores
builder.Services.AddControllers();

// 4️⃣ Configurar Swagger/OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API Automóvil",
        Version = "v1",
        Description = "API REST para gestionar información de automóviles"
    });
});

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";


builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin()
                                .AllowAnyHeader()
                                .AllowAnyMethod();
                      });
});


var app = builder.Build();

// 5️⃣ Middleware de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API Automóvil V1");
        c.RoutePrefix = string.Empty; // Para abrir Swagger en la raíz: https://localhost:5001/
    });
}

// Luego en el pipeline:
app.UseCors(MyAllowSpecificOrigins);

// 6️⃣ Middlewares básicos
app.UseHttpsRedirection();
app.UseAuthorization();

// 7️⃣ Mapear controladores
app.MapControllers();

app.Run();
