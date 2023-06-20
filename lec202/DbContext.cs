using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace lec202
{
    public class MyDbContext : DbContext
    {
        // dotnet ef migrations add Init
        // dotnet ef database update
        // dotnet ef migrations remove
        // dotnet ef database update 0
        public MyDbContext()
        {
        }
        public MyDbContext(DbContextOptions<DbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Connection String");
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryDescription> CategoryDescription { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<Company> Company { get; set; }
    }
}