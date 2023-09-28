using System;
using System.Reflection;
using Hub.Domain.Context;
using Microsoft.EntityFrameworkCore;

namespace Hub.API.Configuration
{
	public static class DatabaseSetup
	{

        public static IServiceCollection AddSqlDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var constring = configuration.GetConnectionString("Default");

            services.AddDbContext<ScorehubDbContext>(options =>
            {
                options.UseMySql(connectionString: constring, serverVersion: ServerVersion.AutoDetect(constring),
                    mySqlOptionsAction: sqlOptions =>
                    {
                        sqlOptions.MigrationsAssembly(typeof(ScorehubDbContext).GetTypeInfo().Assembly.GetName().Name);

                    });
            });
            return services;




        }

        }
}

