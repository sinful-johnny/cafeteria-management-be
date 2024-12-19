
namespace api.Models
{
    public class RoleMenuPerm
    {
        public required Role Role { get; set; }
        public required Menu Menu { get; set; }
        public Perm? Perm { get; set; }
    }
}
