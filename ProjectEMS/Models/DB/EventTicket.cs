using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Models.DB
{
    public class EventTicket
    {
        public int TicketId { get; set; }
        public int EventId { get; set; }
        public DateTime TicketStartSale { get; set; }
        public DateTime TicketEndSale { get; set; }
        public int TicketsSold { get; set; }
        public int TicketsRemaining { get; set; }
    }
}