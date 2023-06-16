using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectTweets2.Models.DB;
using ProjectTweets2.Models.ViewModel;

namespace ProjectTweets2.Models.Repositories
{
    public class MessageRepository
    {
        private readonly MyTweetsDbContext _context;

        public MessageRepository()
        {
            _context = new MyTweetsDbContext();
        }

        public List<ChatMessage> GetMyFriendsMessages(int myId, int friendId)
        {
            User? Me = _context.User.Find(myId);
            User? MyFriend = _context.User.Find(friendId);


            List<Messages> messages = _context.Messages
            .Where(m => (m.From == myId && m.To == friendId) || (m.From == friendId && m.To == myId))
            .ToList();

            List<ChatMessage> chatMessages = new List<ChatMessage>();

            foreach (var msg in messages)
            {
                chatMessages.Add(
                    new ChatMessage
                    {
                        User = msg.From == myId ? Me! : MyFriend!,
                        Message = msg.msg,
                        Time = msg.Time,
                        IsSender = msg.From == myId
                    }
                );
            }

            return chatMessages;
        }
    }
}