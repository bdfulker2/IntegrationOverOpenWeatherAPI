using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json.Converters;

namespace RetrieveOpenWeatherAPIData
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
            //dependency injection for CodeCanaryDatabaseSetting
            services.Configure<ConfigLibrarySettings>(
                Configuration.GetSection(nameof(ConfigLibrarySettings)));

            //dependency injection 
            services.AddSingleton<IConfigLibrarySettings>(sp =>
                sp.GetRequiredService<IOptions<ConfigLibrarySettings>>().Value);

            services.AddScoped<ICurrentWeatherForecastService<CurrentWeatherForecastRoot>, CurrentWeatherForecastService>();
            //services.AddSingleton<ILogger>();

            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    //set Swagger UI title
                    Title = "WeatherAPI",
                    Version = "v1",
                    Description = "An API for accessing the OpenWeatherApi.orgs api",

                    //sets contact information
                    Contact = new OpenApiContact
                    {
                        Name = "Ben Fulker",
                        Email = "bfulker1596@eagle.fgcu.edu"
                    }
                });

                //provides XML documentation.
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
            });

            /*above must be included for swashbuckle.AspNetCore package*/
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "WeatherAPI");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
