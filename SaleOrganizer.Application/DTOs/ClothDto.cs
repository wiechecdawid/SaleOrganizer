using System;
using System.Collections.Generic;
using System.Text;

namespace SaleOrganizer.Application.DTOs
{
    public class ClothDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
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
