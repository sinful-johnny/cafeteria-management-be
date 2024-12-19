using api.Dtos.APIAuthentication;
using api.Dtos.MenuResource;
using api.Identity;
using api.Models.AuthModels;
using IdentityCafeteriaModel;

namespace api.Mappers
{
    public static class TakeRolePermissionsMapper
    {
        public static UserApiDto ToUserApiDto(this V_TakePermission_From_UserAndApiAndRole VTakePermisson, List<UserApiRoleDto> Roles)
        {
            return new UserApiDto
            {
                UserName = VTakePermisson.UserName,
                API = VTakePermisson.API,
                Roles = Roles

            };
        }
        public static UserApiRoleDto ToRoleDto(this V_TakePermission_From_UserAndApiAndRole VTakePermisson, List<UserApiPermissionDto> Permissions)
        {
            return new UserApiRoleDto
            {
                RoleName = VTakePermisson.RoleName,
                Permissions = Permissions
            };
        }

        public static UserApiPermissionDto ToRolePermissionDto(this V_TakePermission_From_UserAndApiAndRole VTakePermisson)
        {
            return new UserApiPermissionDto
            {
                Permission = VTakePermisson.Permission
            };
        }
    }
}
