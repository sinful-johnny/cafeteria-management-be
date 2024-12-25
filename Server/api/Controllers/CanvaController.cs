using api.Identity;
using api.Interfaces;
using api.Mappers;
using api.Models.AuthModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace api.Controllers
{
    [Route("api/canva")]
    [ApiController]
    [Authorize(Roles = "Manager, Staff, Customer")]
    public class CanvaController : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        private readonly ICanvaRepository _canvaRepo;
        public CanvaController(ApplicationDBContext context, ICanvaRepository canvaRepo)
        {
            _canvaRepo = canvaRepo;
            _context = context;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllCanva()
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //// Extract the MenuResource from the token
            //var menuResourceClaim = User.Claims
            //    .FirstOrDefault(c => c.Type == "MenuResource")?.Value; 
            //if (menuResourceClaim == null) 
            //{ 
            //    return Unauthorized();
            //}

            //var menuResource = JsonSerializer.Deserialize<MenuResource>(menuResourceClaim);

            //// Authorize using the extracted MenuResource

            //var authorizationResult = await _authorizationService.AuthorizeAsync(User, menuResource, "ReadWrite");

            //if (authorizationResult.Succeeded) { return Ok("Access granted to the resource."); }

            var canvaModels = await this._canvaRepo.GetAllCanvaAsync();
            var canvaDtos = canvaModels.Select(c => c.ToCanvaDto());
            return Ok(canvaDtos);
        }
    }
}
