
using Microsoft.Data.SqlClient;

namespace ProjectTweet.Models.Repositories
{
    public class TweetRepsitory
    {

        private const string connectionString = @" Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;";

        public List<TweetModel> GetAllTweetsOfParticularTag(string tagTitle)
        {
            return null;

        }


        public List<TweetModel> GetAllMyTweets(int userId)
        {
            return null;

        }


        public List<TweetModel> GetTopTweets()
        {
            return null;

        }


        public List<TweetModel> GetTop5Tweets()
        {
            return null;

        }

        public bool CreateNewTweet(TweetModel tweet)
        {
            return false;
        }

        public bool CreateNewComment(CommentModel comment)
        {
            return false;

        }

        public TweetModel GetParticularTweet(int tweetId)
        {
            return new TweetModel
            {

            };

        }


        public bool DeleteTweet(int tweetId)
        {
            return false;
        }

        public bool UpdateTweet(TweetModel tweet)
        {
            return false;
        }


    }
}