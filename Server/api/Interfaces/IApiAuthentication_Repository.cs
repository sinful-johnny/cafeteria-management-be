using IdentityCafeteriaModel;

namespace api.Interfaces
{
    public interface IApiAuthentication_Repository
    {
        public Task<List<V_TakePermission_From_UserAndApiAndRole>> getRoleAndPermission(string UserName, string Api);
    }
}
