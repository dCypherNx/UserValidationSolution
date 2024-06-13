using Application.Services;
using Domain.Interfaces;
using Infrastructure.Observers.Implementation;
using Infrastructure.Observers.Interfaces;
using Infrastructure.Repositories;
using System;

var builder = WebApplication.CreateBuilder(args);

// Configurar serviços
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Injeção de dependência
builder.Services.AddSingleton<IUserValidator, UserValidator>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IObservable, UserObservable>();
builder.Services.AddSingleton<IUserObserver, UserObserver>();

var app = builder.Build();

// Configurar o pipeline HTTP
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
