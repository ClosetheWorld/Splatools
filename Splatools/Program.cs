using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Splatools.Domain.Services;
using Splatools.Domain.Services.Interfaces;
using Splatools.Infrastructure.Database;
using Splatools.Repository;
using Splatools.Repository.Interfaces;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;
var environment = builder.Environment;

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Services
builder.Services.AddScoped<IGetNintendoAuthUrl, GetNintendoAuthUrl>();

// Repositories
builder.Services.AddScoped<IAuthenticationParameterRepository, AuthenticationParameterRepository>();

builder.Services.AddDbContext<SplatDbContext>(optionsBuilder => optionsBuilder.UseSqlServer(configuration.GetConnectionString("Database")));

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