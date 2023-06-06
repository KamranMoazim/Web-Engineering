
using Microsoft.EntityFrameworkCore;

namespace lec151
{
    public class InventoryDbContext : DbContext
    {
        public InventoryDbContext()
        { }

        public InventoryDbContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<Item> Items { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Connection String");
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;");
            // optionsBuilder.UseSqlServer("Server=localhost,1433; Initial Catalog=Test2DB;");
            // optionsBuilder.UseSqlServer("Data Source = localhost,1433; Initial Catalog = NewDB;");
            // "Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;"
            base.OnConfiguring(optionsBuilder);
        }

        public override int SaveChanges()
        {

            var changeTracker = this.ChangeTracker;

            foreach (var entry in changeTracker.Entries())
            {
                if (entry.State.Equals(EntityState.Added))
                {
                    // Console.WriteLine($"entry.Entity : {entry.Entity}, entry.State {entry.State}");
                    // Console.WriteLine($"entry.CurrentValues : {entry.CurrentValues}, entry.OriginalValues {entry.OriginalValues}");
                    // Console.WriteLine($"entry.Members : {entry.Members}, entry.Context {entry.Context}");

                    foreach (var item in entry.Members)
                    {
                        // Console.WriteLine($"item.Metadata.Name : {item.Metadata.Name}, item.Metadata.ClrType {item.Metadata.ClrType}, item.CurrentValue {item.CurrentValue}");
                        if (item.Metadata.Name.Equals("CreatedAt"))
                        {
                            item.CurrentValue = DateTime.Now;
                        }
                    }

                }
                else if (entry.State.Equals(EntityState.Modified))
                {
                    foreach (var item in entry.Members)
                    {
                        if (item.Metadata.Name.Equals("ModifiedAt"))
                        {
                            item.CurrentValue = DateTime.Now;
                        }
                    }
                }
            }

            return base.SaveChanges();
        }
    }
}