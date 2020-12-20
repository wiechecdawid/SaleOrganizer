using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Domain
{
    public class Purchase : Trade
    {
        public DateTime PurchaseDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
