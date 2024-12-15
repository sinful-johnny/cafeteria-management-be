﻿using api.Dtos.Account;
using api.Interfaces;
using api.Models.AuthModels;
using CafeteriaDB;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;
        private readonly IAdminRepository _adminRepo;
        private readonly IUserService _userService;

        public AccountController(IAdminRepository adminRepo, 
            ITokenService tokenService, IUserService userService)
        {
            _adminRepo = adminRepo;
            _tokenService = tokenService;
            _userService = userService;
        }

        [HttpPost("login")]

        public async Task<IActionResult> Login (LoginDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var admin = new ADMIN
            {
                EMAIL = loginDto.EmailAddress
            };

            if (loginDto.Password == null)
            {
                return BadRequest(ModelState);
            }

            string result = await _adminRepo.LoginAdminAsync(loginDto);

            if (result.Contains("Invalid email or password.") || result.Contains("Invalid email or password.") )
                    return Unauthorized("Username not found or password incorrect");

            var menuResource = new MenuResource
            {
                MenuName = "MainMenu",
                OwnerRoles = new List<RolePermission>
    {
        new RolePermission
        {
            RoleName = "Admin",
            PermissionType = new List<string> { "Read", "Write", "Delete" }
        },
        new RolePermission
        {
            RoleName = "User",
            PermissionType = new List<string> { "Read" }
        }
    },
                children = new List<MenuResource>
    {
        new MenuResource
        {
            MenuName = "SubMenu1",
            OwnerRoles = new List<RolePermission>
            {
                new RolePermission
                {
                    RoleName = "Admin",
                    PermissionType = new List<string> { "Read", "Write" }
                }
            },
            children = new List<MenuResource>
            {
                new MenuResource
                {
                    MenuName = "SubSubMenu1",
                    OwnerRoles = new List<RolePermission>
                    {
                        new RolePermission
                        {
                            RoleName = "Admin",
                            PermissionType = new List<string> { "Read" }
                        }
                    }
                }
            }
        },
        new MenuResource
        {
            MenuName = "SubMenu2",
            OwnerRoles = new List<RolePermission>
            {
                new RolePermission
                {
                    RoleName = "User",
                    PermissionType = new List<string> { "Read" }
                }
            }
        }
    }
            };

            return Ok(
                new NewUserDto
                {
                    Email = admin.EMAIL,
                    Token = await _tokenService.CreateToken(menuResource)
                }
            );
        }

        [HttpPost("register")]

        public async Task<IActionResult> Register([FromBody] RegisterDto registerDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var admin = new ADMIN
                {
                    EMAIL = registerDto.EmailAddress
                };

                if (registerDto.Password == null)
                {
                    return BadRequest(ModelState);
                }


                string result = await _adminRepo.RegisterAdminAsync(registerDto);

                var menuResource = new MenuResource
                {
                    MenuName = "MainMenu",
                    OwnerRoles = new List<RolePermission>
    {
        new RolePermission
        {
            RoleName = "Admin",
            PermissionType = new List<string> { "Read", "Write", "Delete" }
        },
        new RolePermission
        {
            RoleName = "User",
            PermissionType = new List<string> { "Read" }
        }
    },
                    children = new List<MenuResource>
    {
        new MenuResource
        {
            MenuName = "SubMenu1",
            OwnerRoles = new List<RolePermission>
            {
                new RolePermission
                {
                    RoleName = "Admin",
                    PermissionType = new List<string> { "Read", "Write" }
                }
            },
            children = new List<MenuResource>
            {
                new MenuResource
                {
                    MenuName = "SubSubMenu1",
                    OwnerRoles = new List<RolePermission>
                    {
                        new RolePermission
                        {
                            RoleName = "Admin",
                            PermissionType = new List<string> { "Read" }
                        }
                    }
                }
            }
        },
        new MenuResource
        {
            MenuName = "SubMenu2",
            OwnerRoles = new List<RolePermission>
            {
                new RolePermission
                {
                    RoleName = "User",
                    PermissionType = new List<string> { "Read" }
                }
            }
        }
    }
                };
                if (result.Contains("User registered successfully"))
                {
                    return Ok
                            (
                                new NewUserDto
                                {
                                    Email = admin.EMAIL,
                                    Token = await _tokenService.CreateToken(menuResource)
                                }
                            );
                }
                else
                {
                    return BadRequest(new { Message = result });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
