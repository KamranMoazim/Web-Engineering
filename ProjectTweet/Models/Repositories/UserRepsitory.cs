
using Microsoft.Data.SqlClient;
using ProjectTweet.Models.DB;

namespace ProjectTweet.Models.Repositories
{
    public class UserRepsitory
    {
        private const string connectionString = @" Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;";

        // dotnet ef dbcontext scaffold "Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir ./Models/DB -t TweetUser language -f

        // dotnet ef migrations add MigrationNameHere 
        // dotnet ef database update

        private readonly MyDbContext context;

        public UserRepsitory()
        {
            context = new MyDbContext();
        }

        public UserModel getProfile(int userId)
        {
            TweetUser? tweetUser = context.TweetUsers.Where(x => x.UserId == userId).FirstOrDefault();

            if (tweetUser != null)
            {
                UserModel userModel = new UserModel
                {
                    UserId = tweetUser.UserId,
                    Username = tweetUser.Username,
                    Password = tweetUser.Password,
                    FirstName = "test",
                    LastName = "test",
                    Follower = new List<FollowUserModel>(){
                    new FollowUserModel(){
                        UserId = 2,
                        Username = "test2",
                        FirstName = "test2",
                    },
                    new FollowUserModel(){
                        UserId = 3,
                        Username = "test3",
                        FirstName = "test3",
                    },
                },
                    Followee = new List<FollowUserModel>(){
                    new FollowUserModel(){
                        UserId = 4,
                        Username = "test4",
                        FirstName = "test4",
                    },
                    new FollowUserModel(){
                        UserId = 5,
                        Username = "test5",
                        FirstName = "test5",
                    },
                }
                };

                return userModel;
            }



            return null;
        }

        public UserModel login(UserModel user)
        {
            TweetUser userDB = new TweetUser();
            userDB.Username = user.Username;
            userDB.Password = user.Password;

            TweetUser? tweetUser = context.TweetUsers.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (tweetUser != null)
            {
                user.UserId = tweetUser.UserId;
                user.Username = tweetUser.Username;
                user.Password = tweetUser.Password;

                user.FirstName = "first name";
                user.LastName = "last name";
                user.Followee = new List<FollowUserModel>();
                user.Follower = new List<FollowUserModel>();

                return user;
            }

            return null;
        }

        public UserModel register(UserModel user)
        {
            TweetUser userDB = new TweetUser();
            userDB.Username = user.Username;
            userDB.Password = user.Password;

            context.TweetUsers.Add(userDB);

            context.SaveChanges();

            TweetUser? tweetUser = context.TweetUsers.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (tweetUser != null)
            {
                user.UserId = tweetUser.UserId;
                user.Username = tweetUser.Username;
                user.Password = tweetUser.Password;

                user.FirstName = "first name";
                user.LastName = "last name";
                user.Followee = new List<FollowUserModel>();
                user.Follower = new List<FollowUserModel>();

                return user;
            }

            return null;
        }

        public bool updateUserProfile(UserModel user)
        {
            return true;
        }

        public bool removeFollwerOrFollowee(int UserId, int FollowedUserId)
        {
            return true;
        }

        public List<ProfileModel> getProfilesByJoinedDate()
        {
            return null;
        }

        public bool makeFollower(int UserId, int FollowedUserId)
        {
            return true;
        }

    }
}