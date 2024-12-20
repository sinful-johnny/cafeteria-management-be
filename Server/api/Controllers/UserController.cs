using api.Dtos.MenuResource;
using api.Interfaces;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/User")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUser_Roles_repository _user_Roles_Repository;
        public UserController(IUser_Roles_repository user_Roles_Repository)
        {
            _user_Roles_Repository = user_Roles_Repository;
        }

        [HttpGet]
        //[Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GetAllUsersContainRoles()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var (users, roles) = await _user_Roles_Repository.getUserContainRoles();

            // Map roles to roles model
            var roleModels = roles.Select(r => r.ToRolesModel()).ToList();

            // Group roles by UserId
            var rolesByUserId = roleModels
                .GroupBy(r => r.UserId)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Map users to user models and assign roles
            var userModels = users.Select(u => u.ToUserModel(
                rolesByUserId.ContainsKey(u.Id) ? rolesByUserId[u.Id] : new List<Roles>()
            )).ToList();

            // Serialize the object manually using JsonSerializer
            var jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase, // Ensure camelCase naming for JSON
                WriteIndented = true // Optional: Pretty-print JSON
            };
            var jsonResult = JsonSerializer.Serialize(userModels, jsonOptions);

            return Content(jsonResult, "application/json");
        }
    }
}
