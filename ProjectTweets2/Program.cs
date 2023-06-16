using ProjectTweets2.MyHub;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddSignalR(); // out signalR has added as service


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


app.MapHub<MyHub>("/chatHub"); // we will access with chatHub at client side



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();



// kamran@kamran.com

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







