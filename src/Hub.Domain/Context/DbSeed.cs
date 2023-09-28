using System;
using Microsoft.Extensions.DependencyInjection;

namespace Hub.Domain.Context
{
    public static class DbSeed
    {
        public static async Task SeedAsync(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var db = scope.ServiceProvider.GetRequiredService<ScorehubDbContext>();

             

                await db.SaveChangesAsync();
            }
        }
    }
}
