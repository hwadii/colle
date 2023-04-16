using Microsoft.EntityFrameworkCore;
using Colle.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services
    .AddDbContext<PasteContext>(options =>
    {
        options.UseNpgsql(builder.Configuration.GetSection("ConnectionStrings").GetValue<string>("colle")).UseSnakeCaseNamingConvention();
    });
builder.Services.AddMvc();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
