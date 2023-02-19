using Airline_Reservation_System.Context;
using Airline_Reservation_System.Repository;
using Airline_Reservation_System.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airline_Reservation_System
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //string LocalSQlConnectionString = "Server=DESKTOP-M1N8JGA;Database=AirlineReservationSystem;Trusted_Connection=True";
            string LocalSQlConnectionString = Configuration.GetConnectionString("LocalDatabaseConnection");
            services.AddControllersWithViews();
            services.AddSession();
            services.AddScoped<IUserService,UserService>();
            services.AddScoped<IUserRepository,UserRepository>();
            services.AddScoped<IPlainService,PlainService>();
            services.AddScoped<IPlainRepository,PlainRepository>();
            services.AddScoped<ITokenGenerator,TokenGenerator>();
            services.AddDbContext<AirlineReservationSystemContextDb>(A => A.UseSqlServer(LocalSQlConnectionString));
            JwtValidationParameters(services, Configuration);
        }

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

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseSession();
            app.UseStaticFiles();
            app.Use(async (Context, next) =>
            {
                var tokenInfo = Context.Session.GetString("token");
                Context.Request.Headers.Add("Authorization", "Bearer " + tokenInfo);
                await next();
            });

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Index}/{id?}");
            });
        }
    }
}
