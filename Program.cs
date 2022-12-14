using ApiTest.Data;
using Marten;
using Microsoft.EntityFrameworkCore;
using Marten.PLv8.Patching;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql("User ID=postgres;Password=92?VH2WMrx;Host=localhost;Port=5432;Database=postgres;Pooling=true;"));


var options = new StoreOptions();
options.Connection("User ID=postgres;Password=92?VH2WMrx;Host=localhost;Port=5432;Database=postgres;Pooling=true;");
builder.Services.AddMarten(options);

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
