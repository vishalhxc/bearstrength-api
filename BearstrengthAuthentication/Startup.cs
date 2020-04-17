using BearstrengthAuthentication.Data;
using BearstrengthAuthentication.Athlete.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BearstrengthAuthentication.Athlete.Repository;
using BearstrengthAuthentication.Error;

namespace BearstrengthAuthentication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        { 
            services.AddControllers();
            services.AddLogging();
            services.AddDbContext<AuthenticationDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("BearstrengthConnectionString"));
            });
            services.AddEntityFrameworkNpgsql();
            services.AddScoped<IAthleteService, AthleteService>();
            services.AddScoped<IAthleteRepository, AthleteRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    await ErrorHandler.HandleHttpExceptions(context);
                });
            });

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            { 
                endpoints.MapControllers();
            });
        }
    }
}
