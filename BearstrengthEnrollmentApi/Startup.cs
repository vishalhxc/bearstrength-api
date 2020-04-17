using BearstrengthEnrollmentApi.Data;
using BearstrengthEnrollmentApi.User.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BearstrengthEnrollmentApi.User.Repository;
using BearstrengthEnrollmentApi.Error;

namespace BearstrengthEnrollmentApi
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
            services.AddDbContext<EnrollmentDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("BearstrengthConnectionString"));
            });
            services.AddEntityFrameworkNpgsql();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
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
