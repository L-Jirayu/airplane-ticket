using System;
using System.Collections.Generic;

namespace BasicWebApp.Models.db
{
    public partial class Ticket
    {
        public int TicketId { get; set; }

        public int? AirportId { get; set; }

        public int? FlightId { get; set; }

        public int? PassId { get; set; }

        public DateTime? DepartDate { get; set; }

        public DateTime? Boarding { get; set; }

        public string? SeatNumber { get; set; }

        public string? Gate { get; set; }

        public string? Zone { get; set; }

        public string? Seq { get; set; }

        public virtual Airport? Airport { get; set; }

        public virtual Flight? Flight { get; set; }

        public virtual Passenger? Pass { get; set; }
    }
}
