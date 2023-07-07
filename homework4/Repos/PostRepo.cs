
using homework4.Models;

namespace homework4.Repos
{
    public class PostRepo
    {
        private List<Post> AllPosts { get; set; } = new List<Post>
        {
            new Post
            {
                Id = 1,
                Title = "First Post",
                Body = "This is the body of the first post",
                PostedBy = "John Doe",
                PostedDate = DateTime.Now
            },
            new Post
            {
                Id = 2,
                Title = "Second Post",
                Body = "This is the body of the second post",
                PostedBy = "Jane Doe",
                PostedDate = DateTime.Now
            },
            new Post
            {
                Id = 3,
                Title = "Third Post",
                Body = "This is the body of the third post",
                PostedBy = "John Doe",
                PostedDate = DateTime.Now
            },
            new Post
            {
                Id = 4,
                Title = "Fourth Post",
                Body = "This is the body of the fourth post",
                PostedBy = "Jane Doe",
                PostedDate = DateTime.Now
            },
            new Post
            {
                Id = 5,
                Title = "Fifth Post",
                Body = "This is the body of the fifth post",
                PostedBy = "John Doe",
                PostedDate = DateTime.Now
            },
        };

        public Post GetPostById(int id)
        {
            return AllPosts.FirstOrDefault(p => p.Id == id);
        }

        public List<Post> GetAllPosts()
        {
            return AllPosts;
        }

        public void OrderList(string sort = "asc")
        {
            if (sort.Equals("asc"))
            {
                AllPosts = AllPosts.OrderBy(p => p.Id).ToList();
            }
            else if (sort.Equals("desc"))
            {
                AllPosts = AllPosts.OrderByDescending(p => p.Id).ToList();
            }
        }

    }
}