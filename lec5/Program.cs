
using System.IO;


namespace lec5
{
    public class Program
    {
        static void Main(string[] args)
        {
            // * charater base streams

            // ! with file access 
            // FileStream fOut = new FileStream("myText.txt", FileMode.Create, FileAccess.ReadWrite);


            // FileStream fOut = new FileStream("myText.txt", FileMode.Create);
            // StreamWriter sw = new StreamWriter(fOut);

            // sw.WriteLine("This is my Data.");

            // sw.Close();
            // fOut.Close();





            // FileStream fIn = new FileStream("myText.txt", FileMode.Open);
            // StreamReader sr = new StreamReader(fIn);

            // string? data = sr.ReadLine();
            // Console.WriteLine(data);

            // sr.Close();
            // fIn.Close();





            // FileStream fIn = new FileStream("myText.txt", FileMode.Open);
            // StreamReader sr = new StreamReader(fIn);

            // string? data = sr.ReadLine();
            // while (data != null)
            // {
            //     Console.WriteLine(data);
            //     data = sr.ReadLine();
            // }

            // sr.Close();
            // fIn.Close();


            // StreamReader sr = new StreamReader("myText.txt");
            StreamWriter sr = new StreamWriter("myText.txt", append: true);




            Rider rider = new Rider { Id = 2, Name = "Zaeem" };
            // rider.saveRider();
            // Rider rider2 = rider.readRider();
            // Console.WriteLine(rider2);
        }
    }
}