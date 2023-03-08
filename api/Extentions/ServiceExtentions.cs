using Contracts;
using Entities;
using Microsoft.EntityFrameworkCore;
using Repository;

namespace api.Extentions
{
    static public class ServiceExtentions
    {
        static public void ConfigureCorsPolicy(this IServiceCollection services) 
        {
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });
        }

        static public void ConfigureSqlServerContext(this IServiceCollection services, IConfiguration config)
        {
            var connectionString = config["connectionString"];

            services.AddDbContext<ApplicationContext>(o =>
                o.UseSqlServer(connectionString,
                options => options.MigrationsAssembly("api"))
            );
        }
    
        static public void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }
    }
}
