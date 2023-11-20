using Microsoft.EntityFrameworkCore;
using Steeltoe.Discovery.Client;
using Steeltoe.Extensions.Configuration;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddScoped<CustomerService>();
builder.Services.AddScoped<CustomerRepository>();
builder.Services.AddScoped<PreferenceService>();
builder.Services.AddScoped<PreferenceRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
builder.Services.AddDiscoveryClient(builder.Configuration);
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySQL(connectionString);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseDiscoveryClient();

app.UseAuthorization();

app.MapControllers();

app.Run("http://0.0.0.0:8080");
