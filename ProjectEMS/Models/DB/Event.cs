using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Models.DB
{
    public class Event
    {
        public int EventId { get; set; }
        public string? EventName { get; set; }
        public string? EventDescription { get; set; }
        public string? EventLocation { get; set; }
        public DateTime EventDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? EventPicture { get; set; }
        public int EventCreatorId { get; set; }
        public int CategoryId { get; set; }
        public int EventCapacity { get; set; }
        public int EventDuration { get; set; }
        public int EventStatusId { get; set; }
        public int EventPrice { get; set; }
        public int EventOverAllRating { get; set; }



        // public int EventVisibilityId { get; set; }
        // public int EventReview { get; set; }
        // public int EventView { get; set; }
        // public int EventLike { get; set; }
        // public int EventDislike { get; set; }
        // public int EventShare { get; set; }
        // public int EventComment { get; set; }
    }
}