using Microsoft.EntityFrameworkCore;
using NaukaWebApi.Data;
using NaukaWebApi.Services.PersonService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPersonService, PersonService>();

builder.Services.AddDbContext<DataContext>
(
    options => options.UseSqlServer("Server=localhost;Database=Nauka;Trusted_Connection=true;TrustServerCertificate=true;")
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
