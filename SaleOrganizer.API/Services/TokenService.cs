using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using SaleOrganizer.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;

namespace SaleOrganizer.API.Services
{
    public class TokenService
    {
        public string CreateToken(AppUser user)
        {
            var claims = CreateClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Temporary hardcoded key"));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private List<Claim> CreateClaims(AppUser user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
                //new Claim(ClaimTypes.Expiration, DateTime.Now.AddDays(7).ToString()),
            };

            if(user.Services != null )
            {
                foreach(var service in user.Services)
                {
                    claims.Add(new Claim("Services", service));
                }
            }

            return claims;
        }
    }
}