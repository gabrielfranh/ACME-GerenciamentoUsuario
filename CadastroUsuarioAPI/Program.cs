using AgendamentoAPI.Config;
using AutoMapper;
using CadastroUsuarioAPI.Context;
using CadastroUsuarioAPI.Repositories;
using CadastroUsuarioAPI.Repositories.Interface;
using CadastroUsuarioAPI.Services;
using CadastroUsuarioAPI.Services.Interface;
using CadastroUsuarioAPI.Utils;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.]

var connection = builder.Configuration["MySqlConnection:MySQLConnectionString"];
var mapper = MappingConfig.RegisterMaps().CreateMapper();
var tokenUtils = new TokenUtils(builder.Configuration);

builder.Services.AddDbContext<MySQLContext>(options => options
    .UseMySql(connection,
        new MySqlServerVersion(
            new Version(8, 0, 28))));

builder.Services.AddSingleton(mapper);
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddSingleton(tokenUtils);

builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddControllers();

var key = Encoding.ASCII.GetBytes(builder.Configuration["Token:SecretKey"]);
builder.Services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(options =>
        {
            options.RequireHttpsMetadata= false;
            options.SaveToken = true;
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });

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

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
