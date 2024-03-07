﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using API_Projet.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<API_ProjetContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("API_ProjetContext") ?? throw new InvalidOperationException("Connection string 'API_ProjetContext' not found.")));

// Add services to the container.

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

app.UseAuthorization();

app.MapControllers();

app.Run();
