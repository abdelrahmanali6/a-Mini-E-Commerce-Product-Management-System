using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Management_System.DTOs.Account;
using Management_System.Interfaces;
using Management_System.Models;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace Management_System.Controllers
{

    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly ICartItemRepository _cartItemRepo;
        private readonly SignInManager<AppUser> _signinManager;
        public AccountController(UserManager<AppUser> userManager,ITokenService tokenService, ICartItemRepository cartItemRepo,SignInManager<AppUser> signinManager)
        {
            _userManager = userManager;
            _tokenService = tokenService;
            _cartItemRepo = cartItemRepo;
            _signinManager = signinManager;
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto loginDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.Users.FirstOrDefaultAsync(x => x.Email == loginDto.Email);
            if(user == null)
            {
                return Unauthorized("Invalid Email");
            }

            var result = await _signinManager.CheckPasswordSignInAsync(user, loginDto.Password,false);

            if(!result.Succeeded)
            {
                return Unauthorized("Email not found and/or password Incorrect");
            }

            return Ok
            (
                new NewUserDto
                {
                    UserName = user.UserName,
                    Email = user.Email,
                    CartItemId = user.CartItemId,
                    Token = _tokenService.CreateToken(user)
                }
            );
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                var appUser = new AppUser
                {
                    UserName = registerDto.Username,
                    Email = registerDto.Email
                };

                var createUser = await _userManager.CreateAsync(appUser, registerDto.Password);

                if (createUser.Succeeded)
                {
                    appUser.CartItemId = await _cartItemRepo.CreateAsync();
                    var roleResult = await _userManager.AddToRoleAsync(appUser, "User");
                    if (roleResult.Succeeded)
                    {

                        return Ok(
                            new NewUserDto
                            {
                                UserName = appUser.UserName,
                                Email = appUser.Email,
                                CartItemId = appUser.CartItemId,
                                Token = _tokenService.CreateToken(appUser)
                            }
                        );
                    }
                    else
                    {
                        return StatusCode(500, roleResult.Errors);
                    }
                }
                else
                {
                    return StatusCode(500, createUser.Errors);
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}