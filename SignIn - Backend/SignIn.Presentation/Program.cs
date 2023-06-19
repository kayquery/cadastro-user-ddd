using Microsoft.Extensions.Options;
using SignIn.Application.Interfaces;
using SignIn.Application.Services;
using SignIn.Domain.Models;
using SignIn.Infra.Base;
using SignIn.Infra.Interfaces;
using SignIn.Presentation.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<MongoSettings>(builder.Configuration.GetSection("MongoSettings"));
builder.Services.Configure<ViaCEPSettings>(builder.Configuration.GetSection("ViaCep"));
builder.Services.AddSingleton<MongoSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<MongoSettings>>().Value);
builder.Services.AddSingleton<ViaCEPSettings>(serviceProvider =>
    serviceProvider.GetRequiredService<IOptions<ViaCEPSettings>>().Value);


builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
        });
});


builder.Services.AddCustomServices();

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

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
