using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TurtleEazyCheckout.Classes
{
    public class TicketItem
    {
        public int Number { get; private set; }
        public string Summary { get; private set; }

        public TicketItem(int ticketNumber, string ticketSummary)
        {
            this.Number = ticketNumber;
            this.Summary = ticketSummary;
        }
    }
}
