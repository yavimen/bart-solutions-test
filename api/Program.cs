using api.Extentions;
using Entities;

namespace api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var services = builder.Services;

            services.ConfigureSqlServerContext(builder.Configuration);

            services.ConfigureCorsPolicy();

            services.ConfigureRepositoryWrapper();

            services.AddAutoMapper(typeof(Program));

            services.AddControllers();

            services.AddEndpointsApiExplorer();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
                app.UseDeveloperExceptionPage();
            else
                app.UseHsts();

            app.UseHttpsRedirection();

            app.UseHttpsRedirection();

            app.UseCors("CorsPolicy");

            app.UseAuthorization();

            app.MapControllers();

            app.MigrateDatabase();

            app.Run();
        }
    }
}