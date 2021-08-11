using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Evolent.Demo.Domain.Services;
using AutoMapper;
using System;
using Evolent.Demo.Domain;
using Evolent.Demo.Data;
using System.Data.Common;
using Newtonsoft.Json.Serialization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using Newtonsoft.Json;

namespace Evolent.Demo.Web
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
           

            services.AddControllersWithViews()
                .AddNewtonsoftJson(options =>
                  {
                      options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                      options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                      //options.SerializerSettings.DateFormatString = "yyyy-MMM-dd HH:mm:ss";

                      // This prevents the json serializer from parsing dates
                      options.SerializerSettings.DateParseHandling = DateParseHandling.DateTime;
                      // This changes how the timezone is converted - RoundtripKind keeps the timezone that was provided and doesn't convert it
                      options.SerializerSettings.DateTimeZoneHandling = DateTimeZoneHandling.Local;
                  }
                   
            );

            

            services.AddSingleton(Serilog.Log.Logger);

            services.ConfigureDEMODomainServices();
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", System.Data.SqlClient.SqlClientFactory.Instance);
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });

            app.UseRouting();
            

            //app.UseAuthentication();
            //app.UseAuthorization();
            app.UseEndpoints(endPoints =>
            {
                endPoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}", defaults: new { controller = "WeatherForecast"});

            });

        }
    }

}
