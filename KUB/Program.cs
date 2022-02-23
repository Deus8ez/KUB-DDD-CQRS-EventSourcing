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
builder.Services.AddScoped<ITournamentReadRepository, TournamentReadRepository>();
builder.Services.AddScoped<IParticipantReadRepository, ParticipantReadRepository>();
//builder.Services.AddScoped<ISchoolReadRepository, SchoolReadRepository>();
builder.Services.AddScoped<IBaseWriteRepository, BaseWriteRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ITournamentService, Service>();
builder.Services.AddScoped<IParticipantService, Service>();
//builder.Services.AddScoped<ISchoolService, Service>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBaseCommandHandler, CommandHandler>();
builder.Services.AddSqlServer<ManagementGamesDB>(configuration.GetConnectionString("LocalDB"));
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
