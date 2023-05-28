using System;
using System.Collections.Generic;

namespace ProjectTweet.Models.DB;

public partial class TweetUser
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;
}
