using System;
using Hub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Hub.Domain.Context
{
    public class ScorehubDbContext : DbContext
    {

        public ScorehubDbContext(DbContextOptions<ScorehubDbContext> options)
            : base(options)
        {
            
        }
        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }
        public DbSet<News> News { get; set; }


        
    }
}

