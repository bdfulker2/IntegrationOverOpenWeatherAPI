using System;
using System.Collections.Generic;
using System.Linq;
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
            //ConfigLibrary weatherConfig = new ConfigLibrary();
            //Configuration.GetSection("ApiKeys").Bind(weatherConfig);

            services.AddScoped<ICurrentWeatherForecastService<CurrentWeatherForecastRoot>, CurrentWeatherForecastService>();
            //services.AddSingleton<ILogger>();

            services.AddControllers().AddNewtonsoftJson(options => options.UseMemberCasing());
            services.AddMvc().AddNewtonsoftJson(options => options.SerializerSettings.Converters.Add(new StringEnumConverter()));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

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
