

namespace LocationLib
{
    public class Location
    {
        public float latitude { get; set; }
        public float longitude { get; set; }


        public bool setLocation(float longitude, float latitude)
        {
            this.longitude = longitude;
            this.latitude = latitude;

            return true;
        }


    }
}