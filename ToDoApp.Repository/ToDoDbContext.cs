using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

using ToDoAppCommon.Items;

namespace ToDoApp.Repository
{
    public class ToDoDbContext : DbContext
    {
        public DbSet<Item> Items { get; set; }

        public string ConnectionString { get; set; }
        public ToDoDbContext(DbContextOptions<ToDoDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public ToDoDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
         
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var config = modelBuilder.Entity<Item>();
            config.ToTable("Item").HasKey(x => x.ID);
            
            modelBuilder.Entity(typeof(Item))
                        .Property("ID")
                        .UseIdentityColumn()
                        .Metadata.SetBeforeSaveBehavior(PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }
    }
}
