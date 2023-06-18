using System;
using Hub.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Hub.API.Configuration
{
	public static class DatabaseSetup
	{
        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkNpgsql().AddDbContext<ScorehubDbContext>(options =>
            {
                options.UseNpgsql(connectionString, npgsqlOptions =>
                {
                    // options.SetPostgresVersion(new Version(ServerVersion.AutoDetect(connectionString).ToString()));
                    npgsqlOptions.MigrationsAssembly(typeof(ScorehubDbContext).Assembly.GetName().Name);
                });
            });

            return services;
        }





    }
}

