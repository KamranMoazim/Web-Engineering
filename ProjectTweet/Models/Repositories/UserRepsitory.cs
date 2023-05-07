
using Microsoft.Data.SqlClient;

namespace ProjectTweet.Models.Repositories
{
    public class UserRepsitory
    {
        private const string connectionString = @" Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;";


        private string findUserQuery = "SELECT UserId, Username, Password FROM MyDB.dbo.TweetUser WHERE Username = @Username AND Password = @Password";
        private string createUserQuery = "INSERT INTO MyDB.dbo.TweetUser (Username, Password) VALUES (@Username, @Password)";
        private string updateUserProfileQuery = "UPDATE MyDB.dbo.TweetUser SET FirstName = @FirstName, LastName = @LastName WHERE UserId = @UserId";
        private string removeFollwerOrFolloweeQuery = "DELETE FROM MyDB.dbo.TweetFollow WHERE UserId = @UserId AND FollowedUserId = @FollowedUserId";
        private string findUserQueryById = "SELECT * FROM MyDB.dbo.TweetUser WHERE UserId = @UserId";
        private string findProfileByJoinedDateDesc = "SELECT ProfileId, Firstname, Lastname, TagLine, JoinedDate FROM MyDB.dbo.TweetProfile ORDER BY JoinedDate DESC";
        private string createFollower = "INSERT INTO MyDB.dbo.TweetFollow (UserId, FollowedUserId) VALUES (@UserId, @FollowedUserId)";

        public UserModel login(UserModel user)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(findUserQuery, connection);

            connection.Open();

            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);

            var reader = command.ExecuteReader();

            if (reader.Read())
            {
                return new UserModel
                {
                    UserId = reader.GetInt32(0),
                    Username = reader.GetString(1),
                    Password = reader.GetString(2)
                };
            }
            else
            {
                return null;
            }
        }

        public UserModel register(UserModel user)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(createUserQuery, connection);
            connection.Open();
            command.Parameters.AddWithValue("@Username", user.Username);
            command.Parameters.AddWithValue("@Password", user.Password);
            command.ExecuteNonQuery();
            return user;
        }

        public bool updateUserProfile(UserModel user)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(updateUserProfileQuery, connection);
            connection.Open();
            command.Parameters.AddWithValue("@UserId", user.UserId);
            command.Parameters.AddWithValue("@FirstName", user.FirstName);
            command.Parameters.AddWithValue("@LastName", user.LastName);
            command.ExecuteNonQuery();
            return true;
        }

        public bool removeFollwerOrFollowee(int UserId, int FollowedUserId)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(removeFollwerOrFolloweeQuery, connection);
            connection.Open();
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@FollowedUserId", FollowedUserId);
            command.ExecuteNonQuery();
            return true;
        }

        public List<ProfileModel> getProfilesByJoinedDate()
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(findProfileByJoinedDateDesc, connection);
            connection.Open();
            var reader = command.ExecuteReader();
            var profiles = new List<ProfileModel>();
            while (reader.Read())
            {
                var profile = new ProfileModel
                {
                    ProfileId = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    TagLine = reader.GetString(3),
                    JoinedDate = reader.GetDateTime(4)
                };
                profiles.Add(profile);
            }
            return profiles;
        }

        public bool makeFollower(int UserId, int FollowedUserId)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(createFollower, connection);
            connection.Open();
            command.Parameters.AddWithValue("@UserId", UserId);
            command.Parameters.AddWithValue("@FollowedUserId", FollowedUserId);
            command.ExecuteNonQuery();
            return true;
        }

    }
}