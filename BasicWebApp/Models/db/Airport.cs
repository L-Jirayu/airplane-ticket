using System;
using System.Collections.Generic;

namespace BasicWebApp.Models.db
{
    public partial class Airport
    {
        public int AirportId { get; set; }

        public string AirportName { get; set; } = null!;

        public string AirportSignal { get; set; } = null!;

        public string Province { get; set; } = null!;

        public string FullDestination { get; set; } = null!;

        public string? Destination { get; set; }

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
