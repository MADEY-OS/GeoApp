using GeoAPI.Interfaces;
using GeoAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<IGeoService, GeoService>();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
