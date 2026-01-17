using Microsoft.EntityFrameworkCore;
using Rekrytering.Api.Data;
using Rekrytering.Api.Tjanster;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

// Tillåt Web-projektet att anropa API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowWebApp",
        policy => policy
            .WithOrigins("https://localhost:7001") // Web-porten
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplikationDbContext>(options =>
    options.UseSqlite("Data Source=rekrytering.db"));
builder.Services.AddScoped<KandidatTjanst>();

var app = builder.Build();

app.UseCors("AllowWebApp"); // aktivera CORS

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();