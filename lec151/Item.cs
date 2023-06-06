

namespace lec151
{
    public class Item : Audit
    {
        public int ID { get; set; }
        public string? Name { get; set; }
        public float Price { get; set; }
    }
}