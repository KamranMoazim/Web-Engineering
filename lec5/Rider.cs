using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec5
{
    public class Rider
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public override string ToString()
        {
            return $"{Id} , {Name}";
        }



        // public bool saveRider()
        // {
        //     FileStream fOut = new FileStream("rider.txt", FileMode.Append);
        //     StreamWriter streamWriter = new StreamWriter(fOut);

        //     string data = Id + "," + Name;
        //     streamWriter.WriteLine(data);

        //     // streamWriter.WriteLine(this.ToString());

        //     streamWriter.Close();
        //     fOut.Close();

        //     return true;
        // }

        // public Rider readRider()
        // {
        //     Rider rider = new Rider();

        //     FileStream fIn = new FileStream("rider.txt", FileMode.Open);
        //     StreamReader streamReader = new StreamReader(fIn);

        //     string? data = streamReader.ReadLine();

        //     string[] parsedRider = data!.Split(",");

        //     rider.Id = Convert.ToInt32(parsedRider[0]);
        //     rider.Name = parsedRider[1];


        //     streamReader.Close();
        //     fIn.Close();

        //     return rider;
        // }


    }
}