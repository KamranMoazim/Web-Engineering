using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec202
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyDbContext ctx = new MyDbContext();

            // write code to insert few categories to the database

            Category c1 = new Category();
            c1.Name = "Electronics";
            ctx.Category.Add(c1);

            Category c2 = new Category();
            c2.Name = "Clothing";
            ctx.Category.Add(c2);

            Category c3 = new Category();
            c3.Name = "Food";
            ctx.Category.Add(c3);



            // write code to insert few companies to the database

            Company co1 = new Company();
            co1.Name = "Apple";
            ctx.Company.Add(co1);

            Company co2 = new Company();
            co2.Name = "Samsung";
            ctx.Company.Add(co2);

            Company co3 = new Company();
            co3.Name = "LG";
            ctx.Company.Add(co3);





            // write code to insert few items to the database

            Item i1 = new Item();
            i1.Name = "iPhone 6";
            i1.Price = 600;
            i1.category = c1;
            i1.Companies = new List<Company>();
            i1.Companies.Add(co1);
            i1.Companies.Add(co2);
            ctx.Item.Add(i1);

            Item i2 = new Item();
            i2.Name = "iPhone 6s";
            i2.Price = 700;
            i2.category = c1;
            i2.Companies = new List<Company>();
            i2.Companies.Add(co1);
            i2.Companies.Add(co2);
            ctx.Item.Add(i2);

            Item i3 = new Item();
            i3.Name = "iPhone 7";
            i3.Price = 800;
            i3.category = c1;
            i3.Companies = new List<Company>();
            i3.Companies.Add(co1);
            i3.Companies.Add(co2);
            ctx.Item.Add(i3);

            Item i4 = new Item();
            i4.Name = "iPhone 7s";
            i4.Price = 900;
            i4.category = c1;
            i4.Companies = new List<Company>();
            i4.Companies.Add(co1);
            i4.Companies.Add(co2);
            ctx.Item.Add(i4);

            Item i5 = new Item();
            i5.Name = "iPhone 8";
            i5.Price = 1000;
            i5.category = c1;
            i5.Companies = new List<Company>();
            i5.Companies.Add(co1);
            i5.Companies.Add(co2);
            ctx.Item.Add(i5);




            ctx.SaveChanges();


        }
    }
}