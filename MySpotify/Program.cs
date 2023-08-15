using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.IdentityModel.Tokens;
using MySpotify.Data.Interfaces;
using MySpotify.Data.Repositories;
using MySpotify.Services.Impl;
using MySpotify.Services.Interfaces;
using MySpotify.Services.Utils;
using MySpotity.Data;

var configuration = new ConfigurationBuilder().AddJsonFile($"appsettings.json");

var config = configuration.Build();
var connectionStrings = config.GetConnectionString("DefaultConnection");
//var connectionString = connectionStrings.GetValue<string>("DefaultConnection");
var keyJwt = config.GetValue<string>("JwtKey");

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Services.AddControllers();

ConfigureMVC(builder);
ConfigureAuthentication(builder);
ConfigureData(builder);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(cors => cors.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


void ConfigureMVC(WebApplicationBuilder builder)
{
    builder.Services.AddControllers().ConfigureApiBehaviorOptions(options =>
    {
        options.SuppressModelStateInvalidFilter = true;
    });

}

void ConfigureAuthentication(WebApplicationBuilder builder)
{

    string key1 = builder.Configuration.GetValue<string>("JwtKey");
    //var key = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("AppSettings")["JwtKey"];
    var keyBytes = Encoding.ASCII.GetBytes(keyJwt); //(Globals._KeyT);
    builder.Services.AddAuthentication(configure =>
    {
        configure.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        configure.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

    }).AddJwtBearer(autenticacao =>
    {
        autenticacao.RequireHttpsMetadata = false;
        autenticacao.SaveToken = true;
        autenticacao.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(keyBytes),
            ValidateIssuer = false,
            ValidateAudience = false
        };
    });

    builder.Services.AddCors();
}



void ConfigureData(WebApplicationBuilder builder)
{
    
    var connString = builder.Configuration.GetConnectionString("DefaultConnection");
    builder.Services.AddDbContext<DataContext>(options =>
    {
        options.UseMySql(connString, ServerVersion.AutoDetect(connString));
    });
    
    builder.Services.AddTransient<TokenService>();

    //Repositories
    builder.Services.AddScoped<IUserRepository, UserRepository>();
    builder.Services.AddScoped<IMusicRepository, MusicRepository>();
    builder.Services.AddScoped<IPlaylistRepository, PlaylistRepository>();
    builder.Services.AddScoped<IRhythmRepository, RhythmRepository>();
    builder.Services.AddScoped<IRoleRepository, RoleRepository>();
    builder.Services.AddScoped<ISingerRepository, SingerRepository>();

    //Services
    builder.Services.AddTransient<IMusicService, MusicService>();
    builder.Services.AddTransient<IPlaylistService, PlaylistService>();



}

/*
using MySpotify.Data.Interfaces;
using MySpotify.Data.Repositories;
using MySpotify.Services.Utils;
using MySpotity.Data;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
*/



