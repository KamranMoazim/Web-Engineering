
using Microsoft.Data.SqlClient;

namespace ProjectTweet.Models.Repositories
{
    public class UserRepsitory
    {
        private const string connectionString = @" Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;";


        private string findUserQuery = "SELECT * FROM MyDB.dbo.TweetUser WHERE Username = @Username AND Password = @Password";
        private string createUserQuery = "INSERT INTO MyDB.dbo.TweetUser (Username, Password) VALUES (@Username, @Password)";

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

    }
}