
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Models.Repositories
{
    public class UserRepsitory
    {
        private readonly MyTweetsDbContext _context;

        public UserRepsitory()
        {
            _context = new MyTweetsDbContext();
        }


        public User getProfile(int userId)
        {
            User? tweetUser = _context.User.Where(x => x.UserId == userId).FirstOrDefault();

            if (tweetUser != null)
            {
                List<int> follwerUserSets = _context.UserSet.Where(x => x.FollwerId == userId).Select(e => e.UserId).ToList();
                List<int> follweeUserSets = _context.UserSet.Where(x => x.UserId == userId).Select(e => e.FollwerId).ToList();

                User userModel = new User
                {
                    UserId = tweetUser.UserId,
                    Username = tweetUser.Username,
                    Password = tweetUser.Password,
                    FirstName = tweetUser.FirstName,
                    LastName = tweetUser.LastName,
                    Follower = _context.User.Where(x => follwerUserSets.Contains(x.UserId)).ToList(),
                    Followee = _context.User.Where(x => follweeUserSets.Contains(x.UserId)).ToList(),
                };
                return userModel;
            };

            return null;
        }



        public User login(User user)
        {
            User userDB = new User();
            userDB.Username = user.Username;
            userDB.Password = user.Password;

            User? tweetUser = _context.User.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (tweetUser != null)
            {
                userDB = completeUserContents(tweetUser.UserId);

                return userDB;
            }

            return null;
        }


        public User register(User user)
        {
            User userDB = new User();
            userDB.Username = user.Username;
            userDB.Password = user.Password;
            userDB.FirstName = "TEST";
            userDB.LastName = "TEST";
            userDB.JoinedDate = System.DateTime.Now;
            userDB.TagLine = "TEST";

            _context.User.Add(userDB);
            _context.SaveChanges();

            User? tweetUser = _context.User.Where(x => x.Username == user.Username && x.Password == user.Password).FirstOrDefault();

            if (tweetUser != null)
            {
                userDB = completeUserContents(tweetUser.UserId);

                return userDB;
            }

            return null;
        }


        public bool updateUserProfile(User user)
        {
            // User? tweetUser = _context.User.Where(x => x.UserId == user.UserId).FirstOrDefault();
            User? tweetUser = _context.User.Find(user.UserId);

            // Console.WriteLine("tweetUser --- " + tweetUser);

            // Console.WriteLine("user.UserId --- " + user.UserId);
            // Console.WriteLine("user.FirstName --- " + user.FirstName);
            // Console.WriteLine("user.LastName --- " + user.LastName);

            if (tweetUser != null)
            {
                tweetUser.FirstName = user.FirstName;
                tweetUser.LastName = user.LastName;
                tweetUser.TagLine = user.TagLine;

                _context.SaveChanges();
            }

            return true;
        }


        public List<User> getProfilesByJoinedDate(int userId)
        {
            List<int> follwerUserSets = _context.UserSet.Where(x => x.UserId == userId).Select(e => e.FollwerId).ToList();

            List<User> users = new List<User>();

            _context.User
                .OrderByDescending(e => e.JoinedDate)
                .Where(x => !follwerUserSets.Contains(x.UserId))
                .ToList()
                .ForEach(x => users.Add(completeUserContents(x.UserId)));

            int v = users.FindIndex(x => x.UserId == userId);
            users.RemoveAt(v);

            return users;
        }

        public bool makeFollower(int UserId, int FollowedUserId)
        {
            _context.UserSet.Add(new UserSet { UserId = UserId, FollwerId = FollowedUserId });
            _context.SaveChanges();

            return true;
        }


        public bool removeFollower(int UserId, int FollowedUserId)
        {
            UserSet? userSet = _context.UserSet.Where(x => x.UserId == UserId && x.FollwerId == FollowedUserId).FirstOrDefault();

            if (userSet != null)
            {
                _context.UserSet.Remove(userSet);
                _context.SaveChanges();
            }

            return true;
        }

        public bool removeFollowee(int UserId, int FollowedUserId)
        {
            UserSet? userSet = _context.UserSet.Where(x => x.UserId == FollowedUserId && x.FollwerId == UserId).FirstOrDefault();

            if (userSet != null)
            {
                _context.UserSet.Remove(userSet);
                _context.SaveChanges();
            }

            return true;
        }














        private User completeUserContents(int userId)
        {
            User dbUser = new User();

            User? tweetUser = _context.User.Where(x => x.UserId == userId).FirstOrDefault();

            if (tweetUser == null)
            {
                return null;
            }


            List<int> follwerUserSets = _context.UserSet.Where(x => x.FollwerId == userId).Select(e => e.UserId).ToList();
            List<int> follweeUserSets = _context.UserSet.Where(x => x.UserId == userId).Select(e => e.FollwerId).ToList();


            dbUser.UserId = tweetUser.UserId;
            dbUser.Username = tweetUser.Username;
            dbUser.Password = tweetUser.Password;
            dbUser.FirstName = tweetUser.FirstName;
            dbUser.LastName = tweetUser.LastName;
            dbUser.Follower = _context.User.Where(x => follwerUserSets.Contains(x.UserId)).ToList();
            dbUser.Followee = _context.User.Where(x => follweeUserSets.Contains(x.UserId)).ToList();
            dbUser.Tweets = _context.Tweets.Where(x => x.UserId == userId).ToList();

            return dbUser;
        }


    }
}