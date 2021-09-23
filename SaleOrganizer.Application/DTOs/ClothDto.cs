using System;
using System.Collections.Generic;
using System.Text;
using SaleOrganizer.Domain;

namespace SaleOrganizer.Application.DTOs
{
    public class ClothDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Photo Photo { get; set; }
        public string StorageInfo { get; set; }
        public string DetailedStorageInfo { get; set; }
        public ClothStatusDto Status { get; set; }
    }

    public enum ClothStatusDto
    {
        sold,
        bought,
        atHome,
        atParents
    }
}
