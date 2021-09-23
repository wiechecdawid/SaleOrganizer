using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Domain
{
    public class Trade
    {
        public string Id { get; set; }
        public string ClothId { get; set; }
        public virtual Cloth Cloth { get; set; }
        public string ReferenceLink { get; set; }
        public decimal Price { get; set; }
        public TradeType TradeType { get; set; }
        public DeliveryType DeliveryType { get; set; }
    }

    public enum TradeType
    {
        allegro,
        vinted
    }

    public enum DeliveryType
    {
        inpost,
        ruchPackage,
        polishPost
    }
}
