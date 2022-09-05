// https://www.entityframeworktutorial.net/efcore/entity-framework-core.aspx

using Microsoft.EntityFrameworkCore; // adicionado para usar DB
using src.Persistence; // adicionado para usar DB

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DatabaseContext>(options => options.UseInMemoryDatabase("dbcontracts")); // adicionado para usar DB

builder.Services.AddScoped<DatabaseContext, DatabaseContext>(); // adicionado para usar DB

builder.Services.AddControllers();
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

app.UseAuthorization();

app.MapControllers();

app.Run();
