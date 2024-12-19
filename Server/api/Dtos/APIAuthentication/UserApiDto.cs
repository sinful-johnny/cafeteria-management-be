using api.Models.AuthModels;

namespace api.Dtos.APIAuthentication
{
    public class UserApiDto
    {
        public string UserName { get; set; }
        public string API { get; set; }
        public List<UserApiRoleDto>? Roles { get; set; }
    }
}
