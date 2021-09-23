using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Application.DTOs
{
    public class OfferingDto
    {
        public string Id { get; set; }
        public string ClothId { get; set; }
        public virtual ClothDto Cloth { get; set; }
        public string ReferenceLink { get; set; }
        public decimal Price { get; set; }
        public TradeTypeDto TradeType { get; set; }
        public DeliveryTypeDto DeliveryType { get; set; }
        public DateTime OfferingDate { get; set; }
        public DateTime? OrderedDate { get; set; }
        public DateTime? SendDate { get; set; }
    }

    public enum TradeTypeDto
    {
        allegro,
        vinted
    }

    public enum DeliveryTypeDto
    {
        inpost,
        ruchPackage,
        polishPost
    }
}
