using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec5
{
    public class RiderManager
    {
        public bool saveRider(Rider rider)
        {
            FileStream fOut = new FileStream("rider.txt", FileMode.Append);
            StreamWriter streamWriter = new StreamWriter(fOut);

            // string data = rider.Id + "," + rider.Name;
            streamWriter.WriteLine(rider.ToString());

            // streamWriter.WriteLine(this.ToString());

            streamWriter.Close();
            fOut.Close();

            return true;
        }

        public Rider readRider()
        {
            Rider rider = new Rider();

            FileStream fIn = new FileStream("rider.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fIn);

            string? data = streamReader.ReadLine();

            string[] parsedRider = data!.Split(",");

            rider.Id = Convert.ToInt32(parsedRider[0]);
            rider.Name = parsedRider[1];


            streamReader.Close();
            fIn.Close();

            return rider;
        }

        public List<Rider> GetAllRider()
        {
            List<Rider> ridersList = new List<Rider>();

            FileStream fIn = new FileStream("rider.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fIn);

            string? data = streamReader.ReadLine();
            while (data != null)
            {
                string[] parsedRider = data!.Split(",");

                int Id = Convert.ToInt32(parsedRider[0]);
                string Name = parsedRider[1];

                Rider rider = new Rider { Id = Id, Name = Name };
                ridersList.Add(rider);

                data = streamReader.ReadLine();
            }




            streamReader.Close();
            fIn.Close();

            return ridersList;
        }


        public List<Rider> GetAllRider(string name)
        {
            List<Rider> ridersList = new List<Rider>();

            FileStream fIn = new FileStream("rider.txt", FileMode.Open);
            StreamReader streamReader = new StreamReader(fIn);

            string? data = streamReader.ReadLine();
            while (data != null)
            {
                string[] parsedRider = data!.Split(",");

                int Id = Convert.ToInt32(parsedRider[0]);
                string Name = parsedRider[1];

                if (Name == name)
                {
                    Rider rider = new Rider { Id = Id, Name = Name };
                    ridersList.Add(rider);
                }

                data = streamReader.ReadLine();
            }


            streamReader.Close();
            fIn.Close();

            return ridersList;
        }
    }
}