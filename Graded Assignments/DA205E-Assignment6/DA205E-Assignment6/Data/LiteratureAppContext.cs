using DA205E_Assignment6.Models;
using Microsoft.EntityFrameworkCore;
using System.IO;

namespace DA205E_Assignment6.Data
{
    /// <summary>
    /// This class serves as the database context class for the application. It is used to "communicate"/query the database in the C# code.
    /// Note to self: p.524 in C# 12 and .NET 8 Modern Cross-Platform Development Fundamentals (8th edition) by Mark J. Price. + https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app?tabs=netcore-cli#create-the-model
    /// </summary>
    public class LiteratureAppContext : DbContext
    {
        #region Fields
        private string dbPath; // Database path, used to determine where the SQLite .db-file is stored
        #endregion

        #region Auto properties for convenience, most sources implement the Context class like this
        // These DBSets are used to to query and save instances of application entities (p.864, Pro C# 10 with .NET 6 by Andrew Troelsen & Phil Japikse).
        public DbSet<Literature> Literatures { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<JournalArticle> JournalArticles { get; set; }
        public DbSet<Course> Courses { get; set; }
        #endregion

        #region Properties
        public string DbPath
        {
            get { return dbPath; }
        }
        #endregion

        #region Constructor
        public LiteratureAppContext()
        {
            string path = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"..\..\..")); // Very hacky way to get the database file to be stored among the code instead of instead of the bin/Debug/net10.0-windows folder when running from Visual Studio... 
            dbPath = System.IO.Path.Join(path, "literature.db");
        }
        #endregion

        #region Methods
        /// <summary>
        /// Overridden OnConfiguring method that configures EF Core to use an SQLite database at the specified source
        /// </summary>
        /// <param name="optionsBuilder">Object used to configure the database context.</param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
        #endregion
    }
}
