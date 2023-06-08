
using Microsoft.EntityFrameworkCore;

namespace ProjectTweet.Models.DB;

public partial class MyDbContext : DbContext
{
    // dotnet ef migrations add Init
    // dotnet ef database update
    // dotnet ef migrations remove
    // dotnet ef database update 0
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // optionsBuilder.UseSqlServer("Connection String");
        optionsBuilder.UseSqlServer("Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TweetUser>()
            .HasMany(e => e.Followee)
            .WithMany(e => e.Follower)
            .UsingEntity<TweetUserSet>(
                e => e.HasOne<TweetUser>().WithMany().HasForeignKey(e => e.UserId),
                e => e.HasOne<TweetUser>().WithMany().HasForeignKey(e => e.FollwerId));
    }

    public virtual DbSet<TweetUser> TweetUsers { get; set; }
    public virtual DbSet<CommentModel> CommentModel { get; set; }
    public virtual DbSet<TweetModel> TweetModel { get; set; }

    // public virtual DbSet<TestCalss> TestCalss { get; set; }




}
