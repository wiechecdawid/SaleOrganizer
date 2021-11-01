using System;

namespace SaleOrganizer.Domain
{
    public class RefreshToken
    {
        public int Id { get; set; }
        public AppUser User { get; set; }
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; } = DateTime.UtcNow.AddDays(7);
        public bool IsExpired => DateTime.UtcNow >= ExpiryDate;
        public DateTime? Revoked { get; set; }
        public bool IsActive => Revoked == null && !IsExpired;
    }
}