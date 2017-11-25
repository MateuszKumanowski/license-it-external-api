using licenseItExternal.Models.DataBaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MySQL.Data.Entity.Extensions;

namespace licenseItExternal
{
    /// <summary>
    /// The entity framework context with a DataBaseContext DbSet
    /// </summary>
    public class DataBaseContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

            var configuration = builder.Build();

            string connectionString = configuration.GetConnectionString("DbConnection");

            optionsBuilder.UseMySQL(connectionString);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Application> Application { get; set; }

        public DbSet<Clients> Clients { get; set; }

        public DbSet<Licenses> Licenses { get; set; }

        public DbSet<Permissions> Permissions { get; set; }

        public DbSet<Group> Group { get; set; }
        
        public DbSet<UserGroup> UserGroup { get; set; }

        public DbSet<Logs> Logs { get; set; }
    }
}

