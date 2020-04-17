using BearstrengthApi.Data;
using BearstrengthApi.User.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using BearstrengthApi.User.Repository;
using BearstrengthApi.Error;

namespace BearstrengthApi
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
            services.AddControllers();
            services.AddLogging();
            services.AddDbContext<BearstrengthDbContext>(options =>
            {
                options.UseNpgsql(Configuration.GetConnectionString("BearstrengthConnectionString"));
            });
            services.AddEntityFrameworkNpgsql();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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
