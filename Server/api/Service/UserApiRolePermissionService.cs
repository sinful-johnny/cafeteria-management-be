using api.Models.AuthModels;
using Microsoft.AspNetCore.Authorization;

namespace api.Service
{
    public class UserApiRolePermissionService : AuthorizationHandler<PolicyRequirementModel, UserApiRolePermission>
    {
        protected override Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            PolicyRequirementModel requirement,
            UserApiRolePermission resource)
        {
            // Access the policy name
            var policyName = requirement.PolicyName; //RW; R;

            // Check if the user is in any of the roles that define ownership of the resource
            if (resource.Roles.Any(
                role => context.User.IsInRole(role.RoleName)
                && role.Permissions.Any(p => p == policyName)
                ))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
