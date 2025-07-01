using System;
using System.Collections.Generic;

namespace BasicWebApp.Models.db
{
    public partial class Passenger
    {
        public int PassId { get; set; }

        public string PassName { get; set; } = null!;

        public virtual ICollection<Ticket> Tickets { get; set; } = new List<Ticket>();
    }
}
