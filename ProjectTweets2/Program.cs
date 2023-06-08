var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // when we use use session, it should be saved in Memory
builder.Services.AddSession(); // this line will add session


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession(); // it will must add after UseRouting() and before MapControllerRoute()

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();




// using ProjectTweets2.Models.DB;
// using ProjectTweets2.Models.Repositories;

// UserRepsitory userRepsitory = new UserRepsitory();
// TweetRepository tweetRepository = new TweetRepository();


// var ListOfTweets = tweetRepository.GetRecentTweets(20);
// // var TopTweets = tweetRepository.GetTopTweets(5);

// foreach (var tweet in ListOfTweets)
// {
//     // Console.WriteLine(tweet.Tags.Tag1);
//     // Console.WriteLine(tweet.Tags.Tag2);
//     // Console.WriteLine(tweet.Tags.Tag3);

//     // Console.WriteLine(tweet.User.Username + " " + tweet.User.FirstName + " " + tweet.User.LastName + " " + tweet.User.JoinedDate);
//     // Console.WriteLine(tweet.User.Username + " " + tweet.User.FirstName + " " + tweet.User.LastName + " " + tweet.User.JoinedDate + " " + tweet.User.Follower.Count + " " + tweet.User.Followee.Count);
//     Console.WriteLine(tweet.User.Username + " " + tweet.User.FirstName + " " + tweet.User.LastName + " " + tweet.User.JoinedDate + " " + tweet.User.Follower.Count + " " + tweet.User.Followee.Count + " " + tweet.Tags);
// }


// userRepsitory.register(
//     new User
//     {
//         Username = "test1",
//         Password = "test1",
//         FirstName = "f test1",
//         LastName = "l test1",

//     }
// );


// userRepsitory.register(
//     new User
//     {
//         Username = "test2",
//         Password = "test2",
//         FirstName = "f test2",
//         LastName = "l test2",

//     }
// );

// User user = userRepsitory.login(new User { Username = "test1", Password = "test1" });
// Console.WriteLine(user.UserId + " " + user.Username + " " + user.Password + " " + user.FirstName + " " + user.LastName + " " + user.Follower + " " + user.Followee);

// Console.WriteLine(userRepsitory.getProfile(1).Username);
// userRepsitory.getProfilesByJoinedDate().ForEach(x => Console.WriteLine(x.UserId + " " + x.Username + " " + x.JoinedDate));

// userRepsitory.makeFollower(1, 2);
// userRepsitory.makeFollower(1, 3);

// userRepsitory.getProfile(1).Follower.ForEach(x => Console.WriteLine(x.UserId + " " + x.Username + " " + x.JoinedDate));
// Console.WriteLine();
// userRepsitory.getProfile(1).Followee.ForEach(x => Console.WriteLine(x.UserId + " " + x.Username + " " + x.JoinedDate));









// tweetRepository.CreateNewTweet(
//     new Tweets
//     {
//         UserId = 1,
//         CommentsCount = 0,
//         LikesCount = 0,
//         RetweetsCount = 0,
//         Content = "test tweet 1 by user 1",
//         PostedAt = DateTime.Now,
//         Title = "test tweet 1 by user 1",
//         Tags = new Tags
//         {
//             Tag1 = "c++",
//             Tag2 = "c",
//             Tag3 = "java",
//         }
//     }
// );

// tweetRepository.CreateNewTweet(
//     new Tweets
//     {
//         UserId = 2,
//         CommentsCount = 0,
//         LikesCount = 0,
//         RetweetsCount = 0,
//         Content = "test tweet 1 by user 2",
//         PostedAt = DateTime.Now,
//         Title = "test tweet 1 by user 2",
//         Tags = new Tags
//         {
//             Tag1 = "js",
//             Tag2 = "ts",
//             Tag3 = "node",
//         }
//     }
// );

// tweetRepository.CreateNewTweet(
//     new Tweets
//     {
//         UserId = 3,
//         CommentsCount = 0,
//         LikesCount = 0,
//         RetweetsCount = 0,
//         Content = "test tweet 1 by user 3",
//         PostedAt = DateTime.Now,
//         Title = "test tweet 1 by user 3",
//         Tags = new Tags
//         {
//             Tag1 = "cSharp",
//             Tag2 = "dotnet",
//             Tag3 = "aspnet",
//         }
//     }
// );

// tweetRepository.ShareATweet(2, 2);

// tweetRepository.GetAllMyTweets(1).ForEach(x => Console.WriteLine(x.UserId + " " + x.Title + " " + x.Content + " " + x.PostedAt + " " + x.Tags.Tag1 + " " + x.Tags.Tag2 + " " + x.Tags.Tag3));

// tweetRepository.GetTweetsOfMyFriends(1).ForEach(x => Console.WriteLine(x.UserId + " " + x.Title + " " + x.Content + " " + x.PostedAt + " " + x.Tags.Tag1 + " " + x.Tags.Tag2 + " " + x.Tags.Tag3));

// tweetRepository.GetSharedTweetsOfMyFriends(1).ForEach(x => Console.WriteLine(x.UserId + " " + x.Title + " " + x.Content + " " + x.PostedAt + " " + x.Tags.Tag1 + " " + x.Tags.Tag2 + " " + x.Tags.Tag3));

// userRepsitory.removeFollower(1, 2);

// Console.WriteLine("Hello World!");