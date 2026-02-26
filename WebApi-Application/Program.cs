using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApi.Application;
using WebApi.Application.Common.Models;
using WebApi.Infrastucture;
using WebApi_Application.Middleware;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using WebApi_Application;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();

// Api Dependencies
builder.Services.AddApiDependency(jwtSettings);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Api Dependencies
builder.Services.AddApplicationDependencies();

// Infrastructure Dependencies
builder.Services.AddInfrastructureDependencies();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Added Middleware
app.UseAuthentication();
app.UseAuthorization();

//Custom Middleware

app.UseMiddleware<GlobalExceptionMiddleware>();

app.MapControllers();

app.Run();
