using api.Dtos.FOOD;
using api.Dtos.FOOD_TABLE;
using api.Dtos.MenuResource;
using api.Models;
using IdentityCafeteriaModel;

namespace api.Mappers
{
    public static class MenuResourceMapper
    {
        public static MenuResourceDto ToMenuResourceDto(this V_Menu Menu, List<MenuResourceDto> MenuChildrens, List<RolePermissionDto> rolePermissions)
        {
            return new MenuResourceDto
            {
                menuID = Menu.menuID,
                MenuName = Menu.menuName,
                OwnerRoles = rolePermissions,
                children = MenuChildrens
            };
        }

        public static Menu ToMenuModel(this V_Menu Menu)
        {
            return new Menu
            {
                Id = Menu.menuID,
                MenuName = Menu.menuName
            };
        }

        public static Role ToRoleModel(this V_Role Role)
        {
            return new Role
            {
                Id = Role.RoleID,
                RoleName = Role.RoleName,
                UserCount = Role.UserCount
            };
        }

        public static RolePermissionDto ToRolePermissionDto(this V_Role_Menu roleMenu, List<PermissionDto> permissions)
        {
            return new RolePermissionDto
            {
                menuID = roleMenu.menuID,
                rolemenuID = roleMenu.rolemenuID,
                RoleName = roleMenu.roleName,
                PermissionType = permissions,
                permissionID = roleMenu.permissionID
            };
        }

        public static PermissionDto ToPermissionDto(this V_Permission_RoleMenu permissions)
        {
            return new PermissionDto
            {
                rolemenuID = permissions.rolemenuID,
                PermissionName = permissions.permissionName,
                permissionID = permissions.permissionID,
            };
        }
    }
}
