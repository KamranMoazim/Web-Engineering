using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using lec13.Models;

namespace lec13
{


    // IF OBJECT_ID('DatabaseName.dbo.Profile', 'U') IS NOT NULL
    // DROP TABLE DatabaseName.dbo.Profile;
    // GO
    // -- Create the table in the specified schema
    // CREATE TABLE DatabaseName.dbo.Profile
    // (
    //     ProfileId INT IDENTITY(1,1) PRIMARY KEY, -- primary key column
    //     Firstname [NVARCHAR](50) NOT NULL,
    //     Lastname [NVARCHAR](50) NOT NULL,
    //     TagLine [NVARCHAR](100) NOT NULL,
    //     Birthdate [DATETIME] NOT NULL,
    //     JoinedDate [DATETIME] NOT NULL DEFAULT GETDATE(),
    // );
    // GO


    // USE master ;  
    // GO  
    // DROP DATABASE DatabaseName;  
    // GO  

    // USE master;
    // GO
    // CREATE DATABASE TestDB
    // GO
    // USE TestDB
    // CREATE LOGIN TestUser WITH PASSWORD = '123', CHECK_POLICY = OFF;
    // CREATE USER TestUser FOR LOGIN TestUser;
    // EXEC sp_addrolemember N'db_owner', N'TestUser';
    // GO



    public class Program
    {
        // dotnet ef dbcontext scaffold "Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir ./Models/DB -t TweetUser language -f
        // dotnet ef dbcontext scaffold "Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir ./Models

        static void Main(string[] args)
        {
            TestDbContext db = new TestDbContext();

            // db.Profiles.Add(new Profile
            // {
            //     Firstname = "John",
            //     Lastname = "Doe",
            //     TagLine = "Hello World",
            //     Birthdate = DateTime.Now,
            //     JoinedDate = DateTime.Now
            // });

            // db.Profiles.Add(new Profile
            // {
            //     Firstname = "John2",
            //     Lastname = "Doe2",
            //     TagLine = "Hello World2",
            //     Birthdate = DateTime.Now,
            //     JoinedDate = DateTime.Now
            // });

            // db.SaveChanges();




            // var profiles = db.Profiles.ToList();
            // foreach (var profile in profiles)
            // {
            //     Console.WriteLine(profile.Firstname + " " + profile.Lastname);
            // }

            // Console.WriteLine("ReterievedRecords");




            // var profile = db.Profiles.First();
            // profile.TagLine = "this is my new TagLine";
            // db.SaveChanges();

            // Console.WriteLine("UpdatedRecords");





            // var profile = db.Profiles.Find(2);
            // db.Profiles.Remove(profile!);
            // db.SaveChanges();

            // Console.WriteLine("DeletedRecords");





            // IQueryable<Profile> profiles = db.Profiles.Where(p => p.Firstname == "John");
            // foreach (var profile in profiles)
            // {
            //     Console.WriteLine(profile.Firstname + " " + profile.Lastname);
            // }

        }

    }

}