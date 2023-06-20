
using Microsoft.EntityFrameworkCore;

namespace ProjectTweets2.Models.DB
{
    public class MyTweetsDbContext : DbContext
    {

        // dotnet ef migrations add Init
        // dotnet ef database update
        // dotnet ef migrations remove
        // dotnet ef database update 0
        public MyTweetsDbContext()
        {
        }

        public MyTweetsDbContext(DbContextOptions<MyTweetsDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer("Connection String");
            optionsBuilder.UseSqlServer("Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;");
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Tweets> Tweets { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<Tags> Tags { get; set; }
        public DbSet<TweetLikes> TweetLikes { get; set; }
        public DbSet<ReTweets> ReTweets { get; set; }
        public DbSet<UserSet> UserSet { get; set; }
        public DbSet<Messages> Messages { get; set; }
        public DbSet<GroupName> GroupName { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tweets>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.Tweets)
                .HasForeignKey(e => e.TweetId)
                .IsRequired(false);



            modelBuilder.Entity<User>()
                .HasMany(e => e.Comments)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Tweets)
                .WithOne(e => e.User)
                .HasForeignKey(e => e.UserId)
                .IsRequired(false);




            // modelBuilder.Entity<User>()
            //     .HasMany(e => e.LikedTweets)
            //     .WithMany(e => e.UserLikes)
            //     .UsingEntity<TweetLikes>();
            modelBuilder.Entity<TweetLikes>()
                .HasKey(sc => new { sc.TweetId, sc.UserId });
            // .OnDelete(DeleteBehavior.Cascade);

            // modelBuilder.Entity<User>()
            //     .HasMany(e => e.UserReTweets)
            //     .WithMany(e => e.TweetReTweets)
            //     .UsingEntity<ReTweets>();
            modelBuilder.Entity<ReTweets>()
                .HasKey(sc => new { sc.TweetId, sc.UserId });

            // modelBuilder.Entity<ReTweets>()
            //     .HasOne<Student>(sc => sc.Student)
            //     .WithMany(s => s.ReTweets)
            //     .HasForeignKey(sc => sc.SId);


            // modelBuilder.Entity<ReTweets>()
            //     .HasOne<Course>(sc => sc.Course)
            //     .WithMany(s => s.ReTweets)
            //     .HasForeignKey(sc => sc.CId);


            modelBuilder.Entity<User>()
                .HasMany(e => e.Follower)
                .WithMany(e => e.Followee)
                .UsingEntity<UserSet>();

        }


        public override int SaveChanges()
        {
            var changeTracker = this.ChangeTracker;

            foreach (var entry in changeTracker.Entries())
            {
                if (entry.State.Equals(EntityState.Added))
                {
                    foreach (var item in entry.Members)
                    {
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
                        if (item.Metadata.Name.Equals("UpdatedAt"))
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