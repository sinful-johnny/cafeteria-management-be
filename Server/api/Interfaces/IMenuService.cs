using System.Collections.Generic;
using System.Security.Principal;
using api.Models;

namespace api.Interfaces
{
    public interface IMenuService
    {
        public List<MenuItem> GetMenuByUser(IPrincipal user);
    }
}