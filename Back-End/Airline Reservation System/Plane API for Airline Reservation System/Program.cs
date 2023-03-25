using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Plane_API_for_Airline_Reservation_System.Context;
using Plane_API_for_Airline_Reservation_System.Repository;
using Plane_API_for_Airline_Reservation_System.Service;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string LocalSQlConnectionStringCourse = builder.Configuration.GetConnectionString("LocalDatabaseConnection");
builder.Services.AddDbContext<AirlineReservationSystemContextDb>(c => c.UseSqlServer(LocalSQlConnectionStringCourse));

builder.Services.AddScoped<IPlaneService, PlaneService>();
builder.Services.AddScoped<IPlaneRepository, PlaneRepository>();

builder.Services.AddCors();

JwtValidationParameters(builder.Services, builder.Configuration);
void JwtValidationParameters(IServiceCollection services, IConfiguration configuration)
{
    var userSecretKey = configuration["JwtValidationParameters:UserSecretKey"];
    var userIssuer = configuration["JwtValidationParameters:UserIssuer"];
    var userAudience = configuration["JwtValidationParameters:UserAudience"];
    var userSecretKeyInBytes = Encoding.UTF8.GetBytes(userSecretKey);
    var userSymmetricSecurityKey = new SymmetricSecurityKey(userSecretKeyInBytes);
    var tokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuer = true,
        ValidIssuer = userIssuer,

        ValidateAudience = true,
        ValidAudience = userAudience,

        ValidateIssuerSigningKey = true,
        IssuerSigningKey = userSymmetricSecurityKey,

        ValidateLifetime = true,
    };
    services.AddAuthentication(u =>
    {
        u.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        u.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    }).AddJwtBearer(u => u.TokenValidationParameters = tokenValidationParameters);
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(x => x
           .AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
