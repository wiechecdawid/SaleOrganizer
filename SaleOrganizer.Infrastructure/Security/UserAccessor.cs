using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using SaleOrganizer.Application.Interfaces;

namespace SaleOrganizer.Infrastructure.Security
{
    public class UserAccessor : IUserAccessor
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserAccessor(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetEmail()
        {
            return _httpContextAccessor.HttpContext.User.FindFirstValue(ClaimTypes.Email);
        }
    }
}