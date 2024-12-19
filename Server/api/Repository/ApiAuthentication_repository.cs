using api.Identity;
using api.Interfaces;
using IdentityCafeteriaModel;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace api.Repository
{
    public class ApiAuthentication_repository : IApiAuthentication_Repository
    {
        private readonly ApplicationDBContext _context;
        public ApiAuthentication_repository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<V_TakePermission_From_UserAndApiAndRole>> getRoleAndPermission(string UserName, string Api)
        {
            var resultTablesOfPermissionRole = await _context.V_TakePermission
                .FromSqlRaw("Exec DBO.sp_TakePermission_From_UserAndApi @UserName={0}, @Api={1}", UserName, Api)
                .ToListAsync();


            return (resultTablesOfPermissionRole);
        }
    }
}
