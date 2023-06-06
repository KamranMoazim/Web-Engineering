

namespace lec151
{
    public class Program
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

        static InventoryDbContext inventoryDbContext = new();

        static void Main(string[] args)
        {
            addItem();
            // updateItem();
        }

        static void addItem()
        {
            // Console.WriteLine("Enter Item Name : ");
            // string? name = Console.ReadLine();

            // Console.WriteLine("Enter Item Price : ");
            // float price = float.Parse(Console.ReadLine());

            Item item = new Item
            {
                Name = "Again NEW M.ALi",
                Price = 150.4f,
                // CreatedAt = DateTime.Now,
                CreatedBy = "ME",
                // ModifiedAt = DateTime.Now,
                // ModifiedBy = "Ali"
            };

            inventoryDbContext.Items.Add(item);



            var item2 = inventoryDbContext.Items.Find(1);

            // item2!.ModifiedAt = DateTime.Now;
            item2.ModifiedBy = "M.Ali Again";
            item2.Name = "Updated Name";
            item2.Price = 0.54f;


            inventoryDbContext.SaveChanges();
        }


        static void updateItem(int i)
        {
            // Console.WriteLine("Enter Item Name : ");
            // string? name = Console.ReadLine();

            // Console.WriteLine("Enter Item Price : ");
            // float price = float.Parse(Console.ReadLine());

            var item = inventoryDbContext.Items.Find(i);

            // item.ModifiedAt = DateTime.Now;
            item.ModifiedBy = "M.Ali Again";
            item.Name = "Updated Name";
            item.Price = 0.54f;

            inventoryDbContext.SaveChanges();
        }

    }
}