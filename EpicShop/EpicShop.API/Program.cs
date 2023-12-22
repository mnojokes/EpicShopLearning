using EpicShop.API.Contexts;
using EpicShop.API.Interfaces;
using EpicShop.API.Middlewares;
using EpicShop.API.Repositories;
using EpicShop.API.Services;
using Microsoft.EntityFrameworkCore;
using Npgsql;
using System;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var Configuration = builder.Configuration;

// Set up Dapper Postgre DB
//string dbConnectionString = Configuration.GetConnectionString("PostgreConnectionDapper")
//    ?? throw new ArgumentNullException($"{nameof(dbConnectionString)} cannot be null.");
//builder.Services.AddScoped<IDbConnection>(sp => new NpgsqlConnection(dbConnectionString));
//builder.Services.AddScoped<IItemRepository, ItemRepositoryDapper>();

// Set up EFCore InMemory DB
//builder.Services.AddDbContext<DataContext>(o => o.UseInMemoryDatabase("EpicShopEFCore"));
//builder.Services.AddScoped<IItemRepository, ItemRepositoryEFCoreInMemory>();

// Set up EFCore Postgre DB
string dbConnectionString = Configuration.GetConnectionString("PostgreConnectionEFC")
    ?? throw new ArgumentNullException($"{nameof(dbConnectionString)} cannot be null.");

builder.Services.AddMvc();
builder.Services.AddEntityFrameworkNpgsql().AddDbContext<DataContext>(o => o.UseNpgsql(dbConnectionString));
builder.Services.AddScoped<IItemRepository, ItemRepositoryEFCorePostgre>();

builder.Services.AddScoped<ItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseExceptionHandlingMiddleware();

app.MapControllers();

app.Run();
