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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
IConfiguration configuration = new ConfigurationBuilder()
                            .AddJsonFile("appsettings.json")
                            .Build();

var mapperConfig = new MapperConfiguration(cfg =>
        cfg.AddProfile(new MappingProfile())
    );

IMapper mapper = mapperConfig.CreateMapper();


// Add services to the container.
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})

// Adding Jwt Bearer
.AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = configuration["JWT:ValidAudience"],
        ValidIssuer = configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
    };
});

builder.Services.AddControllers().AddJsonOptions(options =>
            options.JsonSerializerOptions.Converters.Add(new TimeSpanToStringConverter())); ;
builder.Services.AddSwaggerGen(c => c.MapType<TimeSpan?>(() => new OpenApiSchema { Type = "string", Example = new OpenApiString("00:00:00") }));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ITournamentReadRepository, TournamentReadRepository>();
builder.Services.AddScoped<IParticipantReadRepository, ParticipantReadRepository>();
builder.Services.AddScoped<ISchoolReadRepository, SchoolReadRepository>();
builder.Services.AddScoped<IBaseWriteRepository, BaseWriteRepository>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<ITournamentService, Service>();
builder.Services.AddScoped<IParticipantService, Service>();
builder.Services.AddScoped<ISchoolService, Service>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IBaseCommandHandler, CommandHandler>();
builder.Services.AddSqlServer<ManagementGamesDB>(configuration.GetConnectionString("DB"));
builder.Services.AddSingleton(mapper);
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader();
}));
var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();
app.UseCors("MyPolicy");
app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
