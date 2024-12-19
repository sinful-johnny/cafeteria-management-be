using api.Identity;
using api.Interfaces;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class User_Roles_repository : IUser_Roles_repository
    {
        private readonly ApplicationDBContext _context;
        public User_Roles_repository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<List<UserRolesModel>> getRolesFromUser(string UserName)
        {
            var UserRoles = await _context.userRolesModels
                .FromSqlRaw("EXEC DBO.sp_TakeRoleFromUser @UserName={0}", UserName)
                .ToListAsync();
            return UserRoles;
        }
    }
}
