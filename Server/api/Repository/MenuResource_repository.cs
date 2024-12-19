using api.Dtos.MenuResource;
using api.Identity;
using api.Interfaces;
using IdentityCafeteriaModel;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public class MenuResource_repository : IMenuResource_Repository
    {
        private readonly ApplicationDBContext _context;
        public MenuResource_repository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<V_Menu>> getAllMenus()
        {
            var resultTablesOfMenu = await _context.VMenus
                .FromSqlRaw("""
                                select *
                                From DBO.V_Menu
                            """)
                .ToListAsync();

            return resultTablesOfMenu;
        }
        public async Task<(List<V_Menu>, List<V_Role_Menu>, List<V_Permission_RoleMenu>)> getAllMenuResource()
        {
            var resultTablesOfMenu = await _context.VMenus
                .FromSqlRaw("""
                                select *
                                From DBO.V_Menu
                            """)
                .ToListAsync();

            var resultTablesOfRoleMenu = await _context.VRole_Menus
                .FromSqlRaw("""
                                select *
                                From DBO.V_Role_Menu
                            """)
                .ToListAsync();

            var resultTablesOfPermission = await _context.VPermission_Roles
                .FromSqlRaw("""
                                select *
                                From DBO.V_Permission_RoleMenu
                            """)
                .ToListAsync();

            return (resultTablesOfMenu, resultTablesOfRoleMenu, resultTablesOfPermission);
        }

        public async Task<List<V_Role>> getAllRoles()
        {
            var resultTablesOfRoles = await _context.RoleModels
                .FromSqlRaw("""
                                select *
                                From DBO.V_Role
                            """)
                .ToListAsync();

            return resultTablesOfRoles;
        }
    }
}
