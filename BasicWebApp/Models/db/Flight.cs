using System;
using System.Collections.Generic;

namespace BasicWebApp.Models.db
{
    public partial class Flight
    {
        public int FlightId { get; set; }

        public string FlightNumber { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
