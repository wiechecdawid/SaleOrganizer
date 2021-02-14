using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Application.DTOs
{
    public class PurchaseDto
    {
        public int Id { get; set; }
        public int ClothId { get; set; }
        public virtual ClothDto Cloth { get; set; }
        public string ReferenceLink { get; set; }
        public decimal Price { get; set; }
        public TradeTypeDto TradeType { get; set; }
        public DeliveryTypeDto DeliveryType { get; set; }
        public DateTime PurchaseDate { get; set; }
        public DateTime? PaymentDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
    }
}
