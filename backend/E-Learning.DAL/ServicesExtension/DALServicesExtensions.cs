using E_Learning.DAL.Data.Context;
using E_Learning.DAL.UnitOfWorkDP;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace E_Learning.DAL.ServicesExtension
{
    public static class DALServicesExtensions
    {
        public static void AddDALServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddConsole();
                loggingBuilder.AddDebug();
            });
            /*------------------------------------------------------------------------*/
            var connectionString = configuration.GetConnectionString("Yasser");
          
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString));
            /*------------------------------------------------------------------------*/
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            /*------------------------------------------------------------------------*/
        }
    }
}

