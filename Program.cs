global using Role_playing_game.Models;
global using Role_playing_game.Services.CharacterService;
global using System.Threading.Tasks;
global using Role_playing_game.Dtos.Character;
global using AutoMapper;
global using Microsoft.EntityFrameworkCore;
global using Role_playing_game.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<DataContext>(options =>
 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddScoped<ICharacterService,CharacterService>();
//this means now the (Web API)server knows that they have to inject the CharacterService class whenever a controller wants to inject ICharacterService.
//change here we will be done

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
