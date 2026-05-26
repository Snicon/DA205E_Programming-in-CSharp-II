using EntityFrameworkCoreCrashCourse.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkCoreCrashCourse.Data
{
    // Note to self: p.524 in C# 12 and .NET 8 Modern Cross-Platform Development Fundamentals. + https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-model
    public class TankAppContext : DbContext
    {
        private DbSet<Commander>? commanders;
        private DbSet<Tank>? tanks;

        private string dbPath;

        public string DbPath 
        {
            get {  return dbPath; }
        }

        public DbSet<Commander>? Commanders
        {
            get { return commanders; }
            set { commanders = value; }
        }

        public DbSet<Tank>? Tanks
        {
            get { return tanks; }
            set { tanks = value; }
        }

        public TankAppContext()
        {
            var folder = Environment.SpecialFolder.LocalApplicationData;
            var path = Environment.GetFolderPath(folder);
            dbPath = System.IO.Path.Join(path, "TankApp.db");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}
