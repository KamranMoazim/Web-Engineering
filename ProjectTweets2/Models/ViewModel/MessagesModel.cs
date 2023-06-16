
using ProjectTweets2.Models.DB;

namespace ProjectTweets2.Models.ViewModel
{
    public class MessagesModel
    {
        public List<User> MyFriends { get; set; }
        public User CurrentFriend { get; set; }
        public List<ChatMessage> MessagesWithCurrentFriend { get; set; }
    }
}