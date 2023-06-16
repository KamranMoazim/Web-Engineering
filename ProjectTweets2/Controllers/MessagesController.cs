using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ProjectTweets2.Models.DB;
using ProjectTweets2.Models.Repositories;
using ProjectTweets2.Models.ViewModel;

namespace ProjectTweets2.Controllers
{
    [Route("[controller]")]
    public class MessagesController : Controller
    {
        private readonly ILogger<MessagesController> _logger;
        private readonly UserRepsitory _userRepository;
        private readonly MessageRepository _msgRepository;
        private readonly String cookieName = "userToken";

        public MessagesController(ILogger<MessagesController> logger)
        {
            _logger = logger;
            _userRepository = new UserRepsitory();
            _msgRepository = new MessageRepository();

        }



        [HttpGet("MyMessages")]
        public IActionResult MyMessagesStart()
        {

            int userId = CheckIfLoggedIn();

            if (userId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            User user = _userRepository.getProfile(userId);

            MessagesModel messagesModel = null;


            if (user.Follower.IsNullOrEmpty())
            {
                messagesModel = new MessagesModel
                {
                    MyFriends = new List<User>(),
                    CurrentFriend = null,
                    MessagesWithCurrentFriend = new List<ChatMessage>()
                };
            }
            else
            {
                user.Followee.ForEach(x => user.Follower.Add(x));

                var uniquePersons = user.Followee.GroupBy(p => p.UserId)
                                            .Select(g => g.First())
                                            .ToList();

                messagesModel = new MessagesModel
                {
                    MyFriends = uniquePersons,
                    CurrentFriend = uniquePersons[0],
                    MessagesWithCurrentFriend = _msgRepository.GetMyFriendsMessages(userId, uniquePersons[0].UserId)
                };
            }



            return View(messagesModel);

        }


        [HttpGet("MyMessages/{friendId}")]
        public IActionResult MyMessages(int friendId = 0)
        {

            int userId = CheckIfLoggedIn();

            if (userId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            User user = _userRepository.getProfile(userId);
            User friend = _userRepository.getProfile(friendId);

            user.Followee.ForEach(x => user.Follower.Add(x));

            var uniquePersons = user.Followee.GroupBy(p => p.UserId)
                                            .Select(g => g.First())
                                            .ToList();

            MessagesModel messagesModel = new MessagesModel
            {
                MyFriends = uniquePersons,
                CurrentFriend = friend,
                MessagesWithCurrentFriend = _msgRepository.GetMyFriendsMessages(userId, friend.UserId)
            };

            Console.WriteLine(messagesModel.MessagesWithCurrentFriend.Count);

            return View(messagesModel);
        }


        [HttpGet("MyFriendsMessages/{friendId}")]
        public IActionResult MyFriendsMessages(int friendId)
        {

            int userId = CheckIfLoggedIn();

            if (userId == 0)
            {
                return RedirectToAction("Login", "Auth");
            }

            User user = _userRepository.getProfile(userId);
            User friend = _userRepository.getProfile(friendId);

            user.Followee.ForEach(x => user.Follower.Add(x));

            var uniquePersons = user.Followee.GroupBy(p => p.UserId)
                                            .Select(g => g.First())
                                            .ToList();


            MessagesModel messagesModel = new MessagesModel
            {
                MyFriends = uniquePersons,
                CurrentFriend = friend,
                MessagesWithCurrentFriend = _msgRepository.GetMyFriendsMessages(userId, friend.UserId)
            };

            return View(messagesModel);
        }


        private int CheckIfLoggedIn()
        {
            if (HttpContext.Request.Cookies.ContainsKey(cookieName))
            {
                string? cookie = HttpContext.Request.Cookies[cookieName];
                int v = int.Parse(cookie!);
                Console.WriteLine("v-cookie " + v);
                return v;
            }

            return 0;
        }

    }
}