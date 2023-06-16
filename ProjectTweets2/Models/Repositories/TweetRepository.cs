
using ProjectTweets2.Models.DB;
using ProjectTweets2.Models.ViewModel;

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

            List<int> tags = _context.Tags.Where(t => t.Tag1 == tagTitle || t.Tag2 == tagTitle || t.Tag3 == tagTitle).Select(e => e.TagsId).ToList();

            List<Tweets> tweets = _context.Tweets.Where(t => tags.Contains(t.TagsId)).ToList();

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


        public List<SharedTweetModel> GetSharedTweetsOfMyFriends(int userId)
        {
            List<SharedTweetModel> sharedTweets = new List<SharedTweetModel>();


            List<int> myFriends = _context.UserSet.Where(u => u.UserId == userId).Select(u => u.FollwerId).ToList();

            List<ReTweets> reTweets = new List<ReTweets>();
            _context.ReTweets.OrderByDescending(t => t.PostedAt).Where(t => myFriends.Contains(t.UserId)).ToList().ForEach(t => reTweets.Add(t));



            foreach (var reTweet in reTweets)
            {
                Tweets tweet = completeTheTweetContents(_context.Tweets.Where(t => t.TweetId == reTweet.TweetId).FirstOrDefault()!);
                User user = _context.User.Find(reTweet.UserId)!;

                sharedTweets.Add(
                    new SharedTweetModel
                    {
                        Tweet = tweet,
                        User = user
                    }
                );
            }

            return sharedTweets;
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
            // Console.WriteLine(userId + " " + tweetId);

            Tweets tweet = _context.Tweets.Where(t => t.TweetId == tweetId).FirstOrDefault()!;

            TweetLikes tweetLikes = _context.TweetLikes.Where(t => t.UserId == userId && t.TweetId == tweetId).FirstOrDefault()!;

            if (tweetLikes == null)
            {
                tweet.LikesCount += 1;
                TweetLikes tweetLikes2 = new TweetLikes();
                tweetLikes2.UserId = userId;
                tweetLikes2.TweetId = tweetId;
                _context.TweetLikes.Add(tweetLikes2);
            }
            else
            {
                tweet.LikesCount -= 1;
                _context.TweetLikes.Remove(tweetLikes);
            }


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

            _context.Comments.RemoveRange(_context.Comments.Where(c => c.TweetId == tweetId));

            _context.TweetLikes.RemoveRange(_context.TweetLikes.Where(c => c.TweetId == tweetId));

            _context.ReTweets.RemoveRange(_context.ReTweets.Where(c => c.TweetId == tweetId));



            _context.Tweets.Remove(tweet!);

            _context.SaveChanges();
            return true;
        }

        public bool ShareATweet(int userId, int tweetId)
        {
            ReTweets? reTweets = _context.ReTweets.Where(t => t.UserId == userId && t.TweetId == tweetId).FirstOrDefault();

            Tweets tweet = _context.Tweets.Where(t => t.TweetId == tweetId).First();


            if (reTweets == null)
            {
                tweet.RetweetsCount += 1;

                ReTweets reTweet = new ReTweets();
                reTweet.UserId = userId;
                reTweet.TweetId = tweetId;
                reTweet.PostedAt = DateTime.Now;

                _context.ReTweets.Add(reTweet);

            }
            else
            {
                tweet.RetweetsCount -= 1;

                _context.ReTweets.Remove(reTweets);
            }

            _context.SaveChanges();

            return true;






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