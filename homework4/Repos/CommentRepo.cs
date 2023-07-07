

using homework4.Models;

namespace homework4.Repos
{
    public class CommentRepo
    {
        public List<Comment> AllComments { get; set; } = new List<Comment>
        {
            new Comment
            {
                Id = 1,
                Content = "This is a comment",
                PostId = 1
            },
            new Comment
            {
                Id = 2,
                Content = "This is another comment",
                PostId = 1
            },
            new Comment
            {
                Id = 3,
                Content = "This is a third comment",
                PostId = 2
            },
            new Comment
            {
                Id = 4,
                Content = "This is a fourth comment",
                PostId = 2
            },
            new Comment
            {
                Id = 5,
                Content = "This is a fifth comment",
                PostId = 3
            },
            new Comment
            {
                Id = 6,
                Content = "This is a sixth comment",
                PostId = 3
            },
            new Comment
            {
                Id = 7,
                Content = "This is a seventh comment",
                PostId = 4
            },
            new Comment
            {
                Id = 8,
                Content = "This is an eighth comment",
                PostId = 4
            },
            new Comment
            {
                Id = 9,
                Content = "This is a ninth comment",
                PostId = 5
            },
            new Comment
            {
                Id = 10,
                Content = "This is a tenth comment",
                PostId = 5
            },
        };

        public List<Comment> GetCommentsByPostId(int postId)
        {
            return AllComments.Where(comment => comment.PostId == postId).ToList();
        }
    }
}