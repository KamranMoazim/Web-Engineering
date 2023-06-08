
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Models.Repositories
{
    public class TweetRepository
    {

        private readonly MyTweetsDbContext _context;

        public TweetRepository()
        {
            _context = new MyTweetsDbContext();
        }

        public List<Tweets> GetAllTweetsOfParticularTag(string tagTitle)
        {
            // GetAllTweetsOfParticularTag
            List<Tweets> tweets = _context.Tweets.Where(t => t.Tags.Tag1 == tagTitle || t.Tags.Tag3 == tagTitle || t.Tags.Tag3 == tagTitle).ToList();

            tweets = completeTheTweetsContents(tweets);

            return tweets;
        }


        public List<Tweets> GetAllMyTweets(int userId)
        {
            List<Tweets> tweets = _context.Tweets.Where(t => t.UserId == userId).ToList();

            tweets = completeTheTweetsContents(tweets);

            return tweets;
        }


        public List<Tweets> GetTopTweets(int top)
        {
            List<Tweets> tweets = _context.Tweets.OrderByDescending(t => t.LikesCount).Take(top).ToList();

            // tweets = completeTheTweetsContents(tweets);
            foreach (var tweet in tweets)
            {
                tweet.Comments = _context.Comments.Where(c => c.TweetId == tweet.TweetId).ToList();

                tweet.Tags = _context.Tags.Where(t => t.TagsId == tweet.TagsId).FirstOrDefault()!;

                tweet.User = _context.User.Where(u => u.UserId == tweet.UserId).FirstOrDefault()!;
            }

            return tweets;
        }


        public List<Tweets> GetTweetsOfMyFriends(int userId)
        {
            List<int> myFriends = _context.UserSet.Where(u => u.UserId == userId).Select(u => u.FollwerId).ToList();

            List<Tweets> tweets = new List<Tweets>();

            _context.Tweets.OrderByDescending(t => t.PostedAt).Where(t => myFriends.Contains(t.UserId)).ToList().ForEach(t => tweets.Add(t));

            tweets = completeTheTweetsContents(tweets);

            return tweets;
        }


        public List<Tweets> GetSharedTweetsOfMyFriends(int userId)
        {
            List<int> myFriends = _context.UserSet.Where(u => u.UserId == userId).Select(u => u.FollwerId).ToList();

            List<ReTweets> reTweets = new List<ReTweets>();

            List<Tweets> tweets = new List<Tweets>();


            _context.ReTweets.OrderByDescending(t => t.PostedAt).Where(t => myFriends.Contains(t.UserId)).ToList().ForEach(t => reTweets.Add(t));

            foreach (var reTweet in reTweets)
            {
                tweets.Add(_context.Tweets.Where(t => t.TweetId == reTweet.TweetId).FirstOrDefault()!);
            }

            tweets = completeTheTweetsContents(tweets);


            return tweets;
        }


        public List<Tweets> GetRecentTweets(int count)
        {
            List<Tweets> tweets = _context.Tweets.OrderByDescending(e => e.PostedAt).Take(count).ToList();

            tweets = completeTheTweetsContents(tweets);

            // foreach (var item in tweets)
            // {
            //     tweets2.Add(item);
            //     Console.WriteLine(item.TweetId + " " + item.Title + " " + item.Content + " " + item.PostedAt + " " + item.UserId + " " + item.LikesCount + " " + item.RetweetsCount + " " + item.CommentsCount + " " + item.Tags.Tag1 + " " + item.Tags.Tag2 + " " + item.Tags.Tag3 + " " + item.User.Username + " " + item.User.Password + " " + item.User.FirstName + " " + item.User.LastName);
            // }

            return tweets;
        }


        public bool LikeTweet(int userId, int tweetId)
        {
            Tweets tweet = _context.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault()!;
            tweet.LikesCount += 1;

            TweetLikes tweetLikes = new TweetLikes();
            tweetLikes.UserId = userId;
            tweetLikes.TweetId = tweetId;
            _context.TweetLikes.Add(tweetLikes);

            _context.SaveChanges();

            return true;
        }

        public bool RemoveLikeTweet(int userId, int tweetId)
        {
            Tweets tweet = _context.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault()!;
            tweet.LikesCount -= 1;

            TweetLikes tweetLikes = _context.TweetLikes.Where(t => t.UserId == userId && t.TweetId == tweetId).FirstOrDefault()!;
            _context.TweetLikes.Remove(tweetLikes);

            _context.SaveChanges();

            return true;
        }


        public bool CreateNewTweet(Tweets tweet)
        {
            _context.Tweets.Add(tweet);
            _context.SaveChanges();
            return true;
        }

        public bool CreateNewComment(string comment, int tweetId, int userId)
        {
            Comments comments = new Comments();
            comments.Comment = comment;
            comments.PostedAt = DateTime.Now;
            comments.TweetId = tweetId;
            comments.UserId = userId;
            _context.Comments.Add(comments);

            Tweets tweet = _context.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault()!;
            tweet.CommentsCount += 1;

            _context.SaveChanges();
            return true;
        }

        public Tweets GetParticularTweet(int tweetId)
        {
            Tweets tweets = _context.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault()!;

            tweets = completeTheTweetContents(tweets);

            return tweets;
        }


        public bool DeleteTweet(int tweetId)
        {
            var tweet = _context.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault();
            _context.Tweets.Remove(tweet!);
            _context.SaveChanges();
            return true;
        }

        public bool ShareATweet(int userId, int tweetId)
        {
            ReTweets reTweet = new ReTweets();
            reTweet.UserId = userId;
            reTweet.TweetId = tweetId;
            reTweet.PostedAt = DateTime.Now;
            _context.ReTweets.Add(reTweet);

            Tweets tweet = _context.Tweets.Where(t => t.TweetId == tweetId).First();
            Console.WriteLine(tweet.TweetId + " " + tweet.Title + " " + tweet.Content + " " + tweet.PostedAt + " " + tweet.UserId + " " + tweet.LikesCount + " " + tweet.RetweetsCount + " " + tweet.CommentsCount);
            tweet.RetweetsCount += 1;


            _context.SaveChanges();

            return true;
        }























        private List<Tweets> completeTheTweetsContents(List<Tweets> tweets)
        {

            foreach (var tweet in tweets)
            {
                List<int> follwerUserSets = _context.UserSet.Where(x => x.FollwerId == tweet.UserId).Select(e => e.UserId).ToList();
                List<int> follweeUserSets = _context.UserSet.Where(x => x.UserId == tweet.UserId).Select(e => e.FollwerId).ToList();


                tweet.Comments = _context.Comments.Where(c => c.TweetId == tweet.TweetId).ToList();

                tweet.Tags = _context.Tags.Where(t => t.TagsId == tweet.TagsId).FirstOrDefault()!;

                tweet.User = _context.User.Where(u => u.UserId == tweet.UserId).FirstOrDefault()!;

                tweet.Comments = _context.Comments.Where(c => c.TweetId == tweet.TweetId).ToList();

                tweet.Tags = _context.Tags.Where(t => t.TagsId == tweet.TagsId).FirstOrDefault();

                tweet.User = _context.User.Where(u => u.UserId == tweet.UserId).FirstOrDefault();

                tweet.User.Follower = _context.User.Where(x => follwerUserSets.Contains(x.UserId)).ToList();
                tweet.User.Followee = _context.User.Where(x => follweeUserSets.Contains(x.UserId)).ToList();
            }

            return tweets;
        }

        private Tweets completeTheTweetContents(Tweets tweet)
        {

            List<int> follwerUserSets = _context.UserSet.Where(x => x.FollwerId == tweet.UserId).Select(e => e.UserId).ToList();
            List<int> follweeUserSets = _context.UserSet.Where(x => x.UserId == tweet.UserId).Select(e => e.FollwerId).ToList();


            tweet.TweetId = tweet.TweetId;
            tweet.UserId = tweet.UserId;
            tweet.CommentsCount = tweet.CommentsCount;
            tweet.LikesCount = tweet.LikesCount;
            tweet.RetweetsCount = tweet.RetweetsCount;
            tweet.Content = tweet.Content;
            tweet.PostedAt = tweet.PostedAt;
            tweet.Title = tweet.Title;


            tweet.Comments = _context.Comments.Where(c => c.TweetId == tweet.TweetId).ToList();

            tweet.Tags = _context.Tags.Where(t => t.TagsId == tweet.TagsId).FirstOrDefault();

            tweet.User = _context.User.Where(u => u.UserId == tweet.UserId).FirstOrDefault();

            tweet.User.Follower = _context.User.Where(x => follwerUserSets.Contains(x.UserId)).ToList();
            tweet.User.Followee = _context.User.Where(x => follweeUserSets.Contains(x.UserId)).ToList();


            return tweet;
        }

    }
}