
using System.ComponentModel.DataAnnotations;

namespace ProjectTweet.Models.DB;

public partial class TweetUser
{
    [Key]
    public int UserId { get; set; }

    public string Username { get; set; } = null!;
    public string Password { get; set; } = null!;


    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string TagLine { get; set; }
    public DateTime JoinedDate { get; set; }

    public ICollection<TweetUser> Follower { get; set; }
    public ICollection<TweetUser> Followee { get; set; }
}
