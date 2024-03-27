using CFP.Application.Models;
using CFP.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CFP.Infrastructure
{
    public class DbContext: Microsoft.EntityFrameworkCore.DbContext
    {
        private readonly DbContextSettings _settings;

        public DbContext(DbContextSettings settings)
        {
            _settings = settings;
        }

        public DbSet<Domain.Entities.Application> Applications { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(_settings.DataBaseConnectionString);
        }
    }
}
