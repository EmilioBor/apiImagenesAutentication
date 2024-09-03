using Microsoft.EntityFrameworkCore;
using Models.Models;
using Services;

var builder = WebApplication.CreateBuilder(args);

// Configurar CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("PermitirTodo", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<PruebaContext>(option =>
option.UseNpgsql(builder.Configuration.GetConnectionString("Conection")));

builder.Services.AddScoped<IPerfilService, PerfilService>();
builder.Services.AddScoped<IImagenService, ImagenService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

// Usar la política de CORS
app.UseCors("PermitirTodo");

app.MapControllers();

app.Run();
