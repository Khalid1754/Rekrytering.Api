using Microsoft.EntityFrameworkCore;
using Rekrytering.Api.Data;
using Rekrytering.Api.Tjanster;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ApplikationDbContext>(options =>
    options.UseSqlite("Data Source=rekrytering.db"));

builder.Services.AddScoped<KandidatTjanst>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
