

namespace homework4.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PostedBy { get; set; }
        public DateTime PostedDate { get; set; }
    }
}