using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using SaleOrganizer.Domain;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;

namespace SaleOrganizer.API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;

        public TokenService(IConfiguration config)
        {
            _config = config;
        }
        public string CreateToken(AppUser user)
        {
            var claims = CreateClaims(user);

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Token:SecretKey"]));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(1),
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
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.Email, user.Email)
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

        public RefreshToken GenerateRefreshToken()
        {
            var randomNum = new byte[32];

            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNum);
            return new RefreshToken{ Token = Convert.ToBase64String(randomNum) };
        }
    }
}