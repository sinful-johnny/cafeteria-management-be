using api.Models;

namespace api.Interfaces
{
    public interface IUser_Roles_repository
    {
        public Task<List<UserRolesModel>> getRolesFromUser(string UserName);
    }
}
