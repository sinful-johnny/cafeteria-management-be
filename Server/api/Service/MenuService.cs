using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using api.Identity;
using api.Interfaces;
using api.Models;
using Microsoft.AspNetCore.Identity;

namespace api.Service
{
    public class MenuService : IMenuService
    {
        private readonly ApplicationDBContext _context;
        private readonly UserManager<ApplicationUser> _manager;

        public MenuService(ApplicationDBContext context, UserManager<ApplicationUser> manager)
        {
            _context = context;
            _manager = manager;
        }

        public List<MenuItem> GetMenuByUser(IPrincipal user)
        {
            if (user == null)
            {
                return new List<MenuItem>();
            }

            var principal = user as ClaimsPrincipal;

            var id = _manager.GetUserId(principal);

            var viewableItems = principal.Claims
                .Where(e => e.Value == "View")
                .Select(item => item.Type)
                .ToList();

            var result = _context.MenuItems
                .Where(item => viewableItems.Any(u => item.Id.ToString() == u))
                .ToList();

            return result;
        }
    }
}