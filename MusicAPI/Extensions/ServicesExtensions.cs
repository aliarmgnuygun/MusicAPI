using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Repositories.EFCore;
using Services;
using Services.Contracts;

namespace MusicAPI.Extensions
{
    public static class ServicesExtensions
    {
        public static void ConfigureSqlContext(this IServiceCollection services,
             IConfiguration configuration) => services.AddDbContext<RepositoryContext>(opts =>
                 opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureRepositoryManager(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<ISanatciRepository, SanatciRepository>();
            services.AddScoped<IAlbumRepository, AlbumRepository>();
            services.AddScoped<ISarkiRepository, SarkiRepository>();
        }
            

        public static void ConfigureServiceManager(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<ISanatciService, SanatciManager>();
            services.AddScoped<IAlbumService, AlbumManager>();
            services.AddScoped<ISarkiService, SarkiManager>();
        }
            
            
    }
}
