using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SaleOrganizer.API.DTOs;
using SaleOrganizer.API.Services;
using SaleOrganizer.Domain;

namespace SaleOrganizer.API.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController: ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly TokenService _tokenSerice;

        public AccountController(UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager, TokenService tokenService)
        {
            (_userManager, _signInManager, _tokenSerice) = (userManager, signInManager, tokenService);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if(user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);
            if(result.Succeeded)
            {
                return Ok(new UserDto
                {
                    UserName = user.UserName,
                    Token = _tokenSerice.CreateToken(user),
                    Email = user.Email
                });
            }

            return Unauthorized();
        }
    }
}