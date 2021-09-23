using System.Collections.Generic;

namespace SaleOrganizer.Domain
{
    public class Cloth
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ClothStatus Status { get; set; }
        public Photo Photo { get; set; }
        public string StorageInfo { get; set; }
        public string DetailedStorageInfo { get; set; }
        public ICollection<Offering> Offerings { get; set; }
        public ICollection<Purchase> Purchases { get; set; }
    }

    public enum ClothStatus
    {
        sold,
        bought,
        atHome,
        atParents
    }
}
