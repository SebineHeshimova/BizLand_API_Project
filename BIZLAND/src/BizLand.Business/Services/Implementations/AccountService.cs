using BizLand.Business.CustomExceptions;
using BizLand.Business.DTOs.AccountDTOS;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace BizLand.Business.Services.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IConfiguration _config;

        public AccountService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, SignInManager<AppUser> signInManager, IConfiguration config)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }

        public async Task<string> LoginAsync(LoginDTO loginDTO)
        {
            AppUser appUser = null;
            appUser = await _userManager.FindByNameAsync(loginDTO.UserNameorEmail);
            if (appUser == null)
            {
                appUser = await _userManager.FindByEmailAsync(loginDTO.UserNameorEmail);
                if (appUser == null)
                {
                    throw new InvalidUserNameOrPassword("Invalid UserName, Email or Password!");
                }
            }

            var result = await _signInManager.PasswordSignInAsync(appUser, loginDTO.Password, true, false);
            if (!result.Succeeded) throw new InvalidLoginException("Login olmaq mumkun olmadi!");

            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Sub, appUser.Id),
                new Claim("FullName", appUser.FullName),
                new Claim(ClaimTypes.Name, appUser.UserName)
            };

            var roles = await _userManager.GetRolesAsync(appUser);

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            //foreach(var role in roles)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}

            var symmetricSecurityKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_config.GetSection("JWT:Key").Value));

            var signingCred = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwt = new JwtSecurityToken(
            audience: _config.GetSection("JWT:Audience").Value,
            issuer: _config.GetSection("JWT:Issuer").Value,
            claims : claims,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddHours(2),
            signingCredentials: signingCred);

            var token=new JwtSecurityTokenHandler().WriteToken(jwt);

            return token;
        }


        //public async Task LogoutAsync()
        //{
        //    await _signInManager.SignOutAsync();
        //}

       

        public async Task RegisterAsync(RegisterDTO registerDTO)
        {
            AppUser appUser = null;
            appUser = await _userManager.FindByNameAsync(registerDTO.UserName);
            if (appUser != null)
            {
                throw new InvalidUserNameException("Bu UserName'li user var!");
            }
            appUser = await _userManager.FindByEmailAsync(registerDTO.Email);
            if (appUser != null)
            {
                throw new InvalidEmailException("Bu Email'li user var!");
            }
            appUser = new AppUser
            {
                UserName = registerDTO.UserName,
                FullName = registerDTO.FullName,
                Email = registerDTO.Email
            };
            var result1 = await _userManager.CreateAsync(appUser, registerDTO.Password);
            if (!result1.Succeeded) throw new InvalidUserException("User yaradila bilmedi!");

            var result2 = await _userManager.AddToRoleAsync(appUser, "User");
            if (!result2.Succeeded) throw new InvalidRolException("Rol elave etmek olmadi!");

        }
    }
}
