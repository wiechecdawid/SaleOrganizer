using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Domain
{
    public class Offering : Trade
    {
        public DateTime OfferingDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? SendDate { get; set; }
    }
}
