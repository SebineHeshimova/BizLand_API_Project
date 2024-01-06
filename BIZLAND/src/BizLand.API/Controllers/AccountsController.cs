using BizLand.Business.CustomExceptions;
using BizLand.Business.DTOs.AccountDTOS;
using BizLand.Business.Services.Interfaces;
using BizLand.Core.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BizLand.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountsController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IAccountService _accountService;
        public AccountsController(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IAccountService accountService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _accountService = accountService;
        }

        [HttpPost("Login")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Login([FromForm] LoginDTO loginDTO)
        {
            string token = null;
            try
            {
               token= await _accountService.LoginAsync(loginDTO);
            }
            catch(InvalidUserNameOrPassword ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidLoginException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok(token);
        }


        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register([FromForm]RegisterDTO registerDTO)
        {
            try
            {
                await _accountService.RegisterAsync(registerDTO);
            }
            catch(InvalidUserNameException ex)
            {
                return BadRequest(ex.Message);
            }
            catch(InvalidEmailException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidUserException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (InvalidRolException ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }

        //[HttpGet]
        //public async Task<IActionResult> LogOut()
        //{
        //    _accountService.LogoutAsync();
        //    return Ok();
        //}

        //[HttpGet("CreateAdmin")]
        //public async Task<IActionResult> CreateAdmin()
        //{
        //    AppUser appUser = new AppUser()
        //    {
        //        FullName = "Sebine Heshimova",
        //        UserName = "Sebine2003"
        //    };
        //    var result = await _userManager.CreateAsync(appUser, "Sebine_123");
        //    var addRole = await _userManager.AddToRoleAsync(appUser, "SuperAdmin");
        //    return Ok(addRole);
        //}
        //[HttpGet("CreateRole")]
        //public async Task<IActionResult> CreateRole()
        //{
        //    var role1 = new IdentityRole("SuperAdmin");
        //    var role2 = new IdentityRole("Admin");
        //    var role3 = new IdentityRole("User");

        //    await _roleManager.CreateAsync(role1);
        //    await _roleManager.CreateAsync(role2);
        //    await _roleManager.CreateAsync(role3);

        //    return Ok("Rol yaradildi");
        //}
    }
}
