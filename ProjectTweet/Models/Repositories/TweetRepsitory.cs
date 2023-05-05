
using Microsoft.Data.SqlClient;

namespace ProjectTweet.Models.Repositories
{
    public class TweetRepsitory
    {

        private const string connectionString = @" Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;";


        string createNewTweet = @"INSERT INTO Tweet (Title, Content, PostedDate, UserId) VALUES (@Title, @Content, @PostedDate, @UserId)";
        string deleteParticularTweet = @"DELETE FROM Tweet WHERE TweetId = @TweetId";
        string updateParticularTweet = @"UPDATE Tweet SET Title = @Title, Content = @Content WHERE TweetId = @TweetId";


        string queryParticularTweet = @"SELECT * FROM Tweet WHERE TweetId = @TweetId";
        string getAllTagsOfParticularTweet = @"SELECT * FROM TweetTags WHERE TweetId = @TweetId";
        // string getAllCommentsOfParticularTweet = @"SELECT * FROM Comment WHERE TweetId = @TweetId";
        // string findUserQuery = "SELECT Username FROM MyDB.dbo.TweetUser WHERE UserId = @UserId";
        string queryAllCommentsOfParticularTweetAlongWithUser = @"SELECT * FROM Comment INNER JOIN TweetUser ON Comment.UserId = TweetUser.UserId WHERE Comment.TweetId = @TweetId";


        string queryTweetsOfParticularTag = @"SELECT * FROM TweetTags INNER JOIN Tweet ON TweetTags.TweetId = Tweet.TweetId WHERE TweetTags.Tag = @Tag";


        string queryTop50Tweets = @"SELECT TOP 50 * FROM Tweet ORDER BY PostedDate DESC";
        string queryTop5TweetsWhichHasMostComments = @"SELECT TOP 5 * FROM Tweet ORDER BY (SELECT COUNT(*) FROM Comment WHERE Comment.TweetId = Tweet.TweetId) DESC";


        string queryAllTweetsOfParticularUser = @"SELECT * FROM Tweet WHERE UserId = @UserId";

        string createNewComment = @"INSERT INTO Comment (TweetId, UserId, Comment, PostedDate) VALUES (@TweetId, @UserId, @Comment, @PostedDate)";


        public List<TweetModel> GetAllTweetsOfParticularTag(string tagTitle)
        {
            var connection = new SqlConnection(connectionString);
            var command1 = new SqlCommand(queryTweetsOfParticularTag, connection);
            connection.Open();

            command1.Parameters.AddWithValue("@Tag", tagTitle);

            SqlDataReader sqlDataReader1 = command1.ExecuteReader();


            if (sqlDataReader1.Read())
            {
                return null;
            }
            else
            {
                return null;
            }

        }


        public List<TweetModel> GetAllMyTweets(int userId)
        {
            var connection = new SqlConnection(connectionString);
            var command1 = new SqlCommand(queryAllTweetsOfParticularUser, connection);
            connection.Open();

            command1.Parameters.AddWithValue("@UserId", userId);

            SqlDataReader sqlDataReader1 = command1.ExecuteReader();


            if (sqlDataReader1.Read())
            {
                return null;
            }
            else
            {
                return null;
            }

        }


        public List<TweetModel> GetTopTweets()
        {
            var connection = new SqlConnection(connectionString);
            var command1 = new SqlCommand(queryTop50Tweets, connection);
            connection.Open();

            SqlDataReader sqlDataReader1 = command1.ExecuteReader();


            if (sqlDataReader1.Read())
            {
                return null;
            }
            else
            {
                return null;
            }

        }


        public List<TweetModel> GetTop5Tweets()
        {
            var connection = new SqlConnection(connectionString);
            var command1 = new SqlCommand(queryTop5TweetsWhichHasMostComments, connection);
            connection.Open();

            SqlDataReader sqlDataReader1 = command1.ExecuteReader();


            if (sqlDataReader1.Read())
            {
                return null;
            }
            else
            {
                return null;
            }

        }

        public bool CreateNewTweet(TweetModel tweet)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(createNewTweet, connection);

            connection.Open();

            command.Parameters.AddWithValue("@Title", tweet.Title);
            command.Parameters.AddWithValue("@Content", tweet.Content);
            command.Parameters.AddWithValue("@PostedDate", DateTime.Now);
            command.Parameters.AddWithValue("@UserId", tweet.User.UserId);

            var effectedRows = command.ExecuteNonQuery();

            if (effectedRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool CreateNewComment(CommentModel comment)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(createNewComment, connection);

            connection.Open();

            command.Parameters.AddWithValue("@TweetId", comment.TweetId);
            command.Parameters.AddWithValue("@UserId", comment.UserId);
            command.Parameters.AddWithValue("@Comment", comment.Comment);
            command.Parameters.AddWithValue("@PostedDate", DateTime.Now);

            var effectedRows = command.ExecuteNonQuery();

            if (effectedRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public TweetModel GetParticularTweet(int tweetId)
        {
            var connection = new SqlConnection(connectionString);
            var command1 = new SqlCommand(queryParticularTweet, connection);
            var command2 = new SqlCommand(getAllTagsOfParticularTweet, connection);
            // var command3 = new SqlCommand(getAllCommentsOfParticularTweet, connection);
            // var command4 = new SqlCommand(findUserQuery, connection);

            connection.Open();

            command1.Parameters.AddWithValue("@TweetId", tweetId);
            command2.Parameters.AddWithValue("@TweetId", tweetId);
            // command3.Parameters.AddWithValue("@TweetId", tweetId);


            SqlDataReader sqlDataReader1 = command1.ExecuteReader();


            if (sqlDataReader1.Read())
            {
                SqlDataReader sqlDataReader2 = command2.ExecuteReader();
                // SqlDataReader sqlDataReader3 = command3.ExecuteReader();

                // command4.Parameters.AddWithValue("@UserId", tweetId);

                return new TweetModel
                {

                };
            }
            else
            {
                return null;
            }

        }


        public bool DeleteTweet(int tweetId)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(deleteParticularTweet, connection);

            connection.Open();

            command.Parameters.AddWithValue("@TweetId", tweetId);

            var effectedRows = command.ExecuteNonQuery();

            if (effectedRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UpdateTweet(TweetModel tweet)
        {
            var connection = new SqlConnection(connectionString);
            var command = new SqlCommand(updateParticularTweet, connection);

            connection.Open();

            command.Parameters.AddWithValue("@Title", tweet.Title);
            command.Parameters.AddWithValue("@Content", tweet.Content);
            command.Parameters.AddWithValue("@TweetId", tweet.Id);

            var effectedRows = command.ExecuteNonQuery();

            if (effectedRows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


    }
}