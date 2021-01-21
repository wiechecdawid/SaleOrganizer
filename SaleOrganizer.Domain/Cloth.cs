using System.Collections.Generic;

namespace SaleOrganizer.Domain
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ClothStatus Status { get; set; }
        public ICollection<Trade> Trades { get; set; }
    }

    public enum ClothStatus
    {
        sold,
        bought,
        atHome,
        atParents
    }
}
