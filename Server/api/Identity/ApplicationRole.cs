﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace api.Identity
{
    public class ApplicationRole : IdentityRole<string>
    {
        public ApplicationRole() { }
        public ApplicationRole(string name)
            : this()
        {
            this.Name = name;
            RoleApis = new HashSet<ApplicationRoleAPI>();
        }

        public ICollection<ApplicationRoleAPI> RoleApis { get; set; }

    }
}
