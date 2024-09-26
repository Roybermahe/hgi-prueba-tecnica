using Dominio.Contratos;
using Infraestructura.Base;
using Infraestructura.DominioContext;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);



// agregamos el soporte para postgresSQL usando Npgsql
builder.Services.AddDbContext<PruebaTecnicaContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("AllContext")));

// agregamos inyección de dependencia
builder.Services.AddScoped<IDbContext, PruebaTecnicaContext>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowOrigins",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200")
                .AllowAnyHeader()
                .AllowAnyMethod();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowOrigins");

app.UsePathBase("/api");
app.UseAuthorization();

app.MapControllers();

app.Run();
