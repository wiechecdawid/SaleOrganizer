using System;

namespace SaleOrganizer.Domain
{
    public class Cloth
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ClothStatus Status { get; set; }
    }

    public enum ClothStatus
    {
        sold,
        bought,
        atHome,
        atParents
    }
}
