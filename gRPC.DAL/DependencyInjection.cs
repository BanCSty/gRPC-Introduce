using gRPC.DAL.Repositories;
using gRPC.Domain;
using gRPC.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace gRPC.DAL
{
    public static class DependencyInjection
    {
        //Добавление контекста БД и его регистрация 
        public static IServiceCollection AddPersistence(this IServiceCollection service,
            IConfiguration configuration)
        {
            var connectionString = configuration["DbConnection"];
            service.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlite(connectionString);
            });

            service.AddScoped<IBaseRepository<User>, UserRepository>();
 

            return service;
        }
    }
}
