using api.Models;
using api.Models.AuthModels;
using CafeteriaDB;

namespace api.Interfaces
{
    public interface ITokenService
    {
        public Task<string> CreateToken(MenuResource resource);
    }
}
