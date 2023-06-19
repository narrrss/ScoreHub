using System;
using Hub.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Hub.API.Configuration
{
	public static class DatabaseSetup
	{
        public static IServiceCollection AddPostgresDbContext(this IServiceCollection services, string connectionString)
        {
            //var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddEntityFrameworkNpgsql().AddDbContext<ScorehubDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });

            return services;
        }





    }
}

