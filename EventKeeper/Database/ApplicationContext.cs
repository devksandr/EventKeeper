using EventKeeper.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventKeeper.Database
{
    public class ApplicationContext : DbContext
    {
        private const string DB_NAME = "eventKeeper.db";
        private const string DB_FOLDER = "Database";
        private const string DB_PATH = $"{DB_FOLDER}/{DB_NAME}";

        public DbSet<Event> Events { get; set; } = null!;

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!Directory.Exists(DB_FOLDER))
            {
                Directory.CreateDirectory(DB_FOLDER);
            }
            optionsBuilder.UseSqlite($"Data Source={DB_PATH}");
        }
    }
}