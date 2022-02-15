using AutoMapper;
using KUB.Core;
using KUB.Core.Interfaces;
using KUB.Core.Interfaces;
using KUB.Core.Models;
using KUB.Infrastructure.Data;
using KUB.Infrastructure.Data.Repositories;
using KUB.Infrastructure.Data.UnitsOfWork;
using KUB.SharedKernel.DTOModels.Tournament;
using KUB.SharedKernel.DTOModels.Tournament.Requests;
using KUB.Web.Services;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var mapperConfig = new MapperConfiguration(cfg =>
        cfg.AddProfile(new MappingProfile())
    );

IMapper mapper = mapperConfig.CreateMapper();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IReadRepository<TournamentDto>, TournamentReadRepository>();
builder.Services.AddScoped<IWriteRepository<Tournament>, TournamentWriteRepository>();
builder.Services.AddScoped<IEventRepository<BaseEvent>, EventRepository>();
builder.Services.AddScoped<IService<TournamentDto, Tournament>, TournamentService>();
builder.Services.AddScoped<IUnitOfWork<Tournament, BaseEvent>, TournamentUnitOfWork>();
builder.Services.AddScoped<ITournamentCommandHandler, TournamentCommandHandler>();
builder.Services.AddSqlServer<ManagementGamesDB>(configuration.GetConnectionString("LocalDB"));
builder.Services.AddSingleton(mapper);
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
