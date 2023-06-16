using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectEMS.Models.DB
{
    public class UserTicket
    {
        public int EventTicketId { get; set; }
        public int EventId { get; set; }
        public int UserId { get; set; }

        public int TicketTypeId { get; set; }
        public int TicketPrice { get; set; }
        public int TicketQuantity { get; set; }
    }
}