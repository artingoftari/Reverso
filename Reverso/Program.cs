using MediatR;
using Microsoft.EntityFrameworkCore;
using Reverso.Application.Configuration;
using Reverso.Application.Phrase;
using Reverso.Persistence;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ReversoDbContext>(o => { o.UseSqlServer(builder.Configuration.GetConnectionString("DbConnectionString")); });
builder.Services.AddMediatR(typeof(ReversePhraseCommandHandler).GetTypeInfo().Assembly);
//builder.Services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

var confObject = Activator.CreateInstance(typeof(ReversePhraseConfiguration));
builder.Configuration.Bind(confObject);
builder.Configuration.GetSection(nameof(ReversePhraseConfiguration)).Bind(confObject);
builder.Services.AddSingleton((ReversePhraseConfiguration)confObject);


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
