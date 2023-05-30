using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec14
{
    public class Program
    {
        static void Main(string[] args)
        {

            // dotnet ef dbcontext scaffold "Server=localhost,1433; Database=MyDB; User Id=SA; Password=Password_01; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir ./Models/DB -t TweetUser language -f
            // dotnet ef dbcontext scaffold "Server=localhost,1433; Database=TestDB; User Id=TestUser; Password=123; TrustServerCertificate=true;" Microsoft.EntityFrameworkCore.SqlServer --output-dir ./Models

            // ** Add-Migration MigrationNameHere
            // it will change DB according to our Code
            //      - UP    - contains creations code
            //      - DOWN  - contains removal code
            // ** Update-Database


            // dotnet ef migrations add MigrationNameHere
            // dotnet ef database update


            Console.WriteLine("hello");
        }
    }
}
