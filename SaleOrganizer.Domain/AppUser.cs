using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace SaleOrganizer.Domain
{
    public class AppUser: IdentityUser
    {
        public List<string> Services { get; set; }
    }
}