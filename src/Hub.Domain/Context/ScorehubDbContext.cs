using System;
using Hub.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Hub.Domain.Context
{
    public class ScorehubDbContext : DbContext
    {
        private readonly IConfiguration _configuration;
        public ScorehubDbContext(DbContextOptions<ScorehubDbContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }
        public ScorehubDbContext()
        {

        }
        
        public DbSet<Team> Teams { get; set; }

        public DbSet<Player> Players { get; set; }
        public DbSet<TeamPlayer> TeamPlayers { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseNpgsql(_configuration.GetConnectionString("DefaultConnection"));
        //}
    }
}

